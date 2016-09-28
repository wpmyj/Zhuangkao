using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.State
{
    public interface IMotorStateManager : IStateManager
    {
        uint C5Time { get;}
    }
}
