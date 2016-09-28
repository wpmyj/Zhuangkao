using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cn.Youdundianzi.Share.Module.CandidateInfo
{
    public partial class ExamResultPanel : UserControl
    {
        public ExamResultPanel()
        {
            InitializeComponent();
        }


        private delegate void SetTextDelegate(Control ctrl, string newText);
        private void SetText(Control ctrl, string newText)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new SetTextDelegate(SetText), ctrl, newText);
            }
            else
            {
                ctrl.Text = newText;
            }
        }


        public void SetResultText(int huihe ,string msg)
        {
            if (huihe == 0)
                this.Clear();
            if (huihe == 1)
            {
                SetText(label_ks1, "第一回合考试：" + msg);
               
            }
            if (huihe == 2)
            {
                SetText(label_ks2, "第二回合考试：" + msg);
            }

        }

        private void Clear()
        {
            SetText(label_ks1, "第一回合考试：");
            SetText(label_ks2, "第二回合考试：");
        }
    }
}
