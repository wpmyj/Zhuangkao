using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.XA3WMotorState
{
    public class ZWKSState : BaseState
    {
        public ZWKSState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "ZWKS";
        }

        public override string DisplayName
        {
            get
            {
                return "ת�俪ʼ";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 1:
                case 2:
                    break;
                case 3:
                    ChangeState(motorStateManager.ZWJS);
                    translator.StartStateTimeOut(settings.StateDelayConfig.Delay6);
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
