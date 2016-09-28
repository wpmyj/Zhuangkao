using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class XCK74State : BaseState
    {
        public XCK74State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "XCK74";
        }

        public override string DisplayName
        {
            get
            {
                return "Ð±³ö¿â¡£Ñ¹7ÏßÎ´Ñ¹4Ïß¡£";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                    ChangeState(carStateMgr.XCK41);
                    break;
                case 0:
                case 2:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }
    }
}
