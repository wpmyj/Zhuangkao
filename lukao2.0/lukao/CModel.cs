using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace lukao
{
    public class CModel
    {
        //public delegate void UserDataReceived(object sender, byte[] e);
        //public event UserDataReceived OnUserDataReceived;//���ݵ����¼�
        public  ModuleSettings settings;
        private CIDCardInfo idcardinfo;
        public delegate void IDCardRequest(object sender, CStudent student);
        public event IDCardRequest OnIDCardReceived;
        private CFindAndSaveStudent findandsavestudent;
        public CKsDevManager ksdevmanager;
        public  CStudent djstudent; //���ڵǼǵĿ�����Ϣ
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

        ////---------�������ݽ��մ���------------------------------
        //public void msg_OnUserDataReceived(object sender, byte[] e)
        //{
        //    this.OnUserDataReceived(this, e);
        //}

     //   public void initDataSet()
     //   {
     //       ds = new System.Data.DataSet();
     //       string connstr = "Data Source=" + settings.Ipaddress + ";Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";//;Pooling=true;Max Pool Size=20;";
     //       conn = new SqlConnection(connstr);
     //       //SqlDataAdapter da = new SqlDataAdapter("select myorder as ���,xm as ����,SFZMHM as ���֤����,ZKZMBH as ׼��֤����,KSCJ as ���Գɼ�,LKKSRQ as ��������,KSY2 as ����Ա,ISPRINT as �Ѿ���ӡ from ready where lkcs > 0", conn);
     //       SqlDataAdapter da = new SqlDataAdapter("select * from ready where lkcs > 0", conn);
     //       da.Fill(ds, "ready");
     //   }

     //   public void UpdateDataSet()
     //   {
     //       //ds.Dispose();
     //       //ds = msdb.exeSqlForDataSet("select xm as ����,SFZMHM as ���֤����,ZKZMBH as ׼��֤����,KSCJ as ���Գɼ� from ready where lkcs > 0");
     //       //SqlDataAdapter da = new SqlDataAdapter("select myorder as ���,xm as ����,SFZMHM as ���֤����,ZKZMBH as ׼��֤����,KSCJ as ���Գɼ�,LKKSRQ as ��������,KSY2 as ����Ա,ISPRINT as �Ѿ���ӡ from ready where lkcs > 0", conn);
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
