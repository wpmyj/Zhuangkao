namespace Cn.Youdundianzi.Share.Module.Setup
{
    partial class ExamSetup
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabCtrl = new DevComponents.DotNetBar.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(298, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(217, 473);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "应用";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabCtrl
            // 
            this.tabCtrl.CanReorderTabs = true;
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabCtrl.SelectedTabIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(409, 430);
            this.tabCtrl.TabIndex = 13;
            this.tabCtrl.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabCtrl.Text = "参数设置";
            // 
            // ExamSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 518);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExamSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.ExamSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private DevComponents.DotNetBar.TabControl tabCtrl;



    }
}