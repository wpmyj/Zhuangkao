using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ExamDisplayModelPanel
{
    public class CLineFairy : IFairy
    {
        private Pen mypen;
        private string linename;
        public int Linex;
        public int Liney;
        public bool Visable;

        private int stat;
        public int Stat
        {
            get
            {
                return stat;
            }
            set
            {
                stat = value;
                switch (value)
                {
                    case 0:
                        mypen.Color = errorcolor;
                        break;
                    case 1:
                        mypen.Color=normalcolor;
                        break;
                    case -1:
                        mypen.Color = shieldcolor;
                        break;
                }
                //if (value == 0)
                //{
                //    mypen.Color = errorcolor;
                //}
                //else
                //{
                //    mypen.Color = normalcolor;
                //}
            }
        }

        public string LineName
        {
            get
            {
                return linename;
            }
            set
            {
                linename = value;
            }
        }

        private int x1;
        public int X1
        {
            get
            {
                return x1;
            }
        }

        private int y1;
        public int Y1
        {
            get
            {
                return y1;
            }
        }

        private int x2;
        public int X2
        {
            get
            {
                return x2;
            }
        }

        private int y2;
        public int Y2
        {
            get
            {
                return y2;
            }
        }

        private int linewidth;
        public int LineWidth
        {
            get
            {
                return linewidth;
            }
            set
            {
                linewidth = value;
            }
        }

        private Color normalcolor;
        public Color NormalColor
        {
            get
            {
                return normalcolor;
            }
            set
            {
                normalcolor = value;
            }
        }

        private Color errorcolor;
        public Color ErrorColor
        {
            get
            {
                return errorcolor;
            }
            set
            {
                errorcolor = value;
            }
        }

        private Color shieldcolor;
        public Color ShiedColor
        {
            get
            {
                return shieldcolor;
            }
            set
            {
                shieldcolor = value;
            }
        }

        private int flashspeed;
        public int FlashSpeed
        {
            get
            {
                return flashspeed;
            }
            set
            {
                flashspeed = value;
            }
        }

        private int flashcount;
        private bool isflash;
        public bool IsFlash
        {
            get
            {
                return isflash;
            }
            set
            {
                isflash = value;
                if (isflash == false)
                {
                    mypen.Color = normalcolor;
                }
            }
        }

        public CLineFairy(int sx1,int sy1,int sx2,int sy2)
        {
            x1 = sx1;
            y1 = sy1;
            x2 = sx2;
            y2 = sy2;
            linewidth = 2;
            normalcolor = Color.Yellow;
            errorcolor = Color.Red;
            shieldcolor = Color.Gray;
            mypen = new Pen(normalcolor);
            mypen.Width = LineWidth;
            flashspeed = 5;
            isflash = false;
            flashcount = 0;
            linename = "";
            Linex = (x1 + x2) / 2 - 15;
            Liney = (y1 + y2) / 2;
            Visable = true;
        }

        public void Flash()
        {
            if (mypen.Color == normalcolor)
            {
                mypen.Color = errorcolor;
            }
            else
            {
                mypen.Color = normalcolor;
            }
        }

        public void Display(Graphics g)
        {
            if (isflash)
            {
                flashcount = flashcount + 1;
                if (flashcount > flashspeed)
                {
                    Flash();
                    flashcount = 0;
                }
            }

            Font fn = new Font(FontFamily.GenericMonospace, 12.0F, FontStyle.Bold);
            if (Visable)
            {
                g.DrawLine(mypen, x1, y1, x2, y2);
            }
            g.DrawString(linename, fn, Brushes.Yellow, (float)Linex, (float)Liney);
        }

    }
}
