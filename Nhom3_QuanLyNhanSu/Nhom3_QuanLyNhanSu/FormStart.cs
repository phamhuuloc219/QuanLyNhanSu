using System;
using System.Windows.Forms;
using System.Threading;
using Nhom3_QuanLyNhanSu.Models;

namespace Nhom3_QuanLyNhanSu
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();

        }

        private void OpenMainForm() {
            Thread.Sleep(1500);
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    new FrmMain().Show();
                    this.Visible = false;
                });
            }
            else
            {
                new FrmMain().Show();
                this.Visible = false;
            }
        }

        private void TestConnectDb()
        {

            Nhom3_QuanLyNhanSu.Models.TestConnection test = new Nhom3_QuanLyNhanSu.Models.TestConnection();


            if (!test.Test())
            {
                this.Visible = false;
                new FormConnect().Show();

            }
            else
            {
                label1.Text = "...Kết Nối Thành Công. Đang Mở Ứng Dụng";
                
                Thread th = new Thread(new ThreadStart(OpenMainForm));
                th.IsBackground = true;
                th.Start();
                
            }

        }

        private void TheadFunction()
        {
            Thread.Sleep(2000);
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    label1.Text = "...Đang Kiểm Tra Kết Nối Đến CSDL";
                });
            }
            else
            {
                label1.Text = "...Đang Kiểm Tra Kết Nối Đến CSDL";
            }
            Thread.Sleep(1500);
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    TestConnectDb();
                });
            }
            else
            {
                TestConnectDb();
            }

        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            label1.Text = "...Đang Mở Ứng Dụng";
            Thread th = new Thread(new ThreadStart(TheadFunction));
            th.IsBackground = true;
            th.Start();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
