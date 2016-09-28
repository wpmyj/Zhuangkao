using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Cn.Youdundianzi.Share.DataAccess;
using Cn.Youdundianzi.Share.Util;

namespace Cn.Youdundianzi.Share.Module.Score
{
    //郑州考试数据处理模块
    public  class NetDALCandidate
    {
        private CSettings settings;
        SQLDataAccess msdatabase;

        public NetDALCandidate(CSettings set)
        {
           this.settings = set;
           string connStr = @"Data Source="+settings.IPAddress+"\\sqlexpress;Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";
           msdatabase = new DataAccess.SQLDataAccess(connStr);  
        }

        //获取考生信息(在中间表drv_preasign中读取数据)
        public  Candidate GetStudentInfo(string zkzmbhorsfzh)
        {
            string strsql;
            Candidate cand = null;

            if (zkzmbhorsfzh.Length == 12)
            {
                strsql = "select * from drv_preasign where ZKZMBH ='" + zkzmbhorsfzh + "'";
            }
            else
            {
                strsql = "select * from drv_preasign where SFZMHM ='" + zkzmbhorsfzh + "'";
            }

            try
            {

                DataTable dt = msdatabase.ExecteDataTable(CommandType.Text,strsql,null);
                if (dt.Rows.Count!=0)
                {
                    cand = new Candidate();
                    cand.Zkzmbh = dt.Rows[0]["ZKZMBH"].ToString().Trim();
                    cand.Lsh = dt.Rows[0]["LSH"].ToString().Trim();
                    cand.Sfzmhm = dt.Rows[0]["SFZMHM"].ToString().Trim();
                    cand.Xm = dt.Rows[0]["XM"].ToString().Trim();
                    cand.Kscx = dt.Rows[0]["KSCX"].ToString().Trim();
                    cand.Kscs = Convert.ToInt16(dt.Rows[0]["KSCS"]);
                    cand.Jbr = dt.Rows[0]["JBR"].ToString().Trim();
                    cand.Kchp = dt.Rows[0]["ZKKCHP"].ToString().Trim();
                    cand.Ksrq = System.DateTime.Now;
                    cand.HuiHeShu = 0;
                }
                return cand;
            }
            catch
            {
                return null;

            }
        }

        //保存成绩
        public bool SaveInfo(Candidate cand)
        {       
            string sqlstr = "insert into ready (LSH,ZKZMBH,SFZMHM,XM,KSCX,JBR,ZKKSCJ,KSRQ,KSCS,KSY1,KSY2,ZT,KS1,KS2,ZKKFXM,ZKKCHP,ZKKUORDER) values (@LSH,@ZKZMBH,@SFZMHM,@XM,@KSCX,@JBR,@ZKKSCJ,@KSRQ,@KSCS,@KSY1,@KSY2,@ZT,@KS1,@KS2,@ZKKFXM,@ZKKCHP,@ZKKUORDER)";
                SqlParameter[] para = new SqlParameter[]
                {
                     new SqlParameter("@LSH",cand.Lsh),
                     new SqlParameter("@ZKZMBH",cand.Zkzmbh),
                     new SqlParameter("@SFZMHM",cand.Sfzmhm),
                     new SqlParameter("@XM",cand.Xm),
                     new SqlParameter("@KSCX",cand.Kscx),
                     new SqlParameter("@ZKKSCJ",cand.Kscj),
                     new SqlParameter("@KSRQ",cand.Ksrq),
                     new SqlParameter("@KSCS",cand.Kscs),
                     new SqlParameter("@JBR",cand.Jbr),
                     new SqlParameter("@KSY1",cand.Ksy1),
                     new SqlParameter("@KSY2",cand.Ksy2),
                     new SqlParameter("@ZT",cand.Zt),
                     new SqlParameter("@KS1",cand.KS1),
                     new SqlParameter("@KS2",cand.KS2),
                     new SqlParameter("@ZKKFXM",cand.Kfxm),//新增
                     new SqlParameter("@ZKKCHP",cand.Kchp),//新增
                     new SqlParameter("@ZKKUORDER",settings.Devnum)//新增
                };
                try
                {
                    msdatabase.ExecuteNonQuery(CommandType.Text, sqlstr, para);
                    return true;
                }
                catch
                {
                    return false;
                }
        }
    }
}
