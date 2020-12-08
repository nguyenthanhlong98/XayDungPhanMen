using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using Entity;

namespace BUS
{
    public class BusQuanLyDia
    {
        dbChoThueDiaContextDataContext db = new dbChoThueDiaContextDataContext();

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

        public List<eDiaCD> layDSDia()
        {
            IEnumerable<tbDiaCD> dsDia = (from n in db.tbDiaCDs
                                          select n).ToList();
            List<eDiaCD> dsCustomDiaCD = new List<eDiaCD>();
            foreach (tbDiaCD t in dsDia)
            {
                eDiaCD customDia = new eDiaCD();
                customDia.MaDiaCD = t.MaDiaCD;
                customDia.TinhTrang = t.TinhTrangDia;
                customDia.MaTieuDe = t.MaTieuDe;
                dsCustomDiaCD.Add(customDia);
            }
            return dsCustomDiaCD;
        }

        public String layMaTieuDe(String tenTieuDe)
        {
            tbTieuDe tieuDe = (from x in db.tbTieuDes
                               where x.TenTieuDe.Equals(tenTieuDe)
                               select x).FirstOrDefault();
            if (tieuDe != null)
            {
                return tieuDe.MaTieuDe;
            }
            return null;
        }

        public Boolean themDia(eDiaCD eDia)
        {
            tbDiaCD tbDia = new tbDiaCD();
            tbDia.MaDiaCD = eDia.MaDiaCD;
            tbDia.TinhTrangDia = eDia.TinhTrang;
            tbDia.MaTieuDe = eDia.MaTieuDe;
            db.tbDiaCDs.InsertOnSubmit(tbDia);
            db.SubmitChanges();
            return true;

        }

        public Boolean xoaDia(String ma)
        {
            tbDiaCD tbDia = (from x in db.tbDiaCDs
                             where x.MaDiaCD.Equals(ma)
                             select x).FirstOrDefault();
            if (tbDia != null)
            {
                db.tbDiaCDs.DeleteOnSubmit(tbDia);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

    } 
}
