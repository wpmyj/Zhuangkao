using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Cn.Youdundianzi.Share.DataAccess
{
     public interface IDatabase
    {
        string DBType { get;}
         IDbConnection DBConn { get;} //得到数据库连接 
          string ErrorInfo{get;}
         bool OpenConnect();
         void CloseConnect();
         void BeginTrans();//开始一个事务 
         void CommitTrans(); //提交一个事务 
         void RollbackTrans(); //回滚一个事务 
         DataSet exeSqlForDataSet(string QueryString);//执行Sql，返回DataSet 
         object exeScalar(string strSql);
         IDataReader executeReader(string strSql);
         bool exeSql(string strSql, IDataParameter[] strParams, object[] strValues);
        
    }
}
