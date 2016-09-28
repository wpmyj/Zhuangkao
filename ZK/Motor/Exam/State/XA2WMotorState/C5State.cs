using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.XA2WMotorState
{
    public class C5State : BaseState
    {
        public C5State(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "C5";
        }

        public override string DisplayName
        {
            get
            {
                return "第" + motorStateManager.C5Time + "次穿过5线";
            }
        }

        public override void OnHitGanEvent(object sender, SignalEventArgs e)
        {

            switch (e.Number)
            {
                case 0:
                    switch (motorStateManager.C5Time)
                    {
                        case 1:
                        case 8:
                            base.OnHitGanEvent(sender, e);
                            break;
                        default:
                            return;
                    }
                    break;
                case 1:
                    switch (motorStateManager.C5Time)
                    {
                        case 1:
                        case 2:
                        case 7:
                        case 8:
                            base.OnHitGanEvent(sender, e);
                            break;
                        default:
                            return;
                    }
                    break;
                case 2:
                    switch (motorStateManager.C5Time)
                    {
                        case 2:
                        case 3:
                        case 6:
                        case 7:
                            base.OnHitGanEvent(sender, e);
                            break;
                        default:
                            return;
                    }
                    break;
                case 3:
                    switch (motorStateManager.C5Time)
                    {
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            base.OnHitGanEvent(sender, e);
                            break;
                        default:
                            return;
                    }
                    break;
                case 4:
                    switch (motorStateManager.C5Time)
                    {

                        case 4:
                        case 5:
                            base.OnHitGanEvent(sender, e);
                            break;
                        default:
                            return;
                    }
                    break;
            }

        } 
        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 4:
                    if (!MinDelayReached(this.MinBlockDelay))
                        return;

                    base.OnLeaveXianEvent(sender, e);
                    switch(motorStateManager.C5Time )
                    {
                        case 1:
                        case 3:
                        case 6:
                            ChangeState(motorStateManager.Z);
                            translator.StartStateTimeOut(settings.StateDelayConfig.Delay3);
                            break;
                        case 2:
                        case 5:
                        case 7:
                            ChangeState(motorStateManager.Y);
                            translator.StartStateTimeOut(settings.StateDelayConfig.Delay3);
                            break;
                        case 4:
                            ChangeState(motorStateManager.Y2);
                            translator.StartStateTimeOut(settings.StateDelayConfig.Delay3);
                            break;
                        case 8:
                            ChangeState(motorStateManager.Z1);
                            translator.StartStateTimeOut(settings.StateDelayConfig.Delay4);
                            break;
                    }
                    break;
                default:
                    base.OnLeaveXianEvent(sender, e);
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            OnFailure(new ExamResultMsg(ResultType.ZT));
        }
    }
}
