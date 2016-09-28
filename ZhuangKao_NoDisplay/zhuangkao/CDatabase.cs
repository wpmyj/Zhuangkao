using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace zhuangkao
{
    public abstract class CDatabase
    {
        public abstract string DBType { get;}
        public abstract IDbConnection DBConn { get;} //得到数据库连接 
        public abstract  string ErrorInfo{get;}
        public abstract bool OpenConnect();
        public abstract void CloseConnect();
        public abstract void BeginTrans();//开始一个事务 
        public abstract void CommitTrans(); //提交一个事务 
        public abstract void RollbackTrans(); //回滚一个事务 
        public abstract DataSet exeSqlForDataSet(string QueryString);//执行Sql，返回DataSet 
        public abstract object exeScalar(string strSql);
        public abstract IDataReader executeReader(string strSql);
        public virtual  bool exeSql(string strSql, IDataParameter[] strParams, object[] strValues)
        {
            return true;
        }
    }
}
