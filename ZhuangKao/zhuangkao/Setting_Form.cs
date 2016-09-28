using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public partial class Setting_Form : Form
    {
        private ModuleSettings settings;
       

        public Setting_Form()
        {
            InitializeComponent();
            settings = new ModuleSettings();
            settings = ModuleConfig.GetSettings();
            
        }

        private void Setting_Form_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = settings;
            //propertyGrid1.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModuleConfig.SaveSettings(settings);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}