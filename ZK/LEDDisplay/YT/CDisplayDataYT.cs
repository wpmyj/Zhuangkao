//********************************************************************
//通信协议: RS232C电平（或485电平）,9600,无校验
//数据格式:
//1、立即显示
//字节      内容       注释
//1         1bH       头
//2         01H       头
//3           w        屏宽(像素/8)
//4           h        屏高(像素/16)
//5           t        屏类型（00：单色  01：双色）
//6          03         立即显示命令
//7          n        要显示的字符总字节数(即不包含zh,ys,x,y这4个字节和结束字节)
//8         zh        字号      （01：16点阵  02：32点阵）
//9         ys        颜色      （01:  红     02：绿  03：黄）
//10        x       水平方向的坐标像素=8*x   
//11        y       垂直方向的坐标像素=16*y
//以下为显示的字符代码
//12、13             第一个汉字的2字节内码或2个ASCII码
//14、15             第二个汉字的2字节内码或2个ASCII码
//.         
//.        
//.        
//最后一个字节     7fH       结束标志

//2、左滚动显示
//字节      内容       注释
//1         1bH       头
//2         01H       头
//3           w        屏宽(像素/8)
//4           h        屏高(像素/16)
//5           t        屏类型（00：单色  01：双色）
//6          06        左滚动显示命令
//7          n        要显示的字符总字节数(即不包含zh,ys,x,y这4个字节和结束字节)
//8         zh        字号      （01：16点阵  02：32点阵）
//9         ys        颜色      （01:  红     02：绿  03：黄）
//10          v         左滚动速度  （1，2，3,4,5,6,7,8,9,）
//11         kd       左滚动显示全部内容的实际宽度（单位：字节）,字号为1时：一个汉字占2字节宽度，ASCII码占1字节宽度。字号为2时：一个汉字占4字节宽度，ASCII码占2字节宽度。

//以下为显示的字符代码
//12、13             第一个汉字的2字节内码或2个ASCII码
//14、15             第二个汉字的2字节内码或2个ASCII码
//.         
//.        
//.        
//最后一个字节     7fH       结束标志

//3、上滚动显示
//字节      内容       注释
//1         1bH       头
//2         01H       头
//3           w        屏宽(像素/8)
//4           h        屏高(像素/16)
//5           t        屏类型（00：单色  01：双色）
//6          07        上滚动显示命令
//7          n        要显示的字符总字节数(即不包含zh,ys,x,y这4个字节和结束字节)
//8         zh        字号      （01：16点阵  02：32点阵）
//9         ys        颜色      （01:  红     02：绿  03：黄）
//10          v         上滚动速度  （1，2，3,4,5,6,7,8,9,）
//11         gd       上滚动显示全部内容的实际高度（单位：字高 即像素/16）,字号为1时：一个汉字或ASCII码占1个字高度。字号为2时：一个汉字或ASCII码占2个字高度。

//以下为显示的字符代码
//12、13             第一个汉字的2字节内码或2个ASCII码
//14、15             第二个汉字的2字节内码或2个ASCII码
//.         
//.        
//.        
//最后一个字节     7fH       结束标志

//4、清屏命令：
//1    1BH         头
//2     01         头
//3           w        屏宽(像素/8)
//4           h        屏高(像素/16)
//5           t        屏类型（00：单色  01：双色）
//6          04H        清屏命令
//7          7fH        结束标志

//5、握手命令：
//1    1BH         头
//2     01         头
//3           w        屏宽(像素/8)
//4           h        屏高(像素/16)
//5           t        屏类型（00：单色  01：双色）
//6          05H        命令
//7          7fH        结束标志

//接收到该命令后：返回“0K”

//6、关机命令：
//1    1BH         头
//2     01         头
//3           w        屏宽(像素/8)
//4           h        屏高(像素/16)
//5           t        屏类型（00：单色  01：双色）
//6          08H        命令
//7          7fH        结束标志


//7、开机命令：
//1    1BH         头
//2     01         头
//3           w        屏宽(像素/8)
//4           h        屏高(像素/16)
//5           t        屏类型（00：单色  01：双色）
//6          09H        命令
//7          7fH        结束标志

//8、亮度输出命令：
//1    1BH         头
//2     01         头
//3           w        屏宽(像素/8)
//4           h        屏高(像素/16)
//5           t        屏类型（00：单色  01：双色）
//6          0aH        命令
//7           b       亮度值（0-----3）共4级亮度
//7          7fH        结束标志

