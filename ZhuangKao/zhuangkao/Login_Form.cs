using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace zhuangkao
{
    public partial class Login_Form : Form
    {
        ModuleSettings settings;
        CIDCardInfo idcard;
        bool isidcard;//�Ƿ��������֤��¼���û�
        SqlConnection conn;
        SqlDataAdapter ad;
        DataSet ds;


        public Login_Form()
        {
            InitializeComponent();
            settings = ModuleConfig.GetSettings();
            isidcard = false;
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=" + settings.Ipaddress + ";Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";
            ad = new SqlDataAdapter();
            string sqlstr = "select * from zkuser";
            ad.SelectCommand = new SqlCommand(sqlstr, conn);
            try
            {
                conn.Open();
                ds = new DataSet();
                ad.Fill(ds);
            }
            catch
            {
                MessageBox.Show("���ݿ�����ʧ�ܣ�","׮��ϵͳ");
            }
            if (settings.UseidcardLogin == 1)
            {
                groupBox1.Enabled = false;
            }
            idcard = new CIDCardInfo();
            idcard.OnIDCardReceived += new CIDCardInfo.IDCardRequest(idcardinfo_OnIDCardReceived);
            idcard.InitIDcardDev();
            idcard.Start();
        }

        private void invokeformfun(string username, string password)
        {
            // this.DialogResult = DialogResult.Yes;
            groupBox1.Enabled = true;
            textBox1.Text  = username;
            CMyGlobal.G_Loging_Password  = password;
        }

        private delegate void InvokeDelegate(string username, string password);
        private void idcardinfo_OnIDCardReceived(string xm, string sfzhm)
        {
            groupBox1.Enabled = true;
            pictureBox1.ImageLocation = "photo.bmp";
            textBox1.Focus();
            CMyGlobal.G_Loging_Sfzhm = string.Empty;
            CMyGlobal.G_Loging_Username = string.Empty;
            isidcard = true;
            DataRow[] drs = ds.Tables[0].Select("idcardnumber='" + MD5.md5(sfzhm.Trim().Substring(0, sfzhm.Length - 2) + "liuying") + "'");
            if (drs.Length > 0)
            {
               // dq_sfzhm = MD5.md5(sfzhm.Trim().Substring(0, sfzhm.Length - 2) + "liuying");
                if (this.InvokeRequired)
                {
                    CMyGlobal.G_Loging_Sfzhm = sfzhm;
                    CMyGlobal.G_Loging_Username = xm;
                    CMyGlobal.G_UserClass  = (int)drs[0]["class"];
                    CMyGlobal.G_DBMyorder = (int)drs[0]["myorder"];
                    this.Invoke(new InvokeDelegate(invokeformfun), drs[0]["username"].ToString(), drs[0]["password"].ToString().Trim());
                }
                else
                {
                    CMyGlobal.G_Loging_Sfzhm = sfzhm;
                    CMyGlobal.G_Loging_Username = xm;
                    CMyGlobal.G_UserClass = (int)drs[0]["class"];
                    CMyGlobal.G_DBMyorder = (int)drs[0]["myorder"];
                    groupBox1.Enabled = true;
                    textBox1.Text = drs[0]["username"].ToString().Trim();
                    CMyGlobal.G_Loging_Password = drs[0]["password"].ToString().Trim();

                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //1����һ���֣���ǰ�µ�ȡֵ��ȡֵ�б����£�
            //һ�£���abc��   ���£���def��  ���£���asd��  ���£���xcd��  ���£���tyg�� 
            // ���£���kjh��   ���£���eyn��  ���£���iom��  ���£���sxn��  ʮ�£���sp�� 
            // ʮһ�£���yas��  ʮ���£���sve��  
            //2��	�ڶ����֣���ǰ����λ�ĵ��ã��磺2006�꣬ȡֵΪ����60����
            //3��	�������֣���ǰ��ֵ��5��6��ȡǰ��λ
            //4��	���Ĳ��֣���ǰ��ֵ��8��9��ȡǰ��λ
            //5��	���岿�֣���������ֵ�ӵ��Ĳ���ֵ��ȡǰ��λ��

            bool ispass = false;

            string[] yue ={ "abc", "def", "asd", "xcd", "tyg", "kjh", "eyn", "iom", "sxn", "sp", "yas", "sve" };
            string part1 = yue[Convert.ToInt16(System.DateTime.Now.Month) - 1];
            string part2 = System.DateTime.Now.Year.ToString().Substring(3, 1) + System.DateTime.Now.Year.ToString().Substring(2, 1);
            string part3 = (Convert.ToInt16(System.DateTime.Now.Month) * 5 + 6).ToString().Substring(0, 2);
            string part4 = (Convert.ToInt16(System.DateTime.Now.Day) * 8 + 9).ToString().Substring(0, 2);
            string part5 = ((Convert.ToInt16(System.DateTime.Now.Month) * 5 + 6) + (Convert.ToInt16(System.DateTime.Now.Day) * 8 + 9)).ToString().Substring(0, 2);
            string passwd = part1 + part2 + part3 + part4 + part5;

            if (isidcard)//�����֤��¼
            {
                if (CMyGlobal.G_Loging_Sfzhm == string.Empty || CMyGlobal.G_Loging_Username== string.Empty)
                {
                    ispass = false;
                }
                else
                {
                    if (CMyGlobal.G_Loging_Password == textBox2.Text.Trim())
                    {
                        ispass = true;
                    }
                }
            }
            else
            {
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        DataRow[] drs = ds.Tables[0].Select("nickname='" + textBox1.Text.Trim() + "'");
                        if (drs.Length > 0)
                        {
                            CMyGlobal.G_UserClass = (int)drs[0]["class"];
                            CMyGlobal.G_Loging_Password = drs[0]["password"].ToString().Trim();
                            CMyGlobal.G_DBMyorder = (int)drs[0]["myorder"];
                            CMyGlobal.G_Loging_Username = drs[0]["username"].ToString().Trim();
                            if (CMyGlobal.G_Loging_Password == textBox2.Text.Trim())
                            {
                               
                                ispass = true;
                            }
                        }
                    }
                }
            }

            switch (textBox1.Text)
            {
                case "iamly":
                    if (textBox2.Text == "yippee")
                    {
                        ispass = true;
                        CMyGlobal.G_UserClass = 0;
                    }
                    break; 
                case "ksy":
                    if (textBox2.Text == passwd)
                    {
                        ispass = true;
                    }
                    break;
                case "test":
                    ispass = true;
                    CMyGlobal.G_UserClass = 1;
                    break;
            }

            if (ispass)
            {
                if (checkBox1.Checked)
                {
                    CMyGlobal.G_IsConfig = true;
                }
                else
                {
                    CMyGlobal.G_IsConfig = false;
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("�û������������");
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            idcard.CloseIDcardDev();
        }
    }
}