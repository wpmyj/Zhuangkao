using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace zkcenter
{
    public class CStudent
    {
        public string xm;
        public string lsh;
        public string sfzmhm;
        public string zkzmbh;
        public string kscx;
        public int kscj;
        public string ksy1;
        public string ksy2;
        public string kssj;
        public DateTime yyrq;//预约日期
        public int kscs;
        public string jbr;
        public string zt;
        public bool isprint;
        public Image photo;

        public string DisplayString(int devnum)
        {
            string tmpStr = string.Empty;
            if (xm.Length == 2)
                tmpStr = xm + "    ";
            else if (xm.Length == 3)
                tmpStr = xm + "  ";
            else
                tmpStr = xm;
            return tmpStr + " 请到" + devnum + "号库";
        }
    }
}
