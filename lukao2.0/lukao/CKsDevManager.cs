using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace lukao
{
    public class CKsDevManager
    {
        private CModel model;
        public CKsDevModel[] ksdevmodels;
        private int _index=0;
        private int ksdevcount;
        public int KsDevCount
        {
            get { return ksdevcount; }
        }

        public CKsDevManager(CModel model)
        {
            this.model = model;
            string[] str = model.settings.DevInfo.Split(',');
            //Array.Sort(str);
            ksdevmodels = new CKsDevModel[str.Length];
            ksdevcount = str.Length;
            for (int i = 0; i < str.Length; i++)
            {
                string[] str1 = str[i].Split(':');
                ksdevmodels[i] = new CKsDevModel();
                ksdevmodels[i].Ksdevorder = str1[0];
                ksdevmodels[i].Ksdevname = str1[1];
            }
        }

        public void MoveNext()
        {
            if ((_index + 1) < ksdevmodels.Length)
            {
                _index++;
            }
            else
            {
                _index = 0;
            }
        }

        public int QqIndex //当前设备索引
        {
            get { return _index; }
        }


    }
}
