using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class JK24State : ZKBaseCState
    {
        public JK24State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "JK24";
        }
        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 3:
                    base.OnBlockXianEvent(sender, e);
                    ChangeState(zkStateManager.JK474);
                    break;
            }
        }
    }
}
