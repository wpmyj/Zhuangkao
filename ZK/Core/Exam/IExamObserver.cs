using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Exam
{
    public interface IExamObserver
    {
        void Notify(CExam exam);
        void Notify(IState state);
    }
}
