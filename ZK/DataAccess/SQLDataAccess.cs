using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Cn.Youdundianzi.Share.DataAccess
{
  
    
   //SQl SERVER 数据库访问类 提供存SQL/存储过程两种访问模式
    public class SQLDataAccess
    {
        public   string strConn ="";

        public SQLDataAccess(string strconn)
        {
            strConn = strconn;
        }
        private  SqlConnection conn;
        /// <summary>
        /// 判断数据库是否链接
        /// </summary>
        public  void SqlIsOpen()
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConn);
            }
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        /// <summary>
        /// 判断数据库是否关闭
        /// </summary>
        public  void SqlIsClosed()
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">SqlCommand命令</param>
        /// <param name="Type">SqlCommand命令类型(Sql语句，存储过程)</param>
        /// <param name="strSql">Command text,T_SQL语句</param>
        /// <param name="para">返回带参数的命令</param>
        public  void PreCommand(SqlCommand cmd, CommandType Type, String strSql, SqlParameter[] para)
        {
            SqlIsOpen();
            cmd.Connection = conn;
            cmd.CommandType = Type;
            cmd.CommandText = strSql;
            if (para != null)
            {
                foreach (SqlParameter parm in para)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        /// <summary>
        /// 执行非返回语句的查询
        /// </summary>
        /// <param name="Type">SqlCommand命令类型(Sql语句，存储过程)</param>
        /// <param name="strSql">Command text,T_SQL语句</param>
        /// <param name="para">返回带参数的命令</param>
        /// <returns>返回所影响的行数</returns>
        public  Int32 ExecuteNonQuery(CommandType Type, String strSql, params SqlParameter[] para)
        {
            SqlIsOpen();
            SqlCommand cmd = new SqlCommand();
            PreCommand(cmd, Type, strSql, para);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            SqlIsClosed();
            return val;
        }
        /// <summary>
        /// 执行一个DataSet 语句
        /// </summary>
        /// <param name="Type">SqlCommand命令类型(Sql语句，存储过程)</param>
        /// <param name="strSql">Command text,T_SQL语句</param>
        /// <param name="para">返回带参数的命令</param>
        /// <returns>返回一个DataSet</returns>
        public  DataSet ExecuteDataSet(CommandType Type, String strSql, params SqlParameter[] para)
        {
            SqlIsOpen();
            SqlCommand cmd = new SqlCommand();
            PreCommand(cmd, Type, strSql, para);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.Parameters.Clear();
            SqlIsClosed();
            return ds;
        }
        /// <summary>
        /// 执行一个DataTable语句
        /// </summary>
        /// <param name="Type">SqlCommand命令类型(Sql语句，存储过程)</param>
        /// <param name="strSql">Command text,T_SQL语句</param>
        /// <param name="para">返回带参数的命令</param>
        /// <returns>返回一个DataTable</returns>
        public DataTable ExecteDataTable(CommandType Type, String strSql, params SqlParameter[] para)
        {
            SqlIsOpen();
            SqlCommand cmd = new SqlCommand();
            PreCommand(cmd, Type, strSql, para);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Parameters.Clear();
            SqlIsClosed();
            return dt;
        }


        //获取ExecuteScalar查询结果。返回类型为object
        public  object GetExecuteScalarResult(CommandType Type, String strSql, params SqlParameter[] para)
        {
            object o;
            SqlIsOpen();
            SqlCommand cmd = new SqlCommand();
            PreCommand(cmd, Type, strSql, para);
            o = cmd.ExecuteScalar();
            SqlIsClosed();
            return o;
         
        }

    }

}
