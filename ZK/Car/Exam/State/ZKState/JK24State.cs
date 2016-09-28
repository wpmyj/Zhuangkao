using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class JK24State : BaseState
    {
        public JK24State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JK24";
        }

        public override string DisplayName
        {
            get
            {
                return "进库。二线至四线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                    carStateMgr.JKLineNum = 1;
                    break;
                case 3:
                    ChangeState(carStateMgr.JK47);
                    break;
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 0:
                    carStateMgr.JKL1Time = DateTime.Now;
                    break;
                case 1:
                    carStateMgr.JKL2Time = DateTime.Now;
                    break;
            }
            base.OnLeaveXianEvent(sender, e);
        }
    }
}
