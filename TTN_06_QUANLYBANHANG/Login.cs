using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLy
{
    public partial class Login : Form
    {
        private int dem = 3;
        public Login()
        {
            InitializeComponent();
        }

        private void bttnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txtUser.Text == "admin") && (txtPass.Text == "admin"))
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                txtUser.Focus();
                txtUser.SelectAll();
                txtPass.Text = "";
                dem--;
                MessageBox.Show("Bạn được phép nhập " + dem + " lần nữa!", "Thông báo từ Admin");

                if (dem == 0)
                {
                    MessageBox.Show("Bạn đã nhập quá 3 lần!", "Thông báo từ Admin");
                    Application.Exit();
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = this.Text.Substring(this.Text.Length - 1, 1) + this.Text.Substring(0, this.Text.Length - 1);            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = label2.Text.Substring(label2.Text.Length - 1, 1) + label2.Text.Substring(0, label2.Text.Length - 1);                        
        }


    }
}