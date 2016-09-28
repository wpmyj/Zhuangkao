using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Module.Sound;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class JKTOState : BaseState
    {
        public JKTOState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JKTO";
        }

        public override string DisplayName
        {
            get
            {
                return "进库。过了4线停车或超时。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    if (carStateMgr.YKNotified)
                    {
                        ChangeState(carStateMgr.YK1F);
                        YKHideLine2();
                    }
                    else
                        OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 0:
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
                case 1:
                    if (carStateMgr.YKNotified)
                    {
                        YKLeaveLine2();
                    }
                    break;
                case 7:
                    if (carStateMgr.YKNotified)
                    {
                        ChangeState(carStateMgr.YK1F);
                    }
                    break;
            }
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            if (carStateMgr.YKNotified && settings.SoundConfig.HasVoice)
            {
                OnFailure(new ExamResultMsg(ResultType.LXC));
                return;
            }
            ChangeState(carStateMgr.JK4S, settings.StateDelayConfig.Delay2);
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            base.OnCarMoveForwardEvent(sender, e);
            if (carStateMgr.YKNotified)
                ChangeState(carStateMgr.YK1F);
            else
                OnFailure(new ExamResultMsg(ResultType.LXC));
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (!carStateMgr.YKNotified)
            {
                if (settings.SoundConfig.HasVoice)
                    CVoice.Play("准备移库");
                carStateMgr.YKNotified = true;
            }
        }
    }
}

