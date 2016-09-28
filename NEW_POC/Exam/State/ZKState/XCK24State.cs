using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class XCK24State : CState
    {
        public XCK24State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "XCK24";
        }
    }
}
