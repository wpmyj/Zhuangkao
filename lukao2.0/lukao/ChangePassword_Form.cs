using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lukao
{
    public partial class ChangePassword_Form : Form
    {
        string dq_sfzhm;
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;

        public ChangePassword_Form(string dq_sfzhm,string ip)
        {
            InitializeComponent();
            this.dq_sfzhm = dq_sfzhm;
            conn = new SqlConnection("Data Source=" + ip + ";Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb");
            da = new SqlDataAdapter();
            da.SelectCommand =new SqlCommand("select * from dbo.[user] where idcardnumber='" + dq_sfzhm + "'",conn);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(da);
            conn.Open();
            ds = new DataSet();
            da.Fill(ds);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                if (textBox1.Text == ds.Tables[0].Rows[0]["password"].ToString().Trim())
                {
                    ds.Tables[0].Rows[0]["password"] = textBox2.Text;
                    da.Update(ds);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("�����޸ĳɹ���");
                }
                else
                {
                    MessageBox.Show("���������");
                }
            }
            else
            {
                MessageBox.Show("������������벻һ�£�");
            }
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}