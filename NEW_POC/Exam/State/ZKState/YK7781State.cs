using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class YK7781State : CState
    {
        public YK7781State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "YK7781";
        }
    }
}
