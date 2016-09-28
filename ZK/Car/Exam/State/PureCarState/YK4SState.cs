using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Module.Sound;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class YK4SState : BaseState
    {
        public YK4SState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YK4S";
        }

        public override string DisplayName
        {
            get
            {
                return "�ƿ⡣����ʱͣ����";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    if (carStateMgr.XCKNotified)
                        ChangeState(carStateMgr.XCK24);
                    break;
                case 0:
                case 2:
                case 3:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 7:
                    if (!carStateMgr.XCKNotified)
                    {
                        if (this.CurrentMonData.GetSignal(SignalType.XIAN, 1) == 1) //���ѹ8��ʱδѹ2��
                        {
                            ChangeState(carStateMgr.YK4S, 500);
                        }
                        else//���ѹ8��ʱѹ2��
                        {
                            ChangeState(carStateMgr.YK4S, settings.StateDelayConfig.Delay10);
                        }
                    }
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    carStateMgr.HasLeaveLine2 = true;
                    YKLeaveLine2();
                    break;
                case 7:
                    if (carStateMgr.XCKNotified)
                        ChangeState(carStateMgr.XCK24);
                    else
                        OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
            }
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            if (carStateMgr.XCKNotified && settings.SoundConfig.HasVoice)
            {
                OnFailure(new ExamResultMsg(ResultType.LXC));
                return;
            }
            ChangeState(carStateMgr.YK2B, settings.StateDelayConfig.Delay4);
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            base.OnCarMoveForwardEvent(sender, e);
            if (carStateMgr.XCKNotified)
                ChangeState(carStateMgr.XCK24);
            else
                OnFailure(new ExamResultMsg(ResultType.LXC));
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (!carStateMgr.XCKNotified)
            {
                //ѹ����
                if (this.CurrentMonData.GetSignal(SignalType.XIAN, 1) == 0)
                {
                    OnFailure(new ExamResultMsg(ResultType.YKBR));
                    return;
                }
                if (carStateMgr.YKHideLine2Duration < new TimeSpan(settings.StateDelayConfig.Delay12))
                {
                    OnFailure(new ExamResultMsg(ResultType.LXC));
                    return;
                }
                carStateMgr.HasLeaveLine2 = true;
                if (settings.SoundConfig.HasVoice)
                    CVoice.Play("��ʼб����");
                carStateMgr.XCKNotified = true;
            }
        }
    }
}

