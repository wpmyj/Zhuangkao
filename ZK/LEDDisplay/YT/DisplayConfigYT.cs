using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Cn.Youdundianzi.Share.LEDDisplay
{
    public class DisplayConfigYT : DisplayConfig
    {
        private int _displaywidth;
        [DescriptionAttribute("屏幕宽度，像素为单位！"), CategoryAttribute("显示屏通讯设置")]
        public int DisplayWidth
        {
            get { return _displaywidth; }
            set { _displaywidth = value; }
        }


        private int _displayheight;
        [DescriptionAttribute("屏幕高度，像素为单位！"), CategoryAttribute("显示屏通讯设置")]
        public int DisplayHeight
        {
            get { return _displayheight; }
            set { _displayheight = value; }
        }

    }
}
