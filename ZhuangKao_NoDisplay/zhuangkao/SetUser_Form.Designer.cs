namespace zhuangkao
{
    partial class SetUser_Form
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_xm = new System.Windows.Forms.Label();
            this.textBox_nicheng = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.domainUpDown_class = new System.Windows.Forms.DomainUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_rpasswd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_passwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_sfzhm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(193, 437);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 23);
            this.button3.TabIndex = 9;
            this.button3.TabStop = false;
            this.button3.Text = "关闭";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(398, 125);
            this.dataGridView1.TabIndex = 100;
            this.dataGridView1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "添加用户";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_xm);
            this.groupBox1.Controls.Add(this.textBox_nicheng);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.domainUpDown_class);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_rpasswd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_passwd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label_sfzhm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // label_xm
            // 
            this.label_xm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_xm.Location = new System.Drawing.Point(149, 28);
            this.label_xm.Name = "label_xm";
            this.label_xm.Size = new System.Drawing.Size(153, 21);
            this.label_xm.TabIndex = 13;
            // 
            // textBox_nicheng
            // 
            this.textBox_nicheng.Location = new System.Drawing.Point(148, 87);
            this.textBox_nicheng.Name = "textBox_nicheng";
            this.textBox_nicheng.Size = new System.Drawing.Size(100, 21);
            this.textBox_nicheng.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "昵称：";
            // 
            // domainUpDown_class
            // 
            this.domainUpDown_class.Items.Add("1");
            this.domainUpDown_class.Items.Add("2");
            this.domainUpDown_class.Items.Add("3");
            this.domainUpDown_class.Location = new System.Drawing.Point(148, 172);
            this.domainUpDown_class.Name = "domainUpDown_class";
            this.domainUpDown_class.Size = new System.Drawing.Size(53, 21);
            this.domainUpDown_class.TabIndex = 4;
            this.domainUpDown_class.Text = "3";
            this.domainUpDown_class.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDown_class.Wrap = true;
            this.domainUpDown_class.Leave += new System.EventHandler(this.domainUpDown_class_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "权限级别：";
            // 
            // textBox_rpasswd
            // 
            this.textBox_rpasswd.Location = new System.Drawing.Point(148, 141);
            this.textBox_rpasswd.Name = "textBox_rpasswd";
            this.textBox_rpasswd.Size = new System.Drawing.Size(100, 21);
            this.textBox_rpasswd.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "密码确认：";
            // 
            // textBox_passwd
            // 
            this.textBox_passwd.Location = new System.Drawing.Point(148, 114);
            this.textBox_passwd.Name = "textBox_passwd";
            this.textBox_passwd.Size = new System.Drawing.Size(100, 21);
            this.textBox_passwd.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "密码：";
            // 
            // label_sfzhm
            // 
            this.label_sfzhm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_sfzhm.Location = new System.Drawing.Point(149, 58);
            this.label_sfzhm.Name = "label_sfzhm";
            this.label_sfzhm.Size = new System.Drawing.Size(153, 21);
            this.label_sfzhm.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "身份证号码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(328, 391);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 23);
            this.button2.TabIndex = 8;
            this.button2.TabStop = false;
            this.button2.Text = "删除用户";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SetUser_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 477);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Name = "SetUser_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetUser_Form_FormClosed);
            this.Load += new System.EventHandler(this.SetUser_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_sfzhm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_rpasswd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_passwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DomainUpDown domainUpDown_class;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_xm;
        private System.Windows.Forms.TextBox textBox_nicheng;
        private System.Windows.Forms.Label label7;
    }
}