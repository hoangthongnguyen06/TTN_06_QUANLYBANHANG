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
    public partial class LoaiHang : Form
    {
        // comments
        private SqlConnection objConnect;
        public LoaiHang()
        {
            InitializeComponent();
        }

        private void loaiHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.loaiHangBindingSource.EndEdit();
            this.loaiHangTableAdapter.Update(this.DataSet1.LoaiHang);

        }

        private void LoaiHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.LoaiHang' table. You can move, or remove it, as needed.
            this.loaiHangTableAdapter.Fill(this.DataSet1.LoaiHang);
            txtMaLH.DataBindings.Clear();
            txtMaLH.DataBindings.Add("Text", loaiHangDataGridView.DataSource, "MaLH");
            txtTenLH.DataBindings.Clear();
            txtTenLH.DataBindings.Add("Text", loaiHangDataGridView.DataSource, "TenLH");
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", loaiHangDataGridView.DataSource, "MoTa");
           // pictureBox1.DataBindings.Clear();
           // pictureBox1.DataBindings.Add("image", loaiHangDataGridView.DataSource, "Hinh");
            

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            NhanVien NhanVien = new NhanVien();
            NhanVien.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            HoaDon HoaDon = new HoaDon();
            HoaDon.Show();
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            MatHang matHang = new MatHang();
            matHang.Show();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            CTHD CT = new CTHD();
            CT.Show();
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuongDan HD = new HuongDan();
            HD.ShowDialog();
        }

        private void thôngTinVềChươngTrìnhVàTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia TG = new TacGia();
            TG.ShowDialog();
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CamOn CamOn = new CamOn();
            CamOn.ShowDialog();
        }

        private void toolStriptimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.SelectAll();
            txtTimKiem.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void TaoKetNoi()
        {
            string chuoiKetNoi = "Data Source=DESKTOP-5VIA6DA;Initial Catalog=SieuThi;Integrated Security=True";
            objConnect = new SqlConnection(chuoiKetNoi);
            objConnect.Open();
        }
        public void huyKetNoi()
        {
            objConnect.Close(); //Đóng kết nối
            objConnect.Dispose();//Giải phóng tài nguyên
            objConnect = null; //Hủy đối tượng
        }

       public void UpdateLH()
        {
            TaoKetNoi();
            //Tạo đối tượng command
            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnect;
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = "Update LoaiHang Set " +
                                    "TenLH= " + "'" + txtTenLH.Text + "'" + "," +
                                    "MoTa = " + "'" + txtMoTa.Text + "'" + 
                                    " Where MaLH = " + Convert.ToInt32(txtMaLH.Text);
            objCommand.ExecuteNonQuery();
            //Hủy đối tượng
            objCommand.Dispose();
            objCommand = null;
            huyKetNoi();
        }

        private void bttncapnhat_Click(object sender, EventArgs e)
        {
            UpdateLH();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaoKetNoi();
            SqlDataAdapter da = new SqlDataAdapter("TimLoaiHang " + txtTimKiem.Text, objConnect);
            DataTable t1 = new DataTable();
            da.Fill(t1);
            this.loaiHangDataGridView.DataSource = t1;
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
                x = label10.Text.Substring(0, 1).ToString();
                //Ban dau thi cat 1 ki tu ban trai truoc
                y = label10.Text.Substring(1, label10.Text.Length - 1).ToString();
                //Lay ca cac ki tu con lai ben phai
                label10.Text = y + x;

            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }
    }
}