using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public static string opr_num;
        //登录按键
        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "123")
            {
                if (maskedTextBox1.Text == "")
                    MessageBox.Show("请输入密码");
                else if (worker_num.Text == "")
                    MessageBox.Show("请输入工号");
                else
                {
                    opr_num = worker_num.Text;
                    info form3 = new info();
                    this.Hide();
                    form3.ShowDialog();
                    this.Dispose();
                }
            }
            else
            { 
                MessageBox.Show("密码错误，请重新输入");
                maskedTextBox1.Text = "";
                maskedTextBox1.Focus();
            }
                
        }

        //回车键触发登录
        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==  '\r') 
            {
                btn_login.Focus();
                button1_Click(sender, e);
            }
        }
    }
}
