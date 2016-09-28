using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Exam;
using System.Reflection;

namespace Cn.Youdundianzi.Core.Util
{
    public struct AssemblyInfoPair
    {
        public string AssemblyName;
        public string ClassName;
    }

    public class AssemblyInfoFactory
    {
        public static AssemblyInfoPair GetAssemblyInfo(object mon)
        {
            AssemblyInfoPair monpair = new AssemblyInfoPair();
            monpair.AssemblyName = mon.GetType().Assembly.Location;
            monpair.ClassName = mon.GetType().FullName;
            return monpair;
        }

        public static AssemblyInfoPair GetAssemblyInfo(Type type)
        {
            AssemblyInfoPair monpair = new AssemblyInfoPair();
            monpair.AssemblyName = type.Assembly.Location;
            monpair.ClassName = type.FullName;
            return monpair;
        }

        public static AssemblyInfoPair GetAssemblyInfo(string AssemblyName, string ClassName)
        {

            AssemblyInfoPair monpair = new AssemblyInfoPair();
            monpair.AssemblyName = AssemblyName;
            monpair.ClassName = ClassName;
            return monpair;
        }

        public static Type GetType(string AssemblyName, string ClassName)
        {
            Assembly ass = Assembly.LoadFrom(AssemblyName);
            Type type = ass.GetType(ClassName);
            return type;
        }
    }
}
