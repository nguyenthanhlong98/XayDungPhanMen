using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DATA;

namespace BUS
{
    public class BusThongKe
    {
        dbChoThueDiaContextDataContext db = new dbChoThueDiaContextDataContext();

        //Lấy danh sách tất cả khách hàng (All)
        public List<eKhachHang> layDSKhachHang()
        {
            IEnumerable<tbKhachHang> dskh = (from n in db.tbKhachHangs
                                            select n).ToList();
            List<eKhachHang> dsKH = new List<eKhachHang>();
            foreach(tbKhachHang item  in dskh)
            {
                eKhachHang kh = new eKhachHang();
                kh.MaKhachHang = item.MaKhachHang;
                kh.TenKH = item.TenKH;
                kh.DiaChi = item.DiaChi;
                kh.SoDienThoai = item.SoDienThoai;
                kh.PhiPhat = (Decimal) item.PhiPhat;
                dsKH.Add(kh);
            }
            return dsKH;
        }

        //Lấy danh sách khách hàng có phí phạt (Phí phạt)
        public List<eKhachHang> layDSKhachHangCoPhiPhat()
        {
            IEnumerable<tbKhachHang> dskh = (from n in db.tbKhachHangs
                                             where n.PhiPhat >= 5000
                                            select n).ToList();
            List<eKhachHang> dsKH = new List<eKhachHang>();
            foreach (tbKhachHang item in dskh)
            {
                eKhachHang kh = new eKhachHang();
                kh.MaKhachHang = item.MaKhachHang;
                kh.TenKH = item.TenKH;
                kh.DiaChi = item.DiaChi;
                kh.SoDienThoai = item.SoDienThoai;
                kh.PhiPhat = (Decimal)item.PhiPhat;
                dsKH.Add(kh);
            }
            return dsKH;
        }

        //Lấy danh sách khách hàng bị trễ hạn (Trễ hạn)
        public List<eKhachHang> layDSKhachHangTreHanThueDia()
        {
            var dskh = (from n in db.tbKhachHangs
                        join x in db.tbLapPhieuThues on n.MaKhachHang equals x.MaKhachHang
                        join d in db.tbDiaCDs on x.MaDiaCD equals d.MaDiaCD
                        where (DateTime.Now > x.NgayPhaiTra) && d.TinhTrangDia.Equals("Đang Thuê")
                        select new
                        {
                            maKhachHang = n.MaKhachHang,
                            tenKH = n.TenKH,
                            diaChi = n.DiaChi,
                            soDienThoai = n.SoDienThoai,
                            phiPhat = n.PhiPhat
                        });

            List<eKhachHang> dsKH = new List<eKhachHang>();
            foreach (var item in dskh)
            {
                eKhachHang kh = new eKhachHang();
                kh.MaKhachHang = item.maKhachHang;
                kh.TenKH = item.tenKH;
                kh.DiaChi = item.diaChi;
                kh.SoDienThoai = item.soDienThoai;
                kh.PhiPhat = (Decimal)item.phiPhat;
                dsKH.Add(kh);
            }
            return dsKH;
        }

        //Lấy tổng số đĩa khách hàng đang thuê (All)
        public dynamic layDSTongDiaKHDangThue1()
        {
            dynamic dskh = (from n in db.tbKhachHangs
                            join x in db.tbLapPhieuThues on n.MaKhachHang equals x.MaKhachHang
                            join d in db.tbDiaCDs on x.MaDiaCD equals d.MaDiaCD
                            group n by new { n.MaKhachHang,d.TinhTrangDia } into box // Gom nhóm theo mã khách hàng
                            where box.Key.TinhTrangDia.Equals("Đang Thuê") // Điều kiện sau khi group
                            select new
                            {
                                maKhachHang = box.Key.MaKhachHang,
                                soLuong = box.Key.TinhTrangDia.Count()
                            });
            return dskh;
        }

        //Lấy tổng số đĩa khách hàng đang thuê (Trễ Hạn)
        public dynamic layDSTongDiaKHDangThue2()
        {
            dynamic dskh = (from n in db.tbKhachHangs
                            join x in db.tbLapPhieuThues on n.MaKhachHang equals x.MaKhachHang
                            join d in db.tbDiaCDs on x.MaDiaCD equals d.MaDiaCD
                            group n by new { n.MaKhachHang, d.TinhTrangDia,x.NgayPhaiTra } into box // Gom nhóm theo mã khách hàng
                            where box.Key.TinhTrangDia.Equals("Đang Thuê") && (DateTime.Now > box.Key.NgayPhaiTra) // Điều kiện sau khi group
                            select new
                            {
                                maKhachHang = box.Key.MaKhachHang,
                                soLuong = box.Key.TinhTrangDia.Count()
                            });
            return dskh;
        }

