using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    abstract public class CState : IZKEventHandler ,IState
    {
        protected ZKSignalTranslator translator;
        protected StateManager stateManager;

        public CState(ZKSignalTranslator st,StateManager sm)
        {
            this.translator = st;
            this.stateManager = sm;
            this._name = string.Empty;
            this.OnFailure = this.FailureHandler;
        }

        #region ISignalEventHandler Members

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
            Logger.Log(_name + "\tTime Out " + e.TimeOut);
        }

        #endregion

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
        }

        virtual public void ChangeState(IState state)
        {
            if (state != this)
            {
                try
                {
                    translator.AbortStateTimeOut();
                }
                catch (ThreadAbortException e)
                {
                    Thread.ResetAbort();
                }
                stateManager.CurrentState = state;
                Logger.Log("Change to " + stateManager.CurrentState.Name);
            }
        }

        protected string _name;
        public string Name
        {
            get { return _name; }
        }
        
        private FailureHandleDelegate failureHandler;
        public FailureHandleDelegate OnFailure
        {
            get { return failureHandler; }
            set { failureHandler = value; }
        }
        virtual public void FailureHandler(IFailureMessage imsg)
        {
            ZKFailureMsg msg = (ZKFailureMsg)imsg;
            Logger.Log("Failure!");
        }

        #region IBaseEventHandler Members

        public void OnSet(object sender, SignalEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void OnUnSet(object sender, SignalEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
