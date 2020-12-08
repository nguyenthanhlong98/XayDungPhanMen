namespace GUI
{
    partial class frmXoaPhiPhat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkBox_ThanhToanTungPhan = new System.Windows.Forms.CheckBox();
            this.checkBox_ThanhToanHet = new System.Windows.Forms.CheckBox();
            this.lblHienThiTongTienPhiPhat = new System.Windows.Forms.Label();
            this.btnXoaPhiPhat = new System.Windows.Forms.Button();
            this.groupBox_ThanhToanPhiPhat = new System.Windows.Forms.GroupBox();
            this.lblTongTienPhiPhat = new System.Windows.Forms.Label();
            this.cbThanhToan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridView_ChiTietPhiPhat = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox_ThongTinKH = new System.Windows.Forms.GroupBox();
            this.treeViewXoaPhiPhat = new System.Windows.Forms.TreeView();
            this.lblTitle1_XemChiTietPhiPhat = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox_ThanhToanPhiPhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ChiTietPhiPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox_ThongTinKH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_ThanhToanTungPhan
            // 
            this.checkBox_ThanhToanTungPhan.AutoSize = true;
            this.checkBox_ThanhToanTungPhan.Location = new System.Drawing.Point(420, 63);
            this.checkBox_ThanhToanTungPhan.Name = "checkBox_ThanhToanTungPhan";
            this.checkBox_ThanhToanTungPhan.Size = new System.Drawing.Size(316, 42);
            this.checkBox_ThanhToanTungPhan.TabIndex = 7;
            this.checkBox_ThanhToanTungPhan.Text = "Xóa Từng Khoảng";
            this.checkBox_ThanhToanTungPhan.UseVisualStyleBackColor = true;
            this.checkBox_ThanhToanTungPhan.CheckedChanged += new System.EventHandler(this.checkBox_ThanhToanTungPhan_CheckedChanged);
            // 
            // checkBox_ThanhToanHet
            // 
            this.checkBox_ThanhToanHet.AutoSize = true;
            this.checkBox_ThanhToanHet.Location = new System.Drawing.Point(40, 63);
            this.checkBox_ThanhToanHet.Name = "checkBox_ThanhToanHet";
            this.checkBox_ThanhToanHet.Size = new System.Drawing.Size(174, 42);
            this.checkBox_ThanhToanHet.TabIndex = 6;
            this.checkBox_ThanhToanHet.Text = "Xóa Hết ";
            this.checkBox_ThanhToanHet.UseVisualStyleBackColor = true;
            this.checkBox_ThanhToanHet.CheckedChanged += new System.EventHandler(this.checkBox_ThanhToanHet_CheckedChanged);
            // 
            // lblHienThiTongTienPhiPhat
            // 
            this.lblHienThiTongTienPhiPhat.AutoSize = true;
            this.lblHienThiTongTienPhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHienThiTongTienPhiPhat.Location = new System.Drawing.Point(1441, 66);
            this.lblHienThiTongTienPhiPhat.Name = "lblHienThiTongTienPhiPhat";
            this.lblHienThiTongTienPhiPhat.Size = new System.Drawing.Size(0, 39);
            this.lblHienThiTongTienPhiPhat.TabIndex = 4;
            // 
            // btnXoaPhiPhat
            // 
            this.btnXoaPhiPhat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnXoaPhiPhat.Location = new System.Drawing.Point(3, 214);
            this.btnXoaPhiPhat.Name = "btnXoaPhiPhat";
            this.btnXoaPhiPhat.Size = new System.Drawing.Size(1799, 50);
            this.btnXoaPhiPhat.TabIndex = 0;
            this.btnXoaPhiPhat.Text = "Xóa Phí Phạt";
            this.btnXoaPhiPhat.UseVisualStyleBackColor = true;
            this.btnXoaPhiPhat.Click += new System.EventHandler(this.btnXoaPhiPhat_Click);
            // 
            // groupBox_ThanhToanPhiPhat
            // 
            this.groupBox_ThanhToanPhiPhat.Controls.Add(this.checkBox_ThanhToanTungPhan);
            this.groupBox_ThanhToanPhiPhat.Controls.Add(this.checkBox_ThanhToanHet);
            this.groupBox_ThanhToanPhiPhat.Controls.Add(this.lblHienThiTongTienPhiPhat);
            this.groupBox_ThanhToanPhiPhat.Controls.Add(this.lblTongTienPhiPhat);
            this.groupBox_ThanhToanPhiPhat.Controls.Add(this.btnXoaPhiPhat);
            this.groupBox_ThanhToanPhiPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_ThanhToanPhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ThanhToanPhiPhat.Location = new System.Drawing.Point(0, 0);
            this.groupBox_ThanhToanPhiPhat.Name = "groupBox_ThanhToanPhiPhat";
            this.groupBox_ThanhToanPhiPhat.Size = new System.Drawing.Size(1805, 267);
            this.groupBox_ThanhToanPhiPhat.TabIndex = 0;
            this.groupBox_ThanhToanPhiPhat.TabStop = false;
            this.groupBox_ThanhToanPhiPhat.Text = "Thông Tin Thanh Toán";
            // 
            // lblTongTienPhiPhat
            // 
            this.lblTongTienPhiPhat.AutoSize = true;
            this.lblTongTienPhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienPhiPhat.Location = new System.Drawing.Point(1222, 63);
            this.lblTongTienPhiPhat.Name = "lblTongTienPhiPhat";
            this.lblTongTienPhiPhat.Size = new System.Drawing.Size(195, 39);
            this.lblTongTienPhiPhat.TabIndex = 3;
            this.lblTongTienPhiPhat.Text = "Tổng Cộng:";
            // 
            // cbThanhToan
            // 
            this.cbThanhToan.HeaderText = "Chọn";
            this.cbThanhToan.MinimumWidth = 6;
            this.cbThanhToan.Name = "cbThanhToan";
            this.cbThanhToan.Width = 75;
            // 
            // dataGridView_ChiTietPhiPhat
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ChiTietPhiPhat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ChiTietPhiPhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ChiTietPhiPhat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbThanhToan});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ChiTietPhiPhat.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ChiTietPhiPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ChiTietPhiPhat.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ChiTietPhiPhat.Name = "dataGridView_ChiTietPhiPhat";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ChiTietPhiPhat.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_ChiTietPhiPhat.RowHeadersWidth = 51;
            this.dataGridView_ChiTietPhiPhat.Size = new System.Drawing.Size(1501, 520);
            this.dataGridView_ChiTietPhiPhat.TabIndex = 1;
            this.dataGridView_ChiTietPhiPhat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ChiTietPhiPhat_CellContentClick);
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox_ThanhToanPhiPhat);
            this.splitContainer2.Size = new System.Drawing.Size(1805, 792);
            this.splitContainer2.SplitterDistance = 520;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox_ThongTinKH);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridView_ChiTietPhiPhat);
            this.splitContainer4.Size = new System.Drawing.Size(1805, 520);
            this.splitContainer4.SplitterDistance = 300;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox_ThongTinKH
            // 
            this.groupBox_ThongTinKH.Controls.Add(this.treeViewXoaPhiPhat);
            this.groupBox_ThongTinKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_ThongTinKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ThongTinKH.Location = new System.Drawing.Point(0, 0);
            this.groupBox_ThongTinKH.Name = "groupBox_ThongTinKH";
            this.groupBox_ThongTinKH.Size = new System.Drawing.Size(300, 520);
            this.groupBox_ThongTinKH.TabIndex = 1;
            this.groupBox_ThongTinKH.TabStop = false;
            this.groupBox_ThongTinKH.Text = "Thông Tin Khách Hàng";
            // 
            // treeViewXoaPhiPhat
            // 
            this.treeViewXoaPhiPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewXoaPhiPhat.Location = new System.Drawing.Point(3, 41);
            this.treeViewXoaPhiPhat.Name = "treeViewXoaPhiPhat";
            this.treeViewXoaPhiPhat.Size = new System.Drawing.Size(294, 476);
            this.treeViewXoaPhiPhat.TabIndex = 0;
            this.treeViewXoaPhiPhat.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewXoaPhiPhat_AfterSelect);
            // 
            // lblTitle1_XemChiTietPhiPhat
            // 
            this.lblTitle1_XemChiTietPhiPhat.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle1_XemChiTietPhiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1_XemChiTietPhiPhat.Location = new System.Drawing.Point(0, 0);
            this.lblTitle1_XemChiTietPhiPhat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle1_XemChiTietPhiPhat.Name = "lblTitle1_XemChiTietPhiPhat";
            this.lblTitle1_XemChiTietPhiPhat.Size = new System.Drawing.Size(1805, 53);
            this.lblTitle1_XemChiTietPhiPhat.TabIndex = 2;
            this.lblTitle1_XemChiTietPhiPhat.Text = "XÓA PHÍ PHẠT";
            this.lblTitle1_XemChiTietPhiPhat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            this.splitContainer1.Size = new System.Drawing.Size(1805, 883);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // frmXoaPhiPhat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1805, 883);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmXoaPhiPhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmXoaPhiPhat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXoaPhiPhat_Load);
            this.groupBox_ThanhToanPhiPhat.ResumeLayout(false);
            this.groupBox_ThanhToanPhiPhat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ChiTietPhiPhat)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox_ThongTinKH.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_ThanhToanTungPhan;
        private System.Windows.Forms.CheckBox checkBox_ThanhToanHet;
        private System.Windows.Forms.Label lblHienThiTongTienPhiPhat;
        private System.Windows.Forms.Button btnXoaPhiPhat;
        private System.Windows.Forms.GroupBox groupBox_ThanhToanPhiPhat;
        private System.Windows.Forms.Label lblTongTienPhiPhat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbThanhToan;
        private System.Windows.Forms.DataGridView dataGridView_ChiTietPhiPhat;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblTitle1_XemChiTietPhiPhat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox_ThongTinKH;
        private System.Windows.Forms.TreeView treeViewXoaPhiPhat;
    }
}