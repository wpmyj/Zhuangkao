using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Share.Module.CandidateInfo;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Share.Module.Sound
{
    public class SoundCtrl : IExamObserver
    {
        //实现接口要求的方法
        //重写本方法可赋予考试结果产生时的语音
        virtual public void Notify(CExam exam) { }
        //重写本方法可赋予考试中状态改变时的语音
        virtual public void Notify(IState state) { }

        //重写本方法可赋予考试开始、结束等控制状态改变时的语音
        virtual protected void OnStudentExamChanged(string msg)
        {
        }

        public void PlayText(string msg)
        {
            CVoice.Play(msg);
        }

    }
}
