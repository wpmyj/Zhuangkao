#define Debug

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;

namespace zkdata
{
    public class CSend_Model
    {
        public ModuleSettings settings;
        SqlConnection sqlconn;
        OracleConnection oraconn;

        int _sendnum;//发送的数据
        int _errsendnum;//发送错误的数据

        public CSend_Model()
        {
            settings = ModuleConfig.GetSettings();
        }


        public delegate void D_SQLlink(bool islink);
        private event D_SQLlink _event_sqllink; //SQL Server连接事件
        public event D_SQLlink Event_SQLLink
        {
            add
            {
                _event_sqllink += value;
            }
            remove
            {
                _event_sqllink -= value;
            }
        }

        public delegate void D_ORACLElink(bool islink);
        private event D_ORACLElink _event_oraclelink; //Oracle连接事件
        public event D_ORACLElink Event_ORACLELink
        {
            add
            {
                _event_oraclelink += value;
            }
            remove
            {
                _event_oraclelink -= value;
            }
        }


        public delegate void D_Send(int sendnum);
        private event D_Send _event_Send; //发送数据事件
        public event D_Send Event_Send
        {
            add
            {
                _event_Send += value;
            }
            remove
            {
                _event_Send -= value;
            }
        }


        public delegate void D_SendErr(int errdownloadnum);
        private event D_SendErr _event_SendErr; //发送错误数据事件
        public event D_SendErr Event_SendErr
        {
            add
            {
                _event_SendErr += value;
            }
            remove
            {
                _event_SendErr -= value;
            }
        }



        public bool LocalDBlink() //建立本地SQL数据库连接
        {
            try
            {
                sqlconn = new SqlConnection();
                sqlconn.ConnectionString = "Data Source=" + settings.Ipaddress + ";Initial Catalog=zhuangkao;Persist " +
                                                                     "Security Info=True;User ID=sa;Password=cgcsxb";
                sqlconn.Open();

            }
            catch
            {
                _event_sqllink(false);
                return false;
            }

            _event_sqllink(true);
            return true;
        }


        public bool RemoteDBlink() //远程数据连接
        {
            oraconn = new OracleConnection();
            oraconn.ConnectionString = "Data Source=oraclelan;Persist Security Info=True;User ID=" + settings.Username + ";Password=" + settings.Password + ";Unicode=True";
            try
            {
                oraconn.Open();
            }
            catch
            {
                _event_oraclelink(false);
                return false;
            }
            _event_oraclelink(true);
            return true;
        }

        private int _localdbnum;
        public int Localdbnum
        {
            get
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
#if Debug
                        cmd.CommandText = "select  count(*) from ready where issend<>1";
#else
                        cmd.CommandText = "select count(*) from ready where issend<>1";
#endif
                        cmd.Connection = sqlconn;
                        _localdbnum = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        _localdbnum = -1;
                    }
                }

                return _localdbnum;
            }
        }


        public void SendData()
        {
            _sendnum = 0;
            _errsendnum = 0;

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlconn;
#if Debug
            sqlcmd.CommandText = "select TOP 1000 * from ready where issend<>1";
#else
            sqlcmd.CommandText = "select * from ready where issend<>1";
#endif

            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = sqlcmd;
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(ad);//利用SqlCommandBuilder自动生成更新和删除命令
            DataSet ds = new DataSet();
            ad.Fill(ds);


           //SqlDataReader dr = sqlcmd.ExecuteReader();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = oraconn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
#if Debug
            cmd.CommandText = "WRITE_KM1_SN";
#else
            cmd.CommandText = "WRITE_KM2_SN";
#endif

            //while (dr.Read())
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("lsh", OracleType.VarChar, 11).Value = "66666666666";//ds.Tables[0].Rows[i]["LSH"].ToString(); //dr["LSH"].ToString();
                    cmd.Parameters.Add("sfzmhm", OracleType.VarChar, 18).Value = ds.Tables[0].Rows[i]["SFZMHM"].ToString();// dr["SFZMHM"].ToString();
                    cmd.Parameters.Add("kscx", OracleType.VarChar, 2).Value = ds.Tables[0].Rows[i]["KSCX"].ToString();//dr["KSCX"].ToString();
                    cmd.Parameters.Add("ksrq", OracleType.DateTime).Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["KSRQ"]); // Convert.ToDateTime(dr["KSRQ"]);
                    cmd.Parameters.Add("kscj", OracleType.Number).Value = Convert.ToInt16(ds.Tables[0].Rows[i]["KSCJ"]);//Convert.ToInt16(dr["KSCJ"]);
                    cmd.Parameters.Add("kscs", OracleType.Number).Value = Convert.ToInt16(ds.Tables[0].Rows[i]["KSCS"]);// Convert.ToInt16(dr["KSCS"]);
                    cmd.Parameters.Add("ksy1", OracleType.VarChar, 30).Value = ds.Tables[0].Rows[i]["KSY1"].ToString(); //dr["KSY1"].ToString();
                    cmd.Parameters.Add("ksy2", OracleType.VarChar, 30).Value = ds.Tables[0].Rows[i]["KSY2"].ToString(); //dr["KSY2"].ToString();
                    cmd.Parameters.Add("jbr", OracleType.VarChar, 30).Value = ds.Tables[0].Rows[i]["JBR"].ToString(); //dr["JBR"].ToString();
                    cmd.Parameters.Add("zt", OracleType.VarChar, 1).Value = ds.Tables[0].Rows[i]["ZT"].ToString(); //dr["ZT"].ToString();
                    cmd.Parameters.Add("sn", OracleType.VarChar, 30).Value = "SSSSSSSSSS";
                    cmd.Parameters.Add("res", OracleType.Number);
                    cmd.Parameters[11].Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add("err", OracleType.VarChar, 30);
                    cmd.Parameters[12].Direction = System.Data.ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    ds.Tables[0].Rows[i]["ISSEND"] = 1;
                    ad.Update(ds);
                }
                catch
                {
                    _errsendnum++;
                    _event_SendErr(_errsendnum);
                }
                _sendnum++;
                _event_Send(_sendnum);

            }
        }


        public string SaveSendTime()
        {
            settings.SendDatetime = System.DateTime.Now.ToString();
            ModuleConfig.SaveSettings(settings);
            return settings.Downloaddate;
        }


    }
}
