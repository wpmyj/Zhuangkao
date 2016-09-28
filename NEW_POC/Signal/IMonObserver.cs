using System;
using System.Collections.Generic;
using System.Text;

namespace Signal
{
    public interface IMonObserver
    {
        void Notify(CMonData data);
    }
}
