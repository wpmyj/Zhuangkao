using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Cn.Youdundianzi.Share.Util.Car
{
    public class CarSignalSettings : CSettings
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
        //�����⴩Խ7��ʱ���뿪7�ߵ����ʱ������
        private int _delay1;
        [DescriptionAttribute("�����⴩Խ7��ʱ���뿪7�ߵ����ʱ������")]
        public int Delay1
        {
            get { return _delay1; }
            set { _delay1 = value; }
        }

        //����/����ʱ�뿪4��ѹ8��/ͣ�������ʱ��������������ʱ��
        private int _delay2;
        [DescriptionAttribute("����//����ʱ�뿪4��ѹ8��//ͣ�������ʱ��������������ʱ��")]
        public int Delay2
        {
            get { return _delay2; }
            set { _delay2 = value; }
        }

        //���뿪4��7�ߵ�ʱ�䳬�������ã����϶��뿪4��7��
        private int _delay3;
        [DescriptionAttribute("���뿪4��7�ߵ�ʱ�䳬�������ã����϶��뿪4��7��")]
        public int Delay3
        {
            get { return _delay3; }
            set { _delay3 = value; }
        }

        //�ƿ����ѹ8�ߺ������ʱ
        private int _delay4;
        [DescriptionAttribute("�ƿ����ѹ8�ߺ������ʱ")]
        public int Delay4
        {
            get { return _delay4; }
            set { _delay4 = value; }
        }

        //б���⵽����ʱ�뿪1����Сʱ����
        private int _delay5;
        [DescriptionAttribute("б���⵽����ʱ�뿪1����Сʱ��������б�����뿪4�ߵ�ͣ�������ȴ�ʱ�䣨�����źţ�")]
        public int Delay5
        {
            get { return _delay5; }
            set { _delay5 = value; }
        }

        //б����/�����뿪4�ߵ���ѹס2/3�ߵ���Сʱ����
        private int _delay6;
        [DescriptionAttribute("б����//�����뿪4�ߵ���ѹס2//3�ߵ���Сʱ������")]
        public int Delay6
        {
            get { return _delay6; }
            set { _delay6 = value; }
        }

        //������/������Ϊ2ʱ���뿪2�ߵ���ʱ����������ʱ��ѹ2�ߣ���ѹ��
        private int _delay7;
        [DescriptionAttribute("������//������Ϊ2ʱ���뿪2�ߵ���ʱ����������ʱ��ѹ2�ߣ���ѹ��")]
        public int Delay7
        {
            get { return _delay7; }
            set { _delay7 = value; }
        }

        //������/������Ϊ1/3ʱ���뿪1/3�ߵ���ʱ����������ʱ��ѹ1//3�ߣ���ѹ��
        private int _delay8;
        [DescriptionAttribute("������//������Ϊ1//3ʱ���뿪1//3�ߵ���ʱ����������ʱ��ѹ1//3�ߣ���ѹ��")]
        public int Delay8
        {
            get { return _delay8; }
            set { _delay8 = value; }
        }

        //���⵽�ƿ�/���⵽����ʱͣ����������֮�����ʱ
        private int _delay9;
        [DescriptionAttribute("���⵽�ƿ�//���⵽����ʱͣ����������֮�����ʱ����������ʾʱʱ���Գ�����������ʾʱʱ���Զ̣�")]
        public int Delay9
        {
            get { return _delay9; }
            set { _delay9 = value; }
        }

        //б����ͣ����������֮�����ʱ
        private int _delay10;
        [DescriptionAttribute("б����ͣ����������֮�����ʱ����������ʾʱʱ���Գ�����������ʾʱʱ���Զ̣�")]
        public int Delay10
        {
            get { return _delay10; }
            set { _delay10 = value; }
        }

        //����ͣ����������֮�����ʱ
        private int _delay11;
        [DescriptionAttribute("����ͣ����������֮�����ʱ����������ʾʱʱ���Գ�����������ʾʱʱ���Զ̣�")]
        public int Delay11
        {
            get { return _delay11; }
            set { _delay11 = value; }
        }

        //�ƿ�ѹ�������ʱ�䡣ѹ���ߵ�ʱ�����С�ڱ�ʱ�䣬����Ϊδ�����ƿ⡣
        private int _delay12;
        [DescriptionAttribute("�ƿ�ѹ�������ʱ�䡣ѹ���ߵ�ʱ�����С�ڱ�ʱ�䣬����Ϊδ�����ƿ⡣")]
        public int Delay12
        {
            get { return _delay12; }
            set { _delay12 = value; }
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



