using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class JK32State : ZKBaseCState 
    {
        public JK32State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "JK32";
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 1:
                    base.OnBlockXianEvent(sender, e);
                    ChangeState(zkStateManager.JK24);
                    break;
            }
        }
    }
}
