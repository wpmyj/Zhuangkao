using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Cn.Youdundianzi.Core.Util;

namespace Cn.Youdundianzi.Core.Exam
{
    public class StateManagerFactory
    {
        public static IStateManager CreateStateManager(AssemblyInfoPair info, ITranslator translator, ISettings setting)
        {
            return CreateStateManager(info.AssemblyName, info.ClassName, translator, setting);
        }

        public static IStateManager CreateStateManager(string assName, string stateManagerName,ITranslator translator, ISettings setting)
        {
            Assembly ass = Assembly.LoadFrom(assName);
            Type t = ass.GetType(stateManagerName);
            IStateManager mgr = (IStateManager)Activator.CreateInstance(t, new object[] {translator, setting });
            return mgr;
        }
    }
}
