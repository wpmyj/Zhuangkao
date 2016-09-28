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
    public partial class LocalInputPanel : CandExamCtrl 
    {
        public LocalInputPanel()
        {
            InitializeComponent();
        }

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
                this.txtBoxXKSCX.Items.Clear();
                foreach(string cx in CXList)
                {
                    this.txtBoxXKSCX.Items.Add(cx);
                }
                EnableAndSetText(this.txtBoxXKSCX, true, CXList[0]);
            }

        }

        protected override void ResetPanel()
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

            CameraChannelChange(settings.CameraConfig.YuntaiChannel);
            ExamResultReady(0, string.Empty);
        }

        private bool ValidateCandInfo()
        {
            //ʵ�ֶԿ������ݵļ��

            if (this.txtBoxXXM.Text == "")
            {
                MessageBox.Show("�����뿼��������");
                return false;
            }
       
            if (this.txtBoxXKSY1.Text == "")
            {
                MessageBox.Show("�����뿼��Ա������");
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
            if (cand.HuiHeShu == 0)
            {
                SoundChange(cand.Xm + ",���ϳ�,��ʼ����!");
                LEDDisplayChange(cand.Xm + ",���ϳ�,��ʼ����!");
            }
            else
            {
                SoundChange(cand.Xm + ",�ڶ��غϿ�ʼ����!");
                LEDDisplayChange(cand.Xm + ",�ڶ��غϿ�ʼ����!");
            }
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
            if (cand != null)
            {
                cand.Kscj = 1;
                cand.HuiHeShu = examTimes + 1;

                if (cand.HuiHeShu == 1)
                    cand.KS1 = msg;
                if (cand.HuiHeShu == 2)
                    cand.KS2 = msg;

                SoundChange(cand.Xm + "," + msg + ",���Խ���!");
                LEDDisplayChange(cand.Xm + "," + msg + ",���Խ���!");
                ExamResultReady(cand.HuiHeShu, msg);

                //��ʾ����ͨ��
                ShowMsgBox(this, msg);

                if (DoStore())
                {
                    if (this._printContent != null)
                    {
                        if ((new frmMessageBox()).ShowDialog() == DialogResult.Yes)
                            DoPrint();
                    }
                }
            }
            ResetPanel();
        }

        private void PrepareRetry()
        {
            examTimes = 1;
        }

        protected override void ExamFail(string msg)
        {
            if (cand != null)
            {
                cand.Kscj = 0;
                cand.HuiHeShu = examTimes + 1;

                if (cand.HuiHeShu == 1)
                {
                    cand.KS1 = msg;

                    SoundChange(cand.Xm + "," + msg + ",��һ�غϽ������뽫��������㡣");
                    LEDDisplayChange(cand.Xm + "," + msg + ",��һ�غϽ������뽫��������㡣");
                    ExamResultReady(cand.HuiHeShu, msg);

                    //��ʾ����δͨ��
                    ShowMsgBox(this, msg);

                }
                if (cand.HuiHeShu == 2)
                {
                    cand.KS2 = msg;

                    SoundChange(cand.Xm + "," + msg + ",���Խ�����");
                    LEDDisplayChange(cand.Xm + "," + msg + ",���Խ�����");
                    ExamResultReady(cand.HuiHeShu, msg);

                    //��ʾ����δͨ��
                    ShowMsgBox(this, msg);

                    //�浵
                    if (DoStore())
                    {
                        //��ӡ
                        if (this._printContent != null)
                        {
                            if (settings.PrintConfig.IsprintNopass)
                                if ((new frmMessageBox()).ShowDialog() == DialogResult.Yes)
                                    DoPrint();
                        }
                    }
                }
            }
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
