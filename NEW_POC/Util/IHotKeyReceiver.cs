using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public interface IHotKeyReceiver
    {
        void ReceiveHotKey(System.Windows.Forms.Keys key);
    }
}
