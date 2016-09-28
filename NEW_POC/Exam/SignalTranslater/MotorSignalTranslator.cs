using System;
using System.Collections.Generic;
using System.Text;
using Signal;
using Shared;
using System.Threading;

namespace Exam.SignalTranslator
{
    public class MotorSignalTranslator : BaseExamTranslator
    {
        public MotorSignalTranslator(IMonitor monitor)
            : base(monitor)
        {
        }

        #region IMonObserver Members

        public override void Notify(CMonData data)
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
                    if (sig[i] != sig[i])
                        if (sig[i] == 1)
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
            }
            else
            {
                monitor.Ready = true;
            }
            oldData.Copy(data);
        }

        #endregion
    }
}
