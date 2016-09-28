using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GenCode128;
using Util;

namespace Modules.PrintModule
{
    public partial class SetPrint_Form : Form
    {
        private CTextPrintObjSet ksxmtxt;
        private CTextPrintObjSet ksddtxt;
        private CTextPrintObjSet kscjtxt;
        private CTextPrintObjSet ksrqtxt;
        private CTextPrintObjSet ksyxmtxt;
        private CTextPrintObjSet kscxtxt;
        private CImagePrintObjSet tiaomaimg;

        Print_form pf;
 
        private PrintSettings settings;
        private CSettings fullSettings;
        private string configFilePath = string.Empty;




        string str2wheelconfigFilePath;
        string str3wheelconfigFilePath;
        Signal.MotorSignal.MotorSignalSettings settings2;
        Signal.MotorSignal.MotorSignalSettings settings3;





        public SetPrint_Form(Signal.MotorSignal.MotorSignalSettings set2, string str2, Signal.MotorSignal.MotorSignalSettings set3, string str3)
        {
            InitializeComponent();

            this.settings2 = set2;
            this.settings3 = set3;
            this.str2wheelconfigFilePath = str2;
            this.str3wheelconfigFilePath = str3;


        }
        public void InitializePrintFormComponent(CSettings csetting, string configPath)
        {
            this.fullSettings = csetting;
            this.settings = csetting.PrintConfig;
            this.configFilePath = configPath;

            pf = new Print_form(Convert.ToInt16(210 * 4), Convert.ToInt16(297 * 4));

            ksddtxt = new CTextPrintObjSet();
            ksddtxt.Printtext = "考试地点";
            ksddtxt.mmX = settings.Ksdd_x;
            ksddtxt.mmY = settings.Ksdd_y;
            ksdd_x.Text = settings.Ksdd_x.ToString();
            ksdd_y.Text = settings.Ksdd_y.ToString();
            pf.PrintRegister(ksddtxt);

            ksxmtxt = new CTextPrintObjSet();
            ksxmtxt.Printtext = "考生姓名";
            ksxmtxt.mmX = settings.Ksxm_x;
            ksxmtxt.mmY = settings.Ksxm_y;
            ksxm_x.Text = settings.Ksxm_x.ToString();
            ksxm_y.Text = settings.Ksxm_y.ToString();
            pf.PrintRegister(ksxmtxt);

            kscjtxt = new CTextPrintObjSet();
            kscjtxt.Printtext = "考试成绩";
            kscjtxt.mmX = settings.Kscj_x;
            kscjtxt.mmY = settings.Kscj_y;
            kscj_x.Text = settings.Kscj_x.ToString();
            kscj_y.Text = settings.Kscj_y.ToString();
            pf.PrintRegister(kscjtxt);

            kscxtxt = new CTextPrintObjSet();
            kscxtxt.Printtext = "考试车型";
            kscxtxt.mmX = settings.Kscx_x;
            kscxtxt.mmY = settings.Kscx_y;
            kscx_x.Text = settings.Kscx_x.ToString();
            kscx_y.Text = settings.Kscx_y.ToString();
            pf.PrintRegister(kscxtxt);


            ksrqtxt = new CTextPrintObjSet();
            ksrqtxt.Printtext = "考试日期";
            ksrqtxt.mmX = settings.Ksrq_x;
            ksrqtxt.mmY = settings.Ksrq_y;
            ksrq_x.Text = settings.Ksrq_x.ToString();
            ksrq_y.Text = settings.Ksrq_y.ToString();
            pf.PrintRegister(ksrqtxt);

            ksyxmtxt = new CTextPrintObjSet();
            ksyxmtxt.Printtext = "考试员姓名";
            ksyxmtxt.mmX = settings.Ksyxm_x;
            ksyxmtxt.mmY = settings.Ksyxm_y;
            ksyxm_x.Text = settings.Ksyxm_x.ToString();
            ksyxm_y.Text = settings.Ksyxm_y.ToString();
            pf.PrintRegister(ksyxmtxt);

            tiaomaimg = new CImagePrintObjSet();
            tiaomaimg.InImage = Code128Rendering.MakeBarcodeImage("测试员100", 1, true);
            tiaomaimg.mmX = settings.Tiaomaimg_x;
            tiaomaimg.mmY = settings.Tiaomaimg_y;
            pf.PrintRegister(tiaomaimg);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pf.ShowDialog();
            ksdd_x.Text = ksddtxt.mmX.ToString();
            ksdd_y.Text = ksddtxt.mmY.ToString(); 

            ksxm_x.Text = ksxmtxt.mmX.ToString();
            ksxm_y.Text = ksxmtxt.mmY.ToString();

            ksrq_x.Text = ksrqtxt.mmX.ToString();
            ksrq_y.Text = ksrqtxt.mmY.ToString();

            kscj_x.Text = kscjtxt.mmX.ToString();
            kscj_y.Text = kscjtxt.mmY.ToString();

            ksyxm_x.Text = ksyxmtxt.mmX.ToString();
            ksyxm_y.Text = ksyxmtxt.mmY.ToString();
           
            kscx_x.Text = kscxtxt.mmX.ToString();
            kscx_y.Text = kscxtxt.mmY.ToString();
        }

        private void SetPrint_Form_Load(object sender, EventArgs e)
        {
            InitializePrintFormComponent(settings2, str2wheelconfigFilePath);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            settings.Ksxm_x = Convert.ToInt16(ksxm_x.Text);
            settings.Ksxm_y = Convert.ToInt16(ksxm_y.Text);

            settings.Ksdd_x = Convert.ToInt16(ksdd_x.Text);
            settings.Ksdd_y = Convert.ToInt16(ksdd_y.Text);

            settings.Ksrq_x = Convert.ToInt16(ksrq_x.Text);
            settings.Ksrq_y = Convert.ToInt16(ksrq_y.Text);

            settings.Kscj_x = Convert.ToInt16(kscj_x.Text);
            settings.Kscj_y = Convert.ToInt16(kscj_y.Text);


            settings.Kscx_x = Convert.ToInt16(kscx_x.Text);
            settings.Kscx_y = Convert.ToInt16(kscx_y.Text);

            settings.Ksyxm_x = Convert.ToInt16(ksyxm_x.Text);
            settings.Ksyxm_y = Convert.ToInt16(ksyxm_y.Text);

            ModuleConfig.SaveSettings(this.fullSettings, configFilePath);
        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            InitializePrintFormComponent(settings2, str2wheelconfigFilePath);
            
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            InitializePrintFormComponent(settings3, str3wheelconfigFilePath);
        }
    }
}