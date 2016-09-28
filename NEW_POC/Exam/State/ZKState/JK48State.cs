using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class JK48State : ZKBaseCState
    {
        public JK48State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "JK48";
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 7:
                    base.OnBlockXianEvent(sender, e);
                    ChangeState(zkStateManager.JK8TO);
                    this.translator.StartStateTimeOut(10);
                    break;
            }
        }
    }
}
