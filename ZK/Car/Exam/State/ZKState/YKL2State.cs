using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class YKL2State : BaseState
    {
        public YKL2State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YKL2";
        }

        public override string DisplayName
        {
            get
            {
                return "移库。二退离开7线后，离开2线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.YKH2);
                    break;
                case 7:
                    ChangeState(carStateMgr.YKL28, settings.StateDelayConfig.Delay4);
                    break;
                case 3:
                case 6:
                    OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
                case 0:
                case 2:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }
    }
}
