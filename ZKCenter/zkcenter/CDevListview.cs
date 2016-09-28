using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using System.Drawing;

namespace zkcenter
{
    public class CDevListview
    {
        private System.Windows.Forms.ContextMenuStrip MyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_clear;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_del;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_showstu;    


        public delegate void groupPanelinvoke(string txt);
        private void UpdateconStatus(string txt)
        {
            groupPanel.Text = txt;
        }

        GroupPanel groupPanel;
        ListViewEx devlistViewEx;
        Label label_devnum;
         

        public delegate void MenuEventHandler(int devnum,string zkzhm);
        public event MenuEventHandler Menu_clear;
        public event MenuEventHandler Menu_del;
        public event MenuEventHandler Menu_showstu;




        int _intdevnum;//设备编号
        public int IntDevnum
        {
            get { return _intdevnum; }
        }

        private DevStatus _status;
        public DevStatus Status
        {
            get { return _status; }
            set 
            {
                _status = value;
                if (groupPanel.InvokeRequired)
                {
                    groupPanel.BeginInvoke(new groupPanelinvoke(UpdateconStatus), _status.ToString());
                }
                else
                {
                    groupPanel.Text = _status.ToString();
                }
            }
        }



        public int Width
        {
            get
            {
                return groupPanel.Width;
            }
        }

        public int Height
        {
            get
            {
                return groupPanel.Height;
            }
        }


        public int Left
        {
            get
            {
                return groupPanel.Left;
            }
            set
            {
                groupPanel.Left = value;
                label_devnum.Left = groupPanel.Left + 6;
            }
        }

        public int Top
        {
            get
            {
                return groupPanel.Top;
            }
            set
            {
                groupPanel.Top = value;
                label_devnum.Top = groupPanel.Top - 8;
            }
        }
       

        public void SetLocation(int x, int y)
        {
            groupPanel.Left = x;
            groupPanel.Top = y;
            label_devnum.Left = groupPanel.Left + 6;
            label_devnum.Top=groupPanel.Top - 8;
        }

        public delegate void ViewUpdatelinvoke(CStuDevlist student);
        public void UpdateStudent(CStuDevlist student)
        {
            if (devlistViewEx.InvokeRequired)
            {
                devlistViewEx.BeginInvoke(new ViewUpdatelinvoke(UpdateStudent), student);
            }
            else
            {
                devlistViewEx.Items.Clear();
                if (student.StudentList.Count > 0)
                {
                    ListViewItem Item0 = new ListViewItem();
                    Item0.SubItems.Clear();
                    Item0.SubItems[0].Text = "0";
                    Item0.SubItems.Add(((CStudent)student.StudentList[0]).xm);
                    Item0.SubItems.Add(((CStudent)student.StudentList[0]).zkzmbh);
                    if (Status == DevStatus.身份验证 || Status == DevStatus.正在考试)
                    {
                        Item0.ForeColor = Color.SeaShell;
                        Item0.SubItems[1].ForeColor = Color.SeaShell;
                        Item0.SubItems[2].ForeColor = Color.SeaShell;

                        Item0.BackColor = Color.Tan;
                        Item0.SubItems[1].BackColor = Color.Tan;
                        Item0.SubItems[2].BackColor = Color.Tan;
                    }
                    else
                    {
                        Item0.BackColor = Color.White;
                    }
                    Item0.ForeColor = Color.FromArgb(255, 69, 98, 135);
                    Item0.SubItems[1].ForeColor = Color.FromArgb(255, 69, 98, 135);
                    Item0.SubItems[2].ForeColor = Color.FromArgb(255, 69, 98, 135);
                    devlistViewEx.Items.Add(Item0);

                    for (int i = 1; i < student.StudentList.Count; i++)
                    {
                        ListViewItem Item = new ListViewItem();
                        Item.SubItems.Clear();
                        Item.SubItems[0].Text = i.ToString();
                        Item.SubItems.Add(((CStudent)student.StudentList[i]).xm);
                        Item.SubItems.Add(((CStudent)student.StudentList[i]).zkzmbh);
                        if ((i % 2) == 0)
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
                        devlistViewEx.Items.Add(Item);
                    }
                }
            }
        }

