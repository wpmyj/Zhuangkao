using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Exam
{
    public class Logger
    {
        public static string CHANGE_STATE_PREFIX = "#״̬ת����";
        public static string START_STATE_TIME_OUT_THREAD_PREFIX = "#���ö�ʱ��";
        public static string ABORT_STATE_TIME_OUT_THREAD_PREFIX = "#�ж϶�ʱʱ���������쳣��";
        public static string FAILURE_PREFIX = "ʧ�ܣ�";
        public static string SUCCESS_PREFIX = "�ɹ���";
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
