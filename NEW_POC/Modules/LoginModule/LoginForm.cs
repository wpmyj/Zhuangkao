using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.LoginModule
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool pass = false;
            if (this.txtUserName.Text == "" || this.txtPassword.Text == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
                this.txtUserName.Focus();
            }
            else
            {

                if (this.txtUserName.Text == "iamly" && this.txtPassword.Text == "yippee")
                {
                    pass = true;
                    if (this.checkBox1.Checked != true)
                       Modules.LoginModule.CMyGlobal.UserClass = 0;
                    else
                       Modules.LoginModule.CMyGlobal.UserClass = 2;

                }
                if (this.txtUserName.Text == "cgs" && this.txtPassword.Text == "123")
                {
                    pass = true;
                    if (this.checkBox1.Checked!= true)
                        Modules.LoginModule.CMyGlobal.UserClass = 1;
                    else
                        Modules.LoginModule.CMyGlobal.UserClass =3;
                }

                if (pass)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                    this.txtUserName.Focus();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}