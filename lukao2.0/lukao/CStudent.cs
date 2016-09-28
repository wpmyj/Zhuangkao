using System;
using System.Collections.Generic;
using System.Text;

namespace lukao
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
        public DateTime ksrq;
        public DateTime zkrq;
        public int lkcs;
        public bool isprint;
      //  public string gmcj; //各门成绩扣分，格式为 考试设备编号：扣分 例如： 11：20，12：0，13：10，14：5
      //  public int ykxmcount;//已考项目数
        public int[] fxcj;//分项成绩

        public CStudent(CModel model)
        {
            isprint = false;
            kscj=100;
            
            fxcj = new int[model.ksdevmanager.KsDevCount];
            for (int i = 0; i < fxcj.Length; i++)
            {
                fxcj[i] = -1;
            }
        }


    }
}
