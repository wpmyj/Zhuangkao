using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
//using Cn.Youdundianzi.Core.Util;


namespace Cn.Youdundianzi.Share.LEDDisplay
{
    public class DisplayFactory
    {
        //public static IDisplaycomm CreateDisplay(AssemblyInfoPair info,  DisplayConfig setting)
        //{
        //    return CreateDisplay(info.AssemblyName, info.ClassName, setting);
        //}

        public static IDisplaycomm CreateDisplay(string assName, string displayName, DisplayConfig setting)
        {
            Assembly ass = Assembly.LoadFrom(assName);
            Type t = ass.GetType(displayName);
            IDisplaycomm dis = (IDisplaycomm)Activator.CreateInstance(t, new object[] { setting });
            return dis;
        }
    }
}
