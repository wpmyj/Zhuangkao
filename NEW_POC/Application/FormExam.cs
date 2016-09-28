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


//���ԣ�
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
                throw new Exception("�������δ����ʼ����");

            switch (examType)
            {
                case ExamType.MOTOR_2:
                    this.Text = "����Ħ�г�����";
                    monitor = new Signal.MotorSignal.MotorMonitor(settings);
                    translator = new Exam.SignalTranslator.MotorSignalTranslator(monitor);
                    statemgr = new Exam.State.XA2WMotorState.MotorStateManager(translator, (Signal.MotorSignal.MotorSignalSettings)settings);
                    break;
                case ExamType.MOTOR_3:
                    this.Text = "����Ħ�г�����";
                    monitor = new Signal.MotorSignal.MotorMonitor(settings);
                    translator = new Exam.SignalTranslator.MotorSignalTranslator(monitor);
                    statemgr = new Exam.State.XA3WMotorState.MotorStateManager(translator, (Signal.MotorSignal.MotorSignalSettings)settings);
                    break;
            }

            this.examStatusDisplayPanel.InitializeExamComponent(statemgr);

            this.motorModelDisplayPanel.InitializeExamComponent(settings, monitor, statemgr);

            //һ��Ҫ��ExamCtrlPanel��������ʼ��
            this.examCtrlPanel.InitializeExamComponent(settings, monitor, translator, statemgr);

            this.localInputPanel.InitializeCandExamCtrlComponent(this.examCtrlPanel,settings);

            //��������
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