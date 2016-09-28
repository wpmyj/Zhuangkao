using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Util
{
    public class CSettings
    {
        //考试地点
        private string _ksdd = string.Empty;
        [DescriptionAttribute("考试地点")]
        public string KSDD
        {
            get { return _ksdd; }
            set { _ksdd = value; }
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

        virtual public CSettings GetCommonSettings()
        {
            return this;
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

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class SignalConfigures
    {
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
        [DescriptionAttribute("线信号积分次数")]
        public int XianJiFen
        {
            get { return _xianjf; }
            set { _xianjf = value; }
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
    }



   



}
