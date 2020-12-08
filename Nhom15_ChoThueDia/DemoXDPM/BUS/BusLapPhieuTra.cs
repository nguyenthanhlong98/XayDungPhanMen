using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using Entity;
namespace BUS
{
    public class BusLapPhieuTra
    {
        dbChoThueDiaContextDataContext db = new dbChoThueDiaContextDataContext();

        public eLapPhieuTra LayThongTinPhieuTra(string maDiaCD)
        {
            var dsDiaTam = db.tbDiaCDs.Where(x => x.MaDiaCD == maDiaCD).ToList();
            var dsPhieuThueTam = db.tbLapPhieuThues.ToList();
            var dsKhachHang = db.tbKhachHangs.ToList();
            var dsTieuDe = db.tbTieuDes.ToList();
            var dsLoaiDia = db.tbLoaiDias.ToList();
            eLapPhieuTra lapPhieuTra = new eLapPhieuTra();
            foreach (tbDiaCD DiaTam in dsDiaTam)
            {
                if (DiaTam.TinhTrangDia.Equals("Đang Thuê"))
                {
                    foreach (tbTieuDe tieudetam in dsTieuDe)
                    {
                        if (DiaTam.MaTieuDe.Equals(tieudetam.MaTieuDe))
                        {
                            lapPhieuTra.TenTieuDe = tieudetam.TenTieuDe;
                            foreach (tbLoaiDia loaiphim in dsLoaiDia)
                            {
                                if (tieudetam.MaLoai.Equals(loaiphim.MaLoai))
                                {
                                    lapPhieuTra.LoaiDia = loaiphim.TenLoai;
                                    lapPhieuTra.PhiPhat = (decimal)loaiphim.PhiPhat;
                                }
                            }
                        }
                    }
                    foreach (tbLapPhieuThue phieuthuetam in dsPhieuThueTam)
                    {
                        if (phieuthuetam.MaDiaCD.Equals(DiaTam.MaDiaCD))
                        {
                            lapPhieuTra.MaPhieuThue = phieuthuetam.MaPhieuThue;
                            lapPhieuTra.NgayThueDia = Convert.ToDateTime(phieuthuetam.NgayThueDia);
                            lapPhieuTra.NgayPhaiTra = Convert.ToDateTime(phieuthuetam.NgayPhaiTra);
                            foreach (tbKhachHang khachhangtam in dsKhachHang)
                            {
                                if (khachhangtam.MaKhachHang.Equals(phieuthuetam.MaKhachHang))
                                {
                                    lapPhieuTra.MaKhachHang = khachhangtam.MaKhachHang;
                                    lapPhieuTra.TenKhachHang = khachhangtam.TenKH;
                                }
                            }
                        }
                    }
                    return lapPhieuTra;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        public void UpdatePhieuThue(string maPhieuThue, eLapPhieuTra phieutra)
        {
            IQueryable<tbLapPhieuThue> updateDia = db.tbLapPhieuThues.Where(x => x.MaPhieuThue == maPhieuThue);
            updateDia.First().MaPhieuThue = maPhieuThue;
            updateDia.First().NgayTraDia = phieutra.NgayTraDia;
            updateDia.First().PhiPhat = phieutra.PhiPhat;
            updateDia.First().KiemTraPhiPhat = phieutra.KiemTraPhiPhat;
            db.SubmitChanges();
        }
        public void UpdateTrangThaiDia(string maDiaCD)
        {
            IQueryable<tbDiaCD> DiaCDTam = db.tbDiaCDs.Where(x => x.MaDiaCD.Equals(maDiaCD));
            DiaCDTam.First().MaDiaCD = maDiaCD;
            DiaCDTam.First().TinhTrangDia = "Trống";
            db.SubmitChanges();

        }
        public void UpdateTongPhiPhatKhachHang(string maKhachHang, decimal PhiPhat)
        {
            IQueryable<tbKhachHang> KhachHang = db.tbKhachHangs.Where(x => x.MaKhachHang == maKhachHang);
            KhachHang.First().MaKhachHang = maKhachHang;
            decimal TongPhi = (decimal)KhachHang.First().PhiPhat;
            if (TongPhi >= 0)
            {
                KhachHang.First().PhiPhat = TongPhi + PhiPhat;
            }
            else
            {
                KhachHang.First().PhiPhat = 0;
            }
            db.SubmitChanges();
        }


        //Nguyễn Lê Ngân Bình
        //Gán đĩa vào hàng đợi khi có người trả đĩa
        public void tuDongGanDia(string maDiaCD,string maTieuDe)
        {
            tbThongTinDatTruoc hangDoi = (from n in db.tbThongTinDatTruocs
                                          where n.MaTieuDe.Equals(maTieuDe) && n.MaDiaTam.Equals(null)
                                          select n).FirstOrDefault();
            if(hangDoi != null)
            {
                hangDoi.MaDiaTam = maDiaCD;
                db.SubmitChanges();
                UpdateTrangThaiDiaDangCho(maDiaCD);
            }
            else
            {
                UpdateTrangThaiDia(maDiaCD);
            }
        }

        //Update trạng thái đĩa khi có hàng chờ
        private void UpdateTrangThaiDiaDangCho(string maDiaCD)
        {
            IQueryable<tbDiaCD> DiaCDTam = db.tbDiaCDs.Where(x => x.MaDiaCD.Equals(maDiaCD));
            DiaCDTam.First().MaDiaCD = maDiaCD;
            DiaCDTam.First().TinhTrangDia = "Đang Chờ";
            db.SubmitChanges();

        }
    }
}
