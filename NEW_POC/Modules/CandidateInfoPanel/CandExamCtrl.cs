using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Modules.PrintModule;
using Util;
using System.Globalization; 


namespace Modules.CandidateInfoPanel
{
    public delegate void StudentExamChangeEvent(string msg);

    //���ǵ�����̳к���չ�� ��������,��Ҫ��ԭע�ͳ���(ò�ƻ�ԭ����ȥ��)ע�͵ط����Ĵ���
    //-------------------------------------------------------------------------
    //1.public abstract  class CandExamCtrl : UserControl, ICandidateInfoReader
    //2.protected abstract void ResetPanel();
    //3.protected abstract void ExamStart();
    //4.protected abstract void ExamStop();
    //---------------------------------------------------------------------------


    //public abstract  class CandExamCtrl : UserControl, ICandidateInfoReader
    public   class CandExamCtrl : UserControl, ICandidateInfoReader
    {

        //���ڿ�������״̬(��������)
        public event StudentExamChangeEvent StudentExamChange ;


        protected int examTimes = 0;
        int kscj_y, ksrq_y;
        public void InitializeCandExamCtrlComponent(ExamCtrlPanelModule.ExamCtrlPanel examCtrl, CSettings settings)
        {
            this.examCtrl = examCtrl;
            this.examCtrl.OnChangeState += new ExamCtrlPanelModule.ExamCtrlPanelEvent(this.examCtrl_stateChange);
            this.settings = settings;
            if (this.settings.PrintConfig.Isprint)
            {
                _printContent = new CPrintContent(this.settings.PrintConfig);
            }
            ResetPanel();
        }
        
        //protected abstract void ResetPanel();
        protected virtual void ResetPanel()
        { }

        private CSettings settings;
        private ExamCtrlPanelModule.ExamCtrlPanel examCtrl;
        public ExamCtrlPanelModule.ExamCtrlPanel ExamCtrl
        {
            get
            {
                return examCtrl;
            }
        }

        protected CPrintContent _printContent;

        protected Candidate cand;

        #region ICandidateInfoReader Members

        public Candidate GetCandidate()
        {
            if (cand == null)
            {
                throw new Exception("No candidate's information.");
            }
            return cand;
        }

        #endregion

        protected void examCtrl_stateChange(object sender, ExamCtrlPanelModule.StateChangeEventArgs args)
        {
            switch (args.State)
            {
                case Modules.ExamCtrlPanelModule.CtrlPanelState.Start:
                    ExamStart();
                    break;
                case Modules.ExamCtrlPanelModule.CtrlPanelState.Stop:
                    ExamStop();
                    break;
                case Modules.ExamCtrlPanelModule.CtrlPanelState.Pass:
                    ExamPass(args.Msg);
                    break;
                case Modules.ExamCtrlPanelModule.CtrlPanelState.Fail:
                    ExamFail(args.Msg);
                    break;
            }
        }

         
       
        //protected abstract void ExamStart();
        protected virtual void ExamStart()
        {
            if (this.StudentExamChange != null)
            {
                if(cand.HuiHeShu==0)
                    this.StudentExamChange(cand.Xm + ",���ϳ�,��ʼ����!");
                else
                    this.StudentExamChange(cand.Xm + ",�ڶ��غϿ�ʼ����!");
            }
        }

        //protected abstract void ExamStop();
        protected virtual void ExamStop()
        { }

        protected virtual void ExamPass(string msg)
        {
            if (cand != null)
            {
                cand.Kscj = 1;
                cand.HuiHeShu = examTimes + 1;

                if (cand.HuiHeShu == 1)
                    cand.KS1 = msg;
                if (cand.HuiHeShu == 2)
                    cand.KS2 = msg;

                if (this.StudentExamChange != null)
                {
                    this.StudentExamChange(cand.Xm + "," + msg + ",���Խ���!");
                }

                //��ʾ����ͨ��
                if (this.InvokeRequired)
                {
                    NotifyDelegate doNotify = new NotifyDelegate(DoShowMsgBox);
                    this.Invoke(doNotify, msg);
                }
                else
                    DoShowMsgBox(msg);

                if (DoStore())
                {
                    if (this._printContent != null)
                    {
                        if ((new Modules.ScoreModule.frmMessageBox()).ShowDialog() == DialogResult.Yes)
                            DoPrint();
                    }
                }
            }
        }

