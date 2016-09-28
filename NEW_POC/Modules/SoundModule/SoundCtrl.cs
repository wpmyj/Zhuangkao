using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.SoundModule
{
    public class SoundCtrl : Exam.IExamObserver
    {

        public SoundCtrl(CandidateInfoPanel.LocalInputPanel localInputPanel)
        {
            localInputPanel.StudentExamChange += new Modules.CandidateInfoPanel.StudentExamChangeEvent(ReadText);
        }
        //实现接口要求的方法
        public　void Notify(Exam.Exam exam) { }
        public　void Notify(Exam.IState state) { }

        protected void ReadText(string msg)
        {
           CVoice.Play(msg); 
        }

    }
}
