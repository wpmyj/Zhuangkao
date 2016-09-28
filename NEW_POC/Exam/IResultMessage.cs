using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public enum ResultType
    {
        PASS,
        Gan,
        Xian,
        ZT,
        XH,
        LXC,
        TimeOut
    }
    public interface IResultMessage
    {
        ResultType TypeOfResult
        {
            get;
        }

        string Message
        {
            get;
        }

        int Index
        {
            get;
        }
    }
}