        //Lấy tổng số đĩa khách hàng đang thuê (Phí phạt)
        public dynamic layDSTongDiaKHDangThue3()
        {
            dynamic dskh = (from n in db.tbKhachHangs
                            join x in db.tbLapPhieuThues on n.MaKhachHang equals x.MaKhachHang
                            join d in db.tbDiaCDs on x.MaDiaCD equals d.MaDiaCD
                            where n.PhiPhat >=5000
                            group n by new { n.MaKhachHang, d.TinhTrangDia } into box // Gom nhóm theo mã khách hàng
                            where box.Key.TinhTrangDia.Equals("Đang Thuê") // Điều kiện sau khi group
                            select new
                            {
                                maKhachHang = box.Key.MaKhachHang,
                                soLuong = box.Key.TinhTrangDia.Count()
                            });
            return dskh;
        }

        //Lấy danh sách đĩa đã từng bị quá hạn (ALL)
        public dynamic layDSDiaBiQuaHan()
        {
            dynamic dsdia = (from  x in db.tbLapPhieuThues
                            join t in db.tbDiaCDs on x.MaDiaCD equals t.MaDiaCD
                            join h in db.tbTieuDes on t.MaTieuDe equals h.MaTieuDe
                            where ((DateTime.Now > x.NgayPhaiTra) && t.TinhTrangDia.Equals("Đang Thuê"))
                            select new
                            {
                                maDiaCD = x.MaDiaCD,
                                tenTieuDe = h.TenTieuDe,
                                tinhTrangDia = t.TinhTrangDia,
                                ngayPhaiTra = x.NgayPhaiTra,
                                ngayTraDia = x.NgayTraDia
                            });
            return dsdia;
        }

        //Lấy danh sách đĩa đã từng bị quá hạn (Trễ hạn)
        public dynamic layDSDiaBiQuaHan2()
        {
            dynamic dsdia = (from x in db.tbLapPhieuThues
                             join t in db.tbDiaCDs on x.MaDiaCD equals t.MaDiaCD
                             join h in db.tbTieuDes on t.MaTieuDe equals h.MaTieuDe
                             where ((DateTime.Now > x.NgayPhaiTra) && t.TinhTrangDia.Equals("Đang Thuê"))
                             select new
                             {
                                 maDiaCD = x.MaDiaCD,
                                 tenTieuDe = h.TenTieuDe,
                                 tinhTrangDia = t.TinhTrangDia,
                                 ngayPhaiTra = x.NgayPhaiTra,
                                 ngayTraDia = x.NgayTraDia
                             });
            return dsdia;
        }

        //Lấy danh sách đĩa đã từng bị quá hạn (Phí phạt)
        public dynamic layDSDiaBiQuaHan3()
        {
            dynamic dsdia = (from x in db.tbLapPhieuThues
                             join t in db.tbDiaCDs on x.MaDiaCD equals t.MaDiaCD
                             join h in db.tbTieuDes on t.MaTieuDe equals h.MaTieuDe
                             join k in db.tbKhachHangs on x.MaKhachHang equals k.MaKhachHang
                             where ((DateTime.Now > x.NgayPhaiTra) && t.TinhTrangDia.Equals("Đang Thuê")) && k.PhiPhat >=5000
                             select new
                             {
                                 maDiaCD = x.MaDiaCD,
                                 tenTieuDe = h.TenTieuDe,
                                 tinhTrangDia = t.TinhTrangDia,
                                 ngayPhaiTra = x.NgayPhaiTra,
                                 ngayTraDia = x.NgayTraDia
                             });
            return dsdia;
        }

        //Hiển thị danh sách tiền phạt hiện đang nợ (ALL)
        public dynamic LayDSTienPhatNo1()
        {
            dynamic dsTienPhat = (from x in db.tbLapPhieuThues
                                  join d in db.tbDiaCDs on x.MaDiaCD equals d.MaDiaCD
                                  join t in db.tbTieuDes on d.MaTieuDe equals t.MaTieuDe
                                  where x.KiemTraPhiPhat == false
                                  select new
                                  {
                                      maKhachHang = x.MaKhachHang,
                                      tenTieuDe = t.TenTieuDe,
                                      ngayPhaiTra = x.NgayPhaiTra,
                                      ngayTraDia = x.NgayTraDia,
                                      phiPhat = x.PhiPhat
                                  });
            return dsTienPhat;
        }

