using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Share.Module.Sound;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class DKTOState : BaseState
    {
        public DKTOState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "DKTO";
        }

        public override string DisplayName
        {
            get
            {
                return "倒库。过了4线停车或超时。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                    if (carStateMgr.CKNotified)
                        ChangeState(carStateMgr.CK4);
                    else
                        OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 1:
                case 2:
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
                    if (carStateMgr.CKNotified)
                        ChangeState(carStateMgr.CKF4);
                    break;
            }
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            base.OnCarMoveForwardEvent(sender, e);
            if (carStateMgr.CKNotified)
                ChangeState(carStateMgr.CKF4);
            else
                OnFailure(new ExamResultMsg(ResultType.LXC));
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            if (carStateMgr.CKNotified && settings.SoundConfig.HasVoice)
            {
                OnFailure(new ExamResultMsg(ResultType.LXC));
                return;
            }
            ChangeState(carStateMgr.DK4S, settings.StateDelayConfig.Delay2);
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (!carStateMgr.CKNotified)
            {
                if (settings.SoundConfig.HasVoice)
                    CVoice.Play("开始出库");
                carStateMgr.CKNotified = true;
            }
        }
    }
}

