using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Exam
{
    /**
    public enum ExamType
    {
        NULL,
        MOTOR_2,
        MOTOR_3,
        ZK_S,
        ZK_L
    }
     * */

    public class CExam
    {
        private bool passed = false;
        public bool Passed
        {
            get { return passed; }
        }

        private IResultMessage message;
        public IResultMessage Message
        {
            get { return message; }
        }

        public CExam(bool result, IResultMessage msg)
        {
            passed = result;
            message = msg;
        }
    }
}
