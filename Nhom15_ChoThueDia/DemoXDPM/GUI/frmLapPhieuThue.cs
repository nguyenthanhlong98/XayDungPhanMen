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
    public partial class frmLapPhieuThue : Form
    {
        string maDiaTam = "";
        int ThoiGianTam; // Lấy thời Thời gian thuê ở column trên datagridview
        string maDiaTam2 = "";
        int ThoiGianTam2; // Lấy thời Thời gian thuê ở column trên datagridview
        BusLapPhieuThue busLapPhieuThue;
        BusXemChiTietPhiPhat busXemChiTietPhiPhat;
        List<eTieuDe> lsTieuDe;
        List<eLapPhieuThue> lsMaPhieuThue;
        List<eHienThiDiaDeChon> lsDiaDeChon;
        List<eHienThiDiaDeChon> lsDatDiaCuaKH;
        double HienThiTongTien = 0;
        public frmLapPhieuThue()
        {
            InitializeComponent();
            busLapPhieuThue = new BusLapPhieuThue();
            lsDiaDeChon = new List<eHienThiDiaDeChon>();
            lsDatDiaCuaKH = new List<eHienThiDiaDeChon>();
            busXemChiTietPhiPhat = new BusXemChiTietPhiPhat();

        }
        static public class MaKHLapPhieuThue // Truyền giá trị từ Lập Phiếu Thuê -> Chi Tiết Phí Phạt
        {
            static public string MaKH; // Truyền Mã Khách Hàng
            static public int flag_LapPhieuThue; // Kiểm tra có chọn xem chi tiết không ?.
        }
        private void frmLapPhieuThue_Load(object sender, EventArgs e)
        {
            lsTieuDe = busLapPhieuThue.getALLTieuDeDia();
            LoadDataToComBoBox(comboBoxChonTieuDe, lsTieuDe);
            lsMaPhieuThue = busLapPhieuThue.getALLMaPhieuThue();
            dateTimePicker_NgayThue_LapPhieu.Value = DateTime.Now;
            lblHienThiTongTienPhieuThue.Text = HienThiTongTien.ToString();
            btnChiTietPhiPhat_PhieuThue.Enabled = false;
        }
        public void LoadDataToComBoBox(ComboBox cb, List<eTieuDe> lsTieuDe)
        {
            lsTieuDe = busLapPhieuThue.getALLTieuDeDia();
            cb.DisplayMember = "TenTieuDe"; // Tên Hiển Thị lên Combobox
            cb.ValueMember = "MaTieuDe"; // Giá trị lấy đi so sánh.
            cb.DataSource = lsTieuDe;
        }
        void FormatLaiDataGridViewChonDia(DataGridView dgv) // Format lại column DataGridview
        {
            dataGridView_ChonDiaCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_DsDiaDaChon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns["MaDiaCD"].DisplayIndex = 0;
            dgv.Columns["TenLoai"].DisplayIndex = 1;
            dgv.Columns["TinhTrang"].DisplayIndex = 2;
            dgv.Columns["ThoiGianThue"].DisplayIndex = 3;
            dgv.Columns["Gia"].DisplayIndex = 4;
            //--------------------------------------------
            dgv.Columns["MaDiaCD"].HeaderText = "Mã Đĩa CD";
            dgv.Columns["TenLoai"].HeaderText = "Loại";
            dgv.Columns["TinhTrang"].HeaderText = "Tình Trạng Đĩa";
            dgv.Columns["ThoiGianThue"].HeaderText = "Thời Gian Thuê/Ngày";
            dgv.Columns["Gia"].HeaderText = "Giá";

        }
        private void comboBoxChonTieuDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<eHienThiDiaDeChon> lsDiaDeChon_SauKhiSelect;
            string maTieuDe = "";
            if (comboBoxChonTieuDe.SelectedIndex >= 0)
            {
                maTieuDe = comboBoxChonTieuDe.SelectedValue.ToString();
                lsDiaDeChon_SauKhiSelect = busLapPhieuThue.getALLDiaDeChon(maTieuDe);
                dataGridView_ChonDiaCD.DataSource = lsDiaDeChon_SauKhiSelect;
                FormatLaiDataGridViewChonDia(dataGridView_ChonDiaCD);
                lsDiaDeChon = lsDiaDeChon_SauKhiSelect;
            }
        }

        private void btnChonDiaThue_Click(object sender, EventArgs e)
        {
            HienThiTongTien = 0; // Gán lại Tổng Tiền.
            string maKH = txtMaKhachHangPhieuThue.Text;
            eKhachHang kh = busLapPhieuThue.LayThongTinKhachHang(maKH); // Lấy Thông tin khách hàng từ TextBox và kiểm tra
            if (kh == null)
            {
                MessageBox.Show("Vui Lòng Nhập Khách Hàng !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                return;
            }
            if (dataGridView_ChonDiaCD.SelectedRows.Count <= 0 && dgrDSDatDiaCuaKhachHang.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                return;
            }
            //----Nguyễn Lê Ngân Bình ----//

            if (dataGridView_ChonDiaCD.SelectedRows.Count > 0 || dgrDSDatDiaCuaKhachHang.SelectedRows.Count > 0)
            {
                if (dataGridView_ChonDiaCD.SelectedRows.Count > 0)
                {
                    foreach (eHienThiDiaDeChon diachon in lsDiaDeChon)
                    {
                        if (diachon.MaDiaCD.Equals(maDiaTam))
                        {
                            DateTime dateTime = dateTimePicker_NgayThue_LapPhieu.Value.AddDays(ThoiGianTam); // Gia Hạn thời gian tối đa mượn đĩa (Thời Gian Tam lấy ở dataGridView_ChonDiaCD_RowStateChanged)
                            string s = String.Format("{0:MM/dd/yyyy}", dateTime); // Format lại ngày tháng để hiển thị
                            string[] row = new string[] { diachon.MaDiaCD, diachon.TenLoai, diachon.TinhTrang, diachon.ThoiGianThue.ToString(), Convert.ToString(diachon.Gia), s }; // Tạo Row trong Danh Sách Đĩa Đã Chọn
                            for (int i = 0; i < dataGridView_DsDiaDaChon.Rows.Count - 1; i++)
                            {
                                if (diachon.MaDiaCD.Equals(dataGridView_DsDiaDaChon.Rows[i].Cells["MaDiaCD"].Value)) // Kiểm tra đỉa CD đó đã được chọn bỏ vào Danh Sách Đĩa Đã chọn chưa ?
                                {
                                    MessageBox.Show("Bạn đã đĩa sản phẩm này !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                                    return;
                                }
                            }
                            dataGridView_DsDiaDaChon.Rows.Add(row);
                            for (int i = 0; i < dataGridView_DsDiaDaChon.Rows.Count - 1; i++) // Hiển Thị Tổng Tiền trên label
                            {
                                HienThiTongTien += Convert.ToDouble(dataGridView_DsDiaDaChon.Rows[i].Cells["Gia"].Value.ToString());
                            }
                            HienThiTongTien += PhiPhat;
                            lblHienThiTongTienPhieuThue.Text = HienThiTongTien.ToString();
                            txtMaKhachHangPhieuThue.Enabled = false;
                        }
                    }
                }
                if (dgrDSDatDiaCuaKhachHang.SelectedRows.Count > 0)
                {
                    foreach (eHienThiDiaDeChon diachon in lsDatDiaCuaKH)
                    {
                        if (diachon.MaDiaCD.Equals(maDiaTam2))
                        {
                            DateTime dateTime = dateTimePicker_NgayThue_LapPhieu.Value.AddDays(ThoiGianTam2); // Gia Hạn thời gian tối đa mượn đĩa (Thời Gian Tam lấy ở dataGridView_ChonDiaCD_RowStateChanged)
                            string s = String.Format("{0:MM/dd/yyyy}", dateTime); // Format lại ngày tháng để hiển thị
                            string[] row = new string[] { diachon.MaDiaCD, diachon.TenLoai, diachon.TinhTrang, diachon.ThoiGianThue.ToString(), Convert.ToString(diachon.Gia), s }; // Tạo Row trong Danh Sách Đĩa Đã Chọn
                            for (int i = 0; i < dataGridView_DsDiaDaChon.Rows.Count - 1; i++)
                            {
                                if (diachon.MaDiaCD.Equals(dataGridView_DsDiaDaChon.Rows[i].Cells["MaDiaCD"].Value)) // Kiểm tra đỉa CD đó đã được chọn bỏ vào Danh Sách Đĩa Đã chọn chưa ?
                                {
                                    MessageBox.Show("Bạn đã đĩa sản phẩm này !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                                    return;
                                }
                            }
                            dataGridView_DsDiaDaChon.Rows.Add(row);
                            for (int i = 0; i < dataGridView_DsDiaDaChon.Rows.Count - 1; i++) // Hiển Thị Tổng Tiền trên label
                            {
                                HienThiTongTien += Convert.ToDouble(dataGridView_DsDiaDaChon.Rows[i].Cells["Gia"].Value.ToString());
                            }
                            HienThiTongTien += PhiPhat;
                            lblHienThiTongTienPhieuThue.Text = HienThiTongTien.ToString();
                            txtMaKhachHangPhieuThue.Enabled = false;
                        }
                    }
                }
            }
        }

        private void btnXoaDiaPhieuThue_Click(object sender, EventArgs e) // Xóa Đĩa trong danh sách đĩa đã chọn
        {
            HienThiTongTien = 0;
            if (dataGridView_DsDiaDaChon.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView_DsDiaDaChon.CurrentCell.RowIndex;
                dataGridView_DsDiaDaChon.Rows.RemoveAt(rowIndex);
                for (int i = 0; i < dataGridView_DsDiaDaChon.Rows.Count - 1; i++)
                {
                    HienThiTongTien += Convert.ToDouble(dataGridView_DsDiaDaChon.Rows[i].Cells["Gia"].Value.ToString());
                }
                HienThiTongTien += PhiPhat;
                lblHienThiTongTienPhieuThue.Text = HienThiTongTien.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm xóa !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                return;
            }

            if (dataGridView_DsDiaDaChon.RowCount == 1)
            {
                txtMaKhachHangPhieuThue.Enabled = true;
            }
        }

        private void txtMaKhachHangPhieuThue_Leave(object sender, EventArgs e)
        {
            string maKH = txtMaKhachHangPhieuThue.Text;
            eKhachHang kh = busLapPhieuThue.LayThongTinKhachHang(maKH);
            if (kh != null)
            {
                layDSDatDiaCuaKH(txtMaKhachHangPhieuThue.Text);
                btnChiTietPhiPhat_PhieuThue.Enabled = true;
                txtTenKhachPhieuThue.Text = kh.TenKH;
                List<eChiTietPhiPhat> lsChiTietPhiPhat = new List<eChiTietPhiPhat>();
                lsChiTietPhiPhat = busXemChiTietPhiPhat.GetAllPhiPhatTheoMaKH(kh.MaKhachHang);
                double tt = 0;
                foreach(eChiTietPhiPhat tam in lsChiTietPhiPhat)
                {
                    tt += tam.PhiPhat;
                }    
                lblHienThiPhiPhat_PhieuThue.Text = Convert.ToDouble(tt).ToString();
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Mã Khách Hàng !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                btnChiTietPhiPhat_PhieuThue.Enabled = false;
                return;
            }
        }

        private void btnLapPhieuThue_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKhachHangPhieuThue.Text;
            eKhachHang kh = busLapPhieuThue.LayThongTinKhachHang(maKH); // Lấy Thông tin khách hàng từ TextBox và kiểm tra
            if (kh == null)
            {
                MessageBox.Show("Vui Lòng Nhập Mã Khách Hàng !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                return;
            }
            if (dataGridView_DsDiaDaChon.Rows.Count <= 1) // Kiểm tra Danh Sách Đĩa Đã chọn có sản phẩm chưa ?.
            {
                MessageBox.Show("Vui Lòng Chọn Đỉa CD !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                return;
            }
            int flag = 0; // Kiểm Tra Lập Hóa Đơn Có thành công không ?.
            for (int i = 0; i < dataGridView_DsDiaDaChon.Rows.Count - 1; i++) // Tiến hành lập các Phiếu các đĩa có trong danh sách đĩa đã chọn.
            {
                eLapPhieuThue newPhieuThue = new eLapPhieuThue();
                newPhieuThue.MaPhieuThue = "MP0001";
                lsMaPhieuThue = busLapPhieuThue.getALLMaPhieuThue();
                foreach (eLapPhieuThue tam in lsMaPhieuThue) // Phát sinh MP
                {
                    if (tam.MaPhieuThue.Equals(newPhieuThue.MaPhieuThue))
                    {
                        Random r = new Random();
                        string PhatSinhMa;
                        while (tam.MaPhieuThue == newPhieuThue.MaPhieuThue)
                        {
                            if (tam.MaPhieuThue.Equals(newPhieuThue.MaPhieuThue))
                            {
                                PhatSinhMa = "MP" + r.Next(0, 9999).ToString();
                                newPhieuThue.MaPhieuThue = PhatSinhMa;
                            }
                        }
                    }
                }
                newPhieuThue.MaKhachHang = txtMaKhachHangPhieuThue.Text;
                newPhieuThue.MaDiaCD = dataGridView_DsDiaDaChon.Rows[i].Cells["MaDiaCD"].Value.ToString();
                newPhieuThue.NgayThueDia = Convert.ToDateTime(dateTimePicker_NgayThue_LapPhieu.Value);
                newPhieuThue.GiaDiaThue = Convert.ToDecimal(dataGridView_DsDiaDaChon.Rows[i].Cells["Gia"].Value.ToString());
                newPhieuThue.NgayPhaiTra = Convert.ToDateTime(dataGridView_DsDiaDaChon.Rows[i].Cells["NgayPhaiTra"].Value.ToString());

                busLapPhieuThue.UpdateTrangThaiDia(newPhieuThue.MaDiaCD);
                int kq = busLapPhieuThue.LapPhieuThue(newPhieuThue);

                if (kq != 1)
                {
                    MessageBox.Show("Lập Phiếu Thuê Không Thành Công!.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {

                    //Nguyễn Lê Ngân Bình
                    //Xóa hàng đợi khi lập phiếu thuê có chứa đĩa chờ
                    string maDiaCD = dataGridView_DsDiaDaChon.Rows[i].Cells[0].Value.ToString();
                    string tinhTrangDia = dataGridView_DsDiaDaChon.Rows[i].Cells[2].Value.ToString();
                    if (tinhTrangDia.Equals("Đang Chờ"))
                    {
                        busLapPhieuThue.XoaHangDoiBangMaDatDia(maDiaCD);
                    }
                }
            }

            if (frmChiTietPhiPhat.DanhSachPhieuThue.flag_DanhSachPhieuThue == 1) // Có chọn phí ở form xem chi tiết phí phạt
            {
                List<eChonPhiPhatToiLapPhieuThue> dsPhieuThue = new List<eChonPhiPhatToiLapPhieuThue>();
                dsPhieuThue = frmChiTietPhiPhat.DanhSachPhieuThue.dsPhieuThue;
                for (int i = 0; i < dsPhieuThue.Count; i++)
                {
                    busXemChiTietPhiPhat.UpdatePhiPhatPhieuThue(dsPhieuThue[i].MaPhieuThue);
                    busXemChiTietPhiPhat.UpdateTongPhiPhatKhachHang(txtMaKhachHangPhieuThue.Text, dsPhieuThue[i].PhiPhat);
                }
                MessageBox.Show("Lập Phiếu Thuê Thành Công!.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                LoadDataToComBoBox(comboBoxChonTieuDe, lsTieuDe);
                dataGridView_DsDiaDaChon.Rows.Clear();
                txtMaKhachHangPhieuThue.Clear();
                txtTenKhachPhieuThue.Clear();
                lblHienThiPhiPhat_PhieuThue.Text = "0";
                lblHienThiTongTienPhieuThue.Text = "0";
                txtMaKhachHangPhieuThue.Enabled = true;
                lsDatDiaCuaKH.Clear();
                dgrDSDatDiaCuaKhachHang.DataSource = null;
                dgrDSDatDiaCuaKhachHang.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Lập Phiếu Thuê Thành Công!.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                LoadDataToComBoBox(comboBoxChonTieuDe, lsTieuDe);
                dataGridView_DsDiaDaChon.Rows.Clear();
                txtMaKhachHangPhieuThue.Clear();
                txtTenKhachPhieuThue.Clear();
                lblHienThiPhiPhat_PhieuThue.Text = "0";
                lblHienThiTongTienPhieuThue.Text = "0";
                lsDatDiaCuaKH.Clear();
                dgrDSDatDiaCuaKhachHang.DataSource = null;
                dgrDSDatDiaCuaKhachHang.Rows.Clear();
                txtMaKhachHangPhieuThue.Enabled = true;
            }

        }
        double PhiPhat = 0;
        private void lblHienThiPhiPhat_PhieuThue_Click(object sender, EventArgs e) // Click vào lblHienThiPhiPhat để cập nhập lại phí phạt sẽ thanh toán và tổng tiền.
        {
            if (frmChiTietPhiPhat.DanhSachPhieuThue.flag_DanhSachPhieuThue == 1)
            {
                PhiPhat = 0;
                HienThiTongTien = 0;
                List<eChonPhiPhatToiLapPhieuThue> dsPhieuThue = new List<eChonPhiPhatToiLapPhieuThue>();
                dsPhieuThue = frmChiTietPhiPhat.DanhSachPhieuThue.dsPhieuThue;
                for (int i = 0; i < dsPhieuThue.Count; i++)
                {
                    PhiPhat += Convert.ToDouble(dsPhieuThue[i].PhiPhat);
                }
                for (int i = 0; i < dataGridView_DsDiaDaChon.Rows.Count - 1; i++)
                {
                    HienThiTongTien += Convert.ToDouble(dataGridView_DsDiaDaChon.Rows[i].Cells["Gia"].Value.ToString());
                }
                HienThiTongTien += PhiPhat;
                lblHienThiPhiPhat_PhieuThue.Text = "Sẽ Thanh Toán:" + PhiPhat.ToString();
                lblHienThiTongTienPhieuThue.Text = HienThiTongTien.ToString();
            }
        }
        private void lblPhiPhatPhieuThue_Click(object sender, EventArgs e)
        {

        }
        private void btnChiTietPhiPhat_PhieuThue_Click(object sender, EventArgs e)
        {
            MaKHLapPhieuThue.MaKH = txtMaKhachHangPhieuThue.Text;
            MaKHLapPhieuThue.flag_LapPhieuThue = 1;
            frmChiTietPhiPhat frmChiTietPhiPhat = new frmChiTietPhiPhat();
            frmChiTietPhiPhat.ShowDialog();
        }

        private void frmLapPhieuThue_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void frmLapPhieuThue_MouseHover(object sender, EventArgs e)
        {

        }

        private void frmLapPhieuThue_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }



        //Nguyễn Lê Ngân Bình

        //Lấy danh sách đặt đĩa của  1  khách hàng và load  lên  gridview
        private void layDSDatDiaCuaKH(string maKhachHang)
        {
            lsDatDiaCuaKH.Clear();
            dgrDSDatDiaCuaKhachHang.DataSource = null;
            dgrDSDatDiaCuaKhachHang.Rows.Clear();
            lsDatDiaCuaKH = busLapPhieuThue.layDSDatDiaCuaKH(maKhachHang);
            dgrDSDatDiaCuaKhachHang.DataSource = lsDatDiaCuaKH;
            FormatLaiDataGridViewChonDia(dgrDSDatDiaCuaKhachHang);
        }



        private void dataGridView_ChonDiaCD_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView_ChonDiaCD.SelectedRows.Count > 0)
            {
                maDiaTam = Convert.ToString(e.Row.Cells["MaDiaCD"].Value); // Lấy Mã Đĩa để kiểm tra có chọn hay chưa ?          
                ThoiGianTam = Convert.ToInt32(Convert.ToString(e.Row.Cells["ThoiGianThue"].Value)); // Lấy Thời Gian Tối Đã thuê để công vào ngày Thuê Đĩa
            }
        }

        private void dgrDSDatDiaCuaKhachHang_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgrDSDatDiaCuaKhachHang.SelectedRows.Count > 0)
            {
                maDiaTam2 = Convert.ToString(e.Row.Cells["MaDiaCD"].Value); // Lấy Mã Đĩa để kiểm tra có chọn hay chưa ?          
                ThoiGianTam2 = Convert.ToInt32(Convert.ToString(e.Row.Cells["ThoiGianThue"].Value)); // Lấy Thời Gian Tối Đã thuê để công vào ngày Thuê Đĩa
            }
        }
    }
}
