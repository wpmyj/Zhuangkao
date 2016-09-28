
//                             通讯协议
//  波特率：4800   数据：8BIT  起始位：1BIT 停止位：1BIT  无奇偶校验
 
//1.0 主显示屏内容数据发送帧
//帧方向
//控制主机－>  显示屏
//发起帧组成
//前导码(2)＋地址码(1)＋字节数(4)+显示类型(1)＋翻屏速度(1)+显示汉字内码+校验和（1）
//发起帧内容释义
//          前导码：0X55 0x55
//          地址码：0X30
//          字节数(4)：高位+低位+高位反+低位反：等于汉字内码字节数加2
//          显示类型：0x30 ：直显
//                    0X31 ：翻屏
//          翻屏速度： 1--15 快--慢
//显示汉字内容：显示的汉字的区位码，占用的字节数与该屏的内容长度有关系。
//   (每行以0X0A结束)
//校验和    ：不包括前导码的所有发起帧数据的异或值

//返回帧组成
//前导码(2)＋地址码(1)＋返回结果(1)
//返回帧内容释义
//前导码：0X55 0x55
//          地址码： 0x30
//          返回结果：0x00          --该数据帧发送成功
//                    0xff           --该数据帧发送失败 

//1.0小显示屏内容数据发送帧（汉字）
//帧方向
//控制主机－>  显示屏
//发起帧组成
//前导码(2)＋地址码(1)＋字节数(4) +显示类型(1)＋移动速度(1)+显示汉字内码+校验和（1）
//发起帧内容释义
//          前导码：0X55 0x55
//          字节数(4)：高位+低位+高位反+低位反：等于汉字内码字节数加2
//          地址码：0X31------0X3A
//          显示类型：0x30 ：直显
//                    0X31 ：左移
//          移动速度： 1--15 快--慢
//显示汉字内容：显示的汉字的区位码，占用的字节数与该屏的内容长度有关系。            
//校验和    ：不包括前导码的所有发起帧数据的异或值

//返回帧组成
//前导码(2)＋地址码(1)＋返回结果(1)
//返回帧内容释义
//前导码：0X55 0x55
//          地址码：0X31------0X3A
//          返回结果：0x00          --该数据帧发送成功
//                    0xff           --该数据帧发送失败 
//--------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Share.LEDDisplay
{
    //public enum DisplayType : byte
    //{
    //    Zhidisp=0x30,
    //    Gundisp=0x31
    //}

    //public enum DisplayBS 
    //{
    //    BigDisplay,
    //    SmallDisplay
    //}

    class CDisplayDataTLSC : LEDDisplay.IDisplayData
    {
        public DisplayType DispType;
        public byte Speed;
        public string DisplayText;
        private Int16 _TextLength;
        public byte AddressCode;
        DisplayConfigTLSC settings;

        public CDisplayDataTLSC(DisplayConfigTLSC settings)
        {
            this.settings = settings;
            DispType = DisplayType.Gundisp;
            Speed = 8;
            DisplayText = string.Empty;
            AddressCode = 0x30;
        }

        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //压入前导码
            result.Add(0x55);
            result.Add(0x55);

            //压入地址码
            result.Add(AddressCode);

            if (DisplayText != string.Empty)
            {
                if (settings.Displaybs == DisplayBS.BigDisplay)
                {
                    _TextLength = (Int16)((System.Text.ASCIIEncoding.Default.GetBytes(DisplayText)).Length + 3);
                }
                else
                {
                    _TextLength = (Int16)((System.Text.ASCIIEncoding.Default.GetBytes(DisplayText)).Length + 2);
                }
                //压入字节数，为文本长度加2个字节
                byte[] tmplength = BitConverter.GetBytes(_TextLength);
                result.Add(tmplength[1]);
                result.Add(tmplength[0]);
                result.Add((byte)(~tmplength[1]));
                result.Add((byte)(~tmplength[0]));

            }
            else
            {
                result.AddRange(BitConverter.GetBytes((int)2));
            }

            //压入显示类型
            result.Add((byte)DispType);

            //压入显示速度
            result.Add(Speed);

            if (DisplayText != string.Empty)
            {
                //压入文本
                result.AddRange(System.Text.ASCIIEncoding.Default.GetBytes(DisplayText));
            }

            if (settings.Displaybs == DisplayBS.BigDisplay)
            {
                result.Add(0x0A);
            }
            
            byte verify=0;
            for (int i = 2; i < result.Count; i++)
            {
                verify = (byte)(verify^ result[i]);
            }
            //压入异或校验位
            result.Add(verify);

            return result.ToArray();
        }
       
    }
}
