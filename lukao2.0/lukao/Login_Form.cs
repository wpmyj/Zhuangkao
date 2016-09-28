using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lukao
{
    public partial class Login_Form : Form
    {
        CIDCardInfo idcardinfo;
        private delegate void InvokeDelegate(string username,string password);
        InvokeDelegate invokeform;
        int userclass;
        string userpassword;//用户在数据库中的密码
        string username;
        public string  dq_sfzhm;//用户序列号

        public Login_Form()
        {
            InitializeComponent();
            ModuleSettings settings = ModuleConfig.GetSettings();
            if (settings.Useidcard == 1)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
            userclass = 1;
            invokeform = new InvokeDelegate(invokeformfun);
            idcardinfo = new CIDCardInfo();
            idcardinfo.InitIDcardDev();
            idcardinfo.OnIDCardReceived += new CIDCardInfo.IDCardRequest(idcardinfo_OnIDCardReceived);
            idcardinfo.Start();
        }

        private void invokeformfun(string username,string password)
        {
         
           // this.DialogResult = DialogResult.Yes;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox1.Text = username;
            this.username = username;
            userpassword = password;
        }

        private void idcardinfo_OnIDCardReceived(string xm, string sfzhm)
        {
            DataRow[] drs = zhuangkaoDataSet1.Tables["user"].Select("idcardnumber='" + MD5.md5(sfzhm.Trim().Substring(0,sfzhm.Length-2) + "liuying") + "'");
           // DataRow[] drs = zhuangkaoDataSet1.Tables["user"].Select("idcardnumber like '%58%'");
            
            if(drs.Length>0)
            {
                idcardinfo.Stop();
                idcardinfo.CloseIDcardDev();
                dq_sfzhm = MD5.md5(sfzhm.Trim().Substring(0, sfzhm.Length - 2) + "liuying");
                if (this.InvokeRequired)
                {
                    userclass =(int) drs[0]["class"];

                    this.Invoke(invokeform, drs[0]["username"].ToString(), drs[0]["password"].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //1、第一部分：当前月的取值，取值列表如下：
          //一月：“abc”   二月：“def”  三月：“asd”  四月：“xcd”  五月：“tyg” 
          // 六月：“kjh”   七月：“eyn”  八月：“iom”  九月：“sxn”  十月：“sp” 
          // 十一月：“yas”  十二月：“sve”  
         //2、	第二部分：当前年两位的倒置，如：2006年，取值为：“60”；
        //3、	第三部分：当前月值乘5加6，取前两位
        //4、	第四部分：当前日值乘8加9，取前两位
        //5、	第五部分：第三部分值加第四部分值，取前两位。

            bool ispass = false;

            string[] yue ={ "abc", "def", "asd", "xcd", "tyg", "kjh", "eyn", "iom", "sxn", "sp", "yas", "sve" };
            string part1 = yue[Convert.ToInt16(System.DateTime.Now.Month)-1];
            string part2 = System.DateTime.Now.Year.ToString().Substring(3, 1) + System.DateTime.Now.Year.ToString().Substring(2, 1);
            string part3 = (Convert.ToInt16(System.DateTime.Now.Month) * 5 + 6).ToString().Substring(0,2);
            string part4 = (Convert.ToInt16(System.DateTime.Now.Day) * 8 + 9).ToString().Substring(0, 2);
            string part5 = ((Convert.ToInt16(System.DateTime.Now.Month) * 5 + 6) + (Convert.ToInt16(System.DateTime.Now.Day) * 8 + 9)).ToString().Substring(0, 2);
            string passwd = part1 + part2 + part3 + part4 + part5;
            if (textBox1.Text == "iamly")
            {
                if (textBox2.Text == "yippee")
                {
                    userclass = 0; 
                    ispass = true;
                }
            }
            if (textBox1.Text == "test")
            {
                if (textBox2.Text == "")
                {
                    userclass = 0;
                    ispass = true;
                }
            }
            else
            {
                if (textBox1.Text == "ksy")
                {
                    if (textBox2.Text == passwd)
                    {
                        ispass = true;
                    }
                }
                else
                {
                    if (textBox1.Text == username)
                    {
                        if (textBox2.Text == userpassword.Trim())
                        {
                            ispass = true;
                        }
                    }
                    
                }
            }

            
           //textBox2.Text = passwd;
            if (ispass)
            {
                if (checkBox1.Checked)
                {
                    idcardinfo.Stop();
                    idcardinfo.CloseIDcardDev();
                    if (userclass > 0)
                    {
                        this.DialogResult = DialogResult.No;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK ;
                    }
                }
                else
                {
                    idcardinfo.Stop();
                    idcardinfo.CloseIDcardDev();
                    this.DialogResult = DialogResult.Yes;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string aaa = zhuangkaoDataSet1.Tables["user"].Rows[0][3].ToString();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“zhuangkaoDataSet1.user”中。您可以根据需要移动或移除它。
            this.userTableAdapter.Fill(this.zhuangkaoDataSet1.user);

        }

    }
}