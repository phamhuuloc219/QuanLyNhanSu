
namespace Nhom3_QuanLyNhanSu.Models
{
    public class TestConnection
    {
        public bool Test() {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.IO.File.ReadAllText("connectionString.txt"));

            try
            {
                con.Open();

                return true;
            }
            catch {
                return false;
            }
        }
    }
}
