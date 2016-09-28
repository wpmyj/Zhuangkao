using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Exam
{
    public interface ICarStateManager : IStateManager
    {
        bool HasLeaveLine2
        {
            get;
            set;
        }

        int JKLineNum
        {
            get;
            set;
        }

        int DKLineNum
        {
            get;
            set;
        }

        DateTime JKL1Time
        {
            set;
            get;
        }

        DateTime JKL2Time
        {
            set;
            get;
        }

        DateTime DKL3Time
        {
            set;
            get;
        }

        DateTime DKL2Time
        {
            set;
            get;
        }

        DateTime YKH2StartTime
        {
            set;
            get;
        }

        TimeSpan YKHideLine2Duration
        {
            set;
            get;
        }

        bool YKNotified
        {
            set;
            get;
        }

        bool XCKNotified
        {
            set;
            get;
        }

        bool DKNotified
        {
            set;
            get;
        }

        bool CKNotified
        {
            set;
            get;
        }
    }
}
