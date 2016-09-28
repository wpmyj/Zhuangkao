using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zkdata
{
    public partial class Incept_Form : Form
    {
        CIncept_Model inceptmodel;
        CIncept_Ctrl inceptctrl;

        public Incept_Form(CIncept_Model inceptmodel)
        {
            InitializeComponent();
            cShowLinkState1.init();
            cShowLinkState2.init();
            SetprogressBar_Max(100);
            //SetprogressBar_Show(true);
            this.inceptmodel = inceptmodel;
            inceptctrl = new CIncept_Ctrl(this, inceptmodel);
            Updatetimelabel(inceptmodel.settings.Downloaddate);
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
            if ((progressBar1.Value + 1) <=progressBar1.Maximum)
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
                DialogResult res = MessageBox.Show("���½���������Ҫ��յ�ǰ���ݱ�", "ȷ��", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (inceptctrl.ClearLocalData() != -1)
                    {
                        SwButtonState();
                        inceptctrl.DownloadData();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                SwButtonState();
                inceptctrl.StopDownloadData();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            inceptctrl.LocalDBlink();
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
        public void UpdateLocalnum(int num)
        {
            label2.Text = "�������ݿ⣺" + num + " ��";
        }

        public void UpdateRemotenum(int num)
        {
            label1.Text = "���������ݣ�"+ num +" ��";
        }


        public void UpdateDownloadnum(int num)
        {
            label5.Text = "�������ݣ�" + num + " ��";
            label5.Refresh();
            Application.DoEvents();
        }

        public void UpdateErrDownloadnum(int num)
        {
            label6.Text = "�������ݣ�" + num + " ��";
            label6.Refresh();
            Application.DoEvents();
        }

        public void Updatetimelabel(string newdate)
        {
            time_label.Text = "���½���ʱ�䣺" + newdate;
        }

        //----------���±�ǩ��End��--------------------------------------
        #endregion

    }

 
}