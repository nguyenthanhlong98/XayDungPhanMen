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
    public partial class frmXoaPhiPhat : Form
    {
        List<eKhachHang> lsKH;
        BusXemChiTietPhiPhat busXemChiTietPhiPhat;
        List<eChiTietPhiPhat> lsChiTietPhiPhat;
        decimal TongTienThanhToanTungPhan = 0;
        decimal TongTienThanhToanHet = 0;
        int kiemtraCheckTT = 0;
        string maKHTam = "";
        public frmXoaPhiPhat()
        {
            InitializeComponent();
            lsKH = new List<eKhachHang>();
            busXemChiTietPhiPhat = new BusXemChiTietPhiPhat();
            lsChiTietPhiPhat = new List<eChiTietPhiPhat>();
        }

        private void frmXoaPhiPhat_Load(object sender, EventArgs e)
        {
            lsKH = busXemChiTietPhiPhat.getALLKhachHang();
            LoadDataKhachHangTreeView(treeViewXoaPhiPhat, lsKH);
        }
        public void LoadDataKhachHangTreeView(TreeView tre, List<eKhachHang> lskh)
        {
            tre.Nodes.Clear();
            foreach (eKhachHang ph in lskh)
            {
                TreeNode n = new TreeNode(ph.TenKH);
                n.Tag = ph.MaKhachHang;
                tre.Nodes.Add(n);
            }
        }

        private void treeViewXoaPhiPhat_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strMaKH = "";
            List<eChiTietPhiPhat> lsChiTietPhiPhat = new List<eChiTietPhiPhat>();
            if (treeViewXoaPhiPhat.SelectedNode != null)
            {
                strMaKH = treeViewXoaPhiPhat.SelectedNode.Tag.ToString();
                maKHTam = strMaKH;
                lsChiTietPhiPhat = busXemChiTietPhiPhat.GetAllPhiPhatTheoMaKH(strMaKH);
                dataGridView_ChiTietPhiPhat.DataSource = lsChiTietPhiPhat;
                FormatLaiDataGridViewPhiPhat(dataGridView_ChiTietPhiPhat);
            }
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
            dgv.Columns["cbThanhToan"].Width = 75;
            dgv.Columns["TenTieuDe"].Width = 300;
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
            dgv.Columns["PhiPhat"].HeaderText = "Phí Phạt";

        }

        private void checkBox_ThanhToanTungPhan_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_ThanhToanTungPhan.Checked == true)
            {
                if (treeViewXoaPhiPhat.SelectedNode == null)
                {
                    checkBox_ThanhToanTungPhan.Checked = false;
                    MessageBox.Show("Vui Lòng Chọn Khách Hàng !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    return;
                }
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
                if (treeViewXoaPhiPhat.SelectedNode == null)
                {
                    checkBox_ThanhToanHet.Checked = false;
                    MessageBox.Show("Vui Lòng Chọn Khách Hàng !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    return;
                }
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

        private void btnXoaPhiPhat_Click(object sender, EventArgs e)
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
            if (kiemtraCheckTT == 0)
            {
                bool s = false;
                decimal PhiPhat = 0;
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
                MessageBox.Show("Xóa Thành Công !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                string strMaKH = maKHTam;
                List<eChiTietPhiPhat> lsChiTietPhiPhat = new List<eChiTietPhiPhat>();
                strMaKH = treeViewXoaPhiPhat.SelectedNode.Tag.ToString();
                lsChiTietPhiPhat = busXemChiTietPhiPhat.GetAllPhiPhatTheoMaKH(maKHTam);
                dataGridView_ChiTietPhiPhat.DataSource = lsChiTietPhiPhat;
                FormatLaiDataGridViewPhiPhat(dataGridView_ChiTietPhiPhat);

                checkBox_ThanhToanHet.Checked = false;
                checkBox_ThanhToanTungPhan.Checked = false;
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
                MessageBox.Show("Xóa Thành Công !.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                kiemtraCheckTT = 0;

                string strMaKH = maKHTam;
                List<eChiTietPhiPhat> lsChiTietPhiPhat = new List<eChiTietPhiPhat>();
                strMaKH = treeViewXoaPhiPhat.SelectedNode.Tag.ToString();
                lsChiTietPhiPhat = busXemChiTietPhiPhat.GetAllPhiPhatTheoMaKH(maKHTam);
                dataGridView_ChiTietPhiPhat.DataSource = lsChiTietPhiPhat;
                FormatLaiDataGridViewPhiPhat(dataGridView_ChiTietPhiPhat);

                checkBox_ThanhToanHet.Checked = false;
                checkBox_ThanhToanTungPhan.Checked = false;
                lblHienThiTongTienPhiPhat.Text = "0";
            }
        }

        private void dataGridView_ChiTietPhiPhat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
