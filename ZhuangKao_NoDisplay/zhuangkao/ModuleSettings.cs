using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel;
using zhuangkao.Displaycomm;

namespace zhuangkao 
{
    #region 配置对象模型类

    

    public class ModuleSettings
    {
        
        private int _chetype;//车类型，0是小车，非0是大车
        [DescriptionAttribute("车类型设置，0为小车，非0为大车。"), CategoryAttribute("车线杆属性设置")]
        public int CheType
        {
            set { _chetype = value; }
            get { return _chetype; }
        }

        private int _pbgan_s;
        [DescriptionAttribute("小车普通杆信号屏蔽。"), CategoryAttribute("车线杆属性设置")]
        public int PbGan_s
        {
            set { _pbgan_s = value; }
            get { return _pbgan_s; }
        }

        private int _pbxian_s;
        [DescriptionAttribute("小车普通线信号屏蔽。"), CategoryAttribute("车线杆属性设置")]
        public int PbXian_s
        {
            set { _pbxian_s = value; }
            get { return _pbxian_s; }
        }

        private int _pbche_s;
        [DescriptionAttribute("小车普通车信号屏蔽。"), CategoryAttribute("车线杆属性设置")]
        public int PbChe_s
        {
            set { _pbche_s = value; }
            get { return _pbche_s; }
        }


        private int _pbgan_l;
        [DescriptionAttribute("大车普通杆信号屏蔽。"), CategoryAttribute("车线杆属性设置")]
        public int PbGan_l
        {
            set { _pbgan_l = value; }
            get { return _pbgan_l; }
        }

        private int _pbxian_l;
        [DescriptionAttribute("大车普通线信号屏蔽。"), CategoryAttribute("车线杆属性设置")]
        public int PbXian_l
        {
            set { _pbxian_l = value; }
            get { return _pbxian_l; }
        }

        private int _pbche_l;
        [DescriptionAttribute("大车普通车信号屏蔽。"), CategoryAttribute("车线杆属性设置")]
        public int PbChe_l
        {
            set { _pbche_l = value; }
            get { return _pbche_l; }
        }

        private int _adminpbgan_s;
        [DescriptionAttribute("管理员小车杆信号屏蔽。"), CategoryAttribute("车线杆属性设置")]
        public int AdminPbGan_s
        {
            set { _adminpbgan_s = value; }
            get { return _adminpbgan_s; }
        }


        private int _adminpbxian_s;
        [DescriptionAttribute("管理员小车线信号屏蔽。"), CategoryAttribute("车线杆属性设置")]
        public int AdminPbXian_s
        {
            set { _adminpbxian_s = value; }
            get { return _adminpbxian_s; }
        }

        private int _adminpbgan_l;
        [DescriptionAttribute("管理员大车杆信号屏蔽。"), CategoryAttribute("车线杆属性设置")]
        public int AdminPbGan_l
        {
            set { _adminpbgan_l = value; }
            get { return _adminpbgan_l; }
        }

        private int _adminpbxian_l;
        [DescriptionAttribute("管理员大车线信号屏蔽。"), CategoryAttribute("车线杆属性设置")]
        public int AdminPbXian_l
        {
            set { _adminpbxian_l = value; }
            get { return _adminpbxian_l; }
        }

        private int _adminqfgan_s;
        [DescriptionAttribute("管理员小车杆信号取反。"), CategoryAttribute("车线杆属性设置")]
        public int AdminQFGan_s
        {
            set { _adminqfgan_s = value; }
            get { return _adminqfgan_s; }
        }


        private int _adminqfxian_s;
        [DescriptionAttribute("管理员小车线信号取反。"), CategoryAttribute("车线杆属性设置")]
        public int AdminQFXian_s
        {
            set { _adminqfxian_s = value; }
            get { return _adminqfxian_s; }
        }

        private int _adminqfgan_l;
        [DescriptionAttribute("管理员大车杆信号取反。"), CategoryAttribute("车线杆属性设置")]
        public int AdminQFGan_l
        {
            set { _adminqfgan_l = value; }
            get { return _adminqfgan_l; }
        }

        private int _adminqfxian_l;
        [DescriptionAttribute("管理员大车线信号取反。"), CategoryAttribute("车线杆属性设置")]
        public int AdminQFXian_l
        {
            set { _adminqfxian_l = value; }
            get { return _adminqfxian_l; }
        }

        private int _prepareDuration;
        [DescriptionAttribute("考生上车到开始考试之间等待时间"), CategoryAttribute("考试状态时间设置")]
        public int PrepareDuration
        {
            set { _prepareDuration = value; }
            get { return _prepareDuration; }
        }