        //当开始考试时将列表中第一位考生颜色置为红色
        public delegate void Viewcolorlinvoke();
        public void UpdateStuColor()
        {
            if (devlistViewEx.InvokeRequired)
            {
                devlistViewEx.BeginInvoke(new Viewcolorlinvoke(UpdateStuColor));
            }
            else
            {
                try
                {
                    devlistViewEx.Items[0].ForeColor = Color.SeaShell;
                    devlistViewEx.Items[0].SubItems[1].ForeColor = Color.SeaShell;
                    devlistViewEx.Items[0].SubItems[2].ForeColor = Color.SeaShell;

                    devlistViewEx.Items[0].BackColor = Color.Tan;
                    devlistViewEx.Items[0].SubItems[1].BackColor = Color.Tan;
                    devlistViewEx.Items[0].SubItems[2].BackColor = Color.Tan;
                }
                catch
                { 
                }

            }
        }

        //恢复列表中第一位考生的颜色
        public void ReUpdateStuColor()
        {
            if (devlistViewEx.InvokeRequired)
            {
                devlistViewEx.BeginInvoke(new Viewcolorlinvoke(ReUpdateStuColor));
            }
            else
            {
                try
                {
                    devlistViewEx.Items[0].ForeColor = Color.FromArgb(255, 69, 98, 135);
                    devlistViewEx.Items[0].SubItems[1].ForeColor = Color.FromArgb(255, 69, 98, 135);
                    devlistViewEx.Items[0].SubItems[2].ForeColor = Color.FromArgb(255, 69, 98, 135);

                    devlistViewEx.Items[0].BackColor = Color.White;
                    devlistViewEx.Items[0].SubItems[1].BackColor = Color.White;
                    devlistViewEx.Items[0].SubItems[2].BackColor = Color.White;
                }
                catch
                { 
                }
            }
        }

