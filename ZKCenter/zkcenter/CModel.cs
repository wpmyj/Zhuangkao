using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;


namespace zkcenter
{

    public class CModel
    {
        public CDevManager devmanager;
        CStuDevlist[] studevlist;
        public int DevNumber = 0;//桩考设备数量
        public ModuleSettings settings;
        SqlConnection sqlconn;
        SqlDataAdapter sqlad;
        DataSet sqlds;
        SqlConnection rmtSqlconn;   //remote SQL connection
        SqlDataAdapter rmtSqlad;
        DataSet rmtSqlds;
        //OracleConnection oraconn;
        bool _isstopdownload;
        public bool Isstopdownload
        {
            get { return _isstopdownload; }
            set { _isstopdownload = value; }
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

        public delegate void D_RemoteSQLLink(bool islink);
        private event D_RemoteSQLLink _event_rmtsqllink;
        public event D_RemoteSQLLink Event_RemoteSQLLink
        {
            add
            {
                _event_rmtsqllink += value;
            }
            remove
            {
                _event_rmtsqllink -= value;
            }
        }

        //public delegate void D_ORACLElink(bool islink);
        //private event D_ORACLElink _event_oraclelink; //Oracle连接事件
        //public event D_ORACLElink Event_ORACLELink
        //{
        //    add
        //    {
        //        _event_oraclelink += value;
        //    }
        //    remove
        //    {
        //        _event_oraclelink -= value;
        //    }
        //}

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


        private int _localdbnum;
        public int Localdbnum
        {
            get { return _localdbnum; }
        }


        private int _remotedbnum;
        public int Remotedbnum
        {
            get { return _remotedbnum; }
        }

        
        public CModel()
        {
            settings = ModuleConfig.GetSettings();
            devmanager = new CDevManager();
            string[] tmpstr = settings.DevOrder.ToString().Split(',');
            DevNumber = tmpstr.Length;
            studevlist = new CStuDevlist[DevNumber];
            for (int i = 0; i < DevNumber; i++)
            {
                studevlist[i] = new CStuDevlist();
                studevlist[i].DevNum = Int16.Parse(tmpstr[i]);
                devmanager.Add(studevlist[i]);
            }
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
                //_localdbnum=sqlds.Tables[0].Rows.Count;
            }
            catch
            {
                //_event_sqllink(false);
                return false;
            }

            //_event_sqllink(true);
            return true;
        }

        public bool RemoteDBlink()
        {
            try
            {
                rmtSqlconn = new SqlConnection();
                rmtSqlconn.ConnectionString = "Data Source=" + settings.Ipaddress + ";Initial Catalog=remote_zhuangkao;Persist " +
                                                                         "Security Info=True;User ID=sa;Password=cgcsxb";
                rmtSqlconn.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }
        //public bool RemoteDBlink() //远程数据连接
        //{
        //    oraconn = new OracleConnection();
        //    oraconn.ConnectionString = "Data Source=oraclelan;Persist Security Info=True;User ID=DRV_KM2;Password=cgcsxb;Unicode=True";
        //    try
        //    {
        //        oraconn.Open();
        //        OracleCommand oracmd = new OracleCommand("select count(*) from \"DRV_KM2\".\"drv_preasign\"");
        //        oracmd.Connection = oraconn;
        //        _remotedbnum=Convert.ToInt16(oracmd.ExecuteScalar());
        //    }
        //    catch
        //    {
        //        _event_oraclelink(false);
        //        return false;
        //    }
        //    _event_oraclelink(true);
        //    return true;
        //}


        //从远程的oracle数据库中读取考生信息
        public CStudent FindStudent(string zjhm)
        {
            string sqlstr=null;
            CStudent student= new CStudent();
            switch (zjhm.Length)
            {
                case 11://流水号
                    sqlstr = "select * from [dbo].[drv_preasign] where LSH='" + zjhm.Trim() + "'";
                    break;
                case 12://准考证
                    sqlstr = "select * from [dbo].[drv_preasign] where ZKZMBH='" + zjhm.Trim() + "'";
                    break;
                default://身份证军官证等
                    sqlstr = "select * from [dbo].[drv_preasign] where SFZMHM='" + zjhm.Trim() + "'";
                    break;
            }
            //OracleCommand oracmd = new OracleCommand(sqlstr);
            //oracmd.Connection = oraconn;
            //OracleDataReader dr = oracmd.ExecuteReader();
            SqlCommand sqlcmd = new SqlCommand(sqlstr, rmtSqlconn);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    student.xm = dr["XM"].ToString();
                    student.sfzmhm = dr["SFZMHM"].ToString();
                    student.zkzmbh = dr["ZKZMBH"].ToString();
                    student.kscs = Convert.ToInt16(dr["KSCS"]);
                    student.kscx = dr["KSCX"].ToString();
                    student.lsh = dr["LSH"].ToString();
                    student.jbr = dr["JBR"].ToString();
                    student.yyrq = (DateTime)dr["YYRQ"];
                    student.zt = dr["ZT"].ToString();
                    dr.Close();
                    dr.Dispose();
                    return student;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("搜索考生时数据库出错！");
            }
            dr.Close();
            dr.Dispose();
            return null;
        }


        //将数据存入本地的drv_preasign数据表中
        public bool SaveStudent(CStudent student)
        {
            string sqlstr = "delete from drv_preasign where ZKZMBH='" + student.zkzmbh.Trim() + "'";
            SqlCommand cmd = new SqlCommand(sqlstr, sqlconn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            sqlstr = "insert into drv_preasign (LSH,ZKZMBH,SFZMHM,XM,KSCX,JBR,YYRQ,KSCS,ZT) values (@LSH,@ZKZMBH,@SFZMHM,@XM,@KSCX,@JBR,@YYRQ,@KSCS,@ZT)";
            cmd.CommandText = sqlstr;
            
            cmd.Parameters.Add("@LSH", SqlDbType.NVarChar, 11).Value = student.lsh;
            cmd.Parameters.Add("@ZKZMBH", SqlDbType.NVarChar, 12).Value = student.zkzmbh;
            cmd.Parameters.Add("@SFZMHM", SqlDbType.NVarChar, 18).Value = student.sfzmhm;
            cmd.Parameters.Add("@XM", SqlDbType.NVarChar, 30).Value = student.xm;
            cmd.Parameters.Add("@KSCX", SqlDbType.NVarChar, 2).Value = student.kscx;
            cmd.Parameters.Add("@JBR", SqlDbType.NVarChar, 30).Value = student.jbr;
            cmd.Parameters.Add("@YYRQ", SqlDbType.SmallDateTime,4).Value = student.yyrq;
            cmd.Parameters.Add("@KSCS", SqlDbType.SmallInt, 2).Value = student.kscs;
            cmd.Parameters.Add("@ZT", SqlDbType.NVarChar, 1).Value = student.zt;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            return true;
        }

        //public List <string> GetDisplayStrings

    }
}
