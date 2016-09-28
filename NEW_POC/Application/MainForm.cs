using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Exam;
using Modules.PrintModule;
using Signal;
using Signal.MotorSignal;



namespace App
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
           
            InitializeComponent();
            switch (Modules.LoginModule.CMyGlobal.UserClass)
            {
                case 0:
                    this.sideBarPanelItemSetup.Visible = false;
                    break;
                case 1:
                    this.sideBarPanelItemSetup.Visible = false;
                 
                    break;
                case 2:
                  
                    this.sideBarPanelItemExam.Visible = false;
                    this.sideBarPanelItemScore.Visible = false;
                    break;
                case 3:
                   
                    this.sideBarPanelItemExam.Visible = false;
                    this.sideBarPanelItemScore.Visible = false;
                    this.btnItemQufan.Visible = false;
                    this.btnItemShieldAdmin.Visible = false;
                    break;

               
            }
        }

        string str2wheelconfigFilePath = "MotorSignal.config";//两轮摩托车配置文件名
        string str3wheelconfigFilePath = "3WheelMotorSignal.config";//三轮摩托车配置文件名
        Signal.MotorSignal.MotorSignalSettings settings2;//两轮摩托车settings对象
        Signal.MotorSignal.MotorSignalSettings settings3;//三轮摩托车settings对象
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            settings2 = (Signal.MotorSignal.MotorSignalSettings)Util.ModuleConfig.GetSettings(new Signal.MotorSignal.MotorSignalSettings().GetType(), str2wheelconfigFilePath);
            settings3 = (Signal.MotorSignal.MotorSignalSettings)Util.ModuleConfig.GetSettings(new Signal.MotorSignal.MotorSignalSettings().GetType(), str3wheelconfigFilePath);
        }

        //三轮摩托车考试
        private void btnItem3wheelExam_Click(object sender, EventArgs e)
        {
            FormExam examForm = new FormExam();
            examForm.InitializeExamComponent(ExamType.MOTOR_3, settings3);
            examForm.ShowDialog();
        }

        //两轮摩托车车考试
        private void btnItem2wheelExam_Click(object sender, EventArgs e)
        {
            FormExam examForm = new FormExam();
            examForm.InitializeExamComponent(ExamType.MOTOR_2, settings2);
            examForm.ShowDialog();
        }

        //打印设置
        private void btnItemSetupPrinter_Click(object sender, EventArgs e)
        {
            SetPrint_Form setPrtFrm = new Modules.PrintModule.SetPrint_Form(
            settings2, str2wheelconfigFilePath, settings3, str3wheelconfigFilePath);
            setPrtFrm.ShowDialog();
        }

        //系统设置
        private void btnItemSetup_Click(object sender, EventArgs e)
        {
            Modules.SetupModule.ExamSetup frmsetup = new Modules.SetupModule.ExamSetup(
            settings2,str2wheelconfigFilePath,settings3,str3wheelconfigFilePath);
            frmsetup.ShowDialog();

        }
        //信号检测
        private void btnItemTest_Click(object sender, EventArgs e)
        {
            Modules.SetupModule.GXTest gxTest = new Modules.SetupModule.GXTest(settings2, settings3);
            gxTest.Show();
        }
        //信号屏蔽
        private void btnItemShield_Click(object sender, EventArgs e)
        {
             Modules.SetupModule.GXShield gxShield=new Modules.SetupModule.GXShield(
             settings2, str2wheelconfigFilePath, settings3, str3wheelconfigFilePath);
             gxShield.ShowDialog();

        }
        //管理员型号屏蔽
        private void btnItemShieldAdmin_Click(object sender, EventArgs e)
        {
            Modules.SetupModule.GXShieldAdmin gxShieldAdmin = new Modules.SetupModule.GXShieldAdmin(
            settings2, str2wheelconfigFilePath, settings3, str3wheelconfigFilePath);
            gxShieldAdmin.ShowDialog();
        }

        //信号取反
        private void btnItemQufan_Click(object sender, EventArgs e)
        {
            Modules.SetupModule.GXQufan gxQufan = new Modules.SetupModule.GXQufan(
            settings2, str2wheelconfigFilePath, settings3, str3wheelconfigFilePath);
            gxQufan.ShowDialog();
        }

        //成绩查询
        private void btnItemScore_Click(object sender, EventArgs e)
        {
            //Signal.MotorSignal.MotorSignalSettings settingsTemp = (Signal.MotorSignal.MotorSignalSettings)Util.ModuleConfig.GetSettings(new Signal.MotorSignal.MotorSignalSettings().GetType(), str2wheelconfigFilePath);
            Modules.ScoreModule.FormScore ScoreFom = new Modules.ScoreModule.FormScore(settings2);
            ScoreFom.ShowDialog();
 
        }
    }
}