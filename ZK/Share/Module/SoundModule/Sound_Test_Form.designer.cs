namespace Cn.Youdundianzi.Share.Module.Sound
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
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.tabCtrl = new DevComponents.DotNetBar.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonYes
            // 
            this.buttonYes.Location = new System.Drawing.Point(118, 185);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(75, 25);
            this.buttonYes.TabIndex = 5;
            this.buttonYes.Text = "确　定";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // buttonCancle
            // 
            this.buttonCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancle.Location = new System.Drawing.Point(199, 185);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 25);
            this.buttonCancle.TabIndex = 7;
            this.buttonCancle.Text = "取  消";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // tabCtrl
            // 
            this.tabCtrl.CanReorderTabs = true;
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedTabFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.tabCtrl.SelectedTabIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(306, 179);
            this.tabCtrl.TabIndex = 8;
            this.tabCtrl.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabCtrl.Text = "tabCtrl";
            this.tabCtrl.Click += new System.EventHandler(this.tabCtrl_Click);
            // 
            // Sound_Test_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancle;
            this.ClientSize = new System.Drawing.Size(306, 222);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.buttonCancle);
            this.Controls.Add(this.buttonYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Sound_Test_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "声音测试";
            this.Load += new System.EventHandler(this.Sound_Test_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonCancle;
        private DevComponents.DotNetBar.TabControl tabCtrl;
    }
}