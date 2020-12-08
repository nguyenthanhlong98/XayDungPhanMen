using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DATA;
namespace BUS
{
    public class BusLapPhieuThue
    {
        dbChoThueDiaContextDataContext db = new dbChoThueDiaContextDataContext();
        public List<eTieuDe> getALLTieuDeDia()
        {
            var dstam = db.tbTieuDes.ToList();
            List<eTieuDe> lsTieuDe = new List<eTieuDe>();
            foreach (tbTieuDe tam in dstam)
            {
                eTieuDe tieude = new eTieuDe();
                tieude.MaTieuDe = tam.MaTieuDe;
                tieude.TenTieuDe = tam.TenTieuDe;
                tieude.MoTa = tam.MoTa;
                tieude.MaLoai = tam.MaLoai;
                lsTieuDe.Add(tieude);
            }
            return lsTieuDe;

        }
        //public List<eHienThiDiaDeChon> getALLDiaDeChon(string maTieuDe)
        //{
        //    var dstamDia = db.tbDiaCDs.Where(x => x.MaTieuDe.Equals(maTieuDe)).ToList();
        //    var dstamTieuDe = db.tbTieuDes.ToList();
        //    var dstamLoaiDia = db.tbLoaiDias.ToList();
        //    List<eHienThiDiaDeChon> lsDiaCD = new List<eHienThiDiaDeChon>();
        //    foreach (tbDiaCD tamdiaCD in dstamDia)
        //    {
        //        eHienThiDiaDeChon diachon = new eHienThiDiaDeChon();
        //        if (tamdiaCD.TinhTrangDia.Equals("Đang Chờ") || tamdiaCD.TinhTrangDia.Equals("Trống"))
        //        {
        //            diachon.MaDiaCD = tamdiaCD.MaDiaCD;
        //            diachon.TinhTrang = tamdiaCD.TinhTrangDia;
        //            foreach (tbTieuDe tamTieuDe in dstamTieuDe)
        //            {
        //                if (tamdiaCD.MaTieuDe == tamTieuDe.MaTieuDe)
        //                {
        //                    foreach (tbLoaiDia tamLoaiDia in dstamLoaiDia)
        //                    {
        //                        if (tamTieuDe.MaLoai == tamLoaiDia.MaLoai)
        //                        {
        //                            diachon.TenLoai = tamLoaiDia.TenLoai;
        //                            diachon.ThoiGianThue = (int)tamLoaiDia.ThoiGianThue;
        //                            diachon.Gia = Math.Round((decimal)tamLoaiDia.Gia, 0);
        //                            // diachon.Gia = (decimal)tamLoaiDia.Gia;
        //                        }
        //                    }
        //                }
        //            }
        //            lsDiaCD.Add(diachon);
        //        }
        //    }
        //    return lsDiaCD;
        //}

