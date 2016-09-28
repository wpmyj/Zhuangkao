using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class DK12State : BaseState
    {
        public DK12State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "DK12";
        }

        public override string DisplayName
        {
            get
            {
                return "µ¹¿â¡£Ñ¹1Ïßµ½Ñ¹2Ïß¡£";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
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
