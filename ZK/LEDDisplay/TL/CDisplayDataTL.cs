//********************************************************************
//2006。4。20之前的通讯协议
//  ----------------------------------------------------------
//  ;  start: 1 bit  data: 8 bit stop: 1 bit no parity check
//  ;  head   function   first   second    xor    end
//  ;   05h    50h       >=30h    >=30h    55h    06h
//  ;      function:    50h~54h
//  ;      50h: display  50h: off display  52h: select  53h: delete
//  ;      first data:  31h+send_data
//  ;      second data: no use 
//  ;      xor data:  head,funtion,first and second xor 
// ------------------------------------------------------------
//********************************************************************

//波特率：9600 
//   start: 1 bit， data: 8 bit， stop: 1 bit， no parity check
//   数据帧格式：12 字节/非字帧   
//      起 始： 0x55  0xab      2字节
//      命 令： 0x5X            1字节
//         说明： 0x50 : 显示标语
//                0x51 : 关闭显示
//                0x52 : 选择标语
//                0x53 : 删除标语
//                0x54 : 显示模式
//                0x55 : 移动速度
//      主参数： 0x30+数值      1字节
//         数值说明： 显示标语： 显示字的总字节数（ASCII：1字节，汉字：2字节）
//                    关闭显示： 无效
//                    选择标语： 标语号   1--105
//                    删除标语： 标语号   1--105
//                    显示模式： 0--2
//                    移动速度： 1--15 快--慢 
//      字编码：  由ASCII和区位码组成   X个字节
//      XOR校验： 0xXX          1字节 
//         说明： 2--8字节的XOR值
//      结  束：  0x5a  0xa5    2字节


//    应答帧：  OK：  数据帧正确
//              ER：  数据帧错误，重发
//********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Share.LEDDisplay
{
    class CDisplayDataTL : LEDDisplay.IDisplayData
    {
        public DisplayType DispType;
        public byte Speed;
        public string DisplayText;
        private byte _TextLength;
        public DisplayCommand dispcommand;
        DisplayConfigTL settings;

        public CDisplayDataTL(DisplayConfigTL settings)
        {
            this.settings = settings;
            DispType = settings.DisplayType;
            Speed = settings.DisplaySpeed;
            DisplayText = string.Empty;
            dispcommand = DisplayCommand.show;
        }

        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //压入前导码
            result.Add(0x55);
            result.Add(0xab);

            //压入考试命令
            result.Add((byte)dispcommand);

            switch (dispcommand)
            {
                case DisplayCommand.show://显示文本
                    if (DisplayText != string.Empty)
                    {
                        _TextLength =(byte)((System.Text.ASCIIEncoding.Default.GetBytes(DisplayText)).Length + 0x30);
                        //压入字节数，为文本长度加2个字节
                        byte[] tmplength = BitConverter.GetBytes(_TextLength);
                        result.Add(_TextLength);
                    }
                    else
                    {
                        result.Add(0x30);
                    }
                    if (DisplayText != string.Empty)
                    {
                        //压入文本
                        result.AddRange(System.Text.ASCIIEncoding.Default.GetBytes(DisplayText));
                    }
                    break;
                case DisplayCommand.closedisplay://关闭显示
                    for (int i = 0; i < 6; i++)
                    {
                        result.Add(0x20);
                    }
                    break;
                case DisplayCommand.displayspeed:
                    //if ((Speed) > 15 || (Speed < 1))
                    //{
                    //    Speed = 8;
                    //}
                    result.Add((byte)(Speed+0x30));
                    for (int i = 0; i < 5; i++)
                    {
                        result.Add(0x20);
                    }
                    break;
                case DisplayCommand.displaymode:
                    result.Add((byte)(DispType));
                    result.Add((byte)(DispType));
                    result.Add(0x30);
                    result.Add(0x30);
                    result.Add(0x20);
                    result.Add(0x20);
                    break;
            
            }

            
            byte verify=0;
            for (int i = 2; i < result.Count; i++)
            {
                verify = (byte)(verify^ result[i]);
            }
            //压入异或校验位
            result.Add(verify);
            result.Add(0x5a);
            result.Add(0xa5);
            return result.ToArray();
        }
       
    }
}
