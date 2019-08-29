using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy
{
	class HangHoa
	{
		private string maHH;
		private string tenHH;
		private DateTime ngayNhap;
		private DateTime ngayHetHan;

		HangHoa()
		{

		}
        public string MaHH
        {
            get => maHH; set => maHH = value; }
            public string TenHH
        {
            get => tenHH; set => tenHH = value; }
            public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
            public DateTime NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        }
}
