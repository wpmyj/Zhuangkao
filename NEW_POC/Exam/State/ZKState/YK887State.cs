using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class YK887State : CState
    {
        public YK887State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "YK887";
        }
    }
}
