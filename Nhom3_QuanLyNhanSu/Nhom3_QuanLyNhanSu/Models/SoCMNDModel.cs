using Nhom3_QuanLyNhanSu.Entities;
using System;
using System.Data.SqlClient;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class SoCMNDModel:ConnectSQLEx
    {
        public int Insert(CMND cmnd){
            return ExecuteUpdate("insert into SO_CMND values('" + cmnd.SOCMND + "','" + cmnd.NgayCap.ToString() + "',N'" + cmnd.NoiCap + "')");
        }

        public int Edit(CMND cmnd,string CMNDCU,string MaHS) {
            return ExecuteUpdate("EditCMND", System.Data.CommandType.StoredProcedure, new SqlParameter("@CMNDCU", CMNDCU),
                new SqlParameter("@CMND", cmnd.SOCMND), new SqlParameter("@NGAY_CAP", cmnd.NgayCap),
                new SqlParameter("@NOI_CAP", cmnd.NoiCap), new SqlParameter("@MaHS", MaHS));
        }

        public CMND getInfo(string SOCMND)
        {
            CMND cmnd = null;

            try
            {
                SqlDataReader read = Reader("select NGAY_CAP,NOI_CAP from SO_CMND where CMND='" + SOCMND + "'");

                while (read.Read())
                {
                    cmnd = new CMND();
                    cmnd.NgayCap = read.GetDateTime(0);
                    cmnd.NoiCap = read.GetString(1);
                    break;
                }
                read.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            con.Close();

            return cmnd;
        }
    }
}
