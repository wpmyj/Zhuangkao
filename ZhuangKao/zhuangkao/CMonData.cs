using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CMonData
    {
        public sbyte[] gan;
        public sbyte[] xian;
        public sbyte[] che;
        public readonly int xinhaocount=9;

        public CMonData()
        {

            gan = new sbyte[xinhaocount];
            xian = new sbyte[xinhaocount];
            che = new sbyte[4];
            for (int i = 0; i < xinhaocount; i++)
            {
                gan[i] = 0;
                xian[i] = 0;
            }
            for (int i = 0; i < 4; i++)
            {
                che[i] = 0;
            }
        }

        public  void Copy(CMonData src)
        {
            for (int i = 0; i < xinhaocount; i++)
            {
                this.gan[i] = src.gan[i];
                this.xian[i] = src.xian[i];
                if (i < 4)
                {
                    this.che[i] = src.che[i];
                }
            }
        }

        public bool Equals(CMonData src)
        {
            for (int i = 0; i < xinhaocount; i++)
            {
                if (this.xian[i] != src.xian[i] || this.gan[i] != src.gan[i])
                    return false;
                if (i < 4)
                    if (this.che[i] != src.che[i])
                        return false;
            }
            return true;
        }
    }
}
