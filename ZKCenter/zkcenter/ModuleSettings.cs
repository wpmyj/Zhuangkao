using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel;

namespace zkcenter
{
    #region 配置对象模型类

    

    public class ModuleSettings
    {

        private string _ipaddress;
        [DescriptionAttribute("远程数据库IP地址。"), CategoryAttribute("数据库")]
        public string Ipaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        private string _devorder;
        [DescriptionAttribute("将启用的设备号序列。如\"1,2,5\"表示1号、2号和5号库将用作考试。"), CategoryAttribute("桩考设置")]
        public string DevOrder
        {
            get { return _devorder; }
            set { _devorder = value; }
        }


        //----------打印坐标设置---------------------
        private int ksxm_x;
        public int Ksxm_x
        {
            get { return ksxm_x; }
            set { ksxm_x = value; }
        }

        private int ksxm_y;
        public int Ksxm_y
        {
            get { return ksxm_y; }
            set { ksxm_y = value; }
        }

        private int ksdd_x;
        public int Ksdd_x
        {
            get { return ksdd_x; }
            set { ksdd_x = value; }
        }

        private int ksdd_y;
        public int Ksdd_y
        {
            get { return ksdd_y; }
            set { ksdd_y = value; }
        }

        private int kscj_x;
        public int Kscj_x
        {
            get { return kscj_x; }
            set { kscj_x = value; }
        }

        private int kscj_y;
        public int Kscj_y
        {
            get { return kscj_y; }
            set { kscj_y = value; }
        }

        private int ksrq_x;
        public int Ksrq_x
        {
            get { return ksrq_x; }
            set { ksrq_x = value; }
        }

        private int ksrq_y;
        public int Ksrq_y
        {
            get { return ksrq_y; }
            set { ksrq_y = value; }
        }

        private int ksyxm_x;
        public int Ksyxm_x
        {
            get { return ksyxm_x; }
            set { ksyxm_x = value; }
        }

        private int ksyxm_y;
        public int Ksyxm_y
        {
            get { return ksyxm_y; }
            set { ksyxm_y = value; }
        }

        private int isprintbjg;
        public int Isprintbjg
        {
            get { return isprintbjg; }
            set { isprintbjg = value; }
        }

        private int lkrqorzkrq; //发送路考日期还是桩考日期，非0为路考日期，0为桩考日期
        public int lkrqORzkrq
        {
            get { return lkrqorzkrq; }
            set { lkrqorzkrq = value; }
        }

        private int showbutton; //显示复位和同步按钮，非0显示，0不显示
        public int Showbutton
        {
            get { return showbutton; }
            set { showbutton = value; }
        }


        //==============显示牌设置开始=========================
        private bool _hasDisplay;
        [DescriptionAttribute("是否使用显示牌。"), CategoryAttribute("显示屏通讯设置")]
        public bool HasDisplay
        {
            get { return _hasDisplay; }
            set { _hasDisplay = value; }
        }

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

        //==============显示牌设置结束=========================

        private int _voiceIndex;
        [DescriptionAttribute("声音索引号。请在“控制面板”->“语音”中察看可用语音库，并设置本属性值为该语音库的序号减1。"), CategoryAttribute("语音")]
        public int VoiceIndex
        {
            get { return _voiceIndex; }
            set { _voiceIndex = value; }
        }
    }

    #endregion 
}
