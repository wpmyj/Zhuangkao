namespace Cn.Youdundianzi.App
{
    partial class AppConfigFrm
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
            this.propertyGridAppConfig = new System.Windows.Forms.PropertyGrid();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGridAppConfig
            // 
            this.propertyGridAppConfig.AllowDrop = true;
            this.propertyGridAppConfig.Location = new System.Drawing.Point(12, 12);
            this.propertyGridAppConfig.Name = "propertyGridAppConfig";
            this.propertyGridAppConfig.Size = new System.Drawing.Size(570, 420);
            this.propertyGridAppConfig.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(324, 438);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保    存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(405, 438);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 2;
            this.btnCancle.Text = "取    消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // AppConfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 475);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.propertyGridAppConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AppConfigFrm";
            this.Text = "应用设置";
            this.Load += new System.EventHandler(this.AppConfigFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGridAppConfig;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancle;





    }
}