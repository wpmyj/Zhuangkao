//********************************************************************
//2006��4��20֮ǰ��ͨѶЭ��
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

//�����ʣ�9600 
//   start: 1 bit�� data: 8 bit�� stop: 1 bit�� no parity check
//   ����֡��ʽ��12 �ֽ�/����֡   
//      �� ʼ�� 0x55  0xab      2�ֽ�
//      �� � 0x5X            1�ֽ�
//         ˵���� 0x50 : ��ʾ����
//                0x51 : �ر���ʾ
//                0x52 : ѡ�����
//                0x53 : ɾ������
//                0x54 : ��ʾģʽ
//                0x55 : �ƶ��ٶ�
//      �������� 0x30+��ֵ      1�ֽ�
//         ��ֵ˵���� ��ʾ��� ��ʾ�ֵ����ֽ�����ASCII��1�ֽڣ����֣�2�ֽڣ�
//                    �ر���ʾ�� ��Ч
//                    ѡ���� �����   1--105
//                    ɾ����� �����   1--105
//                    ��ʾģʽ�� 0--2
//                    �ƶ��ٶȣ� 1--15 ��--�� 
//      �ֱ��룺  ��ASCII����λ�����   X���ֽ�
//      XORУ�飺 0xXX          1�ֽ� 
//         ˵���� 2--8�ֽڵ�XORֵ
//      ��  ����  0x5a  0xa5    2�ֽ�


//    Ӧ��֡��  OK��  ����֡��ȷ
//              ER��  ����֡�����ط�
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

            //ѹ��ǰ����
            result.Add(0x55);
            result.Add(0xab);

            //ѹ�뿼������
            result.Add((byte)dispcommand);

            switch (dispcommand)
            {
                case DisplayCommand.show://��ʾ�ı�
                    if (DisplayText != string.Empty)
                    {
                        _TextLength =(byte)((System.Text.ASCIIEncoding.Default.GetBytes(DisplayText)).Length + 0x30);
                        //ѹ���ֽ�����Ϊ�ı����ȼ�2���ֽ�
                        byte[] tmplength = BitConverter.GetBytes(_TextLength);
                        result.Add(_TextLength);
                    }
                    else
                    {
                        result.Add(0x30);
                    }
                    if (DisplayText != string.Empty)
                    {
                        //ѹ���ı�
                        result.AddRange(System.Text.ASCIIEncoding.Default.GetBytes(DisplayText));
                    }
                    break;
                case DisplayCommand.closedisplay://�ر���ʾ
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
            //ѹ�����У��λ
            result.Add(verify);
            result.Add(0x5a);
            result.Add(0xa5);
            return result.ToArray();
        }
       
    }
}
