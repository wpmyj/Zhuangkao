using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class XCK41State : CState
    {
        public XCK41State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "XCK41";
        }
    }
}
