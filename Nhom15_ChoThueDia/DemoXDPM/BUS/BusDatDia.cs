using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DATA;

namespace BUS
{
    public class BusDatDia
    {
        dbChoThueDiaContextDataContext db = new dbChoThueDiaContextDataContext();

        //Lấy danh sách hàng đợi
        public List<eDanhSachHangDoi> LayDanhSachHangDoi()
        {
            var dsHangDoi = from n in db.tbThongTinDatTruocs
                            join t in db.tbTieuDes on n.MaTieuDe equals t.MaTieuDe
                            select new
                            {
                                maDatDia = n.MaDatDia,
                                maKhachHang = n.MaKhachHang,
                                tenTieuDe = t.TenTieuDe,
                                ngayDatDia = n.NgayDatDia,
                                maDiaTam = n.MaDiaTam
                            };
            List<eDanhSachHangDoi> dsHangDoiCustom = new List<eDanhSachHangDoi>();
            foreach (var item in dsHangDoi)
            {
                eDanhSachHangDoi hangDoi = new eDanhSachHangDoi();
                hangDoi.MaDatDia = item.maDatDia;
                hangDoi.MaKhachHang = item.maKhachHang;
                hangDoi.TenTieuDe = item.tenTieuDe;
                hangDoi.NgayDatDia = DateTime.Parse(item.ngayDatDia.ToString());
                hangDoi.MaDiaTam = item.maDiaTam;
                dsHangDoiCustom.Add(hangDoi);
            }
            return dsHangDoiCustom;
        }

        //Lấy danh sách tiêu đề được lọc khi tiêu đề đó có ít nhất 1 đĩa ở trạng thái trống
        public List<eTieuDeComboBox> LayDanhSachTieuDe()
        {
            //Except dùng để lấy những phần tử ở bảng 1 mà không có trong bảng 2 A{1,2,3} B{1} => KQ{2,3}
            //Distinct loại bỏ các kết quả trùng lặp
            //Intersect lấy phần tử giao nhau của 2 bảng VD: A{1,2,3} B{1} => KQ{1}
            //Union lấy những phần tử thuộc cả 2 bảng    VD: A{1,2,3} B{2,4,6}  => KQ{1,2,3,4,6}
            dynamic dsTieuDe = (from n in db.tbTieuDes
                                select new
                                {
                                    maTieuDe = n.MaTieuDe,
                                    tenTieuDe = n.TenTieuDe
                                }).Except(  (from n in db.tbTieuDes
                                            join d in db.tbDiaCDs on n.MaTieuDe equals d.MaTieuDe
                                            where d.TinhTrangDia.Equals("Trống")
                                            group n by new { n.MaTieuDe, n.TenTieuDe } into box //group theo mã tiêu đề
                                            select new
                                            {
                                                maTieuDe = box.Key.MaTieuDe,
                                                tenTieuDe = box.Key.TenTieuDe
                                            }).Distinct()
                                            );
            List<eTieuDeComboBox> dsTieuDeCustom = new List<eTieuDeComboBox>();
            foreach (dynamic item in dsTieuDe)
            {
                eTieuDeComboBox td = new eTieuDeComboBox();
                td.MaTieuDe = item.maTieuDe;
                td.TenTieuDe = item.tenTieuDe;
                dsTieuDeCustom.Add(td);
            }
            return dsTieuDeCustom;
        }

        //Lấy tiêu đề khi truyền vào mã tiêu đề
        public eTieuDeDuocChon LayTieuDeBangMaTieuDe(string maTieuDe)
        {
            var tieuDe = (from t in db.tbTieuDes
                          join l in db.tbLoaiDias on t.MaLoai equals l.MaLoai
                          where t.MaTieuDe.Equals(maTieuDe)
                          select new
                          {
                              maTieuDe = t.MaTieuDe,
                              tenTieuDe = t.TenTieuDe,
                              moTa = t.MoTa,
                              tenLoai = l.TenLoai
                          }).FirstOrDefault();
            eTieuDeDuocChon tieuDeCustom = new eTieuDeDuocChon();
            tieuDeCustom.MaTieuDe = tieuDe.maTieuDe;
            tieuDeCustom.TenTieuDe = tieuDe.tenTieuDe;
            tieuDeCustom.MoTa = tieuDe.moTa;
            tieuDeCustom.TenLoai = tieuDe.tenLoai;
            return tieuDeCustom;
        }

        //Lấy mã tiêu đề khi truyền vào tên tiêu đề
        public string LayMaTieuDeBangTenTieuDe(string tenTieuDe)
        {
            tbTieuDe tieuDe = (from t in db.tbTieuDes
                               where t.TenTieuDe.Equals(tenTieuDe)
                               select t).FirstOrDefault();
            if (tieuDe != null)
            {
                return tieuDe.MaTieuDe;
            }
            return null;
        }

