using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace lukao
{
    public abstract  class  CPrintObjSet
    {
        public Label la;

        protected int _x;
        public int X
        {
            get { return _x; }
            set 
            {
                if (value >= 0)
                {
                    _x = value;
                    la.Left = _x;
                }
                else
                {
                    _x = 0;
                }
            }
        }

        public int mmX
        {
            get { return _x / 4; }
            set 
            {
                _x = value * 4;
                la.Left = _x;
            }
        }

     

        protected int _y;
        public int Y
        {
            get { return _y; }
            set 
            {
                if (value >= 0)
                {
                    _y = value;
                    la.Top = _y;
                }
                else
                {
                    _y = 0;
                }
            }
        }

        public int mmY
        {
            get { return _y / 4; }
            set 
            {
                _y = value * 4; 
                la.Top = _y; 
            }
        }

        protected int _width;
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        protected int _height;
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public abstract void ShowObj(Graphics g);
        public abstract void PrintObj(Graphics g);

        public void label_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.ShowObj(g);
        }

        public void label_MouseUp(object sender, MouseEventArgs e)
        {
            _x = la.Left;
            _y = la.Top;
        }
    }
}
