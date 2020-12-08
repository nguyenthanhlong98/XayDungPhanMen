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
    public partial class frmQLDia : Form
    {
        public frmQLDia()
        {

            InitializeComponent();
        }
        public List<eTieuDe> dsTieuDe;
        public BusQuanLyDia busQuanLyDia;
        public List<eDiaCD> dsDia;

        private void frmQLDia_Load(object sender, EventArgs e)
        {
            dsTieuDe = new List<eTieuDe>();
            busQuanLyDia = new BusQuanLyDia();
            dsDia = new List<eDiaCD>();
            dsTieuDe = busQuanLyDia.LayDSTieuDe();

            cboTieuDe.DataSource = dsTieuDe;
            cboTieuDe.DisplayMember = "TenTieuDe";
            cboTieuDe.ValueMember = "MaTieuDe";
            // Mã đĩa tăng tự động
            griDanhSachDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dsDia = busQuanLyDia.layDSDia();
           
            txtMaDia.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(busQuanLyDia.layDSDia()));
            griDanhSachDia.DataSource = dsDia;
            formatDatagridsDia();
        }

        private void formatDatagridsDia()
        {
            griDanhSachDia.Columns["maDiaCD"].HeaderText = "Mã Đĩa CD";
            griDanhSachDia.Columns["maDiaCD"].Width = 150;
            griDanhSachDia.Columns["maDiaCD"].ReadOnly = true;
            griDanhSachDia.Columns["tinhTrang"].HeaderText = "Tình Trạng ";
            griDanhSachDia.Columns["tinhTrang"].Width = 150;
            griDanhSachDia.Columns["tinhTrang"].ReadOnly = true;

            griDanhSachDia.Columns["maTieuDe"].HeaderText = "Mã tiêu đề";
            griDanhSachDia.Columns["maTieuDe"].Width = 150;
            griDanhSachDia.Columns["maTieuDe"].ReadOnly = true;
            
        }



        //Xét hàng đơn vị,chục,trăm,nghìn
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
        private int getMaDD_AuTo(List<eDiaCD> dshd)
        {
            int max = 0;
            foreach (eDiaCD item in dshd)
            {
                //Substring này lấy 4 kí tự cuối của chuỗi
                if (long.Parse(item.MaDiaCD.Substring(item.MaDiaCD.Length - 4)) >= max)
                {
                    max = Int32.Parse(item.MaDiaCD.Substring(item.MaDiaCD.Length - 4));
                }
            }
            return max + 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            eDiaCD eDia = new eDiaCD();
            eDia.MaDiaCD = txtMaDia.Text;
            eDia.TinhTrang = "Trống";
            eDia.MaTieuDe = busQuanLyDia.layMaTieuDe(cboTieuDe.Text);

  
            if (busQuanLyDia.themDia(eDia))
            {
                MessageBox.Show("Thêm thành công","");
                dsDia = busQuanLyDia.layDSDia();
                txtMaDia.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(busQuanLyDia.layDSDia()));
                griDanhSachDia.DataSource = dsDia;
                formatDatagridsDia();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (griDanhSachDia.SelectedRows.Count > 0) {
                String maDia = griDanhSachDia.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult d;
                d = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    busQuanLyDia.xoaDia(maDia);
                    MessageBox.Show("Xoa thanh cong");
                    dsDia = busQuanLyDia.layDSDia();
                    txtMaDia.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(busQuanLyDia.layDSDia()));
                    griDanhSachDia.DataSource = dsDia;
                    formatDatagridsDia();
                }
            }
        }
    }
}
