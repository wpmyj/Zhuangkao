using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cn.Youdundianzi.Share.Module.Login;
using Cn.Youdundianzi.Core.Exam;
using System.IO;

namespace Cn.Youdundianzi.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");
            Logger.LogTextWriter = new System.IO.StreamWriter("Logs\\log" + DateTime.Today.ToString("yyyyMMdd") + ".txt", true);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginfrm = new LoginForm();
            loginfrm.ShowDialog();

            switch (loginfrm.DialogResult)
            {
                case DialogResult.OK:
                    switch (CMyGlobal.G_Login_UserCls)
                    {
                        case UserClass.APPADMIN:
                            Application.Run(new AppConfigFrm());
                            break;
                        default:
                            Application.Run(new MainFrm());
                            break;
                    }
                    break;
            }
        }
    }
}