using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Exam
{
    public enum ResultType
    {
        PASS,
        Gan,    //����
        Xian,   //ѹ��
        ZT,     //��ͣ
        XH,     //Ϩ��
        LXC,    //·�ߴ�
        YKBR,   //�ƿⲻ��
        TimeOut //��ʱ
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
