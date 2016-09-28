using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Signal
{
    public interface IMonObserver
    {
        void Notify(IMonData data);
    }
}
