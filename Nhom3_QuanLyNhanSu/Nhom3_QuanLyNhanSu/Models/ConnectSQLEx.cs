using System.Data.SqlClient;
using System.Data;
using System;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class ConnectSQLEx:ConnecSQL
    {
        protected SqlDataReader Reader(string query, CommandType type=CommandType.Text, params SqlParameter[] p) {
            OpenConnection();
            SqlDataReader read = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = type;

                if (type == CommandType.StoredProcedure) {
                    cmd.Parameters.AddRange(p);
                }

                read = cmd.ExecuteReader();
            }
            catch{
                read = null;
            }
            return read;
        }

        protected int ExecuteUpdate(string query, CommandType type=CommandType.Text, params SqlParameter[] p) {
            int result = -1;
            OpenConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = type;

                if (type == CommandType.StoredProcedure)
                {
                    cmd.Parameters.AddRange(p);
                }

                result = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                result = -1;
            }

            con.Close();

            return result;
        }

        protected int ExecuteUpdateReturnValue(string query, CommandType type = CommandType.Text, params SqlParameter[] p)
        {
            int result = -1;
            OpenConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = type;

                if (type == CommandType.StoredProcedure)
                {
                    cmd.Parameters.AddRange(p);
                }

                result = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                result = -1;
            }

            con.Close();

            return result;
        }
    }
}
