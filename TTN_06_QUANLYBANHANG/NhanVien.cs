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
            string chuoiKetNoi = "Data Source=DESKTOP-2LM6C8U\\SQLSERVER;Initial Catalog=SieuThi;Integrated Security=True";
            objConnect = new SqlConnection(chuoiKetNoi);
            objConnect.Open();
        }
        public void huyKetNoi()
        {
            objConnect.Close(); //Đóng kết nối
            objConnect.Dispose();//Giải phóng tài nguyên
            objConnect = null; //Hủy đối tượng
        }   

        public void UpdateNV()
        {
            TaoKetNoi();
            //Tạo đối tượng command
            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnect;
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = "Update NhanVien Set " +
                                    "Ho = " + "'" + txtHo.Text + "'" + "," +
                                    "Ten = " + "'" + txtTen.Text + "'" + "," +
                                    "Phai = "  + "'" + Convert.ToBoolean(chkNu.CheckState) + "'" + "," +
                                    "DiaChi = " + "'" + txtDiaChi.Text + "'" + "," +
                                    "DienThoai = " + "'" + txtDT.Text + "'" + "," +
                                    "LuongCB = " + "'" + txtLuongCB.Text + "'" + "," +
                                    "CongViec = " + "'" + txtCongViec.Text + "'" + "," +
                                    "MaKV = " + "'" + txtMaKV.Text + "'" + 
                                    " Where MaNV = " + Convert.ToInt32(txtMaNV.Text);
            objCommand.ExecuteNonQuery();
            //Hủy đối tượng
            objCommand.Dispose();
            objCommand = null;
            huyKetNoi();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateNV();
            }
            catch
            {
                MessageBox.Show("Không thể update !", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void txtTimNV_Click(object sender, EventArgs e)
        {
            txtTimNV.SelectAll();
            txtTimNV.Text = "";
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            TaoKetNoi();
            SqlDataAdapter da = new SqlDataAdapter("TimNhanVien " + txtTimNV.Text, objConnect);
            DataTable t1 = new DataTable();
            da.Fill(t1);
            this.nhanVienDataGridView.DataSource = t1;
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

    }
}