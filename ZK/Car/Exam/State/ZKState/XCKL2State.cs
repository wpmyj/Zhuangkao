using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class XCKL2State : BaseState
    {
        public XCKL2State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "XCKL2";
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
                    OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
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
