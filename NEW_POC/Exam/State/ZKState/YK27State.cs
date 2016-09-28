using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class YK27State : CState
    {
        public YK27State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "YK27";
        }
    }
}
