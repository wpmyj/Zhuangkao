using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zkcenter
{
    public partial class ShowStudentInfo_Form : Form
    {
        CStudent student;
        public ShowStudentInfo_Form(CStudent student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void ShowStudentInfo_Form_Load(object sender, EventArgs e)
        {
            label_xm.Text = "姓名：" + student.xm;
            label_lsh.Text = "流水号：" + student.lsh;
            label_zkzhm.Text = "准考证：" + student.zkzmbh;
            label_sfzhm.Text = "身份证：" + student.sfzmhm;
            label_kscx.Text = "考试车型：" + student.kscx;
            label_kscs.Text = "考试次数：" + student.kscs.ToString();
        }

    }
}