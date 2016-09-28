using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Reflection;

namespace Util
{
    #region  ÅäÖÃµÄ²Ù×÷ÀàModuleConfig

    public class ModuleConfig
    {
        public static CSettings GetSettings(Type type, string fileName)
        {
            CSettings settings;
            XmlSerializer serializer = new XmlSerializer(type);
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                TextReader reader = new StreamReader(fs, Encoding.Unicode);
                settings = (CSettings)serializer.Deserialize(reader);
                fs.Close();
            }
            catch(Exception e)
            {
                settings = (CSettings)type.GetConstructor(new Type[] { }).Invoke(new object[] { });
            }
            return settings;
        }


        public static void SaveSettings(CSettings settings, string fileName)
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
