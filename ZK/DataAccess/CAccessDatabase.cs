using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Cn.Youdundianzi.Share.DataAccess
{
    public class CAccessDatabase : IDatabase
    {
        private string _errorinfo;
        public  string ErrorInfo
        {
            get { return _errorinfo; }
        }

        private string _dbtype = "ACCESS";
        public  string DBType
        {
            get { return this._dbtype; }
        }

        private OleDbConnection _dbconn;
        public  System.Data.IDbConnection DBConn
        {
            get { return this._dbconn; }
        }

        private OleDbTransaction _trans; //事务处理类 
        private bool _inTransaction = false; //指示当前是否正处于事务中 


        public CAccessDatabase(string connstr)
        {
            _dbconn = new OleDbConnection(connstr);
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
                catch (OleDbException e)
                {
                    for (int i = 0; i < e.Errors.Count; i++)
                    {
                        _errorinfo += "错误序号：" + i + "\n" +
                                   "出错信息：" + e.Errors[i].Message + "\n" +
                                   "出错来源：" + e.Errors[i].Source + "\n";
                    }
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
                catch (OleDbException e)
                {
                    for (int i = 0; i < e.Errors.Count; i++)
                    {
                        _errorinfo += "错误序号：" + i + "\n" +
                                   "出错信息：" + e.Errors[i].Message + "\n" +
                                   "出错来源：" + e.Errors[i].Source + "\n";
                    }
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


       

        public  System.Data.DataSet exeSqlForDataSet(string QueryString)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = this._dbconn;
            if (_inTransaction)
            {
                cmd.Transaction = _trans;
            }
            DataSet ds = new DataSet();
            OleDbDataAdapter ad = new OleDbDataAdapter();
            cmd.CommandText = QueryString;
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            return ds;
        }

        public  object exeScalar(string strSql)
        {
            OleDbCommand cmd = new OleDbCommand();
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
            OleDbCommand cmd = new OleDbCommand();
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

        public  bool  exeSql(string strSql, IDataParameter[] strParams, object[] strValues)
        {
            int recommand;
            OleDbCommand cmd = new OleDbCommand();
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
            catch (OleDbException e)
            {
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    _errorinfo += "错误序号：" + i + "\n" +
                               "出错信息：" + e.Errors[i].Message + "\n" +
                               "出错来源：" + e.Errors[i].Source + "\n";
                }
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





    }
}
