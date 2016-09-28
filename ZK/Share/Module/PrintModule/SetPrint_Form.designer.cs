namespace Cn.Youdundianzi.Share.Module.Print
{
    partial class SetPrint_Form
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
            this.btnOpenPrintFrm = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.tabCtrl = new DevComponents.DotNetBar.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenPrintFrm
            // 
            this.btnOpenPrintFrm.Location = new System.Drawing.Point(225, 485);
            this.btnOpenPrintFrm.Name = "btnOpenPrintFrm";
            this.btnOpenPrintFrm.Size = new System.Drawing.Size(75, 25);
            this.btnOpenPrintFrm.TabIndex = 0;
            this.btnOpenPrintFrm.Text = "打开定位窗体";
            this.btnOpenPrintFrm.UseVisualStyleBackColor = true;
            this.btnOpenPrintFrm.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(323, 485);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(55, 25);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(399, 485);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(55, 25);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabCtrl
            // 
            this.tabCtrl.CanReorderTabs = true;
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedTabFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.tabCtrl.SelectedTabIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(480, 466);
            this.tabCtrl.TabIndex = 14;
            this.tabCtrl.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabCtrl.Text = "参数设置";
            // 
            // SetPrint_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 522);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnOpenPrintFrm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetPrint_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打印设置";
            this.Load += new System.EventHandler(this.SetPrint_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenPrintFrm;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnQuit;
        private DevComponents.DotNetBar.TabControl tabCtrl;
    }
}