using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cn.Youdundianzi.Share.Module.CandidateInfo
{
    //考生排队列表控件
    public partial class CandidateQuery : UserControl
    {
        public CandidateQuery()
        {
            InitializeComponent();
            init();

        }


        private delegate void AddItemDelegate( string zjbm, string xm);
        private delegate void DeleteItemDelegate(string zkzbm);
        private delegate void ClearItemDelegate();
      
        
        //添加考生
        public void AddCandidate(string zjbm, string xm)
        {
            if (StudentlistView.InvokeRequired)
            {
                StudentlistView.Invoke(new AddItemDelegate(AddCandidate), zjbm, xm);
            }
            else
            {
                ListViewItem Item = new ListViewItem();
                Item.SubItems[0].Text = StudentlistView.Items.Count.ToString();
                Item.SubItems.Add(xm);
                Item.SubItems.Add(zjbm);
                if ((StudentlistView.Items.Count % 2) == 0)
                {
                    Item.BackColor = Color.White;
                }
                else
                {
                    Item.BackColor = Color.FromArgb(255, 214, 224, 236);
                    Item.SubItems[1].BackColor = Color.FromArgb(255, 214, 224, 236);
                    Item.SubItems[2].BackColor = Color.FromArgb(255, 214, 224, 236);

                }
                Item.ForeColor = Color.FromArgb(255, 69, 98, 135);
                Item.SubItems[1].ForeColor = Color.FromArgb(255, 69, 98, 135);
                Item.SubItems[2].ForeColor = Color.FromArgb(255, 69, 98, 135);
                StudentlistView.Items.Add(Item);
            }
        }
        //删除考生
        public void DeleteCandidate(string zkzbm)
        {
            if (StudentlistView.InvokeRequired)
            {
                StudentlistView.Invoke(new DeleteItemDelegate(DeleteCandidate), zkzbm);
            }
            else
            {
                List<int> delitem = new List<int>();
                for (int i = 0; i < StudentlistView.Items.Count; i++)
                {
                    if (StudentlistView.Items[i].SubItems[2].Text.Trim() == zkzbm)
                    {
                        delitem.Add(i);
                    }
                }
                for (int i = 0; i < delitem.Count; i++)
                {
                    StudentlistView.Items[delitem[i]].Remove();
                }
            }
        }
        //清空考生
        public void ClearCandidate()
        {
            if (StudentlistView.InvokeRequired)
            {
                StudentlistView.Invoke(new ClearItemDelegate(ClearCandidate));
            }
            else
            {
                StudentlistView.Items.Clear();
            }
        }

        //初始化
        private void init()
        {
            StudentlistView.Size = new Size(220, 160);
            StudentlistView.GridLines = true;
            StudentlistView.FullRowSelect = true;//要选择就是一行 
            StudentlistView.View = View.Details;//定义列表显示的方式 
            StudentlistView.Scrollable = true;//需要时候显示滚动条 
            StudentlistView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            StudentlistView.Columns.Add("序号", StudentlistView.Width * 1 / 6 + 2, HorizontalAlignment.Left);
            StudentlistView.Columns.Add("姓名", StudentlistView.Width * 2 / 6 - 4, HorizontalAlignment.Left);
            StudentlistView.Columns.Add("证号", StudentlistView.Width * 3 / 6 - 3, HorizontalAlignment.Left);

        }
       
      
       
    }
}
