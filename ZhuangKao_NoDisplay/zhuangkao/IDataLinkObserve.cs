using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public interface IDataLinkObserve
    {
        void LinkStateNotify(bool linkstate);
    }
}
