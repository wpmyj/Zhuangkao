using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace zhuangkao
{
    public class CStudent
    {
        private CLinkPool _linkpool;
        private CReadLacal _readlacallink;
        private CReadRemote _readremotelink;
        
        public bool LinkState1
        {
            get { return _readlacallink.LinkState; }
        }

        public bool LinkState2
        {
            get { return _readremotelink.LinkState; }
        }

        // private string _errorinfo;
        //public string ErrorInfo
        //{
        //    get { return _errorinfo; }
        //}

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


        public CStudent(ModuleSettings settings)
        {
            string connstr = "Data Source="+ settings.Ipaddress +";Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";//mssql数据库链接
            //connstr =  @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + settings.LocalLinkStr  +";Persist Security Info=False;Jet OLEDB:Database Password=cgcsxb";
            _readlacallink = new CReadLacal(connstr);
            //connstr = "Data Source=oraclelan;Persist Security Info=True;User ID=DRV_KM2;Password=cgcsxb;Unicode=True";
            connstr = "Data Source=" + settings.Ipaddress + ";Initial Catalog=remote_zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";  //mssql数据库链接
            _readremotelink = new CReadRemote(connstr);
            _linkpool = new CLinkPool();
            _linkpool.RegDbLink(_readlacallink);
            //_linkpool.RegDbLink(_readremotelink); //连接次序根据注册先后
            Clear();
            int tmpreturn = _linkpool.OpenLink();
            System.Threading.Thread.Sleep(1000);
        }

        public void GetKsNumber()
        {
            if (_readlacallink.LinkState)
            {
                string sqlstr = "select count(*) from ready where (KSCJ=1) and (KSRQ >= '" + System.DateTime.Today  + "')";
                _passnumber = Convert.ToInt16(_readlacallink.Db.exeScalar(sqlstr));
                sqlstr = "select count(*) from ready where (KSCJ=0) and (KSRQ >= '" + System.DateTime.Today + "')";
                _nopassnumber = Convert.ToInt16(_readlacallink.Db.exeScalar(sqlstr));
            }
        }

        public bool GetStudentInfo(string zkzmbhorsfzh)
        {
            Clear();
            string strsql;
            if (zkzmbhorsfzh.Length == 12)
            {
                strsql = "select * from drv_preasign where ZKZMBH ='" + zkzmbhorsfzh.Trim() + "'";
            }
            else
            {
                strsql = "select * from drv_preasign where SFZMHM ='" + zkzmbhorsfzh.Trim() + "'";
            }
            for (int i = 0; i < _linkpool.LinkCount; i++)
            {
                try
                {
                    if (_linkpool.GetLink(i).Useable)
                    {
                        IDataReader dr = _linkpool.GetLink(i).Db.executeReader(strsql);
                        
                        if (dr.Read())
                        {
                           // _zkzmbh = zkzmbhorsfzh;
                            _zkzmbh = dr["ZKZMBH"].ToString().Trim();
                            _lsh = dr["LSH"].ToString().Trim();
                            _sfzmbm = dr["SFZMHM"].ToString().Trim();
                            _xm = dr["XM"].ToString().Trim();
                            _kscx = dr["KSCX"].ToString().Trim();
                            _kscs = Convert.ToInt16(dr["KSCS"]);
                            _jbr = dr["JBR"].ToString().Trim();
                            _isdown = true;
                            dr.Close();
                            dr.Dispose();
                            return true;
                        }
                        dr.Close();
                        dr.Dispose();
                        _ksrq = System.DateTime.Now;
                        _huiheshu  = 1;
                    }
                    else
                    {
                        _linkpool.GetLink(i).OpenConnect(); 
                    }
           
                }
                catch
                {
                    _linkpool.GetLink(i).Useable = false;
                   
                }
            }
            return false;
        }

        //public bool SaveInfo()
        //{
        //    if (_readlacallink.LinkState == false)
        //    {
        //        return false;
        //    }
        //   // string sqlstr = "insert into ready (LSH,ZKZMBH,SFZMHM,XM,KSCX,JBR,KSCJ,KSRQ,KSCS,KSY1,KSY2,ZT,KS1,KS2) values (@LSH,@ZKZMBH,@SFZMHM,@XM,@KSCX,@JBR,@KSCJ,@KSRQ,@KSCS,@KSY1,@KSY2,@ZT,@KS1,@KS2)";
        //    string sqlstr = "insert into ready (LSH,ZKZMBH,SFZMHM,XM,KSCX,JBR,KSCJ,KSRQ,KSCS,KSY1,KSY2,ZT,KS1,KS2) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        //    //string sqlstr = "insert into ready (LSH,ZKZMBH,KSRQ) values (@LSH,@ZKZMBH,@KSRQ)";
        //    string[] strParams = new string[14];
        //    strParams[0] = "@LSH";
        //    strParams[1] ="@ZKZMBH";
        //    strParams[2] = "@SFZMHM";
        //    strParams[3] = "@XM";
        //    strParams[4] = "@KSCX";
        //    strParams[5] = "@JBR";
        //    strParams[6] = "@KSCJ";
        //    strParams[7] ="@KSRQ";
        //    strParams[8] = "@KSCS";
        //    strParams[9] = "@KSY1";
        //    strParams[10] = "@KSY2";
        //    strParams[11] = "@ZT";
        //    strParams[12] = "@KS1";
        //    strParams[13] = "@KS2";
        //    object[] strValues = new object[14];
        //    strValues[0] = _lsh;
        //    strValues[1] =_zkzmbh;
        //    strValues[2] = _sfzmbm;
        //    strValues[3] = _xm;
        //    strValues[4] = _kscx;
        //    strValues[5] = _jbr;
        //    strValues[6] = _kscj;
        //    strValues[7] = _ksrq.ToString();
        //    strValues[8] = _kscs;
        //    strValues[9] =  _ksy1;
        //    strValues[10] = _ksy2;
        //    strValues[11] = _zt;
        //    strValues[12] = _ks1;
        //    strValues[13] = _ks2;
        //    if (!_readlacallink.Db.exeSql(sqlstr, strParams, strValues))
        //    {
        //        return false;
        //    }
        //    return true;
        //}


        public bool SaveInfo()
        {
            if (_readlacallink.LinkState == false)
            {
                return false;
            }
            string sqlstr = "insert into ready (LSH,ZKZMBH,SFZMHM,XM,KSCX,JBR,KSCJ,KSRQ,KSCS,KSY1,KSY2,ZT,KS1,KS2,ISDOWN) values (@LSH,@ZKZMBH,@SFZMHM,@XM,@KSCX,@JBR,@KSCJ,@KSRQ,@KSCS,@KSY1,@KSY2,@ZT,@KS1,@KS2,@ISDOWN)";
           // string sqlstr = "insert into ready (LSH,ZKZMBH,SFZMHM,XM,KSCX,JBR,KSCJ,KSRQ,KSCS,KSY1,KSY2,ZT,KS1,KS2,ISDOWN) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            //string sqlstr = "insert into ready (LSH,ZKZMBH,KSRQ) values (@LSH,@ZKZMBH,@KSRQ)";
           // System.Data.OleDb.OleDbParameter[] strParams = new System.Data.OleDb.OleDbParameter[15];
            System.Data.SqlClient.SqlParameter[] strParams = new System.Data.SqlClient.SqlParameter[15];
            for (int i = 0; i < 15; i++)
            {
                strParams[i] = new System.Data.SqlClient.SqlParameter();
            }
            strParams[0].ParameterName = "@LSH";
            strParams[1].ParameterName = "@ZKZMBH";
            strParams[2].ParameterName = "@SFZMHM";
            strParams[3].ParameterName = "@XM";
            strParams[4].ParameterName = "@KSCX";
            strParams[5].ParameterName = "@JBR";
            strParams[6].ParameterName = "@KSCJ";
            strParams[7].ParameterName = "@KSRQ";
            strParams[8].ParameterName = "@KSCS";
            strParams[9].ParameterName = "@KSY1";
            strParams[10].ParameterName = "@KSY2";
            strParams[11].ParameterName = "@ZT";
            strParams[12].ParameterName = "@KS1";
            strParams[13].ParameterName = "@KS2";
            strParams[14].ParameterName = "@ISDOWN";
            object[] strValues = new object[15];
            strValues[0] = _lsh;
            strValues[1] = _zkzmbh;
            strValues[2] = _sfzmbm;
            strValues[3] = _xm;
            strValues[4] = _kscx;
            strValues[5] = _jbr;
            strValues[6] = _kscj;
            strValues[7] = _ksrq.ToString();
            strValues[8] = _kscs;
            strValues[9] = _ksy1;
            strValues[10] = _ksy2;
            strValues[11] = _zt;
            strValues[12] = _ks1;
            strValues[13] = _ks2;
            strValues[14] = _isdown;
            if (!_readlacallink.Db.exeSql(sqlstr, strParams, strValues))
            {
                return false;
            }
            return true;
        }

        public void Close()
        {
            //_rdbase.CloseConnect();
            //_wdbase.CloseConnect();
            _readlacallink.CloseConnect();
            _readremotelink.CloseConnect();
        }

        public void Clear()
        {
            this._jbr = "";
            this._kscx = "";
            this._kscj = 0;
            this._kscs = 0;
            this._ksrq = System.DateTime.Now;
            this._ksy1 = "";
            this._ksy2 = "";
            this._lsh = "";
            this._sfzmbm = "";
            this._xm = "";
            this._zkzmbh = "";
            this._zt = "0";
            this._isdown = false;
            this.HuiHeShu = 1;
            this.KS1 = "";
            this.KS2 = "";
        }

    }
}
