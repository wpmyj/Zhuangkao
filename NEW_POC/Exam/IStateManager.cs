using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace Exam
{
    public interface IStateManager
    {
        string Name
        {
            get;
        }

        CSettings Settings
        {
            get;
        }

        string Description
        {
            get;
        }

        IState CurrentState
        {
            get;
            set;
        }

        IState EntryState
        {
            get;
            set;
        }

        void ResetState();

        void RegExamObserver(IExamObserver obj);

        void UnRegExamObserver(IExamObserver obj);
    }
}
