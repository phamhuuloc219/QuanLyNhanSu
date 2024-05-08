using System;
using System.Windows.Forms;
using Nhom3_QuanLyNhanSu.Models;
using Nhom3_QuanLyNhanSu.Entities;

namespace Nhom3_QuanLyNhanSu
{
    public partial class FrmChucVu : Form
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

        private void HiddenIconTextBox()
        {
            lblIconMaCV.Visible = false;
            lblIconTenCV.Visible = false;
            lblIconPhuCap.Visible = false;
        }

        private void EnableTextBox(bool b)
        {
            txtMaChucVu.Enabled = b;
            txtTenChucVu.Enabled = b;
            txtPhuCap.Enabled = b;
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

        public void ShowEditAnDeleteButton()
        {
            if (dataGridView1.Rows.Count>0)
            {
                changeStateButton(true, true, false, true, true);
                EnableTextBox(false);
            }
            HiddenIconTextBox();

        }

        private void ShowDetail(DataGridViewRow row)
        {
            if (row != null && (tab != null && (tab.action == ActionForm.KHONG || tab.action == ActionForm.SUA)) || tab == null || BeforeInsert)
            {
                txtMaChucVu.Text = row.Cells[0].Value.ToString();
                txtTenChucVu.Text = row.Cells[1].Value.ToString();
                txtPhuCap.Text = string.Format("{0:0,0}", double.Parse(row.Cells[2].Value.ToString()));
                txtSoNV.Text = row.Cells[3].Value.ToString();
            }
            else {
                clearInsert();
            }
        }

        private void clearInsert(){
            txtMaChucVu.Text = "";
            txtTenChucVu.Text = "";
            txtPhuCap.Text = "";
            txtSoNV.Text = "";
        }

        private void HuyBoFull()
        {
            changeStateButton(true, true, false, true, true);
            tab.action = ActionForm.KHONG;

            EnableTextBox(false);


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

        private void Them()
        {
            changeStateButton(false, false, true, false, true);
            tab.action = ActionForm.THEM;

            EnableTextBox(true);
            clearInsert();
            txtMaChucVu.Focus();
            btnSearch.Enabled = false;
            dataGridView1.Enabled = false;
        }

        private void LuuLai()
        {
            switch (tab.action)
            {
                case ActionForm.THEM:
                    CheckMa();
                    validate.Check(new ValidateParam(ValidateType.NULL, txtTenChucVu.Text, lblIconTenCV,"Vui lòng nhập tên chức vụ"));
                    validate.Check(new ValidateParam(ValidateType.PRICE, txtPhuCap.Text, lblIconPhuCap,"Phụ cấp phải có dạng tiền tệ."));
                    if (!validate.Check(lblIconMaCV, lblIconTenCV,lblIconPhuCap)) {
                        MessageBox.Show("Có lỗi. Không thể lưu");
                        return;
                    }
                    BeforeInsert = true;
                    model.insert(new ChucVu() { Ma = txtMaChucVu.Text.Trim().ToUpper(), Ten = validate.formatStringToName(txtTenChucVu.Text), PhuCap = validate.formatPrice(txtPhuCap.Text.Trim()) });
                    HuyBoFull();
                    isChangeData = true;
                    if (!isUpdate && lblMessage.Text.Equals("Insert Successfully"))
                        tab.UpdateData(1);
                    break;
                case ActionForm.SUA:
                    validate.Check(new ValidateParam(ValidateType.NULL, txtTenChucVu.Text, lblIconTenCV, "Vui lòng nhập tên chức vụ"));
                    validate.Check(new ValidateParam(ValidateType.PRICE, txtPhuCap.Text, lblIconPhuCap, "Phụ cấp phải có dạng tiền tệ."));
                    if (!validate.Check(lblIconTenCV,lblIconPhuCap))
                    {
                        MessageBox.Show("Có lỗi. Không thể lưu");
                        return;
                    }
                    BeforeInsert = true;
                    model.update(new ChucVu() { Ma = txtMaChucVu.Text.Trim(), Ten = validate.formatStringToName(txtTenChucVu.Text), PhuCap = validate.formatPrice(txtPhuCap.Text.Trim()), SoNV = int.Parse(txtSoNV.Text) });
                    HuyBoFull();
                    isChangeData = true;
                    if (!isUpdate && lblMessage.Text.EndsWith("row(s) affected"))
                        tab.UpdateData(1);
                    break;
            }
        }

        private void Sua()
        {
            changeStateButton(false, false, true, false, true);
            tab.action = ActionForm.SUA;

            txtTenChucVu.Enabled = true;
            txtPhuCap.Enabled = true;
            txtTenChucVu.Focus();
            btnSearch.Enabled = false;
        }

        private void Xoa()
        {
            if (tab.action == ActionForm.KHONG)
            {
                model.delete();
                if (!isUpdate && lblMessage.Text.EndsWith("row(s) affected"))
                {
                    tab.UpdateData(1);
                }
            }
        }

        private void CapNhat()
        {
            if (tab.action == ActionForm.KHONG)
            {
                model.getAllData("TEN_CV");
                ShowDetail(dataGridView1.CurrentRow);
            }
        }

        private void In()
        {
            System.Collections.Generic.List<ChucVu> ldata = new System.Collections.Generic.List<ChucVu>();

            foreach (DataGridViewRow row in dataGridView1.Rows) {
                ChucVu cv = new ChucVu();
                cv.Ma = row.Cells[0].Value.ToString();
                cv.Ten = row.Cells[1].Value.ToString();
                cv.PhuCap = string.Format("{0:0,0}", double.Parse(row.Cells[2].Value.ToString()))+" VNĐ";
                cv.SoNV = (int)row.Cells[3].Value;
                ldata.Add(cv);
            }

            new Reports.Frm_Report_ChucVu(ldata).Show();
        }

        private void CheckMa()
        {
            if (tab.action == ActionForm.THEM)
            {
                bool flag = true;
                string Ma = txtMaChucVu.Text.Trim();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(Ma))
                    {
                        flag = false;
                        break;
                    }
                }
                lblIconMaCV.Visible = true;
                if (flag && Ma != "")
                {
                    lblIconMaCV.Image = validate.imgOk;
                    toolTip1.SetToolTip(lblIconMaCV, "");
                }
                else
                {
                    lblIconMaCV.Image = validate.imgError;
                    toolTip1.SetToolTip(lblIconMaCV, "Mã Phòng Ban Đã Tồn Tại");
                }

            }
        }

