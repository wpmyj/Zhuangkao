namespace Modules.SetupModule
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoType3wheel = new System.Windows.Forms.RadioButton();
            this.rdoType2wheel = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoSignal = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rdoSignalXian = new System.Windows.Forms.RadioButton();
            this.rdoSignalGan = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCar
            // 
            this.labelCar.AutoSize = true;
            this.labelCar.Location = new System.Drawing.Point(16, 12);
            this.labelCar.Name = "labelCar";
            this.labelCar.Size = new System.Drawing.Size(41, 12);
            this.labelCar.TabIndex = 0;
            this.labelCar.Text = "车信号";
            // 
            // labelGan
            // 
            this.labelGan.AutoSize = true;
            this.labelGan.Location = new System.Drawing.Point(16, 53);
            this.labelGan.Name = "labelGan";
            this.labelGan.Size = new System.Drawing.Size(41, 12);
            this.labelGan.TabIndex = 1;
            this.labelGan.Text = "杆信号";
            // 
            // labelXian
            // 
            this.labelXian.AutoSize = true;
            this.labelXian.Location = new System.Drawing.Point(16, 96);
            this.labelXian.Name = "labelXian";
            this.labelXian.Size = new System.Drawing.Size(41, 12);
            this.labelXian.TabIndex = 2;
            this.labelXian.Text = "线信号";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoType3wheel);
            this.groupBox1.Controls.Add(this.rdoType2wheel);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(93, 71);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "车型选择";
            // 
            // rdoType3wheel
            // 
            this.rdoType3wheel.AutoSize = true;
            this.rdoType3wheel.Location = new System.Drawing.Point(6, 44);
            this.rdoType3wheel.Name = "rdoType3wheel";
            this.rdoType3wheel.Size = new System.Drawing.Size(83, 16);
            this.rdoType3wheel.TabIndex = 1;
            this.rdoType3wheel.Text = "三轮摩托车";
            this.rdoType3wheel.UseVisualStyleBackColor = true;
            // 
            // rdoType2wheel
            // 
            this.rdoType2wheel.AutoSize = true;
            this.rdoType2wheel.Checked = true;
            this.rdoType2wheel.Location = new System.Drawing.Point(6, 21);
            this.rdoType2wheel.Name = "rdoType2wheel";
            this.rdoType2wheel.Size = new System.Drawing.Size(83, 16);
            this.rdoType2wheel.TabIndex = 0;
            this.rdoType2wheel.TabStop = true;
            this.rdoType2wheel.Text = "两轮摩托车";
            this.rdoType2wheel.UseVisualStyleBackColor = true;
            this.rdoType2wheel.CheckedChanged += new System.EventHandler(this.rdoType2wheel_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoSignal);
            this.groupBox2.Controls.Add(this.rdoAll);
            this.groupBox2.Location = new System.Drawing.Point(111, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 71);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检测方式";
            // 
            // rdoSignal
            // 
            this.rdoSignal.AutoSize = true;
            this.rdoSignal.Location = new System.Drawing.Point(6, 44);
            this.rdoSignal.Name = "rdoSignal";
            this.rdoSignal.Size = new System.Drawing.Size(89, 16);
            this.rdoSignal.TabIndex = 3;
            this.rdoSignal.Text = "单杆/线检测";
            this.rdoSignal.UseVisualStyleBackColor = true;
            this.rdoSignal.CheckedChanged += new System.EventHandler(this.rdoSignal_CheckedChanged);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Location = new System.Drawing.Point(6, 20);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(71, 16);
            this.rdoAll.TabIndex = 2;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "全部检测";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.rdoSignalXian);
            this.groupBox3.Controls.Add(this.rdoSignalGan);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(221, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(138, 71);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "单杆线检测";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBox1.Location = new System.Drawing.Point(84, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(39, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // rdoSignalXian
            // 
            this.rdoSignalXian.AutoSize = true;
            this.rdoSignalXian.Location = new System.Drawing.Point(6, 45);
            this.rdoSignalXian.Name = "rdoSignalXian";
            this.rdoSignalXian.Size = new System.Drawing.Size(71, 16);
            this.rdoSignalXian.TabIndex = 1;
            this.rdoSignalXian.Text = "单线检测";
            this.rdoSignalXian.UseVisualStyleBackColor = true;
            // 
            // rdoSignalGan
            // 
            this.rdoSignalGan.AutoSize = true;
            this.rdoSignalGan.Checked = true;
            this.rdoSignalGan.Location = new System.Drawing.Point(6, 23);
            this.rdoSignalGan.Name = "rdoSignalGan";
            this.rdoSignalGan.Size = new System.Drawing.Size(71, 16);
            this.rdoSignalGan.TabIndex = 0;
            this.rdoSignalGan.TabStop = true;
            this.rdoSignalGan.Text = "单杆检测";
            this.rdoSignalGan.UseVisualStyleBackColor = true;
            this.rdoSignalGan.CheckedChanged += new System.EventHandler(this.rdoSignalGan_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(365, 167);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(67, 32);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(69, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(216, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(265, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "5";
            // 
            // GXTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 234);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelXian);
            this.Controls.Add(this.labelGan);
            this.Controls.Add(this.labelCar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GXTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信号检测";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GXTest_FormClosed);
            this.Load += new System.EventHandler(this.GXTest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoType3wheel;
        private System.Windows.Forms.RadioButton rdoType2wheel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoSignal;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoSignalXian;
        private System.Windows.Forms.RadioButton rdoSignalGan;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}