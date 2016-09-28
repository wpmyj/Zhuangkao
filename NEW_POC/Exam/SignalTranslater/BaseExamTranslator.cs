using System;
using System.Collections.Generic;
using System.Text;
using Signal;
using Shared;
using System.Threading;

namespace Exam
{
    public abstract class BaseExamTranslator : ITranslater
    {
        protected CMonData oldData;
        protected IMonitor monitor;

        private Thread _examTOThread;
        private int _examTimeout = 0;

        private Thread _stateTOThread;
        private int _stateTimeout = 0;

        public BaseExamTranslator(IMonitor monitor)
        {
            oldData = new CMonData(monitor.SignalLength);
            this.monitor = monitor;
            this.monitor.RegMonitor(this);
            _examTOThread = new Thread(new ThreadStart(ExamTimeOut));
            _stateTOThread = new Thread(new ThreadStart(StateTimeOut));
        }

        #region IMonObserver Members

        abstract public void Notify(Signal.CMonData data);

        #endregion


        private void ExamTimeOut()
        {
            if (_examTimeout != 0)
            {
                Thread.Sleep(_examTimeout * 1000);
            }
            if (_examTOThread.ThreadState == ThreadState.Running)
            {
                TimeOutEvent handler = examTimeOutEvent;
                handler(this, new TimeOutEventArgs(_examTimeout));
            }
        }

        private void StateTimeOut()
        {
            try
            {
                if (_stateTimeout != 0)
                {
                    Thread.Sleep(_stateTimeout);
                }
                if (Thread.CurrentThread.ThreadState == ThreadState.Running)
                {
                    TimeOutEvent handler = stateTimeOutEvent;
                    handler(this, new TimeOutEventArgs(_stateTimeout));
                }
            }
            catch (ThreadAbortException e)
            {
                Thread.ResetAbort();
            }
        }

        virtual public void StartExamTimeOut(int timeout)
        {
            _examTimeout = timeout;
            StartTimeOut(ref _examTOThread, new ThreadStart(ExamTimeOut));
        }

        virtual public void StartStateTimeOut(int timeout)
        {
            _stateTimeout = timeout;
            StartTimeOut(ref _stateTOThread, new ThreadStart(StateTimeOut));
        }

        virtual public void AbortExamTimeOut()
        {
            AbortTimeOut(ref _examTOThread);
        }

        virtual public void AbortStateTimeOut()
        {
            AbortTimeOut(ref _stateTOThread);
        }

        private void StartTimeOut(ref Thread timeoutThread, ThreadStart timeoutThreadStart)
        {
            if (timeoutThread != null)
            {
                try
                {
                    timeoutThread.Abort();
                }
                catch
                { }
            }
            timeoutThread = new Thread(timeoutThreadStart);
            timeoutThread.Start();
        }

        private void AbortTimeOut(ref Thread t)
        {
            if (t != null)
                try
                {
                    t.Abort();
                    t.Join();
                }
                catch
                { }
        }

        event SignalEvent blockXianEvent;
        protected SignalEvent BlockXianEvent
        {
            get { return blockXianEvent; }
        }
        virtual public event SignalEvent OnBlockXianEvent
        {
            add
            {
                if (blockXianEvent != null)
                {
                    lock (blockXianEvent)
                    {
                        blockXianEvent += value;
                    }
                }
                else
                {
                    blockXianEvent += value;
                }
            }
            remove
            {
                if (blockXianEvent != null)
                {
                    lock (blockXianEvent)
                    {
                        blockXianEvent -= value;
                    }
                }
                else
                {
                    blockXianEvent -= value;
                }
            }
        }

        event SignalEvent leaveXianEvent;
        protected SignalEvent LeaveXianEvent
        {
            get { return leaveXianEvent; }
        }
        virtual public event SignalEvent OnLeaveXianEvent
        {
            add
            {
                if (leaveXianEvent != null)
                {
                    lock (leaveXianEvent)
                    {
                        leaveXianEvent += value;
                    }
                }
                else
                {
                    leaveXianEvent += value;
                }
            }
            remove
            {
                if (leaveXianEvent != null)
                {
                    lock (leaveXianEvent)
                    {
                        leaveXianEvent -= value;
                    }
                }
                else
                {
                    leaveXianEvent -= value;
                }
            }
        }

        event SignalEvent hitGanEvent;
        protected SignalEvent HitGanEvent
        {
            get { return hitGanEvent; }
        }
        virtual public event SignalEvent OnHitGanEvent
        {
            add
            {
                if (hitGanEvent != null)
                {
                    lock (hitGanEvent)
                    {
                        hitGanEvent += value;
                    }
                }
                else
                {
                    hitGanEvent += value;
                }
            }
            remove
            {
                if (hitGanEvent != null)
                {
                    lock (hitGanEvent)
                    {
                        hitGanEvent -= value;
                    }
                }
                else
                {
                    hitGanEvent -= value;
                }
            }
        }

