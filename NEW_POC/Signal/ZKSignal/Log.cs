using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Signal;

namespace Signal.ZKSignal
{
    public class Log
    {
        public static void WriteCMonData(CMonData data)
        {
            FileStream fs = new FileStream(@"C:\log.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            string a = string.Empty;
            for (int i = 0; i < data.che.Length; i++)
                a += data.che[i].ToString();
            sw.Write(a);
            sw.Write(Environment.NewLine);
            a = string.Empty;
            for (int i = 0; i < data.gan.Length; i++)
                a += data.gan[i].ToString();
            sw.Write(a);
            sw.Write(Environment.NewLine);
            a = string.Empty;
            for (int i = 0; i < data.xian.Length; i++)
                a += data.xian[i].ToString();
            sw.Write(a);
            sw.Write(Environment.NewLine);
            sw.Flush();
            sw.Close();
        }
    }
}
