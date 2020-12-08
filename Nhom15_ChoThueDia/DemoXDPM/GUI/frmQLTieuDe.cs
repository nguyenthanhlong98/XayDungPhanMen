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
    public partial class frmQLTieuDe : Form
    {
        public frmQLTieuDe()
        {
            InitializeComponent();
        }
        public List<eTieuDe> dsTieuDe;
        public BusTieuDe busQuanTieuDe;
        public List<eLoaiDia> dsLoaiDia;
        private void frmQLTieuDe_Load(object sender, EventArgs e)
        {
            dsTieuDe = new List<eTieuDe>();
            busQuanTieuDe = new BusTieuDe();
            dsLoaiDia = new List<eLoaiDia>();
            dsLoaiDia = busQuanTieuDe.LayDSLoaiDia();

            cboMaLoai.DataSource = dsLoaiDia;
            cboMaLoai.DisplayMember = "TenLoai";
            cboMaLoai.ValueMember = "MaLoai";
            // mã đĩa tăng tự động
            griViewTieuDe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dsTieuDe = busQuanTieuDe.layDSTieuDe();

            txtMaTieuDe.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(busQuanTieuDe.layDSTieuDe()));
            griViewTieuDe.DataSource = dsTieuDe;
            formatDatagridsDia();
        }

        private void formatDatagridsDia()
        {
            griViewTieuDe.Columns["maTieuDe"].HeaderText = "Mã tiêu đề";
            griViewTieuDe.Columns["maTieuDe"].Width = 300;
            griViewTieuDe.Columns["maTieuDe"].ReadOnly = true;

            griViewTieuDe.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            griViewTieuDe.Columns["tenTieuDe"].Width = 300;
            griViewTieuDe.Columns["tenTieuDe"].ReadOnly = true;

            griViewTieuDe.Columns["moTa"].HeaderText = "Mô tả";
            griViewTieuDe.Columns["moTa"].Width = 300;
            griViewTieuDe.Columns["moTa"].ReadOnly = true;

            griViewTieuDe.Columns["maLoai"].HeaderText = "Mã loại";
            griViewTieuDe.Columns["maLoai"].Width = 300;
            griViewTieuDe.Columns["maLoai"].ReadOnly = true;

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
        private int getMaDD_AuTo(List<eTieuDe> dshd)
        {
            int max = 0;
            foreach (eTieuDe item in dshd)
            {
                //Substring này lấy 4 kí tự cuối của chuỗi
                if (long.Parse(item.MaTieuDe.Substring(item.MaTieuDe.Length - 4)) >= max)
                {
                    max = Int32.Parse(item.MaTieuDe.Substring(item.MaTieuDe.Length - 4));
                }
            }
            return max + 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            eTieuDe eDe = new eTieuDe();
            eDe.MaTieuDe = txtMaTieuDe.Text;
            eDe.TenTieuDe = txtTenTieuDe.Text;
            eDe.MoTa = txtMoTa.Text;
            eDe.MaLoai = busQuanTieuDe.layMaLoai(cboMaLoai.Text);

            if (busQuanTieuDe.themTieuDe(eDe))
            {
                MessageBox.Show("Thêm thành công", "");
                dsTieuDe = busQuanTieuDe.layDSTieuDe();
                txtMaTieuDe.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(busQuanTieuDe.layDSTieuDe()));
                griViewTieuDe.DataSource = dsTieuDe;
                formatDatagridsDia();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (griViewTieuDe.SelectedRows.Count > 0)
            {
                String maTieuDe = griViewTieuDe.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult d;
                d = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    busQuanTieuDe.xoaTieuDe(maTieuDe);
                    MessageBox.Show("Xoa thanh cong");
                    dsTieuDe = busQuanTieuDe.layDSTieuDe();
                    txtMaTieuDe.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(busQuanTieuDe.layDSTieuDe()));
                    griViewTieuDe.DataSource = dsTieuDe;
                    formatDatagridsDia();
                }
            }
        }
    }
}
