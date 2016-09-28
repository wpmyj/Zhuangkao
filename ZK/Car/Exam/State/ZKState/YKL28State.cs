using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Module.Sound;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class YKL28State : BaseState
    {
        public YKL28State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YKL28";
        }

        public override string DisplayName
        {
            get
            {
                return "移库。二退离开7线后，未压2线压8线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.XCKH2);
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

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            CVoice.Play("开始斜出库");
        }
    }
}