        private int _state2_time_s;
        [DescriptionAttribute("状态2时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State2_Time_s
        {
            set { _state2_time_s = value; }
            get { return _state2_time_s; }
        }

        private int _state3_time_s;
        [DescriptionAttribute("状态3时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State3_Time_s
        {
            set { _state3_time_s = value; }
            get { return _state3_time_s; }
        }

        private int _state4_time_s;
        [DescriptionAttribute("状态4时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State4_Time_s
        {
            set { _state4_time_s = value; }
            get { return _state4_time_s; }
        }

        private int _state4i_time_s;
        [DescriptionAttribute("状态4i时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State4i_Time_s
        {
            set { _state4i_time_s = value; }
            get { return _state4i_time_s; }
        }

        private int _state5_time_s;
        [DescriptionAttribute("状态5时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State5_Time_s
        {
            set { _state5_time_s = value; }
            get { return _state5_time_s; }
        }

        private int _state6_time_s;
        [DescriptionAttribute("状态6时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State6_Time_s
        {
            set { _state6_time_s = value; }
            get { return _state6_time_s; }
        }

        private int _state7_time_s;
        [DescriptionAttribute("状态7时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State7_Time_s
        {
            set { _state7_time_s = value; }
            get { return _state7_time_s; }
        }

        private int _state8_time_s;
        [DescriptionAttribute("状态8时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State8_Time_s
        {
            set { _state8_time_s = value; }
            get { return _state8_time_s; }
        }

        private int _state9_time_s;
        [DescriptionAttribute("状态9时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State9_Time_s
        {
            set { _state9_time_s = value; }
            get { return _state9_time_s; }
        }

        private int _state10_time_s;
        [DescriptionAttribute("状态10时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State10_Time_s
        {
            set { _state10_time_s = value; }
            get { return _state10_time_s; }
        }


        private int _state11_time_s;
        [DescriptionAttribute("状态11时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State11_Time_s
        {
            set { _state11_time_s = value; }
            get { return _state11_time_s; }
        }

        private int _state12_time_s;
        [DescriptionAttribute("状态12时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State12_Time_s
        {
            set { _state12_time_s = value; }
            get { return _state12_time_s; }
        }

        private int _state13_time_s;
        [DescriptionAttribute("状态13时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State13_Time_s
        {
            set { _state13_time_s = value; }
            get { return _state13_time_s; }
        }

        private int _state14_time_s;
        [DescriptionAttribute("状态14时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State14_Time_s
        {
            set { _state14_time_s = value; }
            get { return _state14_time_s; }
        }

        private int _state14i_time_s;
        [DescriptionAttribute("状态14i时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State14i_Time_s
        {
            set { _state14i_time_s = value; }
            get { return _state14i_time_s; }
        }

        private int _state15_time_s;
        [DescriptionAttribute("状态15时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State15_Time_s
        {
            set { _state15_time_s = value; }
            get { return _state15_time_s; }
        }

        private int _state16_time_s;
        [DescriptionAttribute("状态16时间。"), CategoryAttribute("小车考试状态时间设置")]
        public int State16_Time_s
        {
            set { _state16_time_s = value; }
            get { return _state16_time_s; }
        }

        private int _state2_time_l;
        [DescriptionAttribute("状态2时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State2_Time_l
        {
            set { _state2_time_l = value; }
            get { return _state2_time_l; }
        }

        private int _state3_time_l;
        [DescriptionAttribute("状态3时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State3_Time_l
        {
            set { _state3_time_l = value; }
            get { return _state3_time_l; }
        }

        private int _state4_time_l;
        [DescriptionAttribute("状态4时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State4_Time_l
        {
            set { _state4_time_l = value; }
            get { return _state4_time_l; }
        }

        private int _state4i_time_l;
        [DescriptionAttribute("状态4i时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State4i_Time_l
        {
            set { _state4i_time_l = value; }
            get { return _state4i_time_l; }
        }

        private int _state5_time_l;
        [DescriptionAttribute("状态5时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State5_Time_l
        {
            set { _state5_time_l = value; }
            get { return _state5_time_l; }
        }

        private int _state6_time_l;
        [DescriptionAttribute("状态6时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State6_Time_l
        {
            set { _state6_time_l = value; }
            get { return _state6_time_l; }
        }

        private int _state7_time_l;
        [DescriptionAttribute("状态7时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State7_Time_l
        {
            set { _state7_time_l = value; }
            get { return _state7_time_l; }
        }

        private int _state8_time_l;
        [DescriptionAttribute("状态8时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State8_Time_l
        {
            set { _state8_time_l = value; }
            get { return _state8_time_l; }
        }

        private int _state9_time_l;
        [DescriptionAttribute("状态9时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State9_Time_l
        {
            set { _state9_time_l = value; }
            get { return _state9_time_l; }
        }

        private int _state10_time_l;
        [DescriptionAttribute("状态10时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State10_Time_l
        {
            set { _state10_time_l = value; }
            get { return _state10_time_l; }
        }


        private int _state11_time_l;
        [DescriptionAttribute("状态11时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State11_Time_l
        {
            set { _state11_time_l = value; }
            get { return _state11_time_l; }
        }

        private int _state12_time_l;
        [DescriptionAttribute("状态12时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State12_Time_l
        {
            set { _state12_time_l = value; }
            get { return _state12_time_l; }
        }

        private int _state13_time_l;
        [DescriptionAttribute("状态13时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State13_Time_l
        {
            set { _state13_time_l = value; }
            get { return _state13_time_l; }
        }

        private int _state14_time_l;
        [DescriptionAttribute("状态14时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State14_Time_l
        {
            set { _state14_time_l = value; }
            get { return _state14_time_l; }
        }

        private int _state14i_time_l;
        [DescriptionAttribute("状态14i时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State14i_Time_l
        {
            set { _state14i_time_l = value; }
            get { return _state14i_time_l; }
        }

        private int _state15_time_l;
        [DescriptionAttribute("状态15时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State15_Time_l
        {
            set { _state15_time_l = value; }
            get { return _state15_time_l; }
        }

        private int _state16_time_l;
        [DescriptionAttribute("状态16时间。"), CategoryAttribute("大车考试状态时间设置")]
        public int State16_Time_l
        {
            set { _state16_time_l = value; }
            get { return _state16_time_l; }
        }

        private int _maxstopcount;
        [DescriptionAttribute("最大中停次数，现已废弃。")]
        public int MaxStopCount
        {
            set 
            {
                if (value < 2)
                {
                    _maxstopcount = 2;
                }
                else
                {
                    _maxstopcount = value;
                }
            }
            get{ return _maxstopcount;}
        }

        private string _locallinkstr;
        [DescriptionAttribute("本地连接字符串。"), CategoryAttribute("数据库设置")]
        public string LocalLinkStr
        {
            set { _locallinkstr = value; }
            get { return _locallinkstr; }
        }

        private string _soundksks;//开始考试
        public string SoundKsks
        {
            set { _soundksks = value; }
            get { return _soundksks; }
        }

        private int _state8delay;
        [DescriptionAttribute("状态8延时时间。"), CategoryAttribute("延时设置")]
        public int State8delay
        {
            get { return _state8delay; }
            set { _state8delay = value; }
        }


        private int _delaytime;
        [DescriptionAttribute("读取信号间隔。"), CategoryAttribute("延时设置")]
        public int Delaytime
        {
            get { return _delaytime; }
            set { _delaytime = value; }
        }

        private int _lvbodelaytime;
        [DescriptionAttribute("写地址与读地址数据时间间隔。"), CategoryAttribute("延时设置")]
        public int Lvbodelaytime
        {
            get { return _lvbodelaytime; }
            set { _lvbodelaytime = value; }
        }

        private int _gan_s;
        [DescriptionAttribute("小车杆信号位置定义"), CategoryAttribute("车线杆属性设置")]
        public int Gan_s
        {
            get { return _gan_s; }
            set { _gan_s = value; }
        }

        private int _gan_l;
        [DescriptionAttribute("大车杆信号位置定义"), CategoryAttribute("车线杆属性设置")]
        public int Gan_l
        {
            get { return _gan_l; }
            set { _gan_l = value; }
        }

        private int _xian_s;
        [DescriptionAttribute("小车线信号位置定义"), CategoryAttribute("车线杆属性设置")]
        public int Xian_s
        {
            get { return _xian_s; }
            set { _xian_s = value; }
        }

        private int _xian_l;
        [DescriptionAttribute("大车线信号位置定义"), CategoryAttribute("车线杆属性设置")]
        public int Xian_l
        {
            get { return _xian_l; }
            set { _xian_l = value; }
        }

        private int _che;
        [DescriptionAttribute("车信号位置定义"), CategoryAttribute("车线杆属性设置")]
        public int Che
        {
            get { return _che; }
            set { _che = value; }
        }

        private string _ipaddress;
        [DescriptionAttribute("本地连接IP地址。"), CategoryAttribute("数据库设置")]
        public string Ipaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        //t1,t2,t3时间以秒为单位，程序中引用时乘1000转为毫秒
        private int _t1;
        [DescriptionAttribute("进库挡8线延时t1秒等同停车。"), CategoryAttribute("延时设置")]
        public int T1
        {
            get { return _t1; }
            set { _t1 = value; }
        }
        
        private int _t2;
        public int T2
        {
            get { return _t2; }
            set { _t2 = value; }
        }

        private int _t3;
        [DescriptionAttribute("车二退，挡8线如果挡2线，延时t3秒等同停车。"), CategoryAttribute("延时设置")]
        public int T3
        {
            get { return _t3; }
            set { _t3 = value; }
        }
      
        private string _ksdd;
        [DescriptionAttribute("考试地点。")]
        public string Ksdd
        {
            get { return _ksdd; }
            set { _ksdd = value; }
        }

        private int _useidcardlogin; //是否必须用身份证登录
        public int UseidcardLogin
        {
            get { return _useidcardlogin; }
            set { _useidcardlogin = value; }
        }

        //private int _useidcardexam;//是否必须用身份证进入考试
        //public int UseidcardExam
        //{
        //    get { return _useidcardexam; }
        //    set { _useidcardexam = value; }
        //}

        private bool _isNetwork;
        [DescriptionAttribute("是否使用网络。")]
        public bool IsNetwork
        {
            get { return _isNetwork; }
            set { _isNetwork = value; }
        }

        private string _ServerIP;
        [DescriptionAttribute("点名中心服务器IP地址。")]
        public string ServerIP
        {
            get { return _ServerIP; }
            set { _ServerIP = value; }
        }

        private int _devnum;
        [DescriptionAttribute("设备编号，必须是非0的纯数字。")]
        public int Devnum
        {
            get { return _devnum; }
            set { _devnum = value; }
        }

        private int _jifennum;
       // [DefaultValue(20)]
        [DescriptionAttribute("积分次数。")]
        public int Jifennum
        {
            get { return _jifennum; }
            set { _jifennum = value; }
        }

        //----------打印坐标设置---------------------
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
        [DescriptionAttribute("考试地点Y坐标。"),CategoryAttribute("打印设置")]
        public int Ksdd_y
        {
            get { return ksdd_y; }
            set { ksdd_y = value; }
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
        //----------打印设置结束-----------------------------------------

        //----------声音设置开始-----------------------------------------
        private int voiceIndex;
        [DescriptionAttribute("声音索引"), CategoryAttribute("声音")]
        public int VoiceIndex
        {
            get { return voiceIndex; }
            set { voiceIndex = value; }
        }
        //----------声音设置结束-----------------------------------------

        //----------显示牌设置开始---------------------------------------
        private string _comport;
        [DescriptionAttribute("串行端口设置。"), CategoryAttribute("显示屏通讯设置")]
        public string Comport
        {
            get { return _comport; }
            set { _comport = value; }
        }

        private DisplayBS _displaybs;
        [DescriptionAttribute("显示屏类型，大屏为BigDisplay,小屏为SmallDisplay。"), CategoryAttribute("显示屏通讯设置")]
        public DisplayBS Displaybs
        {
            get { return _displaybs; }
            set { _displaybs = value; }
        }


        private byte _addresscode;
        [DescriptionAttribute("显示屏地址设置，注意为十进制值，16进制前加0x。"), CategoryAttribute("显示屏通讯设置")]
        public byte Addresscode
        {
            get { return _addresscode; }
            set { _addresscode = value; }
        }

        private byte _displaySpeed;
        [DescriptionAttribute("显示屏翻屏或移动速度。"), CategoryAttribute("显示屏通讯设置")]
        public byte DisplaySpeed
        {
            get { return _displaySpeed; }
            set { _displaySpeed = value; }
        }

        private DisplayType _displayType;
        [DescriptionAttribute("显示类型设置，Zhidisp=0x30直屏显示,Gundisp=0x31翻屏或移屏显示。"), CategoryAttribute("显示屏通讯设置")]
        public DisplayType DisplayType
        {
            get { return _displayType; }
            set { _displayType = value; }
        }
        //------------显示牌设置结束-----------------------------------------------------------

        //----------摄像通道设置开始-----------------------------------------
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
        //----------摄像通道设置结束-----------------------------------------
    }

    #endregion 
}
