using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class F5State : BaseState
    {
        public F5State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "F5";
        }

        public override string DisplayName
        {
            get
            {
                return "F5��ǰ����ѹ5��";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                //��ʱȡ��·�ߴ��ж�
                //case 3:
                //    OnFailure(new ExamResultMsg(ResultType.LXC));
                //    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.F7, settings.StateDelayConfig.Delay3);
                    break;
                //��ʱȡ��·�ߴ��ж�
                //case 4:
                //    OnFailure(new ExamResultMsg(ResultType.LXC));
                //    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 1) == 1)  //����뿪2��
            {
                ChangeState(carStateMgr.F7, settings.StateDelayConfig.Delay3);
            }
        }
    }
}

