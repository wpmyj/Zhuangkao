using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Exam
{
    public class Logger
    {
        public static string CHANGE_STATE_PREFIX = "#状态转到：";
        public static string START_STATE_TIME_OUT_THREAD_PREFIX = "#设置定时：";
        public static string ABORT_STATE_TIME_OUT_THREAD_PREFIX = "#中断定时时，所包含异常：";
        public static string FAILURE_PREFIX = "失败：";
        public static string SUCCESS_PREFIX = "成功：";
        public static string SIGNAL_PREFIX = "@";
        private static System.IO.TextWriter sw = Console.Out;
        public static System.IO.TextWriter LogTextWriter
        {
            get { return sw; }
            set { sw = value; }
        }

        public static void Log(string str)
        {
            try
            {
                sw.WriteLine(str);
                sw.Flush();
            }
            catch (System.IO.IOException e)
            {
                sw = Console.Out;
            }
        }
    }
}
