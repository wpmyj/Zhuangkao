using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace zhuangkao
{
    public abstract class CDatabase
    {
        public abstract string DBType { get;}
        public abstract IDbConnection DBConn { get;} //�õ����ݿ����� 
        public abstract  string ErrorInfo{get;}
        public abstract bool OpenConnect();
        public abstract void CloseConnect();
        public abstract void BeginTrans();//��ʼһ������ 
        public abstract void CommitTrans(); //�ύһ������ 
        public abstract void RollbackTrans(); //�ع�һ������ 
        public abstract DataSet exeSqlForDataSet(string QueryString);//ִ��Sql������DataSet 
        public abstract object exeScalar(string strSql);
        public abstract IDataReader executeReader(string strSql);
        public virtual  bool exeSql(string strSql, IDataParameter[] strParams, object[] strValues)
        {
            return true;
        }
    }
}
