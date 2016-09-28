using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Share.Module.Setup;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Module.ExamCtrl;
using System.Reflection;
using Cn.Youdundianzi.Share.Module.CandidateInfo;
using Cn.Youdundianzi.Share.Module.SignalDisplay;
using Cn.Youdundianzi.Share.Module.ModelDisplay;
using Cn.Youdundianzi.Share.Module.Sound;
using Cn.Youdundianzi.Share.LEDDisplay;
using Cn.Youdundianzi.Share.Module.Video;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.App
{
    public partial class ExamFrm : Form
    {
        public ExamFrm()
        {
            InitializeComponent();
            examCtrl = new ExamCtrlPanel();
        }

        private bool _isExam = false;
        public bool IsExam
        {
            get { return _isExam; }
        }

        private Practice _pracConfig;
        private Exam _examConfig;

        public Practice PracticeConfig
        {
            get { return _pracConfig; }
            set
            {
                _pracConfig = value;
                try
                {
                    _examConfig = (Exam)_pracConfig;
                    _isExam = true;
                }
                catch (InvalidCastException ice)
                {
                    _isExam = false;
                }
            }
        }

        private Exam ExamConfig
        {
            get { return _examConfig; }
        }

        private ISignalMonitor mon;
        private ITranslator translator;
        private IStateManager stateMgr;
        private ExamCtrlPanel examCtrl;
        private IDisplaycomm displaycomm;

        private void ExamFrm_Load(object sender, EventArgs e)
        {
            if (_pracConfig == null)
            {
                MessageBox.Show("ExamConfig����δ��ֵ��");
                this.Close();
                return;
            }

            if (IsExam)
            {
                this.Text = "���Դ���";
            }
            else
            {
                this.Text = "��ϰ����";
            }

            //
            //��ȡ�����ļ���׼����������
            //
            //���ĸ�setting
            SettingPair sp = new SettingPair();

            sp.ImplementClass = AssemblyInfoFactory.GetType(PracticeConfig.Setting.ClsFilePath, PracticeConfig.Setting.ClsName);
            sp.FilePath = PracticeConfig.Setting.ConfigFilePath;

            ISettings setting = new CSetup(sp).Settings;
            CSettings csetting = setting as CSettings;

            //
            //����Monitor��Translator��StateManager��
            //׼�����Ժ�������
            //
            //���ĸ�monitor
            AssemblyInfoPair monInfo = AssemblyInfoFactory.GetAssemblyInfo(PracticeConfig.Monitor.ClsFilePath, PracticeConfig.Monitor.ClsName);
            mon = SignalMonitorFactory.CreateSignalMonitor(monInfo, setting);

            //���ĸ�translator
            AssemblyInfoPair transInfo = AssemblyInfoFactory.GetAssemblyInfo(PracticeConfig.Translator.ClsFilePath, PracticeConfig.Translator.ClsName);
            translator = TranslatorFactory.CreateTranslater(transInfo, mon);

            //���ĸ�statemanager
            AssemblyInfoPair stateMgrInfo = AssemblyInfoFactory.GetAssemblyInfo(PracticeConfig.StateManager.ClsFilePath, PracticeConfig.StateManager.ClsName);
            stateMgr = StateManagerFactory.CreateStateManager(stateMgrInfo, translator, setting);

            //
            //������������ֹͣ�ؼ�
            //ʵ�ֵ���Ͽ���
            examCtrl.Anchor = AnchorStyles.None;
            examCtrl.Dock = DockStyle.Fill;
            this.paneExamCtrl.Controls.Add(examCtrl);

            //ExamCtrl�ؼ������ȱ�add���丸�����У�Ȼ���ٽ���Initialize
            examCtrl.InitializeExamComponent(setting, mon, translator, stateMgr);

            //��ʼ�������ؼ������������ؼ��ࣩ
            SoundCtrl soundCtrl = new SoundCtrl();
            

            //��ʼ����ʾ�ƿؼ�
            SettingPair spDisplay = new SettingPair();
            spDisplay.ImplementClass = AssemblyInfoFactory.GetType(PracticeConfig.LEDConfig.ClsFilePath, PracticeConfig.LEDConfig.ClsName);
            spDisplay.FilePath = PracticeConfig.LEDConfig.ConfigFilePath;

            ISettings dissettings = new CSetup(spDisplay).Settings;
            DisplayConfig dispalySetting = dissettings as DisplayConfig;
            displaycomm = DisplayFactory.CreateDisplay(PracticeConfig.LED.ClsFilePath, PracticeConfig.LED.ClsName, dispalySetting);

            //��ʼ������ͷ
            Camera camera = new Camera(0);
            camera.Anchor = AnchorStyles.None;
            camera.Dock = DockStyle.Fill;
            this.groupPanelVideo.Controls.Add(camera);
            this.Move += new EventHandler(camera.Camera_Move);
            this.FormClosing += new FormClosingEventHandler(camera.Camera_Closing);

            if (IsExam)
            {
                string[] cxs = ExamConfig.LicenseList.Split(new char[] { ';' });
                //��ʼ�������б�
                List<string> cxList = new List<string>(cxs);

                //���ĸ�Candidate Infomation Panel
                CandExamCtrl candExamPane;

                if (ExamConfig.HasQueue)
                {
                    //��ʼ���Ŷ��б�
                    CandidateQuery candQuery = new CandidateQuery();
                    candQuery.Anchor = AnchorStyles.None;
                    candQuery.Dock = DockStyle.Fill;
                    this.paneXQueueList.Controls.Add(candQuery);

                    candExamPane = (CandExamCtrl)CreateModule(ExamConfig.ExamCtrl.ClsFilePath, ExamConfig.ExamCtrl.ClsName, new object[] { candQuery });
                }
                else
                {
                    candExamPane = (CandExamCtrl)CreateModule(ExamConfig.ExamCtrl.ClsFilePath, ExamConfig.ExamCtrl.ClsName, new object[] { });
                }

                candExamPane.Dock = DockStyle.Fill;
                candExamPane.InitializeCandExamCtrlComponent(examCtrl, csetting, cxList);
                this.groupPanelCandInfo.Controls.Add(candExamPane);

                //�����ʾ�ؼ�
                ExamResultPanel resultPanel = new ExamResultPanel();
                resultPanel.Anchor = AnchorStyles.None;
                resultPanel.Dock = DockStyle.Fill;
                candExamPane.ExamResultReady += new ExamResultDelegate(resultPanel.SetResultText);
                this.paneXResult.Controls.Add(resultPanel);

                candExamPane.SoundChange += new MessageDelegate(soundCtrl.PlayText);    //ע��candExamCtrl�������仯�¼��ص�����
                candExamPane.LEDDisplayChange += new MessageDelegate(displaycomm.ShowText); //ע��candExamCtrl����ʾ�Ʊ仯�¼��ص�����
                candExamPane.CameraChannelChange += new IntegerDelegate(camera.SetChannel); //ע��candExamCtrl������ͷ�仯�¼��ص�����
            }

            //��������״̬��ʾ���
            //����Ͽ��Լ�����չ����
            ExamStatusDisplayPanel statePane = new ExamStatusDisplayPanel();
            statePane.Anchor = AnchorStyles.None;
            statePane.InitializeExamComponent(stateMgr);
            this.paneXStatus.Controls.Add(statePane);

            //�����ź���ʾ���
            SignalDisplay signaldisplay = new SignalDisplay(mon);
            signaldisplay.Anchor = AnchorStyles.None;
            signaldisplay.Dock = DockStyle.Fill;
            this.paneXSignalDisp.Controls.Add(signaldisplay);

            //���ĸ�DisplayPanel
            BaseModelDisplayPanel modelDisplayPane = (BaseModelDisplayPanel)CreateModule(PracticeConfig.ModelDisplay.ClsFilePath, PracticeConfig.ModelDisplay.ClsName, new object[] { });
            modelDisplayPane.Anchor = AnchorStyles.None;
            modelDisplayPane.InitializeExamComponent(csetting, mon, stateMgr);
            this.groupPanelModelDisp.Controls.Add(modelDisplayPane);
        }

        private static object CreateModule(string assName, string className, params object[] param)
        {
            Assembly ass = Assembly.LoadFrom(assName);
            Type t = ass.GetType(className);
            object obj = Activator.CreateInstance(t, param);
            return obj;
        }

        private void ExamFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (examCtrl.IsExaming)
            {
                if (this.IsExam)
                {
                    MessageBox.Show("���ڿ��ԣ������˳���");
                }
                else
                {
                    MessageBox.Show("������ϰ�������˳���");
                }
                e.Cancel = true;
                return;
            }
            if (mon != null)
            {
                mon.Close();
            }
            if (displaycomm != null)
            {
                displaycomm.Close();
            }
        }

        private void btnXExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExamFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case 'l':
                    if (this.stateMgr != null)
                    {
                        try
                        {
                            ((IExamEventHandler)this.stateMgr.CurrentState).OnFailure(new ExamResultMsg(ResultType.LXC));
                        }
                        catch
                        {}
                    }
                    break;
            }
        }

        private void ExamFrm_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.L:
            //        if (this.stateMgr != null)
            //        {
            //            try
            //            {
            //                ((IExamEventHandler)this.stateMgr.CurrentState).OnFailure(new ExamResultMsg(ResultType.LXC));
            //            }
            //            catch
            //            { }
            //        }
            //        break;
            //}
        }
    }
}