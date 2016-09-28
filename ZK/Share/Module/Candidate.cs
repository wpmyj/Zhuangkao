using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Cn.Youdundianzi.Share.Module
{
    public class Candidate
    {
        private string _lsh = string.Empty;
        public string Lsh
        {
            set { _lsh = value; }
            get { return _lsh; }
        }

        private string _zkzmbh = string.Empty;
        public string Zkzmbh
        {
            set { _zkzmbh = value; }
            get { return _zkzmbh; }
        }

        private string _sfzmbm = string.Empty;
        public string Sfzmhm
        {
            set { _sfzmbm = value; }
            get { return _sfzmbm; }
        }

        private string _kscx = string.Empty;
        public string Kscx
        {
            set { _kscx = value; }
            get { return _kscx; }
        }

        private string _xm = string.Empty;
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

        private string _ksy1 = string.Empty;
        public string Ksy1
        {
            set { _ksy1 = value; }
            get { return _ksy1; }
        }

        private string _ksy2 = string.Empty;
        public string Ksy2
        {
            set { _ksy2 = value; }
            get { return _ksy2; }
        }

        private string _jbr = string.Empty;
        public string Jbr
        {
            set { _jbr = value; }
            get { return _jbr; }
        }

        private string _zt = string.Empty;
        public string Zt
        {
            set
            {
                _zt = value;
            }
            get { return _zt; }
        }

        private string _ks1 = string.Empty;//第一回合考试结果
        public string KS1
        {
            set { _ks1 = value; }
            get { return _ks1; }
        }


        private string _ks2 = string.Empty;//第二回合考试结果
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

        private string _kchp = string.Empty;//考车号牌
        public string Kchp
        {
            get { return _kchp; }
            set { _kchp = value; }
        }

        //不按规定路线、顺序行驶 B101  路线错 行进方向错
        //碰擦桩杆 B102  碰杆
        //车身出线 B103  压线
        //移库不入 B104  移库不入
        //考试合格

        private string _kfxm;//扣分项目编码，编码之间用","隔开
        public string Kfxm
        {
            get { return _kfxm; }
            set { _kfxm = value; }
        }

    }
}