        #endregion

        private ChucVuModel model = null;

        public FrmChucVu()
        {
            InitializeComponent();
        }

        private bool isUpdate = false;

        public bool isChangeData = false;

        public string CurrentRowSelected = null;

        private void EnableButtonUpdate(bool b) {
            btnLuu.Enabled = !b;
            btnHuy.Enabled = !b;
            btnThem.Enabled = b;
            btnSua.Enabled = b;
        }

        public FrmChucVu(string CurrentRowSelected)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            InitializeComponent();

            this.tab = new infoTab();
           

            this.isUpdate = true;
            this.CurrentRowSelected = CurrentRowSelected;
            EnableTextBox(false);
            HiddenIconTextBox();

            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnDong.Visible = true;

            EnableButtonUpdate(true);

            
        }

        private void FrmChucVu_Load(object sender, EventArgs e)
        {
            model = new ChucVuModel();
            model.setControl(dataGridView1, lblMessage);

            model.getAllData("TEN_CV");


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

        private void txtMaChucVu_Leave(object sender, EventArgs e)
        {
            CheckMa();
        }

        private void txtTenChucVu_Leave(object sender, EventArgs e)
        {
            validate.Check(new ValidateParam(ValidateType.NULL, txtTenChucVu.Text, lblIconTenCV, "Vui lòng nhập tên chức vụ"));
        }

        private void txtPhuCap_Leave(object sender, EventArgs e)
        {
            validate.Check(new ValidateParam(ValidateType.PRICE, txtPhuCap.Text, lblIconPhuCap, "Phụ cấp phải có dạng tiền tệ."));
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "PhuCap") {
                if (e.Value != null) {
                    e.Value = string.Format("{0:0,0}", double.Parse(e.Value.ToString()));
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            model.getAllData("TEN_CV", txtKey.Text.Trim());
            button1.Enabled = true;
            ShowDetail(dataGridView1.CurrentRow);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.getAllData("TEN_CV");
            button1.Enabled = false;
            ShowDetail(dataGridView1.CurrentRow);
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            Sua();
            EnableButtonUpdate(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them();
            EnableButtonUpdate(false);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
