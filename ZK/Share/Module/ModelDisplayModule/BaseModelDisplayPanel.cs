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
using Cn.Youdundianzi.Share.Signal;
using Cn.Youdundianzi.Share.Util;
using System.Runtime.CompilerServices;

namespace Cn.Youdundianzi.Share.Module.ModelDisplay
{
    abstract public partial class BaseModelDisplayPanel : UserControl, IMonObserver, IExamObserver
    {
        private CSettings settings;
        protected ISignalMonitor monitor;
        protected IStateManager statemgr;

        private CDisplayManager cdm;
        protected CGanFairy[] gan;    //杆类型，在CDisplayManager注册即可显示
        protected CLineFairy[] xian;  //线类型
        protected CBmpFairy che;//车类型
        private Bitmap[] ganbm = new Bitmap[3];//杆的显示图片，包含有信号无信号及屏蔽

        protected int[] stateDuration;

        private Timer timer;

        public BaseModelDisplayPanel()
        {
            InitializeComponent();
            this.cdm = new CDisplayManager();
        }

        public virtual void InitializeExamComponent(CSettings set, ISignalMonitor mon, IStateManager sm)
        {
            this.settings = set;
            this.monitor = mon;
            this.statemgr = sm;

            gan = new CGanFairy[set.InitPosition.NumOfGan];
            xian = new CLineFairy[set.InitPosition.NumOfXian];
            monitor.RegMonitor(this);
            statemgr.RegExamObserver(this);

            ganbm[0] = new Bitmap(settings.ModelAppearance.Gan.Normal);
            ganbm[1] = new Bitmap(settings.ModelAppearance.Gan.Error);
            ganbm[2] = new Bitmap(settings.ModelAppearance.Gan.Shield);

            for (int i = 0; i < set.InitPosition.NumOfXian; i++)
            {
                XianPosition x = settings.InitPosition.Xian[i];
                xian[i] = new CLineFairy(x.X1, x.Y1, x.X2, x.Y2);
                xian[i].LineName = (i + 1).ToString();
                cdm.RegDisplay(xian[i]);
            }

            for (int i = 0; i < set.InitPosition.NumOfGan; i++)
            {
                gan[i] = new CGanFairy(ganbm);
                gan[i].GanName = (i + 1).ToString();

                GanPosition gp = settings.InitPosition.Gan[i];
                gan[i].X = gp.X;
                gan[i].Y = gp.Y - 10;
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

        abstract public void Notify(CExam exam);

        abstract public void Notify(IState state);

        #endregion

        #region IMonObserver Members

        [MethodImpl(MethodImplOptions.Synchronized)]
        public virtual void Notify(IMonData data)
        {
            CSignals g = data.GetSignals(SignalType.GAN);
            for (int i = 0; i < g.Length; i++)
            {
                try
                {
                    gan[i].Stat = g[i];
                }
                catch (NullReferenceException nilRefe)
                {
                }
            }

            CSignals x = data.GetSignals(SignalType.XIAN);
            for (int i = 0; i < x.Length; i++)
            {
                try
                {
                    xian[i].Stat = x[i];
                }
                catch (NullReferenceException nilRefe)
                {
                }
            }
        }

        #endregion

        protected virtual void ResetElements()
        {
            che.SetWeizhi(settings.InitPosition.Che.X, settings.InitPosition.Che.Y);
            che.SetRangle(settings.InitPosition.Che.Angle);
            che.Speed = 1;
            che.RSpeed = 6;

            //---读配置文件屏蔽杆，线，车信号
            for (int i = 0; i < gan.Length; i++)
            {
                if (((settings.SignConfig.PBGan >> i) & 1) == 1)
                {
                    gan[i].Stat = -1;
                }
            }
            for (int i = 0; i < xian.Length; i++)
            {
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
