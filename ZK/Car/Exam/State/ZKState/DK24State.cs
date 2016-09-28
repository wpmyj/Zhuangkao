using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class DK24State : BaseState
    {
        public DK24State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "DK24";
        }

        public override string DisplayName
        {
            get
            {
                return "µ¹¿â¡£Ñ¹2Ïßµ½Ñ¹4Ïß";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 2:
                    carStateMgr.DKLineNum = 3;
                    break;
                case 3:
                    ChangeState(carStateMgr.DK47);
                    break;
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 2:
                    carStateMgr.DKL3Time = DateTime.Now;
                    break;
                case 1:
                    carStateMgr.DKL2Time = DateTime.Now;
                    break;
            }
            base.OnLeaveXianEvent(sender, e);
        }
    }
}
