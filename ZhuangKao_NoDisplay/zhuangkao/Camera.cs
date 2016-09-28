using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao.video
{
    public partial class Camera : UserControl
    {
         public Camera(int chn)
        {
            InitializeComponent();
            channel = chn;
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

        private void Camera_Load(object sender, EventArgs e)
        {
            try
            {
                int a = CMyVideo.CreateVideoDlg(this.Handle, 0, 0, 800, 600);//this.Width, this.Height);
                CMyVideo.SetVideoDlgRect(0, 0, this.Width, this.Height);
                CMyVideo.MoveVideoDlg();
                CMyVideo.SelectChannel(channel);
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

        //public bool StartRecordVideo()
        //{

        //}

 
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
    }
}
