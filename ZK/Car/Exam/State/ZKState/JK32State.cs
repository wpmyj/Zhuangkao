using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class JK32State : BaseState
    {
        public JK32State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JK32";
        }

        public override string DisplayName
        {
            get
            {
                return "进库。三线至二线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.JK24);
                    break;
                case 3:
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }
    }
}
