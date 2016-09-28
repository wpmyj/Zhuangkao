namespace Cn.Youdundianzi.Share.Module.ExamCtrl
{
    partial class ExamStatusDisplayPanel
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
            this.labelXStatus = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelXStatus
            // 
            this.labelXStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelXStatus.Location = new System.Drawing.Point(0, 0);
            this.labelXStatus.Name = "labelXStatus";
            this.labelXStatus.Size = new System.Drawing.Size(150, 30);
            this.labelXStatus.TabIndex = 0;
            // 
            // ExamStatusDisplayPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelXStatus);
            this.Name = "ExamStatusDisplayPanel";
            this.Size = new System.Drawing.Size(150, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelXStatus;
    }
}
