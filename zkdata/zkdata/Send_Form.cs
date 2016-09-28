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


        #region ����������
        //-----------���������ƣ�Head��----------------------------------
        public void SetprogressBar_Show(bool isshow) //�Ƿ���ʾ������
        {
            progressBar1.Visible = isshow;
            time_label.Visible = !isshow;
        }

        public void SetprogressBar_Max(int maxval) //���������ֵ����
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maxval;
        }

        public void progressBar_Step() //����������1
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
        //-----------���������ƣ�End��-------------------------------------
        #endregion

        #region ״̬�ƿ���
        //-----------״̬�ƿ��ƣ�Head��-----------------------------------
        public void LocallinkState(bool islink)
        {
            cShowLinkState1.LinkState = islink;
        }

        public void RemotelinkState(bool islink)
        {
            cShowLinkState2.LinkState = islink;
        }
        //-----------״̬�ƿ��ƣ�End��-------------------------------------
        #endregion

        #region ��ť����
        //----------���ƽ������Ӱ�ť�Ƿ���Ե����Head��-------------------
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
            if (button1.Text == "��ʼ����")
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
            if (button1.Text == "��ʼ����")
            {
                button1.Text = "ֹͣ����";
            }
            else
            {
                button1.Text = "��ʼ����";
            }
        }

        //----------���ƽ������Ӱ�ť�Ƿ���Ե����End��-------------------
        #endregion


        #region ���±�ǩ
        //----------���±�ǩ��Head��--------------------------------------
        public void UpdateDfsjnum(int num)
        {
            label1.Text = "���������ݣ�" + num + " ��";
        }

        public void Updatefssjnum(int num)
        {
            label5.Text = "�����������ݣ�" + num + " ��";
            label5.Refresh();
            Application.DoEvents();
        }


        public void UpdateErrnum(int num)
        {
            label6.Text = "�������ݣ�" + num + " ��";
            label6.Refresh();
            Application.DoEvents();
        }

        public void Updatetimelabel(string newdate)
        {
            time_label.Text = "���·���ʱ�䣺" + newdate;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            send_ctrl.SendData();
        }

        //----------���±�ǩ��End��--------------------------------------
        #endregion

    }
}