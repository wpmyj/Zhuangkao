using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Cn.Youdundianzi.Share.Module.Video
{
    public partial class VideoPlayForm : Form
    {
        public const int USER = 0x0401;

        Timer tm;
        string filename;
        CVideoPlay videoplayer;

        /// <summary>
        /// 总播放时间
        /// </summary>
        int iTotalTime = 0;


        /// <summary>
        /// 总帧数
        /// </summary>
        int iTotalFrames = 0;

        /// <summary>
        /// 手动改变进度条
        /// </summary>
        bool IsMyChange=false;

        /// <summary>
        /// 暂停
        /// </summary>
        bool pause = true;

        /// <summary>
        /// 播放完成
        /// </summary>
        bool PlayEnd = false;

        public VideoPlayForm(string filename)
        {
            InitializeComponent();
            this.filename = filename;
            tm = new Timer();
            tm.Tick += new EventHandler(tm_Tick);
            tm.Interval = 100;
        }

        void tm_Tick(object sender, EventArgs e)
        {
            int curFrames = videoplayer.VideoGetCurrentFrameNum(1);
            slider1.Value = curFrames;
            //throw new Exception("The method or operation is not implemented.");
            this.Text = "视频回放" + "     第"+videoplayer.VideoGetPlayedTime(1).ToString() + "秒";
        }

        private void VideoPlay_Form_Load(object sender, EventArgs e)
        {
            videoplayer = new CVideoPlay();
            videoplayer.VideoOpenFile(1,filename);
            videoplayer.VideoSetFileRefCallBack(1, mycallback, (int)this.Handle);
            videoplayer.VideoSetFileEndMsg(1, this.Handle, USER);
            videoplayer.VideoPlay(1, this.Handle);
            tm.Start();
        }


        /// <summary>
        /// 生成索引文件的回调函数
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="nUser"></param>
        private static CVideoPlay.pfnFileRefDone pfnFR;//防止被垃圾回收
        private void mycallback(Int32 nPort, int nUser)
        {
            if (slider1.InvokeRequired)
            {
                pfnFR = new CVideoPlay.pfnFileRefDone(mycallback);
                slider1.BeginInvoke(pfnFR, nPort, nUser);
            }
            else
            {
                int nSize = 0;
                byte[] p1 = new byte[1]; ;
                if (videoplayer.VideoGetRefValue(1, null, ref nSize))
                {
                    byte[] p = new byte[nSize];
                    if (p.Length > 0)
                    {
                        if (videoplayer.VideoGetRefValue(1, p, ref nSize))
                        {
                            using (FileStream fs = File.Open(filename + ".idx", FileMode.Create, FileAccess.Write))
                            {
                                fs.Write(p, 0, p.Length);
                                fs.Close();
                            }
                        }
                    }
                }
                iTotalTime = (int)videoplayer.VideoGetFileTime(1);
                iTotalFrames = videoplayer.VideoGetFileTotalFrames(1);
                slider1.Maximum = iTotalFrames;
                slider1.Value = 0;
            }
        }

        private void VideoPlay_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            tm.Stop();
            tm.Dispose();
            videoplayer.VideoCloseFile(1);
            //删除临时索引文件
            if (File.Exists(filename + ".idx"))
            {
                File.Delete(filename + ".idx");
            }
        }


        private void slider1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMyChange = true;
            if (pause)
            {
                tm.Stop();
            }
        }



        private void slider1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMyChange)
            {
                int curFrameNum = ((DevComponents.DotNetBar.Controls.Slider)sender).Value;
                videoplayer.VideoSetCurrentFrameNum(1, curFrameNum);
                IsMyChange = false;
            }

            IsMyChange = false;
            if (pause)
            {
                tm.Start();
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            videoplayer.VideoPause(1, pause);
            if (pause)
            {
                tm.Stop();
                pause = false;
                buttonX1.Text = ">";
            }
            else
            {
                if (PlayEnd)
                {
                    videoplayer.VideoPlay(1, this.Handle);
                    PlayEnd = false;
                }
                tm.Start();
                pause = true;
                buttonX1.Text = "||";
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == USER)
            {  
                tm.Stop();
                MessageBox.Show("考试视频播放完成！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                PlayEnd = true;
                buttonX1.Text = ">";
                pause = false;
                slider1.Value = 0;
                slider1.Refresh();
                this.Text = "考试回放";
            }
            base.WndProc(ref m);
        }



    }
}