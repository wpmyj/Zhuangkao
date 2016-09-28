using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Cn.Youdundianzi.Share.Util.Tractor
{
    public class TractorSignalSettings : CSettings
    {
        //Exam��ʱʱ������
        private int _examTimeOut;
        [DescriptionAttribute("���Գ�ʱʱ��(��)"), CategoryAttribute("��ʱ����")]
        public int ExamTimeOutDelay
        {
            get { return _examTimeOut; }
            set { _examTimeOut = value; }
        }

        private DelayConfig _delayConfig = new DelayConfig();
        [DescriptionAttribute("״̬��ʱ����"), CategoryAttribute("��ʱ����")]
        public DelayConfig StateDelayConfig
        {
            get { return _delayConfig; }
            set { _delayConfig = value; }
        }

    }
    
    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("״̬��ʱ����")]
    public class DelayConfig
    {
        //��״̬F2,F3,F5,F6,F7_2,B2,B3,B5,B6,B7_2ʱ��Ϊ��ֹ©����źŶ��ٴμ��ĳ�ʱʱ��
        private int _delay1;
        [DescriptionAttribute("��״̬F2,F3,F5,F6,B2,B3,B5,B6ʱ��Ϊ��ֹ©����źŶ��ٴμ��ĳ�ʱʱ�䡣")]
        public int Delay1
        {
            get { return _delay1; }
            set { _delay1 = value; }
        }

        private int _delay2;
        [DescriptionAttribute("��״̬B8ʱ���ȴ���������ߵ�ʱ�䡣")]
        public int Delay2
        {
            get { return _delay2; }
            set { _delay2 = value; }
        }

        private int _delay3;
        [DescriptionAttribute("�ڽ��ҿ���˵��׿��ʱ�򣬵ȴ���ʼ���2�ߵ�ʱ�䡣")]
        public int Delay3
        {
            get { return _delay3; }
            set { _delay3 = value; }
        }

        //����״̬��Сʱ�������룩
        private int _minLeaveDelay;
        [DescriptionAttribute("����״̬��Сʱ����")]
        public int MinLeaveDelay
        {
            get { return _minLeaveDelay; }
            set { _minLeaveDelay = value; }
        }

        //ѹ��״̬��Сʱ�������룩
        private int _minBlockDelay;
        [DescriptionAttribute("ѹ��״̬��Сʱ����")]
        public int MinBlockDelay
        {
            get { return _minBlockDelay; }
            set { _minBlockDelay = value; }
        }
    }
}



