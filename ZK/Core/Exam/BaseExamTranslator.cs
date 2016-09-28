using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Util;
using System.Threading;

namespace Cn.Youdundianzi.Core.Exam
{
    public abstract class BaseExamTranslator : ITranslator
    {
        protected IMonData oldData;
        protected ISignalMonitor monitor;

        private Thread _examTOThread;
        private int _examTimeout = 0;

        private Thread _stateTOThread;
        private int _stateTimeout = 0;

        public BaseExamTranslator(ISignalMonitor monitor)
        {
            oldData = monitor.CreateMonDate(monitor.SignalLength);
            this.monitor = monitor;
            this.monitor.RegMonitor(this);
            _examTOThread = new Thread(new ThreadStart(ExamTimeOut));
            _stateTOThread = new Thread(new ThreadStart(StateTimeOut));
        }

        #region IMonObserver Members

        virtual public void Notify(IMonData data)
        {
            if (monitor.Ready)
            {
                CSignals oldx = oldData.GetSignals(SignalType.XIAN);
                for (int i = 0; i < monitor.SignalLength.XIAN_LENGTH; i++)
                {
                    CSignals sig = data.GetSignals(SignalType.XIAN);
                    if (sig[i] != oldx[i])
                    {
                        SignalEvent handler;
                        if (sig[i] == 1)
                            handler = LeaveXianEvent;
                        else
                            handler = BlockXianEvent;
                        handler(this, new SignalEventArgs(SignalType.XIAN, i));
                    }
                }
                CSignals oldg = oldData.GetSignals(SignalType.GAN);
                for (int i = 0; i < monitor.SignalLength.GAN_LENGTH; i++)
                {
                    CSignals sig = data.GetSignals(SignalType.GAN);
                    if (sig[i] != oldg[i])
                    {
                        SignalEvent handler;
                        if (sig[i] == 0)
                            handler = HitGanEvent;
                        else
                            handler = ResetGanEvent;
                        handler(this, new SignalEventArgs(SignalType.GAN, i));
                    }
                }
                CSignals oldc = oldData.GetSignals(SignalType.CHE);
                for (int i = 0; i < monitor.SignalLength.CHE_LENGTH; i++)
                {
                    CSignals sig = data.GetSignals(SignalType.CHE);
                    if (sig[i] != oldc[i])
                        if (sig[i] == 1)
                        {
                            EventHandler handler = CarStopEvent;
                            switch (i)
                            {
                                case (int)BaseCarSignalEnum.FORWARD:
                                    handler = CarMoveForwardEvent;
                                    break;
                                case (int)BaseCarSignalEnum.BACK:
                                    handler = CarMoveBackEvent;
                                    break;
                                case (int)BaseCarSignalEnum.STOP:
                                    handler = CarStopEvent;
                                    break;
                                case (int)BaseCarSignalEnum.FLAMEOUT:
                                    handler = CarFlameoutEvent;
                                    break;
                            }
                            handler(this, new EventArgs());
                        }
                }
            }
            else
            {
                monitor.Ready = true;
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
            /*
            if (timeoutThread != null)
            {
                try
                {
                    //timeoutThread.Abort();
                    AbortTimeOut(ref timeoutThread);
                }
                catch (Exception e)
                { }
            }
             * */
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
                catch (Exception e)
                {
                    Logger.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "\t" + Logger.ABORT_STATE_TIME_OUT_THREAD_PREFIX + e.Message);
                }
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

        public IMonData CurrentData
        {
            get { return monitor.CurrData; }
        }

        #region ITranslater Members

        public ISignalMonitor Monitor
        {
            get { return monitor; }
        }

        #endregion
    }
}
