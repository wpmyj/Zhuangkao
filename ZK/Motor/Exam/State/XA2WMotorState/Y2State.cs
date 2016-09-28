using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.XA2WMotorState
{
    public class Y2State : BaseState
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
                return "准备开始转弯";
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
