using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class JK8TOState : ZKBaseCState
    {
        public JK8TOState(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "JK8TO";
        }

        public override void OnCarStopEvent(object sender, EventArgs e)
        {
            base.OnCarStopEvent(sender, e);
            ChangeState(zkStateManager.IDLE);
            this.translator.StartStateTimeOut(10);
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            ChangeState(zkStateManager.IDLE);
        }
    }
}
