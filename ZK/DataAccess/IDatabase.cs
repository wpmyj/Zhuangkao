using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Cn.Youdundianzi.Share.DataAccess
{
     public interface IDatabase
    {
        string DBType { get;}
         IDbConnection DBConn { get;} //�õ����ݿ����� 
          string ErrorInfo{get;}
         bool OpenConnect();
         void CloseConnect();
         void BeginTrans();//��ʼһ������ 
         void CommitTrans(); //�ύһ������ 
         void RollbackTrans(); //�ع�һ������ 
         DataSet exeSqlForDataSet(string QueryString);//ִ��Sql������DataSet 
         object exeScalar(string strSql);
         IDataReader executeReader(string strSql);
         bool exeSql(string strSql, IDataParameter[] strParams, object[] strValues);
        
    }
}
