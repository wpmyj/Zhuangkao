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
        //考试地点
        private string _ksdd = string.Empty;
        [DescriptionAttribute("考试地点")]
        public string KSDD
        {
            get { return _ksdd; }
            set { _ksdd = value; }
        }

        //数据库IP
        private string _ipaddress;
        [DescriptionAttribute("本地连接IP地址。"), CategoryAttribute("数据库设置")]
        public string IPAddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        //点明中心服务器 IP
        private string _serverIP;
        [DescriptionAttribute("点名中心服务器IP地址。")]
        public string ServerIP
        {
            get { return _serverIP; }
            set { _serverIP = value; }
        }

        //设备编号
        private int _devnum;
        [DescriptionAttribute("设备编号，必须是非0的纯数字。")]
        public int Devnum
        {
            get { return _devnum; }
            set { _devnum = value; }
        }

        //是否用键盘模拟信号
        private bool _isSimulate;
        [DescriptionAttribute("是否用键盘模拟信号")]
        public bool IsSimulate
        {
            get { return _isSimulate; }
            set { _isSimulate = value; }
        }


        //读取信号间隔。
        private int _delaytime;
        [DescriptionAttribute("读取信号间隔")]
        public int Delaytime
        {
            get { return _delaytime; }
            set { _delaytime = value; }
        }


        //写地址与读地址数据时间间隔。
        private int _lvbodelaytime;
        [DescriptionAttribute("写地址与读地址数据时间间隔")]
        public int Lvbodelaytime
        {
            get { return _lvbodelaytime; }
            set { _lvbodelaytime = value; }
        }


        //信号设置
        private SignalConfigures _signConfig = new SignalConfigures();
        [DescriptionAttribute("信号设置")]
        public SignalConfigures SignConfig
        {
            get { return _signConfig; }
            set { _signConfig = value; }
        }


        //打印设置
        private PrintSettings _printSettings = new PrintSettings();
        [DescriptionAttribute("打印设置")]
        public PrintSettings PrintConfig
        {
            get { return _printSettings; }
            set { _printSettings = value; }
        }

        //显示牌设置
        private DisplayPanelSettings _displayPaneSettings = new DisplayPanelSettings();
        [DescriptionAttribute("显示牌设置")]
        public DisplayPanelSettings DisplayPaneConfig
        {
            get { return _displayPaneSettings; }
            set { _displayPaneSettings = value; }
        }

        //语音设置
        private SoundSettings _soundSettings = new SoundSettings();
        [DescriptionAttribute("语音设置")]
        public SoundSettings SoundConfig
        {
            get { return _soundSettings; }
            set { _soundSettings = value; }
        }

        //摄像头设置
        private CameraSettings _cameraSettings = new CameraSettings();
        [DescriptionAttribute("语音设置")]
        public CameraSettings CameraConfig
        {
            get { return _cameraSettings; }
            set { _cameraSettings = value; }
        }

        //杆线车图片设置
        private Appearance _modelAppearance = new Appearance();
        [DescriptionAttribute("图片路径"), CategoryAttribute("车线杆属性设置")]
        public Appearance ModelAppearance
        {
            get { return _modelAppearance; }
            set { _modelAppearance = value; }
        }

        //杆线车模型初始化位置
        private InitialPosition _modelInitPos = new InitialPosition();
        [DescriptionAttribute("初始位置"), CategoryAttribute("车线杆属性设置")]
        public InitialPosition InitPosition
        {
            get { return _modelInitPos; }
            set { _modelInitPos = value; }
        }

        //车模型移动速度
        private int[] _stateDur = new int[4];
        [DescriptionAttribute("动画移动速度"), CategoryAttribute("车线杆属性设置")]
        public int[] StateDuration
        {
            get { return _stateDur; }
            set { _stateDur = value; }
        }
    }


    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("杆位置")]
    public class GanPosition
    {
       
        //序号
        private int _index;
        [DescriptionAttribute("序号")]
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        //x坐标
        private int _x;
        [DescriptionAttribute("x坐标")]
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        //y坐标
        private int _y;
        [DescriptionAttribute("y坐标")]
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("线位置")]
    public class XianPosition
    {

       
        //序号
        private int _index;
        [DescriptionAttribute("序号")]
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        //起点x坐标
        private int _x1;
        [DescriptionAttribute("起点x坐标")]
        public int X1
        {
            get { return _x1; }
            set { _x1 = value; }
        }

        //起点y坐标
        private int _y1;
        [DescriptionAttribute("起点y坐标")]
        public int Y1
        {
            get { return _y1; }
            set { _y1 = value; }
        }

        //终点x坐标
        private int _x2;
        [DescriptionAttribute("终点x坐标")]
        public int X2
        {
            get { return _x2; }
            set { _x2 = value; }
        }

        //终点y坐标
        private int _y2;
        [DescriptionAttribute("终点y坐标")]
        public int Y2
        {
            get { return _y2; }
            set { _y2 = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("车位置")]
    public class ChePosition
    {
        //初始角度
        private int _angle;
        [DescriptionAttribute("初始角度")]
        public int Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        //x坐标
        private int _x;
        [DescriptionAttribute("x坐标")]
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        //y坐标
        private int _y;
        [DescriptionAttribute("y坐标")]
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

    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("初始位置")]
    public class InitialPosition
    {
        private int _gnum;
        [DescriptionAttribute("杆数量")]
        public int NumOfGan
        {
            get { return _gnum; }
            set { _gnum = value; }
        }

        private List<GanPosition> _gan = new List<GanPosition>();
        [DescriptionAttribute("杆位置")]
        public List<GanPosition> Gan
        {
            get { return _gan; }
            set { _gan = value; }
        }

        private int _xnum;
        [DescriptionAttribute("线数量")]
        public int NumOfXian
        {
            get { return _xnum; }
            set { _xnum = value; }
        }

        private List<XianPosition> _xian = new List<XianPosition>();
        [DescriptionAttribute("线位置")]
        public List<XianPosition> Xian
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

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class SignalConfigures
    {
        private int _iowport = 0x378;
        [DescriptionAttribute("输出至桩考仪物理地址")]
        public int IOWritterPort
        {
            get { return _iowport; }
            set { _iowport = value; }
        }

        private int _iorport = 0x379;
        [DescriptionAttribute("从桩考仪输入物理地址")]
        public int IOReaderPort
        {
            get { return _iorport; }
            set { _iorport = value; }
        }

        private int _printerport = 0x37a;
        [DescriptionAttribute("打印机物理地址")]
        public int PrinterPort
        {
            get { return _printerport; }
            set { _printerport = value; }
        }

        //杆线车信号的位置
        private int _ganpos;
        [DescriptionAttribute("杆信号的位置")]
        public int GanPosition
        {
            get { return _ganpos; }
            set { _ganpos = value; }
        }
        private int _xianpos;
        [DescriptionAttribute("线信号的位置")]
        public int XianPosition
        {
            get { return _xianpos; }
            set { _xianpos = value; }
        }
        private int _chepos;
        [DescriptionAttribute("车信号的位置")]
        public int ChePosition
        {
            get { return _chepos; }
            set { _chepos = value; }
        }

        private int _readioLoopTime;
        [DescriptionAttribute("每读一轮信号所需循环的次数")]
        public int ReadIOLoopTime
        {
            get { return _readioLoopTime; }
            set { _readioLoopTime = value; }
        }

        //杆线车信号长度
        private uint _ganlen;
        [DescriptionAttribute("杆信号长度")]
        public uint GanLength
        {
            get { return _ganlen; }
            set { _ganlen = value; }
        }
        private uint _xianlen;
        [DescriptionAttribute("线信号长度")]
        public uint XianLength
        {
            get { return _xianlen; }
            set { _xianlen = value; }
        }
        private uint _chelen;
        [DescriptionAttribute("车信号长度")]
        public uint CheLength
        {
            get { return _chelen; }
            set { _chelen = value; }
        }

        //杆线信号积分次数
        private int _ganjf;
        [DescriptionAttribute("杆信号积分次数")]
        public int GanJiFen
        {
            get { return _ganjf; }
            set { _ganjf = value; }
        }
        private int _xianjf;
        [DescriptionAttribute("压线线信号积分次数")]
        public int XianJiFen
        {
            get { return _xianjf; }
            set { _xianjf = value; }
        }

        private int _lxianjf;
        [DescriptionAttribute("离线线信号积分次数")]
        public int LXianJiFen
        {
            get { return _lxianjf; }
            set { _lxianjf = value; }
        }

        //管理员取反设置
        private int _adminQFGan;
        [DescriptionAttribute("管理员杆取反设置")]
        public int AdminQFGan
        {
            get { return _adminQFGan; }
            set { _adminQFGan = value; }
        }
        private int _adminQFXian;
        [DescriptionAttribute("管理员线取反设置")]
        public int AdminQFXian
        {
            get { return _adminQFXian; }
            set { _adminQFXian = value; }
        }

        //管理员屏蔽设置
        private int _adminPBGan;
        [DescriptionAttribute("管理员杆屏蔽设置")]
        public int AdminPBGan
        {
            get { return _adminPBGan; }
            set { _adminPBGan = value; }
        }
        private int _adminPBXian;
        [DescriptionAttribute("管理员线屏蔽设置")]
        public int AdminPBXian
        {
            get { return _adminPBXian; }
            set { _adminPBXian = value; }
        }

        //普通用户屏蔽设置
        private int _PBGan;
        [DescriptionAttribute("普通用户杆屏蔽设置")]
        public int PBGan
        {
            get { return _PBGan; }
            set { _PBGan = value; }
        }
        private int _PBXian;
        [DescriptionAttribute("普通用户线屏蔽设置")]
        public int PBXian
        {
            get { return _PBXian; }
            set { _PBXian = value; }
        }
        private int _PBChe;
        [DescriptionAttribute("普通用户车屏蔽设置")]
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
        [DescriptionAttribute("是否需要打印考表。"), CategoryAttribute("打印设置")]
        public bool Isprint
        {
            get { return isprint; }
            set { isprint = value; }
        }
        private bool isprintnopass;
        [DescriptionAttribute("是否打印不合格考表。"), CategoryAttribute("打印设置")]
        public bool IsprintNopass
        {
            get { return isprintnopass; }
            set { isprintnopass = value; }
        }


        private int _fontSize;
        [DescriptionAttribute("打印字体大小。"), CategoryAttribute("打印设置")]
        public int FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        private int ksxm_x;
        [DescriptionAttribute("考试姓名X坐标。"), CategoryAttribute("打印设置")]
        public int Ksxm_x
        {
            get { return ksxm_x; }
            set { ksxm_x = value; }
        }

        private int ksxm_y;
        [DescriptionAttribute("考试姓名Y坐标。"), CategoryAttribute("打印设置")]
        public int Ksxm_y
        {
            get { return ksxm_y; }
            set { ksxm_y = value; }
        }

        private int ksdd_x;
        [DescriptionAttribute("考试地点X坐标。"), CategoryAttribute("打印设置")]
        public int Ksdd_x
        {
            get { return ksdd_x; }
            set { ksdd_x = value; }
        }

        private int ksdd_y;
        [DescriptionAttribute("考试地点Y坐标。"), CategoryAttribute("打印设置")]
        public int Ksdd_y
        {
            get { return ksdd_y; }
            set { ksdd_y = value; }
        }


        private int kscx_x;
        [DescriptionAttribute("考试车型X坐标。"), CategoryAttribute("打印设置")]
        public int Kscx_x
        {
            get { return kscx_x; }
            set { kscx_x = value; }
        }

        private int kscx_y;
        [DescriptionAttribute("考试车型Y坐标。"), CategoryAttribute("打印设置")]
        public int Kscx_y
        {
            get { return kscx_y; }
            set { kscx_y = value; }
        }
        private int kscj_x;
        [DescriptionAttribute("考试成绩X坐标。"), CategoryAttribute("打印设置")]
        public int Kscj_x
        {
            get { return kscj_x; }
            set { kscj_x = value; }
        }

        private int kscj_y;
        [DescriptionAttribute("考试成绩Y坐标。"), CategoryAttribute("打印设置")]
        public int Kscj_y
        {
            get { return kscj_y; }
            set { kscj_y = value; }
        }

        private int ksrq_x;
        [DescriptionAttribute("考试日期X坐标。"), CategoryAttribute("打印设置")]
        public int Ksrq_x
        {
            get { return ksrq_x; }
            set { ksrq_x = value; }
        }

        private int ksrq_y;
        [DescriptionAttribute("考试日期Y坐标。"), CategoryAttribute("打印设置")]
        public int Ksrq_y
        {
            get { return ksrq_y; }
            set { ksrq_y = value; }
        }

        private int ksyxm_x;
        [DescriptionAttribute("考试员姓名X坐标。"), CategoryAttribute("打印设置")]
        public int Ksyxm_x
        {
            get { return ksyxm_x; }
            set { ksyxm_x = value; }
        }

        private int ksyxm_y;
        [DescriptionAttribute("考试员姓名Y坐标。"), CategoryAttribute("打印设置")]
        public int Ksyxm_y
        {
            get { return ksyxm_y; }
            set { ksyxm_y = value; }
        }

        private int tiaomaimg_x;
        [DescriptionAttribute("条形码X坐标。"), CategoryAttribute("打印设置")]
        public int Tiaomaimg_x
        {
            get { return tiaomaimg_x; }
            set { tiaomaimg_x = value; }
        }

        private int tiaomaimg_y;
        [DescriptionAttribute("条形码Y坐标。"), CategoryAttribute("打印设置")]
        public int Tiaomaimg_y
        {
            get { return tiaomaimg_y; }
            set { tiaomaimg_y = value; }
        }

        private int traceimg_x;
        [DescriptionAttribute("轨迹图X坐标。"), CategoryAttribute("打印设置")]
        public int TraceImg_X
        {
            get { return traceimg_x; }
            set { traceimg_x = value; }
        }

        private int traceimg_y;
        [DescriptionAttribute("轨迹图Y坐标。"), CategoryAttribute("打印设置")]
        public int TraceImg_Y
        {
            get { return traceimg_y; }
            set { traceimg_y = value; }
        }
    }

    //语音设置
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class SoundSettings
    {
        private bool _hasVoice;
        [DescriptionAttribute("是否使用声音。"), CategoryAttribute("语音设置")]
        public bool HasVoice
        {
            get { return _hasVoice; }
            set { _hasVoice = value; }
        }

        private int voiceIndex;
        [DescriptionAttribute("语音索引"), CategoryAttribute("语音设置")]
        public int VoiceIndex
        {
            get { return voiceIndex; }
            set { voiceIndex = value; }
        }
    }

    //电子显示牌设置
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class DisplayPanelSettings
    {
        private bool _hasDisplay;
        [DescriptionAttribute("是否使用显示牌。"), CategoryAttribute("显示屏通讯设置")]
        public bool HasDisplay
        {
            get { return _hasDisplay; }
            set { _hasDisplay = value; }
        }
        private string _displayName;
        [DescriptionAttribute("显示牌名称设置。"), CategoryAttribute("显示屏通讯设置")]
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }


        private string _displayConfigFilePath;
        [DescriptionAttribute("显示牌配置文件的路径。"), CategoryAttribute("显示屏通讯设置")]
        public string DisplayConfigFilePath
        {
            get { return _displayConfigFilePath; }
            set { _displayConfigFilePath = value; }
        }


        private string _displayConfigClass;
        [DescriptionAttribute("显示牌配置文件类名。"), CategoryAttribute("显示屏通讯设置")]
        public string DisplayConfigClass
        {
            get { return _displayConfigClass; }
            set { _displayConfigClass = value; }
        }

        private string _displayCommClass;
        [DescriptionAttribute("显示牌通讯文件类名。"), CategoryAttribute("显示屏通讯设置")]
        public string DisplayCommClass
        {
            get { return _displayCommClass; }
            set { _displayCommClass = value; }
        }
    }

    //摄像通道设置
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class CameraSettings
    {
        private int _yuntaichannel;
        [DescriptionAttribute("云台摄像机通道"), CategoryAttribute("摄像")]
        public int YuntaiChannel
        {
            get { return _yuntaichannel; }
            set { _yuntaichannel = value; }
        }

        private int _gaochannel;
        [DescriptionAttribute("高台摄像机通道"), CategoryAttribute("摄像")]
        public int GaoChannel
        {
            get { return _gaochannel; }
            set { _gaochannel = value; }
        }
    }
}
