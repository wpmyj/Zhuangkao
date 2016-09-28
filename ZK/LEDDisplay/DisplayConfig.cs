using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Util;
using System.ComponentModel;

namespace Cn.Youdundianzi.Share.LEDDisplay
{
    public class DisplayConfig:ISettings

    {
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

        //private DisplayBS _displaybs = DisplayBS.SmallDisplay;
        //[DescriptionAttribute("显示屏类型，大屏为BigDisplay,小屏为SmallDisplay。"), CategoryAttribute("显示屏通讯设置")]
        //public DisplayBS Displaybs
        //{
        //    get { return _displaybs; }
        //    set { _displaybs = value; }
        //}


        //private byte _addresscode;
        //[DescriptionAttribute("显示屏地址设置，注意为十进制值，16进制前加0x。"), CategoryAttribute("显示屏通讯设置")]
        //public byte Addresscode
        //{
        //    get { return _addresscode; }
        //    set { _addresscode = value; }
        //}

        private byte _displaySpeed;
        [DescriptionAttribute("显示屏翻屏或移动速度。"), CategoryAttribute("显示屏通讯设置")]
        public byte DisplaySpeed
        {
            get { return _displaySpeed; }
            set { _displaySpeed = value; }
        }

        private DisplayType _displayType = DisplayType.Gundisp;
        [DescriptionAttribute("显示类型设置，Zhidisp=0x30直屏显示,Gundisp=0x31翻屏或移屏显示。"), CategoryAttribute("显示屏通讯设置")]
        public DisplayType DisplayType
        {
            get { return _displayType; }
            set { _displayType = value; }
        }


        //private int _displaywidth;
        //[DescriptionAttribute("屏幕宽度，像素为单位！"), CategoryAttribute("显示屏通讯设置")]
        //public int DisplayWidth
        //{
        //    get { return _displaywidth; }
        //    set { _displaywidth = value; }
        //}


        //private int _displayheight;
        //[DescriptionAttribute("屏幕高度，像素为单位！"), CategoryAttribute("显示屏通讯设置")]
        //public int DisplayHeight
        //{
        //    get { return _displayheight; }
        //    set { _displayheight = value; }
        //}

        private string welcome_string;
        [DescriptionAttribute("在大屏上显示欢迎词！"), CategoryAttribute("显示屏通讯设置")]
        public string Welcome
        {
            get { return welcome_string; }
            set { welcome_string = value; }
        }
    }
}
