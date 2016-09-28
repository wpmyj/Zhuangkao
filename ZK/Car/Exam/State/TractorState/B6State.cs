using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class B6State : BaseState
    {
        public B6State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "B6";
        }

        public override string DisplayName
        {
            get
            {
                return "B6：后退。离开2线未压4线";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                    ChangeState(carStateMgr.B7, settings.StateDelayConfig.Delay3);
                    break;
                //case 2:
                //    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                //    break;
                case 0:
                //case 4:
                case 5:
                case 6:
                    OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 3) == 0)  //如果压了4线
            {
                ChangeState(carStateMgr.B7, settings.StateDelayConfig.Delay3);
            }
        }
    }
}

