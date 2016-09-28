using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Share.Module.CandidateInfo
{
    public partial class PractiseCtrlPanel : CandExamCtrl 
    {
        public PractiseCtrlPanel()
        {
            InitializeComponent();
        }

        protected override void ResetPanel()
        {
            CameraChannelChange(settings.CameraConfig.YuntaiChannel);
            ExamResultReady(0, string.Empty);
        }

        protected override void ExamStart()
        {
            SoundChange("请上车,开始考试!");
            LEDDisplayChange("请上车,开始考试!");
        }

        protected override void ExamStop()
        {
        }

        protected override void ExamPass(string msg)
        {
            SoundChange(msg + ",考试结束!");
            LEDDisplayChange(msg + ",考试结束!");
            ExamResultReady(1, msg);

            //显示考试通过
            ShowMsgBox(this, msg);
            ResetPanel();
        }

        private void PrepareRetry()
        {
            examTimes = 1;
        }

        protected override void ExamFail(string msg)
        {
            SoundChange(msg + ",考试结束。");
            LEDDisplayChange(msg + ",考试结束。");
            ExamResultReady(1, msg);

            if (examTimes == 0)
            {
                PrepareRetry();
            }
            else
            {
                ResetPanel();
            }
        }
    }
}
