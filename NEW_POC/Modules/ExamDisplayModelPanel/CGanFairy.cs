using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ExamDisplayModelPanel
{
    public class CGanFairy:IFairy
    {
        private Bitmap normalbm;
        private Bitmap errorbm;
        private Bitmap shieldbm;
        private Bitmap showbm;

        private string ganname;
        public string GanName
        {
            get
            {
                return ganname;
            }
            set
            {
                ganname = value;
            }
        }


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
                switch (stat)
                {
                    case 0:
                        showbm = errorbm;
                        break;
                    case 1:
                        showbm = normalbm;
                        break;
                    case -1:
                        showbm = shieldbm;
                        break;
                }

              }
        }

        private int x;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        private int y;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public CGanFairy(Bitmap[] bm)
        {
            normalbm = bm[0];
            errorbm = bm[1];
            shieldbm = bm[2];
            showbm = normalbm;
            x = 0;
            y = 0;
            stat = 1;
            ganname = "";
        }

        public void Display(Graphics g)
        {
            g.DrawImage(showbm, (float)x, (float)y, (float)(showbm.Width / 1.2), (float)(showbm.Height / 1.2));
            Font fn = new Font(FontFamily.GenericMonospace, 10.0F, FontStyle.Bold);
            g.DrawString(ganname, fn, Brushes.Black, (float)x + 5, (float)y+2);
        }
    }
}
