
//                             ͨѶЭ��
//  �����ʣ�4800   ���ݣ�8BIT  ��ʼλ��1BIT ֹͣλ��1BIT  ����żУ��
 
//1.0 ����ʾ���������ݷ���֡
//֡����
//����������>  ��ʾ��
//����֡���
//ǰ����(2)����ַ��(1)���ֽ���(4)+��ʾ����(1)�������ٶ�(1)+��ʾ��������+У��ͣ�1��
//����֡��������
//          ǰ���룺0X55 0x55
//          ��ַ�룺0X30
//          �ֽ���(4)����λ+��λ+��λ��+��λ�������ں��������ֽ�����2
//          ��ʾ���ͣ�0x30 ��ֱ��
//                    0X31 ������
//          �����ٶȣ� 1--15 ��--��
//��ʾ�������ݣ���ʾ�ĺ��ֵ���λ�룬ռ�õ��ֽ�������������ݳ����й�ϵ��
//   (ÿ����0X0A����)
//У���    ��������ǰ��������з���֡���ݵ����ֵ

//����֡���
//ǰ����(2)����ַ��(1)�����ؽ��(1)
//����֡��������
//ǰ���룺0X55 0x55
//          ��ַ�룺 0x30
//          ���ؽ����0x00          --������֡���ͳɹ�
//                    0xff           --������֡����ʧ�� 

//1.0С��ʾ���������ݷ���֡�����֣�
//֡����
//����������>  ��ʾ��
//����֡���
//ǰ����(2)����ַ��(1)���ֽ���(4) +��ʾ����(1)���ƶ��ٶ�(1)+��ʾ��������+У��ͣ�1��
//����֡��������
//          ǰ���룺0X55 0x55
//          �ֽ���(4)����λ+��λ+��λ��+��λ�������ں��������ֽ�����2
//          ��ַ�룺0X31------0X3A
//          ��ʾ���ͣ�0x30 ��ֱ��
//                    0X31 ������
//          �ƶ��ٶȣ� 1--15 ��--��
//��ʾ�������ݣ���ʾ�ĺ��ֵ���λ�룬ռ�õ��ֽ�������������ݳ����й�ϵ��            
//У���    ��������ǰ��������з���֡���ݵ����ֵ

//����֡���
//ǰ����(2)����ַ��(1)�����ؽ��(1)
//����֡��������
//ǰ���룺0X55 0x55
//          ��ַ�룺0X31------0X3A
//          ���ؽ����0x00          --������֡���ͳɹ�
//                    0xff           --������֡����ʧ�� 
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

            //ѹ��ǰ����
            result.Add(0x55);
            result.Add(0x55);

            //ѹ���ַ��
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
                //ѹ���ֽ�����Ϊ�ı����ȼ�2���ֽ�
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

            //ѹ����ʾ����
            result.Add((byte)DispType);

            //ѹ����ʾ�ٶ�
            result.Add(Speed);

            if (DisplayText != string.Empty)
            {
                //ѹ���ı�
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
            //ѹ�����У��λ
            result.Add(verify);

            return result.ToArray();
        }
       
    }
}