        public CDevListview(PanelDockContainer panelDockContainer1,int devnum)
        {
            this._intdevnum = devnum;
            groupPanel = new GroupPanel();
            devlistViewEx = new ListViewEx();
            label_devnum = new Label();
            panelDockContainer1.Controls.Add(label_devnum);
            panelDockContainer1.Controls.Add(groupPanel);

        
            devlistViewEx.Border.Class = "ListViewBorder";
            devlistViewEx.Dock = System.Windows.Forms.DockStyle.Fill;
            devlistViewEx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            devlistViewEx.Location = new System.Drawing.Point(0, 0);
            devlistViewEx.Name = "devlistViewEx";
            devlistViewEx.Size = new System.Drawing.Size(196, 171);
            devlistViewEx.TabIndex = 0;
            devlistViewEx.UseCompatibleStateImageBehavior = false;
            devlistViewEx.GridLines = true;
            devlistViewEx.FullRowSelect = true;//要选择就是一行 
            devlistViewEx.View = View.Details;//定义列表显示的方式 
            devlistViewEx.Scrollable = true;//需要时候显示滚动条 
            devlistViewEx.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            devlistViewEx.Columns.Add("序号", devlistViewEx.Width * 1 / 6 + 7, HorizontalAlignment.Left);
            devlistViewEx.Columns.Add("姓名", devlistViewEx.Width * 2 / 6 - 4, HorizontalAlignment.Left);
            devlistViewEx.Columns.Add("证号", devlistViewEx.Width * 3 / 6 - 3, HorizontalAlignment.Left);

            groupPanel.BackColor = System.Drawing.Color.Transparent;
            groupPanel.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel.Controls.Add(this.devlistViewEx);
            groupPanel.Location = new System.Drawing.Point(5, 12);
            groupPanel.Name = "groupPanel3";
            groupPanel.Size = new System.Drawing.Size(202, 210);
            groupPanel.Visible = true;
            groupPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            groupPanel.Style.BackColorGradientAngle = 90;
            groupPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel.Style.BorderBottomWidth = 1;
            groupPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel.Style.BorderLeftWidth = 1;
            groupPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel.Style.BorderRightWidth = 1;
            groupPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel.Style.BorderTopWidth = 1;
            groupPanel.Style.CornerDiameter = 4;
            groupPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel.TabIndex = 4;
            groupPanel.Text = "未连接";

            label_devnum.AutoSize = true;
            label_devnum.BackColor = System.Drawing.Color.Transparent;
            label_devnum.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_devnum.ForeColor = System.Drawing.Color.Red;
            label_devnum.Location = new System.Drawing.Point(groupPanel.Left+6, groupPanel.Top-8);
            label_devnum.Name = "label1";
            label_devnum.Size = new System.Drawing.Size(23, 24);
            label_devnum.Text = _intdevnum.ToString();
            Status = DevStatus.未连接;
          //  this.devlistViewEx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.devlistViewEx_MouseDown);

            //初始化菜单
            this.MyMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.MenuItem_clear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_del = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_showstu = new System.Windows.Forms.ToolStripMenuItem();
            // MyMenuStrip
            // 
            this.MyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_clear,
            this.MenuItem_del,
            this.toolStripMenuItem1,
            this.MenuItem_showstu});
            this.MyMenuStrip.Name = "MyMenuStrip";
            this.MyMenuStrip.Size = new System.Drawing.Size(167, 76);
            // 
            // 清除所以考生MenuItem_clear
            // 
            this.MenuItem_clear.Name = "MenuItem_clear";
            this.MenuItem_clear.Size = new System.Drawing.Size(166, 22);
            this.MenuItem_clear.Text = "清除所有考生";
            this.MenuItem_clear.Click += new System.EventHandler(this.MenuItem_clear_Click);
            // 
            // 删除对应考试MenuItem_del
            // 
            this.MenuItem_del.Name = "MenuItem_del";
            this.MenuItem_del.Size = new System.Drawing.Size(166, 22);
            this.MenuItem_del.Text = "删除对应考生";
            this.MenuItem_del.Click += new System.EventHandler(this.MenuItem_del_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // 显示考生详细信息MenuItem_showstu
            // 
            this.MenuItem_showstu.Name = "MenuItem_showstu";
            this.MenuItem_showstu.Size = new System.Drawing.Size(166, 22);
            this.MenuItem_showstu.Text = "显示考生详细信息";
            this.MenuItem_showstu.Click += new System.EventHandler(this.MenuItem_showstu_Click);

            devlistViewEx.ContextMenuStrip = MyMenuStrip;
           
        }

        private void MenuItem_clear_Click(object sender, EventArgs e)
        {
            if (_status == DevStatus.正在考试 || _status == DevStatus.身份验证)
            {
                MessageBox.Show("考生已进入考试流程，不能清空列表！");
                return;
            }

            if (devlistViewEx.Items.Count > 0)
            {
                if(Menu_clear!=null)
                Menu_clear(IntDevnum, string.Empty);
            }
        }

        private void MenuItem_del_Click(object sender, EventArgs e)
        {
            if (devlistViewEx.SelectedItems.Count > 0)
            {
                if (_status == DevStatus.正在考试 || _status == DevStatus.身份验证)
                {
                    MessageBox.Show("考生已进入考试流程，不能清空列表！");
                    return;
                }

                if(Menu_del!=null)
                Menu_del(IntDevnum, devlistViewEx.SelectedItems[0].SubItems[2].Text);
            }
        }

        private void MenuItem_showstu_Click(object sender, EventArgs e)
        {
            if (devlistViewEx.SelectedItems.Count > 0)
            {
                if(Menu_showstu!=null)
                Menu_showstu(IntDevnum, devlistViewEx.SelectedItems[0].SubItems[2].Text);
            }
        }






    }
}