        //Kiểm tra Tiêu đề của 1 khách hàng có trùng trong hàng đợi hay không?
        public Boolean KiemTraKhachHangTrongHangDoi(string tenTieuDe, string maKhachHang)
        {
            var dsHangDoi = (from n in db.tbThongTinDatTruocs
                             join t in db.tbTieuDes on n.MaTieuDe equals t.MaTieuDe
                             where n.MaKhachHang.Equals(maKhachHang) && t.TenTieuDe.Equals(tenTieuDe)
                             select new
                             {
                                 maDatDia = n.MaDatDia,
                                 maKhachHang = n.MaKhachHang,
                                 tenTieuDe = t.TenTieuDe,
                                 ngayDatDia = n.NgayDatDia,
                                 maDiaTam = n.MaDiaTam
                             }).FirstOrDefault();
            if (dsHangDoi != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Kiểm tra tồn tại khách hàng
        public Boolean KiemTraTonTaiKhachHang(string maKhachHang)
        {
            var khachHang = (from n in db.tbKhachHangs
                             where n.MaKhachHang.Equals(maKhachHang)
                             select n).FirstOrDefault();
            if (khachHang != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Lấy khách hàng từ mã khách hàng
        public eKhachHang LayKhachHangBangMa(string maKhachHang)
        {
            var khachHang = (from n in db.tbKhachHangs
                             where n.MaKhachHang.Equals(maKhachHang)
                             select n).FirstOrDefault();
            if (khachHang != null)
            {
                eKhachHang kh = new eKhachHang();
                kh.MaKhachHang = khachHang.MaKhachHang;
                kh.TenKH = khachHang.TenKH;
                kh.SoDienThoai = khachHang.SoDienThoai;
                return kh;
            }
            else
            {
                return null;
            }
        }

        //Lấy danh sách khách hàng
        public List<eKhachHang> LayDanhSachKhachHang()
        {
            var dsKhachHang = (from n in db.tbKhachHangs
                               select n).ToList();
            List<eKhachHang> dsCustomKhachHang = new List<eKhachHang>();
            foreach (tbKhachHang t in dsKhachHang)
            {
                eKhachHang customKhachHang = new eKhachHang();
                customKhachHang.MaKhachHang = t.MaKhachHang;
                customKhachHang.TenKH = t.TenKH;
                customKhachHang.DiaChi = t.DiaChi;
                customKhachHang.SoDienThoai = t.SoDienThoai;
                dsCustomKhachHang.Add(customKhachHang);
            }
            return dsCustomKhachHang;
        }

        //Lưu hàng đợi vào CSDL
        public int themHangDoi(eDanhSachHangDoi hangdoi)
        {
            if (LayMaTieuDeBangTenTieuDe(hangdoi.TenTieuDe) != null)
            {
                tbThongTinDatTruoc tbHangDoi = new tbThongTinDatTruoc();
                tbHangDoi.MaDatDia = hangdoi.MaDatDia;
                tbHangDoi.MaKhachHang = hangdoi.MaKhachHang;
                tbHangDoi.NgayDatDia = hangdoi.NgayDatDia;
                tbHangDoi.MaTieuDe = LayMaTieuDeBangTenTieuDe(hangdoi.TenTieuDe); //Từ tên lấy mã tiêu đề
                tbHangDoi.MaDiaTam = hangdoi.MaDiaTam;
                db.tbThongTinDatTruocs.InsertOnSubmit(tbHangDoi);
                db.SubmitChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //Lấy danh sách hàng đợi của 1 khách hàng
        public List<eDanhSachHangDoi> LayDSHangDoiBangMaKhachHang(string maKhachHang)
        {
            var dsHangDoiCuaKhachHang = from n in db.tbThongTinDatTruocs
                                        join t in db.tbTieuDes on n.MaTieuDe equals t.MaTieuDe
                                        where n.MaKhachHang.Equals(maKhachHang)
                                        select new
                                        {
                                            maDatDia = n.MaDatDia,
                                            maKhachHang = n.MaKhachHang,
                                            tenTieuDe = t.TenTieuDe,
                                            ngayDatDia = n.NgayDatDia,
                                            maDiaTam = n.MaDiaTam
                                        };
            List<eDanhSachHangDoi> dsHangDoiCustom = new List<eDanhSachHangDoi>();
            foreach (var item in dsHangDoiCuaKhachHang)
            {
                eDanhSachHangDoi hangDoi = new eDanhSachHangDoi();
                hangDoi.MaDatDia = item.maDatDia;
                hangDoi.MaKhachHang = item.maKhachHang;
                hangDoi.TenTieuDe = item.tenTieuDe;
                hangDoi.NgayDatDia = DateTime.Parse(item.ngayDatDia.ToString());
                hangDoi.MaDiaTam = item.maDiaTam;
                dsHangDoiCustom.Add(hangDoi);
            }
            return dsHangDoiCustom;
        }

        //Xóa hàng đợi của khách hàng bằng mã đĩa đặt
        public int XoaHangDoiBangMaDatDia(string maDatDia)
        {
            tbThongTinDatTruoc hangDoi = (from n in db.tbThongTinDatTruocs
                                          where n.MaDatDia.Equals(maDatDia)
                                          select n).FirstOrDefault();
            if (hangDoi != null)
            {
                if (hangDoi.MaDiaTam != null)  //Có đĩa đang chờ xử lý
                {
                    BusLapPhieuTra lapPhieuTraController = new BusLapPhieuTra();
                    lapPhieuTraController.tuDongGanDia(hangDoi.MaDiaTam, hangDoi.MaTieuDe);
                    db.tbThongTinDatTruocs.DeleteOnSubmit(hangDoi);
                    db.SubmitChanges();
                }
                else //Không có đĩa chờ trong hàng đợi này
                {
                    db.tbThongTinDatTruocs.DeleteOnSubmit(hangDoi);
                    db.SubmitChanges();
                }
            }
            return 1;
        }
    }
}
