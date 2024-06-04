using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Maximized;
            info_trig();
            
        }
        private void info_trig()
        {
            MyWord word = new MyWord();
            if (info.info_flag==1)
            {
                this.rpt_name.Text = info.doc_name;
                this.richTextBox1.Text = word.ImportWord(info.doc_path);
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            MyWord word = new MyWord();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "word文件|*.docx";
            object fileName = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName1 = dlg.FileName;
                fileName = fileName1;
            }
            string str = (string)fileName;
            rpt_name.Text = str;
            this.richTextBox1.Text = word.ImportWord(str);


        }
        


        private void button23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_doc_Click(object sender, EventArgs e)
        {
            MyWord word = new MyWord();
            string doc_text = this.richTextBox1.Text;
            string filename = this.plane_num.Text + this.start_time.Text + "_" + this.end_time.Text + ".docx";
            string doc_path = info.save_path + filename;
            word.ExportWord(doc_text, doc_path);
        }
    }
}
