using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMenuNhanVien : Form
    {
        public frmMenuNhanVien()
        {
            InitializeComponent();
        }

        private void frmMenuNhanVien_Load(object sender, EventArgs e)
        {

        }
        public bool kiemTraTrungForm(string tenForm)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.Name.Equals(tenForm))
                {
                    return false;
                }
            }
            return true;
        }

        private void lapPhieuThueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //----!Đóng tất cả form con đang hiện ----
            foreach (Form f in MdiChildren)
            {
                if (f.ShowInTaskbar)
                {
                    f.Close();
                }
            }
            if (kiemTraTrungForm("frmLapPhieuThue"))
            {
                frmLapPhieuThue fLapPhieuThue = new frmLapPhieuThue();
                fLapPhieuThue.Name = "frmLapPhieuThue";
                fLapPhieuThue.MdiParent = this;
                fLapPhieuThue.Show();
            }
        }

        private void traDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //----!Đóng tất cả form con đang hiện ----
            foreach (Form f in MdiChildren)
            {
                if (f.ShowInTaskbar)
                {
                    f.Close();
                }
            }
            if (kiemTraTrungForm("frmTraDia"))
            {
                frmTraDia fTraDia = new frmTraDia();
                fTraDia.Name = "frmTraDia";
                fTraDia.MdiParent = this;
                fTraDia.Show();
            }
        }

        private void quanLyKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //----!Đóng tất cả form con đang hiện ----
            foreach (Form f in MdiChildren)
            {
                if (f.ShowInTaskbar)
                {
                    f.Close();
                }
            }
            if (kiemTraTrungForm("frmQLKhachHang"))
            {
                frmQLKhachHang fQLKhachHang = new frmQLKhachHang();
                fQLKhachHang.Name = "frmQLKhachHang";
                fQLKhachHang.MdiParent = this;
                fQLKhachHang.Show();
            }
        }

        private void quanLyDatDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //----!Đóng tất cả form con đang hiện ----
            foreach (Form f in MdiChildren)
            {
                if (f.ShowInTaskbar)
                {
                    f.Close();
                }
            }
            if (kiemTraTrungForm("frmQLDatDia"))
            {
                frmQLDatDia fQLDatDia = new frmQLDatDia();
                fQLDatDia.Name = "frmQLDatDia";
                fQLDatDia.MdiParent = this;
                fQLDatDia.Show();
            }
        }

        private void baoCaoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //----!Đóng tất cả form con đang hiện ----
            foreach (Form f in MdiChildren)
            {
                if (f.ShowInTaskbar)
                {
                    f.Close();
                }
            }
            if (kiemTraTrungForm("frmBaoCao"))
            {
                frmBaoCao fBaoCao = new frmBaoCao();
                fBaoCao.Name = "frmThongKe";
                fBaoCao.MdiParent = this;
                fBaoCao.Show();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thanhToánPhíPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //----!Đóng tất cả form con đang hiện ----
            foreach (Form f in MdiChildren)
            {
                if (f.ShowInTaskbar)
                {
                    f.Close();
                }
            }
            if (kiemTraTrungForm("frmChiTietPhiPhat"))
            {
                frmChiTietPhiPhat fBaoCao = new frmChiTietPhiPhat();
                fBaoCao.Name = "frmChiTietPhiPhat";
                fBaoCao.MdiParent = this;
                fBaoCao.Show();
            }
        }

        private void trởLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap fDangNhap = new frmDangNhap(1);
            fDangNhap.Show();
            this.Hide();
        }
    }
}
