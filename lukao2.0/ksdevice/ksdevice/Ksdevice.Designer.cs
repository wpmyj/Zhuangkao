namespace ksdevice
{
    partial class Ksdevice
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.TitleLable = new System.Windows.Forms.Label();
            this.DeviceItemListView = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QueuelistView = new System.Windows.Forms.ListView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.splitter1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            this.splitContainer1.Panel1.Controls.Add(this.DeviceItemListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(271, 337);
            this.splitContainer1.SplitterDistance = 147;
            this.splitContainer1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ksdevice.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.White;
            this.splitter1.Controls.Add(this.TitleLable);
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(271, 30);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // TitleLable
            // 
            this.TitleLable.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.TitleLable.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLable.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLable.ForeColor = System.Drawing.Color.FloralWhite;
            this.TitleLable.Location = new System.Drawing.Point(0, 0);
            this.TitleLable.Name = "TitleLable";
            this.TitleLable.Size = new System.Drawing.Size(271, 21);
            this.TitleLable.TabIndex = 8;
            this.TitleLable.Text = "侧方停车";
            this.TitleLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeviceItemListView
            // 
            this.DeviceItemListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeviceItemListView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeviceItemListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DeviceItemListView.FullRowSelect = true;
            this.DeviceItemListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.DeviceItemListView.HideSelection = false;
            this.DeviceItemListView.Location = new System.Drawing.Point(-5, 32);
            this.DeviceItemListView.Name = "DeviceItemListView";
            this.DeviceItemListView.Size = new System.Drawing.Size(229, 91);
            this.DeviceItemListView.SmallImageList = this.imageList1;
            this.DeviceItemListView.TabIndex = 4;
            this.DeviceItemListView.UseCompatibleStateImageBehavior = false;
            this.DeviceItemListView.View = System.Windows.Forms.View.List;
            this.DeviceItemListView.DoubleClick += new System.EventHandler(this.DeviceItemListView_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(1, 20);
            this.imageList1.TransparentColor = System.Drawing.Color.Gainsboro;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.QueuelistView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "排队人数：0";
            // 
            // QueuelistView
            // 
            this.QueuelistView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QueuelistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueuelistView.ForeColor = System.Drawing.Color.Sienna;
            this.QueuelistView.Location = new System.Drawing.Point(3, 17);
            this.QueuelistView.Margin = new System.Windows.Forms.Padding(3, 3, 30, 30);
            this.QueuelistView.Name = "QueuelistView";
            this.QueuelistView.Size = new System.Drawing.Size(265, 166);
            this.QueuelistView.TabIndex = 0;
            this.QueuelistView.UseCompatibleStateImageBehavior = false;
            // 
            // Ksdevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Ksdevice";
            this.Size = new System.Drawing.Size(271, 337);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitter1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView DeviceItemListView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label TitleLable;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView QueuelistView;
    }
}
