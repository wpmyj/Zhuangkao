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
                        return "成功";
                    case ResultType.Gan:
                        return "碰杆" + (Index + 1).ToString();
                    case ResultType.Xian:
                        return "压线" + (Index + 1).ToString();
                    case ResultType.ZT:
                        return "中停";
                    case ResultType.XH:
                        return "熄火";
                    case ResultType.LXC:
                        return "路线错";
                    case ResultType.YKBR:
                        return "移库不入";
                    case ResultType.TimeOut:
                        return "超时";
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
