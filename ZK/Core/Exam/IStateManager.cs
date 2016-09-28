using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Core.Exam
{
    public interface IStateManager
    {
        string Name
        {
            get;
        }

        ISettings Settings
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
