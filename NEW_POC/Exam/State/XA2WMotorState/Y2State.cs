using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.XA2WMotorState
{
    public class Y2State : MotorBaseState
    {
        public Y2State(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "Y2";
        }

        public override string DisplayName
        {
            get
            {
                return "׼����ʼת��";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 2:
                    if (!MinDelayReached(this.MinBlockDelay))
                        return;

                    ChangeState(motorStateManager.ZWKS);
                    translator.StartStateTimeOut(settings.StateDelayConfig.Delay5);
                    break;
                default:
                    base.OnBlockXianEvent(sender, e);
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
