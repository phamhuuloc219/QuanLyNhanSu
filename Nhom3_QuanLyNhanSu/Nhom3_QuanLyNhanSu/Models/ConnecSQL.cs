using System.Data.SqlClient;
using System.Windows.Forms;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class ConnecSQL
    {
        protected static SqlConnection con = null;

        protected void OpenConnection()
        {
            if (con == null)
            {
                con = new SqlConnection(System.IO.File.ReadAllText("connectionString.txt"));
            }
            try
            {
                con.Open();
            }
            catch
            {
                MessageBox.Show("Có lỗi kết nối đến csdl. Vui lòng khởi động lại ứng dụng.");
                Application.Exit();
            }
        }
    }
}
