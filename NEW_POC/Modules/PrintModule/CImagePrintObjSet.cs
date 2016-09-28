using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Modules.PrintModule
{
    public class CImagePrintObjSet:CPrintObjSet 
    {
        private Image _inimage;
        public Image InImage
        {
            get { return _inimage; }
            set 
            { 
                _inimage = value;
                _width = _inimage.Width;
                _height = _inimage.Height;
                la.Width = _width;
                la.Height = _height;
            }
        }

        public CImagePrintObjSet()
        {
            la = new Label();
            la.BackColor = System.Drawing.Color.White;
            la.Location = new System.Drawing.Point(_x, _y);
            //la.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            la.Paint += new System.Windows.Forms.PaintEventHandler(this.label_Paint);
            la.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp); 
        }

        public override void ShowObj(Graphics g)
        {
            //g.DrawString(_printtext, _fn, Brushes.Blue, 0, 2);
            g.DrawImage(_inimage, 0, 0); 
        }

        public override void PrintObj(Graphics g)
        {
           // g.DrawString(_printtext, _fn, Brushes.Blue, _x, _y);
            g.DrawImage(_inimage, _x, _y);
        }
    }
}
