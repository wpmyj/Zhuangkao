using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Cn.Youdundianzi.App
{
    public partial class AppConfigFrm : Form
    {
        public AppConfigFrm()
        {
            InitializeComponent();
        }

        private void AppConfigFrm_Load(object sender, EventArgs e)
        {
            AppConfig appConf;

            XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
            try
            {
                FileStream fs = new FileStream(AppConfig.APPCONF_FILE_NAME, FileMode.Open);
                TextReader reader = new StreamReader(fs, Encoding.Unicode);
                appConf = (AppConfig)serializer.Deserialize(reader);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法找到" + AppConfig.APPCONF_FILE_NAME + "，生成新配置文件。");
                appConf = new AppConfig();
            }

            this.propertyGridAppConfig.SelectedObject = appConf;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));

            // serialize the object
            try
            {
                FileStream fs = new FileStream(AppConfig.APPCONF_FILE_NAME, FileMode.Create);
                TextWriter writer = new StreamWriter(fs, Encoding.Unicode);
                serializer.Serialize(writer, propertyGridAppConfig.SelectedObject);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}