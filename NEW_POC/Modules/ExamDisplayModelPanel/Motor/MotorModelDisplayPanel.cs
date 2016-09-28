using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Exam;
using Exam.State;
using Exam.State.MotorState;
using Util;
using Shared;
using Signal;
using Signal.MotorSignal;

namespace Modules.ExamDisplayModelPanel.Motor
{
    public partial class MotorModelDisplayPanel : UserControl, IMonObserver, IExamObserver
    {
        private MotorSignalSettings settings;
        private MotorMonitor monitor;
        private MotorStateManager statemgr;

        private CDisplayManager cdm;
        private CGanFairy[] gan = new CGanFairy[5]; //杆类型，在CDisplayManager注册即可显示
        private CLineFairy[] xian = new CLineFairy[5];//线类型
        private CBmpFairy che;//车类型
        private Bitmap[] ganbm = new Bitmap[3];//杆的显示图片，包含有信号无信号及屏蔽

        private int[] stateDuration;

        private Timer timer;

        public MotorModelDisplayPanel()
        {
            InitializeComponent();
            this.cdm = new CDisplayManager();
        }

        public void InitializeExamComponent(CSettings set, IMonitor mon, StateManager sm)
        {
            this.settings = (MotorSignalSettings)set;
            this.monitor = (MotorMonitor)mon;
            this.statemgr = (MotorStateManager)sm;

            monitor.RegMonitor(this);
            statemgr.RegExamObserver(this);

            ganbm[0] = new Bitmap(settings.ModelAppearance.Gan.Normal);
            ganbm[1] = new Bitmap(settings.ModelAppearance.Gan.Error);
            ganbm[2] = new Bitmap(settings.ModelAppearance.Gan.Shield);

            for (int i = 0; i < 5; i++)
            {
                gan[i] = new CGanFairy(ganbm);
                gan[i].GanName = (i + 1).ToString();
            }

            for (int i = 0; i < 5; i++)
            {
                XianPosition x = settings.InitPosition.Xian[i];
                xian[i] = new CLineFairy(x.X1, x.Y1, x.X2, x.Y2);
                xian[i].LineName = (i + 1).ToString();
                cdm.RegDisplay(xian[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                GanPosition gp = settings.InitPosition.Gan[i];
                gan[i].X = gp.X;
                gan[i].Y = gp.Y-10;
                cdm.RegDisplay(gan[i]);
            }

            che = new CBmpFairy(settings.ModelAppearance.Che.Normal);
            cdm.RegDisplay(che);

            ResetElements();

            stateDuration = new int[4];

            stateDuration[0] = settings.StateDuration[0];
            stateDuration[1] = settings.StateDuration[1];
            stateDuration[2] = settings.StateDuration[2];
            stateDuration[3] = settings.StateDuration[3];

            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();//屏幕刷新启动
        }

        #region IExamObserver Members

        public void Notify(Exam.Exam exam)
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
        }

        public void Notify(IState state)
        {
            MotorBaseState mstate = (MotorBaseState)state;

            switch (mstate.Name)
            {
                case "IDLE":
                    ResetElements();
                    break;
                case "KS":
                    che.Moveto(25, 233, true);
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
                    switch (statemgr.C5Time)
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
                            che.Speed = stateDuration[2];
                            che.Moveto(346, 167, true);
                            break;
                        case 6:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(270, 233, true);
                            break;
                        case 7:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(216, 167, true);
                            break;
                        case 8:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(160, 233, true);
                            break;
                        case 9:
                            che.JempStop();
                            che.Speed = stateDuration[1];
                            che.Moveto(101, 167, true);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region IMonObserver Members

        public void Notify(CMonData data)
        {
            CSignals g = data.GetSignals(SignalType.GAN);
            for (int i = 0; i < 5; i++)
            {
                gan[i].Stat = g[i];
            }

            CSignals x = data.GetSignals(SignalType.XIAN);
            for (int i = 0; i < 5; i++)
            {
                xian[i].Stat = x[i];
            }
        }

        #endregion

        private void ResetElements()
        {
            che.SetWeizhi(settings.InitPosition.Che.X, settings.InitPosition.Che.Y);
            che.SetRangle(settings.InitPosition.Che.Angle);
            che.Speed = 1;
            che.RSpeed = 6;

            //---读配置文件屏蔽杆，线，车信号
            for (int i = 0; i < 5; i++)
            {
                if (((settings.SignConfig.PBGan >> i) & 1) == 1)
                {
                    gan[i].Stat = -1;
                }
                if (((settings.SignConfig.PBXian >> i) & 1) == 1)
                {
                    xian[i].Stat = -1;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.picBoxModelBackGround.Refresh();
        }

        private void picBoxModelBackGround_Paint(object sender, PaintEventArgs e)
        {
            cdm.DisplayAll(e.Graphics);
        }
    }
}
