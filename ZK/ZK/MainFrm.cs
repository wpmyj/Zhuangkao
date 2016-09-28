using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Cn.Youdundianzi.Core.Util;
using System.IO;
using Cn.Youdundianzi.Share.Module.Setup;
using DevComponents.DotNetBar;
using Cn.Youdundianzi.Share.Module.Print;
using Cn.Youdundianzi.Share.Module.Sound;
using Cn.Youdundianzi.Share.Module.Login;

namespace Cn.Youdundianzi.App
{
    public partial class MainFrm : Form
    {
        private AppConfig appconfig;

        public MainFrm()
        {
            InitializeComponent();
        }

        private class ExamButtonItem : ButtonItem
        {
            public ExamButtonItem()
                : base()
            {
                this.Click += new EventHandler(OnExamButtonItemClick);
            }

            private Exam _exam;
            public Exam ExamConfig
            {
                set { _exam = value; }
                get { return _exam; }
            }

            private void OnExamButtonItemClick(object sender, EventArgs e)
            {
                ExamFrm examFrm = new ExamFrm();
                examFrm.PracticeConfig = this.ExamConfig;
                examFrm.ShowDialog();
            }
        }

        private class PracticeButtonItem : ButtonItem
        {
            public PracticeButtonItem()
                : base()
            {
                this.Click += new EventHandler(OnPracticeButtonItemClick);
            }

            private Practice _exam;
            public Practice PracticeConfig
            {
                set { _exam = value; }
                get { return _exam; }
            }

            private void OnPracticeButtonItemClick(object sender, EventArgs e)
            {
                ExamFrm examFrm = new ExamFrm();
                examFrm.PracticeConfig = this.PracticeConfig;
                examFrm.ShowDialog();
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
            try
            {
                FileStream fs = new FileStream(AppConfig.APPCONF_FILE_NAME, FileMode.Open);
                TextReader reader = new StreamReader(fs, Encoding.Unicode);
                appconfig = (AppConfig)serializer.Deserialize(reader);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法找到" + AppConfig.APPCONF_FILE_NAME + "，程序关闭。");
                this.Close();
                Application.Exit();
            }

            this.labelMainTitle.Text = appconfig.MainTitle;
            this.Text = appconfig.MainTitle;
            this.btnItemIntro.Text = appconfig.Intro.Title;
            this.sideBarPanelItemExams.Text = appconfig.Exams.Title;
            this.sideBarPanelItemPractices.Text = appconfig.Practices.Title;
            this.sideBarPanelItemOptions.Text = appconfig.Options.Title;

            //初始化考试列表
            if (appconfig.Exams.Exam != null)
            {
                foreach (Exam exam in appconfig.Exams.Exam)
                {
                    ExamButtonItem btnItemExam = new ExamButtonItem();
                    btnItemExam.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
                    btnItemExam.ImageIndex = 1;
                    btnItemExam.ImagePaddingHorizontal = 8;
                    btnItemExam.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
                    btnItemExam.Name = "btnItemExam";
                    btnItemExam.Text = exam.Title;

                    btnItemExam.ExamConfig = exam;

                    this.sideBarPanelItemExams.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] { btnItemExam });
                }
            }

