using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Logger
    {
#if DEBUG
        private static System.IO.TextWriter sw = Console.Out;
#else
        private static System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Path.Combine(Environment.CurrentDirectory, "log.txt"), true);
#endif

        public static void Log(string str)
        {
            sw.WriteLine(str);
            sw.Flush();
        }
    }
}
