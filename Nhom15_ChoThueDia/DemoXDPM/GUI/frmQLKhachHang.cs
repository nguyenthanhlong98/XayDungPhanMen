using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BUS;
namespace GUI
{
    public partial class frmQLKhachHang : Form
    {
        public frmQLKhachHang()
        {
            InitializeComponent();
        }
        public List<eKhachHang> dsKH;
        public BusQuanLyKhachHang busQuanLyKhachHang;
        private void frmQLKhachHang_Load(object sender, EventArgs e)
        {
            dsKH = new List<eKhachHang>();
            busQuanLyKhachHang = new BusQuanLyKhachHang();
            griDanhSachKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dsKH = busQuanLyKhachHang.layDSKhachHang();
            txtMaKH.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(busQuanLyKhachHang.layDSKhachHang()));
            griDanhSachKhachHang.DataSource = dsKH;
        }

        private string kiemTraMaTuDong(int so)
        {
            if (so / 10 >= 0 && so / 10 < 1) //số thuộc hàng đơn vị
            {
                return "000" + so;
            }
            else if (so / 10 >= 1 && so / 10 < 10) //số thuộc hàng chục
            {
                return "00" + so;
            }
            else if (so / 10 >= 10 && so / 10 < 100) //số thuộc hàng trăm
            {
                return "0" + so;
            }
            else //số thuộc hàng nghìn
            {
                return "" + so;
            }
        }

        //Hàm tự động tăng mã Đặt đĩa
        private int getMaDD_AuTo(List<eKhachHang> dshd)
        {
            int max = 0;
            foreach (eKhachHang item in dshd)
            {
                //Substring này lấy 4 kí tự cuối của chuỗi
                if (long.Parse(item.MaKhachHang.Substring(item.MaKhachHang.Length - 4)) >= max)
                {
                    max = Int32.Parse(item.MaKhachHang.Substring(item.MaKhachHang.Length - 4));
                }
            }
            return max + 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            eKhachHang eKhach = new eKhachHang();
            eKhach.MaKhachHang = txtMaKH.Text;
            eKhach.TenKH = txtTenKH.Text;
            eKhach.DiaChi = txtDiaChi.Text;
            eKhach.SoDienThoai = txtSDT.Text;
           // eKhach.PhiPhat = txtPhiPhat.Text.Length;

            if (busQuanLyKhachHang.themKhachHang(eKhach))
            {
                MessageBox.Show("Thêm thành công", "");
                dsKH = busQuanLyKhachHang.layDSKhachHang();
                txtMaKH.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(busQuanLyKhachHang.layDSKhachHang()));
                griDanhSachKhachHang.DataSource = dsKH;
               // formatDatagridsDia();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}
