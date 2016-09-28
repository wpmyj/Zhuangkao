using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class DK11State : BaseState
    {
        public DK11State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "DK11";
        }

        public override string DisplayName
        {
            get
            {
                return "倒库。离开一线到压住一线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                    ChangeState(carStateMgr.DK12);
                    break;
                case 1:
                    ChangeState(carStateMgr.DK24);
                    break;
                case 3:
                    OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }
    }
}
