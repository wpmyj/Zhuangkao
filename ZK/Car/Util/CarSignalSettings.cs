using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Cn.Youdundianzi.Share.Util.Car
{
    public class CarSignalSettings : CSettings
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
        //进出库穿越7线时，离开7线的最大时间间隔。
        private int _delay1;
        [DescriptionAttribute("进出库穿越7线时，离开7线的最大时间间隔。")]
        public int Delay1
        {
            get { return _delay1; }
            set { _delay1 = value; }
        }

        //进库/倒库时离开4至压8线/停车的最大时间间隔（超过即超时）
        private int _delay2;
        [DescriptionAttribute("进库//倒库时离开4至压8线//停车的最大时间间隔（超过即超时）")]
        public int Delay2
        {
            get { return _delay2; }
            set { _delay2 = value; }
        }

        //若离开4、7线的时间超过本设置，则认定离开4、7线
        private int _delay3;
        [DescriptionAttribute("若离开4、7线的时间超过本设置，则认定离开4、7线")]
        public int Delay3
        {
            get { return _delay3; }
            set { _delay3 = value; }
        }

        //移库二退压8线后最大延时
        private int _delay4;
        [DescriptionAttribute("移库二退压8线后最大延时")]
        public int Delay4
        {
            get { return _delay4; }
            set { _delay4 = value; }
        }

        //斜出库到倒库时离开1线最小时间间隔
        private int _delay5;
        [DescriptionAttribute("斜出库到倒库时离开1线最小时间间隔。或斜出库离开4线到停车的最大等待时间（纯车信号）")]
        public int Delay5
        {
            get { return _delay5; }
            set { _delay5 = value; }
        }

        //斜出库/出库离开4线到再压住2/3线的最小时间间隔
        private int _delay6;
        [DescriptionAttribute("斜出库//出库离开4线到再压住2//3线的最小时间间隔。")]
        public int Delay6
        {
            get { return _delay6; }
            set { _delay6 = value; }
        }

        //进库线/倒库线为2时，离开2线的延时。超过该延时再压2线，则报压线
        private int _delay7;
        [DescriptionAttribute("进库线//倒库线为2时，离开2线的延时。超过该延时再压2线，则报压线")]
        public int Delay7
        {
            get { return _delay7; }
            set { _delay7 = value; }
        }

        //进库线/倒库线为1/3时，离开1/3线的延时。超过该延时再压1//3线，则报压线
        private int _delay8;
        [DescriptionAttribute("进库线//倒库线为1//3时，离开1//3线的延时。超过该延时再压1//3线，则报压线")]
        public int Delay8
        {
            get { return _delay8; }
            set { _delay8 = value; }
        }

        //进库到移库/倒库到出库时停车到报语音之间的延时
        private int _delay9;
        [DescriptionAttribute("进库到移库//倒库到出库时停车到报语音之间的延时（有语音提示时时间稍长，无语音提示时时间稍短）")]
        public int Delay9
        {
            get { return _delay9; }
            set { _delay9 = value; }
        }

        //斜出库停车到报语音之间的延时
        private int _delay10;
        [DescriptionAttribute("斜出库停车到报语音之间的延时（有语音提示时时间稍长，无语音提示时时间稍短）")]
        public int Delay10
        {
            get { return _delay10; }
            set { _delay10 = value; }
        }

        //倒库停车到报语音之间的延时
        private int _delay11;
        [DescriptionAttribute("倒库停车到报语音之间的延时（有语音提示时时间稍长，无语音提示时时间稍短）")]
        public int Delay11
        {
            get { return _delay11; }
            set { _delay11 = value; }
        }

        //移库压二线最短时间。压二线的时间如果小于本时间，则认为未发生移库。
        private int _delay12;
        [DescriptionAttribute("移库压二线最短时间。压二线的时间如果小于本时间，则认为未发生移库。")]
        public int Delay12
        {
            get { return _delay12; }
            set { _delay12 = value; }
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



