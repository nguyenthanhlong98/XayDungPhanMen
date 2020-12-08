using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using Entity;
namespace BUS
{
    public class BusQuanLyKhachHang
    {
        dbChoThueDiaContextDataContext db = new dbChoThueDiaContextDataContext();

        public List<eKhachHang> layDSKhachHang()
        {
            IEnumerable<tbKhachHang> dsKH = (from n in db.tbKhachHangs
                                             select n).ToList();
            List<eKhachHang> dsCustomKH = new List<eKhachHang>();
            foreach (tbKhachHang t in dsKH)
            {
                eKhachHang customKH = new eKhachHang();
                customKH.MaKhachHang = t.MaKhachHang;
                customKH.TenKH = t.TenKH;
                customKH.DiaChi = t.DiaChi;
                customKH.SoDienThoai = t.SoDienThoai;
                customKH.PhiPhat = (decimal)t.PhiPhat;
                dsCustomKH.Add(customKH);
            }
            return dsCustomKH;
        }
        public Boolean themKhachHang(eKhachHang eKhach)
        {
            tbKhachHang tbKhach = new tbKhachHang();
            tbKhach.MaKhachHang = eKhach.MaKhachHang;
            tbKhach.TenKH = eKhach.TenKH;
            tbKhach.DiaChi = eKhach.DiaChi;
            tbKhach.SoDienThoai = eKhach.SoDienThoai;
            //tbKhach.PhiPhat = eKhach.PhiPhat;
            return true;
        }

        public Boolean xoaKhachHang(String ma) {
            tbKhachHang tbKhach = (from x in db.tbKhachHangs
                             where x.MaKhachHang.Equals(ma)
                             select x).FirstOrDefault();
            if (tbKhach != null)
            {
                db.tbKhachHangs.DeleteOnSubmit(tbKhach);
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
