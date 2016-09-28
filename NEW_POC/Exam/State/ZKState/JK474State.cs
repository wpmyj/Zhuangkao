using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class JK474State : ZKBaseCState
    {
        public JK474State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "JK474";
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 3:
                    base.OnBlockXianEvent(sender, e);
                    ChangeState(zkStateManager.JK48);
                    break;
            }
        }
    }
}
