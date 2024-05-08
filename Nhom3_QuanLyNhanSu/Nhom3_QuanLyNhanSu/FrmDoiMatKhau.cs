using System;
using System.Windows.Forms;
using Nhom3_QuanLyNhanSu.Models;

namespace Nhom3_QuanLyNhanSu
{
    public partial class FrmDoiMatKhau : Form
    {
        private string iduser = null;
        public FrmDoiMatKhau(string iduser)
        {
            InitializeComponent();

            this.iduser = iduser;
        }

        private DoiMatKhauModel model = new DoiMatKhauModel();

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string matkhaucu = model.getMatKhauCu(iduser);

            if (txtMatKhauCu.Text.Trim() == "") {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ.");
                txtMatKhauCu.Focus();
                return;
            }

            if (txtMatKhauMoi.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.");
                txtMatKhauMoi.Focus();
                return;
            }

            if (!txtMatKhauMoi.Text.Trim().Equals(txtNhapLai.Text.Trim()))
            {
                MessageBox.Show("Nhập lại mật khẩu sai.");
                txtMatKhauCu.Focus();
                return;
            }

            if(!matkhaucu.Equals(txtMatKhauCu.Text.Trim())){
                MessageBox.Show("Mật khẩu cũ sai.");
                return;
            }


            if (model.DoiMatKhau(iduser, txtMatKhauMoi.Text.Trim()) < 1)
            {
                MessageBox.Show("Có lỗi. Cập nhật mật khẩu thất bại. Vui lòng thử lại.");
                return;
            }
            MessageBox.Show("Cập nhật mật khẩu thành công");
            txtMatKhauMoi.Text = "";
            txtMatKhauCu.Text = "";
            txtNhapLai.Text = "";
        }
    }
}
