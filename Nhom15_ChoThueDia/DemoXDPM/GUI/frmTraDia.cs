using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Entity;
namespace GUI
{
    public partial class frmTraDia : Form
    {
        BusLapPhieuTra busLapPhieuTra;
        BusDatDia busDatDia;
        string MaDiaCD = "";
        bool KiemTraTraDia = false;
        string MaPhieuThue = "";
        public frmTraDia()
        {
            InitializeComponent();
            busLapPhieuTra = new BusLapPhieuTra();
            busDatDia = new BusDatDia();
        }

        private void frmTraDia_Load(object sender, EventArgs e)
        {

        }

        private void txtMaDia_TraDia_Leave(object sender, EventArgs e)
        {
            MaDiaCD = txtMaDia_TraDia.Text;
            eLapPhieuTra PhieuTra = new eLapPhieuTra();
            PhieuTra = busLapPhieuTra.LayThongTinPhieuTra(MaDiaCD);
            if (PhieuTra != null)
            {
                MaPhieuThue = PhieuTra.MaPhieuThue;
                txtTenTieuDeDia_TraDia.Text = PhieuTra.TenTieuDe;
                txtLoaiDia_TraDia.Text = PhieuTra.LoaiDia;
                dateTimePicker_NgayThue_TraDia.Value = PhieuTra.NgayThueDia;
                dateTimePicker_NgayPhaiTra.Value = PhieuTra.NgayPhaiTra;
                txtMaKH_TraDia.Text = PhieuTra.MaKhachHang;
                txtTenKH_TraDia.Text = PhieuTra.TenKhachHang;
                dateTimePicker_NgayTraDia.Value = DateTime.Now;
                if (dateTimePicker_NgayPhaiTra.Value < dateTimePicker_NgayTraDia.Value)
                {
                    lblHienThiPhiPhat_TraDia.Text = Convert.ToDouble(PhieuTra.PhiPhat).ToString();
                    KiemTraTraDia = false;
                }
                else
                {
                    lblHienThiPhiPhat_TraDia.Text = "0";
                    KiemTraTraDia = true;
                }    
            }
            else
            {
                MessageBox.Show("Không tìm thấy đỉa thuê !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }

        }

        //private void btnTimMaDia_TraDia_Click(object sender, EventArgs e)
        //{
        //    MaDiaCD = txtMaDia_TraDia.Text;
        //    eLapPhieuTra PhieuTra = new eLapPhieuTra();
        //    PhieuTra = busLapPhieuTra.LayThongTinPhieuTra(MaDiaCD);
        //    if (PhieuTra != null)
        //    {
        //        MaPhieuThue = PhieuTra.MaPhieuThue;
        //        txtTenTieuDeDia_TraDia.Text = PhieuTra.TenTieuDe;
        //        txtLoaiDia_TraDia.Text = PhieuTra.LoaiDia;
        //        dateTimePicker_NgayThue_TraDia.Value = PhieuTra.NgayThueDia;
        //        dateTimePicker_NgayPhaiTra.Value = PhieuTra.NgayPhaiTra;
        //        txtMaKH_TraDia.Text = PhieuTra.MaKhachHang;
        //        txtTenKH_TraDia.Text = PhieuTra.TenKhachHang;
        //        dateTimePicker_NgayTraDia.Value = DateTime.Now;
        //        if (dateTimePicker_NgayPhaiTra.Value < dateTimePicker_NgayTraDia.Value)
        //        {
        //            lblHienThiPhiPhat_TraDia.Text = "5000";
        //            KiemTraTraDia = false;
        //        }
        //        else
        //        {
        //            lblHienThiPhiPhat_TraDia.Text = "0";
        //            KiemTraTraDia = true;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Không tìm thấy đỉa thuê !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        //    }
        //}

        private void btnTraDia_Click(object sender, EventArgs e)
        {
            if (txtMaDia_TraDia.Text.Equals("") || txtMaKH_TraDia.Text.Equals(""))
            {
                MessageBox.Show("Vui Lòng Nhập Mã Đỉa CD !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                eLapPhieuTra PhieuTra = new eLapPhieuTra();
                PhieuTra.MaPhieuThue = MaPhieuThue;
                PhieuTra.NgayTraDia = dateTimePicker_NgayTraDia.Value;
                PhieuTra.PhiPhat = Convert.ToDecimal(lblHienThiPhiPhat_TraDia.Text);
                PhieuTra.KiemTraPhiPhat = KiemTraTraDia;
                busLapPhieuTra.UpdateTongPhiPhatKhachHang(txtMaKH_TraDia.Text, PhieuTra.PhiPhat);
                busLapPhieuTra.UpdatePhieuThue(MaPhieuThue, PhieuTra);
                busLapPhieuTra.UpdateTrangThaiDia(MaDiaCD);

                ////////////////--Nguyễn Lê Ngân  Bình--///////////////////
                string maTieuDe = busDatDia.LayMaTieuDeBangTenTieuDe(txtTenTieuDeDia_TraDia.Text);
                busLapPhieuTra.tuDongGanDia(txtMaDia_TraDia.Text, maTieuDe);
                ////////////////--Nguyễn Lê Ngân  Bình--///////////////////
                MessageBox.Show("Ghi Nhận Trả Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                txtMaDia_TraDia.Clear();
                txtLoaiDia_TraDia.Clear();
                txtTenTieuDeDia_TraDia.Clear();
                txtMaKH_TraDia.Clear();
                txtTenKH_TraDia.Clear();
                dateTimePicker_NgayPhaiTra.Value = DateTime.Now;
                dateTimePicker_NgayThue_TraDia.Value = DateTime.Now;
                dateTimePicker_NgayTraDia.Value = DateTime.Now;
                lblHienThiPhiPhat_TraDia.Text = "0";
            }
        }
    }
}
