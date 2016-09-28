namespace App
{
    partial class FormExam
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
            this.motorModelDisplayPanel = new Modules.ExamDisplayModelPanel.Motor.XAMotorModelDisplayPanel();
            this.examCtrlPanel = new Modules.ExamCtrlPanelModule.ExamCtrlPanel();
            this.examStatusDisplayPanel = new Modules.ExamCtrlPanelModule.ExamStatusDisplayPanel();
            this.localInputPanel = new Modules.CandidateInfoPanel.LocalInputPanel();
            this.SuspendLayout();
            // 
            // motorModelDisplayPanel
            // 
            this.motorModelDisplayPanel.Location = new System.Drawing.Point(231, 11);
            this.motorModelDisplayPanel.Name = "motorModelDisplayPanel";
            this.motorModelDisplayPanel.Size = new System.Drawing.Size(500, 369);
            this.motorModelDisplayPanel.TabIndex = 2;
            // 
            // examCtrlPanel
            // 
            this.examCtrlPanel.BackColor = System.Drawing.Color.Transparent;
            this.examCtrlPanel.Location = new System.Drawing.Point(150, 253);
            this.examCtrlPanel.Name = "examCtrlPanel";
            this.examCtrlPanel.Size = new System.Drawing.Size(75, 33);
            this.examCtrlPanel.TabIndex = 1;
            // 
            // examStatusDisplayPanel
            // 
            this.examStatusDisplayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.examStatusDisplayPanel.Location = new System.Drawing.Point(12, 353);
            this.examStatusDisplayPanel.Name = "examStatusDisplayPanel";
            this.examStatusDisplayPanel.Size = new System.Drawing.Size(213, 28);
            this.examStatusDisplayPanel.TabIndex = 0;
            // 
            // localInputPanel
            // 
            this.localInputPanel.Location = new System.Drawing.Point(11, 11);
            this.localInputPanel.Name = "localInputPanel";
            this.localInputPanel.Size = new System.Drawing.Size(214, 275);
            this.localInputPanel.TabIndex = 3;
            // 
            // FormExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 390);
            this.Controls.Add(this.motorModelDisplayPanel);
            this.Controls.Add(this.examCtrlPanel);
            this.Controls.Add(this.examStatusDisplayPanel);
            this.Controls.Add(this.localInputPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "øº ‘";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExam_FormClosing);
            this.Load += new System.EventHandler(this.ExamForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Modules.ExamCtrlPanelModule.ExamStatusDisplayPanel examStatusDisplayPanel;
        private Modules.ExamCtrlPanelModule.ExamCtrlPanel examCtrlPanel;
        private Modules.ExamDisplayModelPanel.Motor.XAMotorModelDisplayPanel motorModelDisplayPanel;
        private Modules.CandidateInfoPanel.LocalInputPanel localInputPanel;
    }
}

