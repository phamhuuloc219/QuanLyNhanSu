using System;
using System.Windows.Forms;
using Nhom3_QuanLyNhanSu.Models;
using Nhom3_QuanLyNhanSu.Entities;

namespace Nhom3_QuanLyNhanSu
{
    public partial class FrmLogin : Form
    {
        public delegate void SuccessLogin(NhanVienLogin nv);

        public SuccessLogin lg = null;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Login() {
            if(txtUsername.Text.Trim()==""){
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                txtUsername.Focus();
                return;
            }
            if(txtPassword.Text.Trim()==""){
                MessageBox.Show("Vui lòng nhập mật khẩu");
                txtPassword.Focus();
                return;
            }
            LoginModel model = new LoginModel();

            NhanVienLogin nv = model.login(txtUsername.Text.Trim().ToUpper(), txtPassword.Text.Trim());

            if (nv == null) {
                MessageBox.Show("Mã nhân viên hoặc mật khẩu sai.\nNếu bạn quyên mật khẩu vui lòng liên hệ phòng IT để lấy lại mật khẩu.");
                return;
            }
            if (checkBox1.Checked)
            {
                System.IO.File.WriteAllText("userlogin.txt", txtUsername.Text.Trim().ToUpper() + "~" + txtPassword.Text.Trim());
            }
            else {
                System.IO.File.WriteAllText("userlogin.txt", "");
            }
            lg(nv);
            this.Dispose();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                Login();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string[] userlogin = System.IO.File.ReadAllText("userlogin.txt").Split('~');

            if (userlogin.Length == 2) {
                txtUsername.Text = userlogin[0];
                txtPassword.Text = userlogin[1];
            }
        }
    }
}
