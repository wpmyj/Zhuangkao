using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zkdata
{
    public partial class Send_Form : Form
    {
        CSend_Ctrl send_ctrl;
        CSend_Model send_model;

        public Send_Form()
        {
            InitializeComponent();
            cShowLinkState1.init();
            cShowLinkState2.init();
            SetprogressBar_Max(100);
            send_model = new CSend_Model();
            send_ctrl = new CSend_Ctrl(this, send_model);
            Updatetimelabel(send_model.settings.SendDatetime);
           
        }


        #region 进度条控制
        //-----------进度条控制（Head）----------------------------------
        public void SetprogressBar_Show(bool isshow) //是否显示进度条
        {
            progressBar1.Visible = isshow;
            time_label.Visible = !isshow;
        }

        public void SetprogressBar_Max(int maxval) //进度条最大值设置
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maxval;
        }

        public void progressBar_Step() //进度条步进1
        {
            if ((progressBar1.Value + 1) <= progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
        }
        public void progressBar_Reset()
        {
            progressBar1.Value = 0;
        }
        //-----------进度条控制（End）-------------------------------------
        #endregion

        #region 状态灯控制
        //-----------状态灯控制（Head）-----------------------------------
        public void LocallinkState(bool islink)
        {
            cShowLinkState1.LinkState = islink;
        }

        public void RemotelinkState(bool islink)
        {
            cShowLinkState2.LinkState = islink;
        }
        //-----------状态灯控制（End）-------------------------------------
        #endregion

        #region 按钮控制
        //----------控制建立连接按钮是否可以点击（Head）-------------------
        public void locallinkButtonEnable(bool isenable)
        {
            button2.Enabled = isenable;
        }

        public void RemotelinkButtonEnable(bool isenable)
        {
            button3.Enabled = isenable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //progressBar_Step();
            if (button1.Text == "开始发送")
            {
               
                SwButtonState();
  
            }
            else
            {
                SwButtonState();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            send_model.LocalDBlink();
        }


        public void SwButtonState()
        {
            if (button1.Text == "开始发送")
            {
                button1.Text = "停止发送";
            }
            else
            {
                button1.Text = "开始发送";
            }
        }

        //----------控制建立连接按钮是否可以点击（End）-------------------
        #endregion


        #region 更新标签
        //----------更新标签（Head）--------------------------------------
        public void UpdateDfsjnum(int num)
        {
            label1.Text = "待发送数据：" + num + " 条";
        }

        public void Updatefssjnum(int num)
        {
            label5.Text = "发送数据数据：" + num + " 条";
            label5.Refresh();
            Application.DoEvents();
        }


        public void UpdateErrnum(int num)
        {
            label6.Text = "错误数据：" + num + " 条";
            label6.Refresh();
            Application.DoEvents();
        }

        public void Updatetimelabel(string newdate)
        {
            time_label.Text = "最新发送时间：" + newdate;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            send_ctrl.SendData();
        }

        //----------更新标签（End）--------------------------------------
        #endregion

    }
}