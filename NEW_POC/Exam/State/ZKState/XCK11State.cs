using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class XCK11State : CState
    {
        public XCK11State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "XCK11";
        }
    }
}
