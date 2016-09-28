using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public delegate void FailureHandleDelegate(IResultMessage msg);
    public interface IState
    {
        void RegEventHandle();
        void UnRegEventHandle();
        void ChangeState(IState state);
        string Name
        {
            get;
        }
        string DisplayName
        {
            get;
        }
        DateTime EntryTime
        {
            get;
            set;
        }
    }
}
