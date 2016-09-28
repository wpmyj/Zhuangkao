using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Share.Module.Print;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Module.ExamCtrl;
using System.Globalization;
using Cn.Youdundianzi.Share.Module.Score;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Share.Module.CandidateInfo
{
    public delegate void MessageDelegate(string msg);
    public delegate void IntegerDelegate(int i);
    public delegate void ExamResultDelegate(int huihe, string result);

    //考虑到软件继承和扩展性 界面改完后,需要还原注释程序(貌似还原不回去了)注释地方有四处：
    //-------------------------------------------------------------------------
    //1.public abstract  class CandExamCtrl : UserControl, ICandidateInfoReader
    //2.protected abstract void ResetPanel();
    //3.protected abstract void ExamStart();
    //4.protected abstract void ExamStop();
    //---------------------------------------------------------------------------


    public abstract  class CandExamCtrl : UserControl, ICandidateInfoReader
    //public   class CandExamCtrl : UserControl, ICandidateInfoReader
    {

        //声音事件
        public MessageDelegate SoundChange;
        protected virtual void OnSoundChange(string msg)
        {
        }

        //显示牌事件
        public MessageDelegate LEDDisplayChange;
        protected virtual void OnLEDDisplayChange(string msg)
        {
        }

        //摄像头Channel事件
        public IntegerDelegate CameraChannelChange;
        protected virtual void OnCameraChannelChange(int i)
        {
        }

        //结果事件
        public ExamResultDelegate ExamResultReady;
        protected virtual void OnExamResultReady(int huihe, string result)
        {
        }

        protected int examTimes = 0;
        public void InitializeCandExamCtrlComponent(ExamCtrlPanel examCtrl, CSettings settings, List<string> cxList)
        {
            this.examCtrl = examCtrl;
            this.examCtrl.OnChangeState += new ExamCtrlPanelEvent(this.examCtrl_stateChange);
            this.settings = settings;
            if (this.settings.PrintConfig.Isprint)
            {
                _printContent = new CPrintContent(this.settings.PrintConfig);
            }
            if (cxList != null)
                _cxList = cxList;
            else
                _cxList = new List<string>(1);
            this.SoundChange += new MessageDelegate(OnSoundChange);
            this.LEDDisplayChange += new MessageDelegate(OnLEDDisplayChange);
            this.CameraChannelChange += new IntegerDelegate(OnCameraChannelChange);
            this.ExamResultReady += new ExamResultDelegate(OnExamResultReady);
            ResetPanel();
        }

        private List<string> _cxList = new List<string>(1);
        public List<string> CXList
        {
            get { return _cxList; }
        }

        protected abstract void ResetPanel();

        protected CSettings settings;
        private ExamCtrlPanel examCtrl;
        public ExamCtrlPanel ExamCtrl
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

        protected void examCtrl_stateChange(object sender, StateChangeEventArgs args)
        {
            switch (args.State)
            {
                case CtrlPanelState.Start:
                    ExamStart();
                    break;
                case CtrlPanelState.Stop:
                    ExamStop();
                    break;
                case CtrlPanelState.Pass:
                    ExamPass(args.Msg);
                    break;
                case CtrlPanelState.Fail:
                    ExamFail(args.Msg);
                    break;
            }
        }
       
        protected abstract void ExamStart();

        protected abstract void ExamStop();

        protected abstract void ExamPass(string msg);

        protected abstract void ExamFail(string msg);

        protected virtual void DoPrint()
        {
            try
            {
               
                //this._printContent.ksrqstr = System.DateTime.Now.ToString("yyyy  MM  dd", DateTimeFormatInfo.InvariantInfo);
                this._printContent.ksrqstr = System.DateTime.Now.ToString();

                if (cand.Kscj == 1)
                    this._printContent.kscjstr = "合格";
                else
                    this._printContent.kscjstr = "不合格";

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
                MessageBox.Show("打印失败,请检查打印机是否连接好！");
            }
        }

        protected virtual bool DoStore()
        {
            try
            {
                DALStudent student = new DALStudent();
                if (cand != null)
                    student.Insert(cand);
                return true;
            }
            catch 
            {
                ShowMsgBox(this, "数据库读写错误");
                return false;
            }
        }

        //关闭资源
        public virtual void CloseResources()
        { }

        private delegate void NotifyDelegate(string newText);
        private void DoShowMsgBox(string msg)
        {
            MessageBox.Show(msg);
        }

        protected void ShowMsgBox(UserControl ctrl, string msg)
        {
            if (ctrl.InvokeRequired)
            {
                NotifyDelegate doNotify = new NotifyDelegate(DoShowMsgBox);
                ctrl.Invoke(doNotify, msg);
            }
            else
                DoShowMsgBox(msg);
        }

        private delegate void SetTextDelegate(Control ctrl, string newText);
        protected void SetText(Control ctrl, string newText)
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

        private delegate void SetEnableDelegate(Control ctrl, bool enable);

        protected void EnableAndSetText(Control ctrl, bool enable, string newText)
        {
            EnableCtrl(ctrl, enable);
            SetText(ctrl, newText);
        }
        protected void EnableCtrl(Control ctrl, bool enable)
        {
            if (ctrl.InvokeRequired)
            {
                SetEnableDelegate setEnable = new SetEnableDelegate(EnableCtrl);
                ctrl.Invoke(setEnable, ctrl, enable);
            }
            else
            {
                ctrl.Enabled = enable;
            }
        }
    }
}
