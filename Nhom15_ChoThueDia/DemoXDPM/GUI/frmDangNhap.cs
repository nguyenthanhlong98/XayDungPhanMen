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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap(int x)
        {
            InitializeComponent();
            int check = x;
            if (check == 0)
            {
                frmFlashScreen fFlashScreen = new frmFlashScreen();
                fFlashScreen.ShowDialog();
            }
            else if (check == 1)
            {

            }
        }

        private void picShutdown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmMenuQuanLy rmQUly = new frmMenuQuanLy();
            rmQUly.Show();
            this.Hide();
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            frmMenuNhanVien rmNhanVien = new frmMenuNhanVien();
            rmNhanVien.Show();
            this.Hide();
        }
    }
}
