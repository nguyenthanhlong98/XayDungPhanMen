using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DATA;
namespace BUS
{
    public class BusXemChiTietPhiPhat
    {
        dbChoThueDiaContextDataContext db = new dbChoThueDiaContextDataContext();

        public List<eChiTietPhiPhat> GetAllPhiPhatTheoMaKH(string maKH)
        {
            var dsPhieuThueTam = db.tbLapPhieuThues.Where(x => x.MaKhachHang == maKH).ToList();
            var dsDiaCDTam = db.tbDiaCDs.ToList();
            var dsTieuDeTam = db.tbTieuDes.ToList();
            var dsLoaiDiaTam = db.tbLoaiDias.ToList();
            List<eChiTietPhiPhat> lsPhiPhat = new List<eChiTietPhiPhat>();

            foreach (tbLapPhieuThue phieuthuetam in dsPhieuThueTam)
            {
                if (phieuthuetam.KiemTraPhiPhat == false && phieuthuetam.MaKhachHang.Equals(maKH))
                {
                    eChiTietPhiPhat chiTietPhiPhat = new eChiTietPhiPhat();
                    chiTietPhiPhat.MaPhieuThue = phieuthuetam.MaPhieuThue;
                    //   chiTietPhiPhat.MaKhachHang = khtam.MaKhachHang;
                    chiTietPhiPhat.NgayThueDia = (DateTime)phieuthuetam.NgayThueDia;
                    chiTietPhiPhat.NgayPhaiTra = (DateTime)phieuthuetam.NgayPhaiTra;
                    chiTietPhiPhat.NgayTraDia = (DateTime)phieuthuetam.NgayTraDia;
                    chiTietPhiPhat.PhiPhat = (double)phieuthuetam.PhiPhat;
                    chiTietPhiPhat.MaDiaCD = phieuthuetam.MaDiaCD;
                    foreach (tbDiaCD diacdtam in dsDiaCDTam)
                    {
                        if (phieuthuetam.MaDiaCD.Equals(diacdtam.MaDiaCD))
                        {
                            foreach (tbTieuDe tieudetam in dsTieuDeTam)
                            {
                                if (diacdtam.MaTieuDe.Equals(tieudetam.MaTieuDe))
                                {
                                    chiTietPhiPhat.TenTieuDe = tieudetam.TenTieuDe;
                                    foreach (tbLoaiDia loaidiatam in dsLoaiDiaTam)
                                    {
                                        if (tieudetam.MaLoai.Equals(loaidiatam.MaLoai))
                                        {
                                            chiTietPhiPhat.TenLoai = loaidiatam.TenLoai;
                                        //    chiTietPhiPhat.GiaDiaThue = (decimal)loaidiatam.Gia;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    lsPhiPhat.Add(chiTietPhiPhat);
                }

            }

            return lsPhiPhat;
        }
        public eKhachHang LayThongTinKhachHang(string maKH)
        {

            var KhachHang = db.tbKhachHangs.Where(x => x.MaKhachHang == maKH).FirstOrDefault();
            if (KhachHang != null)
            {
                eKhachHang kh = new eKhachHang();
                kh.MaKhachHang = KhachHang.MaKhachHang;
                kh.TenKH = KhachHang.TenKH;
                kh.PhiPhat = (decimal)KhachHang.PhiPhat;
                db.SubmitChanges();
                return kh;
            }
            else
                return null;
        }
        public List<eKhachHang> getALLKhachHang()
        {
            var dsKH = db.tbKhachHangs.ToList();
            List<eKhachHang> lsKH = new List<eKhachHang>();
            foreach(tbKhachHang tam in dsKH)
            {
                eKhachHang kh = new eKhachHang();
                kh.MaKhachHang = tam.MaKhachHang;
                kh.TenKH = tam.TenKH;
                lsKH.Add(kh);
            }
            return lsKH;
        }
        public void UpdatePhiPhatPhieuThue(string maPhieuThue)
        {
            IQueryable<tbLapPhieuThue> PhieuThue = db.tbLapPhieuThues.Where(x => x.MaPhieuThue == maPhieuThue);
            PhieuThue.First().MaPhieuThue = maPhieuThue;
            PhieuThue.First().KiemTraPhiPhat = true;   
        }
        public void UpdateTongPhiPhatKhachHang(string maKhachHang, decimal PhiPhat)
        {
            IQueryable<tbKhachHang> KhachHang = db.tbKhachHangs.Where(x => x.MaKhachHang == maKhachHang);
            KhachHang.First().MaKhachHang = maKhachHang;
            decimal TongPhi = (decimal)KhachHang.First().PhiPhat;
            if (TongPhi > 0)
            {
                KhachHang.First().PhiPhat = TongPhi - PhiPhat;
            }
            else
            {
                KhachHang.First().PhiPhat = 0;
            }
            db.SubmitChanges();
        }
    }
}
