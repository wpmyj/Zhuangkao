namespace Cn.Youdundianzi.Share.Module.CandidateInfo
{
    partial class ExamResultPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label_ks1 = new System.Windows.Forms.Label();
            this.label_ks2 = new System.Windows.Forms.Label();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label_ks1);
            this.groupPanel1.Controls.Add(this.label_ks2);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(209, 100);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 57;
            this.groupPanel1.Text = "考试结果";
            // 
            // label_ks1
            // 
            this.label_ks1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ks1.AutoEllipsis = true;
            this.label_ks1.AutoSize = true;
            this.label_ks1.BackColor = System.Drawing.Color.Transparent;
            this.label_ks1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_ks1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.label_ks1.Location = new System.Drawing.Point(10, 20);
            this.label_ks1.Name = "label_ks1";
            this.label_ks1.Size = new System.Drawing.Size(89, 12);
            this.label_ks1.TabIndex = 52;
            this.label_ks1.Text = "第一回合考试：";
            this.label_ks1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ks2
            // 
            this.label_ks2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ks2.AutoEllipsis = true;
            this.label_ks2.AutoSize = true;
            this.label_ks2.BackColor = System.Drawing.Color.Transparent;
            this.label_ks2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_ks2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.label_ks2.Location = new System.Drawing.Point(10, 40);
            this.label_ks2.Name = "label_ks2";
            this.label_ks2.Size = new System.Drawing.Size(89, 12);
            this.label_ks2.TabIndex = 53;
            this.label_ks2.Text = "第二回合考试：";
            this.label_ks2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExamResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel1);
            this.Name = "ExamResultPanel";
            this.Size = new System.Drawing.Size(209, 100);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label_ks1;
        private System.Windows.Forms.Label label_ks2;
    }
}
