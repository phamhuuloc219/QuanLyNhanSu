using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Nhom3_QuanLyNhanSu
{
    
    public partial class FrmMain : Form
    {
        //Quản Lý Thông Tin Các Tab Trong TabControl
        private clsTab clstab = new clsTab();

        //Thông Tin User Đang Đăng Nhập.
        private Nhom3_QuanLyNhanSu.Entities.NhanVienLogin nvlogin = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        //Icon Close Tab
        private Bitmap img = Properties.Resources.close;

        //Lưu Thông Tin Thứ, Ngày, Tháng, Năm Hiện Tại.
        private string FullDay = "";

        //Giờ Hiện Tại
        private int hour = 0;
        //Phút Hiện Tại
        private int minute = 0;
        //Giây Hiện Tại
        private int second = 0;

        private void getFullDay(DateTime now)
        {
            
            int day = now.Day;
            int month = now.Month;

            FullDay = now.DayOfWeek.ToString()+" ngày ";

            FullDay += (day < 10 ? ("0" + day) : day + "")+"/";

            FullDay += (month < 10 ? ("0" + month) : month + "") + "/";
            FullDay += now.Year+"";

        }

        private void AddNewTab(Form frm,int index,bool print=false) {

            foreach (TabPage tab in tabControl1.TabPages) {
                if ((int)tab.Tag == index) {
                    //clstab.CurrentTab = int.Parse(tab.Tag.ToString());
                    //tabControl1.SelectedTab = tab;
                    MessageBox.Show("Đã được mở.");
                    return;
                    //tabControl1.TabPages.Remove(tab);
                }
            }

            TabPage tabitem = new TabPage(frm.Text + (index == 0 ? "" : "     "));
            frm.TopLevel = false;
            frm.Parent = tabitem;
            frm.Visible = true;
            frm.Dock = DockStyle.Fill;
            frm.AutoScroll = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();

            tabitem.Tag = index;

            tabControl1.TabPages.Add(tabitem);
            tabControl1.SelectedTab = tabitem;

            clstab.CurrentTab = index;

            lblCurrentTab.Text = tabitem.Text.Trim() + " is opened";

            clstab.addTab(index, print);

            EnableButton();
            clstab.AddEventChangeData(changeData);
        }

        private void changeData(int index) {
            infoTab nhanvien = clstab.current(3);

            if (nhanvien != null) {
                nhanvien.callBackChangeData(index);
            }
        }

        private void changeButton() {
            EnableButton();
        }

        private void OpenHomePage() {
            FrmHome home = new FrmHome();
            AddNewTab(home, 0);
        }

        private void DangNhap(bool b) {
            btnDangNhap.Enabled = !b;
            btnDoiMatKhau.Enabled = b;
            btnDangXuat.Enabled = b;

            mnQuanLy.Enabled = b;
            mnThongKe.Enabled = b;
        }

        private void SuccessLogin(Nhom3_QuanLyNhanSu.Entities.NhanVienLogin nv) {
            this.nvlogin = nv;
            DangNhap(true);
            lblUserOnline.Text = "Chào Bạn: " + nv.Ho + " " + nv.Ten+"("+(nv.LaAdmin?"Admin":"User")+")";
            NVLG.HoTenNVLG = nv.Ho + " " + nv.Ten;
            NVLG.MaNVLG = nv.MaNV;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            getFullDay(now);
           
            hour = now.Hour;
            minute = now.Minute;
            second = now.Second;


            lblTimeNow.Text =FullDay+ " " + hour + ":" + minute + ":" + ":" + second;


            OpenHomePage();

            btnDangNhap.PerformClick();
            
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((int)this.tabControl1.TabPages[e.Index].Tag == 0)
            {
                e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text.Trim(), e.Font, Brushes.Black, e.Bounds.Left + 3, e.Bounds.Top + 4);
            }
            else {
                e.Graphics.DrawImage(img, new Point(e.Bounds.Right - 18, e.Bounds.Top + 1));
                e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 3, e.Bounds.Top + 4);
            }
            
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++) {
                Rectangle r = tabControl1.GetTabRect(i);

                Rectangle close = new Rectangle(r.Right - 16, r.Top + 1, 14, 15);

                if (close.Contains(e.Location)) {
                    if ((int)tabControl1.TabPages[i].Tag != 0)
                    {
                        int idtab = (int)tabControl1.TabPages[i].Tag;
                        infoTab tabf = clstab.current(idtab);
                        if (tabf!=null && tabf.action != ActionForm.KHONG)
                        {
                            if (MessageBox.Show("Có dữ liệu chưa được lưu. Bạn có chắc muốn đóng?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                clstab.removeTab(idtab);
                                this.tabControl1.TabPages.RemoveAt(i);
                                break;
                            }
                        }
                        else
                        {
                            clstab.removeTab(idtab);
                            this.tabControl1.TabPages.RemoveAt(i);
                            break;
                        }
                    }
                 
                }
            }
        }

        private void EnableButton(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6, bool b7) {
            btnAddNew.Enabled = b1;
            btnEdit.Enabled = b2;
            btnDelete.Enabled = b3;

            btnSave.Enabled = b4;
            btnCancel.Enabled = b5;
            btnRefresh.Enabled = b6;
            btnPrint.Enabled = b7;

            if (nvlogin!=null && !nvlogin.LaAdmin) {
                btnDelete.Enabled = false;
            }
        }

        private void EnableButton() {
            infoTab tabcurrent = clstab.current();

            if (tabcurrent != null)
            {
                EnableButton(tabcurrent.Them, tabcurrent.Sua, tabcurrent.Sua, tabcurrent.Luu, tabcurrent.Luu, tabcurrent.CapNhat, tabcurrent.In);
            }
            else {
                EnableButton(false, false, false, false, false, false, false);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                //clstab.CurrentTab = (int)tabControl1.SelectedTab.Tag;
                //lblCurrentTab.Text = tabControl1.SelectedTab.Text.Trim() + " is opened";
                EnableButton();
            }
            catch { 
                
            }
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (second == 59)
            {
                second = 0;
                if (minute == 59)
                {
                    minute = 0;

                    if (hour == 24)
                    {
                        hour = 0;

                        DateTime now = DateTime.Now;
                        getFullDay(now);

                    }
                    else
                    {
                        hour++;
                    }
                }
                else
                {
                    minute++;
                }
            }
            else {
                second++;
            }

            lblTimeNow.Text = FullDay + " " + (hour < 10 ? ("0" + hour) : hour + "") + ":" + (minute < 10 ? ("0" + minute) : minute + "") + ":" + (second < 10 ? ("0" + second) : second + "");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.ToString().Equals("UserClosing"))
            {
                if (MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Thông Báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCloseAllTab_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 1)
            {
                if (MessageBox.Show("Bạn có chắc muốn đóng tất cả tab đang được mở?", "Thông Báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tabControl1.TabPages.Clear();
                    clstab.clearTab();
                    OpenHomePage();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                btnAddNew.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.E))
            {
                btnEdit.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.R))
            {
                btnRefresh.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.P))
            {
                btnPrint.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave.PerformClick();
                return true;
            }
            if (keyData == Keys.Delete)
            {
                btnDelete.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.Q))
            {
                btnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            infoTab tabcurrent = clstab.current();

            tabcurrent.AddNew();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            infoTab tabcurrent = clstab.current();

            tabcurrent.Edit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            infoTab tabcurrent = clstab.current();

            tabcurrent.Delete();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            infoTab tabcurrent = clstab.current();

            tabcurrent.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            infoTab tabcurrent = clstab.current();

            tabcurrent.Cancel();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            infoTab tabcurrent = clstab.current();

            tabcurrent.Refresh();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            infoTab tabcurrent = clstab.current();

            tabcurrent.Print();
        }

        private void btnShowFormInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bài tập nhóm: Phần mềm quản lý nhân sự.\n\n Nhóm sinh viên thực hiện: \n1. Phạm Hữu Lộc\n2. Nguyễn Thị Thanh Thảo\n\nPhần mềm này được tạo ra nhằm mục đích quản lý các nhân viên trong công ty một cách dễ dàng hơn","Giới thiệu");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (nvlogin == null)
            {
                FrmLogin lg = new FrmLogin();
                lg.lg = new FrmLogin.SuccessLogin(SuccessLogin);
                lg.ShowDialog();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            nvlogin = null;
            tabControl1.TabPages.Clear();
            clstab.clearTab();
            OpenHomePage();
            DangNhap(false);
            lblUserOnline.Text = "Chào Bạn: Khách";
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            FrmPhongBan f = new FrmPhongBan(nvlogin.LaAdmin);
            AddNewTab(f, 2);
            f.setTab(clstab.current());
            f.change = new ChangeStateButton(changeButton);
            f.ShowEditAnDeleteButton();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien f = new FrmNhanVien(nvlogin.LaAdmin);
            AddNewTab(f, 3);
            f.setTab(clstab.current());
            f.change = new ChangeStateButton(changeButton);
            f.ShowEditAnDeleteButton();
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            FrmChucVu f = new FrmChucVu(nvlogin.LaAdmin);
            AddNewTab(f, 4);
            f.setTab(clstab.current());
            f.change = new ChangeStateButton(changeButton);
            f.ShowEditAnDeleteButton();
        }

        private void btnDanToc_Click(object sender, EventArgs e)
        {
            FrmDanToc f = new FrmDanToc(nvlogin.LaAdmin);
            AddNewTab(f, 5);
            f.setTab(clstab.current());
            f.change = new ChangeStateButton(changeButton);
            f.ShowEditAnDeleteButton();
        }

        private void btnTonGiao_Click(object sender, EventArgs e)
        {
            FrmTonGiao f = new FrmTonGiao(nvlogin.LaAdmin);
            AddNewTab(f, 6);
            f.setTab(clstab.current());
            f.change = new ChangeStateButton(changeButton);
            f.ShowEditAnDeleteButton();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            FrmLuong f = new FrmLuong(nvlogin.LaAdmin);
            AddNewTab(f, 7);
            f.setTab(clstab.current());
            f.change = new ChangeStateButton(changeButton);
            f.ShowEditAnDeleteButton();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            FrmDoiMatKhau frm = new FrmDoiMatKhau(nvlogin.MaNV);
            frm.ShowDialog();
        }

        private void btnHocVan_Click(object sender, EventArgs e)
        {
            FrmTrinhDo f = new FrmTrinhDo(nvlogin.LaAdmin);
            AddNewTab(f, 9);
            f.setTab(clstab.current());
            f.change = new ChangeStateButton(changeButton);
            f.ShowEditAnDeleteButton();
        }

        private void btnPrintNhanVien_Click(object sender, EventArgs e)
        {

            new Reports.Frm_Report_LuongThucLanh().Show();
            /*if (nvlogin.LaAdmin)
            {
                btnPrintNhanVien.Enabled = false;
            }
            else
            {
                btnPrintNhanVien.Enabled = true;
            }*/
        }
    }
}
