using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class DK48State : BaseState
    {
        public DK48State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "DK48";
        }

        public override string DisplayName
        {
            get
            {
                return "µπø‚°£¿Î4œﬂµΩ—π8œﬂ°£";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 7:
                    ChangeState(carStateMgr.CK84);
                    break;
                case 3:
                    ChangeState(carStateMgr.CK44);
                    break;
                case 1:
                case 2:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }
    }
}
