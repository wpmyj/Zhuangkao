using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Share.Module.Sound;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
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
                return "斜出库。停车结束。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                    if (carStateMgr.DKNotified)
                        ChangeState(carStateMgr.DK12);
                    break;
                case 1:
                    if (carStateMgr.DKNotified)
                        ChangeState(carStateMgr.DK24);
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
            if (carStateMgr.DKNotified)
                ChangeState(carStateMgr.DK12);
            else
                OnFailure(new ExamResultMsg(ResultType.LXC));
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            base.OnCarMoveForwardEvent(sender, e);
            if (carStateMgr.DKNotified && settings.SoundConfig.HasVoice)
            {
                OnFailure(new ExamResultMsg(ResultType.LXC));
                return;
            }
            ChangeState(carStateMgr.XCK4S, settings.StateDelayConfig.Delay5);
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (!carStateMgr.DKNotified)
            {
                if (settings.SoundConfig.HasVoice)
                    CVoice.Play("开始倒库");
                carStateMgr.DKNotified = true;
            }
        }
    }
}

