using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class CK44State : BaseState
    {
        public CK44State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "CK44";
        }

        public override string DisplayName
        {
            get
            {
                return "出库。压四线到离四线";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 2:
                    ChangeState(carStateMgr.CK34);
                    break;
                case 1:
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                    ChangeState(carStateMgr.CK43, settings.StateDelayConfig.Delay3);
                    break;
            }
        }
    }
}
