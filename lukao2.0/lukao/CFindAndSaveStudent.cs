using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace lukao
{
    public class CFindAndSaveStudent
    {
        CModel model;
        private CMsSqlDatabase msdbread;
        private CMsSqlDatabase msdbwrite;
        public CFindAndSaveStudent(CModel model)
        {
            this.model = model;
          
        }

        public void OpenLink()
        {
            string connstr = "Data Source=" + model.settings.Ipaddress + ";Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";//;Pooling=true;Max Pool Size=20;";
            msdbread = new CMsSqlDatabase(connstr);
            msdbread.OpenConnect();
            msdbwrite = new CMsSqlDatabase(connstr);
            msdbwrite.OpenConnect();
        }

        public void CloseLink()
        {
            msdbread.CloseConnect();
            msdbwrite.CloseConnect();
        }

        public bool SavePrintInfo(string zkzmbh)
        {
            if (zkzmbh != "")
            {
                string sqlstr = "update ready set ISPRINT = 1  where ZKZMBH= '" + zkzmbh.Trim() + "'";
                if (msdbwrite.exeSql(sqlstr))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public bool SaveStudentInfo(CStudent student)
        {
            if (student != null)
            {
                //string sqlstr = "update ready set kscj=" + student.kscj.ToString() + ",ksy2='" + student.ksy2.Trim() + "',LKCS ="+ student.lkcs.ToString().Trim()+",LKKSRQ = '"+ student.ksrq.ToString()  +"' where ZKZMBH= '" + student.zkzmbh.Trim() + "'";
                string sqlstr;
                if (model.settings.lkrqORzkrq == 0)
                {
                    sqlstr = "update ready set kscj=" + student.kscj.ToString() + ",ksy2='" + student.ksy2.Trim() + "',LKCS =" + student.lkcs.ToString().Trim() + ",KSRQ = '" + System.DateTime.Now.ToString() + "' where ZKZMBH= '" + student.zkzmbh.Trim() + "'";
                }
                else
                {
                     sqlstr = "update ready set kscj=" + student.kscj.ToString() + ",ksy2='" + student.ksy2.Trim() + "',LKCS =" + student.lkcs.ToString().Trim() + ",LKKSRQ = '" + System.DateTime.Now.ToString() + "' where ZKZMBH= '" + student.zkzmbh.Trim() + "'";
                }
                if (msdbwrite.exeSql(sqlstr))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public CStudent  GetStudentInfo(string zkzmbhorsfzhm)
        {

            CStudent student = new CStudent(model);
            //       student.zkzmbh = zkzmbhorsfzhm.Trim();
            //            student.lsh = "12345678901";
            //            student.xm = "≤‚ ‘";
            //            student.sfzmhm = "610104199922122345";
            //            student.kscx = "C1";
            //            student.ksrq = System.DateTime.Now;
            //return student;
            try
            {
                if (zkzmbhorsfzhm.Length == 12)
                {
                    string strsql = "select * from ready where ZKZMBH ='" + zkzmbhorsfzhm.Trim() + "'";

                    IDataReader dr = msdbread.executeReader(strsql);
                    if (dr.Read())
                    {
                        student.zkzmbh = zkzmbhorsfzhm.Trim();
                        student.lsh = dr["LSH"].ToString().Trim();
                        student.xm = dr["XM"].ToString().Trim();
                        student.sfzmhm = dr["SFZMHM"].ToString().Trim();
                        student.kscx = dr["KSCX"].ToString().Trim();
                        student.ksrq = System.DateTime.Now;
                        // student.zkrq = Convert.ToDateTime(dr["KSRQ"]);
                        string ksrqstr;
                        if (model.settings.lkrqORzkrq == 0)
                        {
                            ksrqstr = "KSRQ";
                        }
                        else
                        {
                            ksrqstr = "LKKSRQ";
                        }
                        if (Convert.ToDateTime(dr[ksrqstr]).Date != System.DateTime.Now.Date)
                        {
                            student.lkcs = 1;
                        }
                        else
                        {

                            if (dr["LKCS"] != null)
                            {
                                student.lkcs = Convert.ToInt16(dr["LKCS"]) + 1;
                            }
                            else
                            {
                                student.lkcs = 1;
                            }
                        }


                        dr.Close();
                        dr.Dispose();
                        return student;

                    }

                    dr.Close();
                    dr.Dispose();
                    return null;
                }
                else
                {
                    string strsql = "select * from ready where SFZMHM ='" + zkzmbhorsfzhm.Trim() + "'";
                    IDataReader dr = msdbread.executeReader(strsql);
                    if (dr.Read())
                    {
                        student.sfzmhm = zkzmbhorsfzhm.Trim();
                        student.lsh = dr["LSH"].ToString().Trim();
                        student.xm = dr["XM"].ToString().Trim();
                        student.zkzmbh = dr["ZKZMBH"].ToString().Trim();
                        student.kscx = dr["KSCX"].ToString().Trim();
                        student.ksrq = System.DateTime.Now;
                        // student.zkrq = Convert.ToDateTime(dr["LKKSRQ"]);
                        // student.ksy1 = dr["KSY1"].ToString().Trim();
                        string ksrqstr;
                        if (model.settings.lkrqORzkrq == 0)
                        {
                            ksrqstr = "KSRQ";
                        }
                        else
                        {
                            ksrqstr = "LKKSRQ";
                        }
                        if (Convert.ToDateTime(dr[ksrqstr]).Date != System.DateTime.Now.Date)
                        {
                            student.lkcs = 1;
                        }
                        else
                        {
                            if (dr["LKCS"] != null)
                            {
                                student.lkcs = Convert.ToInt16(dr["LKCS"]) + 1;
                            }
                            else
                            {
                                student.lkcs = 1;
                            }
                        }

                        dr.Close();
                        dr.Dispose();
                        return student;
                    }
                    dr.Close();
                    dr.Dispose();
                    return null;

                }
            }
            catch
            {
                return null;
            }
        }


        ~CFindAndSaveStudent()
        {
            CloseLink();
        }

    }
}
