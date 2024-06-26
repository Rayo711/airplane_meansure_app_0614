
namespace WindowsFormsApp2
{
    partial class UserControlTest1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.测试窗口1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 测试窗口1
            // 
            this.测试窗口1.Location = new System.Drawing.Point(11, 33);
            this.测试窗口1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.测试窗口1.Name = "测试窗口1";
            this.测试窗口1.Size = new System.Drawing.Size(90, 28);
            this.测试窗口1.TabIndex = 0;
            this.测试窗口1.Text = "测试窗口1";
            this.测试窗口1.UseVisualStyleBackColor = true;
            // 
            // UserControlTest1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.测试窗口1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserControlTest1";
            this.Size = new System.Drawing.Size(112, 120);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button 测试窗口1;
    }
}
