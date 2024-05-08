using System;
using System.Data.SqlClient;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class ThanNhanModel:ConnectSQLEx
    {
        public int Insert(string HoTen, string GioiTinh, string QuanHe, string NamSinh, string NgheNghiep,string MaHS)
        {
            return ExecuteUpdateReturnValue("InsertThanNhan", System.Data.CommandType.StoredProcedure, new SqlParameter("@MAHS", MaHS),
                new SqlParameter("@HOTEN", HoTen), new SqlParameter("@QUAN_HE", QuanHe),
                new SqlParameter("@NAM_SINH", NamSinh), new SqlParameter("@NGHE_NGHIEP", NgheNghiep),
                new SqlParameter("@GIOI_TINH", GioiTinh.Equals("Nam")));
        }

        public int Update(string HoTen, int GioiTinh, string QuanHe, string NamSinh, string NgheNghiep, string MaQHGD) {
            return ExecuteUpdate("update QUAN_HE_GIA_DINH set HOTEN=N'" + HoTen + "',QUAN_HE=N'" + QuanHe + "',NAM_SINH='" + NamSinh + "',NGHE_NGHIEP=N'" + NgheNghiep + "',GIOI_TINH=" + GioiTinh + " where MAQHGD=" + MaQHGD);
        }
    }
}
