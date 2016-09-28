using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Cn.Youdundianzi.Share.Util.Motor
{
    public class MotorSignalSettings : CSettings
    {
        //Exam超时时间设置
        private int _examTimeOut;
        [DescriptionAttribute("考试超时时间(秒)"), CategoryAttribute("延时设置")]
        public int ExamTimeOutDelay
        {
            get { return _examTimeOut; }
            set { _examTimeOut = value; }
        }

        private DelayConfig _delayConfig = new DelayConfig();
        [DescriptionAttribute("状态延时设置"), CategoryAttribute("延时设置")]
        public DelayConfig StateDelayConfig
        {
            get { return _delayConfig; }
            set { _delayConfig = value; }
        }

        /**
         * //移至CSettings
        private Appearance _modelAppearance = new Appearance();
        [DescriptionAttribute("图片路径"), CategoryAttribute("车线杆属性设置")]
        public Appearance ModelAppearance
        {
            get { return _modelAppearance; }
            set { _modelAppearance = value; }
        }
         * */

        /**
         * //移至CSettings
        private InitialPosition _modelInitPos = new InitialPosition();
        [DescriptionAttribute("初始位置"), CategoryAttribute("车线杆属性设置")]
        public InitialPosition InitPosition
        {
            get { return _modelInitPos; }
            set { _modelInitPos = value; }
        }
         * */

        /**
         * //移至CSettings
        private int[] _stateDur = new int[4];
        [DescriptionAttribute("动画移动速度"), CategoryAttribute("车线杆属性设置")]
        public int[] StateDuration
        {
            get { return _stateDur; }
            set { _stateDur = value; }
        }
         * */
    }
   
    /*
     * //移至CSettings
    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("初始位置")]
    public class InitialPosition
    {
        private GanPosition[] _gan = new GanPosition[5];
        [DescriptionAttribute("杆位置")]
        public GanPosition[] Gan
        {
            get { return _gan; }
            set { _gan = value; }
        }
        private XianPosition[] _xian = new XianPosition[5];
        [DescriptionAttribute("线位置")]
        public XianPosition[] Xian
        {
            get { return _xian; }
            set { _xian = value; }
        }
        private ChePosition _che = new ChePosition();
        [DescriptionAttribute("车位置")]
        public ChePosition Che
        {
            get { return _che; }
            set { _che = value; }
        }
    }
     * */

    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("状态延时设置")]
    public class DelayConfig
    {
        //起步到第一次穿过5线的最大时间间隔
        private int _delay1;
        [DescriptionAttribute("起步到第一次穿过5线的最大时间间隔")]
        public int Delay1
        {
            get { return _delay1; }
            set { _delay1 = value; }
        }

        //穿过5线的最大时间间隔
        private int _delay2;
        [DescriptionAttribute("穿过5线的最大时间间隔")]
        public int Delay2
        {
            get { return _delay2; }
            set { _delay2 = value; }
        }

        //两次穿过5线的最大时间间隔
        private int _delay3;
        [DescriptionAttribute("两次穿过5线的最大时间间隔")]
        public int Delay3
        {
            get { return _delay3; }
            set { _delay3 = value; }
        }

        //最后一次穿过5线到结束的最大时间间隔
        private int _delay4;
        [DescriptionAttribute("最后一次穿过5线到结束的最大时间间隔")]
        public int Delay4
        {
            get { return _delay4; }
            set { _delay4 = value; }
        }

        //第一次压3线到压4线的时间间隔
        private int _delay5;
        [DescriptionAttribute("第一次压3线到压4线的时间间隔")]
        public int Delay5
        {
            get { return _delay5; }
            set { _delay5 = value; }
        }

        //压4线到第二次压3线的时间间隔
        private int _delay6;
        [DescriptionAttribute("压4线到第二次压(两轮为离开)3线的时间间隔")]
        public int Delay6
        {
            get { return _delay6; }
            set { _delay6 = value; }
        }

        //离线状态最小时间间隔（秒）
        private int _minLeaveDelay;
        [DescriptionAttribute("离线状态最小时间间隔")]
        public int MinLeaveDelay
        {
            get { return _minLeaveDelay; }
            set { _minLeaveDelay = value; }
        }

        //压线状态最小时间间隔（秒）
        private int _minBlockDelay;
        [DescriptionAttribute("压线状态最小时间间隔")]
        public int MinBlockDelay
        {
            get { return _minBlockDelay; }
            set { _minBlockDelay = value; }
        }
    }
}



