namespace Cn.Youdundianzi.Share.Module.Setup
{
    partial class GXTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelCar = new System.Windows.Forms.Label();
            this.labelGan = new System.Windows.Forms.Label();
            this.labelXian = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoSignal = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comBoxIndex = new System.Windows.Forms.ComboBox();
            this.rdoSignalXian = new System.Windows.Forms.RadioButton();
            this.rdoSignalGan = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comBoxType = new System.Windows.Forms.ComboBox();
            this.carPane = new System.Windows.Forms.Panel();
            this.ganPane = new System.Windows.Forms.Panel();
            this.xianPane = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCar
            // 
            this.labelCar.AutoSize = true;
            this.labelCar.Location = new System.Drawing.Point(16, 12);
            this.labelCar.Name = "labelCar";
            this.labelCar.Size = new System.Drawing.Size(43, 13);
            this.labelCar.TabIndex = 0;
            this.labelCar.Text = "车信号";
            // 
            // labelGan
            // 
            this.labelGan.AutoSize = true;
            this.labelGan.Location = new System.Drawing.Point(16, 57);
            this.labelGan.Name = "labelGan";
            this.labelGan.Size = new System.Drawing.Size(43, 13);
            this.labelGan.TabIndex = 1;
            this.labelGan.Text = "杆信号";
            // 
            // labelXian
            // 
            this.labelXian.AutoSize = true;
            this.labelXian.Location = new System.Drawing.Point(16, 104);
            this.labelXian.Name = "labelXian";
            this.labelXian.Size = new System.Drawing.Size(43, 13);
            this.labelXian.TabIndex = 2;
            this.labelXian.Text = "线信号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoSignal);
            this.groupBox2.Controls.Add(this.rdoAll);
            this.groupBox2.Location = new System.Drawing.Point(111, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 77);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检测方式";
            // 
            // rdoSignal
            // 
            this.rdoSignal.AutoSize = true;
            this.rdoSignal.Location = new System.Drawing.Point(6, 48);
            this.rdoSignal.Name = "rdoSignal";
            this.rdoSignal.Size = new System.Drawing.Size(90, 17);
            this.rdoSignal.TabIndex = 3;
            this.rdoSignal.Text = "单杆/线检测";
            this.rdoSignal.UseVisualStyleBackColor = true;
            this.rdoSignal.CheckedChanged += new System.EventHandler(this.rdoSignal_CheckedChanged);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Location = new System.Drawing.Point(6, 22);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(73, 17);
            this.rdoAll.TabIndex = 2;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "全部检测";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comBoxIndex);
            this.groupBox3.Controls.Add(this.rdoSignalXian);
            this.groupBox3.Controls.Add(this.rdoSignalGan);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(221, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(138, 77);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "单杆线检测";
            this.groupBox3.EnabledChanged += new System.EventHandler(this.groupBox3_EnabledChanged);
            // 
            // comBoxIndex
            // 
            this.comBoxIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxIndex.FormattingEnabled = true;
            this.comBoxIndex.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comBoxIndex.Location = new System.Drawing.Point(84, 34);
            this.comBoxIndex.Name = "comBoxIndex";
            this.comBoxIndex.Size = new System.Drawing.Size(39, 21);
            this.comBoxIndex.TabIndex = 2;
            this.comBoxIndex.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // rdoSignalXian
            // 
            this.rdoSignalXian.AutoSize = true;
            this.rdoSignalXian.Location = new System.Drawing.Point(6, 49);
            this.rdoSignalXian.Name = "rdoSignalXian";
            this.rdoSignalXian.Size = new System.Drawing.Size(73, 17);
            this.rdoSignalXian.TabIndex = 1;
            this.rdoSignalXian.Text = "单线检测";
            this.rdoSignalXian.UseVisualStyleBackColor = true;
            // 
            // rdoSignalGan
            // 
            this.rdoSignalGan.AutoSize = true;
            this.rdoSignalGan.Checked = true;
            this.rdoSignalGan.Location = new System.Drawing.Point(6, 25);
            this.rdoSignalGan.Name = "rdoSignalGan";
            this.rdoSignalGan.Size = new System.Drawing.Size(73, 17);
            this.rdoSignalGan.TabIndex = 0;
            this.rdoSignalGan.TabStop = true;
            this.rdoSignalGan.Text = "单杆检测";
            this.rdoSignalGan.UseVisualStyleBackColor = true;
            this.rdoSignalGan.CheckedChanged += new System.EventHandler(this.rdoSignalGan_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(365, 181);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(67, 35);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "开始检测";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comBoxType
            // 
            this.comBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxType.FormattingEnabled = true;
            this.comBoxType.Location = new System.Drawing.Point(12, 172);
            this.comBoxType.Name = "comBoxType";
            this.comBoxType.Size = new System.Drawing.Size(92, 21);
            this.comBoxType.TabIndex = 7;
            this.comBoxType.SelectedIndexChanged += new System.EventHandler(this.comBoxType_SelectedIndexChanged);
            // 
            // carPane
            // 
            this.carPane.Location = new System.Drawing.Point(61, 12);
            this.carPane.Name = "carPane";
            this.carPane.Size = new System.Drawing.Size(370, 27);
            this.carPane.TabIndex = 8;
            // 
            // ganPane
            // 
            this.ganPane.Location = new System.Drawing.Point(61, 57);
            this.ganPane.Name = "ganPane";
            this.ganPane.Size = new System.Drawing.Size(370, 27);
            this.ganPane.TabIndex = 9;
            // 
            // xianPane
            // 
            this.xianPane.Location = new System.Drawing.Point(61, 104);
            this.xianPane.Name = "xianPane";
            this.xianPane.Size = new System.Drawing.Size(370, 27);
            this.xianPane.TabIndex = 10;
            // 
            // GXTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 254);
            this.Controls.Add(this.xianPane);
            this.Controls.Add(this.ganPane);
            this.Controls.Add(this.carPane);
            this.Controls.Add(this.comBoxType);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelXian);
            this.Controls.Add(this.labelGan);
            this.Controls.Add(this.labelCar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GXTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信号检测";
            this.Load += new System.EventHandler(this.GXTest_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GXTest_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCar;
        private System.Windows.Forms.Label labelGan;
        private System.Windows.Forms.Label labelXian;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoSignal;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoSignalXian;
        private System.Windows.Forms.RadioButton rdoSignalGan;
        private System.Windows.Forms.ComboBox comBoxIndex;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comBoxType;
        private System.Windows.Forms.Panel carPane;
        private System.Windows.Forms.Panel ganPane;
        private System.Windows.Forms.Panel xianPane;
    }
}