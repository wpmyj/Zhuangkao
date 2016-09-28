using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cn.Youdundianzi.App
{
    public partial class IntroFrm : Form
    {
        public IntroFrm()
        {
            InitializeComponent();
        }

        private string _introPath = string.Empty;
        public string IntroFilePath
        {
            set { _introPath = value; }
            get { return _introPath; }
        }

        private void IntroFrm_Load(object sender, EventArgs e)
        {
            try
            {
                this.richTxtBox.LoadFile("Intro.rtf");
            }
            catch (Exception ex)
            {
            }
        }
    }
}