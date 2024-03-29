using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace QuanLy
{
    public partial class Main : Form
    {
        DataSet ds = new DataSet();
        public static string str; 

        public Main()
        {
            InitializeComponent();
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ds.Tables[this.cboTable.Text];
        }

        private void Main_Load(object sender, EventArgs e)
        {
            str = "Data Source=.;Initial Catalog=SieuThi;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(" Select * From HoaDon ", conn);
            da.Fill(ds, "Hóa Đơn");
            SqlDataAdapter da1 = new SqlDataAdapter(" Select * From NHanVien ", conn);
            da1.Fill(ds, "Nhân Viên");
            SqlDataAdapter da2 = new SqlDataAdapter(" Select * From CTHD", conn);
            da2.Fill(ds, "CTHD");
            SqlDataAdapter da3 = new SqlDataAdapter(" Select * From MatHang ", conn);
            da3.Fill(ds, "Mặt Hàng");
            SqlDataAdapter da4 = new SqlDataAdapter(" Select * From LoaiHang ", conn);
            da4.Fill(ds, "Loại Hàng");
            this.dataGridView1.DataSource = ds.Tables[0];
            foreach (DataTable t in ds.Tables)
            {
                this.cboTable.Items.Add(t.TableName);
            }

            conn.Close();           
            dataGridView1.ReadOnly = true;
        }

// Khai bao cac bien ket noi
        public SqlConnection objConnect;
        public DataTable objDataTable;
        public enum varMode : int { AddMode, EditMode, DeleteMode }

        # region Tao va huy ket noi
        public void TaoKetNoi()
        {
            string chuoiKetNoi = "Data Source=Phuoc;Initial Catalog=SieuThi;Integrated Security=True";
            objConnect = new SqlConnection(chuoiKetNoi);
            objConnect.Open();
        }
        public void huyKetNoi()
          {
           objConnect.Close(); //Đóng kết nối
           objConnect.Dispose();//Giải phóng tài nguyên
           objConnect = null; //Hủy đối tượng
          }
        
       #endregion   
  

          private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Convert.ToString(result) == "Yes")
            {
                Application.Exit();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Convert.ToString(result) == "Yes")
            {
                Application.Exit();
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien NhanVien = new NhanVien();
            NhanVien.ShowDialog();
        }

        private void thôngTinChươngTrìnhVàTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia TacGia = new TacGia();
            TacGia.ShowDialog();
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatHang MatHang = new MatHang();
            MatHang.ShowDialog();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiHang LoaiHang = new LoaiHang();
            LoaiHang.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon HoaDon = new HoaDon();
            HoaDon.ShowDialog();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CTHD CTHD = new CTHD();
            CTHD.ShowDialog();
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CamOn CamOn = new CamOn();
            CamOn.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HuongDan HuongDan = new HuongDan();
            HuongDan.ShowDialog();
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuongDan HuongDan = new HuongDan();
            HuongDan.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Login Login = new Login();
            Login.Show();
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
                x = label2.Text.Substring(0, 1).ToString();
                //Ban dau thi cat 1 ki tu ban trai truoc
                y = label2.Text.Substring(1, label2.Text.Length - 1).ToString();
                //Lay ca cac ki tu con lai ben phai
                label2.Text = y + x;

            }
        }

     
   
    }
}