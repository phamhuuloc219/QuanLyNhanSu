using System;
using System.Windows.Forms;
using Nhom3_QuanLyNhanSu.Models;

namespace Nhom3_QuanLyNhanSu
{
    public partial class FrmCMND : Form
    {
        public string SOCMND=null;
        private string MaHS = null;

        private DateTime ngaysinh;

        public FrmCMND(string SOCMND,string MaHS,DateTime ngaysinh)
        {
            InitializeComponent();
            this.SOCMND = SOCMND;
            this.ngaysinh = ngaysinh;
            this.MaHS = MaHS;
        }

        public FrmCMND(DateTime ngaysinh)
        {
            InitializeComponent();
            this.ngaysinh = ngaysinh;
        }

        private SoCMNDModel model = null;

        private Validate validate = null;

        private void FrmCMND_Load(object sender, EventArgs e)
        {
            model = new SoCMNDModel();
            validate = new Validate();
            validate.SetTooltip(toolTip1);

            if (SOCMND != null && SOCMND!="")
            {
                Entities.CMND info = model.getInfo(SOCMND);

                if (info != null) {
                    txtCMND.Text = SOCMND;
                    txtNoiCap.Text = info.NoiCap;
                    dtNgayCap.Value = info.NgayCap;
                }
            }
        }

        private void checkNgayCap()
        {
            DateTime now = DateTime.Now;
            DateTime ngaycap = dtNgayCap.Value;
            lblIconNgayCap.Visible = true;

            int sonam = ngaycap.Year - ngaysinh.Year;

            if ((sonam > 14 || (sonam == 14 && ngaycap.Month > ngaysinh.Month) || (sonam == 14 && ngaycap.Month == ngaysinh.Month && ngaycap.Day >= ngaysinh.Day)) && (now - ngaycap).TotalDays >= 0)
            {
                lblIconNgayCap.Image = validate.imgOk;
                toolTip1.SetToolTip(lblIconNgayCap, "");
            }
            else { 
                lblIconNgayCap.Image = validate.imgError;
                toolTip1.SetToolTip(lblIconNgayCap, "Ngày cấp phải từ 14 tuổi so với ngày sinh và nhỏ hơn ngày hiện tại");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validate.Check(new ValidateParam(ValidateType.CMND, txtCMND.Text, lblIconCMND, "CMND không hợp lệ"));
            checkNgayCap();
            validate.Check(new ValidateParam(ValidateType.NULL, txtNoiCap.Text, lblIconNoiCap, "Vui lòng nhập nơi cấp"));
            if (!validate.Check(lblIconCMND, lblIconNoiCap, lblIconNgayCap))
            {
                MessageBox.Show("Có lỗi. Không thể lưu");
                return;
            }
            if (SOCMND == null)
            {
                if (model.Insert(new Entities.CMND() { SOCMND = txtCMND.Text.Trim(), NgayCap = dtNgayCap.Value, NoiCap = validate.formatStringToName(txtNoiCap.Text) }) > 0)
                {
                    SOCMND = txtCMND.Text.Trim();
                    this.Dispose();
                }
            }
            else {
                if (model.Edit(new Entities.CMND() { SOCMND = txtCMND.Text.Trim(), NgayCap = dtNgayCap.Value, NoiCap = validate.formatStringToName(txtNoiCap.Text) }, SOCMND, MaHS) > 0)
                {
                    SOCMND = txtCMND.Text.Trim();
                    this.Dispose();
                }
            }
        }

        private void dtNgayCap_ValueChanged(object sender, EventArgs e)
        {
            checkNgayCap();
        }

        private void txtCMND_Leave(object sender, EventArgs e)
        {
            validate.Check(new ValidateParam(ValidateType.CMND, txtCMND.Text, lblIconCMND, "CMND không hợp lệ"));
        }

        private void txtNoiCap_Leave(object sender, EventArgs e)
        {
            validate.Check(new ValidateParam(ValidateType.NULL, txtNoiCap.Text, lblIconNoiCap, "Vui lòng nhập nơi cấp"));
        }
    }
}
