using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Exam
{
    public interface IMotorStateManager : IStateManager
    {
        uint C5Time { get;}
        void Pass5();
        void ResetC5Time();
    }
}