            //初始化练习列表
            if (appconfig.Practices.Practice != null)
            {
                foreach (Practice prac in appconfig.Practices.Practice)
                {
                    PracticeButtonItem btnItemExam = new PracticeButtonItem();
                    btnItemExam.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
                    btnItemExam.ImageIndex = 1;
                    btnItemExam.ImagePaddingHorizontal = 8;
                    btnItemExam.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
                    btnItemExam.Name = "btnItemExam";
                    btnItemExam.Text = prac.Title;

                    btnItemExam.PracticeConfig = prac;

                    this.sideBarPanelItemPractices.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] { btnItemExam });
                }
            }

            switch (CMyGlobal.G_Login_UserCls)
            {
                case UserClass.ADMIN:
                    sideBarPanelItemExams.Visible = false;
                    sideBarPanelItemPractices.Visible = false;
                    break;
                case UserClass.EXAM:
                    sideBarPanelItemOptions.Visible = false;
                    break;
                case UserClass.PRACTICE:
                    sideBarPanelItemExams.Visible = false;
                    sideBarPanelItemOptions.Visible = false;
                    break;
                case UserClass.NONE:
                    sideBarPanelItemExams.Visible = false;
                    sideBarPanelItemPractices.Visible = false;
                    sideBarPanelItemOptions.Visible = false;
                    break;
            }
        }

        private void btnItemIntro_Click(object sender, EventArgs e)
        {
            IntroFrm frm = new IntroFrm();
            frm.IntroFilePath = this.appconfig.Intro.IntroFilePath;
            frm.ShowDialog();
        }

        private void btnItemParam_Click(object sender, EventArgs e)
        {
            Dictionary<string, SettingPair> tempSettings = GetOptionConfigTable();

            if (tempSettings.Count == 0)
                return;

            ExamSetup setupFrm = new ExamSetup();
            
            setupFrm.ConfigTable = tempSettings;
            setupFrm.ShowDialog();
        }

        private void btnItemSigQFSetup_Click(object sender, EventArgs e)
        {
            ShowGXSetup(SetupDialogType.QF);
        }

        private void btnItemSigPBSetup_Click(object sender, EventArgs e)
        {
            ShowGXSetup(SetupDialogType.PB);
        }

        private void btnItemSigAdminPBSetup_Click(object sender, EventArgs e)
        {
            ShowGXSetup(SetupDialogType.ADMIN_PB);
        }

        private void btnItemSigTest_Click(object sender, EventArgs e)
        {
            Dictionary<string, SettingPair> tempSettings = GetOptionConfigTable();

            if (tempSettings.Count == 0)
                return;

            AssemblyInfoPair monInfo = AssemblyInfoFactory.GetAssemblyInfo(appconfig.Options.Monitor.ClsFilePath, appconfig.Options.Monitor.ClsName);
            
            GXTest testFrm = new GXTest(tempSettings, monInfo);

            testFrm.ShowDialog();
        }

        private void btnItemVoice_Click(object sender, EventArgs e)
        {
            Dictionary<string, SettingPair> tempSettings = GetOptionConfigTable();
            if (tempSettings.Count == 0)
                return;

            Sound_Test_Form soundFrm = new Sound_Test_Form();
            soundFrm.ConfigTable = tempSettings;
            soundFrm.ShowDialog();
        }

        private void btnItemPrinter_Click(object sender, EventArgs e)
        {
            Dictionary<string, SettingPair> tempSettings = GetOptionConfigTable();
            if (tempSettings.Count == 0)
                return;

            SetPrint_Form printFrm = new SetPrint_Form();
            printFrm.ConfigTable = tempSettings;

            printFrm.ShowDialog();
        }

        private void ShowGXSetup(SetupDialogType type)
        {
            Dictionary<string, SettingPair> tempSettings = GetOptionConfigTable();

            if (tempSettings.Count == 0)
                return;

            GXSetup setupFrm = new GXSetup(type);

            setupFrm.ConfigTable = tempSettings;
            setupFrm.ShowDialog();
        }

        private Dictionary<string, SettingPair> GetOptionConfigTable()
        {
            Dictionary<string, SettingPair> tempSettings = new Dictionary<string, SettingPair>();

            foreach (ClsInfo clsinfo in appconfig.Options.Option)
            {
                Type t = AssemblyInfoFactory.GetType(clsinfo.ClsFilePath, clsinfo.ClsName);

                SettingPair sp = new SettingPair();

                sp.ImplementClass = t;
                sp.FilePath = clsinfo.ConfigFilePath;

                tempSettings.Add(clsinfo.Name, sp);
            }
            return tempSettings;
        }
    }
}