using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Cn.Youdundianzi.Share.Util.Motor
{
    public class MotorSignalSettings : CSettings
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

        /**
         * //����CSettings
        private Appearance _modelAppearance = new Appearance();
        [DescriptionAttribute("ͼƬ·��"), CategoryAttribute("���߸���������")]
        public Appearance ModelAppearance
        {
            get { return _modelAppearance; }
            set { _modelAppearance = value; }
        }
         * */

        /**
         * //����CSettings
        private InitialPosition _modelInitPos = new InitialPosition();
        [DescriptionAttribute("��ʼλ��"), CategoryAttribute("���߸���������")]
        public InitialPosition InitPosition
        {
            get { return _modelInitPos; }
            set { _modelInitPos = value; }
        }
         * */

        /**
         * //����CSettings
        private int[] _stateDur = new int[4];
        [DescriptionAttribute("�����ƶ��ٶ�"), CategoryAttribute("���߸���������")]
        public int[] StateDuration
        {
            get { return _stateDur; }
            set { _stateDur = value; }
        }
         * */
    }
   
    /*
     * //����CSettings
    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("��ʼλ��")]
    public class InitialPosition
    {
        private GanPosition[] _gan = new GanPosition[5];
        [DescriptionAttribute("��λ��")]
        public GanPosition[] Gan
        {
            get { return _gan; }
            set { _gan = value; }
        }
        private XianPosition[] _xian = new XianPosition[5];
        [DescriptionAttribute("��λ��")]
        public XianPosition[] Xian
        {
            get { return _xian; }
            set { _xian = value; }
        }
        private ChePosition _che = new ChePosition();
        [DescriptionAttribute("��λ��")]
        public ChePosition Che
        {
            get { return _che; }
            set { _che = value; }
        }
    }
     * */

    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("״̬��ʱ����")]
    public class DelayConfig
    {
        //�𲽵���һ�δ���5�ߵ����ʱ����
        private int _delay1;
        [DescriptionAttribute("�𲽵���һ�δ���5�ߵ����ʱ����")]
        public int Delay1
        {
            get { return _delay1; }
            set { _delay1 = value; }
        }

        //����5�ߵ����ʱ����
        private int _delay2;
        [DescriptionAttribute("����5�ߵ����ʱ����")]
        public int Delay2
        {
            get { return _delay2; }
            set { _delay2 = value; }
        }

        //���δ���5�ߵ����ʱ����
        private int _delay3;
        [DescriptionAttribute("���δ���5�ߵ����ʱ����")]
        public int Delay3
        {
            get { return _delay3; }
            set { _delay3 = value; }
        }

        //���һ�δ���5�ߵ����������ʱ����
        private int _delay4;
        [DescriptionAttribute("���һ�δ���5�ߵ����������ʱ����")]
        public int Delay4
        {
            get { return _delay4; }
            set { _delay4 = value; }
        }

        //��һ��ѹ3�ߵ�ѹ4�ߵ�ʱ����
        private int _delay5;
        [DescriptionAttribute("��һ��ѹ3�ߵ�ѹ4�ߵ�ʱ����")]
        public int Delay5
        {
            get { return _delay5; }
            set { _delay5 = value; }
        }

        //ѹ4�ߵ��ڶ���ѹ3�ߵ�ʱ����
        private int _delay6;
        [DescriptionAttribute("ѹ4�ߵ��ڶ���ѹ(����Ϊ�뿪)3�ߵ�ʱ����")]
        public int Delay6
        {
            get { return _delay6; }
            set { _delay6 = value; }
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



