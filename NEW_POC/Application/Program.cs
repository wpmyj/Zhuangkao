using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Exam;

namespace App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Modules.LoginModule.LoginForm loginfrm = new Modules.LoginModule.LoginForm();
            loginfrm.ShowDialog();
            if (loginfrm.DialogResult == DialogResult.OK)
            {
                Application.Run(new MainForm());

            }
        }
    }
}