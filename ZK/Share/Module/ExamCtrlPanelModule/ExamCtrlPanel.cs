using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Share.Signal;
using Cn.Youdundianzi.Share.Util;

namespace Cn.Youdundianzi.Share.Module.ExamCtrl
{
    public partial class ExamCtrlPanel : UserControl, IExamObserver
    {
        private ISettings settings;
        private ISignalMonitor monitor;
        private ITranslator translator;
        private IStateManager statemgr;

        private bool _IsExaming = false;
        public bool IsExaming
        {
            get { return _IsExaming; }
        }
        
        public ExamCtrlPanel()
        {
            InitializeComponent();
        }

        public void InitializeExamComponent(ISettings set, ISignalMonitor mon, ITranslator trans, IStateManager sm)
        {
            settings = set;
            monitor = mon;
            translator = trans;
            statemgr = sm;

            try
            {
                monitor.HotKeyHandle = this.ParentForm.Handle;
            }
            catch (NullReferenceException nullRefE)
            {
                throw new NullReferenceException("This control has not been put into any form. Please call InitializeExamComponent() after assigning this to a parent form.");
            }

            statemgr.RegExamObserver(this);

            monitor.Start();
        }

        #region IExamObserver Members

        public void Notify(CExam exam)
        {
            string msg=string.Empty;
            if (exam.Passed)
                msg = "考试合格";
            else
                msg = exam.Message.Message;

            if (this.btnXStart.InvokeRequired)
            {
                NotifyDelegateBool doNotify = new NotifyDelegateBool(DoSetBtnEnable);
                this.btnXStart.Invoke(doNotify, false);
            }
            else
                DoSetBtnEnable(false);

            if (exam.Passed)
            {
                if (changeState != null)
                    changeState(this, new StateChangeEventArgs(CtrlPanelState.Pass, msg));
            }
            else
            {
                if (changeState != null)
                    changeState(this, new StateChangeEventArgs(CtrlPanelState.Fail, msg));
            }

            if (this.btnXStart.InvokeRequired)
            {
                NotifyDelegate doNotify = new NotifyDelegate(DoNotify);
                this.btnXStart.Invoke(doNotify, "开始考试");
            }
            else
                DoNotify("开始考试");

            if (this.btnXStart.InvokeRequired)
            {
                NotifyDelegateBool doNotify = new NotifyDelegateBool(DoSetBtnEnable);
                this.btnXStart.Invoke(doNotify, true);
            }
            else
                DoSetBtnEnable(true);
        }

        private delegate void NotifyDelegate(string newText);
        private void DoNotify(string newText)
        {
            this._IsExaming = false;
            this.btnXStart.Text = newText;
        }

        private void DoShowMsgBox(string msg)
        {
            MessageBox.Show(msg);
        }

        private delegate void NotifyDelegateBool(bool val);
        private void DoSetBtnEnable(bool val)
        {
            this.btnXStart.Enabled = val;
        }

        public void Notify(IState state)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void btnXStart_Click(object sender, EventArgs e)
        {
            if (monitor == null || statemgr == null || translator == null || settings == null)
                throw new Exception("考试组件未被初始化！");

            if (_IsExaming)
            {
                statemgr.ResetState();
                _IsExaming = false;
                this.btnXStart.Text = "开始考试";
                if (changeState != null)
                    changeState(this, new StateChangeEventArgs(CtrlPanelState.Stop));
                Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t====STOP EXAM=======================");
            }
            else
            {
                if (checkSignals())
                {
                    startExam();
                }
                else
                {
                    MessageBox.Show("请检查信号！");
                }
            }
        }

        private void startExam()
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t====START EXAM======================");
            statemgr.CurrentState.ChangeState(statemgr.EntryState);
            _IsExaming = true;
            this.btnXStart.Text = "中止考试";
            try
            {
                this.Parent.Parent.Parent.Focus();
            }
            catch(Exception e)
            {
            }
            if (changeState != null)
                changeState(this, new StateChangeEventArgs(CtrlPanelState.Start));
        }

        private bool checkSignals()
        {
            IMonData tempData = monitor.CurrData;
            SignLength sigLen = monitor.SignalLength;
            CSignals ganSig = tempData.GetSignals(SignalType.GAN);
            for (int i = 0; i < sigLen.GAN_LENGTH; i++)
                if (ganSig[i] == 0)
                    return false;
            CSignals xianSig = tempData.GetSignals(SignalType.XIAN);
            for (int i = 0; i < sigLen.XIAN_LENGTH; i++)
                if (xianSig[i] == 0)
                    return false;
            return true;
        }

        private event ExamCtrlPanelEvent changeState;
        virtual public event ExamCtrlPanelEvent OnChangeState
        {
            add
            {
                if (changeState != null)
                {
                    lock (changeState)
                    {
                        changeState += value;
                    }
                }
                else
                {
                    changeState += value;
                }
            }
            remove
            {
                if (changeState != null)
                {
                    lock (changeState)
                    {
                        changeState -= value;
                    }
                }
                else
                {
                    changeState -= value;
                }
            }
        }
    }

    public delegate void ExamCtrlPanelEvent(object sender, StateChangeEventArgs args);
    public class StateChangeEventArgs : EventArgs
    {
        private CtrlPanelState _state;
        public CtrlPanelState State
        {
            get { return _state; }
        }

        private string  _msg;
        public string Msg
        {
            get { return _msg; }
        }


        public StateChangeEventArgs(CtrlPanelState state, string msg)
        {
            this._state = state;
            this._msg = msg;
        }
        public StateChangeEventArgs(CtrlPanelState state)
        {
            this._state = state;
           
        }
    }

    public enum CtrlPanelState
    {
        Start,
        Stop,
        Pass,
        Fail
    }
}