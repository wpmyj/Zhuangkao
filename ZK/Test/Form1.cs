using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Util.Motor;
using Cn.Youdundianzi.Share.Util.Car;
using Cn.Youdundianzi.Share.Util.Tractor;
using Cn.Youdundianzi.Share.Module.Setup;
using Cn.Youdundianzi.Share.Module.ExamCtrl;
using Cn.Youdundianzi.Share.Module.CandidateInfo;
using Cn.Youdundianzi.Share.Module.ModelDisplay;
using Cn.Youdundianzi.Share.Module.Sound;
using Cn.Youdundianzi.Share.Module.SignalDisplay;
using Cn.Youdundianzi.Share.Module.Video;
using Cn.Youdundianzi.Core.Exam;
using System.Reflection;
using Cn.Youdundianzi.Share.LEDDisplay;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**
            ISettings tempSet = new CarSignalSettings();
            ModuleConfig.SaveSettings(tempSet, "test.config");
            Application.Exit();
             * */

            /**
            SettingPair tsp = new SettingPair();
            tsp.ImplementClass = new CarSignalSettings().GetType();
            tsp.FilePath = "test.config";
            CSettings csetting = new CSetup(tsp).Settings as CSettings;
             * */
            
            SettingPair sp1=new SettingPair ();
            sp1.ImplementClass = new CarSignalSettings().GetType();
            sp1.FilePath = "CarSignal.config";

            SettingPair sp2 = new SettingPair();
            sp2.ImplementClass = new MotorSignalSettings().GetType();
            sp2.FilePath = "MotorSignal.config";
            
            ExamSetup setupFrm = new ExamSetup();
            Dictionary<string, SettingPair> tempSettings = new Dictionary<string, SettingPair>();
            tempSettings.Add("汽车设置", sp1);
            tempSettings.Add("Test 2", sp2);
            setupFrm.ConfigTable = tempSettings;
            setupFrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SettingPair sp1=new SettingPair ();
            sp1.ImplementClass = new MotorSignalSettings().GetType();
            sp1.FilePath="3WheelMotorSignal.config";

            SettingPair sp2 = new SettingPair();
            sp2.ImplementClass = new MotorSignalSettings().GetType();
            sp2.FilePath = "MotorSignal.config";

            //GXSetup setupFrm = new GXSetup(SetupDialogType.ADMIN_PB);
            //GXSetup setupFrm = new GXSetup(SetupDialogType.PB);
            GXSetup setupFrm = new GXSetup(SetupDialogType.QF);
            Dictionary<string, SettingPair> tempSettings = new Dictionary<string, SettingPair>();
            tempSettings.Add("三轮取反", sp1);
            tempSettings.Add("二轮取反", sp2);
            setupFrm.ConfigTable = tempSettings;

            setupFrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SettingPair sp1 = new SettingPair();
            sp1.ImplementClass = new MotorSignalSettings().GetType();
            sp1.FilePath = "3WheelMotorSignal.config";

            SettingPair sp2 = new SettingPair();
            sp2.ImplementClass = new MotorSignalSettings().GetType();
            sp2.FilePath = "MotorSignal.config";

            Dictionary<string, SettingPair> tempSettings = new Dictionary<string, SettingPair>();
            tempSettings.Add("三轮", sp1);
            tempSettings.Add("二轮", sp2);
            AssemblyInfoPair monInfo = AssemblyInfoFactory.GetAssemblyInfo(typeof(Cn.Youdundianzi.Share.Signal.Motor.MotorMonitor));
            GXTest testFrm = new GXTest(tempSettings, monInfo);

            testFrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //
            //读取设置文件，准备环境设置
            //
            //用哪个setting
            SettingPair sp1 = new SettingPair();
            //sp1.ImplementClass = new MotorSignalSettings().GetType();
            sp1.ImplementClass = new TractorSignalSettings().GetType();
            sp1.FilePath = "TractorSignal.config";

            ISettings setting = new CSetup(sp1).Settings;
            CSettings csetting = setting as CSettings;

            //
            //创建Monitor，Translator，StateManager。
            //准备考试核心引擎
            //
            //用哪个monitor
            //AssemblyInfoPair monInfo = AssemblyInfoFactory.GetAssemblyInfo(typeof(Cn.Youdundianzi.Share.Signal.Motor.MotorMonitor));
            //AssemblyInfoPair monInfo = AssemblyInfoFactory.GetAssemblyInfo(typeof(Cn.Youdundianzi.Share.Signal.Car.OldCarMonitor));
            AssemblyInfoPair monInfo = AssemblyInfoFactory.GetAssemblyInfo(typeof(Cn.Youdundianzi.Share.Signal.Car.TractorMonitor));
            ISignalMonitor mon = SignalMonitorFactory.CreateSignalMonitor(monInfo, setting);

            //用哪个translator
            //AssemblyInfoPair transInfo = AssemblyInfoFactory.GetAssemblyInfo(typeof(Cn.Youdundianzi.Exam.MotorSignalTranslator));
            AssemblyInfoPair transInfo = AssemblyInfoFactory.GetAssemblyInfo(typeof(Cn.Youdundianzi.Exam.CarSignalTranslator));
            ITranslator translator = TranslatorFactory.CreateTranslater(transInfo, mon);

            //用哪个statemanager
            //AssemblyInfoPair stateMgrInfo = AssemblyInfoFactory.GetAssemblyInfo(typeof(Cn.Youdundianzi.Exam.State.MotorState.MotorStateManager));
            //AssemblyInfoPair stateMgrInfo = AssemblyInfoFactory.GetAssemblyInfo(typeof(Cn.Youdundianzi.Exam.State.PureLineCarState.CarStateManager));
            AssemblyInfoPair stateMgrInfo = AssemblyInfoFactory.GetAssemblyInfo(typeof(Cn.Youdundianzi.Exam.State.Tractor.TractorStateManager));
            IStateManager stateMgr = StateManagerFactory.CreateStateManager(stateMgrInfo, translator, setting);

            //
            //创建考试启动停止控件
            //实现单会合考试
            ExamCtrlPanel examCtrl = new ExamCtrlPanel();
            examCtrl.Location = new System.Drawing.Point(0, 0);
            this.ctrlPanel.Controls.Add(examCtrl);

            //ExamCtrl控件必须先被add到其父窗口中，然后再进行Initialize
            examCtrl.InitializeExamComponent(setting, mon, translator, stateMgr);

            //创建考试状态显示面板
            //单会合考试级别扩展功能
            ExamStatusDisplayPanel statePane = new ExamStatusDisplayPanel();
            statePane.Location = new System.Drawing.Point(0, 100);
            statePane.BorderStyle = BorderStyle.Fixed3D;
            statePane.InitializeExamComponent(stateMgr);
            this.ctrlPanel.Controls.Add(statePane);

            //创建信号显示面板
            SignalDisplay signaldisplay = new SignalDisplay(mon);
            signaldisplay.Location = new System.Drawing.Point(0, 20);
            //sd.BorderStyle = BorderStyle.Fixed3D;
            this.ctrlPanel.Controls.Add(signaldisplay);

            
            //用哪个DisplayPanel
            //BaseModelDisplayPanel modelDisplayPane = new Cn.Youdundianzi.Share.Module.ModelDisplay.Car.CarModelDisplayPanel();
            BaseModelDisplayPanel modelDisplayPane = new Cn.Youdundianzi.Share.Module.ModelDisplay.Car.TractorModelDisplayPanel();
            modelDisplayPane.Location = new System.Drawing.Point(200, 0);
            modelDisplayPane.InitializeExamComponent(csetting, mon, stateMgr);
            this.ctrlPanel.Controls.Add(modelDisplayPane);
            
            /**
            //初始化车型列表
            List<string> cxList = new List<string>(2);
            cxList.Add("A");
            cxList.Add("B");

            //初始化排队列表
            CandidateQuery candQuery = new CandidateQuery();
            candQuery.Location = new System.Drawing.Point(550, 20);
            //sd.BorderStyle = BorderStyle.Fixed3D;
            this.ctrlPanel.Controls.Add(candQuery);

            //用哪个Candidate Infomation Panel
            CandExamCtrl candExamPane = new Cn.Youdundianzi.Share.Module.CandidateInfo.LocalInputPanel();
            candExamPane.Location = new System.Drawing.Point(0, 150);
            candExamPane.InitializeCandExamCtrlComponent(examCtrl, csetting, cxList);
            this.ctrlPanel.Controls.Add(candExamPane);

            //初始化声音控件（基础声音控件类）
            SoundCtrl soundCtrl = new SoundCtrl();
            candExamPane.SoundChange += new MessageDelegate(soundCtrl.PlayText);    //注册candExamCtrl的声音变化事件回调函数

            //初始化显示牌控件
            //------------------------------------------------------------------------------
            string LEDAssemblyFilePath = Application.StartupPath + "\\LEDDisplay.dll";

            SettingPair spDisplay = new SettingPair();
            spDisplay.ImplementClass = AssemblyInfoFactory.GetType(LEDAssemblyFilePath, csetting.DisplayPaneConfig.DisplayConfigClass);
            spDisplay.FilePath = csetting.DisplayPaneConfig.DisplayConfigFilePath;

            ISettings dissettings = new CSetup(spDisplay).Settings;
            DisplayConfig dispalySetting = dissettings as DisplayConfig;
            IDisplaycomm displaycomm = DisplayFactory.CreateDisplay(LEDAssemblyFilePath, csetting.DisplayPaneConfig.DisplayCommClass, dispalySetting);
            candExamPane.LEDDisplayChange += new MessageDelegate(displaycomm.ShowText); //注册candExamCtrl的显示牌变化事件回调函数


            //初始化摄像头
            Camera camera = new Camera(0);
            camera.Location = new System.Drawing.Point(200, 400);
            camera.Size = new Size(400, 300);
            camera.BorderStyle = BorderStyle.Fixed3D;
            this.ctrlPanel.Controls.Add(camera);
            candExamPane.CameraChannelChange += new IntegerDelegate(camera.SetChannel); //注册candExamCtrl的摄像头变化事件回调函数

            //结果显示控件
            ExamResultPanel resultPanel = new ExamResultPanel();
            resultPanel.Location = new System.Drawing.Point(0, 400);
            resultPanel.Size = new Size(210, 110);
            resultPanel.BorderStyle = BorderStyle.FixedSingle;
            candExamPane.ExamResultReady += new ExamResultDelegate(resultPanel.SetResultText);
            **/
        }
    }
}