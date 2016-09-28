using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace lukao
{
    public class CMsSqlDatabase:CDatabase
    {
        private string _errorinfo;
        public override string ErrorInfo
        {
            get { return _errorinfo; }
        }

        private string _dbtype="MSSQL";
        public override string DBType
        {
            get { return this._dbtype; }
        }

        private SqlConnection _dbconn;
        public override System.Data.IDbConnection DBConn
        {
            get { return this._dbconn; }
        }

        private SqlTransaction _trans; //�������� 
        private bool _inTransaction = false; //ָʾ��ǰ�Ƿ������������� 
        
        public CMsSqlDatabase(string connstr)
        {
            _dbconn = new SqlConnection(connstr);
            _errorinfo = "";
        }

        public override bool OpenConnect()
        {
            if (this._dbconn.State.ToString().ToUpper() != "OPEN")
            {
                try
                {
                    try
                    {
                        this._dbconn.Open();
                        string a = _dbconn.State.ToString();
                    }
                    catch (SqlException e)
                    {
                        for (int i = 0; i < e.Errors.Count; i++)
                        {
                            _errorinfo += "������ţ�" + i + "\n" +
                                       "������Ϣ��" + e.Errors[i].Message + "\n" +
                                       "������Դ��" + e.Errors[i].Source + "\n";
                        }
                        return false;
                    }
                }
                catch 
                {
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
                catch 
                {
                    //for (int i = 0; i < e.Errors.Count; i++)
                    //{
                    //    _errorinfo += "������ţ�" + i + "\n" +
                    //               "������Ϣ��" + e.Errors[i].Message + "\n" +
                    //               "������Դ��" + e.Errors[i].Source + "\n";
                    //}
                }
            }

        }

        public override void BeginTrans()
        {
            _trans=_dbconn.BeginTransaction();
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

        public override bool exeSql(string strSql)
        {
            int recommand;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this._dbconn;
            cmd.CommandText = strSql;
            try
            {
                recommand = cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    _errorinfo += "������ţ�" + i + "\n" +
                               "������Ϣ��" + e.Errors[i].Message + "\n" +
                               "������Դ��" + e.Errors[i].Source + "\n";
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

        public override bool exeSql(string strSql, IDataParameter[] strParams, object[] strValues)
        {
            int recommand;
            SqlCommand cmd = new SqlCommand();
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
               recommand= cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    _errorinfo += "������ţ�" + i + "\n" +
                               "������Ϣ��" + e.Errors[i].Message + "\n" +
                               "������Դ��" + e.Errors[i].Source + "\n";
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

        public override System.Data.DataSet exeSqlForDataSet(string QueryString)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this._dbconn;
            if (_inTransaction)
            {
                cmd.Transaction = _trans;
            }
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            cmd.CommandText = QueryString;
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            return ds; 
        }

        public override object exeScalar(string strSql)
        {
            SqlCommand cmd = new SqlCommand();
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
            SqlCommand cmd = new SqlCommand();
            IDataReader dr;
            cmd.Connection = this._dbconn;
            if (this._dbconn.State.ToString().ToUpper() != "OPEN")
            {
                return null;
            }
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
