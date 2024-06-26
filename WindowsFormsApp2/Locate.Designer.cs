namespace WindowsFormsApp2
{
    partial class Locate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label52 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_loc_dev_select = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_loc_means = new System.Windows.Forms.Button();
            this.dataGridView_loc = new System.Windows.Forms.DataGridView();
            this.text_theo = new System.Windows.Forms.TextBox();
            this.text_mean = new System.Windows.Forms.TextBox();
            this.btn_selectTheo = new System.Windows.Forms.Button();
            this.btn_convert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_loc)).BeginInit();
            this.SuspendLayout();
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label52.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label52.Location = new System.Drawing.Point(34, 19);
            this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(71, 16);
            this.label52.TabIndex = 42;
            this.label52.Text = "设备选择";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(269, 55);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 16);
            this.label13.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Location = new System.Drawing.Point(269, 87);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 16);
            this.label12.TabIndex = 38;
            // 
            // comboBox_loc_dev_select
            // 
            this.comboBox_loc_dev_select.FormattingEnabled = true;
            this.comboBox_loc_dev_select.Items.AddRange(new object[] {
            ""});
            this.comboBox_loc_dev_select.Location = new System.Drawing.Point(118, 19);
            this.comboBox_loc_dev_select.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_loc_dev_select.Name = "comboBox_loc_dev_select";
            this.comboBox_loc_dev_select.Size = new System.Drawing.Size(155, 20);
            this.comboBox_loc_dev_select.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(25, 19);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 16);
            this.label11.TabIndex = 36;
            // 
            // btn_loc_means
            // 
            this.btn_loc_means.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_loc_means.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_loc_means.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_loc_means.Location = new System.Drawing.Point(272, 99);
            this.btn_loc_means.Margin = new System.Windows.Forms.Padding(2);
            this.btn_loc_means.Name = "btn_loc_means";
            this.btn_loc_means.Size = new System.Drawing.Size(129, 31);
            this.btn_loc_means.TabIndex = 47;
            this.btn_loc_means.Text = "靶球测量";
            this.btn_loc_means.UseVisualStyleBackColor = false;
            this.btn_loc_means.Click += new System.EventHandler(this.btn_loc_means_Click);
            // 
            // dataGridView_loc
            // 
            this.dataGridView_loc.AllowUserToAddRows = false;
            this.dataGridView_loc.AllowUserToDeleteRows = false;
            this.dataGridView_loc.AllowUserToResizeColumns = false;
            this.dataGridView_loc.AllowUserToResizeRows = false;
            this.dataGridView_loc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_loc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.dataGridView_loc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_loc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_loc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_loc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_loc.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_loc.EnableHeadersVisualStyles = false;
            this.dataGridView_loc.Location = new System.Drawing.Point(37, 163);
            this.dataGridView_loc.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_loc.Name = "dataGridView_loc";
            this.dataGridView_loc.ReadOnly = true;
            this.dataGridView_loc.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_loc.RowHeadersVisible = false;
            this.dataGridView_loc.RowHeadersWidth = 62;
            this.dataGridView_loc.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_loc.RowTemplate.Height = 30;
            this.dataGridView_loc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_loc.Size = new System.Drawing.Size(542, 241);
            this.dataGridView_loc.TabIndex = 48;
            // 
            // text_theo
            // 
            this.text_theo.Location = new System.Drawing.Point(131, 56);
            this.text_theo.Name = "text_theo";
            this.text_theo.Size = new System.Drawing.Size(100, 21);
            this.text_theo.TabIndex = 50;
            // 
            // text_mean
            // 
            this.text_mean.Location = new System.Drawing.Point(131, 99);
            this.text_mean.Name = "text_mean";
            this.text_mean.Size = new System.Drawing.Size(100, 21);
            this.text_mean.TabIndex = 51;
            // 
            // btn_selectTheo
            // 
            this.btn_selectTheo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_selectTheo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectTheo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_selectTheo.Location = new System.Drawing.Point(273, 50);
            this.btn_selectTheo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_selectTheo.Name = "btn_selectTheo";
            this.btn_selectTheo.Size = new System.Drawing.Size(128, 34);
            this.btn_selectTheo.TabIndex = 52;
            this.btn_selectTheo.Text = "选择理论点组";
            this.btn_selectTheo.UseVisualStyleBackColor = false;
            this.btn_selectTheo.Click += new System.EventHandler(this.btn_selectTheo_Click);
            // 
            // btn_convert
            // 
            this.btn_convert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.btn_convert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_convert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.btn_convert.Location = new System.Drawing.Point(441, 50);
            this.btn_convert.Margin = new System.Windows.Forms.Padding(2);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(117, 80);
            this.btn_convert.TabIndex = 54;
            this.btn_convert.Text = "转站计算";
            this.btn_convert.UseVisualStyleBackColor = false;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(34, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 57;
            this.label1.Text = "理论点组";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(34, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 58;
            this.label2.Text = "测量点组";
            // 
            // Locate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(630, 460);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_convert);
            this.Controls.Add(this.btn_selectTheo);
            this.Controls.Add(this.text_mean);
            this.Controls.Add(this.text_theo);
            this.Controls.Add(this.dataGridView_loc);
            this.Controls.Add(this.btn_loc_means);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox_loc_dev_select);
            this.Controls.Add(this.label11);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Locate";
            this.Text = "仪器定位";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_loc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_loc_dev_select;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_loc_means;
        private System.Windows.Forms.DataGridView dataGridView_loc;
        private System.Windows.Forms.TextBox text_theo;
        private System.Windows.Forms.TextBox text_mean;
        private System.Windows.Forms.Button btn_selectTheo;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}