        protected virtual void ExamFail(string msg)
        {
            if (cand != null)
            {
                cand.Kscj = 0;
                cand.HuiHeShu = examTimes + 1;

                if (cand.HuiHeShu == 1)
                {
                    cand.KS1 = msg;
                    if (this.StudentExamChange != null)
                    {
                        this.StudentExamChange(cand.Xm + "," + msg + ",��һ�غϽ������뽫��������㡣");
                    }

                    //��ʾ����ͨ��
                    if (this.InvokeRequired)
                    {
                        NotifyDelegate doNotify = new NotifyDelegate(DoShowMsgBox);
                        this.Invoke(doNotify, msg);
                    }
                    else
                        DoShowMsgBox(msg);
                }
                if (cand.HuiHeShu == 2)
                {
                    cand.KS2 = msg;
                    if (this.StudentExamChange != null)
                    {
                        this.StudentExamChange(cand.Xm + "," + msg + ",���Խ�����");
                       
                    }

                    //��ʾ����ͨ��
                    if (this.InvokeRequired)
                    {
                        NotifyDelegate doNotify = new NotifyDelegate(DoShowMsgBox);
                        this.Invoke(doNotify, msg);
                    }
                    else
                        DoShowMsgBox(msg);

                    if (DoStore())
                    {
                        if (this._printContent != null)
                        {
                            if (settings.PrintConfig.IsprintNopass)
                               if ((new Modules.ScoreModule.frmMessageBox()).ShowDialog() == DialogResult.Yes)
                                    DoPrint();
                        }
                    }
                }


               
            }
        }



        protected virtual void DoPrint()
        {
            try
            {
               
                //this._printContent.ksrqstr = System.DateTime.Now.ToString("yyyy  MM  dd", DateTimeFormatInfo.InvariantInfo);
                this._printContent.ksrqstr = System.DateTime.Now.ToString();

                if (cand.Kscj == 1)
                    this._printContent.kscjstr = "�ϸ�";
                else
                    this._printContent.kscjstr = "���ϸ�";

                this._printContent.ksxmstr = "";
                this._printContent.ksyxmstr = "";

                switch (cand.Kscs)
                {
                    case 1:
                        this._printContent.ksddstr = settings.KSDD;
                        this._printContent.ksxmstr = cand.Xm;
                        this._printContent.kscxstr = cand.Kscx;
                        this._printContent.ksyxmstr = cand.Ksy1 + "  " + cand.Ksy2;
                        break;
                    case 2:
                        this._printContent.kscjtxt.mmY = settings.PrintConfig.Kscj_y + 8;
                        this._printContent.ksrqtxt.mmY = settings.PrintConfig.Ksrq_y + 8;
                        break;
                    case 3:
                        this._printContent.kscjtxt.mmY = settings.PrintConfig.Kscj_y + 16;
                        this._printContent.ksrqtxt.mmY = settings.PrintConfig.Ksrq_y + 16;
                        break;
                    case 4:
                        this._printContent.kscjtxt.mmY = settings.PrintConfig.Kscj_y + 24;
                        this._printContent.ksrqtxt.mmY = settings.PrintConfig.Ksrq_y + 24;
                        break;

                }
              

                this._printContent.Print();

            }
            catch
            {
                MessageBox.Show("��ӡʧ��,�����ӡ���Ƿ����Ӻã�");
            }
        }

        protected virtual bool DoStore()
        {
            //MessageBox.Show("Do Store.");
            try
            {
                Modules.ScoreModule.DALStudent student = new Modules.ScoreModule.DALStudent();
                if (cand != null)
                    student.Insert(cand);
                return true;
            }
            catch 
            {
                //MessageBox.Show("���ݿ��д����");
                if (this.InvokeRequired)
                {
                    NotifyDelegate doNotify = new NotifyDelegate(DoShowMsgBox);
                    this.Invoke(doNotify, "���ݿ��д����");
                }
                else
                    DoShowMsgBox("���ݿ��д����");
                return false;
            }
        }

        private delegate void NotifyDelegate(string newText);
        private void DoShowMsgBox(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
