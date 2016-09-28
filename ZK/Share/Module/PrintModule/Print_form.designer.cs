namespace Cn.Youdundianzi.Share.Module.Print
{
    partial class Print_form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.y_zz = new System.Windows.Forms.Label();
            this.x_zz = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.y_zz);
            this.panel1.Controls.Add(this.x_zz);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 506);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Print_form_Paint);
            // 
            // y_zz
            // 
            this.y_zz.AutoSize = true;
            this.y_zz.BackColor = System.Drawing.Color.Transparent;
            this.y_zz.Font = new System.Drawing.Font("SimSun", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.y_zz.ForeColor = System.Drawing.Color.Yellow;
            this.y_zz.Location = new System.Drawing.Point(87, 204);
            this.y_zz.Name = "y_zz";
            this.y_zz.Size = new System.Drawing.Size(14, 9);
            this.y_zz.TabIndex = 4;
            this.y_zz.Text = "◆";
            // 
            // x_zz
            // 
            this.x_zz.AutoSize = true;
            this.x_zz.Font = new System.Drawing.Font("SimSun", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.x_zz.ForeColor = System.Drawing.Color.Yellow;
            this.x_zz.Location = new System.Drawing.Point(251, 80);
            this.x_zz.Name = "x_zz";
            this.x_zz.Size = new System.Drawing.Size(14, 9);
            this.x_zz.TabIndex = 3;
            this.x_zz.Text = "◆";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(107, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(342, 268);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Print_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(596, 506);
            this.Controls.Add(this.panel1);
            this.Name = "Print_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印模板设置";
            this.SizeChanged += new System.EventHandler(this.Print_form_Resize);
            this.Shown += new System.EventHandler(this.Print_form_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label x_zz;
        private System.Windows.Forms.Label y_zz;

    }
}