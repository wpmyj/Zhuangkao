using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class KSState : BaseState
    {
        public KSState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "KS";
        }

        public override string DisplayName
        {
            get
            {
                return "¿ªÊ¼";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 2:
                    ChangeState(carStateMgr.JK32);
                    break;
                case 1:
                    ChangeState(carStateMgr.JK24);
                    break;
            }
        }
    }
}
