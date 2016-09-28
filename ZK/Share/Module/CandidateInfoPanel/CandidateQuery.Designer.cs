namespace Cn.Youdundianzi.Share.Module.CandidateInfo
{
    partial class CandidateQuery
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
            this.expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.StudentlistView = new System.Windows.Forms.ListView();
            this.label_sum = new System.Windows.Forms.Label();
            this.label_nopass = new System.Windows.Forms.Label();
            this.label_pass = new System.Windows.Forms.Label();
            this.expandablePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // expandablePanel2
            // 
            this.expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel2.Controls.Add(this.buttonX3);
            this.expandablePanel2.Controls.Add(this.StudentlistView);
            this.expandablePanel2.Controls.Add(this.label_sum);
            this.expandablePanel2.Controls.Add(this.label_nopass);
            this.expandablePanel2.Controls.Add(this.label_pass);
            this.expandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandablePanel2.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel2.Name = "expandablePanel2";
            this.expandablePanel2.Size = new System.Drawing.Size(222, 264);
            this.expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel2.Style.GradientAngle = 90;
            this.expandablePanel2.TabIndex = 39;
            this.expandablePanel2.TitleHeight = 28;
            this.expandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel2.TitleStyle.GradientAngle = 90;
            this.expandablePanel2.TitleText = "排队考生信息";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(142, 207);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(69, 25);
            this.buttonX3.TabIndex = 14;
            this.buttonX3.Text = "同步列表";
            // 
            // StudentlistView
            // 
            this.StudentlistView.Location = new System.Drawing.Point(0, 28);
            this.StudentlistView.Name = "StudentlistView";
            this.StudentlistView.Size = new System.Drawing.Size(222, 173);
            this.StudentlistView.TabIndex = 6;
            this.StudentlistView.UseCompatibleStateImageBehavior = false;
            // 
            // label_sum
            // 
            this.label_sum.AutoSize = true;
            this.label_sum.Location = new System.Drawing.Point(103, 244);
            this.label_sum.Name = "label_sum";
            this.label_sum.Size = new System.Drawing.Size(43, 13);
            this.label_sum.TabIndex = 5;
            this.label_sum.Text = "共计：";
            // 
            // label_nopass
            // 
            this.label_nopass.AutoSize = true;
            this.label_nopass.Location = new System.Drawing.Point(13, 244);
            this.label_nopass.Name = "label_nopass";
            this.label_nopass.Size = new System.Drawing.Size(55, 13);
            this.label_nopass.TabIndex = 4;
            this.label_nopass.Text = "不合格：";
            // 
            // label_pass
            // 
            this.label_pass.AutoSize = true;
            this.label_pass.Location = new System.Drawing.Point(13, 219);
            this.label_pass.Name = "label_pass";
            this.label_pass.Size = new System.Drawing.Size(43, 13);
            this.label_pass.TabIndex = 3;
            this.label_pass.Text = "合格：";
            // 
            // CandidateQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.expandablePanel2);
            this.Name = "CandidateQuery";
            this.Size = new System.Drawing.Size(222, 264);
            this.expandablePanel2.ResumeLayout(false);
            this.expandablePanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel expandablePanel2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private System.Windows.Forms.ListView StudentlistView;
        private System.Windows.Forms.Label label_sum;
        private System.Windows.Forms.Label label_nopass;
        private System.Windows.Forms.Label label_pass;
    }
}
