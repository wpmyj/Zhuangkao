using System;
using System.Collections.Generic;
using System.Text;

namespace zkcenter
{
    public enum DisplayType : byte
    {
        Zhidisp=0x30,
        Gundisp=0x31
    }

    public enum DisplayBS 
    {
        BigDisplay,
        SmallDisplay
    }

    class CDisplayData
    {
        public DisplayType DispType;
        public byte Speed;
        public string DisplayText;
        private Int16 _TextLength;
        public byte AddressCode;
        ModuleSettings settings;

        public CDisplayData(ModuleSettings settings)
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
                string[] tempSperator = new string[1];
                tempSperator[0] = "\r\n";
                string[] txtLines = DisplayText.Split(tempSperator, StringSplitOptions.None);
                foreach (string txtline in txtLines)
                {
                    string temptxtline = string.Empty;
                    if (settings.Displaybs == DisplayBS.BigDisplay)
                        temptxtline = "        " + txtline;
                    else
                        temptxtline = txtline;
                    _TextLength += (Int16)(System.Text.ASCIIEncoding.Default.GetBytes(temptxtline)).Length;
                    if (settings.Displaybs == DisplayBS.BigDisplay)
                    {
                        _TextLength += 1;
                    }
                }
                if (settings.Displaybs == DisplayBS.BigDisplay)
                    _TextLength += 3;
                else
                    _TextLength += 2;

                //if (settings.Displaybs == DisplayBS.BigDisplay)
                //{
                //    _TextLength = (Int16)((System.Text.ASCIIEncoding.Default.GetBytes(DisplayText)).Length + 3);
                //}
                //else
                //{
                //    _TextLength = (Int16)((System.Text.ASCIIEncoding.Default.GetBytes(DisplayText)).Length + 2);
                //}
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
                string[] tempSperator = new string[1];
                tempSperator[0] = "\r\n";
                string[] txtLines = DisplayText.Split(tempSperator, StringSplitOptions.None);
                foreach (string txtline in txtLines)
                {
                    string temptxtline = string.Empty;
                    if (settings.Displaybs == DisplayBS.BigDisplay)
                        temptxtline = "        " + txtline;
                    else
                        temptxtline = txtline;
                    result.AddRange(System.Text.ASCIIEncoding.Default.GetBytes(temptxtline));
                    if (settings.Displaybs == DisplayBS.BigDisplay)
                    {
                        result.Add(0x0A);
                    }
                }
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
