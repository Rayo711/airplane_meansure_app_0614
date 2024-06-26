namespace WindowsFormsApp2
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.btn_save_doc = new System.Windows.Forms.Button();
            this.btn_open_doc = new System.Windows.Forms.Button();
            this.btn_return = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.head_box = new System.Windows.Forms.PictureBox();
            this.rpt_name = new System.Windows.Forms.Button();
            this.plane_num = new System.Windows.Forms.Button();
            this.opr_num = new System.Windows.Forms.Button();
            this.end_time = new System.Windows.Forms.Button();
            this.start_time = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.head_box)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save_doc
            // 
            this.btn_save_doc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save_doc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_save_doc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save_doc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save_doc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_save_doc.Location = new System.Drawing.Point(631, 591);
            this.btn_save_doc.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save_doc.Name = "btn_save_doc";
            this.btn_save_doc.Size = new System.Drawing.Size(131, 55);
            this.btn_save_doc.TabIndex = 5;
            this.btn_save_doc.Text = "保存报告";
            this.btn_save_doc.UseVisualStyleBackColor = false;
            this.btn_save_doc.Click += new System.EventHandler(this.btn_save_doc_Click);
            // 
            // btn_open_doc
            // 
            this.btn_open_doc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_open_doc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_open_doc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_open_doc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_open_doc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_open_doc.Location = new System.Drawing.Point(477, 591);
            this.btn_open_doc.Margin = new System.Windows.Forms.Padding(2);
            this.btn_open_doc.Name = "btn_open_doc";
            this.btn_open_doc.Size = new System.Drawing.Size(131, 55);
            this.btn_open_doc.TabIndex = 2;
            this.btn_open_doc.Text = "打开报告";
            this.btn_open_doc.UseVisualStyleBackColor = false;
            this.btn_open_doc.Click += new System.EventHandler(this.button22_Click);
            // 
            // btn_return
            // 
            this.btn_return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_return.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_return.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_return.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_return.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_return.Location = new System.Drawing.Point(785, 591);
            this.btn_return.Margin = new System.Windows.Forms.Padding(2);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(131, 55);
            this.btn_return.TabIndex = 4;
            this.btn_return.Text = "返回";
            this.btn_return.UseVisualStyleBackColor = false;
            this.btn_return.Click += new System.EventHandler(this.button23_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.richTextBox1.Location = new System.Drawing.Point(53, 185);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(876, 393);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(215)))), ((int)(((byte)(245)))));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 27);
            this.label1.TabIndex = 28;
            this.label1.Text = "激光雷达全机水平测量及校靶系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.label2.Location = new System.Drawing.Point(50, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "测量报告";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.label3.Location = new System.Drawing.Point(50, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "飞机编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.label4.Location = new System.Drawing.Point(483, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "测 量 时 间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.label5.Location = new System.Drawing.Point(483, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "操作人员工号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Image = global::WindowsFormsApp2.Properties.Resources.最小化1;
            this.label6.Location = new System.Drawing.Point(754, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "  ";
            // 
            // head_box
            // 
            this.head_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.head_box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.head_box.Image = ((System.Drawing.Image)(resources.GetObject("head_box.Image")));
            this.head_box.Location = new System.Drawing.Point(1, 8);
            this.head_box.Margin = new System.Windows.Forms.Padding(2);
            this.head_box.Name = "head_box";
            this.head_box.Size = new System.Drawing.Size(869, 44);
            this.head_box.TabIndex = 27;
            this.head_box.TabStop = false;
            // 
            // rpt_name
            // 
            this.rpt_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.rpt_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rpt_name.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rpt_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.rpt_name.Location = new System.Drawing.Point(133, 85);
            this.rpt_name.Margin = new System.Windows.Forms.Padding(2);
            this.rpt_name.Name = "rpt_name";
            this.rpt_name.Size = new System.Drawing.Size(323, 31);
            this.rpt_name.TabIndex = 38;
            this.rpt_name.UseVisualStyleBackColor = false;
            // 
            // plane_num
            // 
            this.plane_num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.plane_num.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plane_num.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plane_num.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.plane_num.Location = new System.Drawing.Point(133, 131);
            this.plane_num.Margin = new System.Windows.Forms.Padding(2);
            this.plane_num.Name = "plane_num";
            this.plane_num.Size = new System.Drawing.Size(323, 31);
            this.plane_num.TabIndex = 39;
            this.plane_num.UseVisualStyleBackColor = false;
            // 
            // opr_num
            // 
            this.opr_num.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.opr_num.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opr_num.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.opr_num.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.opr_num.Location = new System.Drawing.Point(605, 131);
            this.opr_num.Margin = new System.Windows.Forms.Padding(2);
            this.opr_num.Name = "opr_num";
            this.opr_num.Size = new System.Drawing.Size(323, 31);
            this.opr_num.TabIndex = 40;
            this.opr_num.UseVisualStyleBackColor = false;
            // 
            // end_time
            // 
            this.end_time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.end_time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.end_time.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.end_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.end_time.Location = new System.Drawing.Point(777, 85);
            this.end_time.Margin = new System.Windows.Forms.Padding(2);
            this.end_time.Name = "end_time";
            this.end_time.Size = new System.Drawing.Size(151, 31);
            this.end_time.TabIndex = 41;
            this.end_time.UseVisualStyleBackColor = false;
            // 
            // start_time
            // 
            this.start_time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.start_time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_time.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.start_time.Location = new System.Drawing.Point(605, 85);
            this.start_time.Margin = new System.Windows.Forms.Padding(2);
            this.start_time.Name = "start_time";
            this.start_time.Size = new System.Drawing.Size(147, 31);
            this.start_time.TabIndex = 42;
            this.start_time.UseVisualStyleBackColor = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(976, 680);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.btn_save_doc);
            this.Controls.Add(this.start_time);
            this.Controls.Add(this.btn_open_doc);
            this.Controls.Add(this.end_time);
            this.Controls.Add(this.opr_num);
            this.Controls.Add(this.plane_num);
            this.Controls.Add(this.rpt_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.head_box);
            this.Controls.Add(this.richTextBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "History";
            ((System.ComponentModel.ISupportInitialize)(this.head_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_save_doc;
        private System.Windows.Forms.Button btn_open_doc;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox head_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button rpt_name;
        private System.Windows.Forms.Button plane_num;
        private System.Windows.Forms.Button opr_num;
        private System.Windows.Forms.Button end_time;
        private System.Windows.Forms.Button start_time;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}