using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace zkcenter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            CModel model = new CModel();
            CCtrl ctrl = new CCtrl(model);
           // Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Main_Form());
        }
    }
}