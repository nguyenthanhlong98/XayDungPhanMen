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
    public partial class frmMenuQuanLy : Form
    {
        public frmMenuQuanLy()
        {
            InitializeComponent();
        }

        private void frmMenuQuanLy_Load(object sender, EventArgs e)
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

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap fDangNhap = new frmDangNhap(1);
            fDangNhap.Show();
            this.Hide();
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

        private void quanLyTieuDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //----!Đóng tất cả form con đang hiện ----
            foreach (Form f in MdiChildren)
            {
                if (f.ShowInTaskbar)
                {
                    f.Close();
                }
            }
            if (kiemTraTrungForm("frmQLTieuDe"))
            {
                frmQLTieuDe fQLTieuDe = new frmQLTieuDe();
                fQLTieuDe.Name = "frmQLTieuDe";
                fQLTieuDe.MdiParent = this;
                fQLTieuDe.Show();
            }
        }

        private void quanLyDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //----!Đóng tất cả form con đang hiện ----
            foreach (Form f in MdiChildren)
            {
                if (f.ShowInTaskbar)
                {
                    f.Close();
                }
            }
            if (kiemTraTrungForm("frmQLDia"))
            {
                frmQLDia fQLDia = new frmQLDia();
                fQLDia.Name = "frmQLDia";
                fQLDia.MdiParent = this;
                fQLDia.Show();
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

        private void thongKeThuNhapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //----!Đóng tất cả form con đang hiện ----
            foreach (Form f in MdiChildren)
            {
                if (f.ShowInTaskbar)
                {
                    f.Close();
                }
            }
            if (kiemTraTrungForm("frmThongKe"))
            {
                frmThongKe fThongKe = new frmThongKe();
                fThongKe.Name = "frmThongKe";
                fThongKe.MdiParent = this;
                fThongKe.Show();
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

        private void xóaPhíPhạtToolStripMenuItem_Click(object sender, EventArgs e)
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
                frmXoaPhiPhat fXoaPhiPhat = new frmXoaPhiPhat();
                fXoaPhiPhat.Name = "frmXoaPhiPhat";
                fXoaPhiPhat.MdiParent = this;
                fXoaPhiPhat.Show();
            }
        }
    }
}
