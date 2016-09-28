using System;
using System.Collections.Generic;
using System.Text;

namespace lukao
{
    public class CMyMessageFuns
    {
        private byte[] data;
        

        public CMyMessageFuns()
        {
           // data = new byte[30];
        }

        public void InputData(byte[] data)
        {
            this.data = data;
        }

        public int GetCmdLength() //包含命令头和结束字节在内的所有字节长度
        {
            switch (GetCmdWord())
            {
                case 0x31:
                    return 6;
                case 0x32:
                    return 6;
                case 0x33:
                    return 7;
                case 0x34:
                    return 7;
                case 0x35:
                    return 20;
                case 0x36:
                    return 6;
                case 0x37:
                    return 6;
                case 0x38:
                    return 15;
                case 0x39:
                    return 6;
                default:
                    return 0;
            }
        }

        //--------命令头--------------
        public void SetCmdHead()
        {
            data[0] = 0x7E;
        }
        public byte GetCmdHead()
        {
            return data[0];
        }


        //---------命令字-------------------
        public void SetCmdWord(byte cmdword)
        {
            data[1] = cmdword;
        }
        public byte GetCmdWord()
        {
            return data[1];
        }


        //--------------设备号-----------------
        public void SetDevnum(string devnum)
        {
            byte[] tmpbyte;
            tmpbyte = System.Text.ASCIIEncoding.Default.GetBytes(devnum);
            data[2] = tmpbyte[0];
            data[3] = tmpbyte[1];
        }
        public string GetDevnum()
        {
            byte[] tmpbyte = new byte[2];
            tmpbyte[0] = data[2];
            tmpbyte[1] = data[3];
            return System.Text.ASCIIEncoding.Default.GetString(tmpbyte);
        }


        //----------返回查询状态------------------------
        public void SetStatus(byte zt)
        {
            data[4] = zt;
        }
        public byte GetStatus()
        {
            return data[4];
        }

        //----------准考证号------------------------
        public void SetZkzhm(string zkzhm)
        {
            string tmpstr = zkzhm.Substring(zkzhm.Length - 7);
            byte[] tmpbyte;
            tmpbyte = System.Text.ASCIIEncoding.Default.GetBytes(zkzhm);
            for (int i = 0; i < 6; i++)
            {
                data[4+i] = tmpbyte[i];
            }
        }
        public string GetZkzhm()
        {
            byte[] tmpbyte = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                tmpbyte[i] = data[4 + i];
            }
            return System.Text.ASCIIEncoding.Default.GetString(tmpbyte);
        }

        //------------姓名----------------------
        public void SetXm(string xm)
        {
            byte[] tmpbyte;
            tmpbyte = System.Text.ASCIIEncoding.Default.GetBytes(xm);
            if (tmpbyte.Length < 8)
            {
                for (int i = 0; i < tmpbyte.Length; i++)
                {
                    data[i + 10] = tmpbyte[i];
                }
                int t = tmpbyte.Length;
                for (int j = 0; j < 8 - tmpbyte.Length; j++)
                {
                    data[t + 10] = 0x20;
                    t++;
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    data[i + 10] = tmpbyte[i];
                }
            }
        }
        public string GetXm()
        {
            byte[] tmpbyte = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                tmpbyte[i] = data[i + 10];
            }
            return System.Text.ASCIIEncoding.Default.GetString(tmpbyte);
        }

        //-------------成绩----------------------
        public void SetKscj(int kscj)
        {
            int tmpi=kscj;
            for (int i = 10; i < 13; i++)
            {
                data[i] = 48+9; //默认值999
            }
            for (int i = 12; i > 9; i--)
            {
                data[i] = (byte)(tmpi % 10 + 48);
                tmpi = tmpi / 10;
            }
        }
        public int GetKscj()
        {
            byte[] tmpbyte = new byte[3];
            tmpbyte[0] = data[10];
            tmpbyte[1] = data[11];
            tmpbyte[2] = data[12];
            try
            {
                return Convert.ToInt16(System.Text.ASCIIEncoding.Default.GetString(tmpbyte));
            }
            catch
            {
                return 999;
            }
        }

        //----------计算校验码不影响data中的校验位-------------------------------
        public byte CountVerifyCode()
        {
            byte b=0;

            for (int i = 1; i < GetCmdLength() - 2; i++)
            {
                b = Convert.ToByte(b ^ data[i]);
            }
            //if (b < 0x21)
            //{
            //    b = (byte)(b + 0x21);
            //}
            return b;
        }

        //--------------从数据中取出校验码--------------------
        public byte GetVerifyCode()
        {
            return data[GetCmdLength() - 2];
        }

        //-------------设置校验码影响data中的校验位-----------------------------
        public void SetVerifyCode()
        {
            byte b = 0;

            for (int i = 1; i < GetCmdLength() - 2; i++)
            {
                b = Convert.ToByte(b ^ data[i]);
            }
            //if (b < 0x21)
            //{
            //    b = (byte)(b + 0x21);
            //}
            data[GetCmdLength() - 2] = b;
        }


        //------------结束字节-----------------------
        public void SetEndCode()
        {
            data[GetCmdLength() - 1] = 0xFF;
        }
        public byte GetEndCode()
        {
            return data[GetCmdLength() - 1];
        }
        
        //--------Data数据清零--------------------
        public void ClearData() 
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
            }
        }


    }
}
