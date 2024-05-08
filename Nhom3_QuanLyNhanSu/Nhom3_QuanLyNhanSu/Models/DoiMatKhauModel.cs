using System.Data.SqlClient;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class DoiMatKhauModel:ConnectSQLEx
    {
        public string getMatKhauCu(string iduser) {
          
            SqlDataReader read = Reader("select MAT_KHAU from NHAN_VIEN where MANV='" + iduser + "'");

            string MatKhau = "";

            while (read.Read()) {
                MatKhau = read.GetValue(0).ToString();
                break;
            }

            read.Close();
            con.Close();

            return MatKhau;
        }

        public int DoiMatKhau(string iduser, string matkhau) {
            return ExecuteUpdate("update NHAN_VIEN set MAT_KHAU='" + matkhau + "'  where MANV='" + iduser + "'");
        }
    }
}
