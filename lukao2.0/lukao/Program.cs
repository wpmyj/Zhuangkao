using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lukao
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread] 
        

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login_Form loginfrm = new Login_Form();
            loginfrm.ShowDialog();
      
            switch (loginfrm.DialogResult)
            {
                case DialogResult.OK:
                    Application.Run(new Menu_Form(0, loginfrm.dq_sfzhm));
                    break;
                case DialogResult.Yes:
                    ModuleSettings settings;
                    settings = new ModuleSettings();
                    settings = ModuleConfig.GetSettings();
                    CModel model = new CModel(settings);
                   // CController ctrl = new CController(model);
                    //mainview = new main_view(this, model);
                    Application.Run(new main_view(model));
                    break;
                case DialogResult.No:
                    Application.Run(new Menu_Form(1, loginfrm.dq_sfzhm));
                    break;
            } 
          
        }
    }
}