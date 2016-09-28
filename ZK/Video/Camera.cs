using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Cn.Youdundianzi.Share.Module.Video
{
    public partial class Camera : UserControl
    {
        public const int USER = 0x0400; // 是windows系统定义的用户消息
        FileStream outfile;
        byte[] databuf;
        int datalength = 0;
        short FrameType;// (short)FrameType_t.PktSysHeader;


        public Camera(int chn)
        {
            InitializeComponent();
            channel = chn;
        }
        public Camera()
        {
            InitializeComponent();
           
        }

        public void Camera_Move(object sender, EventArgs e)
        {
            try
            {
                CMyVideo.SetVideoDlgRect(0, 0, this.Width, this.Height);
                CMyVideo.MoveVideoDlg();
            }
            catch
            {
            }
        }

        public void Camera_Resize(object sender, EventArgs e)
        {
            try
            {
                CMyVideo.SetVideoDlgRect(0, 0, this.Width, this.Height);
                CMyVideo.MoveVideoDlg();
            }
            catch
            {
            }
        }

        public void Camera_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.CloseCamera();
            }
            catch
            {
            }
        }


        private void Camera_Load(object sender, EventArgs e)
        {
            try
            {
                int a = CMyVideo.CreateVideoDlg(this.Handle, 0, 0, 800, 600);//this.Width, this.Height);
                CMyVideo.SetVideoDlgRect(0, 0, this.Width, this.Height);
                CMyVideo.MoveVideoDlg();
                CMyVideo.SelectChannel(channel);
                CMyVideo.WRegisterMessageNotifyHandle(this.Handle, USER);
                databuf = new byte[0x30000];
            }
            catch
            {
            }
        }

        public bool CaptureImage(string path)
        {
            try
            {
                CMyVideo.WCaptureImage(channel, path);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void CloseCamera()
        {
            try
            {
                CMyVideo.Close();
            }
            catch
            {
            }
        }

        public void SetChannel(int i)
        {
            Channel = i;
        }

        private int channel;
        public int Channel
        {
            get
            {
                return channel;
            }
            set
            {
                try
                {
                    if (value >= 0)
                    {
                        CMyVideo.SelectChannel(value);
                        channel = value;
                    }
                }
                catch
                {
                }
            }
        }


        public void StartVideoCapture(string filename)
        {
            try
            {
                CMyVideo.WStartVideoCapture(channel, "tmp.mp4");
                outfile = File.Open(filename, FileMode.Create, FileAccess.Write);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("视频捕捉失败！");
            }
        }


        public void StopVideoCapture()
        {
            try
            {
                CMyVideo.WStopVideoCapture(channel);
                outfile.Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("视频文件关闭失败！");
            }

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == USER)
            {
                datalength = 0x30000;
                unsafe
                {
                    int reval = CMyVideo.WReadStreamData(0, databuf, ref datalength, ref FrameType);
                    if (reval >= 0)
                    {
                        if ((FrameType == (short)FrameType_t.PktSysHeader) || (FrameType == (short)FrameType_t.PktIFrames) || (FrameType == (short)FrameType_t.PktPFrames))
                        {
                            byte[] tmpchar = new byte[datalength];
                            Buffer.BlockCopy(databuf, 0, tmpchar, 0, datalength);
                            outfile.Write(tmpchar, 0, tmpchar.Length);

                        }
                    }
                }
            }
            base.WndProc(ref m);
        }
    }
}
