using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Cn.Youdundianzi.Core.Util
{
    #region  配置的操作类ModuleConfig

    public class ModuleConfig
    {
        public static ISettings GetSettings(Type type, string fileName)
        {
            ISettings settings;
            XmlSerializer serializer = new XmlSerializer(type);
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                TextReader reader = new StreamReader(fs, Encoding.Unicode);
                settings = (ISettings)serializer.Deserialize(reader);
                fs.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(fileName + "无法打开，新建新配置文件。\n\n" + e.Message);
                settings = (ISettings)type.GetConstructor(new Type[] { }).Invoke(new object[] { });
            }
            return settings;
        }


        public static void SaveSettings(ISettings settings, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(settings.GetType());

            // serialize the object
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                TextWriter writer = new StreamWriter(fs, Encoding.Unicode);
                serializer.Serialize(writer, settings);
                fs.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }

    #endregion
}
