using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp2
{
    public partial class info : Form
    {
        public static string doc_path;
        public static string doc_name;
        public static string doc_text;
        public static int info_flag = 0;
        public static string start_time;
        public static string plane_num;
        public static string save_path;
        public info()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Maximized;
            opr_num.Text = login.opr_num;

            Type dgvType = this.dataGridView1.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridView1, true, null);
       }

        private void button1_Click(object sender, EventArgs e)
        {
            if(eqp_num.Text =="")
            {
                MessageBox.Show("请输入飞机编号");
            }
            else
            {
                List<string> means_pro = new List<string>();
                doc_text = "飞机编号：  ";
                doc_text += eqp_num.Text + "\n";
                plane_num = eqp_num.Text;
                doc_text += "操作人员工号：  ";
                doc_text += opr_num.Text + "\n";
                doc_text += "测量内容：";
                if (checkBox1.Checked) { doc_text += checkBox1.Text + "\n"; means_pro.Add("全机水平测量"); }
                if (checkBox2.Checked) { doc_text += checkBox2.Text + "\n"; means_pro.Add("飞控系统"); }
                if (checkBox3.Checked) { doc_text += checkBox3.Text + "\n"; means_pro.Add("座舱显示与控制系统"); }
                if (checkBox4.Checked) { doc_text += checkBox4.Text + "\n"; means_pro.Add("电子战系统"); }
                if (checkBox5.Checked) { doc_text += checkBox5.Text + "\n"; means_pro.Add("CNI子系统"); }
                if (checkBox6.Checked) { doc_text += checkBox6.Text + "\n"; means_pro.Add("惯性参考系统"); }
                if (checkBox7.Checked) { doc_text += checkBox7.Text + "\n"; means_pro.Add("光电分布式孔径雷达"); }
                if (checkBox8.Checked) { doc_text += checkBox8.Text + "\n"; means_pro.Add("雷达系统"); }
                start_time = System.DateTime.Now.ToString("yyyy_MM_dd_HH：mm：ss");
                string newDirectoryName = plane_num + "_" + start_time;
                //string path = "E:/C#_proj/airplane_meansure_app_0416/WindowsFormsApp2/history/";
                string path = Environment.CurrentDirectory.Replace("\\bin\\Debug","") + "/history/";

                save_path = path + newDirectoryName;
                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }
                
                means_pro.Add("其他");
                foreach (string name in means_pro)
                {
                    if (!Directory.Exists(save_path + "/" + name))
                    {
                        Directory.CreateDirectory(save_path + "/" + name);
                    }
                }

                Main form4 = new Main();
                this.Hide();
                form4.ShowDialog();
                this.Dispose();
                
           
            }
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string scanDirectoryPath = this.textBox_selected_scan_path.Text;
            if (String.IsNullOrEmpty(scanDirectoryPath))
            {
                MessageBox.Show("扫描文件路径不能为空");
            }
            else
            {
                //指定的文件夹目录
                DirectoryInfo dir = new DirectoryInfo(scanDirectoryPath);
                if (dir.Exists == false)
                {
                    MessageBox.Show("路径不存在！请重新输入");
                }
                else
                {
                    this.dataGridView1.Rows.Clear();
                    //检索表示当前目录的文件和子目录
                    FileSystemInfo[] fsinfos = dir.GetFiles();
                    //遍历检索的文件和子目录
                    foreach (FileSystemInfo fsinfo in fsinfos)
                    {
                        int index = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[index].Cells[0].Value = index + 1;
                        this.dataGridView1.Rows[index].Cells[1].Value = fsinfo.Name;
                        this.dataGridView1.Rows[index].Cells[2].Value = "打开";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.textBox_selected_scan_path.Text = path.SelectedPath;
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引

            if (index < this.dataGridView1.Rows.Count - 1 && this.dataGridView1.CurrentCell.Value.ToString() == "打开")
            {
                doc_path = string.Join("/",this.textBox_selected_scan_path.Text, this.dataGridView1.Rows[index].Cells[1].Value);
                doc_name = (string)this.dataGridView1.Rows[index].Cells[1].Value;
                info_flag = 1;
                History history = new History();
                history.ShowDialog();
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { checkBox1.ForeColor = SystemColors.ButtonHighlight; }
            if (!checkBox1.Checked) { checkBox1.ForeColor = SystemColors.ActiveBorder; }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { checkBox2.ForeColor = SystemColors.ButtonHighlight; }
            if (!checkBox2.Checked) { checkBox2.ForeColor = SystemColors.ActiveBorder; }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { checkBox3.ForeColor = SystemColors.ButtonHighlight; }
            if (!checkBox3.Checked) { checkBox3.ForeColor = SystemColors.ActiveBorder; }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { checkBox4.ForeColor = SystemColors.ButtonHighlight; }
            if (!checkBox4.Checked) { checkBox4.ForeColor = SystemColors.ActiveBorder; }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked) { checkBox5.ForeColor = SystemColors.ButtonHighlight; }
            if (!checkBox5.Checked) { checkBox5.ForeColor = SystemColors.ActiveBorder; }
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked) { checkBox6.ForeColor = SystemColors.ButtonHighlight; }
            if (!checkBox6.Checked) { checkBox6.ForeColor = SystemColors.ActiveBorder; }
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked) { checkBox7.ForeColor = SystemColors.ButtonHighlight; }
            if (!checkBox7.Checked) { checkBox7.ForeColor = SystemColors.ActiveBorder; }
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked) { checkBox8.ForeColor = SystemColors.ButtonHighlight; }
            if (!checkBox8.Checked) { checkBox8.ForeColor = SystemColors.ActiveBorder; }
        }


    }



}
