using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Cn.Youdundianzi.Core.Util;

namespace Cn.Youdundianzi.Core.Signal
{
    public class SignalMonitorFactory
    {
        public static ISignalMonitor CreateSignalMonitor(string assName, string monitorName, ISettings setting)
        {
            try
            {
                Assembly ass = Assembly.LoadFrom(assName);
                Type t = ass.GetType(monitorName);
                ISignalMonitor mon = (ISignalMonitor)Activator.CreateInstance(t, new object[] { setting });
                return mon;
            }
            catch(TargetInvocationException te)
            {
                throw te.InnerException;
            }
        }

        public static ISignalMonitor CreateSignalMonitor(AssemblyInfoPair monPair, ISettings setting)
        {
            return CreateSignalMonitor(monPair.AssemblyName, monPair.ClassName, setting);
        }
    }
}
