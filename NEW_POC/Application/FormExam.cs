using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Exam;
using Util;
using Shared;
using Signal;
using Modules.ExamCtrlPanelModule;


//测试１
namespace App
{
    public partial class FormExam : Form
    {
        private CSettings settings;
        private IMonitor monitor;
        private ITranslater translator;
        private StateManager statemgr;

        private ExamType examType;
        private IMonObserver simForm;

        Modules.SoundModule.SoundCtrl soundCtrl;

        public FormExam()
        {
            InitializeComponent();
        }

        public void InitializeExamComponent(ExamType type, CSettings set)
        {
            examType = type;
            this.settings = set;
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            if (examType == ExamType.NULL)
                throw new Exception("考试组件未被初始化！");

            switch (examType)
            {
                case ExamType.MOTOR_2:
                    this.Text = "两轮摩托车考试";
                    monitor = new Signal.MotorSignal.MotorMonitor(settings);
                    translator = new Exam.SignalTranslator.MotorSignalTranslator(monitor);
                    statemgr = new Exam.State.XA2WMotorState.MotorStateManager(translator, (Signal.MotorSignal.MotorSignalSettings)settings);
                    break;
                case ExamType.MOTOR_3:
                    this.Text = "三轮摩托车考试";
                    monitor = new Signal.MotorSignal.MotorMonitor(settings);
                    translator = new Exam.SignalTranslator.MotorSignalTranslator(monitor);
                    statemgr = new Exam.State.XA3WMotorState.MotorStateManager(translator, (Signal.MotorSignal.MotorSignalSettings)settings);
                    break;
            }

            this.examStatusDisplayPanel.InitializeExamComponent(statemgr);

            this.motorModelDisplayPanel.InitializeExamComponent(settings, monitor, statemgr);

            //一定要将ExamCtrlPanel对象最后初始化
            this.examCtrlPanel.InitializeExamComponent(settings, monitor, translator, statemgr);

            this.localInputPanel.InitializeCandExamCtrlComponent(this.examCtrlPanel,settings);

            //考车类型
            localInputPanel.CarType = examType;
            this.localInputPanel.SetKSCXComBox();
           
            soundCtrl = new Modules.SoundModule.SoundCtrl(this.localInputPanel);
    }

        private void FormExam_FormClosing(object sender, FormClosingEventArgs e)
        {
            monitor.Close();
        }
    }
}