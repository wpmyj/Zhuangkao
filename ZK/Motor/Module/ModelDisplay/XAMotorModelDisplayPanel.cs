using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Exam;
using Cn.Youdundianzi.Exam.State;
using Cn.Youdundianzi.Share.Signal.Motor;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Util.Motor;
using Cn.Youdundianzi.Share.Module.ModelDisplay;

namespace Cn.Youdundianzi.Share.Module.ModelDisplay.Motor
{
    public class XAMotorModelDisplayPanel : BaseModelDisplayPanel
    {
        private IMotorStateManager _sm;
        private ISignalMonitor _sigMon;

        public XAMotorModelDisplayPanel()
            : base()
        {
        }

        public override void InitializeExamComponent(CSettings set, ISignalMonitor mon, IStateManager sm)
        {
            base.InitializeExamComponent(set, mon, sm);
            _sm = sm as IMotorStateManager;
        }

        #region IExamObserver Members

        public override void Notify(CExam exam)
        {
            if (!exam.Passed)
            {
                //若要改变出错时模型车位置，请调整此处代码。
                //可再为每种ResultType添加switch(exam.Message.Index)，
                //以细化针对不同杆线错误时，模型车的位置
                switch (exam.Message.TypeOfResult)
                {
                    case ResultType.Gan:
                        che.SetWeizhi(gan[exam.Message.Index].X, gan[exam.Message.Index].Y);
                        break;
                    case ResultType.Xian:
                        switch (exam.Message.Index)
                        {
                            case 0:
                            case 2:
                                che.SetWeizhi(xian[exam.Message.Index].X1,che.Y);
                                break;
                            case 1:
                            case 3:
                            case 4:
                                che.SetWeizhi(che.X,xian[exam.Message.Index].Y1);
                                break;
                        }
                        break;
                    case ResultType.ZT:
                        che.SetWeizhi(che.X, che.Y);
                        break;
                    case ResultType.XH:
                        che.SetWeizhi(che.X, che.Y);
                        break;
                    case ResultType.LXC:
                        che.SetWeizhi(che.X, che.Y);
                        break;
                    case ResultType.TimeOut:
                        che.SetWeizhi(che.X, che.Y);
                        break;
                    default:
                        break;
                }
            }
            IMonData data = monitor.CurrData;
            CSignals g = data.GetSignals(SignalType.GAN);
            for (int i = 0; i < g.Length; i++)
            {
                gan[i].Stat = g[i];
            }

            CSignals x = data.GetSignals(SignalType.XIAN);
            for (int i = 0; i < x.Length; i++)
            {
                xian[i].Stat = x[i];
            }

            if (this.picBoxModelBackGround.InvokeRequired)
            {
                NotifyDelegate doNotify = new NotifyDelegate(DoNotify);
                this.picBoxModelBackGround.Invoke(doNotify);
            }
            else
                DoNotify();
        }

        private delegate void NotifyDelegate();
        private void DoNotify()
        {
            this.picBoxModelBackGround.Refresh();
        }

        public override void Notify(IState state)
        {
            IState mstate = state;

            switch (mstate.Name)
            {
                case "IDLE":
                //    ResetElements();
                    che.SetWeizhi(che.X, che.Y);
                    break;
                case "KS":
                    ResetElements();
                    //che.Moveto(25, 233, true);
                    break;
                case "Y1":
                    che.JempStop();
                    che.Speed = stateDuration[0];
                    che.Moveto(101, 233, true);
                    break;
                case "Z1":
                    che.JempStop();
                    che.Speed = stateDuration[0];
                    che.Moveto(25, 167, true);
                    break;
                case "C5":
                    switch (_sm.C5Time)
                    {
                        case 1:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(160, 167, true);
                            break;
                        case 2:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(216, 233, true);
                            break;
                        case 3:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(270, 167, true);
                            break;
                        case 4:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(346, 233, true);
                            break;
                        case 5:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(270, 233, true);
                            break;
                        case 6:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(216, 167, true);
                            break;
                        case 7:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(160, 233, true);
                            break;
                        case 8:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(101, 167, true);
                            break;
                        default:
                            break;
                    }
                    break;
                case "ZWKS":
                    che.JempStop();
                    che.Speed = stateDuration[2];
                    che.Moveto(346, 167, true);
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
