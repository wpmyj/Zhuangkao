using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class XCK41State : BaseState
    {
        public XCK41State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "XCK41";
        }

        public override string DisplayName
        {
            get
            {
                return "Ð±³ö¿â¡£Ñ¹4Ïß¡£";
            }
        }
        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                    ChangeState(carStateMgr.XCK14);
                    break;
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
                    ChangeState(carStateMgr.XCK4E, settings.StateDelayConfig.Delay3);
                    break;
            }
        }
    }
}
