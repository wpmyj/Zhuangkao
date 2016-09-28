using System;
using System.Collections.Generic;
using System.Text;
using Signal;
using System.Threading;
using Signal;
using Signal.ZKSignal;

namespace Exam.SignalTranslator
{
    public class ZKSignalTranslator : IMonObserver,ITranslater
    {
        CMonData oldData;
        CMonitor monitor;

        private Thread _examTOThread;
        private int _examTimeout = 0;

        private Thread _stateTOThread;
        private int _stateTimeout = 0;

        public ZKSignalTranslator(CMonitor monitor)
        {
            oldData = new CMonData();
            this.monitor = monitor;
            monitor.RegMonitor(this);
            _examTOThread = new Thread(new ThreadStart(ExamTimeOut));
            _stateTOThread = new Thread(new ThreadStart(StateTimeOut));
        }

        #region IMonObserver Members

        public void Notify(IMonData idata)
        {
            CMonData data = (CMonData)idata;
            for (int i = 0; i < 9; i++)
            {
                if (data.xian[i] != oldData.xian[i])
                {
                    SignalEvent handler;
                    if (data.xian[i] == 1)
                        handler = LeaveXianEvent;
                    else
                        handler = BlockXianEvent;
                    handler(this, new SignalEventArgs(SignalType.XIAN, i));
                }
                if (data.gan[i] != oldData.gan[i])
                {
                    SignalEvent handler;
                    if (data.gan[i] == 0)
                        handler = HitGanEvent;
                    else
                        handler = ResetGanEvent;
                    handler(this, new SignalEventArgs(SignalType.GAN, i));
                }
                if (i < 4)
                    if (data.che[i] != oldData.che[i])
                        if (data.che[i] == 1)
                        {
                            EventHandler handler = CarStopEvent;
                            switch (i)
                            {
                                case 0:
                                    handler = CarMoveForwardEvent;
                                    break;
                                case 1:
                                    handler = CarMoveBackEvent;
                                    break;
                                case 2:
                                    handler = CarStopEvent;
                                    break;
                                case 3:
                                    handler = CarFlameoutEvent;
                                    break;
                            }
                            handler(this, new EventArgs());
                        }
            }
            oldData.Copy(data);
        }

        #endregion

        private void ExamTimeOut()
        {
            if (_examTimeout != 0)
            {
                Thread.Sleep(_examTimeout * 1000);
            }
            if (_examTOThread.ThreadState == ThreadState.Running)
            {
                TimeOutEvent handler = ExamTimeOutEvent;
                handler(this, new TimeOutEventArgs(_examTimeout));
            }
        }

        private void StateTimeOut()
        {
            try
            {
                if (_stateTimeout != 0)
                {
                    Thread.Sleep(_stateTimeout * 1000);
                }
                if (Thread.CurrentThread.ThreadState == ThreadState.Running)
                {
                    TimeOutEvent handler = StateTimeOutEvent;
                    handler(this, new TimeOutEventArgs(_stateTimeout));
                }
            }
            catch(ThreadAbortException e)
            {
                Thread.ResetAbort();
            }
        }

        public void StartExamTimeOut(int timeout)
        {
            _examTimeout = timeout;
            StartTimeOut(ref _examTOThread, new ThreadStart(ExamTimeOut));
        }

        public void StartStateTimeOut(int timeout)
        {
            _stateTimeout = timeout;
            StartTimeOut(ref _stateTOThread, new ThreadStart(StateTimeOut));
        }

        public void AbortExamTimeOut()
        {
            AbortTimeOut(ref _examTOThread);
        }

        public void AbortStateTimeOut()
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

        event SignalEvent BlockXianEvent;
        public event SignalEvent OnBlockXianEvent
        {
            add
            {
                if (BlockXianEvent != null)
                {
                    lock (BlockXianEvent)
                    {
                        BlockXianEvent += value;
                    }
                }
                else
                {
                    BlockXianEvent += value;
                }
            }
            remove
            {
                if (BlockXianEvent != null)
                {
                    lock (BlockXianEvent)
                    {
                        BlockXianEvent -= value;
                    }
                }
                else
                {
                    BlockXianEvent -= value;
                }
            }
        }

        event SignalEvent LeaveXianEvent;
        public event SignalEvent OnLeaveXianEvent
        {
            add
            {
                if (LeaveXianEvent != null)
                {
                    lock (LeaveXianEvent)
                    {
                        LeaveXianEvent += value;
                    }
                }
                else
                {
                    LeaveXianEvent += value;
                }
            }
            remove
            {
                if (LeaveXianEvent != null)
                {
                    lock (LeaveXianEvent)
                    {
                        LeaveXianEvent -= value;
                    }
                }
                else
                {
                    LeaveXianEvent -= value;
                }
            }
        }

