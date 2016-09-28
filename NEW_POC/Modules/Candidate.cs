using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Modules
{
    public class Candidate
    {
        private string _lsh;
        public string Lsh
        {
            set { _lsh = value; }
            get { return _lsh; }
        }

        private string _zkzmbh;
        public string Zkzmbh
        {
            set { _zkzmbh = value; }
            get { return _zkzmbh; }
        }

        private string _sfzmbm;
        public string Sfzmhm
        {
            set { _sfzmbm = value; }
            get { return _sfzmbm; }
        }

        private string _kscx;
        public string Kscx
        {
            set { _kscx = value; }
            get { return _kscx; }
        }

        private string _xm;
        public string Xm
        {
            set { _xm = value; }
            get { return _xm; }
        }

        private DateTime _ksrq;
        public DateTime Ksrq
        {
            set { _ksrq = value; }
            get { return _ksrq; }
        }

        private int _kscj;
        public int Kscj
        {
            set 
            {
                if ((value == 0) || (value == 1))
                {
                    _kscj = value;
                }
                else
                {
                    _kscj = 0;
                }
            }
            get
            {
                return _kscj;
            }
        }

        private int _kscs;
        public int Kscs
        {
            set { _kscs = value; }
            get { return _kscs; }
        }

        private string _ksy1;
        public string Ksy1
        {
            set { _ksy1 = value; }
            get { return _ksy1; }
        }

        private string _ksy2;
        public string Ksy2
        {
            set { _ksy2 = value; }
            get { return _ksy2; }
        }

        private string _jbr;
        public string Jbr
        {
            set { _jbr = value; }
            get { return _jbr; }
        }

        private string _zt;
        public string Zt
        {
            set
            {
                _zt = value;
            }
            get { return _zt; }
        }

        private string _ks1;//第一回合考试结果
        public string KS1
        {
            set { _ks1 = value; }
            get { return _ks1; }
        }


        private string _ks2;//第二回合考试结果
        public string KS2
        {
            set { _ks2 = value; }
            get { return _ks2; }
        }

        private int _huiheshu;//第几回合考试，区分与考试次数
        public int HuiHeShu
        {
            set { _huiheshu = value; }
            get { return _huiheshu; }
        }

        private bool _isdown;
        public bool ISDOWN
        {
            get { return _isdown; }
        }

        private int _passnumber;
        public int PassNumber
        {
            set { _passnumber = value; }
            get { return _passnumber; }
        }

        private int _nopassnumber;
        public int NoPassNumber
        {
            set { _nopassnumber = value; }
            get { return _nopassnumber; }
        }
    }
}
