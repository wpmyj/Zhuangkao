using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Exam;

namespace Modules.CandidateInfoPanel
{
    public partial class LocalInputPanel : CandExamCtrl 
    {
        public LocalInputPanel()
        {
            InitializeComponent();
        }



        //考车类型
        private ExamType cartype;
        public ExamType CarType
        {
            get { return cartype; }
            set { cartype = value; }
        }

        private delegate void SetEnableDelegate(Control ctrl, bool enable);
        private delegate void SetTextDelegate(Control ctrl, string newText);
        private delegate void SetKSCXComBoxDelegate();

        public void SetKSCXComBox()
        {
            if (this.txtBoxXKSCX.InvokeRequired)
            {
                SetKSCXComBoxDelegate del = new SetKSCXComBoxDelegate(SetKSCXComBox);
                this.txtBoxXKSCX.Invoke(del);
            }
            else
            {
                switch (cartype)
                {
                    case ExamType.MOTOR_2:
                        this.txtBoxXKSCX.Items.Clear();
                        this.txtBoxXKSCX.Items.Add("E");
                        this.txtBoxXKSCX.Items.Add("F");
                        EnableAndSetText(this.txtBoxXKSCX, true, "E");
                        break;
                    case ExamType.MOTOR_3:
                        this.txtBoxXKSCX.Items.Clear();
                        this.txtBoxXKSCX.Items.Add("D");
                        EnableAndSetText(this.txtBoxXKSCX, true, "D");
                        break;
                }
            }

        }

        private void SetEnable(Control ctrl, bool enable)
        {
            ctrl.Enabled = enable;
        }

        private void SetText(Control ctrl, string newText)
        {
            ctrl.Text = newText;
        }

        private void EnableAndSetText(Control ctrl, bool enable, string newText)
        {
            if (ctrl.InvokeRequired)
            {
                SetEnableDelegate setEnable = new SetEnableDelegate(SetEnable);
                ctrl.Invoke(setEnable, ctrl, enable);
                SetTextDelegate setText = new SetTextDelegate(SetText);
                ctrl.Invoke(setText, ctrl, newText);
            }
            else
            {
                SetEnable(ctrl, enable);
                SetText(ctrl, newText);
            }
        }

        private void EnableCtrl(Control ctrl, bool enable)
        {
            if (ctrl.InvokeRequired)
            {
                SetEnableDelegate setEnable = new SetEnableDelegate(SetEnable);
                this.btnXReject.Invoke(setEnable, ctrl, enable);
            }
            else
            {
                SetEnable(ctrl, enable);
            }
        }

        protected  override void ResetPanel()
        {
            cand = null;
            examTimes = 0;

            EnableAndSetText(this.txtBoxXJBR, true, string.Empty);
            EnableAndSetText(this.numericUpDown1, true, 1.ToString());
            SetKSCXComBox();
            //EnableAndSetText(this.txtBoxXKSY1, true, string.Empty);
            //EnableAndSetText(this.txtBoxXKSY2, true, string.Empty);
            EnableAndSetText(this.txtBoxXLSH, true, string.Empty);
            EnableAndSetText(this.txtBoxXSFZMBM, true, string.Empty);
            EnableAndSetText(this.txtBoxXXM, true, string.Empty);
            EnableAndSetText(this.txtBoxXZKZMBH, true, string.Empty);
            EnableCtrl(this.btnXReject, false);
            EnableCtrl(this.btnXOK, true);
            
            if (this.ExamCtrl != null)
            {
                EnableCtrl(this.ExamCtrl, false);
            }
        }

        private bool ValidateCandInfo()
        {
            //实现对考生数据的检查

            if (this.txtBoxXXM.Text == "")
            {
                MessageBox.Show("请输入考生姓名！");
                return false;
            }
       
            if (this.txtBoxXKSY1.Text == "")
            {
                MessageBox.Show("请输入考试员姓名！");
                return false;
            }

            return true;
        }

        private void btnXOK_Click(object sender, EventArgs e)
        {
            if (ValidateCandInfo())
            {
                this.cand = new Candidate();
                cand.Xm = this.txtBoxXXM.Text;
                cand.Lsh = this.txtBoxXLSH.Text;
                cand.Zkzmbh = this.txtBoxXZKZMBH.Text;
                cand.Sfzmhm = this.txtBoxXSFZMBM.Text;
                cand.Kscx = this.txtBoxXKSCX.Text;
                cand.Jbr = this.txtBoxXJBR.Text;
                cand.Kscs = int.Parse(this.numericUpDown1.Value.ToString());
                cand.Ksy1 = this.txtBoxXKSY1.Text;
                cand.Ksy2 = this.txtBoxXKSY2.Text;

                this.txtBoxXJBR.Enabled = false;
                this.numericUpDown1.Enabled = false;
                this.txtBoxXKSCX.Enabled = false;
                this.txtBoxXKSY1.Enabled = false;
                this.txtBoxXKSY2.Enabled = false;
                this.txtBoxXLSH.Enabled = false;
                this.txtBoxXSFZMBM.Enabled = false;
                this.txtBoxXXM.Enabled = false;
                this.txtBoxXZKZMBH.Enabled = false;
                this.btnXOK.Enabled = false;
                this.btnXReject.Enabled = true;
                if (this.ExamCtrl != null)
                    this.ExamCtrl.Enabled = true;
            }
        }

        private void btnXReject_Click(object sender, EventArgs e)
        {
            ResetPanel();
        }

        protected override void ExamStart()
        {
            base.ExamStart();
            if (examTimes == 0)
                EnableCtrl(this.btnXReject, false);
        }

        protected override void ExamStop()
        {
            if (examTimes == 0)
                EnableCtrl(this.btnXReject, true);
        }

        protected override void ExamPass(string msg)
        {
            base.ExamPass(msg);
            ResetPanel();
        }

        private void PrepareRetry()
        {
            examTimes = 1;
        }

        protected override void ExamFail(string msg)
        {
            if (examTimes == 0)
            {
                base.ExamFail(msg);
                PrepareRetry();
            }
            else
            {
                base.ExamFail(msg);
                ResetPanel();
            }
        }
    }
}
