using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Exam;

namespace Modules.ExamCtrlPanelModule
{
    public partial class ExamStatusDisplayPanel : UserControl, IExamObserver
    {
        StateManager stateMgr;

        public ExamStatusDisplayPanel()
        {
            InitializeComponent();
        }

        public void InitializeExamComponent(StateManager sm)
        {
            this.stateMgr = sm;
            stateMgr.RegExamObserver(this);
        }

        #region IExamObserver Members

        public void Notify(Exam.Exam exam)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void Notify(IState state)
        {
            if (this.labelXStatus.InvokeRequired)
            {
                NotifyDelegate doNotify = new NotifyDelegate(DoNotify);
                this.labelXStatus.Invoke(doNotify, state);
            }
            else
                DoNotify(state);
        }
        private delegate void NotifyDelegate(IState state);
        private void DoNotify(IState state)
        {
            labelXStatus.Text = state.DisplayName;
        }

        #endregion
    }
}
