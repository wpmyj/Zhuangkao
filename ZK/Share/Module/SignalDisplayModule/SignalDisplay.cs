using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Share.Module.SignalDisplay
{
    //系统信号显示控件
    public partial class SignalDisplay : UserControl, IMonObserver
    {

        protected ISignalMonitor monitor;
        public SignalDisplay(ISignalMonitor mon)
        {
            InitializeComponent();
            monitor = mon;
            monitor.RegMonitor(this);  
        }

        private delegate void SetTextDelegate(Control ctrl, string newText);
        private void SetText(Control ctrl, string newText)
        {
            if (ctrl.InvokeRequired)
            {
                //ctrl.Invoke(new SetTextDelegate(SetText), ctrl, newText);
                ctrl.BeginInvoke(new SetTextDelegate(SetText), ctrl, newText);
            }
            else
            {
                ctrl.Text = newText;
            }
        }

        #region IMonObserver Members
        public virtual void Notify(IMonData data)
        {
           //杆信号
            CSignals g = data.GetSignals(SignalType.GAN);
            string strGanState = "杆：";
            for (int i = 0; i < g.Length; i++)
            {
                if (g[i]!=-1)
                    strGanState = strGanState + " " + g[i];
                else
                    strGanState = strGanState + " " + g[i];

            }
            SetText(gan_label, strGanState);

            //线信号
            CSignals x = data.GetSignals(SignalType.XIAN);
            string strXianState = "线：";
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i]!=-1)
                   strXianState = strXianState + " " + x[i];
                else
                   strXianState = strXianState + " " + x[i];
            }
            SetText(xian_label, strXianState);

            //车信号
            CSignals c = data.GetSignals(SignalType.CHE);
            if (c[0] == 1)
            {
                SetText(che_label, "车：  前进");
            }
            if (c[1] == 1)
            {
                SetText(che_label, "车：  后退");
            }
            if (c[2] == 1)
            {
                SetText(che_label, "车：  停车");
            }
            if (c[3] == 1)
            {
                SetText(che_label, "车：  熄火");
            }
        }
        #endregion
    }
}
