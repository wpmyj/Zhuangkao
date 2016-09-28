//********************************************************************
//ͨ��Э��: RS232C��ƽ����485��ƽ��,9600,��У��
//���ݸ�ʽ:
//1��������ʾ
//�ֽ�      ����       ע��
//1         1bH       ͷ
//2         01H       ͷ
//3           w        ����(����/8)
//4           h        ����(����/16)
//5           t        �����ͣ�00����ɫ  01��˫ɫ��
//6          03         ������ʾ����
//7          n        Ҫ��ʾ���ַ����ֽ���(��������zh,ys,x,y��4���ֽںͽ����ֽ�)
//8         zh        �ֺ�      ��01��16����  02��32����
//9         ys        ��ɫ      ��01:  ��     02����  03���ƣ�
//10        x       ˮƽ�������������=8*x   
//11        y       ��ֱ�������������=16*y
//����Ϊ��ʾ���ַ�����
//12��13             ��һ�����ֵ�2�ֽ������2��ASCII��
//14��15             �ڶ������ֵ�2�ֽ������2��ASCII��
//.         
//.        
//.        
//���һ���ֽ�     7fH       ������־

//2���������ʾ
//�ֽ�      ����       ע��
//1         1bH       ͷ
//2         01H       ͷ
//3           w        ����(����/8)
//4           h        ����(����/16)
//5           t        �����ͣ�00����ɫ  01��˫ɫ��
//6          06        �������ʾ����
//7          n        Ҫ��ʾ���ַ����ֽ���(��������zh,ys,x,y��4���ֽںͽ����ֽ�)
//8         zh        �ֺ�      ��01��16����  02��32����
//9         ys        ��ɫ      ��01:  ��     02����  03���ƣ�
//10          v         ������ٶ�  ��1��2��3,4,5,6,7,8,9,��
//11         kd       �������ʾȫ�����ݵ�ʵ�ʿ�ȣ���λ���ֽڣ�,�ֺ�Ϊ1ʱ��һ������ռ2�ֽڿ�ȣ�ASCII��ռ1�ֽڿ�ȡ��ֺ�Ϊ2ʱ��һ������ռ4�ֽڿ�ȣ�ASCII��ռ2�ֽڿ�ȡ�

//����Ϊ��ʾ���ַ�����
//12��13             ��һ�����ֵ�2�ֽ������2��ASCII��
//14��15             �ڶ������ֵ�2�ֽ������2��ASCII��
//.         
//.        
//.        
//���һ���ֽ�     7fH       ������־

//3���Ϲ�����ʾ
//�ֽ�      ����       ע��
//1         1bH       ͷ
//2         01H       ͷ
//3           w        ����(����/8)
//4           h        ����(����/16)
//5           t        �����ͣ�00����ɫ  01��˫ɫ��
//6          07        �Ϲ�����ʾ����
//7          n        Ҫ��ʾ���ַ����ֽ���(��������zh,ys,x,y��4���ֽںͽ����ֽ�)
//8         zh        �ֺ�      ��01��16����  02��32����
//9         ys        ��ɫ      ��01:  ��     02����  03���ƣ�
//10          v         �Ϲ����ٶ�  ��1��2��3,4,5,6,7,8,9,��
//11         gd       �Ϲ�����ʾȫ�����ݵ�ʵ�ʸ߶ȣ���λ���ָ� ������/16��,�ֺ�Ϊ1ʱ��һ�����ֻ�ASCII��ռ1���ָ߶ȡ��ֺ�Ϊ2ʱ��һ�����ֻ�ASCII��ռ2���ָ߶ȡ�

//����Ϊ��ʾ���ַ�����
//12��13             ��һ�����ֵ�2�ֽ������2��ASCII��
//14��15             �ڶ������ֵ�2�ֽ������2��ASCII��
//.         
//.        
//.        
//���һ���ֽ�     7fH       ������־

