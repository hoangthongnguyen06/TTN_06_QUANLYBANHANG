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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
       
        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nhanVienBindingSource.EndEdit();
            this.nhanVienTableAdapter.Update(this.DataSet1.NhanVien);

        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.DataSet1.NhanVien);
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", nhanVienDataGridView.DataSource, "MaNV");
            txtHo.DataBindings.Clear();
            txtHo.DataBindings.Add("Text", nhanVienDataGridView.DataSource, "Ho");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", nhanVienDataGridView.DataSource, "Ten");           
            chkNu.DataBindings.Clear();
            chkNu.DataBindings.Add("checked", nhanVienDataGridView.DataSource, "Phai");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", nhanVienDataGridView.DataSource, "DiaChi");
            txtDT.DataBindings.Clear();
            txtDT.DataBindings.Add("Text", nhanVienDataGridView.DataSource, "DienThoai");
            txtLuongCB.DataBindings.Clear();
            txtLuongCB.DataBindings.Add("Text", nhanVienDataGridView.DataSource, "LuongCB");
            txtCongViec.DataBindings.Clear();
            txtCongViec.DataBindings.Add("Text", nhanVienDataGridView.DataSource, "CongViec");
            txtMaKV.DataBindings.Clear();
            txtMaKV.DataBindings.Add("Text", nhanVienDataGridView.DataSource, "MaKV");
            TaoKetNoi();
            SqlCommand objcommand = new SqlCommand("Select * from NhanVien", objConnect);
            SqlDataReader objReader = objcommand.ExecuteReader();
            objDataTable = new DataTable("aaa");
            objDataTable.Load(objReader);
            huyKetNoi();
        }
		
		 private void btnHelp_Click(object sender, EventArgs e)
        {
            HuongDan HD = new HuongDan();
            HD.Show();
        }
        private SqlConnection objConnect;
        private DataTable objDataTable;
        private enum varMode : int { AddMode, EditMode, DeleteMode }            

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuongDan HD = new HuongDan();
            HD.Show();
        }
		
		 private void thôngTinChươngTrìnhVàTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia TG = new TacGia();
            TG.Show();
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CamOn CamOn = new CamOn();
            CamOn.Show();
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatHang MH = new MatHang();
            MH.Show();
            this.Close();
        }

         private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiHang LH = new LoaiHang();
            LH.Show();
            this.Close();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon HD = new HoaDon();
            HD.Show();
            this.Close();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CTHD CT = new CTHD();
            CT.Show();
            this.Close();
        }       

        public void TaoKetNoi()
        {
            string chuoiKetNoi = "Data Source=DESKTOP-5VIA6DA;Initial Catalog=SieuThi;Integrated Security=True";
            objConnect = new SqlConnection(chuoiKetNoi);
            objConnect.Open();
        }
    }
}