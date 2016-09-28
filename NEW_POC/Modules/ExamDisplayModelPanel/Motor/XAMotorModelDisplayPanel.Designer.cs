namespace Modules.ExamDisplayModelPanel.Motor
{
    partial class XAMotorModelDisplayPanel
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
            this.picBoxModelBackGround = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxModelBackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxModelBackGround
            // 
            this.picBoxModelBackGround.BackColor = System.Drawing.Color.Green;
            this.picBoxModelBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxModelBackGround.Location = new System.Drawing.Point(0, 0);
            this.picBoxModelBackGround.Name = "picBoxModelBackGround";
            this.picBoxModelBackGround.Size = new System.Drawing.Size(520, 400);
            this.picBoxModelBackGround.TabIndex = 0;
            this.picBoxModelBackGround.TabStop = false;
            this.picBoxModelBackGround.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoxModelBackGround_Paint);
            // 
            // MotorModelDisplayPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picBoxModelBackGround);
            this.Name = "MotorModelDisplayPanel";
            this.Size = new System.Drawing.Size(520, 400);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxModelBackGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxModelBackGround;
    }
}
