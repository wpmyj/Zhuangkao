using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class XCK14State : BaseState
    {
        public XCK14State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "XCK14";
        }

        public override string DisplayName
        {
            get
            {
                return "б���⡣ѹ1�ߣ��ȴ���4�ߡ�";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
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
