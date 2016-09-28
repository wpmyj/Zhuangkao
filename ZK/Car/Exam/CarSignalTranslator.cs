using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Exam
{
    public class CarSignalTranslator : BaseExamTranslator
    {
        public CarSignalTranslator(ISignalMonitor monitor)
            : base(monitor)
        {
        }
    }
}
