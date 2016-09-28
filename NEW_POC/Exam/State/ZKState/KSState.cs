using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class KSState : ZKBaseCState
    {
        public KSState(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "KS";
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 2:
                    base.OnBlockXianEvent(sender, e);
                    ChangeState(zkStateManager.JK32);
                    break;
                case 1:
                    base.OnBlockXianEvent(sender, e);
                    ChangeState(zkStateManager.JK24);
                    break;
            }
        }
    }
}
