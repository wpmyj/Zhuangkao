namespace zhuangkao
{
    partial class Sound_Test_Form
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
            this.textBoxPreLis = new System.Windows.Forms.TextBox();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.comboBoxVoiceList = new System.Windows.Forms.ComboBox();
            this.labelVoiceList = new System.Windows.Forms.Label();
            this.labelText = new System.Windows.Forms.Label();
            this.buttonYes = new System.Windows.Forms.Button();
            this.groupBoxSndTest = new System.Windows.Forms.GroupBox();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.groupBoxSndTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPreLis
            // 
            this.textBoxPreLis.Location = new System.Drawing.Point(6, 58);
            this.textBoxPreLis.Name = "textBoxPreLis";
            this.textBoxPreLis.Size = new System.Drawing.Size(270, 21);
            this.textBoxPreLis.TabIndex = 0;
            // 
            // buttonPreview
            // 
            this.buttonPreview.Location = new System.Drawing.Point(187, 85);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(75, 21);
            this.buttonPreview.TabIndex = 1;
            this.buttonPreview.Text = "‘ƒ°°∂¡";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // comboBoxVoiceList
            // 
            this.comboBoxVoiceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVoiceList.FormattingEnabled = true;
            this.comboBoxVoiceList.Location = new System.Drawing.Point(6, 32);
            this.comboBoxVoiceList.Name = "comboBoxVoiceList";
            this.comboBoxVoiceList.Size = new System.Drawing.Size(270, 20);
            this.comboBoxVoiceList.TabIndex = 2;
            this.comboBoxVoiceList.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoiceList_SelectedIndexChanged);
            // 
            // labelVoiceList
            // 
            this.labelVoiceList.AutoSize = true;
            this.labelVoiceList.Location = new System.Drawing.Point(-81, 5);
            this.labelVoiceList.Name = "labelVoiceList";
            this.labelVoiceList.Size = new System.Drawing.Size(77, 12);
            this.labelVoiceList.TabIndex = 3;
            this.labelVoiceList.Text = "«Î—°‘Ò…˘“Ù£∫";
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(6, 17);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(89, 12);
            this.labelText.TabIndex = 4;
            this.labelText.Text = "«Î ‰»Î≤‚ ‘Œƒ±æ";
            // 
            // buttonYes
            // 
            this.buttonYes.Location = new System.Drawing.Point(118, 134);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(75, 23);
            this.buttonYes.TabIndex = 5;
            this.buttonYes.Text = "»∑°°∂®";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // groupBoxSndTest
            // 
            this.groupBoxSndTest.Controls.Add(this.textBoxPreLis);
            this.groupBoxSndTest.Controls.Add(this.buttonPreview);
            this.groupBoxSndTest.Controls.Add(this.labelText);
            this.groupBoxSndTest.Controls.Add(this.comboBoxVoiceList);
            this.groupBoxSndTest.Controls.Add(this.labelVoiceList);
            this.groupBoxSndTest.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSndTest.Name = "groupBoxSndTest";
            this.groupBoxSndTest.Size = new System.Drawing.Size(282, 116);
            this.groupBoxSndTest.TabIndex = 6;
            this.groupBoxSndTest.TabStop = false;
            this.groupBoxSndTest.Text = "…˘“Ù≤‚ ‘";
            // 
            // buttonCancle
            // 
            this.buttonCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancle.Location = new System.Drawing.Point(199, 134);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 7;
            this.buttonCancle.Text = "»°  œ˚";
            this.buttonCancle.UseVisualStyleBackColor = true;
            // 
            // Sound_Test_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancle;
            this.ClientSize = new System.Drawing.Size(306, 164);
            this.Controls.Add(this.buttonCancle);
            this.Controls.Add(this.groupBoxSndTest);
            this.Controls.Add(this.buttonYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Sound_Test_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "…˘“Ù≤‚ ‘";
            this.Load += new System.EventHandler(this.Sound_Test_Form_Load);
            this.groupBoxSndTest.ResumeLayout(false);
            this.groupBoxSndTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPreLis;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.ComboBox comboBoxVoiceList;
        private System.Windows.Forms.Label labelVoiceList;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.GroupBox groupBoxSndTest;
        private System.Windows.Forms.Button buttonCancle;
    }
}