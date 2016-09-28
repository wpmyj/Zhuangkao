using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class KSState : BaseState
    {
        public KSState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "KS";
        }

        public override string DisplayName
        {
            get
            {
                return "¿ªÊ¼";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                    ChangeState(carStateMgr.F1);
                    break;
                case 1:
                case 2:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }
    }
}

