using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DATA;

namespace BUS
{
    public class BusBaoCao
    {
        dbChoThueDiaContextDataContext db = new dbChoThueDiaContextDataContext();
        //Lấy danh sách tiêu đề
        public List<eTieuDe> LayDSTieuDe()
        {
            IEnumerable<tbTieuDe> dsTieuDe = (from n in db.tbTieuDes
                                 select n).ToList();
            List<eTieuDe> dsCustomTieuDe = new List<eTieuDe>();
            foreach (tbTieuDe t in dsTieuDe)
            {
                eTieuDe customTieuDe = new eTieuDe();
                customTieuDe.MaTieuDe = t.MaTieuDe;
                customTieuDe.TenTieuDe = t.TenTieuDe;
                customTieuDe.MoTa = t.MoTa;
                customTieuDe.MaLoai = t.MaLoai;
                dsCustomTieuDe.Add(customTieuDe);
            }
            return dsCustomTieuDe;
        }

        //Lấy danh sách đĩa có trạng thái trống theo mã tiêu đề
        public List<eDiaCD> LayDSDiaBangMaTieuDe(string maTieuDe)
        {
            IEnumerable<tbDiaCD> dsDia = (from n in db.tbDiaCDs
                                          where n.TinhTrangDia.Equals("Trống") && n.MaTieuDe.Equals(maTieuDe)
                                          select n).ToList();
            List<eDiaCD> dsDiaCustom = new List<eDiaCD>();
            foreach(tbDiaCD item in dsDia)
            {
                eDiaCD dia = new eDiaCD();
                dia.MaDiaCD = item.MaDiaCD;
                dia.TinhTrang = item.TinhTrangDia;
                dia.MaTieuDe = item.MaTieuDe;
                dsDiaCustom.Add(dia);
            }
            return dsDiaCustom;
        }

        //Lấy tiêu đề đã chọn
        public eTieuDeDuocChon LayTieuDeDuocChon(string maTieuDe)
        {
            var tieuDeDuocChon = (from n in db.tbTieuDes
                                      join l in db.tbLoaiDias on n.MaLoai equals l.MaLoai
                                      where n.MaTieuDe.Equals(maTieuDe)
                                      select new
                                      {
                                          maTieuDe = n.MaTieuDe,
                                          tenTieuDe = n.TenTieuDe,
                                          tenLoai = l.TenLoai,
                                          moTa = n.MoTa
                                      }).FirstOrDefault();
            if (tieuDeDuocChon != null)
            {
                eTieuDeDuocChon tieuDe = new eTieuDeDuocChon();
                tieuDe.MaTieuDe = tieuDeDuocChon.maTieuDe;
                tieuDe.TenTieuDe = tieuDeDuocChon.tenTieuDe;
                tieuDe.TenLoai = tieuDeDuocChon.tenLoai;
                tieuDe.MoTa = tieuDeDuocChon.moTa;
                return tieuDe;
            }
            else
            {
                return null;
            }
        }

        //Kiểm tra tồn tại trong danh sách tiêu đề
        public Boolean KiemTraTieuDeTonTai(string tenTieuDe)
        {
            tbTieuDe td = (from n in db.tbTieuDes
                           where n.TenTieuDe.Equals(tenTieuDe)
                           select n).FirstOrDefault();
            if (td != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
