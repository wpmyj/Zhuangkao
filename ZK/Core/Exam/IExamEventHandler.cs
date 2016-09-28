using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Exam
{
    public interface IExamEventHandler
    {
        void OnBlockXianEvent(object sender, SignalEventArgs e);
        void OnLeaveXianEvent(object sender, SignalEventArgs e);
        void OnHitGanEvent(object sender, SignalEventArgs e);
        void OnResetGanEvent(object sender, SignalEventArgs e);
        void OnCarMoveForwardEvent(object sender, EventArgs e);
        void OnCarMoveBackEvent(object sender, EventArgs e);
        void OnCarStopEvent(object sender, EventArgs e);
        void OnCarFlameoutEvent(object sender, EventArgs e);
        void OnStateTimeOutEvent(object sender, TimeOutEventArgs e);
        void OnExamTimeOutEvent(object seder, TimeOutEventArgs e);
        void OnFailure(IResultMessage msg);
        void OnSuccess(IResultMessage msg);
    }
}