//4���������
//1    1BH         ͷ
//2     01         ͷ
//3           w        ����(����/8)
//4           h        ����(����/16)
//5           t        �����ͣ�00����ɫ  01��˫ɫ��
//6          04H        ��������
//7          7fH        ������־

//5���������
//1    1BH         ͷ
//2     01         ͷ
//3           w        ����(����/8)
//4           h        ����(����/16)
//5           t        �����ͣ�00����ɫ  01��˫ɫ��
//6          05H        ����
//7          7fH        ������־

//���յ�������󣺷��ء�0K��

//6���ػ����
//1    1BH         ͷ
//2     01         ͷ
//3           w        ����(����/8)
//4           h        ����(����/16)
//5           t        �����ͣ�00����ɫ  01��˫ɫ��
//6          08H        ����
//7          7fH        ������־


//7���������
//1    1BH         ͷ
//2     01         ͷ
//3           w        ����(����/8)
//4           h        ����(����/16)
//5           t        �����ͣ�00����ɫ  01��˫ɫ��
//6          09H        ����
//7          7fH        ������־

//8������������
//1    1BH         ͷ
//2     01         ͷ
//3           w        ����(����/8)
//4           h        ����(����/16)
//5           t        �����ͣ�00����ɫ  01��˫ɫ��
//6          0aH        ����
//7           b       ����ֵ��0-----3����4������
//7          7fH        ������־

//˵����1�� ����ӣ�0��0����ʼ
//      2�� �����Կ�8��16����Ϊһ��������λ�������꣨0��0�� ��ʾ��0���أ�0���أ�����Ļλ�á�
//                                            ���꣨1��1�� ��ʾ��8���أ�16���أ�����Ļλ��
//      3��֧���Զ����У������û������������һ�е�X�����0��ʼ��
//4���Ϲ�����ʾ֧���Զ����й��ܣ���ʾ����ʵ�ʸ߶ȿɳ�����Ļʵ�ʸ߶ȣ���ʼ����Ϊ��0��0����
//5���������ʾ֧���Զ����й��ܣ���ʾ����ʵ�ʿ�ȿɳ�����Ļʵ�ʿ�ȣ���ʼ����Ϊ��0��0����
//6�����ƿ�֧��˫ɫ��ʾ����
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
        show = 0x50, // ��ʾ����
        closedisplay = 0x51, //: �ر���ʾ
        selectbiaoyu = 0x52,// : ѡ�����
        deletebiaoyu = 0x53, //: ɾ������
        displaymode = 0x54, //: ��ʾģʽ
        displayspeed = 0x55 //�ƶ��ٶ�
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

            //ѹ��ǰ����
            result.Add(0x1b);
            result.Add(0x01);

            //ѹ����Ļ��� 
            result.Add((byte)(settings.DisplayWidth / 8));
            result.Add((byte)(settings.DisplayHeight / 16));


            //ѹ����Ļ����
            result.Add(0x00); //�����ͣ�00����ɫ  01��˫ɫ��

            //ѹ����ʾ����          
            //03        ������ʾ����
            //06        �������ʾ����
            //07        �Ϲ�����ʾ����
          
            //.���� 1b 01 18 0c 00 03 04 01 01 00 00 41 41 41 41 7f 
            switch (settings.DisplayType)
            {
                case DisplayType.Zhidisp:
                    result.Add(0x03);
                    if (DisplayText != string.Empty)
                    {
                        _TextLength = (byte)((System.Text.ASCIIEncoding.Default.GetBytes(DisplayText)).Length);
                        result.Add(_TextLength);//ѹ���ı�����

                        result.Add(0x01);
                        result.Add(0x01);
                        result.Add(0x0);
                        result.Add(0x0);
                        //ѹ���ı�
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
                        result.Add(_TextLength);//ѹ���ı�����
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
                    //ѹ���ı�
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
                        result.Add(_TextLength);//ѹ���ı�����
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
                    //ѹ���ı�
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
