using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace lukao
{
    public class CTextPrintObjSet:CPrintObjSet 
    {
      
        private string _printtext;

        public string Printtext
        {
            get { return _printtext; }
            set 
            {
                SizeF size;
                Graphics g = la.CreateGraphics();
                size = g.MeasureString(value , _fn);
                _width = Convert.ToInt16(size.Width) + 6;
                _height = Convert.ToInt16(size.Height) + 4;
                la.Size = new System.Drawing.Size(_width, _height);
                _printtext = value;
            }
        }

        public CTextPrintObjSet()
        {
            la = new Label();
            la.BackColor = System.Drawing.Color.White;
            la.Location = new System.Drawing.Point(_x, _y);
            //la.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            la.Paint += new System.Windows.Forms.PaintEventHandler(this.label_Paint);
            la.MouseUp  += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp); 
            _fn = new Font(FontFamily.GenericMonospace, 10.0F, FontStyle.Bold);
        }

        private Font _fn;
        public Font Fn
        {
            get { return _fn; }
            set 
            {
                SizeF size;
                Graphics g = la.CreateGraphics();
                size = g.MeasureString(_printtext, value);
                _width = Convert.ToInt16(size.Width) + 6;
                _height = Convert.ToInt16(size.Height) + 4;
                la.Size = new System.Drawing.Size(_width, _height);
                _fn = value; 
            }
        }

        public override  void ShowObj(Graphics g)
        {  
            g.DrawString(_printtext, _fn, Brushes.Blue, 0, 2);
        }

        public override void PrintObj(Graphics g)
        {
            g.DrawString(_printtext, _fn, Brushes.Blue, _x , _y);
        }
    }
}
