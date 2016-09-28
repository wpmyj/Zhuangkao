namespace Cn.Youdundianzi.Share.Module.ExamCtrl
{
    partial class ExamCtrlPanel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnXStart = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btnXStart
            // 
            this.btnXStart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXStart.BackColor = System.Drawing.Color.CadetBlue;
            this.btnXStart.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXStart.Location = new System.Drawing.Point(3, 3);
            this.btnXStart.Name = "btnXStart";
            this.btnXStart.Size = new System.Drawing.Size(70, 30);
            this.btnXStart.TabIndex = 255;
            this.btnXStart.Text = "¿ªÊ¼¿¼ÊÔ";
            this.btnXStart.Click += new System.EventHandler(this.btnXStart_Click);
            // 
            // ExamCtrlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnXStart);
            this.Name = "ExamCtrlPanel";
            this.Size = new System.Drawing.Size(77, 37);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnXStart;
    }
}
