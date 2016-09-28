using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace lukao
{
    public class CModel
    {
        //public delegate void UserDataReceived(object sender, byte[] e);
        //public event UserDataReceived OnUserDataReceived;//数据到达事件
        public  ModuleSettings settings;
        private CIDCardInfo idcardinfo;
        public delegate void IDCardRequest(object sender, CStudent student);
        public event IDCardRequest OnIDCardReceived;
        private CFindAndSaveStudent findandsavestudent;
        public CKsDevManager ksdevmanager;
        public  CStudent djstudent; //正在登记的考试信息
        public System.Data.DataSet ds;
        private CPrintContent myprint;

      


        public CModel(ModuleSettings settings)
        {
           // config = new ModuleConfig();
            this.settings = settings;
            idcardinfo = new CIDCardInfo();
            idcardinfo.InitIDcardDev();
            idcardinfo.Start();
            idcardinfo.OnIDCardReceived += new CIDCardInfo.IDCardRequest(idcardinfo_OnIDCardReceived);
            findandsavestudent = new CFindAndSaveStudent(this);
            findandsavestudent.OpenLink();
            ksdevmanager = new CKsDevManager(this);
            myprint = new CPrintContent(this);
           
        }

        ////---------串口数据接收处理------------------------------
        //public void msg_OnUserDataReceived(object sender, byte[] e)
        //{
        //    this.OnUserDataReceived(this, e);
        //}

     //   public void initDataSet()
     //   {
     //       ds = new System.Data.DataSet();
     //       string connstr = "Data Source=" + settings.Ipaddress + ";Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";//;Pooling=true;Max Pool Size=20;";
     //       conn = new SqlConnection(connstr);
     //       //SqlDataAdapter da = new SqlDataAdapter("select myorder as 序号,xm as 姓名,SFZMHM as 身份证号码,ZKZMBH as 准考证号码,KSCJ as 考试成绩,LKKSRQ as 考试日期,KSY2 as 考试员,ISPRINT as 已经打印 from ready where lkcs > 0", conn);
     //       SqlDataAdapter da = new SqlDataAdapter("select * from ready where lkcs > 0", conn);
     //       da.Fill(ds, "ready");
     //   }

     //   public void UpdateDataSet()
     //   {
     //       //ds.Dispose();
     //       //ds = msdb.exeSqlForDataSet("select xm as 姓名,SFZMHM as 身份证号码,ZKZMBH as 准考证号码,KSCJ as 考试成绩 from ready where lkcs > 0");
     //       //SqlDataAdapter da = new SqlDataAdapter("select myorder as 序号,xm as 姓名,SFZMHM as 身份证号码,ZKZMBH as 准考证号码,KSCJ as 考试成绩,LKKSRQ as 考试日期,KSY2 as 考试员,ISPRINT as 已经打印 from ready where lkcs > 0", conn);
     //       SqlDataAdapter da = new SqlDataAdapter("select * from ready where lkcs > 0", conn);
     //       //sqlCmdBuilder = new SqlCommandBuilder(da);
     //       //da.Update(ds, "ready");
     ////ds.Clear();
     ////da.Fill(ds, "ready");
     //     //  ds.AcceptChanges();
            
     //   }

        public void ClearDqStudentInfo()
        {
            djstudent = null;
        }

        public CStudent  GetStudentInfo(string zkzmbhorsfzhm)
        {
            djstudent = findandsavestudent.GetStudentInfo(zkzmbhorsfzhm);
            return djstudent;
        }

        public bool SaveStudentInfo(CStudent student)
        {
            return findandsavestudent.SaveStudentInfo(student);
        }

        public bool SavePrintInfo(string zkzmbh)
        {
            return findandsavestudent.SavePrintInfo(zkzmbh);
        }

        public void idcardinfo_OnIDCardReceived(string xm,string sfzhm)
        {
            djstudent = GetStudentInfo(sfzhm);
            OnIDCardReceived(this,djstudent);
        }

        public void PrintStr(string ksdd, string ksxm, string kscj, string ksrq, string ksyxm)
        {
            myprint.ksddstr = ksdd;
            myprint.ksxmstr = ksxm;
            myprint.kscjstr = kscj;
            myprint.ksrqstr = ksrq;
            myprint.ksyxmstr = ksyxm;
            myprint.Print();
        }




    }
}
