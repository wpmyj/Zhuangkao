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
      //  public string gmcj; //���ųɼ��۷֣���ʽΪ �����豸��ţ��۷� ���磺 11��20��12��0��13��10��14��5
      //  public int ykxmcount;//�ѿ���Ŀ��
        public int[] fxcj;//����ɼ�

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
