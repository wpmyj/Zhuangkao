using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Exam
{
    public class MotorSignalTranslator : BaseExamTranslator
    {
        public MotorSignalTranslator(ISignalMonitor monitor)
            : base(monitor)
        {
        }
    }
}
