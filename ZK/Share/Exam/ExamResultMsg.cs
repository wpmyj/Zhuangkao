using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Share.Exam
{
    public class ExamResultMsg : IResultMessage
    {
        public ExamResultMsg(ResultType ft)
        {
            this._resultType = ft;
        }

        public ExamResultMsg(ResultType ft, int index)
        {
            this._resultType = ft;
            this._index = index;
        }

        public string Message
        {
            get
            {
                switch (_resultType)
                {
                    case ResultType.PASS:
                        return "�ɹ�";
                    case ResultType.Gan:
                        return "����" + (Index + 1).ToString();
                    case ResultType.Xian:
                        return "ѹ��" + (Index + 1).ToString();
                    case ResultType.ZT:
                        return "��ͣ";
                    case ResultType.XH:
                        return "Ϩ��";
                    case ResultType.LXC:
                        return "·�ߴ�";
                    case ResultType.YKBR:
                        return "�ƿⲻ��";
                    case ResultType.TimeOut:
                        return "��ʱ";
                }
                return string.Empty;
            }
        }

        #region IFailureMessage Members

        private int _index = -1;
        public int Index
        {
            get { return _index; }
        }

        private ResultType _resultType;
        public ResultType TypeOfResult
        {
            get { return _resultType; }
        }

        #endregion
    }
}
