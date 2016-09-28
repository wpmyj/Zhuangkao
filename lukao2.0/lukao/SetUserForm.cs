using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lukao
{
    public partial class SetUserForm : Form
    {
        CIDCardInfo idcardinfo;
        private delegate void InvokeDelegate(string xm,string sfzhm);
        InvokeDelegate userinvoke;

        public SetUserForm()
        {
            InitializeComponent();
            label3.Text = string.Empty;
            label4.Text = string.Empty;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            idcardinfo = new CIDCardInfo();
            idcardinfo.InitIDcardDev();
            idcardinfo.Start();
            idcardinfo.OnIDCardReceived +=new CIDCardInfo.IDCardRequest(idcardinfo_OnIDCardReceived);
            userinvoke = new InvokeDelegate(userinvokefun);
      
        }


        private void userinvokefun(string xm, string sfzhm)
        {
            label3.Text = xm;
            label4.Text = sfzhm;
        }

        private void idcardinfo_OnIDCardReceived(string xm, string sfzhm)
        {
            if ((label3.InvokeRequired) || (label4.InvokeRequired))
            {
                label3.Invoke(userinvoke, xm, sfzhm);
            }
            else
            {
                label3.Text = xm;
                label4.Text = sfzhm;
            }
        }

        private void SetUserForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“zhuangkaoDataSet.user”中。您可以根据需要移动或移除它。
            this.userTableAdapter.Fill(this.zhuangkaoDataSet.user);

        }

        private void SetUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            idcardinfo.CloseIDcardDev();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (label3.Text != string.Empty && label4.Text != string.Empty)
            {
                DataRow dr = zhuangkaoDataSet.Tables["user"].NewRow();
                dr[2] = label3.Text;
                dr[1] = MD5.md5(label4.Text+"liuying");
                dr[3] = "123456";
                dr[4] = 1;
                zhuangkaoDataSet.Tables["user"].Rows.Add(dr);
                userTableAdapter.Update(zhuangkaoDataSet);
                label3.Text = string.Empty;
                label4.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if ((int)zhuangkaoDataSet.Tables["user"].Rows[dataGridView1.SelectedRows[0].Index]["class"] > 0)
                {
                    zhuangkaoDataSet.Tables["user"].Rows[dataGridView1.SelectedRows[0].Index].Delete();
                    userTableAdapter.Update(zhuangkaoDataSet);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }






    }
}