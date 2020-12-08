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
    public partial class frmBaoCao : Form
    {
        private List<eTieuDe> dsTieuDe;
        private BusBaoCao busBaoCao;
        private List<eDiaCD> dsDia;
        private eTieuDeDuocChon tieuDe;
        private string maTieuDe;
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            busBaoCao = new BusBaoCao();
            dsTieuDe = new List<eTieuDe>();
            dsDia = new List<eDiaCD>();
            tieuDe = new eTieuDeDuocChon();
            dgrDSDiaCoSanDeThue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Load danh sách tiêu đề lên combobox
            dsTieuDe = busBaoCao.LayDSTieuDe();
            cboTenTieuDeBaoCao.DataSource = dsTieuDe;
            cboTenTieuDeBaoCao.DisplayMember = "TenTieuDe";
            cboTenTieuDeBaoCao.ValueMember = "MaTieuDe";

            //Lấy mã tiêu đề
            maTieuDe = cboTenTieuDeBaoCao.SelectedValue.ToString();

            //Gọi hàm Autocomplete cho combobox,textbox
            autoCompleteData();

            //Load danh sách đĩa lên gridview
            loadDSDia();

            //Load lên textbox
            tieuDe = busBaoCao.LayTieuDeDuocChon(maTieuDe);
            loadDataVaoTextbox();

            if (dgrDSDiaCoSanDeThue.Rows.Count > 0)
            {
                txtTrangThai.Text = "Còn hàng";
            }
            else
            {
                txtTrangThai.Text = "Hết hàng";
            }
        }

        private void autoCompleteData()
        {
            //Autocomplete theo tiêu đề cho combobox
            cboTenTieuDeBaoCao.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboTenTieuDeBaoCao.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTenTieuDeBaoCao.AutoCompleteCustomSource.Clear();
            foreach (eTieuDe item in dsTieuDe)
            {
                cboTenTieuDeBaoCao.AutoCompleteCustomSource.Add(item.TenTieuDe);
            }
        }

        // format danh sách đĩa
        private void formatDatagridviewDSDia()
        {
            dgrDSDiaCoSanDeThue.Columns["maDiaCD"].HeaderText = "Mã đĩa CD";
            dgrDSDiaCoSanDeThue.Columns["maDiaCD"].Width = 150;
            dgrDSDiaCoSanDeThue.Columns["maDiaCD"].ReadOnly = true;
            dgrDSDiaCoSanDeThue.Columns["tinhTrang"].HeaderText = "Tình trạng đĩa";
            dgrDSDiaCoSanDeThue.Columns["tinhTrang"].Width = 150;
            dgrDSDiaCoSanDeThue.Columns["tinhTrang"].ReadOnly = true;
            dgrDSDiaCoSanDeThue.Columns["maTieuDe"].HeaderText = "Mã tiêu đề";
            dgrDSDiaCoSanDeThue.Columns["maTieuDe"].Width = 150;
            dgrDSDiaCoSanDeThue.Columns["maTieuDe"].ReadOnly = true;
        }

        private void cboTenTieuDeBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenTieuDeBaoCao.SelectedIndex >= 0)
            {
                maTieuDe = cboTenTieuDeBaoCao.SelectedValue.ToString();
                loadDSDia();
                tieuDe = busBaoCao.LayTieuDeDuocChon(maTieuDe);
                loadDataVaoTextbox();
                if (dgrDSDiaCoSanDeThue.Rows.Count > 0)
                {
                    txtTrangThai.Text = "Còn hàng";
                }
                else
                {
                    txtTrangThai.Text = "Hết hàng";
                }
            }
            else
            {
                MessageBox.Show("Tiêu đề không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Load lại danh sách đĩa cho grid view
        private void loadDSDia()
        {
            //Load lên grid view danh sách đĩa
            dgrDSDiaCoSanDeThue.DataSource = null;
            dgrDSDiaCoSanDeThue.Rows.Clear();
            dsDia = busBaoCao.LayDSDiaBangMaTieuDe(maTieuDe);
            dgrDSDiaCoSanDeThue.DataSource = dsDia;
            formatDatagridviewDSDia();
        }

        //Khi rời combobox
        private void cboTenTieuDeBaoCao_Leave(object sender, EventArgs e)
        {
            if (cboTenTieuDeBaoCao.Text.Equals("") || busBaoCao.KiemTraTieuDeTonTai(cboTenTieuDeBaoCao.Text)==false)
            {
                dgrDSDiaCoSanDeThue.DataSource = null;
                dgrDSDiaCoSanDeThue.Rows.Clear();
                dsDia.Clear();
                maTieuDe = "";
                tieuDe = busBaoCao.LayTieuDeDuocChon(maTieuDe);
                loadDataVaoTextbox();
                MessageBox.Show("Tiêu đề không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                maTieuDe = cboTenTieuDeBaoCao.SelectedValue.ToString();
                loadDSDia();
                tieuDe = busBaoCao.LayTieuDeDuocChon(maTieuDe);
                loadDataVaoTextbox();
                if (dgrDSDiaCoSanDeThue.Rows.Count > 0)
                {
                    txtTrangThai.Text = "Còn hàng";
                }
                else
                {
                    txtTrangThai.Text = "Hết hàng";
                }
            }
        }

        //Load lên text box
        private void loadDataVaoTextbox()
        {
            if (tieuDe != null)
            {
                txtMaTieuDe.Text = tieuDe.MaTieuDe;
                txtTenTieuDe.Text = tieuDe.TenTieuDe;
                txtTenLoai.Text = tieuDe.TenLoai;
                txtMoTa.Text = tieuDe.MoTa;
            }
            else
            {
                txtMaTieuDe.Text = "";
                txtTenTieuDe.Text = "";
                txtTenLoai.Text = "";
                txtMoTa.Text = "";
                txtTrangThai.Text = "";
            }
        }
    }
}
