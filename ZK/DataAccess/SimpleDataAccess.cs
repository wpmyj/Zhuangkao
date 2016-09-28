using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Cn.Youdundianzi.Share.DataAccess
{
    /// <summary>
    /// DB 类的摘要说明。
    /// 提供访问SQL Server数据库的基本方法	

    /// </summary>
    public class SimpleDataAccess
    {
        string connStr = "";
        public SimpleDataAccess(string strconn)
        {
            connStr = strconn;
        }
        public DataSet GetSqlDataSet(string sqlString)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection sqlConn = new SqlConnection(connStr);
                SqlDataAdapter da = new SqlDataAdapter(sqlString, sqlConn);
                da.Fill(ds);
            }
            catch (Exception e)
            {

                throw (e);
            }
            return ds;
        }

       
        public int ExecuteSql(string sqlString)
        {

            int i = 0;
            try
            {
                SqlConnection sqlConn = new SqlConnection(connStr);
                SqlCommand sqlCmd = new SqlCommand(sqlString, sqlConn);
                sqlConn.Open();
                i = sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
            catch (Exception e)
            {
                Exception ee = new Exception(sqlString + "    " + e.Message);
                throw (ee);
            }
            return i;
        }

    }
}
