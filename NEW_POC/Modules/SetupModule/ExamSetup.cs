using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.SetupModule
{
    public partial class ExamSetup : Form
    {
        string strDQFileName;//当前配置文件名
        string str2wheelconfigFilePath;
        string str3wheelconfigFilePath;
        Signal.MotorSignal.MotorSignalSettings settings2;
        Signal.MotorSignal.MotorSignalSettings settings3;
        Signal.MotorSignal.MotorSignalSettings settings;//当前settings对象
       
        public ExamSetup(Signal.MotorSignal.MotorSignalSettings set2, string str2, Signal.MotorSignal.MotorSignalSettings set3, string str3)
        {
            InitializeComponent();

            this.settings2 = set2;
            this.settings3 = set3;
            this.str2wheelconfigFilePath = str2;
            this.str3wheelconfigFilePath = str3;
        }

        private void ExamSetup_Load(object sender, EventArgs e)
        {
            Bind(settings2, str2wheelconfigFilePath);
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Util.ModuleConfig.SaveSettings(settings, strDQFileName);
        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            Bind(settings2,str2wheelconfigFilePath);
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            Bind(settings3, str3wheelconfigFilePath);
        }

        //绑定属性浏览器
        private void Bind(Signal.MotorSignal.MotorSignalSettings set, string filename)
        {
            strDQFileName = filename;
            settings = set;
            this.propertyGrid1.SelectedObject = settings;
        }

       
    }
}