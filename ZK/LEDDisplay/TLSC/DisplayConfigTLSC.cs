using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Cn.Youdundianzi.Share.LEDDisplay
{
    public class DisplayConfigTLSC : DisplayConfig
    {
        private DisplayBS _displaybs = DisplayBS.SmallDisplay;
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
    }
}
