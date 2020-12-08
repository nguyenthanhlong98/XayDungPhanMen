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
    public partial class frmQLDatDia : Form
    {
        BusDatDia datDiaController;
        eKhachHang khachHang;
        List<eDanhSachHangDoi> dsHangDoi;
        eTieuDeDuocChon tieuDeDuocChon;
        List<eTieuDeComboBox> dsTieuDe;
        List<eTieuDeDuocChon> dsTieuDeDuocChon = null;
        List<eKhachHang> dsKhachHang;
        List<eDanhSachHangDoi> dsHangDoiCuaKhachHang;
        string maKhachHang;
        public frmQLDatDia()
        {
            InitializeComponent();
        }

        private void frmQLDatDia_Load(object sender, EventArgs e)
        {
            datDiaController = new BusDatDia();
            dsHangDoi = new List<eDanhSachHangDoi>();
            dsTieuDeDuocChon = new List<eTieuDeDuocChon>();
            dsHangDoiCuaKhachHang = new List<eDanhSachHangDoi>();

            //String.Format("{0:ddMMyyyy}", dtpNgayLap.Value)
            //Mặc định
            txtMaDat.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(datDiaController.LayDanhSachHangDoi()));
            txtNgayDat.Text = DateTime.Now.ToString();
            customLock();
            customLockHangDoiKhachHang();
            dgrDSTieuDe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgrDSDoiCuaKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Lấy danh sách khách hàng
            dsKhachHang = datDiaController.LayDanhSachKhachHang();

            //Load danh sách hàng đợi lên datagridview
            loadHangDoi();

            //Load danh sách tiêu đề lên combobox tiêu đề
            layDSTieuDeLoc();
        }

        //Load hàng chờ
        private void loadHangDoi()
        {
            dsHangDoi = datDiaController.LayDanhSachHangDoi();
            dgrDSHangDoi.DataSource = dsHangDoi;
            formatDatagridviewDSHangDoi();
        }

        //Hàm tự động tăng mã Đặt đĩa
        private int getMaDD_AuTo(List<eDanhSachHangDoi> dshd)
        {
            int max = 0;
            foreach (eDanhSachHangDoi item in dshd)
            {
                //Substring này lấy 4 kí tự cuối của chuỗi
                if (long.Parse(item.MaDatDia.Substring(item.MaDatDia.Length-4)) >= max)
                {
                    max = Int32.Parse(item.MaDatDia.Substring(item.MaDatDia.Length - 4));
                }
            }
            return max + 1;
        }

        //Xét hàng đơn vị,chục,trăm,nghìn
        private string kiemTraMaTuDong(int so)
        {
            if (so / 10 >=0  && so / 10 < 1) //số thuộc hàng đơn vị
            {
                return "000" + so;
            }
            else if (so/10>=1 && so/10 <10) //số thuộc hàng chục
            {
                return "00" + so;
            }
            else if ( so/10 >=10 && so/10 < 100) //số thuộc hàng trăm
            {
                return "0" + so;
            }
            else //số thuộc hàng nghìn
            {
                return "" + so;
            }
        }

        // format danh sách hàng đợi
        private void formatDatagridviewDSHangDoi()
        {
            dgrDSHangDoi.Columns["maDatDia"].HeaderText = "Mã đặt đĩa";
            dgrDSHangDoi.Columns["maDatDia"].Width = 100;
            dgrDSHangDoi.Columns["maDatDia"].ReadOnly = true;
            dgrDSHangDoi.Columns["maKhachHang"].HeaderText = "Mã khách hàng";
            dgrDSHangDoi.Columns["maKhachHang"].Width = 100;
            dgrDSHangDoi.Columns["maKhachHang"].ReadOnly = true;
            dgrDSHangDoi.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            dgrDSHangDoi.Columns["tenTieuDe"].Width = 250;
            dgrDSHangDoi.Columns["tenTieuDe"].ReadOnly = true;
            dgrDSHangDoi.Columns["ngayDatDia"].HeaderText = "Ngày đặt đĩa";
            dgrDSHangDoi.Columns["ngayDatDia"].Width = 150;
            dgrDSHangDoi.Columns["ngayDatDia"].ReadOnly = true;
            dgrDSHangDoi.Columns["maDiaTam"].HeaderText = "Mã đĩa tạm";
            dgrDSHangDoi.Columns["maDiaTam"].Width = 100;
            dgrDSHangDoi.Columns["maDiaTam"].ReadOnly = true;
        }

        // format danh sách tiêu đề được chọn
        private void formatDatagridviewDSTieuDe()
        {
            dgrDSTieuDe.Columns["maTieuDe"].HeaderText = "Mã tiêu đề";
            dgrDSTieuDe.Columns["maTieuDe"].Width = 100;
            dgrDSTieuDe.Columns["maTieuDe"].ReadOnly = true;
            dgrDSTieuDe.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            dgrDSTieuDe.Columns["tenTieuDe"].Width = 350;
            dgrDSTieuDe.Columns["tenTieuDe"].ReadOnly = true;
            dgrDSTieuDe.Columns["moTa"].HeaderText = "Mô tả";
            dgrDSTieuDe.Columns["moTa"].Width = 250;
            dgrDSTieuDe.Columns["moTa"].ReadOnly = true;
            dgrDSTieuDe.Columns["tenLoai"].HeaderText = "Tên loại";
            dgrDSTieuDe.Columns["tenLoai"].Width = 150;
            dgrDSTieuDe.Columns["tenLoai"].ReadOnly = true;
        }

        // format danh sách hàng đợi của 1 khách hàng
        private void formatDatagridviewDSHangDoiCua1KhachHang()
        {
            dgrDSDoiCuaKhachHang.Columns["maDatDia"].HeaderText = "Mã đặt đĩa";
            dgrDSDoiCuaKhachHang.Columns["maDatDia"].Width = 100;
            dgrDSDoiCuaKhachHang.Columns["maDatDia"].ReadOnly = true;
            dgrDSDoiCuaKhachHang.Columns["maKhachHang"].HeaderText = "Mã khách hàng";
            dgrDSDoiCuaKhachHang.Columns["maKhachHang"].Width = 150;
            dgrDSDoiCuaKhachHang.Columns["maKhachHang"].ReadOnly = true;
            dgrDSDoiCuaKhachHang.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            dgrDSDoiCuaKhachHang.Columns["tenTieuDe"].Width = 350;
            dgrDSDoiCuaKhachHang.Columns["tenTieuDe"].ReadOnly = true;
            dgrDSDoiCuaKhachHang.Columns["ngayDatDia"].HeaderText = "Ngày đặt đĩa";
            dgrDSDoiCuaKhachHang.Columns["ngayDatDia"].Width = 150;
            dgrDSDoiCuaKhachHang.Columns["ngayDatDia"].ReadOnly = true;
            dgrDSDoiCuaKhachHang.Columns["maDiaTam"].HeaderText = "Mã đĩa tạm";
            dgrDSDoiCuaKhachHang.Columns["maDiaTam"].Width = 150;
            dgrDSDoiCuaKhachHang.Columns["maDiaTam"].ReadOnly = true;
        }

        //Load danh sách tiêu đề lên gridview
        private void layDSTieuDe(List<eTieuDeDuocChon> dsTieuDeDuocChon)
        {
            dgrDSTieuDe.DataSource = null;
            dgrDSTieuDe.Rows.Clear();
            dgrDSTieuDe.DataSource = dsTieuDeDuocChon;
            formatDatagridviewDSTieuDe();
        }

        //Load danh sách hàng đợi lên gridview
        private void layDSHangDoi(List<eDanhSachHangDoi> dsHangDoi)
        {
            dgrDSHangDoi.DataSource = null;
            dgrDSHangDoi.Rows.Clear();
            dgrDSHangDoi.DataSource = dsHangDoi;
            formatDatagridviewDSHangDoi();
        }

        //Load danh sách hàng đợi của 1 khách hàng lên gridview
        private void layDSHangDoiCua1KhachHang(List<eDanhSachHangDoi> dsHangDoiCuaKhachHang)
        {
            dgrDSDoiCuaKhachHang.DataSource = null;
            dgrDSDoiCuaKhachHang.Rows.Clear();
            dgrDSDoiCuaKhachHang.DataSource = dsHangDoiCuaKhachHang;
            formatDatagridviewDSHangDoiCua1KhachHang();
        }
        private void autoCompleteData()
        {
            //Autocomplete theo tiêu đề cho combobox
            cboDSTieuDe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboDSTieuDe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDSTieuDe.AutoCompleteCustomSource.Clear();
            foreach (eTieuDeComboBox item in dsTieuDe)
            {
                cboDSTieuDe.AutoCompleteCustomSource.Add(item.TenTieuDe);
            }

            //Autocomplete theo khách hàng cho textbox Mã khách hàng
            txtMaKH.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtMaKH.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMaKH.AutoCompleteCustomSource.Clear();
            foreach (eKhachHang item in dsKhachHang)
            {
                txtMaKH.AutoCompleteCustomSource.Add(item.MaKhachHang);
            }

            //Autocomplete theo khách hàng cho textbox Tìm kiếm khách đặt
            txtTimKiemKhachDat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTimKiemKhachDat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTimKiemKhachDat.AutoCompleteCustomSource.Clear();
            foreach (eKhachHang item in dsKhachHang)
            {
                txtTimKiemKhachDat.AutoCompleteCustomSource.Add(item.MaKhachHang);
            }
        }

        //Thêm 1 tiêu đề vào danh sách tiêu đề
        private void btnThemTieuDe_Click(object sender, EventArgs e)
        {
            maKhachHang = txtMaKH.Text;
            if (cboDSTieuDe.SelectedIndex >= 0 && datDiaController.KiemTraTonTaiKhachHang(maKhachHang) == true)
            {
                string maTieuDe = cboDSTieuDe.SelectedValue.ToString();
                //Lấy tiêu đề được chọn
                tieuDeDuocChon = datDiaController.LayTieuDeBangMaTieuDe(maTieuDe);
                string tenTieuDe = tieuDeDuocChon.TenTieuDe;
                if (datDiaController.KiemTraKhachHangTrongHangDoi(tenTieuDe, maKhachHang))
                {
                    if (kiemTraTrungTieuDe(dsTieuDeDuocChon, tieuDeDuocChon))
                    {
                        //Add tiêu đề vào danh sách
                        dsTieuDeDuocChon.Add(tieuDeDuocChon);
                        //Load danh sách lên gridview
                        layDSTieuDe(dsTieuDeDuocChon);
                        customOpen();
                    }
                    else
                    {
                        MessageBox.Show("Tiêu đề này đã được chọn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Khách hàng đã đặt trước tiêu đề này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Tiêu đề hoặc khách hàng không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Kiểm tra tiêu đề trong danh sách tiêu đề
        private Boolean kiemTraTrungTieuDe(List<eTieuDeDuocChon> ds, eTieuDeDuocChon tieuDe)
        {
            int check = 0;
            foreach (eTieuDeDuocChon item in ds)
            {
                if (item.MaTieuDe.Equals(tieuDe.MaTieuDe))
                {
                    check++;
                }
            }
            if (check == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Custom button,textbox
        private void customOpen()
        {
            btnDatDia.Enabled = true;
            btnXoaTieuDe.Enabled = true;
            btnClearTieuDe.Enabled = true;
            txtMaKH.Enabled = false;
        }
        private void customLock()
        {
            btnDatDia.Enabled = false;
            btnXoaTieuDe.Enabled = false;
            btnClearTieuDe.Enabled = false;
            txtMaKH.Enabled = true;
        }
        private void customOpenHangDoiKhachHang()
        {
           
            btnXoaHangDoiKhachHang.Enabled = true;
            btnClearHangDoiKhachHang.Enabled = true;
            txtTimKiemKhachDat.Enabled = false;
        }
        private void customLockHangDoiKhachHang()
        {
           
            btnXoaHangDoiKhachHang.Enabled = false;
            btnClearHangDoiKhachHang.Enabled = false;
            txtTimKiemKhachDat.Enabled = true;
            txtTimKiemKhachDat.Clear();
        }

        //Kiểm tra mã khách hàng
        private void txtMaKH_Leave(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được rỗng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                khachHang = datDiaController.LayKhachHangBangMa(txtMaKH.Text);
                if (khachHang != null)
                {
                    txtTenKhachHang.Text = khachHang.TenKH;
                    txtSoDienThoai.Text = khachHang.SoDienThoai;
                }
                else
                {
                    MessageBox.Show("Khách hàng này không tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Xóa hết danh sách tiêu đề đã chọn
        private void btnClearTieuDe_Click(object sender, EventArgs e)
        {
            dsTieuDeDuocChon.Clear();
            layDSTieuDe(dsTieuDeDuocChon);
            customLock();
        }

        
        //Xóa một tiêu đề đã chọn
        private void btnXoaTieuDe_Click(object sender, EventArgs e)
        {
            if (dgrDSTieuDe.SelectedRows.Count > 0)
            {
                //Xóa tiêu đề trong List tiêu đề được chọn
                dsTieuDeDuocChon.RemoveAt(dgrDSTieuDe.SelectedRows[0].Index);
                layDSTieuDe(dsTieuDeDuocChon);
            }
            if (dsTieuDeDuocChon.Count == 0)
            {
                customLock();
            }
        }

        

        //Chọn đặt dĩa
        private void btnDatDia_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dsTieuDeDuocChon.Count; i++)
            {
                eDanhSachHangDoi temp = new eDanhSachHangDoi();
                temp.MaDatDia = "DD" + kiemTraMaTuDong(getMaDD_AuTo(datDiaController.LayDanhSachHangDoi()));
                temp.MaKhachHang = txtMaKH.Text;
                temp.NgayDatDia =DateTime.Parse(txtNgayDat.Text);
                temp.TenTieuDe = dsTieuDeDuocChon.ElementAt(i).TenTieuDe;
                temp.MaDiaTam = null;
                datDiaController.themHangDoi(temp);
            }

            //Load lại gridview hàng đợi
            dsHangDoi = datDiaController.LayDanhSachHangDoi();
            this.layDSHangDoi(dsHangDoi);
            //Load lại gridview hàng đợi của khách hàng nếu có
            if (txtMaKH.Text.Equals(txtTimKiemKhachDat.Text))
            {
                dsHangDoiCuaKhachHang = datDiaController.LayDSHangDoiBangMaKhachHang(txtTimKiemKhachDat.Text);
                layDSHangDoiCua1KhachHang(dsHangDoiCuaKhachHang);
            }
            //Load lại mã Đặt đĩa và các textbox,button,girdview khác
            txtMaDat.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(datDiaController.LayDanhSachHangDoi()));
            txtNgayDat.Text = DateTime.Now.ToString();
            txtMaKH.Text = "";
            txtSoDienThoai.Text = "";
            txtTenKhachHang.Text = "";
            dsTieuDeDuocChon.Clear();
            layDSTieuDe(dsTieuDeDuocChon);
            customLock();
            MessageBox.Show("Đặt đĩa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Tìm kiếm khách hàng đã đặt đĩa
        private void btnTimKiemKhachDat_Click(object sender, EventArgs e)
        {
            if(btnTimKiemKhachDat.Text == "Tìm kiếm")  // Xử lý của Button có chữ tìm kiếm
            {
                if (txtTimKiemKhachDat.Text == "")
                {
                    customLockHangDoiKhachHang();
                    MessageBox.Show("Mã khách hàng không được rỗng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    eKhachHang khachHangDaDat = datDiaController.LayKhachHangBangMa(txtTimKiemKhachDat.Text);
                    if (khachHangDaDat != null)
                    {
                        //Load lên gridview danh sách đặt trước của khách hàng đó
                        dsHangDoiCuaKhachHang = datDiaController.LayDSHangDoiBangMaKhachHang(khachHangDaDat.MaKhachHang);
                        //Load danh sách hàng đợi của 1 khách hàng lên datagridview
                        layDSHangDoiCua1KhachHang(dsHangDoiCuaKhachHang);
                        //Custom
                        customOpenHangDoiKhachHang();
                        btnTimKiemKhachDat.Text = "Nhập mới";
                    }
                    else
                    {
                        customLockHangDoiKhachHang();
                        MessageBox.Show("Khách hàng này không tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (btnTimKiemKhachDat.Text == "Nhập mới")  // Xử lý của Button có chữ nhập mới
            {
                btnTimKiemKhachDat.Text = "Tìm kiếm";
                customLockHangDoiKhachHang();
                dgrDSDoiCuaKhachHang.DataSource = null;
                dgrDSDoiCuaKhachHang.Rows.Clear();
            }
            
        }

        

        //Xóa hết danh sách hàng đợi của khách hàng
        private void btnClearHangDoiKhachHang_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                int soLuong = dgrDSDoiCuaKhachHang.RowCount; //Lấy số dòng trong danh sách hàng đợi của 1 khách hàng
                string maDatDia;
                for (int i = 0; i < soLuong; i++)
                {
                    maDatDia = dgrDSDoiCuaKhachHang.Rows[i].Cells[0].Value.ToString(); //Lấy mã đặt đĩa của từng dòng
                    datDiaController.XoaHangDoiBangMaDatDia(maDatDia);
                }
                MessageBox.Show("Xóa thành công!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDat.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(datDiaController.LayDanhSachHangDoi()));
                dsHangDoiCuaKhachHang = datDiaController.LayDSHangDoiBangMaKhachHang(txtTimKiemKhachDat.Text);
                layDSHangDoiCua1KhachHang(dsHangDoiCuaKhachHang);
                loadHangDoi();
                layDSTieuDeLoc();
            }
        }

        //Xóa 1 hàng đợi của khách hàng
        private void btnXoaHangDoiKhachHang_Click_1(object sender, EventArgs e)
        {
            if (dgrDSDoiCuaKhachHang.SelectedRows.Count > 0)
            {
                DialogResult d;
                d = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    //Xóa hàng đợi trong List hàng đợi của khách hàng
                    string maDatDia = dgrDSDoiCuaKhachHang.SelectedRows[0].Cells[0].Value.ToString();
                    if (datDiaController.XoaHangDoiBangMaDatDia(maDatDia) == 1) //Trường hợp hàng đợi có đĩa chờ
                    {
                        dsHangDoiCuaKhachHang = datDiaController.LayDSHangDoiBangMaKhachHang(txtTimKiemKhachDat.Text);
                        MessageBox.Show("Xóa thành công!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else //Trường hợp không có hàng chờ
                    {
                        dsHangDoiCuaKhachHang = datDiaController.LayDSHangDoiBangMaKhachHang(txtTimKiemKhachDat.Text);
                        MessageBox.Show("Không có hàng chờ nào để xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtMaDat.Text = "DD" + kiemTraMaTuDong(getMaDD_AuTo(datDiaController.LayDanhSachHangDoi()));
                    layDSHangDoiCua1KhachHang(dsHangDoiCuaKhachHang);
                    loadHangDoi();
                    layDSTieuDeLoc();
                }
            }
            if(dsHangDoiCuaKhachHang.Count == 0)
            {
                btnTimKiemKhachDat.Text = "Tìm kiếm";
                customLockHangDoiKhachHang();
            }
        }

        //Load lại combobox
        private void layDSTieuDeLoc()
        {
            //Load danh sách tiêu đề lên combobox tiêu đề
            dsTieuDe = datDiaController.LayDanhSachTieuDe();
            cboDSTieuDe.DataSource = dsTieuDe;
            cboDSTieuDe.DisplayMember = "TenTieuDe";
            cboDSTieuDe.ValueMember = "MaTieuDe";

            //Gọi hàm Autocomplete cho combobox,textbox
            autoCompleteData();
        }
    }
}
