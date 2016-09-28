using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class YK27State : BaseState
    {
        public YK27State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YK27";
        }

        public override string DisplayName
        {
            get
            {
                return "移库。压2线至压7线。一进。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 6:
                    ChangeState(carStateMgr.YK771);
                    break;
                case 0:
                case 2:
                case 3:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }
    }
}