        public List<eHienThiDiaDeChon> getALLDiaDeChon(string maTieuDe)
        {
            var dstamDia = db.tbDiaCDs.Where(x => x.MaTieuDe.Equals(maTieuDe)).ToList();
            var dstamTieuDe = db.tbTieuDes.ToList();
            var dstamLoaiDia = db.tbLoaiDias.ToList();
            List<eHienThiDiaDeChon> lsDiaCD = new List<eHienThiDiaDeChon>();
            foreach (tbDiaCD tamdiaCD in dstamDia)
            {
                eHienThiDiaDeChon diachon = new eHienThiDiaDeChon();
                if (tamdiaCD.TinhTrangDia.Equals("Trống"))
                {
                    diachon.MaDiaCD = tamdiaCD.MaDiaCD;
                    diachon.TinhTrang = tamdiaCD.TinhTrangDia;
                    foreach (tbTieuDe tamTieuDe in dstamTieuDe)
                    {
                        if (tamdiaCD.MaTieuDe == tamTieuDe.MaTieuDe)
                        {
                            foreach (tbLoaiDia tamLoaiDia in dstamLoaiDia)
                            {
                                if (tamTieuDe.MaLoai == tamLoaiDia.MaLoai)
                                {
                                    diachon.TenLoai = tamLoaiDia.TenLoai;
                                    diachon.ThoiGianThue = (int)tamLoaiDia.ThoiGianThue;
                                    diachon.Gia = Math.Round((decimal)tamLoaiDia.Gia, 0);
                                    // diachon.Gia = (decimal)tamLoaiDia.Gia;
                                }
                            }
                        }
                    }
                    lsDiaCD.Add(diachon);
                }
            }
            return lsDiaCD;
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
        public int LapPhieuThue(eLapPhieuThue NewPhieuThue)
        {
            if (CheckIfExist(NewPhieuThue.MaPhieuThue) == true)
                return 0;
            tbLapPhieuThue pttam = new tbLapPhieuThue();
            pttam.MaPhieuThue = NewPhieuThue.MaPhieuThue;
            pttam.MaKhachHang = NewPhieuThue.MaKhachHang;
            pttam.NgayThueDia = Convert.ToDateTime(NewPhieuThue.NgayThueDia);
            pttam.NgayPhaiTra = NewPhieuThue.NgayPhaiTra;
            pttam.GiaDiaThue = NewPhieuThue.GiaDiaThue;
            pttam.MaDiaCD = NewPhieuThue.MaDiaCD;
            db.tbLapPhieuThues.InsertOnSubmit(pttam);
            db.SubmitChanges();
            return 1;
        }
        public void UpdateTrangThaiDia(string maDiaCD)
        {
            IQueryable<tbDiaCD> DiaCDTam = db.tbDiaCDs.Where(x => x.MaDiaCD.Equals(maDiaCD));
            DiaCDTam.First().MaDiaCD = maDiaCD;
            DiaCDTam.First().TinhTrangDia = "Đang Thuê";
            db.SubmitChanges();

        }
        public bool CheckIfExist(string maPhieuThue)
        {
            tbLapPhieuThue pttemp = db.tbLapPhieuThues.Where(x => x.MaPhieuThue == maPhieuThue).FirstOrDefault();
            if (pttemp != null)
                return true;
            return false;
        }
        public List<eLapPhieuThue> getALLMaPhieuThue()
        {
            var lstam = db.tbLapPhieuThues.ToList();
            List<eLapPhieuThue> lsMaPhieuThue = new List<eLapPhieuThue>();
            foreach(tbLapPhieuThue tam in lstam)
            {
                eLapPhieuThue pt = new eLapPhieuThue();
                pt.MaPhieuThue = tam.MaPhieuThue;
                lsMaPhieuThue.Add(pt);
            }
            return lsMaPhieuThue;
        }
        //public List<eLoaiDia> getALLLoaiDia()
        //{
        //    var dstam = db.tbLoaiDias.ToList();
        //    List<eLoaiDia> lsLoaiDia = new List<eLoaiDia>();
        //    foreach (tbLoaiDia tam in dstam)
        //    {
        //        eLoaiDia loaidia = new eLoaiDia();
        //        loaidia.MaLoai = tam.MaLoai;
        //        loaidia.TenLoai = tam.TenLoai;
        //        loaidia.ThoiGianThue = (int)tam.ThoiGianThue;
        //        loaidia.Gia = (decimal)tam.Gia;
        //        lsLoaiDia.Add(loaidia);
        //    }
        //    return lsLoaiDia;

        //}
        //public List<eDiaCD> getALLDiaTheoTieuDe(string maTieuDe)
        //{
        //    var dstam = db.tbDiaCDs.Where(x => x.MaTieuDe.Equals(maTieuDe)).ToList();
        //    List<eDiaCD> lsDiaCD = new List<eDiaCD>();
        //    foreach (tbDiaCD tam in dstam)
        //    {
        //        eDiaCD diacd = new eDiaCD();
        //        diacd.MaDiaCD = tam.MaDiaCD;
        //        diacd.TinhTrang = tam.TinhTrangDia;
        //        diacd.MaDiaCD = tam.MaDiaCD;
        //        lsDiaCD.Add(diacd);
        //    }
        //    return lsDiaCD;
        //}



        //----Nguyễn Lê Ngân Bình ----//
        //Lấy đĩa bằng mã đĩa
        public eDiaCD layDiaBangMaDia(string maDiaCD)
        {
            tbDiaCD diaCD = (from n in db.tbDiaCDs
                             where n.MaDiaCD.Equals(maDiaCD)
                             select n).FirstOrDefault();
            if (diaCD != null)
            {
                eDiaCD diaCDCustom = new eDiaCD();
                diaCDCustom.MaDiaCD = diaCD.MaDiaCD;
                diaCDCustom.TinhTrang = diaCD.TinhTrangDia;
                diaCDCustom.MaTieuDe = diaCD.MaTieuDe;
                return diaCDCustom;
            }
            else
            {
                return null;
            }
        }

        //Lấy mã khách hàng bằng mã đĩa trong hàng đợi
        public string layMaKhachHangBangMaDia(string maDiaCD)
        {
            tbThongTinDatTruoc hangDoi = (from n in db.tbThongTinDatTruocs
                                          where n.MaDiaTam.Equals(maDiaCD)
                                          select n).FirstOrDefault();
            if (hangDoi != null)
            {
                return hangDoi.MaKhachHang;
            }
            else
            {
                return null;
            }
        }

        //Lấy danh sách đặt trước của khách hàng
        public List<eHienThiDiaDeChon> layDSDatDiaCuaKH(string maKhachHang)
        {
            var dsDatDia = (from n in db.tbThongTinDatTruocs
                            join t in db.tbTieuDes on n.MaTieuDe equals t.MaTieuDe
                            join l in db.tbLoaiDias on t.MaLoai equals l.MaLoai
                            where n.MaDiaTam != null && n.MaKhachHang.Equals(maKhachHang) 
                            select new
                            {
                                maDiaCD = n.MaDiaTam,
                                tenLoai = l.TenLoai,
                                tinhTrangDia = "Đang Chờ",
                                thoiGianThue = l.ThoiGianThue,
                                gia = l.Gia
                            }).ToList();
            List<eHienThiDiaDeChon> dsDatDiaCustom = new List<eHienThiDiaDeChon>();
            foreach(var item in dsDatDia)
            {
                eHienThiDiaDeChon diaCho = new eHienThiDiaDeChon();
                diaCho.MaDiaCD = item.maDiaCD;
                diaCho.TenLoai = item.tenLoai;
                diaCho.TinhTrang = item.tinhTrangDia;
                diaCho.ThoiGianThue = (Int32) item.thoiGianThue;
                diaCho.Gia = (Decimal) item.gia;
                dsDatDiaCustom.Add(diaCho);
            }
            return dsDatDiaCustom;
        }

        //Xóa hàng đợi của khách hàng bằng mã đĩa tạm
        public int XoaHangDoiBangMaDatDia(string maDiaTam)
        {
            tbThongTinDatTruoc hangDoi = (from n in db.tbThongTinDatTruocs
                                          where n.MaDiaTam.Equals(maDiaTam)
                                          select n).FirstOrDefault();
            if (hangDoi != null)
            {
                db.tbThongTinDatTruocs.DeleteOnSubmit(hangDoi);
                db.SubmitChanges();
            }
            return 1;
        }
    }
}
