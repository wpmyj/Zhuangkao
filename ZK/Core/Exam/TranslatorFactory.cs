using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Util;

namespace Cn.Youdundianzi.Core.Exam
{
    public class TranslatorFactory
    {
        public static ITranslator CreateTranslater(AssemblyInfoPair info, ISignalMonitor monitor)
        {
            return CreateTranslater(info.AssemblyName, info.ClassName, monitor);
        }

        public static ITranslator CreateTranslater(string assName, string translatorName, ISignalMonitor monitor)
        {
            Assembly ass = Assembly.LoadFrom(assName);
            Type t = ass.GetType(translatorName);
            ITranslator trans = (ITranslator)Activator.CreateInstance(t, new object[] { monitor });
            return trans;
        }
    }
}
