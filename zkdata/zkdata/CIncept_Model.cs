#define Debug
//#undef Debug
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;


namespace zkdata
{
    public class CIncept_Model
    { 
        
        public ModuleSettings settings;
        SqlConnection sqlconn;
        //SqlDataAdapter sqlad;
        //DataSet sqlds;
        OracleConnection oraconn;
        bool _isstopdownload;
        public bool Isstopdownload
        {
            get { return _isstopdownload; }
            set { _isstopdownload = value; }
        }

        int _downloadnum;//接收到数据
        int _errdownloadnum;//接收错误的数据

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

        public delegate void D_Download(int downloadnum);
        private event D_Download _event_download; //下载数据事件
        public event D_Download Event_DOWNLOAD
        {
            add
            {
                _event_download += value;
            }
            remove
            {
                _event_download -= value;
            }
        }


        public delegate void D_DownloadErr(int errdownloadnum);
        private event D_DownloadErr _event_downloadErr; //下载错误数据事件
        public event D_DownloadErr Event_DOWNLOADErr
        {
            add
            {
                _event_downloadErr += value;
            }
            remove
            {
                _event_downloadErr -= value;
            }
        }

        private int _localdbnum;
        public int Localdbnum
        {
            get {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
#if Debug
                        cmd.CommandText = "select count(*) from drv_preasign";
#else
                        cmd.CommandText = "select count(*) from drv_admin.drv_preasign where (ZT ='0'or ZT='2') and (KSKM='2')";
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


        private int _remotedbnum;
        public int Remotedbnum
        {
            get { return _remotedbnum; }
        }

        
        public CIncept_Model()
        {
            settings = ModuleConfig.GetSettings();
        }

        public bool LocalDBlink() //建立本地SQL数据库连接
        {
            try
            {
                sqlconn = new SqlConnection();
                sqlconn.ConnectionString = "Data Source=" + settings.Ipaddress + ";Initial Catalog=zhuangkao;Persist " +
                                                                     "Security Info=True;User ID=sa;Password=cgcsxb";
                //sqlad = new SqlDataAdapter();
                //string sqlstr = "select * from drv_preasign";
                //sqlad.SelectCommand = new SqlCommand(sqlstr, sqlconn);
                //SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(sqlad);//利用SqlCommandBuilder自动生成更新和删除命令
                sqlconn.Open();
                //sqlds = new DataSet();
                //sqlad.Fill(sqlds);
               // _localdbnum=100;//sqlds.Tables[0].Rows.Count;
            }
            catch
            {
                _event_sqllink(false);
                return false;
            }

            _event_sqllink(true);
            return true;
        }

  //      [zkdata("DEBUG")]
        public bool RemoteDBlink() //远程数据连接
        {
            oraconn = new OracleConnection();
            oraconn.ConnectionString = "Data Source=oraclelan;Persist Security Info=True;User ID="+settings.Username+";Password="+settings.Password+";Unicode=True";
            try
            {
                oraconn.Open();
#if Debug
                OracleCommand oracmd = new OracleCommand("select count(*) from DRV_KM2.drv_preasign");
             
#else
                OracleCommand oracmd;
                if (settings.Ksdd == "-1")
                {
                   oracmd = new OracleCommand("select count(*) from drv_admin.drv_preasign where (ZT ='0'or ZT='2') and (KSKM='2')");
                }
                else
                {
                   oracmd = new OracleCommand("select count(*) from drv_admin.drv_preasign where (ZT ='0'or ZT='2') and (KSKM='2') and (KSDD='"+settings.Ksdd.Trim()+"')");
                }
                
               // OracleCommand oracmd = new OracleCommand("select count(*) from drv_admin.drv_preasign where (ZT ='0'or ZT='2') and (KSKM='2')");
#endif
                oracmd.Connection = oraconn;
                _remotedbnum=Convert.ToInt16(oracmd.ExecuteScalar());
            }
            catch
            {
                _event_oraclelink(false);
                return false;
            }
            _event_oraclelink(true);
            return true;
        }

        public int ClearLocalData()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.CommandText = "delete from drv_preasign";
                    cmd.Connection = sqlconn;
                    return  Convert.ToInt16(cmd.ExecuteScalar());
                }
                catch
                {
                    return -1;
                }
            }
        }

        public void DownloadData() //接收数据
        {
            _isstopdownload = false;
            _downloadnum = 0;
            _errdownloadnum = 0;

            string sqlstr = "insert into drv_preasign (LSH,KSKM,ZKZMBH,SFZMHM,XM,KSCX,KSDD,YYRQ,JBR,ZT) values (@LSH,@KSKM,@ZKZMBH,@SFZMHM,@XM,@KSCX,@KSDD,@YYRQ,@JBR,@ZT)";
            SqlCommand cmd = new SqlCommand(sqlstr, sqlconn);

            OracleCommand oracmd = new OracleCommand("select * from DRV_KM2.drv_preasign");
            oracmd.Connection = oraconn;
            OracleDataReader dr = oracmd.ExecuteReader();
            while (dr.Read() && (!_isstopdownload))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@LSH", SqlDbType.NVarChar, 11).Value = dr["LSH"].ToString();
                    cmd.Parameters.Add("@KSKM", SqlDbType.NVarChar, 1).Value = dr["KSKM"].ToString();
                    cmd.Parameters.Add("@ZKZMBH", SqlDbType.NVarChar, 12).Value = dr["ZKZMBH"].ToString();
                    cmd.Parameters.Add("@SFZMHM", SqlDbType.NVarChar, 18).Value = dr["SFZMHM"].ToString();
                    cmd.Parameters.Add("@XM", SqlDbType.NVarChar, 30).Value = dr["XM"].ToString();
                    cmd.Parameters.Add("@KSCX", SqlDbType.NVarChar, 2).Value = dr["KSCX"].ToString();
                    cmd.Parameters.Add("@KSDD", SqlDbType.NVarChar, 64).Value = dr["KSDD"].ToString();
                    cmd.Parameters.Add("@YYRQ", SqlDbType.DateTime).Value = Convert.ToDateTime(dr["YYRQ"]);
                    cmd.Parameters.Add("@JBR", SqlDbType.NVarChar, 30).Value = dr["JBR"].ToString();
                    //cmd.Parameters.Add("@KSCJ", SqlDbType.SmallInt).Value = Convert.ToInt16(dr["KSCJ"]);
                    cmd.Parameters.Add("@ZT", SqlDbType.NVarChar, 1).Value = dr["ZT"].ToString();
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    _errdownloadnum++;
                    _event_downloadErr(_errdownloadnum);
                    continue;
                }
               _downloadnum++;
               _event_download(_downloadnum);
            }
            dr.Dispose();
        }

        public string SavedownloadTime()
        {
            settings.Downloaddate = System.DateTime.Now.ToString();
            ModuleConfig.SaveSettings(settings);
            return settings.Downloaddate;
        }

    }
}
