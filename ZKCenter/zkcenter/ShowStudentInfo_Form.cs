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
            label_xm.Text = "������" + student.xm;
            label_lsh.Text = "��ˮ�ţ�" + student.lsh;
            label_zkzhm.Text = "׼��֤��" + student.zkzmbh;
            label_sfzhm.Text = "���֤��" + student.sfzmhm;
            label_kscx.Text = "���Գ��ͣ�" + student.kscx;
            label_kscs.Text = "���Դ�����" + student.kscs.ToString();
        }

    }
}