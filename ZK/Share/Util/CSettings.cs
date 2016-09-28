using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Cn.Youdundianzi.Core.Util;

namespace Cn.Youdundianzi.Share.Util
{
    public enum DisplayType : byte
    {
        Zhidisp = 48,   //0x30,
        Gundisp = 49   //0x31
    }

    public enum DisplayBS
    {
        BigDisplay,
        SmallDisplay
    }

    public class CSettings : ISettings
    {
        //���Եص�
        private string _ksdd = string.Empty;
        [DescriptionAttribute("���Եص�")]
        public string KSDD
        {
            get { return _ksdd; }
            set { _ksdd = value; }
        }

        //���ݿ�IP
        private string _ipaddress;
        [DescriptionAttribute("��������IP��ַ��"), CategoryAttribute("���ݿ�����")]
        public string IPAddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        //�������ķ����� IP
        private string _serverIP;
        [DescriptionAttribute("�������ķ�����IP��ַ��")]
        public string ServerIP
        {
            get { return _serverIP; }
            set { _serverIP = value; }
        }

        //�豸���
        private int _devnum;
        [DescriptionAttribute("�豸��ţ������Ƿ�0�Ĵ����֡�")]
        public int Devnum
        {
            get { return _devnum; }
            set { _devnum = value; }
        }

        //�Ƿ��ü���ģ���ź�
        private bool _isSimulate;
        [DescriptionAttribute("�Ƿ��ü���ģ���ź�")]
        public bool IsSimulate
        {
            get { return _isSimulate; }
            set { _isSimulate = value; }
        }


        //��ȡ�źż����
        private int _delaytime;
        [DescriptionAttribute("��ȡ�źż��")]
        public int Delaytime
        {
            get { return _delaytime; }
            set { _delaytime = value; }
        }


        //д��ַ�����ַ����ʱ������
        private int _lvbodelaytime;
        [DescriptionAttribute("д��ַ�����ַ����ʱ����")]
        public int Lvbodelaytime
        {
            get { return _lvbodelaytime; }
            set { _lvbodelaytime = value; }
        }


        //�ź�����
        private SignalConfigures _signConfig = new SignalConfigures();
        [DescriptionAttribute("�ź�����")]
        public SignalConfigures SignConfig
        {
            get { return _signConfig; }
            set { _signConfig = value; }
        }


        //��ӡ����
        private PrintSettings _printSettings = new PrintSettings();
        [DescriptionAttribute("��ӡ����")]
        public PrintSettings PrintConfig
        {
            get { return _printSettings; }
            set { _printSettings = value; }
        }

        //��ʾ������
        private DisplayPanelSettings _displayPaneSettings = new DisplayPanelSettings();
        [DescriptionAttribute("��ʾ������")]
        public DisplayPanelSettings DisplayPaneConfig
        {
            get { return _displayPaneSettings; }
            set { _displayPaneSettings = value; }
        }

        //��������
        private SoundSettings _soundSettings = new SoundSettings();
        [DescriptionAttribute("��������")]
        public SoundSettings SoundConfig
        {
            get { return _soundSettings; }
            set { _soundSettings = value; }
        }

        //����ͷ����
        private CameraSettings _cameraSettings = new CameraSettings();
        [DescriptionAttribute("��������")]
        public CameraSettings CameraConfig
        {
            get { return _cameraSettings; }
            set { _cameraSettings = value; }
        }

        //���߳�ͼƬ����
        private Appearance _modelAppearance = new Appearance();
        [DescriptionAttribute("ͼƬ·��"), CategoryAttribute("���߸���������")]
        public Appearance ModelAppearance
        {
            get { return _modelAppearance; }
            set { _modelAppearance = value; }
        }

        //���߳�ģ�ͳ�ʼ��λ��
        private InitialPosition _modelInitPos = new InitialPosition();
        [DescriptionAttribute("��ʼλ��"), CategoryAttribute("���߸���������")]
        public InitialPosition InitPosition
        {
            get { return _modelInitPos; }
            set { _modelInitPos = value; }
        }

