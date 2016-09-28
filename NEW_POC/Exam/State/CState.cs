using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Exam.SignalTranslator;

namespace Exam.State
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

                Logger.Log("Change to " + stateManager.CurrentState.Name);
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

        protected string _displayname = "Î´ÃüÃû";
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

        #region IExamEventHandler Members


        virtual public void OnFailure(IResultMessage msg)
        {
            Logger.Log("Failure! " + msg.Message);
            AbortStateTimeOut();
            AbortExamTimeOut();
            stateManager.ResetState();
            ArrayList obobjs = stateManager.ExamObservers;
            Exam exmMsg = new Exam(false, msg);
            foreach (IExamObserver obobj in obobjs)
            {
                obobj.Notify(exmMsg);
            }
            //stateManager.ResetState();
        }

        virtual public void OnSuccess(IResultMessage msg)
        {
            Logger.Log("Success! " + msg.Message);
            AbortStateTimeOut();
            AbortExamTimeOut();
            stateManager.ResetState();
            ArrayList obobjs = stateManager.ExamObservers;
            Exam exmMsg = new Exam(true, msg);
            foreach (IExamObserver obobj in obobjs)
            {
                obobj.Notify(exmMsg);
            }
            //stateManager.ResetState();
        }

        virtual public void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            Logger.Log(_name + "\tBlock Xian " + (e.Number + 1));
        }

        virtual public void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            Logger.Log(_name + "\tLeave Xian " + (e.Number + 1));
        }

        virtual public void OnHitGanEvent(object sender, SignalEventArgs e)
        {
            Logger.Log(_name + "\tHit Gan " + (e.Number + 1));
        }

        virtual public void OnResetGanEvent(object sender, SignalEventArgs e)
        {
            Logger.Log(_name + "\tReset Gan " + (e.Number + 1));
        }

        virtual public void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            Logger.Log(_name + "\tCar Move Forward");
        }

        virtual public void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            Logger.Log(_name + "\tCar Move Backward");
        }

        virtual public void OnCarStopEvent(object sender, EventArgs e)
        {
            Logger.Log(_name + "\tCar Stop");
        }

        virtual public void OnCarFlameoutEvent(object sender, EventArgs e)
        {
            Logger.Log(_name + "\tCar Flameout");
        }

        virtual public void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            Logger.Log(_name + "\tState Time Out " + e.TimeOut);
        }

        virtual public void OnExamTimeOutEvent(object seder, TimeOutEventArgs e)
        {
            Logger.Log("\tExam Time Out at " + _name + " " + e.TimeOut);
        }

        #endregion
    }
}
