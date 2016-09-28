using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace zhuangkao
{
    public class CShowLinkState:System.Windows.Forms.PictureBox
    {
        private Bitmap linkbmp;
        private Bitmap closebmp;

        public CShowLinkState()
        {
            
        }

        public void init()
        {
            closebmp = new Bitmap(".\\img\\red2.gif");
            linkbmp = new Bitmap(".\\img\\green2.gif");
            this.BackgroundImage = closebmp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackColor = Color.Transparent;
        }

        private bool _linkstate;
        public bool LinkState
        {
            get { return _linkstate; }
            set
            {
                if (value)
                {
                    this.BackgroundImage = linkbmp;
                }
                else
                {
                    this.BackgroundImage = closebmp;
                }
                _linkstate = value;

            }
        }
    }
}
