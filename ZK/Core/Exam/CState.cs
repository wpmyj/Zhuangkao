using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Core.Exam
{
    abstract public class CState : IExamEventHandler, IState
    {
        protected BaseExamTranslator translator;
        protected StateManager stateManager;

        public CState(BaseExamTranslator st, StateManager sm)
        {
            this.translator = st;
            this.stateManager = sm;
            this._name = string.Empty;
            this._entryTime = new DateTime(0);
        }


        public void RegEventHandle()
        {
            this.translator.OnBlockXianEvent += new SignalEvent(this.OnBlockXianEvent);
            this.translator.OnLeaveXianEvent += new SignalEvent(this.OnLeaveXianEvent);
            this.translator.OnHitGanEvent += new SignalEvent(this.OnHitGanEvent);
            this.translator.OnResetGanEvent += new SignalEvent(this.OnResetGanEvent);
            this.translator.OnCarFlameoutEvent += new EventHandler(this.OnCarFlameoutEvent);
            this.translator.OnCarMoveBackEvent += new EventHandler(this.OnCarMoveBackEvent);
            this.translator.OnCarMoveForwardEvent += new EventHandler(this.OnCarMoveForwardEvent);
            this.translator.OnCarStopEvent += new EventHandler(this.OnCarStopEvent);
            this.translator.OnStateTimeOutEvent += new TimeOutEvent(this.OnStateTimeOutEvent);
            this.translator.OnExamTimeOut += new TimeOutEvent(this.OnExamTimeOutEvent);
        }

        public void UnRegEventHandle()
        {
            this.translator.OnBlockXianEvent -= new SignalEvent(this.OnBlockXianEvent);
            this.translator.OnLeaveXianEvent -= new SignalEvent(this.OnLeaveXianEvent);
            this.translator.OnHitGanEvent -= new SignalEvent(this.OnHitGanEvent);
            this.translator.OnResetGanEvent -= new SignalEvent(this.OnResetGanEvent);
            this.translator.OnCarFlameoutEvent -= new EventHandler(this.OnCarFlameoutEvent);
            this.translator.OnCarMoveBackEvent -= new EventHandler(this.OnCarMoveBackEvent);
            this.translator.OnCarMoveForwardEvent -= new EventHandler(this.OnCarMoveForwardEvent);
            this.translator.OnCarStopEvent -= new EventHandler(this.OnCarStopEvent);
            this.translator.OnStateTimeOutEvent -= new TimeOutEvent(this.OnStateTimeOutEvent);
            this.translator.OnExamTimeOut -= new TimeOutEvent(this.OnExamTimeOutEvent);
        }

        virtual public void ChangeState(IState state)
        {
            if (state != this)
            {
                AbortStateTimeOut();
                stateManager.CurrentState = state;

                foreach (IExamObserver obobj in stateManager.ExamObservers)
                {
                    obobj.Notify(stateManager.CurrentState);
                }

                OnStateChange(translator.CurrentData);
                Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.CHANGE_STATE_PREFIX + stateManager.CurrentState.Name);
            }
        }

        virtual public void ChangeState(IState state, int timeout)
        {
            if (state != this)
            {
                ChangeState(state);
                translator.StartStateTimeOut(timeout);
                Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.START_STATE_TIME_OUT_THREAD_PREFIX + timeout.ToString());
            }
        }

        public void AbortStateTimeOut()
        {
            try
            {
                translator.AbortStateTimeOut();
            }
            catch (ThreadAbortException e)
            {
                Thread.ResetAbort();
            }
        }

        public void AbortExamTimeOut()
        {
            try
            {
                translator.AbortExamTimeOut();
            }
            catch (ThreadAbortException e)
            {
                Thread.ResetAbort();
            }
        }

        protected string _name;
        public string Name
        {
            get { return _name; }
        }

        protected string _displayname = "未命名";
        virtual public string DisplayName
        {
            get { return _displayname; }
        }

        protected DateTime _entryTime;
        public DateTime EntryTime
        {
            get { return _entryTime; }
            set { _entryTime = value; }
        }

        protected IMonData CurrentMonData
        {
            get { return translator.CurrentData; }
        }

        virtual public void OnStateChange(IMonData mondata)
        {
        }

        #region IExamEventHandler Members


        virtual public void OnFailure(IResultMessage msg)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.FAILURE_PREFIX + msg.Message);
            AbortStateTimeOut();
            AbortExamTimeOut();
            stateManager.ResetState();
            ArrayList obobjs = stateManager.ExamObservers;
            CExam exmMsg = new CExam(false, msg);
            foreach (IExamObserver obobj in obobjs)
            {
                obobj.Notify(exmMsg);
            }
            //stateManager.ResetState();
        }

        virtual public void OnSuccess(IResultMessage msg)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SUCCESS_PREFIX + msg.Message);
            AbortStateTimeOut();
            AbortExamTimeOut();
            stateManager.ResetState();
            ArrayList obobjs = stateManager.ExamObservers;
            CExam exmMsg = new CExam(true, msg);
            foreach (IExamObserver obobj in obobjs)
            {
                obobj.Notify(exmMsg);
            }
            //stateManager.ResetState();
        }

        virtual public void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SIGNAL_PREFIX + _name + "\t压线 " + (e.Number + 1));
        }

        virtual public void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SIGNAL_PREFIX + _name + "\t离线 " + (e.Number + 1));
        }

        virtual public void OnHitGanEvent(object sender, SignalEventArgs e)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SIGNAL_PREFIX + _name + "\t碰杆 " + (e.Number + 1));
        }

        virtual public void OnResetGanEvent(object sender, SignalEventArgs e)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SIGNAL_PREFIX + _name + "\t离杆 " + (e.Number + 1));
        }

        virtual public void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SIGNAL_PREFIX + _name + "\t前进");
        }

        virtual public void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SIGNAL_PREFIX + _name + "\t后退");
        }

        virtual public void OnCarStopEvent(object sender, EventArgs e)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SIGNAL_PREFIX + _name + "\t停车");
        }

        virtual public void OnCarFlameoutEvent(object sender, EventArgs e)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SIGNAL_PREFIX + _name + "\t熄火");
        }

        virtual public void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SIGNAL_PREFIX + _name + "\t状态定时结束 " + e.TimeOut);
        }

        virtual public void OnExamTimeOutEvent(object seder, TimeOutEventArgs e)
        {
            Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.SIGNAL_PREFIX + _name + "\t考试定时结束 " + _name + " " + e.TimeOut);
        }

        #endregion
    }
}