        event SignalEvent HitGanEvent;
        public event SignalEvent OnHitGanEvent
        {
            add
            {
                if (HitGanEvent != null)
                {
                    lock (HitGanEvent)
                    {
                        HitGanEvent += value;
                    }
                }
                else
                {
                    HitGanEvent += value;
                }
            }
            remove
            {
                if (HitGanEvent != null)
                {
                    lock (HitGanEvent)
                    {
                        HitGanEvent -= value;
                    }
                }
                else
                {
                    HitGanEvent -= value;
                }
            }
        }

        event SignalEvent ResetGanEvent;
        public event SignalEvent OnResetGanEvent
        {
            add
            {
                if (ResetGanEvent != null)
                {
                    lock (ResetGanEvent)
                    {
                        ResetGanEvent += value;
                    }
                }
                else
                {
                    ResetGanEvent += value;
                }
            }
            remove
            {
                if (ResetGanEvent != null)
                {
                    lock (ResetGanEvent)
                    {
                        ResetGanEvent -= value;
                    }
                }
                else
                {
                    ResetGanEvent -= value;
                }
            }
        }

        event EventHandler CarMoveForwardEvent;
        public event EventHandler OnCarMoveForwardEvent
        {
            add
            {
                if (CarMoveForwardEvent != null)
                {
                    lock (CarMoveForwardEvent)
                    {
                        CarMoveForwardEvent += value;
                    }
                }
                else
                {
                    CarMoveForwardEvent += value;
                }
            }
            remove
            {
                if (CarMoveForwardEvent != null)
                {
                    lock (CarMoveForwardEvent)
                    {
                        CarMoveForwardEvent -= value;
                    }
                }
                else
                {
                    CarMoveForwardEvent -= value;
                }
            }
        }

        event EventHandler CarMoveBackEvent;
        public event EventHandler OnCarMoveBackEvent
        {
            add
            {
                if (CarMoveBackEvent != null)
                {
                    lock (CarMoveBackEvent)
                    {
                        CarMoveBackEvent += value;
                    }
                }
                else
                {
                    CarMoveBackEvent += value;
                }
            }
            remove
            {
                if (CarMoveBackEvent != null)
                {
                    lock (CarMoveBackEvent)
                    {
                        CarMoveBackEvent -= value;
                    }
                }
                else
                {
                    CarMoveBackEvent -= value;
                }
            }
        }

        event EventHandler CarStopEvent;
        public event EventHandler OnCarStopEvent
        {
            add
            {
                if (CarStopEvent != null)
                {
                    lock (CarStopEvent)
                    {
                        CarStopEvent += value;
                    }
                }
                else
                {
                    CarStopEvent += value;
                }
            }
            remove
            {
                if (CarStopEvent != null)
                {
                    lock (CarStopEvent)
                    {
                        CarStopEvent -= value;
                    }
                }
                else
                {
                    CarStopEvent -= value;
                }
            }
        }

        event EventHandler CarFlameoutEvent;
        public event EventHandler OnCarFlameoutEvent
        {
            add
            {
                if (CarFlameoutEvent != null)
                {
                    lock (CarFlameoutEvent)
                    {
                        CarFlameoutEvent += value;
                    }
                }
                else
                {
                    CarFlameoutEvent += value;
                }
            }
            remove
            {
                if (CarFlameoutEvent != null)
                {
                    lock (CarFlameoutEvent)
                    {
                        CarFlameoutEvent -= value;
                    }
                }
                else
                {
                    CarFlameoutEvent -= value;
                }
            }
        }

        event TimeOutEvent ExamTimeOutEvent;
        public event TimeOutEvent OnExamTimeOut
        {
            add
            {
                if (ExamTimeOutEvent != null)
                {
                    lock (ExamTimeOutEvent)
                    {
                        ExamTimeOutEvent += value;
                    }
                }
                else
                {
                    ExamTimeOutEvent += value;
                }
            }
            remove
            {
                if (ExamTimeOutEvent != null)
                {
                    lock (ExamTimeOutEvent)
                    {
                        ExamTimeOutEvent -= value;
                    }
                }
                else
                {
                    ExamTimeOutEvent -= value;
                }
            }
        }

        event TimeOutEvent StateTimeOutEvent;
        public event TimeOutEvent OnStateTimeOutEvent
        {
            add
            {
                if (StateTimeOutEvent != null)
                {
                    lock (StateTimeOutEvent)
                    {
                        StateTimeOutEvent += value;
                    }
                }
                else
                {
                    StateTimeOutEvent += value;
                }
            }
            remove
            {
                if (StateTimeOutEvent != null)
                {
                    lock (StateTimeOutEvent)
                    {
                        StateTimeOutEvent -= value;
                    }
                }
                else
                {
                    StateTimeOutEvent -= value;
                }
            }
        }

        #region ITranslater Members

        public event SignalEvent SignalEvent;

        public event TimeOutEvent TimeOutEvent;

        #endregion

    }
}
