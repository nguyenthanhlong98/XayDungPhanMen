namespace GUI
{
    partial class frmChiTietPhiPhat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTitle1_XemChiTietPhiPhat = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_ChiTietPhiPhat = new System.Windows.Forms.DataGridView();
            this.cbThanhToan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox_ThongTinKH = new System.Windows.Forms.GroupBox();
            this.lblNgayThanhToan_PhiPhat = new System.Windows.Forms.Label();
            this.dateTimePicker_NgayThanhToan_PhiPhat = new System.Windows.Forms.DateTimePicker();
            this.txtMaKhachHangPhiPhat = new System.Windows.Forms.TextBox();
            this.lblTenKhachHang_XemPhiPhat = new System.Windows.Forms.Label();
            this.txtTenKhachPhiPhat = new System.Windows.Forms.TextBox();
            this.lblMaKhachHang_XemPhiPhat = new System.Windows.Forms.Label();
            this.groupBox_ThanhToanPhiPhat = new System.Windows.Forms.GroupBox();
            this.checkBox_ThanhToanTungPhan = new System.Windows.Forms.CheckBox();
            this.checkBox_ThanhToanHet = new System.Windows.Forms.CheckBox();
            this.lblHienThiTongTienPhiPhat = new System.Windows.Forms.Label();
            this.lblTongTienPhiPhat = new System.Windows.Forms.Label();
            this.btnThanhToanPhiPhat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ChiTietPhiPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox_ThongTinKH.SuspendLayout();
            this.groupBox_ThanhToanPhiPhat.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblTitle1_XemChiTietPhiPhat);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1846, 756);
            this.splitContainer1.SplitterDistance = 77;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblTitle1_XemChiTietPhiPhat
            // 
            this.lblTitle1_XemChiTietPhiPhat.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle1_XemChiTietPhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1_XemChiTietPhiPhat.Location = new System.Drawing.Point(0, 0);
            this.lblTitle1_XemChiTietPhiPhat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle1_XemChiTietPhiPhat.Name = "lblTitle1_XemChiTietPhiPhat";
            this.lblTitle1_XemChiTietPhiPhat.Size = new System.Drawing.Size(1846, 53);
            this.lblTitle1_XemChiTietPhiPhat.TabIndex = 2;
            this.lblTitle1_XemChiTietPhiPhat.Text = "XEM CHI TIẾT PHÍ PHẠT";
            this.lblTitle1_XemChiTietPhiPhat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView_ChiTietPhiPhat);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1846, 674);
            this.splitContainer2.SplitterDistance = 344;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView_ChiTietPhiPhat
            // 
            this.dataGridView_ChiTietPhiPhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ChiTietPhiPhat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbThanhToan});
            this.dataGridView_ChiTietPhiPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ChiTietPhiPhat.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ChiTietPhiPhat.Name = "dataGridView_ChiTietPhiPhat";
            this.dataGridView_ChiTietPhiPhat.RowHeadersWidth = 51;
            this.dataGridView_ChiTietPhiPhat.Size = new System.Drawing.Size(1846, 344);
            this.dataGridView_ChiTietPhiPhat.TabIndex = 1;
            this.dataGridView_ChiTietPhiPhat.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ChiTietPhiPhat_CellLeave);
            this.dataGridView_ChiTietPhiPhat.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dataGridView_ChiTietPhiPhat_CellStateChanged);
            this.dataGridView_ChiTietPhiPhat.MouseLeave += new System.EventHandler(this.dataGridView_ChiTietPhiPhat_MouseLeave);
            this.dataGridView_ChiTietPhiPhat.MouseHover += new System.EventHandler(this.dataGridView_ChiTietPhiPhat_MouseHover);
            // 
            // cbThanhToan
            // 
            this.cbThanhToan.HeaderText = "Chọn";
            this.cbThanhToan.MinimumWidth = 6;
            this.cbThanhToan.Name = "cbThanhToan";
            this.cbThanhToan.Width = 75;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox_ThongTinKH);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox_ThanhToanPhiPhat);
            this.splitContainer3.Size = new System.Drawing.Size(1846, 325);
            this.splitContainer3.SplitterDistance = 877;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox_ThongTinKH
            // 
            this.groupBox_ThongTinKH.Controls.Add(this.lblNgayThanhToan_PhiPhat);
            this.groupBox_ThongTinKH.Controls.Add(this.dateTimePicker_NgayThanhToan_PhiPhat);
            this.groupBox_ThongTinKH.Controls.Add(this.txtMaKhachHangPhiPhat);
            this.groupBox_ThongTinKH.Controls.Add(this.lblTenKhachHang_XemPhiPhat);
            this.groupBox_ThongTinKH.Controls.Add(this.txtTenKhachPhiPhat);
            this.groupBox_ThongTinKH.Controls.Add(this.lblMaKhachHang_XemPhiPhat);
            this.groupBox_ThongTinKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_ThongTinKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ThongTinKH.Location = new System.Drawing.Point(0, 0);
            this.groupBox_ThongTinKH.Name = "groupBox_ThongTinKH";
            this.groupBox_ThongTinKH.Size = new System.Drawing.Size(877, 325);
            this.groupBox_ThongTinKH.TabIndex = 0;
            this.groupBox_ThongTinKH.TabStop = false;
            this.groupBox_ThongTinKH.Text = "Thông Tin Khách Hàng";
            // 
            // lblNgayThanhToan_PhiPhat
            // 
            this.lblNgayThanhToan_PhiPhat.AutoSize = true;
            this.lblNgayThanhToan_PhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayThanhToan_PhiPhat.Location = new System.Drawing.Point(44, 225);
            this.lblNgayThanhToan_PhiPhat.Name = "lblNgayThanhToan_PhiPhat";
            this.lblNgayThanhToan_PhiPhat.Size = new System.Drawing.Size(249, 32);
            this.lblNgayThanhToan_PhiPhat.TabIndex = 18;
            this.lblNgayThanhToan_PhiPhat.Text = "Ngày Thanh Toán:";
            // 
            // dateTimePicker_NgayThanhToan_PhiPhat
            // 
            this.dateTimePicker_NgayThanhToan_PhiPhat.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker_NgayThanhToan_PhiPhat.Enabled = false;
            this.dateTimePicker_NgayThanhToan_PhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_NgayThanhToan_PhiPhat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_NgayThanhToan_PhiPhat.Location = new System.Drawing.Point(351, 212);
            this.dateTimePicker_NgayThanhToan_PhiPhat.Name = "dateTimePicker_NgayThanhToan_PhiPhat";
            this.dateTimePicker_NgayThanhToan_PhiPhat.Size = new System.Drawing.Size(262, 45);
            this.dateTimePicker_NgayThanhToan_PhiPhat.TabIndex = 17;
            this.dateTimePicker_NgayThanhToan_PhiPhat.Value = new System.DateTime(2020, 11, 18, 0, 0, 0, 0);
            // 
            // txtMaKhachHangPhiPhat
            // 
            this.txtMaKhachHangPhiPhat.Location = new System.Drawing.Point(351, 77);
            this.txtMaKhachHangPhiPhat.Name = "txtMaKhachHangPhiPhat";
            this.txtMaKhachHangPhiPhat.Size = new System.Drawing.Size(262, 45);
            this.txtMaKhachHangPhiPhat.TabIndex = 16;
            this.txtMaKhachHangPhiPhat.Leave += new System.EventHandler(this.txtMaKhachHangPhiPhat_Leave);
            // 
            // lblTenKhachHang_XemPhiPhat
            // 
            this.lblTenKhachHang_XemPhiPhat.AutoSize = true;
            this.lblTenKhachHang_XemPhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKhachHang_XemPhiPhat.Location = new System.Drawing.Point(44, 150);
            this.lblTenKhachHang_XemPhiPhat.Name = "lblTenKhachHang_XemPhiPhat";
            this.lblTenKhachHang_XemPhiPhat.Size = new System.Drawing.Size(225, 31);
            this.lblTenKhachHang_XemPhiPhat.TabIndex = 15;
            this.lblTenKhachHang_XemPhiPhat.Text = "Tên Khách Hàng:";
            // 
            // txtTenKhachPhiPhat
            // 
            this.txtTenKhachPhiPhat.Location = new System.Drawing.Point(351, 141);
            this.txtTenKhachPhiPhat.Name = "txtTenKhachPhiPhat";
            this.txtTenKhachPhiPhat.ReadOnly = true;
            this.txtTenKhachPhiPhat.Size = new System.Drawing.Size(262, 45);
            this.txtTenKhachPhiPhat.TabIndex = 14;
            // 
            // lblMaKhachHang_XemPhiPhat
            // 
            this.lblMaKhachHang_XemPhiPhat.AutoSize = true;
            this.lblMaKhachHang_XemPhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKhachHang_XemPhiPhat.Location = new System.Drawing.Point(44, 86);
            this.lblMaKhachHang_XemPhiPhat.Name = "lblMaKhachHang_XemPhiPhat";
            this.lblMaKhachHang_XemPhiPhat.Size = new System.Drawing.Size(215, 31);
            this.lblMaKhachHang_XemPhiPhat.TabIndex = 13;
            this.lblMaKhachHang_XemPhiPhat.Text = "Mã Khách Hàng:";
            // 
            // groupBox_ThanhToanPhiPhat
            // 
            this.groupBox_ThanhToanPhiPhat.Controls.Add(this.checkBox_ThanhToanTungPhan);
            this.groupBox_ThanhToanPhiPhat.Controls.Add(this.checkBox_ThanhToanHet);
            this.groupBox_ThanhToanPhiPhat.Controls.Add(this.lblHienThiTongTienPhiPhat);
            this.groupBox_ThanhToanPhiPhat.Controls.Add(this.lblTongTienPhiPhat);
            this.groupBox_ThanhToanPhiPhat.Controls.Add(this.btnThanhToanPhiPhat);
            this.groupBox_ThanhToanPhiPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_ThanhToanPhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ThanhToanPhiPhat.Location = new System.Drawing.Point(0, 0);
            this.groupBox_ThanhToanPhiPhat.Name = "groupBox_ThanhToanPhiPhat";
            this.groupBox_ThanhToanPhiPhat.Size = new System.Drawing.Size(965, 325);
            this.groupBox_ThanhToanPhiPhat.TabIndex = 0;
            this.groupBox_ThanhToanPhiPhat.TabStop = false;
            this.groupBox_ThanhToanPhiPhat.Text = "Thông Tin Thanh Toán";
            // 
            // checkBox_ThanhToanTungPhan
            // 
            this.checkBox_ThanhToanTungPhan.AutoSize = true;
            this.checkBox_ThanhToanTungPhan.Location = new System.Drawing.Point(370, 80);
            this.checkBox_ThanhToanTungPhan.Name = "checkBox_ThanhToanTungPhan";
            this.checkBox_ThanhToanTungPhan.Size = new System.Drawing.Size(421, 42);
            this.checkBox_ThanhToanTungPhan.TabIndex = 7;
            this.checkBox_ThanhToanTungPhan.Text = "Thanh Toán Từng Khoản";
            this.checkBox_ThanhToanTungPhan.UseVisualStyleBackColor = true;
            this.checkBox_ThanhToanTungPhan.CheckedChanged += new System.EventHandler(this.checkBox_ThanhToanTungPhan_CheckedChanged);
            // 
            // checkBox_ThanhToanHet
            // 
            this.checkBox_ThanhToanHet.AutoSize = true;
            this.checkBox_ThanhToanHet.Location = new System.Drawing.Point(30, 79);
            this.checkBox_ThanhToanHet.Name = "checkBox_ThanhToanHet";
            this.checkBox_ThanhToanHet.Size = new System.Drawing.Size(288, 42);
            this.checkBox_ThanhToanHet.TabIndex = 6;
            this.checkBox_ThanhToanHet.Text = "Thanh Toán Hết";
            this.checkBox_ThanhToanHet.UseVisualStyleBackColor = true;
            this.checkBox_ThanhToanHet.CheckedChanged += new System.EventHandler(this.checkBox_ThanhToanHet_CheckedChanged);
            // 
            // lblHienThiTongTienPhiPhat
            // 
            this.lblHienThiTongTienPhiPhat.AutoSize = true;
            this.lblHienThiTongTienPhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHienThiTongTienPhiPhat.Location = new System.Drawing.Point(224, 178);
            this.lblHienThiTongTienPhiPhat.Name = "lblHienThiTongTienPhiPhat";
            this.lblHienThiTongTienPhiPhat.Size = new System.Drawing.Size(0, 39);
            this.lblHienThiTongTienPhiPhat.TabIndex = 4;
            // 
            // lblTongTienPhiPhat
            // 
            this.lblTongTienPhiPhat.AutoSize = true;
            this.lblTongTienPhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienPhiPhat.Location = new System.Drawing.Point(23, 178);
            this.lblTongTienPhiPhat.Name = "lblTongTienPhiPhat";
            this.lblTongTienPhiPhat.Size = new System.Drawing.Size(195, 39);
            this.lblTongTienPhiPhat.TabIndex = 3;
            this.lblTongTienPhiPhat.Text = "Tổng Cộng:";
            // 
            // btnThanhToanPhiPhat
            // 
            this.btnThanhToanPhiPhat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThanhToanPhiPhat.Location = new System.Drawing.Point(3, 265);
            this.btnThanhToanPhiPhat.Name = "btnThanhToanPhiPhat";
            this.btnThanhToanPhiPhat.Size = new System.Drawing.Size(959, 57);
            this.btnThanhToanPhiPhat.TabIndex = 0;
            this.btnThanhToanPhiPhat.Text = "Thanh Toán";
            this.btnThanhToanPhiPhat.UseVisualStyleBackColor = true;
            this.btnThanhToanPhiPhat.Click += new System.EventHandler(this.btnThanhToanPhiPhat_Click);
            // 
            // frmChiTietPhiPhat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1846, 756);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChiTietPhiPhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Phí Phạt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChiTietPhiPhat_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmChiTietPhiPhat_MouseClick);
            this.MouseHover += new System.EventHandler(this.frmChiTietPhiPhat_MouseHover);
            this.Move += new System.EventHandler(this.frmChiTietPhiPhat_Move);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ChiTietPhiPhat)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox_ThongTinKH.ResumeLayout(false);
            this.groupBox_ThongTinKH.PerformLayout();
            this.groupBox_ThanhToanPhiPhat.ResumeLayout(false);
            this.groupBox_ThanhToanPhiPhat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblTitle1_XemChiTietPhiPhat;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox_ThongTinKH;
        private System.Windows.Forms.GroupBox groupBox_ThanhToanPhiPhat;
        private System.Windows.Forms.Label lblNgayThanhToan_PhiPhat;
        private System.Windows.Forms.DateTimePicker dateTimePicker_NgayThanhToan_PhiPhat;
        private System.Windows.Forms.TextBox txtMaKhachHangPhiPhat;
        private System.Windows.Forms.Label lblTenKhachHang_XemPhiPhat;
        private System.Windows.Forms.TextBox txtTenKhachPhiPhat;
        private System.Windows.Forms.Label lblMaKhachHang_XemPhiPhat;
        private System.Windows.Forms.Button btnThanhToanPhiPhat;
        private System.Windows.Forms.Label lblHienThiTongTienPhiPhat;
        private System.Windows.Forms.Label lblTongTienPhiPhat;
        private System.Windows.Forms.DataGridView dataGridView_ChiTietPhiPhat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbThanhToan;
        private System.Windows.Forms.CheckBox checkBox_ThanhToanHet;
        private System.Windows.Forms.CheckBox checkBox_ThanhToanTungPhan;
    }
}