        //��ģ���ƶ��ٶ�
        private int[] _stateDur = new int[4];
        [DescriptionAttribute("�����ƶ��ٶ�"), CategoryAttribute("���߸���������")]
        public int[] StateDuration
        {
            get { return _stateDur; }
            set { _stateDur = value; }
        }
    }


    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("��λ��")]
    public class GanPosition
    {
       
        //���
        private int _index;
        [DescriptionAttribute("���")]
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        //x����
        private int _x;
        [DescriptionAttribute("x����")]
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        //y����
        private int _y;
        [DescriptionAttribute("y����")]
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("��λ��")]
    public class XianPosition
    {

       
        //���
        private int _index;
        [DescriptionAttribute("���")]
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        //���x����
        private int _x1;
        [DescriptionAttribute("���x����")]
        public int X1
        {
            get { return _x1; }
            set { _x1 = value; }
        }

        //���y����
        private int _y1;
        [DescriptionAttribute("���y����")]
        public int Y1
        {
            get { return _y1; }
            set { _y1 = value; }
        }

        //�յ�x����
        private int _x2;
        [DescriptionAttribute("�յ�x����")]
        public int X2
        {
            get { return _x2; }
            set { _x2 = value; }
        }

        //�յ�y����
        private int _y2;
        [DescriptionAttribute("�յ�y����")]
        public int Y2
        {
            get { return _y2; }
            set { _y2 = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("��λ��")]
    public class ChePosition
    {
        //��ʼ�Ƕ�
        private int _angle;
        [DescriptionAttribute("��ʼ�Ƕ�")]
        public int Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        //x����
        private int _x;
        [DescriptionAttribute("x����")]
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        //y����
        private int _y;
        [DescriptionAttribute("y����")]
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class GanAppearance
    {
        private string _normal = string.Empty;
        public string Normal
        {
            get { return _normal; }
            set { _normal = value; }
        }
        private string _error = string.Empty;
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        private string _shield = string.Empty;
        public string Shield
        {
            get { return _shield; }
            set { _shield = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class XianAppearance
    {
        private string _normal = string.Empty;
        public string Normal
        {
            get { return _normal; }
            set { _normal = value; }
        }
        private string _error = string.Empty;
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        private string _shield = string.Empty;
        public string Shield
        {
            get { return _shield; }
            set { _shield = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class CheAppearance
    {
        private string _normal = string.Empty;
        public string Normal
        {
            get { return _normal; }
            set { _normal = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class Appearance
    {
        private GanAppearance _gan = new GanAppearance();
        public GanAppearance Gan
        {
            get { return _gan; }
            set { _gan = value; }
        }
        private XianAppearance _xian = new XianAppearance();
        public XianAppearance Xian
        {
            get { return _xian; }
            set { _xian = value; }
        }
        private CheAppearance _che = new CheAppearance();
        public CheAppearance Che
        {
            get { return _che; }
            set { _che = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("��ʼλ��")]
    public class InitialPosition
    {
        private int _gnum;
        [DescriptionAttribute("������")]
        public int NumOfGan
        {
            get { return _gnum; }
            set { _gnum = value; }
        }

        private List<GanPosition> _gan = new List<GanPosition>();
        [DescriptionAttribute("��λ��")]
        public List<GanPosition> Gan
        {
            get { return _gan; }
            set { _gan = value; }
        }

        private int _xnum;
        [DescriptionAttribute("������")]
        public int NumOfXian
        {
            get { return _xnum; }
            set { _xnum = value; }
        }

        private List<XianPosition> _xian = new List<XianPosition>();
        [DescriptionAttribute("��λ��")]
        public List<XianPosition> Xian
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

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class SignalConfigures
    {
        private int _iowport = 0x378;
        [DescriptionAttribute("�����׮���������ַ")]
        public int IOWritterPort
        {
            get { return _iowport; }
            set { _iowport = value; }
        }

        private int _iorport = 0x379;
        [DescriptionAttribute("��׮�������������ַ")]
        public int IOReaderPort
        {
            get { return _iorport; }
            set { _iorport = value; }
        }

        private int _printerport = 0x37a;
        [DescriptionAttribute("��ӡ�������ַ")]
        public int PrinterPort
        {
            get { return _printerport; }
            set { _printerport = value; }
        }

        //���߳��źŵ�λ��
        private int _ganpos;
        [DescriptionAttribute("���źŵ�λ��")]
        public int GanPosition
        {
            get { return _ganpos; }
            set { _ganpos = value; }
        }
        private int _xianpos;
        [DescriptionAttribute("���źŵ�λ��")]
        public int XianPosition
        {
            get { return _xianpos; }
            set { _xianpos = value; }
        }
        private int _chepos;
        [DescriptionAttribute("���źŵ�λ��")]
        public int ChePosition
        {
            get { return _chepos; }
            set { _chepos = value; }
        }

        private int _readioLoopTime;
        [DescriptionAttribute("ÿ��һ���ź�����ѭ���Ĵ���")]
        public int ReadIOLoopTime
        {
            get { return _readioLoopTime; }
            set { _readioLoopTime = value; }
        }

        //���߳��źų���
        private uint _ganlen;
        [DescriptionAttribute("���źų���")]
        public uint GanLength
        {
            get { return _ganlen; }
            set { _ganlen = value; }
        }
        private uint _xianlen;
        [DescriptionAttribute("���źų���")]
        public uint XianLength
        {
            get { return _xianlen; }
            set { _xianlen = value; }
        }
        private uint _chelen;
        [DescriptionAttribute("���źų���")]
        public uint CheLength
        {
            get { return _chelen; }
            set { _chelen = value; }
        }

        //�����źŻ��ִ���
        private int _ganjf;
        [DescriptionAttribute("���źŻ��ִ���")]
        public int GanJiFen
        {
            get { return _ganjf; }
            set { _ganjf = value; }
        }
        private int _xianjf;
        [DescriptionAttribute("ѹ�����źŻ��ִ���")]
        public int XianJiFen
        {
            get { return _xianjf; }
            set { _xianjf = value; }
        }

        private int _lxianjf;
        [DescriptionAttribute("�������źŻ��ִ���")]
        public int LXianJiFen
        {
            get { return _lxianjf; }
            set { _lxianjf = value; }
        }

        //����Աȡ������
        private int _adminQFGan;
        [DescriptionAttribute("����Ա��ȡ������")]
        public int AdminQFGan
        {
            get { return _adminQFGan; }
            set { _adminQFGan = value; }
        }
        private int _adminQFXian;
        [DescriptionAttribute("����Ա��ȡ������")]
        public int AdminQFXian
        {
            get { return _adminQFXian; }
            set { _adminQFXian = value; }
        }

        //����Ա��������
        private int _adminPBGan;
        [DescriptionAttribute("����Ա����������")]
        public int AdminPBGan
        {
            get { return _adminPBGan; }
            set { _adminPBGan = value; }
        }
        private int _adminPBXian;
        [DescriptionAttribute("����Ա����������")]
        public int AdminPBXian
        {
            get { return _adminPBXian; }
            set { _adminPBXian = value; }
        }

        //��ͨ�û���������
        private int _PBGan;
        [DescriptionAttribute("��ͨ�û�����������")]
        public int PBGan
        {
            get { return _PBGan; }
            set { _PBGan = value; }
        }
        private int _PBXian;
        [DescriptionAttribute("��ͨ�û�����������")]
        public int PBXian
        {
            get { return _PBXian; }
            set { _PBXian = value; }
        }
        private int _PBChe;
        [DescriptionAttribute("��ͨ�û�����������")]
        public int PBChe
        {
            get { return _PBChe; }
            set { _PBChe = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class PrintSettings
    {
        private bool isprint;
        [DescriptionAttribute("�Ƿ���Ҫ��ӡ����"), CategoryAttribute("��ӡ����")]
        public bool Isprint
        {
            get { return isprint; }
            set { isprint = value; }
        }
        private bool isprintnopass;
        [DescriptionAttribute("�Ƿ��ӡ���ϸ񿼱�"), CategoryAttribute("��ӡ����")]
        public bool IsprintNopass
        {
            get { return isprintnopass; }
            set { isprintnopass = value; }
        }


        private int _fontSize;
        [DescriptionAttribute("��ӡ�����С��"), CategoryAttribute("��ӡ����")]
        public int FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        private int ksxm_x;
        [DescriptionAttribute("��������X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksxm_x
        {
            get { return ksxm_x; }
            set { ksxm_x = value; }
        }

        private int ksxm_y;
        [DescriptionAttribute("��������Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksxm_y
        {
            get { return ksxm_y; }
            set { ksxm_y = value; }
        }

        private int ksdd_x;
        [DescriptionAttribute("���Եص�X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksdd_x
        {
            get { return ksdd_x; }
            set { ksdd_x = value; }
        }

        private int ksdd_y;
        [DescriptionAttribute("���Եص�Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksdd_y
        {
            get { return ksdd_y; }
            set { ksdd_y = value; }
        }


        private int kscx_x;
        [DescriptionAttribute("���Գ���X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Kscx_x
        {
            get { return kscx_x; }
            set { kscx_x = value; }
        }

        private int kscx_y;
        [DescriptionAttribute("���Գ���Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Kscx_y
        {
            get { return kscx_y; }
            set { kscx_y = value; }
        }
        private int kscj_x;
        [DescriptionAttribute("���Գɼ�X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Kscj_x
        {
            get { return kscj_x; }
            set { kscj_x = value; }
        }

        private int kscj_y;
        [DescriptionAttribute("���Գɼ�Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Kscj_y
        {
            get { return kscj_y; }
            set { kscj_y = value; }
        }

        private int ksrq_x;
        [DescriptionAttribute("��������X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksrq_x
        {
            get { return ksrq_x; }
            set { ksrq_x = value; }
        }

        private int ksrq_y;
        [DescriptionAttribute("��������Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksrq_y
        {
            get { return ksrq_y; }
            set { ksrq_y = value; }
        }

        private int ksyxm_x;
        [DescriptionAttribute("����Ա����X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksyxm_x
        {
            get { return ksyxm_x; }
            set { ksyxm_x = value; }
        }

        private int ksyxm_y;
        [DescriptionAttribute("����Ա����Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksyxm_y
        {
            get { return ksyxm_y; }
            set { ksyxm_y = value; }
        }

        private int tiaomaimg_x;
        [DescriptionAttribute("������X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Tiaomaimg_x
        {
            get { return tiaomaimg_x; }
            set { tiaomaimg_x = value; }
        }

        private int tiaomaimg_y;
        [DescriptionAttribute("������Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Tiaomaimg_y
        {
            get { return tiaomaimg_y; }
            set { tiaomaimg_y = value; }
        }

        private int traceimg_x;
        [DescriptionAttribute("�켣ͼX���ꡣ"), CategoryAttribute("��ӡ����")]
        public int TraceImg_X
        {
            get { return traceimg_x; }
            set { traceimg_x = value; }
        }

        private int traceimg_y;
        [DescriptionAttribute("�켣ͼY���ꡣ"), CategoryAttribute("��ӡ����")]
        public int TraceImg_Y
        {
            get { return traceimg_y; }
            set { traceimg_y = value; }
        }
    }

    //��������
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class SoundSettings
    {
        private bool _hasVoice;
        [DescriptionAttribute("�Ƿ�ʹ��������"), CategoryAttribute("��������")]
        public bool HasVoice
        {
            get { return _hasVoice; }
            set { _hasVoice = value; }
        }

        private int voiceIndex;
        [DescriptionAttribute("��������"), CategoryAttribute("��������")]
        public int VoiceIndex
        {
            get { return voiceIndex; }
            set { voiceIndex = value; }
        }
    }

    //������ʾ������
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class DisplayPanelSettings
    {
        private bool _hasDisplay;
        [DescriptionAttribute("�Ƿ�ʹ����ʾ�ơ�"), CategoryAttribute("��ʾ��ͨѶ����")]
        public bool HasDisplay
        {
            get { return _hasDisplay; }
            set { _hasDisplay = value; }
        }
        private string _displayName;
        [DescriptionAttribute("��ʾ���������á�"), CategoryAttribute("��ʾ��ͨѶ����")]
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }


        private string _displayConfigFilePath;
        [DescriptionAttribute("��ʾ�������ļ���·����"), CategoryAttribute("��ʾ��ͨѶ����")]
        public string DisplayConfigFilePath
        {
            get { return _displayConfigFilePath; }
            set { _displayConfigFilePath = value; }
        }


        private string _displayConfigClass;
        [DescriptionAttribute("��ʾ�������ļ�������"), CategoryAttribute("��ʾ��ͨѶ����")]
        public string DisplayConfigClass
        {
            get { return _displayConfigClass; }
            set { _displayConfigClass = value; }
        }

        private string _displayCommClass;
        [DescriptionAttribute("��ʾ��ͨѶ�ļ�������"), CategoryAttribute("��ʾ��ͨѶ����")]
        public string DisplayCommClass
        {
            get { return _displayCommClass; }
            set { _displayCommClass = value; }
        }
    }

    //����ͨ������
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class CameraSettings
    {
        private int _yuntaichannel;
        [DescriptionAttribute("��̨�����ͨ��"), CategoryAttribute("����")]
        public int YuntaiChannel
        {
            get { return _yuntaichannel; }
            set { _yuntaichannel = value; }
        }

        private int _gaochannel;
        [DescriptionAttribute("��̨�����ͨ��"), CategoryAttribute("����")]
        public int GaoChannel
        {
            get { return _gaochannel; }
            set { _gaochannel = value; }
        }
    }
}
