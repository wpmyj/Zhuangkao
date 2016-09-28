using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class YK88State : BaseState
    {
        public YK88State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YK88";
        }

        public override string DisplayName
        {
            get
            {
                return "移库。一退压8线至二进离8线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                case 2:
                case 3:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 7:
                    ChangeState(carStateMgr.YK87);
                    break;
            }
        }
    }
}
