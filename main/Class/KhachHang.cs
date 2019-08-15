using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy
{
	class KhachHang
	{
		private string maKH;
		private string tenKH;
		private DateTime ngayMua;

		public string MaKH { get => maKH; set => maKH = value; }
		public string TenKH { get => tenKH; set => tenKH = value; }
		public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
	}
}
