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
            SoundChange("���ϳ�,��ʼ����!");
            LEDDisplayChange("���ϳ�,��ʼ����!");
        }

        protected override void ExamStop()
        {
        }

        protected override void ExamPass(string msg)
        {
            SoundChange(msg + ",���Խ���!");
            LEDDisplayChange(msg + ",���Խ���!");
            ExamResultReady(1, msg);

            //��ʾ����ͨ��
            ShowMsgBox(this, msg);
            ResetPanel();
        }

        private void PrepareRetry()
        {
            examTimes = 1;
        }

        protected override void ExamFail(string msg)
        {
            SoundChange(msg + ",���Խ�����");
            LEDDisplayChange(msg + ",���Խ�����");
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
