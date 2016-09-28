using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
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
                case 2:
                    ChangeState(carStateMgr.JK32);
                    break;
                case 1:
                    ChangeState(carStateMgr.JK24);
                    break;
                case 3:
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            ChangeState(carStateMgr.JK32);
        }
    }
}

