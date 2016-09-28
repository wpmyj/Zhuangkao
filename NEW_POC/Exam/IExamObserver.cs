using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public interface IExamObserver
    {
        void Notify(Exam exam);
        void Notify(IState state);
    }
}
