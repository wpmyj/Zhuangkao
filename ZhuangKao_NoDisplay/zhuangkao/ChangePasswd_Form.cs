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
    public partial class ChangePasswd_Form : Form
    {
        ModuleSettings settings;
        SqlConnection conn;
        SqlCommand cmd;

        public ChangePasswd_Form()
        {
            InitializeComponent();
            settings = ModuleConfig.GetSettings();
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=" + settings.Ipaddress + ";Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CMyGlobal.G_Loging_Password == textBox1.Text)
            {
                if (textBox2.Text.Trim() == textBox3.Text.Trim())
                {
                    conn.Open();
                    cmd = new SqlCommand("update zkuser set password='" + textBox2.Text.Trim() + "' where myorder=" + CMyGlobal.G_DBMyorder.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("�����޸ĳɹ���");
                }
                else
                {
                    MessageBox.Show("����2�������벻һ�£�");
                }
            }
            else
            {
                MessageBox.Show("���������");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}