        event SignalEvent resetGanEvent;
        protected SignalEvent ResetGanEvent
        {
            get { return resetGanEvent; }
        }
        virtual public event SignalEvent OnResetGanEvent
        {
            add
            {
                if (resetGanEvent != null)
                {
                    lock (resetGanEvent)
                    {
                        resetGanEvent += value;
                    }
                }
                else
                {
                    resetGanEvent += value;
                }
            }
            remove
            {
                if (resetGanEvent != null)
                {
                    lock (resetGanEvent)
                    {
                        resetGanEvent -= value;
                    }
                }
                else
                {
                    resetGanEvent -= value;
                }
            }
        }

        event EventHandler carMoveForwardEvent;
        protected EventHandler CarMoveForwardEvent
        {
            get { return carMoveForwardEvent; }
        }
        virtual public event EventHandler OnCarMoveForwardEvent
        {
            add
            {
                if (carMoveForwardEvent != null)
                {
                    lock (carMoveForwardEvent)
                    {
                        carMoveForwardEvent += value;
                    }
                }
                else
                {
                    carMoveForwardEvent += value;
                }
            }
            remove
            {
                if (carMoveForwardEvent != null)
                {
                    lock (carMoveForwardEvent)
                    {
                        carMoveForwardEvent -= value;
                    }
                }
                else
                {
                    carMoveForwardEvent -= value;
                }
            }
        }

        event EventHandler carMoveBackEvent;
        protected EventHandler CarMoveBackEvent
        {
            get { return carMoveBackEvent; }
        }
        virtual public event EventHandler OnCarMoveBackEvent
        {
            add
            {
                if (carMoveBackEvent != null)
                {
                    lock (carMoveBackEvent)
                    {
                        carMoveBackEvent += value;
                    }
                }
                else
                {
                    carMoveBackEvent += value;
                }
            }
            remove
            {
                if (carMoveBackEvent != null)
                {
                    lock (carMoveBackEvent)
                    {
                        carMoveBackEvent -= value;
                    }
                }
                else
                {
                    carMoveBackEvent -= value;
                }
            }
        }

        event EventHandler carStopEvent;
        protected EventHandler CarStopEvent
        {
            get { return carStopEvent; }
        }
        virtual public event EventHandler OnCarStopEvent
        {
            add
            {
                if (carStopEvent != null)
                {
                    lock (carStopEvent)
                    {
                        carStopEvent += value;
                    }
                }
                else
                {
                    carStopEvent += value;
                }
            }
            remove
            {
                if (carStopEvent != null)
                {
                    lock (carStopEvent)
                    {
                        carStopEvent -= value;
                    }
                }
                else
                {
                    carStopEvent -= value;
                }
            }
        }

        event EventHandler carFlameoutEvent;
        protected EventHandler CarFlameoutEvent
        {
            get { return carFlameoutEvent; }
        }
        virtual public event EventHandler OnCarFlameoutEvent
        {
            add
            {
                if (carFlameoutEvent != null)
                {
                    lock (carFlameoutEvent)
                    {
                        carFlameoutEvent += value;
                    }
                }
                else
                {
                    carFlameoutEvent += value;
                }
            }
            remove
            {
                if (carFlameoutEvent != null)
                {
                    lock (carFlameoutEvent)
                    {
                        carFlameoutEvent -= value;
                    }
                }
                else
                {
                    carFlameoutEvent -= value;
                }
            }
        }

        event TimeOutEvent examTimeOutEvent;
        protected TimeOutEvent ExamTimeOutEvent
        {
            get { return examTimeOutEvent; }
        }
        virtual public event TimeOutEvent OnExamTimeOut
        {
            add
            {
                if (examTimeOutEvent != null)
                {
                    lock (examTimeOutEvent)
                    {
                        examTimeOutEvent += value;
                    }
                }
                else
                {
                    examTimeOutEvent += value;
                }
            }
            remove
            {
                if (examTimeOutEvent != null)
                {
                    lock (examTimeOutEvent)
                    {
                        examTimeOutEvent -= value;
                    }
                }
                else
                {
                    examTimeOutEvent -= value;
                }
            }
        }

        event TimeOutEvent stateTimeOutEvent;
        protected TimeOutEvent StateTimeOutEvent
        {
            get { return stateTimeOutEvent; }
        }
        virtual public event TimeOutEvent OnStateTimeOutEvent
        {
            add
            {
                if (stateTimeOutEvent != null)
                {
                    lock (stateTimeOutEvent)
                    {
                        stateTimeOutEvent += value;
                    }
                }
                else
                {
                    stateTimeOutEvent += value;
                }
            }
            remove
            {
                if (stateTimeOutEvent != null)
                {
                    lock (stateTimeOutEvent)
                    {
                        stateTimeOutEvent -= value;
                    }
                }
                else
                {
                    stateTimeOutEvent -= value;
                }
            }
        }

        #region ITranslater Members

        public IMonitor Monitor
        {
            get { return monitor; }
        }

        #endregion
    }
}
