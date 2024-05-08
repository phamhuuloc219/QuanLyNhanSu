namespace Nhom3_QuanLyNhanSu
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChucVu = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcKhácToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDanToc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTonGiao = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHocVan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowFormInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnCloseAllTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCurrentTab = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.lblUserOnline = new System.Windows.Forms.ToolStripLabel();
            this.lblTimeNow = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 468);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.mnQuanLy,
            this.mnThongKe,
            this.mnTroGiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDangNhap,
            this.toolStripMenuItem2,
            this.btnDoiMatKhau,
            this.toolStripMenuItem3,
            this.btnDangXuat});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(152, 22);
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Enabled = false;
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(152, 22);
            this.btnDoiMatKhau.Text = "Đổi Mật Khẩu";
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Enabled = false;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(152, 22);
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // mnQuanLy
            // 
            this.mnQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNhanVien,
            this.btnPhongBan,
            this.btnChucVu,
            this.danhMụcKhácToolStripMenuItem});
            this.mnQuanLy.Enabled = false;
            this.mnQuanLy.Name = "mnQuanLy";
            this.mnQuanLy.Size = new System.Drawing.Size(63, 20);
            this.mnQuanLy.Text = "Quản Lý";
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(158, 22);
            this.btnNhanVien.Text = "Nhân Viên";
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnPhongBan
            // 
            this.btnPhongBan.Name = "btnPhongBan";
            this.btnPhongBan.Size = new System.Drawing.Size(158, 22);
            this.btnPhongBan.Text = "Phòng Ban";
            this.btnPhongBan.Click += new System.EventHandler(this.btnPhongBan_Click);
            // 
            // btnChucVu
            // 
            this.btnChucVu.Name = "btnChucVu";
            this.btnChucVu.Size = new System.Drawing.Size(158, 22);
            this.btnChucVu.Text = "Chức Vụ";
            this.btnChucVu.Click += new System.EventHandler(this.btnChucVu_Click);
            // 
            // danhMụcKhácToolStripMenuItem
            // 
            this.danhMụcKhácToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDanToc,
            this.btnTonGiao,
            this.btnLuong,
            this.btnHocVan});
            this.danhMụcKhácToolStripMenuItem.Name = "danhMụcKhácToolStripMenuItem";
            this.danhMụcKhácToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.danhMụcKhácToolStripMenuItem.Text = "Danh Mục Khác";
            // 
            // btnDanToc
            // 
            this.btnDanToc.Name = "btnDanToc";
            this.btnDanToc.Size = new System.Drawing.Size(122, 22);
            this.btnDanToc.Text = "Dân Tộc";
            this.btnDanToc.Click += new System.EventHandler(this.btnDanToc_Click);
            // 
            // btnTonGiao
            // 
            this.btnTonGiao.Name = "btnTonGiao";
            this.btnTonGiao.Size = new System.Drawing.Size(122, 22);
            this.btnTonGiao.Text = "Tôn Giáo";
            this.btnTonGiao.Click += new System.EventHandler(this.btnTonGiao_Click);
            // 
            // btnLuong
            // 
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Size = new System.Drawing.Size(122, 22);
            this.btnLuong.Text = "Lương";
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            // 
            // btnHocVan
            // 
            this.btnHocVan.Name = "btnHocVan";
            this.btnHocVan.Size = new System.Drawing.Size(122, 22);
            this.btnHocVan.Text = "Học Vấn";
            this.btnHocVan.Click += new System.EventHandler(this.btnHocVan_Click);
            // 
            // mnThongKe
            // 
            this.mnThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrintNhanVien});
            this.mnThongKe.Enabled = false;
            this.mnThongKe.Name = "mnThongKe";
            this.mnThongKe.Size = new System.Drawing.Size(70, 20);
            this.mnThongKe.Text = "Thông Kê";
            // 
            // btnPrintNhanVien
            // 
            this.btnPrintNhanVien.Name = "btnPrintNhanVien";
            this.btnPrintNhanVien.Size = new System.Drawing.Size(167, 22);
            this.btnPrintNhanVien.Text = "Lương Thực Lãnh";
            this.btnPrintNhanVien.Click += new System.EventHandler(this.btnPrintNhanVien_Click);
            // 
            // mnTroGiup
            // 
            this.mnTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowFormInfo});
            this.mnTroGiup.Name = "mnTroGiup";
            this.mnTroGiup.Size = new System.Drawing.Size(65, 20);
            this.mnTroGiup.Text = "Trợ Giúp";
            // 
            // btnShowFormInfo
            // 
            this.btnShowFormInfo.Name = "btnShowFormInfo";
            this.btnShowFormInfo.Size = new System.Drawing.Size(128, 22);
            this.btnShowFormInfo.Text = "Giới Thiệu";
            this.btnShowFormInfo.Click += new System.EventHandler(this.btnShowFormInfo_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnSave,
            this.btnCancel,
            this.toolStripSeparator2,
            this.btnRefresh,
            this.toolStripSeparator3,
            this.btnPrint,
            this.btnCloseAllTab,
            this.toolStripSeparator4,
            this.lblCurrentTab});
            this.toolStrip1.Location = new System.Drawing.Point(5, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(915, 33);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Enabled = false;
            this.btnAddNew.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.add;
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(58, 30);
            this.btnAddNew.Text = "Thêm";
            this.btnAddNew.ToolTipText = "Thêm Mới (CTR + N)";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.editicon;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(46, 30);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.ToolTipText = "Sửa (CTR + E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(47, 30);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.ToolTipText = "Xóa (Delete)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 30);
            this.btnSave.Text = "Lưu";
            this.btnSave.ToolTipText = "Lưu (CTR + S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.cen1;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(49, 30);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.ToolTipText = "Hủy (CTR + Q)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(77, 30);
            this.btnRefresh.Text = "Cập Nhật";
            this.btnRefresh.ToolTipText = "Cập nhật lại (CTR + R)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.iconprint;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(37, 30);
            this.btnPrint.Text = "In";
            this.btnPrint.ToolTipText = "In (CTR + P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCloseAllTab
            // 
            this.btnCloseAllTab.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCloseAllTab.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.close;
            this.btnCloseAllTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseAllTab.Name = "btnCloseAllTab";
            this.btnCloseAllTab.Size = new System.Drawing.Size(96, 30);
            this.btnCloseAllTab.Text = "Close All Tab";
            this.btnCloseAllTab.Click += new System.EventHandler(this.btnCloseAllTab_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 33);
            // 
            // lblCurrentTab
            // 
            this.lblCurrentTab.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblCurrentTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCurrentTab.Name = "lblCurrentTab";
            this.lblCurrentTab.Size = new System.Drawing.Size(63, 30);
            this.lblCurrentTab.Text = "Trang Chủ";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserOnline,
            this.lblTimeNow});
            this.toolStrip2.Location = new System.Drawing.Point(0, 525);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(920, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // lblUserOnline
            // 
            this.lblUserOnline.Name = "lblUserOnline";
            this.lblUserOnline.Size = new System.Drawing.Size(97, 22);
            this.lblUserOnline.Text = "Chào Bạn: Khách";
            // 
            // lblTimeNow
            // 
            this.lblTimeNow.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTimeNow.Name = "lblTimeNow";
            this.lblTimeNow.Size = new System.Drawing.Size(0, 22);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(920, 33);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(920, 468);
            this.panel2.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Nhân Sự - Nhóm 3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnQuanLy;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem btnDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnTroGiup;
        private System.Windows.Forms.ToolStripMenuItem btnShowFormInfo;
        private System.Windows.Forms.ToolStripLabel lblUserOnline;
        private System.Windows.Forms.ToolStripLabel lblTimeNow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem btnDangNhap;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripLabel lblCurrentTab;
        private System.Windows.Forms.ToolStripButton btnCloseAllTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnNhanVien;
        private System.Windows.Forms.ToolStripMenuItem btnPhongBan;
        private System.Windows.Forms.ToolStripMenuItem btnChucVu;
        private System.Windows.Forms.ToolStripMenuItem mnThongKe;
        private System.Windows.Forms.ToolStripMenuItem btnPrintNhanVien;
        private System.Windows.Forms.ToolStripMenuItem danhMụcKhácToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDanToc;
        private System.Windows.Forms.ToolStripMenuItem btnTonGiao;
        private System.Windows.Forms.ToolStripMenuItem btnLuong;
        private System.Windows.Forms.ToolStripMenuItem btnHocVan;
    }
}