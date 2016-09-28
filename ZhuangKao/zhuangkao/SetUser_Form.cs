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
    public partial class SetUser_Form : Form
    {
        ModuleSettings settings;
        SqlConnection conn;
        SqlDataAdapter ad;
        DataSet ds;
        CIDCardInfo idcardinfo;
        private delegate void InvokeDelegate(string xm, string sfzhm);
        InvokeDelegate userinvoke;

        public SetUser_Form(ModuleSettings settings)
        {
            InitializeComponent();
            this.settings = settings;

            label_xm.Text  = string.Empty;
            label_sfzhm.Text = string.Empty;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            idcardinfo = new CIDCardInfo();
            idcardinfo.InitIDcardDev();
            idcardinfo.Start();
            idcardinfo.OnIDCardReceived += new CIDCardInfo.IDCardRequest(idcardinfo_OnIDCardReceived);
            userinvoke = new InvokeDelegate(userinvokefun);

            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=" + settings.Ipaddress + ";Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";
            ad = new SqlDataAdapter();
            string sqlstr = "select * from zkuser";
            ad.SelectCommand = new SqlCommand(sqlstr,conn);
            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(ad);
            conn.Open();
            ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["username"].HeaderText = "用户名";
            dataGridView1.Columns["nickname"].HeaderText = "警号";
            dataGridView1.Columns["class"].HeaderText = "权限级别";
            dataGridView1.Columns["password"].Visible = false;
            dataGridView1.Columns["myorder"].Visible = false;
            dataGridView1.Columns["idcardnumber"].Visible = false;

        }


        private void userinvokefun(string xm, string sfzhm)
        {
            label_xm.Text = xm;
            label_sfzhm.Text = sfzhm;
        }

        private void idcardinfo_OnIDCardReceived(string xm, string sfzhm)
        {
            if ((label_xm.InvokeRequired) || (label_sfzhm.InvokeRequired))
            {
                label_xm.Invoke(userinvoke, xm, sfzhm);
            }
            else
            {
                label_xm.Text = xm;
                label_sfzhm.Text = sfzhm;
            }
        }

        private void SetUser_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            idcardinfo.CloseIDcardDev();
        }

        private void button2_Click(object sender, EventArgs e) //删除用户
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if ((int)ds.Tables[0].Rows[dataGridView1.SelectedRows[0].Index]["class"] > 0)
                {
                    try
                    {
                        ds.Tables[0].Rows[dataGridView1.SelectedRows[0].Index].Delete();
                        ad.Update(ds);
                    }
                    catch
                    {
                        MessageBox.Show("新建用户请下次进入用户管理时才能正确删除！");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //添加用户
        {
            if(textBox_passwd.Text !=textBox_rpasswd.Text )
            {
                MessageBox.Show("两次密码输入不一致！");
                textBox_passwd.Focus();
                return;
            }
            if (label_xm.Text != string.Empty && label_sfzhm.Text != string.Empty)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["username"] = label_xm.Text.Trim();
                dr["idcardnumber"] = MD5.md5(label_sfzhm.Text + "liuying");
                dr["password"] = textBox_passwd.Text.Trim();
                dr["class"] = Convert.ToInt16(domainUpDown_class.Text);
                if (textBox_nicheng.Text == string.Empty)
                {
                    dr["nickname"] = label_xm.Text.Trim();
                }
                else
                {
                    dr["nickname"] = textBox_nicheng.Text.Trim();
                }
                ds.Tables[0].Rows.Add(dr);
                ad.Update(ds);
                label_xm.Text = string.Empty;
                label_sfzhm.Text = string.Empty;
                textBox_passwd.Text = string.Empty;
                textBox_rpasswd.Text = string.Empty;
            }
            else
            {
                DataRow dr = ds.Tables[0].NewRow();
                if (textBox_nicheng.Text == string.Empty)
                {
                    MessageBox.Show("不用身份证登记，警号不能为空！");
                    return;
                }
                else
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["nickname"].ToString().Trim() == textBox_nicheng.Text.Trim())
                        {
                          MessageBox.Show("数据库里已有此警号，请重新选择警号！");
                          textBox_nicheng.Focus();
                           return;
                        }
                    }
                    dr["nickname"] = textBox_nicheng.Text.Trim();
                }
                dr["password"] = textBox_passwd.Text.Trim();
                if (Convert.ToInt16(domainUpDown_class.Text) < 3)
                {
                    MessageBox.Show("不用身份证登记，不能创建权限级别小于3的用户！");
                    return;
                }
                else
                {
                    dr["class"] = Convert.ToInt16(domainUpDown_class.Text);
                }
                ds.Tables[0].Rows.Add(dr);
                ad.Update(ds);
                textBox_nicheng.Text = string.Empty;
                label_xm.Text = string.Empty;
                label_sfzhm.Text = string.Empty;
                textBox_passwd.Text=string.Empty;
                textBox_rpasswd.Text=string.Empty;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void domainUpDown_class_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(domainUpDown_class.Text) > 4 || Convert.ToInt16(domainUpDown_class.Text)<1)
                {
                    System.Windows.Forms.MessageBox.Show("非法权限级别！");
                    domainUpDown_class.Focus();
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("非法权限级别！");
                domainUpDown_class.Focus();
            }
        }

        private void SetUser_Form_Load(object sender, EventArgs e)
        {
            textBox_nicheng.Focus();
        }
    }
}