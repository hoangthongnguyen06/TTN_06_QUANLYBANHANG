using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
                                    
            objCommand.ExecuteNonQuery();
            //Hủy đối tượng
            objCommand.Dispose();
            objCommand = null;
            huyKetNoi();
        }
        private void bttncapnhat_Click(object sender, EventArgs e)
        {
            UpdateMH();

        }

        private void btnTimMH_Click(object sender, EventArgs e)
        {
            TaoKetNoi();
            SqlDataAdapter da = new SqlDataAdapter("TimMatHang " + txtTimMH.Text, objConnect);
            DataTable t1 = new DataTable();
            da.Fill(t1);
            this.matHangDataGridView.DataSource = t1;
            huyKetNoi(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = this.Text.Substring(this.Text.Length - 1, 1) + this.Text.Substring(0, this.Text.Length - 1);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            {
                string x;
                string y;
                x = label8.Text.Substring(0, 1).ToString();
                //Ban dau thi cat 1 ki tu ban trai truoc
                y = label8.Text.Substring(1, label8.Text.Length - 1).ToString();
                //Lay ca cac ki tu con lai ben phai
                label8.Text = y + x;

            }
        }

    }
}