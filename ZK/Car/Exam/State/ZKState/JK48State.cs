using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class JK48State : BaseState
    {
        public JK48State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JK48";
        }

        public override string DisplayName
        {
            get
            {
                return "进库。离四线过了延时至压八线（或超时）。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 7:
                    ChangeState(carStateMgr.JK8TO);
                    break;
                case 0:
                case 1:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            ChangeState(carStateMgr.JKTO);
        }
    }
}
