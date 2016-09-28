using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Exam
{
    public enum ResultType
    {
        PASS,
        Gan,    //碰杆
        Xian,   //压线
        ZT,     //中停
        XH,     //熄火
        LXC,    //路线错
        YKBR,   //移库不入
        TimeOut //超时
    }

    public delegate void FailureHandleDelegate(IResultMessage msg);

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
