using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Cn.Youdundianzi.Share.Module.Score
{
    public class DALStudent
    {
        //---------Ready表的相关操作-------------------------------------------------------------


        #region 无条件查询 ReadyQuery()
        /// <summary>
        /// 无条件查询
        /// </summary>
        public  DataTable ReadyQuery()
        {
            DataSet ds = null;
            try
            {
                DB db = new DB();
                ds = db.GetSqlDataSet(this.ReadyGetSqlString(""));
            }
            catch (Exception e)
            {
                throw (e);
            }
            return ds.Tables[0];
        }
        #endregion

        #region 单引号的处理 format(string myString)
        /// <summary>
        /// 单引号的处理
        /// </summary>
        public string format(string myString)
        {
            if (myString =="" || myString == null)
                return "";
            return myString.Replace("'", "''");
        }
        #endregion


        #region 有条件查询 ReadyQuery(string condition)
        /// <summary>
        /// 有条件查询
        /// </summary>
        public  DataTable ReadyQuery(string condition)
        {
            DataSet ds = null;
            try
            {
                DB db = new DB();
                ds = db.GetSqlDataSet(this.ReadyGetSqlString(condition));
            }
            catch (Exception e)
            {
                throw e;
            }
            return ds.Tables[0];
        }
        #endregion

        #region 根据主键查询 ReadyQueryWithKey(string keyValue)
        /// <summary>
        /// 根据主键查询
        /// </summary>
        public Candidate ReadyQueryWithKey(string keyValue)
        {
            DataSet ds = null;
            Candidate cand=null;
            try
            {
                string cond = " myorder=" + format(keyValue);
                DB db = new DB();
                ds = db.GetSqlDataSet(this.ReadyGetSqlString(cond));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cand = new Candidate();
                    //myorder = ds.Tables[0].Rows[0]["myorder"].ToString();
                    cand.Xm = ds.Tables[0].Rows[0]["姓名"].ToString();
                    cand.Zkzmbh = ds.Tables[0].Rows[0]["准考证号"].ToString();
                    cand.Sfzmhm = ds.Tables[0].Rows[0]["身份证号"].ToString();
                    cand.Kscx = ds.Tables[0].Rows[0]["考试车型"].ToString();
                    cand.Ksrq = DateTime.Parse(ds.Tables[0].Rows[0]["考试日期"].ToString());
                    cand.Kscj = int.Parse(ds.Tables[0].Rows[0]["考试结果"].ToString());
                    cand.KS1 = ds.Tables[0].Rows[0]["第一回合考试"].ToString();
                    cand.KS2 = ds.Tables[0].Rows[0]["第二回合考试"].ToString();
                    cand.Ksy1 = ds.Tables[0].Rows[0]["考试员1"].ToString();
                    cand.Ksy2 = ds.Tables[0].Rows[0]["考试员2"].ToString();
                    cand.Kscs = int.Parse(ds.Tables[0].Rows[0]["考试次数"].ToString());
                }
               
            }
            catch (Exception e)
            {
                throw (e);
            }

            return cand;
        }
        #endregion

        #region 获取查询Sql ReadyGetSqlString(string condition)
        /// <summary>
        /// 获取查询Sql
        /// </summary>
        public string ReadyGetSqlString(string condition)
        {
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("select ");
                sql.Append(" myorder,XM as 姓名,ZKZMBH as 准考证号,SFZMHM as 身份证号,KSCX as 考试车型,KSRQ as 考试日期,KSCS as 考试次数,ZKKSCJ as 考试结果 ,KS1 as 第一回合考试,KS2 as 第二回合考试,KSY1 as 考试员1,KSY2 as 考试员2");
                sql.Append("  from Ready ");
                if (condition != "" && condition != null)
                {
                    sql.Append(" WHERE " + condition);
                }
                sql.Append(" order by myorder desc");
            }
            catch (Exception e)
            {
                throw (e);
            }
            return sql.ToString();

        }
        #endregion




        //统计当天考试人数
        public int getToltoKsrs(string strDate)
        {
            try
            {
                DB myDB = new DB();
                string sqlstr = "SELECT *  FROM dbo.ready T WHERE NOT EXISTS(SELECT 1 FROM dbo.ready WHERE SFZMHM=T.SFZMHM  AND myorder>T.myorder) and DATEDIFF(d,'" + strDate + "',KSRQ)=0";
                DataSet ds = myDB.GetSqlDataSet(sqlstr);
                return ds.Tables[0].Rows.Count;
            }
            catch
            {
                return -1;
            }
        }

        //统计当天合格人数
        public int getToltohgKsrs(string strDate)
        {
            try
            {
                DB myDB = new DB();
                string sqlstr = "SELECT  myorder,SFZMHM  FROM dbo.ready T WHERE NOT EXISTS(SELECT 1 FROM dbo.ready WHERE SFZMHM=T.SFZMHM  AND myorder>T.myorder) and DATEDIFF(d,'" + strDate + "',KSRQ)=0  and ZKKSCJ>=1";
                DataSet ds = myDB.GetSqlDataSet(sqlstr);
                return ds.Tables[0].Rows.Count;
            }
            catch
            {
                return -1;
            }
        }

        #region 添加一条记录 Insert()
        /// <summary>
        ///添加一条记录
        /// </summary>
        public int Insert(Candidate student)
        {
            StringBuilder sql = new StringBuilder();
            DB db = new DB();
            try
            {
                sql.Append("insert into ready");
                sql.Append("(XM,LSH,ZKZMBH,SFZMHM,JBR,KSCX,KSRQ,KSCS,ZKKSCJ,KS1,KS2,KSY1,KSY2) ");
                sql.Append(" values(");
                sql.Append("'" + format(student.Xm) + "'");
                sql.Append(",'" + format(student.Lsh) + "'");
                sql.Append(",'" + format(student.Zkzmbh) + "'");
                sql.Append(",'" + format(student.Sfzmhm) + "'");
                sql.Append(",'" + format(student.Jbr) + "'");
                sql.Append(",'" + format(student.Kscx ) + "'");
                sql.Append(",'" + format(DateTime.Now.ToString()) + "'");
                sql.Append(","+student.Kscs);
                sql.Append("," + student.Kscj);
                sql.Append(",'" + format(student.KS1) + "'");
                sql.Append(",'" + format(student.KS2) + "'");
                sql.Append(",'" + format(student.Ksy1) + "'");
                sql.Append(",'" + format(student.Ksy2) + "'");
                sql.Append(")");
            }
            catch (Exception e)
            {
                throw (e);
            }
            return db.ExecuteSql(sql.ToString());
        }

        #endregion





        //---------------------------------------------------------------------------------

    }
}
