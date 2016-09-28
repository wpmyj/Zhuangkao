using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Util
{
    public interface IHotKeyReceiver
    {
        void ReceiveHotKey(System.Windows.Forms.Keys key);
    }
}
