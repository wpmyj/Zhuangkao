using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ksdevice
{
    public partial class Ksdevice : UserControl
    {

        public delegate void ListUpdate(object sender, int itemsindex, int subitemsindex, string value, Color mycolor);
        public event ListUpdate myinvoke;

        public delegate void TextUpdate(string text);
        public event TextUpdate textinvoke;

        public delegate void QueueADDInvoke(string name, string zkzhm);
        public event QueueADDInvoke queueaddinvoke1;

        public delegate void ClearInvoke();
        public event ClearInvoke clearInvoke1;

        private void textinvokefun(string text)
        {
            QueuelistView.Items.Clear();
        }

        private void myinvokefun(object sender, int itemsindex, int subitemsindex, string value, Color mycolor)
        {
            DeviceItemListView.Items[itemsindex].SubItems[subitemsindex].Text = value;
            DeviceItemListView.Items[itemsindex].ForeColor = mycolor;
        }

        private void queueaddinvoke1fun(string name, string zkzhm)
        {
            QueuelistView.Items.Add((_queuecount + 1).ToString());
            QueuelistView.Items[_queuecount].SubItems.Add(name);
            QueuelistView.Items[_queuecount].SubItems.Add(zkzhm);
            _queuecount++;
            groupBox1.Text = "�Ŷ�������" + _queuecount;
        }

        public Ksdevice()
        {
            InitializeComponent();
            this.Width = 198;
            this.Height = 275;
            _queuecount = 0;
            ViewInit();
            this.AllowDrop = true;
            myinvoke = new ListUpdate(myinvokefun);
            textinvoke = new TextUpdate(textinvokefun);
            queueaddinvoke1 = new QueueADDInvoke(queueaddinvoke1fun);
            clearInvoke1 = new ClearInvoke(clearInvokefun);
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            
            return base.PreProcessMessage(ref msg);
        }

        private void ViewInit()
        {
            DeviceItemListView.GridLines = true;//��ʾ������¼�ķָ��� 
            DeviceItemListView.FullRowSelect = true;//Ҫѡ�����һ�� 
            DeviceItemListView.View = View.Details;//�����б���ʾ�ķ�ʽ 
            DeviceItemListView.Scrollable = false;//��Ҫʱ����ʾ������ 
            DeviceItemListView.MultiSelect = false; // �����Զ���ѡ�� 
            DeviceItemListView.HeaderStyle = ColumnHeaderStyle.None;
            DeviceItemListView.Columns.Add(" ", DeviceItemListView.Width * 2 / 6 , HorizontalAlignment.Center);
            DeviceItemListView.Columns.Add(" ", DeviceItemListView.Width * 4 / 6 , HorizontalAlignment.Left );
            DeviceItemListView.Visible = true;
            DeviceItemListView.Items.Add(" �豸״̬��");
            DeviceItemListView.Items[0].BackColor = Color.Gainsboro;
            DeviceItemListView.Items[0].SubItems.Add("δ֪");
            DeviceItemListView.Items.Add(" ����������");
            DeviceItemListView.Items[1].SubItems.Add("");
            DeviceItemListView.Items.Add(" ׼��֤�ţ�");
            DeviceItemListView.Items[2].SubItems.Add("");
            DeviceItemListView.Items[2].BackColor = Color.Gainsboro;
            DeviceItemListView.Items.Add(" ���֤�ţ�");
            DeviceItemListView.Items[3].SubItems.Add("");
          //  DeviceItemListView.StateImageList = imageList1;
         //   DeviceItemListView.Items[0].ImageIndex = 0;

            QueuelistView.GridLines = true;
            QueuelistView.FullRowSelect = true;
            QueuelistView.View = View.Details;
            QueuelistView.Scrollable =true;
            QueuelistView.MultiSelect = true;
            QueuelistView.HeaderStyle = ColumnHeaderStyle.None;
            QueuelistView.Columns.Add("", DeviceItemListView.Width * 1 /11, HorizontalAlignment.Center);
            QueuelistView.Columns.Add("", DeviceItemListView.Width * 3 / 11, HorizontalAlignment.Left);
            QueuelistView.Columns.Add("", DeviceItemListView.Width * 6 / 11-16, HorizontalAlignment.Left);
            QueuelistView.AllowDrop = true;

        }

        private int _queuecount;
        public int Queuecount
        {
            get { return _queuecount; }
        }


        private string _title;
        public string Title
        {
            get { return _title; }
            set 
            {
                TitleLable.Text = "    "+ value;
                _title = value; 
            }
        }

        //private bool _devicestat;
        //public bool Devicestat
        //{
        //    get { return _devicestat; }
        //    set
        //    {
        //        if (value)
        //        {
        //            DeviceItemListView.Items[0].SubItems[1].Text = "������";
        //        }
        //        else
        //        {
        //            DeviceItemListView.Items[0].SubItems[1].Text = "����";
        //        }
        //        _devicestat = value; 
        //    }
        //}

        private string  _devicestat;
        public string  Devicestat
        {
            get { return _devicestat; }
            set
            {
                
                _devicestat = value;
                if (DeviceItemListView.InvokeRequired)
                {
                    //myinvokefun(object sender, int itemsindex, int subitemsindex, string value, Color mycolor)
                    DeviceItemListView.Invoke(myinvoke, this, 0, 1, _devicestat, Color.Black);
                }
                else
                {
                   DeviceItemListView.Items[0].SubItems[1].Text = _devicestat;
                }
                
            }
        }


        private string _studentname;
        public string Studentname
        {
            get { return _studentname; }
            set 
            {
                _studentname = value;
                if (DeviceItemListView.InvokeRequired)
                {
                    DeviceItemListView.Invoke(myinvoke, this, 1, 1, _studentname, Color.Black);
                }
                else
                {
                    DeviceItemListView.Items[1].SubItems[1].Text = value;
                }
            }
        }


        private string _zkzhm;
        public string Zkzhm
        {
            get { return _zkzhm; }
            set 
            {
                _zkzhm = value;
                if (DeviceItemListView.InvokeRequired)
                {
                    DeviceItemListView.Invoke(myinvoke, this, 2, 1, _zkzhm, Color.Black);
                }
                else
                {
                    DeviceItemListView.Items[2].SubItems[1].Text = value;
                }
            }
        }

        private string _sfzhm;
        public string Sfzhm
        {
            get { return _sfzhm; }
            set 
            {
                _sfzhm = value;
                if (DeviceItemListView.InvokeRequired)
                {
                    DeviceItemListView.Invoke(myinvoke, this, 3, 1, _sfzhm, Color.Black);
                }
                else
                {
                    DeviceItemListView.Items[3].SubItems[1].Text = value;
                }
            }
        }


        public void clearInvokefun()
        {
            // DeviceItemListView.Items[0].SubItems[1].Text = "δ֪";
            DeviceItemListView.Items[1].SubItems[1].Text = "";
            DeviceItemListView.Items[2].SubItems[1].Text = "";
            DeviceItemListView.Items[3].SubItems[1].Text = "";
            groupBox1.Text = "�Ŷ�������0"; //+_queuecount;
        }
        public void KsdeviceClear()
        {
            if (QueuelistView.InvokeRequired || groupBox1.InvokeRequired)
            {
                QueuelistView.Invoke(clearInvoke1);
            }
            else
            {
                // DeviceItemListView.Items[0].SubItems[1].Text = "δ֪";
                DeviceItemListView.Items[1].SubItems[1].Text = "";
                DeviceItemListView.Items[2].SubItems[1].Text = "";
                DeviceItemListView.Items[3].SubItems[1].Text = "";
                groupBox1.Text = "�Ŷ�������0"; //+_queuecount;
            }
        }

        public void QueueAdd(string name, string zkzhm)
        {
            if (QueuelistView.InvokeRequired || groupBox1.InvokeRequired)
            {
                QueuelistView.Invoke(queueaddinvoke1, name, zkzhm);
            }
            else
            {
                QueuelistView.Items.Add((_queuecount + 1).ToString());
                QueuelistView.Items[_queuecount].SubItems.Add(name);
                QueuelistView.Items[_queuecount].SubItems.Add(zkzhm);
                _queuecount++;
                groupBox1.Text = "�Ŷ�������" + _queuecount;
            }
        }

        public void QueueDelete(int myindex)
        {
            if ((_queuecount > 0) && (myindex < _queuecount))
            {
                QueuelistView.Items.RemoveAt(myindex);
                _queuecount--;
                groupBox1.Text = "�Ŷ�������" + _queuecount;
                for (int i = _queuecount; i > 0; i--)
                {
                    QueuelistView.Items[i - 1].SubItems[0].Text = i.ToString();
                }
            }
        }

        public void QueueDeleteSelect()
        {

            int nMaxSelect = QueuelistView.SelectedItems.Count;
            _queuecount = _queuecount - nMaxSelect;
            for (int i = 0; i < nMaxSelect; nMaxSelect--)
            {
                QueuelistView.Items.RemoveAt(QueuelistView.SelectedItems[0].Index);
            }

        }

     

        public void QueueClear()
        {
            _queuecount = 0;
            if (groupBox1.InvokeRequired || QueuelistView.InvokeRequired)
            {
                groupBox1.Invoke(textinvoke, _queuecount.ToString());
            }
            else
            {
                groupBox1.Text = "�Ŷ�������" + _queuecount.ToString();
                QueuelistView.Items.Clear();
            }
        }

        public delegate void UserRequest(object sender, EventArgs e);
        public event UserRequest OnMyevent;

        private void DeviceItemListView_DoubleClick(object sender, EventArgs e)
        {
            if (OnMyevent != null)
            {
                OnMyevent(sender, e);
            }
            else
            {
                groupBox1.Text = "���Լ�ʵ����Ӧ";
            }
            //Message msg = new Message();
            //msg.Msg = ev ;
            //PreProcessMessage(ref msg);

        }

       

       
       


    }
}