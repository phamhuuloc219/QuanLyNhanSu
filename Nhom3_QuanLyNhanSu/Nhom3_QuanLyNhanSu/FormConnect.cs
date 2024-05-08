using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Nhom3_QuanLyNhanSu
{
    public partial class FormConnect : Form
    {
        public FormConnect()
        {
            InitializeComponent();
        }

        private void FormConnect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormConnect_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "Kết nối đến CSDL thất bại. \n Vui lòng thiết lập lại thông số kết nối đến CSDL.";
            cbbAuthen.SelectedIndex = 0;
        }

        private void EnableControl(bool b) {
            
            txtUserName.Enabled = b;
            txtPassWord.Enabled = b;
            label3.Enabled = b;
            label4.Enabled = b;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbAuthen.SelectedIndex == 0)
            {
                EnableControl(false);
            }
            else {
                EnableControl(true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString=null;

            if(cbbAuthen.SelectedIndex==0){
                connectionString=@"Data Source="+txtServerName.Text.Trim()+";Initial Catalog=master;Integrated Security=True";
            }else{
                connectionString = @"Data Source=" + txtServerName.Text.Trim() + ";Initial Catalog=master;User ID=" + txtUserName.Text.Trim() + ";password=" + txtPassWord.Text.Trim();
            }


            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT name FROM sys.databases WHERE name not in('master','model','msdb','tempdb')",con);

                DataTable table = new DataTable();
                da.Fill(table);

                da.Dispose();

                con.Close();

                cbbListDB.DataSource = table;
                cbbListDB.DisplayMember = "name";
                cbbListDB.ValueMember = "name";

                label5.Enabled = true;
                cbbListDB.Enabled = true;

                button1.Enabled = false;
                button2.Enabled = true;

                label1.Enabled = false;
                txtServerName.Enabled = false;

                cbbAuthen.Enabled = false;

                EnableControl(false);

            }
            catch (Exception ex) {
                button2.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbbListDB.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn 1 csdl.");
                return;
            }

            string connectionString = null;

            if (cbbAuthen.SelectedIndex == 0)
            {
                connectionString = @"Data Source=" + txtServerName.Text.Trim() + ";Initial Catalog=" + cbbListDB.SelectedValue.ToString()+ ";Integrated Security=True";
            }
            else
            {
                connectionString = @"Data Source=" + txtServerName.Text.Trim() + ";Initial Catalog=" + cbbListDB.SelectedValue.ToString() + ";User ID=" + txtUserName.Text.Trim() + ";password=" + txtPassWord.Text.Trim();
            }

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            try
            {
               

                SqlCommand cmd = new SqlCommand("TESTCONNECTION", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader ren = cmd.ExecuteReader();

                bool flag = false;

                while (ren.Read())
                {
                    if (ren[0].ToString().Equals("True")) {
                        flag = true;
                    }
                    break;
                }
                con.Close();

                if (flag)
                {
                    System.IO.File.WriteAllText("connectionString.txt", connectionString);

                    this.Hide();
                    new FrmMain().Show();
                }
                else {
                    MessageBox.Show("Vui lòng chọn đúng CSDL. Mặc định là NHOM3_QLNS");
                }
            }
            catch {
                con.Close();
                MessageBox.Show("Vui lòng chọn đúng CSDL. Mặc định là NHOM3_QLNS");
                return;
            }
            
            
        }
    }
}
