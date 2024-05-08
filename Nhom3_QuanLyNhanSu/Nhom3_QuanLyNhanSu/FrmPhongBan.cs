using System;
using System.Windows.Forms;
using Nhom3_QuanLyNhanSu.Models;
using Nhom3_QuanLyNhanSu.Entities;

namespace Nhom3_QuanLyNhanSu
{
    public partial class FrmPhongBan : Form
    {
        #region Function
        private infoTab tab = null;
        public ChangeStateButton change;

        private Validate validate = new Validate();
        private bool BeforeInsert = false;

        public void setTab(infoTab tab)
        {
            this.tab = tab;

            this.tab.AddNew = new infoTab.EventButton(Them);
            this.tab.Cancel = new infoTab.EventButton(HuyBo);
            this.tab.Save = new infoTab.EventButton(LuuLai);
            this.tab.Delete = new infoTab.EventButton(Xoa);
            this.tab.Edit = new infoTab.EventButton(Sua);
            this.tab.Refresh = new infoTab.EventButton(CapNhat);
            this.tab.Print = new infoTab.EventButton(In);
        }

        private void changeStateButton(bool b1, bool b2, bool b3, bool b4, bool b5)
        {
            if (!isUpdate)
            {
                tab.Them = b1;
                tab.Sua = b2;
                tab.Luu = b3;
                tab.CapNhat = b4;
                tab.In = b5;

                change();
            }
        }

        private void HiddenIconTextBox() {
            lblIconMaPhong.Visible = false;
            lblIconTenPhong.Visible = false;
        }

