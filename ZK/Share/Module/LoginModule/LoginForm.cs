using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cn.Youdundianzi.Share.Module.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.txtUserName.Text;
            string password = this.txtPassword.Text;
            if (username.Trim() == "" || password.Trim() == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
                this.txtUserName.Focus();
            }
            else
            {

                if (username == "iamly" && password == "yippee")
                {
                    CMyGlobal.G_Login_Username = username;
                    CMyGlobal.G_Login_UserCls = UserClass.SUPER;
                }
                else if (username == "practicer" && password == "practicer")
                {
                    CMyGlobal.G_Login_Username = username;
                    CMyGlobal.G_Login_UserCls = UserClass.PRACTICE;
                }
                else if (username == "examer" && password == "examer")
                {
                    CMyGlobal.G_Login_Username = username;
                    CMyGlobal.G_Login_UserCls = UserClass.EXAM;
                }
                else if (username.Equals("null") && password.Equals("null"))
                {
                    CMyGlobal.G_Login_Username = username;
                    CMyGlobal.G_Login_UserCls = UserClass.NONE;
                }
                else if (username == "admin" && password == "admin")
                {
                    CMyGlobal.G_Login_Username = username;
                    CMyGlobal.G_Login_UserCls = UserClass.ADMIN;
                }
                else if (username == "appadmin" && password == "appadmin")
                {
                    CMyGlobal.G_Login_Username = username;
                    CMyGlobal.G_Login_UserCls = UserClass.APPADMIN;
                }
                else
                {
                    //添加从数据库中读取登陆用户信息代码
                }

                if (CMyGlobal.G_Login_UserCls == UserClass.NONE)
                {
                    MessageBox.Show("用户名或密码错误！");
                    this.txtUserName.Focus();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}