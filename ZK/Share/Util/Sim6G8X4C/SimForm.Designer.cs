namespace Cn.Youdundianzi.Share.Util.Sim6G8X4C
{
    partial class SimForm
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
            this.labelCar = new System.Windows.Forms.Label();
            this.labelGan = new System.Windows.Forms.Label();
            this.labelXian = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCar
            // 
            this.labelCar.AutoSize = true;
            this.labelCar.Location = new System.Drawing.Point(12, 9);
            this.labelCar.Name = "labelCar";
            this.labelCar.Size = new System.Drawing.Size(23, 13);
            this.labelCar.TabIndex = 0;
            this.labelCar.Text = "Car";
            // 
            // labelGan
            // 
            this.labelGan.AutoSize = true;
            this.labelGan.Location = new System.Drawing.Point(8, 98);
            this.labelGan.Name = "labelGan";
            this.labelGan.Size = new System.Drawing.Size(27, 13);
            this.labelGan.TabIndex = 1;
            this.labelGan.Text = "Gan";
            // 
            // labelXian
            // 
            this.labelXian.AutoSize = true;
            this.labelXian.Location = new System.Drawing.Point(7, 53);
            this.labelXian.Name = "labelXian";
            this.labelXian.Size = new System.Drawing.Size(28, 13);
            this.labelXian.TabIndex = 2;
            this.labelXian.Text = "Xian";
            // 
            // SimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 133);
            this.Controls.Add(this.labelXian);
            this.Controls.Add(this.labelGan);
            this.Controls.Add(this.labelCar);
            this.Name = "SimForm";
            this.Text = "SimForm";
            this.Load += new System.EventHandler(this.SimForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCar;
        private System.Windows.Forms.Label labelGan;
        private System.Windows.Forms.Label labelXian;
    }
}