        public void ShowEditAnDeleteButton()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                changeStateButton(true, true, false, true, true);
                txtMaPhong.Enabled = false;
                txtTenPhong.Enabled = false;
            }
            HiddenIconTextBox();
            
        }

        private void ShowDetail(DataGridViewRow row)
        {
            if (row != null && (tab != null && (tab.action == ActionForm.KHONG || tab.action == ActionForm.SUA)) || tab == null || BeforeInsert)
            {
                txtMaPhong.Text = row.Cells[0].Value.ToString();
                txtTenPhong.Text = row.Cells[1].Value.ToString();
                txtSoNV.Text = row.Cells[2].Value.ToString();
            }
            else {
                clearInsert();
            }
        }

        private void clearInsert() {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtSoNV.Text = "";
        }

        private void Them()
        {
            changeStateButton(false, false, true, false, true);
            tab.action = ActionForm.THEM;

            txtMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            clearInsert();
            txtMaPhong.Focus();
            btnSearch.Enabled = false;
            dataGridView1.Enabled = false;
        }

        private void HuyBoFull()
        {
            changeStateButton(true, true, false, true, true);
            tab.action = ActionForm.KHONG;

            txtMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;


            HiddenIconTextBox();
            BeforeInsert = false;
            btnSearch.Enabled = true;
            dataGridView1.Enabled = true;
        }

        private void HuyBo()
        {
            HuyBoFull();
            ShowDetail(dataGridView1.CurrentRow);
        }

        private void LuuLai()
        {
            switch (tab.action) { 
                case ActionForm.THEM:
                    CheckMaPhong();
                    CheckTenPhong();
                    if (!validate.Check(lblIconMaPhong, lblIconTenPhong)) {
                        MessageBox.Show("Có lỗi. Không thể lưu");
                        return;
                    }
                    BeforeInsert = true;
                    model.insert(new PhongBan() { Ma = txtMaPhong.Text.Trim().ToUpper(), Ten = validate.formatStringToName(txtTenPhong.Text) });
                    HuyBoFull();
                    isChangeData = true;
                    if (!isUpdate && lblMessage.Text.Equals("Insert Successfully"))
                        tab.UpdateData(4);
                    break;
                case ActionForm.SUA:
                    CheckTenPhong();
                    if (!validate.Check(lblIconTenPhong))
                    {
                        MessageBox.Show("Có lỗi. Không thể lưu");
                        return;
                    }
                    model.update(new PhongBan() { Ma = txtMaPhong.Text.Trim(), Ten = validate.formatStringToName(txtTenPhong.Text),SoNV=int.Parse(txtSoNV.Text) });
                    HuyBoFull();
                    isChangeData = true;
                    if (!isUpdate && lblMessage.Text.EndsWith("row(s) affected"))
                        tab.UpdateData(4);
                    break;
            }
        }

        private void Sua()
        {
            changeStateButton(false, false, true, false, true);
            tab.action = ActionForm.SUA;

            txtTenPhong.Enabled = true;
            txtTenPhong.Focus();
            btnSearch.Enabled = false;
        }

        private void Xoa() {
            if (tab.action == ActionForm.KHONG) {
                model.delete();
                if (!isUpdate && lblMessage.Text.EndsWith("row(s) affected"))
                {
                    tab.UpdateData(4);
                }
            }
        }

        private void CapNhat()
        {
            if (tab.action == ActionForm.KHONG)
            {
                model.getAllData("TEN_PB");
                ShowDetail(dataGridView1.CurrentRow);
            }
        }

        private void In()
        {
            System.Collections.Generic.List<PhongBan> ldata = new System.Collections.Generic.List<PhongBan>();

            foreach (DataGridViewRow row in dataGridView1.Rows) {
                PhongBan pb = new PhongBan();
                pb.Ma = row.Cells[0].Value.ToString();
                pb.Ten = row.Cells[1].Value.ToString();
                pb.SoNV = (int)row.Cells[2].Value;

                ldata.Add(pb);
            }

            new Reports.Frm_Report_PhongBan(ldata).Show();
        }

        #endregion

        public FrmPhongBan()
        {
            InitializeComponent();
        }

        private void EnableButtonUpdate(bool b)
        {
            btnLuu.Enabled = !b;
            btnHuy.Enabled = !b;
            btnThem.Enabled = b;
            btnSua.Enabled = b;
        }

        private bool isUpdate = false;

        public bool isChangeData = false;

        public string CurrentRowSelected = null;

        public FrmPhongBan(string CurrentRowSelected)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            InitializeComponent();

            this.tab = new infoTab();
           

            this.isUpdate = true;
            this.CurrentRowSelected = CurrentRowSelected;
            txtTenPhong.Enabled = false;
            HiddenIconTextBox();

            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnDong.Visible = true;

            EnableButtonUpdate(true);

            
        }

        private PhongBanModel model = null;

        private void FrmPhongBan_Load(object sender, EventArgs e)
        {
            model = new PhongBanModel();
            model.setControl(dataGridView1, lblMessage);

            model.getAllData("TEN_PB");

            model.ShowDetail(ShowDetail);

            validate.SetTooltip(toolTip1);

            if (CurrentRowSelected != null)
            {
                dataGridView1.ClearSelection();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(CurrentRowSelected))
                    {
                        row.Cells[0].Selected = true;
                    }
                }
                dataGridView1.DoubleClick += new EventHandler(dataGridView1_DoubleClick);
            }

            ShowDetail(dataGridView1.CurrentRow);
        }

        private void CloseForm()
        {
            if (dataGridView1.CurrentRow != null)
                CurrentRowSelected = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            else
                CurrentRowSelected = null;
            this.Dispose();
        }

        void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CheckMaPhong() {
            if (tab.action == ActionForm.THEM)
            {
                string maphong = txtMaPhong.Text.Trim();
                bool flag = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(maphong))
                    {
                        flag = false;
                        break;
                    }
                }
                lblIconMaPhong.Visible = true;
                if (flag && maphong != "")
                {
                    lblIconMaPhong.Image = validate.imgOk;
                    toolTip1.SetToolTip(lblIconMaPhong, "");
                }
                else
                {
                    lblIconMaPhong.Image = validate.imgError;
                    toolTip1.SetToolTip(lblIconMaPhong, "Mã Phòng Ban Đã Tồn Tại");
                }

            }
        }

        private void CheckTenPhong() {
             validate.Check(new ValidateParam(ValidateType.NULL,txtTenPhong.Text,lblIconTenPhong,"Vui lòng nhập tên phòng ban"));
        }

        private void txtMaPhong_Leave(object sender, EventArgs e)
        {
            CheckMaPhong();
        }

        private void txtTenPhong_Leave(object sender, EventArgs e)
        {
            CheckTenPhong();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            model.getAllData("TEN_PB", txtKey.Text.Trim());
            button1.Enabled = true;
            ShowDetail(dataGridView1.CurrentRow);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.getAllData("TEN_PB");
            button1.Enabled = false;
            ShowDetail(dataGridView1.CurrentRow);
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LuuLai();
            if (tab.action == ActionForm.KHONG)
                EnableButtonUpdate(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HuyBo();
            EnableButtonUpdate(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them();
            EnableButtonUpdate(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Sua();
            EnableButtonUpdate(false);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
