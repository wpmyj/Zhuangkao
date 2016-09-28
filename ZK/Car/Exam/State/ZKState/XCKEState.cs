using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class XCKEState : BaseState
    {
        public XCKEState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "XCKE";
        }

        public override string DisplayName
        {
            get
            {
                return "Ð±³ö¿â¡£Àë¿ª4Ïß¡£";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    if (MinDelayReached(this.EntryTime, settings.StateDelayConfig.Delay6))
                        ChangeState(carStateMgr.DK24);
                    else
                        OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
                case 3:
                    OnFailure(new ExamResultMsg(ResultType.LXC));
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
                case 0:
                    ChangeState(carStateMgr.DK11, settings.StateDelayConfig.Delay5);
                    break;
            }
        }
    }
}
