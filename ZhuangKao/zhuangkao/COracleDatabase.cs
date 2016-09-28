using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace zhuangkao
{
    public class COracleDatabase : CDatabase
    {
        private string _errorinfo;
        public override string ErrorInfo
        {
            get { return _errorinfo; }
        }

        private string _dbtype = "ORACLE";
        public override string DBType
        {
            get { return this._dbtype; }
        }

        private OracleConnection _dbconn;
        public override System.Data.IDbConnection DBConn
        {
            get { return this._dbconn; }
        }


        private OracleTransaction _trans; //�������� 
        private bool _inTransaction = false; //ָʾ��ǰ�Ƿ������������� 

        public COracleDatabase(string connstr)
        {
            _dbconn = new OracleConnection(connstr);
            _errorinfo = "";
        }

        public override bool OpenConnect()
        {
            if (this._dbconn.State.ToString().ToUpper() != "OPEN")
            {
                try
                {
                    this._dbconn.Open();
                    string a = _dbconn.State.ToString();
                }
                catch (OracleException e)
                {
                    _errorinfo += "������ţ�" + e.ErrorCode.ToString();
                    return false;
                }
            }

            return true;
        }

        public override void CloseConnect()
        {
            if (this._dbconn.State.ToString().ToUpper() == "OPEN")
            {
                try
                {
                    this._dbconn.Close();
                    string a = _dbconn.State.ToString();
                }
                catch (OracleException e)
                {
                    _errorinfo += "������ţ�" + e.ErrorCode.ToString(); 
                }
            }

        }

        public override void BeginTrans()
        {
            _trans = _dbconn.BeginTransaction();
            _inTransaction = true;
        }

        public override void CommitTrans()
        {
            _trans.Commit();
            _inTransaction = false;
        }

        public override void RollbackTrans()
        {
            _trans.Rollback();
            _inTransaction = false;
        }

        public override bool exeSql(string strSql, IDataParameter[] strParams, object[] strValues)
        {
            int recommand;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this._dbconn;
            if (_inTransaction)
            {
                cmd.Transaction = _trans;
            }
            if ((strParams != null) && (strParams.Length != strValues.Length))
            {
                _errorinfo = "��ѯ������ֵ����Ӧ!";
                cmd.Dispose();
                return false;
            }
            cmd.CommandText = strSql;
            if (strParams != null)
            {
                for (int i = 0; i < strParams.Length; i++)
                {
                    cmd.Parameters.Add(strParams[i]);
                    cmd.Parameters[i].Value = strValues[i];
                }
            }
            try
            {
                recommand = cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                _errorinfo += "������ţ�" + e.ErrorCode.ToString(); 
                cmd.Dispose();
                return false;
            }

            cmd.Dispose();
            if (recommand == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override System.Data.DataSet exeSqlForDataSet(string QueryString)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this._dbconn;
            if (_inTransaction)
            {
                cmd.Transaction = _trans;
            }
            DataSet ds = new DataSet();
            OracleDataAdapter ad = new OracleDataAdapter();
            cmd.CommandText = QueryString;
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            return ds;
        }

        public override object exeScalar(string strSql)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = this._dbconn;
            if (_inTransaction)
            {
                cmd.Transaction = _trans;
            }
            cmd.CommandText = strSql;
            return cmd.ExecuteScalar();
        }

        public override IDataReader executeReader(string strSql)
        {
            OracleCommand cmd = new OracleCommand();
            IDataReader dr;
            cmd.Connection = this._dbconn;
            if (_inTransaction)
            {
                cmd.Transaction = _trans;
            }
            cmd.CommandText = strSql;
            dr = cmd.ExecuteReader();
            cmd.Dispose();
            return dr;
        }
    }



}
