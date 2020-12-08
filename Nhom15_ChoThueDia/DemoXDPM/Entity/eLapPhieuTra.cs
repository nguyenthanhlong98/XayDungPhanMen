using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class eLapPhieuTra
    {
        public string MaPhieuThue { get; set; }
        public string MaKhachHang { get; set; }
        public string LoaiDia { get; set; }
        public string TenKhachHang { get; set; }
        public string TenTieuDe { get; set; }
        public DateTime NgayThueDia { get; set; }
        public DateTime NgayPhaiTra { get; set; }
        public decimal GiaDiaThue { get; set; }
        public DateTime NgayTraDia { get; set; }
        public decimal PhiPhat { get; set; }
        public bool KiemTraPhiPhat { get; set; }
        public string MaDiaCD { get; set; }
        public string TinhTrang { get; set; }
    }
}
