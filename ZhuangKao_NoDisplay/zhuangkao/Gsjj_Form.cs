using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public partial class Gsjj_Form : Form
    {
        public Gsjj_Form()
        {
            InitializeComponent();
            webBrowser1.Url = new Uri(Application.StartupPath.ToString() + @"\img\gsjj.htm");
        }
    }
}