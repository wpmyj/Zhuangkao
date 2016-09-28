using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Signal
{
    public interface IMonData
    {
        void Copy(IMonData src);

        bool Equals(IMonData src);

        sbyte GetSignal(SignalType type, int index);

        CSignals GetSignals(SignalType type);

        void SetSignals(SignalType type, CSignals src);
    }
}
