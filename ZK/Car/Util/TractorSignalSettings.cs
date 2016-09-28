using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Cn.Youdundianzi.Share.Util.Tractor
{
    public class TractorSignalSettings : CSettings
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

    }
    
    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("状态延时设置")]
    public class DelayConfig
    {
        //在状态F2,F3,F5,F6,F7_2,B2,B3,B5,B6,B7_2时，为防止漏检查信号而再次检查的超时时间
        private int _delay1;
        [DescriptionAttribute("在状态F2,F3,F5,F6,B2,B3,B5,B6时，为防止漏检查信号而再次检查的超时时间。")]
        public int Delay1
        {
            get { return _delay1; }
            set { _delay1 = value; }
        }

        private int _delay2;
        [DescriptionAttribute("在状态B8时，等待检查四周线的时间。")]
        public int Delay2
        {
            get { return _delay2; }
            set { _delay2 = value; }
        }

        private int _delay3;
        [DescriptionAttribute("在进乙库和退到甲库的时候，等待开始检查2线的时间。")]
        public int Delay3
        {
            get { return _delay3; }
            set { _delay3 = value; }
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