//说明：1、 坐标从（0，0）开始
//      2、 坐标以宽8高16像素为一个基本单位。如坐标（0，0） 表示（0像素，0像素）的屏幕位置。
//                                            坐标（1，1） 表示（8像素，16像素）的屏幕位置
//      3、支持自动换行，无须用户发换行命令，下一行的X坐标从0开始。
//4、上滚动显示支持自动换行功能，显示内容实际高度可超出屏幕实际高度，起始坐标为（0，0）。
//5、左滚动显示支持自动换行功能，显示内容实际宽度可超出屏幕实际宽度，起始坐标为（0，0）。
//6、控制卡支持双色显示屏。
//********************************************************************



using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Share.LEDDisplay
{
    public enum DisplayType : byte
    {
        Zhidisp=0x30,
        Gundisp=0x31,
        ZYGundisp=0x32
    }

    public enum DisplayBS 
    {
        BigDisplay,
        SmallDisplay
    }

    public enum DisplayCommand : byte
    {
        show = 0x50, // 显示标语
        closedisplay = 0x51, //: 关闭显示
        selectbiaoyu = 0x52,// : 选择标语
        deletebiaoyu = 0x53, //: 删除标语
        displaymode = 0x54, //: 显示模式
        displayspeed = 0x55 //移动速度
    }

     class CDisplayDataYT : LEDDisplay.IDisplayData
    {
        public DisplayType DispType;
        public byte Speed;
        public string DisplayText;
        private byte _TextLength;
        DisplayConfigYT settings;

         public CDisplayDataYT(DisplayConfigYT settings)
        {
            this.settings = settings;
            DispType = settings.DisplayType;
            Speed = settings.DisplaySpeed;
            DisplayText = string.Empty;
        }

        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //压入前导码
            result.Add(0x1b);
            result.Add(0x01);

            //压入屏幕规格 
            result.Add((byte)(settings.DisplayWidth / 8));
            result.Add((byte)(settings.DisplayHeight / 16));


            //压入屏幕类型
            result.Add(0x00); //屏类型（00：单色  01：双色）

            //压入显示命令          
            //03        立即显示命令
            //06        左滚动显示命令
            //07        上滚动显示命令
          
            //.例子 1b 01 18 0c 00 03 04 01 01 00 00 41 41 41 41 7f 
            switch (settings.DisplayType)
            {
                case DisplayType.Zhidisp:
                    result.Add(0x03);
                    if (DisplayText != string.Empty)
                    {
                        _TextLength = (byte)((System.Text.ASCIIEncoding.Default.GetBytes(DisplayText)).Length);
                        result.Add(_TextLength);//压入文本长度

                        result.Add(0x01);
                        result.Add(0x01);
                        result.Add(0x0);
                        result.Add(0x0);
                        //压入文本
                        result.AddRange(System.Text.ASCIIEncoding.Default.GetBytes(DisplayText));
                        result.Add(0x7f);
                    }
                    else
                    {
                        result.Add(0x0);
                        result.Add(0x01);
                        result.Add(0x01);
                        result.Add(0x0);
                        result.Add(0x0);
                        result.Add(0x7f);
                    }
                    break;
                case DisplayType.Gundisp:
                    result.Add(0x07);
                    if (DisplayText != string.Empty)
                    {
                        _TextLength = (byte)((System.Text.ASCIIEncoding.Default.GetBytes(DisplayText)).Length);
                        result.Add(_TextLength);//压入文本长度
                    }
                    else
                    {
                        result.Add(0x0);
                    }

                    result.Add(0x01);
                    result.Add(0x01);
                    if (settings.DisplaySpeed > 9 || settings.DisplaySpeed < 1)
                    {
                        result.Add(1);
                    }
                    else
                    {
                        result.Add(settings.DisplaySpeed);
                    }
                    result.Add(0x18);
                    //压入文本
                    if (DisplayText != string.Empty)
                    {
                        result.AddRange(System.Text.ASCIIEncoding.Default.GetBytes(DisplayText));
                    }
                    result.Add(0x7f);

                    break;
                case DisplayType.ZYGundisp:
                    result.Add(0x06);
                    if (DisplayText != string.Empty)
                    {
                        _TextLength = (byte)((System.Text.ASCIIEncoding.Default.GetBytes(DisplayText)).Length);
                        result.Add(_TextLength);//压入文本长度
                    }
                    else
                    {
                        result.Add(0x0);
                    }

                    result.Add(0x01);
                    result.Add(0x01);
                    if (settings.DisplaySpeed > 9 || settings.DisplaySpeed < 1)
                    {
                        result.Add(1);
                    }
                    else
                    {
                        result.Add(settings.DisplaySpeed);
                    }
                    result.Add(0x18);
                    //压入文本
                    if (DisplayText != string.Empty)
                    {
                        result.AddRange(System.Text.ASCIIEncoding.Default.GetBytes(DisplayText));
                    }
                    result.Add(0x7f);

                    break;
            }
            return result.ToArray();
        }
       
    }
}
