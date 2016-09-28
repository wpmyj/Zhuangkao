using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public interface IMonObserve
    {
        void Notify(CMonData mdata);
    }
}
