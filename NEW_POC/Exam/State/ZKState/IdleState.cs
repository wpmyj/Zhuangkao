using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class IdleState : ZKBaseCState 
    {
        public IdleState(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "IDLE";
        }
    }
}
