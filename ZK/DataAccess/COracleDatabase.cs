using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace Cn.Youdundianzi.Share.DataAccess
{
    public class COracleDatabase : IDatabase
    {
        private string _errorinfo;
        public  string ErrorInfo
        {
            get { return _errorinfo; }
        }

        private string _dbtype = "ORACLE";
        public  string DBType
        {
            get { return this._dbtype; }
        }

        private OracleConnection _dbconn;
        public  System.Data.IDbConnection DBConn
        {
            get { return this._dbconn; }
        }


        private OracleTransaction _trans; //事务处理类 
        private bool _inTransaction = false; //指示当前是否正处于事务中 

        public COracleDatabase(string connstr)
        {
            _dbconn = new OracleConnection(connstr);
            _errorinfo = "";
        }

        public  bool OpenConnect()
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
                    _errorinfo += "错误序号：" + e.ErrorCode.ToString();
                    return false;
                }
            }

            return true;
        }

        public  void CloseConnect()
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
                    _errorinfo += "错误序号：" + e.ErrorCode.ToString(); 
                }
            }

        }

        public  void BeginTrans()
        {
            _trans = _dbconn.BeginTransaction();
            _inTransaction = true;
        }

        public  void CommitTrans()
        {
            _trans.Commit();
            _inTransaction = false;
        }

        public  void RollbackTrans()
        {
            _trans.Rollback();
            _inTransaction = false;
        }

        public  bool exeSql(string strSql, IDataParameter[] strParams, object[] strValues)
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
                _errorinfo = "查询参数和值不对应!";
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
                _errorinfo += "错误序号：" + e.ErrorCode.ToString(); 
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

        public  System.Data.DataSet exeSqlForDataSet(string QueryString)
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

        public  object exeScalar(string strSql)
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

        public  IDataReader executeReader(string strSql)
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
