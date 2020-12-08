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
    public partial class frmChiTietPhiPhat : Form
    {
        BusXemChiTietPhiPhat busXemChiTietPhiPhat;
        List<eChiTietPhiPhat> lsChiTietPhiPhat;
        string maKHTam = "";
        decimal TongTienThanhToanTungPhan = 0;
        decimal TongTienThanhToanHet = 0;
        int kiemtraCheckTT = 0;
        public frmChiTietPhiPhat()
        {
            InitializeComponent();

            busXemChiTietPhiPhat = new BusXemChiTietPhiPhat();
            lsChiTietPhiPhat = new List<eChiTietPhiPhat>();
        }
        static public class DanhSachPhieuThue
        {
            static public List<eChonPhiPhatToiLapPhieuThue> dsPhieuThue = new List<eChonPhiPhatToiLapPhieuThue>();
            static public int flag_DanhSachPhieuThue=0;
        }
        private void frmChiTietPhiPhat_Load(object sender, EventArgs e)
        {
            HienthiDataGridView(dataGridView_ChiTietPhiPhat, maKHTam);
            FormatLaiDataGridViewPhiPhat(dataGridView_ChiTietPhiPhat);
            if (frmLapPhieuThue.MaKHLapPhieuThue.flag_LapPhieuThue == 1)
            {
                btnThanhToanPhiPhat.Text = "Chọn Phí Thanh Toán";
            }else
            {
                btnThanhToanPhiPhat.Text = "Thanh Toán";
            }    
            txtMaKhachHangPhiPhat.Text = frmLapPhieuThue.MaKHLapPhieuThue.MaKH;

        }
        public void HienthiDataGridView(DataGridView dgv, string maKH)
        {
            lsChiTietPhiPhat = busXemChiTietPhiPhat.GetAllPhiPhatTheoMaKH(maKH);
            dataGridView_ChiTietPhiPhat.DataSource = lsChiTietPhiPhat;
        }
        void FormatLaiDataGridViewPhiPhat(DataGridView dgv)
        {
            dataGridView_ChiTietPhiPhat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["cbThanhToan"].DisplayIndex = 0;
            dgv.Columns["MaPhieuThue"].DisplayIndex = 1;
            dgv.Columns["MaDiaCD"].DisplayIndex = 2;
            dgv.Columns["TenTieuDe"].DisplayIndex = 3;
            dgv.Columns["TenLoai"].DisplayIndex = 4;
            dgv.Columns["NgayThueDia"].DisplayIndex = 5;
            dgv.Columns["NgayPhaiTra"].DisplayIndex = 6;
            dgv.Columns["NgayTraDia"].DisplayIndex = 7;
            dgv.Columns["PhiPhat"].DisplayIndex = 8;
            dgv.Columns["cbThanhToan"].Width = 100;
            dgv.Columns["TenTieuDe"].Width = 350;
            //  dgv.Columns["TenDT"].DisplayIndex = 1;
            //  dgv.Columns["SLuongNhap"].HeaderText

            //--------------------------------------------
            dgv.Columns["MaPhieuThue"].HeaderText = "Mã Phiếu Thuê";
            dgv.Columns["MaDiaCD"].HeaderText = "Mã Đỉa CD";
            dgv.Columns["TenTieuDe"].HeaderText = "Tên Tiêu Đề Dĩa";
            dgv.Columns["TenLoai"].HeaderText = "Loại Đỉa";
            dgv.Columns["NgayThueDia"].HeaderText = "Ngày Thuê";
            dgv.Columns["NgayPhaiTra"].HeaderText = "Ngày Phải Trả";
            dgv.Columns["NgayTraDia"].HeaderText = "Ngày Trả Đĩa";
            dgv.Columns["PhiPhat"].HeaderText = "Phí";

        }
        private void txtMaKhachHangPhiPhat_Leave(object sender, EventArgs e)
        {
            maKHTam = txtMaKhachHangPhiPhat.Text;
            eKhachHang khachHang = busXemChiTietPhiPhat.LayThongTinKhachHang(maKHTam);
            if (khachHang != null)
            {
                txtMaKhachHangPhiPhat.Text = khachHang.MaKhachHang;
                txtTenKhachPhiPhat.Text = khachHang.TenKH;
                dateTimePicker_NgayThanhToan_PhiPhat.Value = DateTime.Now;
                HienthiDataGridView(dataGridView_ChiTietPhiPhat, maKHTam);
                FormatLaiDataGridViewPhiPhat(dataGridView_ChiTietPhiPhat);
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Chính Xác Mã Khách Hàng !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnThanhToanPhiPhat_Click(object sender, EventArgs e)
        {

            if (dataGridView_ChiTietPhiPhat.Rows.Count <= 0)
            {
                MessageBox.Show("Khách Hàng Không Có Phí Phạt !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                return;
            }
            if (checkBox_ThanhToanTungPhan.Checked == false && checkBox_ThanhToanHet.Checked == false)
            {
                MessageBox.Show("Vui Lòng Chọn Loại Thanh Toán !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                return;
            }
            if (frmLapPhieuThue.MaKHLapPhieuThue.flag_LapPhieuThue == 1)
            {
                frmLapPhieuThue.MaKHLapPhieuThue.flag_LapPhieuThue = 0;
                frmChiTietPhiPhat.DanhSachPhieuThue.dsPhieuThue.Clear();
                if (kiemtraCheckTT == 0)
                {
                    bool s = false;                
                    for (int i = 0; i <= dataGridView_ChiTietPhiPhat.Rows.Count - 1; i++)
                    {                     
                        s = Convert.ToBoolean(dataGridView_ChiTietPhiPhat.Rows[i].Cells["cbThanhToan"].Value);
                        if (s == true)
                        {
                            eChonPhiPhatToiLapPhieuThue chon = new eChonPhiPhatToiLapPhieuThue();
                            string maPhieuThue = dataGridView_ChiTietPhiPhat.Rows[i].Cells["MaPhieuThue"].Value.ToString();
                            chon.MaPhieuThue = maPhieuThue;
                            chon.PhiPhat = Convert.ToDecimal(dataGridView_ChiTietPhiPhat.Rows[i].Cells["PhiPhat"].Value);
                            frmChiTietPhiPhat.DanhSachPhieuThue.dsPhieuThue.Add(chon);
                        }
                    }
                    MessageBox.Show("Chọn Thành Công !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    DanhSachPhieuThue.flag_DanhSachPhieuThue = 1;
                    this.Close();
                }
                else if (kiemtraCheckTT == 1)
                {
                    for (int i = 0; i <= dataGridView_ChiTietPhiPhat.Rows.Count - 1; i++)
                    {
                        eChonPhiPhatToiLapPhieuThue chon = new eChonPhiPhatToiLapPhieuThue();
                        string maPhieuThue = dataGridView_ChiTietPhiPhat.Rows[i].Cells["MaPhieuThue"].Value.ToString();
                        chon.MaPhieuThue = maPhieuThue;
                        chon.PhiPhat = Convert.ToDecimal(dataGridView_ChiTietPhiPhat.Rows[i].Cells["PhiPhat"].Value);
                        frmChiTietPhiPhat.DanhSachPhieuThue.dsPhieuThue.Add(chon);
                    }
                    MessageBox.Show("Chọn Thành Công !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    this.Close();
                    DanhSachPhieuThue.flag_DanhSachPhieuThue = 1;
                    kiemtraCheckTT = 0;

                }

            }
            else
            {
                if (kiemtraCheckTT == 0)
                {
                    bool s = false;
                    decimal PhiPhat = 0;
                    frmChiTietPhiPhat.DanhSachPhieuThue.dsPhieuThue.Clear();
                    for (int i = 0; i <= dataGridView_ChiTietPhiPhat.Rows.Count - 1; i++)
                    {
                        s = Convert.ToBoolean(dataGridView_ChiTietPhiPhat.Rows[i].Cells["cbThanhToan"].Value);
                        if (s == true)
                        {

                            string maPhieuThue = dataGridView_ChiTietPhiPhat.Rows[i].Cells["MaPhieuThue"].Value.ToString();
                            busXemChiTietPhiPhat.UpdatePhiPhatPhieuThue(maPhieuThue);
                            PhiPhat = Convert.ToDecimal(dataGridView_ChiTietPhiPhat.Rows[i].Cells["PhiPhat"].Value);
                            busXemChiTietPhiPhat.UpdateTongPhiPhatKhachHang(maKHTam, PhiPhat);
                        }
                    }
                    MessageBox.Show("Thanh Toán Thành Công !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    HienthiDataGridView(dataGridView_ChiTietPhiPhat, maKHTam);
                    FormatLaiDataGridViewPhiPhat(dataGridView_ChiTietPhiPhat);
                    checkBox_ThanhToanHet.Checked = false;
                    checkBox_ThanhToanTungPhan.Checked = false;
                    txtMaKhachHangPhiPhat.Clear();
                    txtTenKhachPhiPhat.Clear();
                    lblHienThiTongTienPhiPhat.Text = "0";
                }
                else if (kiemtraCheckTT == 1)
                {
                    decimal PhiPhat = 0;
                    for (int i = 0; i <= dataGridView_ChiTietPhiPhat.Rows.Count - 1; i++)
                    {
                        string maPhieuThue = dataGridView_ChiTietPhiPhat.Rows[i].Cells["MaPhieuThue"].Value.ToString();
                        busXemChiTietPhiPhat.UpdatePhiPhatPhieuThue(maPhieuThue);
                        PhiPhat = Convert.ToDecimal(dataGridView_ChiTietPhiPhat.Rows[i].Cells["PhiPhat"].Value);
                        busXemChiTietPhiPhat.UpdateTongPhiPhatKhachHang(maKHTam, PhiPhat);
                    }
                    MessageBox.Show("Thanh Toán Thành Công !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    kiemtraCheckTT = 0;
                    HienthiDataGridView(dataGridView_ChiTietPhiPhat, maKHTam);
                    FormatLaiDataGridViewPhiPhat(dataGridView_ChiTietPhiPhat);
                    checkBox_ThanhToanHet.Checked = false;
                    checkBox_ThanhToanTungPhan.Checked = false;
                    txtMaKhachHangPhiPhat.Clear();
                    txtTenKhachPhiPhat.Clear();
                    lblHienThiTongTienPhiPhat.Text = "0";
                }
            }
        }
        private void checkBox_ThanhToanTungPhan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ThanhToanTungPhan.Checked == true)
            {
                TongTienThanhToanTungPhan = 0;
                bool s = true;
                for (int i = 0; i <= dataGridView_ChiTietPhiPhat.Rows.Count - 1; i++)
                {
                    s = Convert.ToBoolean(dataGridView_ChiTietPhiPhat.Rows[i].Cells["cbThanhToan"].Value);
                    if (s == true)
                    {
                        TongTienThanhToanTungPhan += Convert.ToDecimal(dataGridView_ChiTietPhiPhat.Rows[i].Cells["PhiPhat"].Value);
                    }

                }
                if (TongTienThanhToanTungPhan == 0)
                {
                    MessageBox.Show("Vui Lòng Chọn Phí Phạt !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    checkBox_ThanhToanTungPhan.Checked = false;
                    return;
                }
                lblHienThiTongTienPhiPhat.Text = Convert.ToDouble(TongTienThanhToanTungPhan).ToString();
                checkBox_ThanhToanHet.Enabled = false;
            }
            else
            {
                checkBox_ThanhToanHet.Enabled = true;
                TongTienThanhToanTungPhan = 0;
                lblHienThiTongTienPhiPhat.Text = TongTienThanhToanHet.ToString();
            }
        }
        private void checkBox_ThanhToanHet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ThanhToanHet.Checked == true)
            {
                kiemtraCheckTT = 1;
                TongTienThanhToanHet = 0;
                for (int i = 0; i <= dataGridView_ChiTietPhiPhat.Rows.Count - 1; i++)
                {
                    TongTienThanhToanHet += Convert.ToDecimal(dataGridView_ChiTietPhiPhat.Rows[i].Cells["PhiPhat"].Value);
                }
                checkBox_ThanhToanTungPhan.Enabled = false;
                lblHienThiTongTienPhiPhat.Text = Convert.ToDouble(TongTienThanhToanHet).ToString();
            }
            else
            {
                checkBox_ThanhToanTungPhan.Enabled = true;
                kiemtraCheckTT = 0;
                TongTienThanhToanHet = 0;
                lblHienThiTongTienPhiPhat.Text = TongTienThanhToanHet.ToString();
            }

        }
        private void dataGridView_ChiTietPhiPhat_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            TongTienThanhToanTungPhan = 0;
            bool s = true;
            for (int i = 0; i <= dataGridView_ChiTietPhiPhat.Rows.Count - 1; i++)
            {
                s = Convert.ToBoolean(dataGridView_ChiTietPhiPhat.Rows[i].Cells["cbThanhToan"].Value);
                if (s == true)
                {
                    TongTienThanhToanTungPhan += Convert.ToDecimal(dataGridView_ChiTietPhiPhat.Rows[i].Cells["PhiPhat"].Value);
                }

            }
        }
        private void frmChiTietPhiPhat_MouseHover(object sender, EventArgs e)
        {

        }

        private void frmChiTietPhiPhat_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void frmChiTietPhiPhat_Move(object sender, EventArgs e)
        {

        }

        private void dataGridView_ChiTietPhiPhat_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

        }

        private void dataGridView_ChiTietPhiPhat_MouseLeave(object sender, EventArgs e)
        {
            decimal TongTienThanhToanTungPhan = 0;
            bool s = true;
            for (int i = 0; i <= dataGridView_ChiTietPhiPhat.Rows.Count - 1; i++)
            {
                s = Convert.ToBoolean(dataGridView_ChiTietPhiPhat.Rows[i].Cells["cbThanhToan"].Value);
                if (s == true)
                {
                    TongTienThanhToanTungPhan += Convert.ToDecimal(dataGridView_ChiTietPhiPhat.Rows[i].Cells["PhiPhat"].Value);
                }

            }
        }

        private void dataGridView_ChiTietPhiPhat_MouseHover(object sender, EventArgs e)
        {
            decimal TongTienThanhToanTungPhan = 0;
            bool s = true;
            for (int i = 0; i <= dataGridView_ChiTietPhiPhat.Rows.Count - 1; i++)
            {
                s = Convert.ToBoolean(dataGridView_ChiTietPhiPhat.Rows[i].Cells["cbThanhToan"].Value);
                if (s == true)
                {
                    TongTienThanhToanTungPhan += Convert.ToDecimal(dataGridView_ChiTietPhiPhat.Rows[i].Cells["PhiPhat"].Value);
                }

            }
        }

    }
}
