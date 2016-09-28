using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cn.Youdundianzi.Share.Module.CandidateInfo
{
   
    //信阳考试结束时，用于取消本次成绩存盘的打印的消息框
    //按确定打印，按Ctrl+L快捷键表示取消本次打印
    public partial class XYfrmMessage : Form
    {
        public XYfrmMessage(string sm)
        {
            InitializeComponent();
            this.label1.Text = sm + ",考试结束！";
        }
      
        
        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control) && (e.KeyCode == System.Windows.Forms.Keys.L))
            {
                this.KeyPreview = true;
                this.DialogResult = DialogResult.Cancel;
            }   
        }
    }
}