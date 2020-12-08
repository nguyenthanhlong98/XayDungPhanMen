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
    public partial class frmThongKe : Form
    {

        BusThongKe thongKeController;
        List<eKhachHang> dsKH;
        List<eTieuDe> dsTieuDe;
        dynamic dsTongDia;
        dynamic dsDiaQuaHan;
        dynamic dsTieuDeDiaTrong;
        dynamic dsTieuDeDiaCho;
        dynamic dsTieuDeDiaThue;
        dynamic dsTieuDeDatTruoc;
        dynamic dsPhiPhatDangNo;
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            thongKeController = new BusThongKe();
            dsKH = new List<eKhachHang>();
            dsTieuDe = new List<eTieuDe>();
            loadDSTieuDe();
            loadDSTieuDeDiaTrong();
            loadDSTieuDeDiaCho();
            loadDSTieuDeDiaThue();
            loadDSTieuDeDatTruoc();

            LoadDSKhachHangAll();
            LoadDSTongDiaThueKhachHangAll();
            LoadDSDiaQuaHanALL();
            LoadDSPhiPhatDangNoALL();
        }

        // format danh sách thông tin khách hàng
        private void formatDatagridviewDSKhachHang()
        {
            dgrDSTTKhachHang.Columns["maKhachHang"].HeaderText = "Mã khách hàng";
            dgrDSTTKhachHang.Columns["maKhachHang"].Width = 150;
            dgrDSTTKhachHang.Columns["maKhachHang"].ReadOnly = true;
            dgrDSTTKhachHang.Columns["tenKH"].HeaderText = "Tên khách hàng";
            dgrDSTTKhachHang.Columns["tenKH"].Width = 150;
            dgrDSTTKhachHang.Columns["tenKH"].ReadOnly = true;
            dgrDSTTKhachHang.Columns["diaChi"].HeaderText = "Địa chỉ";
            dgrDSTTKhachHang.Columns["diaChi"].Width = 250;
            dgrDSTTKhachHang.Columns["diaChi"].ReadOnly = true;
            dgrDSTTKhachHang.Columns["soDienThoai"].HeaderText = "Số điện thoại";
            dgrDSTTKhachHang.Columns["soDienThoai"].Width = 150;
            dgrDSTTKhachHang.Columns["soDienThoai"].ReadOnly = true;
            dgrDSTTKhachHang.Columns["phiPhat"].HeaderText = "Phí phạt";
            dgrDSTTKhachHang.Columns["phiPhat"].Width = 100;
            dgrDSTTKhachHang.Columns["phiPhat"].ReadOnly = true;
            dgrDSTTKhachHang.Columns["phiPhat"].Visible = false;
        }

        // format danh sách tổng đĩa của khách hàng thuê
        private void formatDatagridviewDSKhachHangCoTongDiaThue()
        {
            dgrDSTongDiaKHThue.Columns["maKhachHang"].HeaderText = "Mã khách hàng";
            dgrDSTongDiaKHThue.Columns["maKhachHang"].Width = 150;
            dgrDSTongDiaKHThue.Columns["maKhachHang"].ReadOnly = true;
            dgrDSTongDiaKHThue.Columns["soLuong"].HeaderText = "Số lượng";
            dgrDSTongDiaKHThue.Columns["soLuong"].Width = 150;
            dgrDSTongDiaKHThue.Columns["soLuong"].ReadOnly = true;
        }

        // format danh sách thông tin đĩa quá hạn
        private void formatDatagridviewDSTTDiaQuaHan()
        {
            dgrDSTTDiaQuaHan.Columns["maDiaCD"].HeaderText = "Mã đĩa CD";
            dgrDSTTDiaQuaHan.Columns["maDiaCD"].Width = 150;
            dgrDSTTDiaQuaHan.Columns["maDiaCD"].ReadOnly = true;
            dgrDSTTDiaQuaHan.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            dgrDSTTDiaQuaHan.Columns["tenTieuDe"].Width = 200;
            dgrDSTTDiaQuaHan.Columns["tenTieuDe"].ReadOnly = true;
            dgrDSTTDiaQuaHan.Columns["tinhTrangDia"].HeaderText = "Tình trạng đĩa";
            dgrDSTTDiaQuaHan.Columns["tinhTrangDia"].Width = 150;
            dgrDSTTDiaQuaHan.Columns["tinhTrangDia"].ReadOnly = true;
            dgrDSTTDiaQuaHan.Columns["ngayPhaiTra"].HeaderText = "Ngày phải trả";
            dgrDSTTDiaQuaHan.Columns["ngayPhaiTra"].Width = 150;
            dgrDSTTDiaQuaHan.Columns["ngayPhaiTra"].ReadOnly = true;
            dgrDSTTDiaQuaHan.Columns["ngayTraDia"].HeaderText = "Ngày trả đĩa";
            dgrDSTTDiaQuaHan.Columns["ngayTraDia"].Width = 150;
            dgrDSTTDiaQuaHan.Columns["ngayTraDia"].ReadOnly = true;
        }

        // format danh sách tiền phạt hiện đang nợ
        private void formatDatagridviewDSTienPhatDangNo()
        {
            dgrDSTTTienPhatDangNo.Columns["maKhachHang"].HeaderText = "Mã khách hàng";
            dgrDSTTTienPhatDangNo.Columns["maKhachHang"].Width = 150;
            dgrDSTTTienPhatDangNo.Columns["maKhachHang"].ReadOnly = true;
            dgrDSTTTienPhatDangNo.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            dgrDSTTTienPhatDangNo.Columns["tenTieuDe"].Width = 200;
            dgrDSTTTienPhatDangNo.Columns["tenTieuDe"].ReadOnly = true;
            dgrDSTTTienPhatDangNo.Columns["ngayPhaiTra"].HeaderText = "Ngày phải trả";
            dgrDSTTTienPhatDangNo.Columns["ngayPhaiTra"].Width = 150;
            dgrDSTTTienPhatDangNo.Columns["ngayPhaiTra"].ReadOnly = true;
            dgrDSTTTienPhatDangNo.Columns["ngayTraDia"].HeaderText = "Ngày trả đĩa";
            dgrDSTTTienPhatDangNo.Columns["ngayTraDia"].Width = 150;
            dgrDSTTTienPhatDangNo.Columns["ngayTraDia"].ReadOnly = true;
            dgrDSTTTienPhatDangNo.Columns["phiPhat"].HeaderText = "Phí phạt";
            dgrDSTTTienPhatDangNo.Columns["phiPhat"].Width = 150;
            dgrDSTTTienPhatDangNo.Columns["phiPhat"].ReadOnly = true;
        }

        //Load DS Khách hàng
        private void LoadDSKhachHangAll()
        {
            dgrDSTTKhachHang.DataSource = null;
            dgrDSTTKhachHang.Rows.Clear();
            dsKH = thongKeController.layDSKhachHang();
            dgrDSTTKhachHang.DataSource = dsKH;
            formatDatagridviewDSKhachHang();
        }

        //Load DS Khách hàng thuê đĩa bị trễ hạn
        private void LoadDSKhachHangTreHanThueDia()
        {
            dgrDSTTKhachHang.DataSource = null;
            dgrDSTTKhachHang.Rows.Clear();
            dsKH = thongKeController.layDSKhachHangTreHanThueDia();
            dgrDSTTKhachHang.DataSource = dsKH;
            formatDatagridviewDSKhachHang();
        }

        //Load DS Khách hàng có phí phạt
        private void LoadDSKhachHangCoPhiPhat()
        {
            dgrDSTTKhachHang.DataSource = null;
            dgrDSTTKhachHang.Rows.Clear();
            dsKH = thongKeController.layDSKhachHangCoPhiPhat();
            dgrDSTTKhachHang.DataSource = dsKH;
            formatDatagridviewDSKhachHang();
        }

        //Load DS Tổng đĩa thuê của Khách hàng
        private void LoadDSTongDiaThueKhachHangAll()
        {
            dgrDSTongDiaKHThue.DataSource = null;
            dgrDSTongDiaKHThue.Rows.Clear();
            dsTongDia = thongKeController.layDSTongDiaKHDangThue1();
            dgrDSTongDiaKHThue.DataSource = dsTongDia;
            formatDatagridviewDSKhachHangCoTongDiaThue();
        }

        //Load DS Tổng đĩa thuê của Khách hàng trễ hạn
        private void LoadDSTongDiaThueKhachHangTreHan()
        {
            dgrDSTongDiaKHThue.DataSource = null;
            dgrDSTongDiaKHThue.Rows.Clear();
            dsTongDia = thongKeController.layDSTongDiaKHDangThue2();
            dgrDSTongDiaKHThue.DataSource = dsTongDia;
            formatDatagridviewDSKhachHangCoTongDiaThue();
        }

        //Load DS Tổng đĩa thuê của Khách hàng có phí phạt
        private void LoadDSTongDiaThueKhachHangPhiPhat()
        {
            dgrDSTongDiaKHThue.DataSource = null;
            dgrDSTongDiaKHThue.Rows.Clear();
            dsTongDia = thongKeController.layDSTongDiaKHDangThue3();
            dgrDSTongDiaKHThue.DataSource = dsTongDia;
            formatDatagridviewDSKhachHangCoTongDiaThue();
        }


        //Load DS Đĩa quá hạn ALL
        private void LoadDSDiaQuaHanALL()
        {
            dgrDSTTDiaQuaHan.DataSource = null;
            dgrDSTTDiaQuaHan.Rows.Clear();
            dsDiaQuaHan = thongKeController.layDSDiaBiQuaHan();
            dgrDSTTDiaQuaHan.DataSource = dsDiaQuaHan;
            formatDatagridviewDSTTDiaQuaHan();
        }

        //Load DS Đĩa quá hạn Tr64 hạn
        private void LoadDSDiaQuaHanTreHan()
        {
            dgrDSTTDiaQuaHan.DataSource = null;
            dgrDSTTDiaQuaHan.Rows.Clear();
            dsDiaQuaHan = thongKeController.layDSDiaBiQuaHan2();
            dgrDSTTDiaQuaHan.DataSource = dsDiaQuaHan;
            formatDatagridviewDSTTDiaQuaHan();
        }

        //Load DS Đĩa quá hạn Phí phạt
        private void LoadDSDiaQuaHanPhiPhat()
        {
            dgrDSTTDiaQuaHan.DataSource = null;
            dgrDSTTDiaQuaHan.Rows.Clear();
            dsDiaQuaHan = thongKeController.layDSDiaBiQuaHan3();
            dgrDSTTDiaQuaHan.DataSource = dsDiaQuaHan;
            formatDatagridviewDSTTDiaQuaHan();
        }

        //Load DS Tiền phạt đang nợ ALL
        private void LoadDSPhiPhatDangNoALL()
        {
            dgrDSTTTienPhatDangNo.DataSource = null;
            dgrDSTTTienPhatDangNo.Rows.Clear();
            dsPhiPhatDangNo = thongKeController.LayDSTienPhatNo1();
            dgrDSTTTienPhatDangNo.DataSource = dsPhiPhatDangNo;
            formatDatagridviewDSTienPhatDangNo();
        }

        //Load DS Tiền phạt đang nợ Trễ hạn
        private void LoadDSPhiPhatDangNoTreHan()
        {
            dgrDSTTTienPhatDangNo.DataSource = null;
            dgrDSTTTienPhatDangNo.Rows.Clear();
            dsPhiPhatDangNo = thongKeController.LayDSTienPhatNo2();
            dgrDSTTTienPhatDangNo.DataSource = dsPhiPhatDangNo;
            formatDatagridviewDSTienPhatDangNo();
        }

        //Load DS Tiền phạt đang nợ phí phạt
        private void LoadDSPhiPhatDangNoPhiPhat()
        {
            dgrDSTTTienPhatDangNo.DataSource = null;
            dgrDSTTTienPhatDangNo.Rows.Clear();
            dsPhiPhatDangNo = thongKeController.LayDSTienPhatNo3();
            dgrDSTTTienPhatDangNo.DataSource = dsPhiPhatDangNo;
            formatDatagridviewDSTienPhatDangNo();
        }

        //Radio tất cả khách hàng
        private void rdTatCaKH_CheckedChanged(object sender, EventArgs e)
        {
            LoadDSKhachHangAll();
            LoadDSTongDiaThueKhachHangAll();
            LoadDSDiaQuaHanALL();
            LoadDSPhiPhatDangNoALL();
        }

        //Radio khách hàng trễ hạn (đang thuê đĩa)
        private void rdKHTreHan_CheckedChanged(object sender, EventArgs e)
        {
            LoadDSKhachHangTreHanThueDia();
            LoadDSTongDiaThueKhachHangTreHan();
            LoadDSDiaQuaHanTreHan();
            LoadDSPhiPhatDangNoTreHan();
        }

        //Radio khách hàng có phí phạt
        private void rdKHCoPhiPhat_CheckedChanged(object sender, EventArgs e)
        {
            LoadDSKhachHangCoPhiPhat();
            LoadDSTongDiaThueKhachHangPhiPhat();
            LoadDSDiaQuaHanPhiPhat();
            LoadDSPhiPhatDangNoPhiPhat();
        }





        // format danh sách tiêu đề
        private void formatDatagridviewDSTieuDe()
        {
            dgrDSTieuDe.Columns["maTieuDe"].HeaderText = "Mã tiêu đề";
            dgrDSTieuDe.Columns["maTieuDe"].Width = 150;
            dgrDSTieuDe.Columns["maTieuDe"].ReadOnly = true;
            dgrDSTieuDe.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            dgrDSTieuDe.Columns["tenTieuDe"].Width = 200;
            dgrDSTieuDe.Columns["tenTieuDe"].ReadOnly = true;
            dgrDSTieuDe.Columns["moTa"].HeaderText = "Mô tả";
            dgrDSTieuDe.Columns["moTa"].Width = 350;
            dgrDSTieuDe.Columns["moTa"].ReadOnly = true;
            dgrDSTieuDe.Columns["maLoai"].HeaderText = "Mã loại";
            dgrDSTieuDe.Columns["maLoai"].Width = 150;
            dgrDSTieuDe.Columns["maLoai"].ReadOnly = true;
        }


        // format danh sách tiêu đề có trạng thái đĩa trống
        private void formatDatagridviewDSTieuDeDiaTrong()
        {
            dgrDSTieuDeTrangThaiDiaTrong.Columns["maTieuDe"].HeaderText = "Mã tiêu đề";
            dgrDSTieuDeTrangThaiDiaTrong.Columns["maTieuDe"].Width = 150;
            dgrDSTieuDeTrangThaiDiaTrong.Columns["maTieuDe"].ReadOnly = true;
            dgrDSTieuDeTrangThaiDiaTrong.Columns["soLuongDiaTrong"].HeaderText = "Số lượng đĩa trống";
            dgrDSTieuDeTrangThaiDiaTrong.Columns["soLuongDiaTrong"].Width = 150;
            dgrDSTieuDeTrangThaiDiaTrong.Columns["soLuongDiaTrong"].ReadOnly = true;
        }

        // format danh sách tiêu đề có trạng thái đĩa chờ
        private void formatDatagridviewDSTieuDeDiaCho()
        {
            dgrDSTieuDeTrangThaiDiaCho.Columns["maTieuDe"].HeaderText = "Mã tiêu đề";
            dgrDSTieuDeTrangThaiDiaCho.Columns["maTieuDe"].Width = 150;
            dgrDSTieuDeTrangThaiDiaCho.Columns["maTieuDe"].ReadOnly = true;
            dgrDSTieuDeTrangThaiDiaCho.Columns["soLuongDiaCho"].HeaderText = "Số lượng đĩa chờ";
            dgrDSTieuDeTrangThaiDiaCho.Columns["soLuongDiaCho"].Width = 150;
            dgrDSTieuDeTrangThaiDiaCho.Columns["soLuongDiaCho"].ReadOnly = true;
        }

        // format danh sách tiêu đề có trạng thái đĩa thuê
        private void formatDatagridviewDSTieuDeDiaThue()
        {
            dgrDSTieuDeTrangThaiDiaThue.Columns["maTieuDe"].HeaderText = "Mã tiêu đề";
            dgrDSTieuDeTrangThaiDiaThue.Columns["maTieuDe"].Width = 150;
            dgrDSTieuDeTrangThaiDiaThue.Columns["maTieuDe"].ReadOnly = true;
            dgrDSTieuDeTrangThaiDiaThue.Columns["soLuongDiaThue"].HeaderText = "Số lượng đĩa thuê";
            dgrDSTieuDeTrangThaiDiaThue.Columns["soLuongDiaThue"].Width = 150;
            dgrDSTieuDeTrangThaiDiaThue.Columns["soLuongDiaThue"].ReadOnly = true;
        }

        // format danh sách tiêu đề đặt trước
        private void formatDatagridviewDSTieuDeDatTruoc()
        {
            dgrDSTieuDeCoSLDatTruoc.Columns["maTieuDe"].HeaderText = "Mã tiêu đề";
            dgrDSTieuDeCoSLDatTruoc.Columns["maTieuDe"].Width = 150;
            dgrDSTieuDeCoSLDatTruoc.Columns["maTieuDe"].ReadOnly = true;
            dgrDSTieuDeCoSLDatTruoc.Columns["soLuongDatTruoc"].HeaderText = "Số lượng đặt trước";
            dgrDSTieuDeCoSLDatTruoc.Columns["soLuongDatTruoc"].Width = 150;
            dgrDSTieuDeCoSLDatTruoc.Columns["soLuongDatTruoc"].ReadOnly = true;
        }
        //Load ds tiêu đề
        private void loadDSTieuDe()
        {
            dgrDSTieuDe.DataSource = null;
            dgrDSTieuDe.Rows.Clear();
            dsTieuDe = thongKeController.layDSTieuDe();
            dgrDSTieuDe.DataSource = dsTieuDe;
            formatDatagridviewDSTieuDe();
        }

        //Load ds tiêu đề trạng thái trống
        private void loadDSTieuDeDiaTrong()
        {
            dgrDSTieuDeTrangThaiDiaTrong.DataSource = null;
            dgrDSTieuDeTrangThaiDiaTrong.Rows.Clear();
            dsTieuDeDiaTrong = thongKeController.layDSTieuDeDiaTrong();
            dgrDSTieuDeTrangThaiDiaTrong.DataSource = dsTieuDeDiaTrong;
            formatDatagridviewDSTieuDeDiaTrong();
        }
        //Load ds tiêu đề trạng thái chờ
        private void loadDSTieuDeDiaCho()
        {
            dgrDSTieuDeTrangThaiDiaCho.DataSource = null;
            dgrDSTieuDeTrangThaiDiaCho.Rows.Clear();
            dsTieuDeDiaCho = thongKeController.layDSTieuDeDiaCho();
            dgrDSTieuDeTrangThaiDiaCho.DataSource = dsTieuDeDiaCho;
            formatDatagridviewDSTieuDeDiaCho();
        }
        //Load ds tiêu đề trạng thái thuê
        private void loadDSTieuDeDiaThue()
        {
            dgrDSTieuDeTrangThaiDiaThue.DataSource = null;
            dgrDSTieuDeTrangThaiDiaThue.Rows.Clear();
            dsTieuDeDiaThue = thongKeController.layDSTieuDeDiaThue();
            dgrDSTieuDeTrangThaiDiaThue.DataSource = dsTieuDeDiaThue;
            formatDatagridviewDSTieuDeDiaThue();
        }

        //Load ds tiêu đề đặt trước
        private void loadDSTieuDeDatTruoc()
        {
            dgrDSTieuDeCoSLDatTruoc.DataSource = null;
            dgrDSTieuDeCoSLDatTruoc.Rows.Clear();
            dsTieuDeDatTruoc = thongKeController.layDSTieuDeDatTruoc();
            dgrDSTieuDeCoSLDatTruoc.DataSource = dsTieuDeDatTruoc;
            formatDatagridviewDSTieuDeDatTruoc();
        }
    }
}