        //Hiển thị danh sách tiền phạt hiện đang nợ (Trễ hạn)
        public dynamic LayDSTienPhatNo2()
        {
            dynamic dsTienPhat = (from x in db.tbLapPhieuThues
                                  join d in db.tbDiaCDs on x.MaDiaCD equals d.MaDiaCD
                                  join t in db.tbTieuDes on d.MaTieuDe equals t.MaTieuDe
                                  where x.KiemTraPhiPhat == false || (DateTime.Now > x.NgayPhaiTra)
                                  select new
                                  {
                                      maKhachHang = x.MaKhachHang,
                                      tenTieuDe = t.TenTieuDe,
                                      ngayPhaiTra = x.NgayPhaiTra,
                                      ngayTraDia = x.NgayTraDia,
                                      phiPhat = x.PhiPhat
                                  });
            return dsTienPhat;
        }

        //Hiển thị danh sách tiền phạt hiện đang nợ (Phí phạt)
        public dynamic LayDSTienPhatNo3()
        {
            dynamic dsTienPhat = (from x in db.tbLapPhieuThues
                                  join d in db.tbDiaCDs on x.MaDiaCD equals d.MaDiaCD
                                  join t in db.tbTieuDes on d.MaTieuDe equals t.MaTieuDe
                                  join k in db.tbKhachHangs on x.MaKhachHang equals k.MaKhachHang
                                  where (x.KiemTraPhiPhat == false || (DateTime.Now > x.NgayPhaiTra)) && k.PhiPhat >= 5000
                                  select new
                                  {
                                      maKhachHang = x.MaKhachHang,
                                      tenTieuDe = t.TenTieuDe,
                                      ngayPhaiTra = x.NgayPhaiTra,
                                      ngayTraDia = x.NgayTraDia,
                                      phiPhat = x.PhiPhat
                                  });
            return dsTienPhat;
        }




        //Lấy danh sách tiêu đề
        public List<eTieuDe> layDSTieuDe()
        {
            IEnumerable<tbTieuDe> dsTieuDe = (from n in db.tbTieuDes
                                             select n).ToList();
            List<eTieuDe> dsTD = new List<eTieuDe>();
            foreach (tbTieuDe item in dsTieuDe)
            {
                eTieuDe td = new eTieuDe();
                td.MaTieuDe = item.MaTieuDe;
                td.TenTieuDe = item.TenTieuDe;
                td.MoTa = item.MoTa;
                td.MaLoai = item.MaLoai;
                dsTD.Add(td);
            }
            return dsTD;
        }

        //Ds tiêu đề có trạng thái địa trống
        public dynamic layDSTieuDeDiaTrong()
        {
            dynamic dsTieuDe = from n in db.tbDiaCDs
                               where n.TinhTrangDia.Equals("Trống")
                               group n by new { n.MaTieuDe, n.TinhTrangDia } into box
                               select new
                               {
                                   maTieuDe = box.Key.MaTieuDe,
                                   soLuongDiaTrong = box.Key.TinhTrangDia.Count()
                               };
            return dsTieuDe;
        }

        //Ds tiêu đề có trạng thái địa chờ
        public dynamic layDSTieuDeDiaCho()
        {
            dynamic dsTieuDe = from n in db.tbDiaCDs
                               where n.TinhTrangDia.Equals("Đang Chờ")
                               group n by new { n.MaTieuDe, n.TinhTrangDia } into box
                               select new
                               {
                                   maTieuDe = box.Key.MaTieuDe,
                                   soLuongDiaCho = box.Key.TinhTrangDia.Count()
                               };
            return dsTieuDe;
        }

        //Ds tiêu đề có trạng thái địa thuê
        public dynamic layDSTieuDeDiaThue()
        {
            dynamic dsTieuDe = from n in db.tbDiaCDs
                               where n.TinhTrangDia.Equals("Đang Thuê")
                               group n by new { n.MaTieuDe, n.TinhTrangDia } into box
                               select new
                               {
                                   maTieuDe = box.Key.MaTieuDe,
                                   soLuongDiaThue = box.Key.TinhTrangDia.Count()
                               };
            return dsTieuDe;
        }

        //Ds tiêu đề có số lượng đặt trước
        public dynamic layDSTieuDeDatTruoc()
        {
            dynamic dsTieuDe = from n in db.tbThongTinDatTruocs
                               group n by new { n.MaTieuDe } into box
                               select new
                               {
                                   maTieuDe = box.Key.MaTieuDe,
                                   soLuongDatTruoc = box.Key.MaTieuDe.Count()
                               };
            return dsTieuDe;
        }
    }
}
