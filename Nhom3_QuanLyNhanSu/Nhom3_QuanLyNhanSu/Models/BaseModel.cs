using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Nhom3_QuanLyNhanSu.Models
{
    /// <summary>
    /// Kết quả trả về sau khi thực hiện 1 câu lệnh trên SQL.
    /// </summary>
    public class ResultExec{
        public int resultNumber=-1;
        public string resultText;
    }

    public abstract class BaseModel<T>:ConnecSQL
    {
        //Datagridview hiển thị danh sách
        protected DataGridView dtGrid=null;

        //Hiện thi thông báo.
        protected Label lblMessage = null;


        //Sự kiện click vào row datagridview. Dùng để hiện thị thông tin row đang được click
        //lên các textbox.
        public delegate void eventCellClick(DataGridViewRow row);

        public eventCellClick cellclick = null;

        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        public abstract void getAllData();
        /// <summary>
        /// Lấy tất cả dữ liệu và sắp xếp kết quả trả về
        /// </summary>
        /// <param name="orderBy">Sắp xếp theo</param>
        public abstract void getAllData(string orderBy);
        /// <summary>
        /// Lấy tất cả dữ liệu theo 1 từ khóa và sắp xếp kết quả trả về
        /// </summary>
        /// <param name="orderBy">Sắp xếp theo</param>
        /// <param name="key">Từ khóa tìm kiếm</param>
        public abstract void getAllData(string orderBy, string key);

        /// <summary>
        /// Lấy 1 row trong csdl
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public abstract string[] getInfo(string query);

        /// <summary>
        /// Thêm 1 row mới vào datagridview
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void InsertNewRow(T entity);
        /// <summary>
        /// Sửa 1 row trên datagridview
        /// </summary>
        /// <param name="entity"></param>
        protected abstract void UpdateRow(T entity);

        public abstract void insert(T entity);
        public abstract void update(T entity);
        public abstract void delete();


        


        protected string[] getRow(string query){
            lblMessage.Text = "...Processing...";
            OpenConnection();
            string[] data = null;
            try
            {

                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader render = cmd.ExecuteReader();

                while (render.Read()) {
                    data = new string[render.FieldCount];
                    for (int i = 0; i < render.FieldCount; i++) {
                        data[i] = render[i].ToString();
                    }

                    lblMessage.Text = "1 row(s) affected";
                }
            }
            catch (Exception ex) {
                lblMessage.Text = "Lỗi: " + ex.Message;
            }
            con.Close();

            return data;
        }

        protected DataTable execQuery(string query) {
            lblMessage.Text = "...Processing...";
            OpenConnection();

            DataTable table = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);

                
                da.Fill(table);
                da.Dispose();

                lblMessage.Text = table.Rows.Count + " row(s) affected";
            }
            catch (Exception ex) {
                lblMessage.Text = "Lỗi: " + ex.Message;
            }

            con.Close();

            return table;
        }

        protected ResultExec execute(string query,CommandType type,params SqlParameter[] param) {
            ResultExec rs = new ResultExec();

            OpenConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = type;
                if (type == CommandType.StoredProcedure) {
                    cmd.Parameters.AddRange(param);
                }
                rs.resultNumber = cmd.ExecuteNonQuery();

                rs.resultText = rs.resultNumber + " row(s) affected";

                cmd.Dispose();
            }
            catch (Exception ex) {
                rs.resultText = "Lỗi: " + ex.Message;
            }
            con.Close();
            return rs;
        }

        private ResultExec executeReturnValue(string query, params SqlParameter[] param)
        {
            ResultExec rs = new ResultExec();

            OpenConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                rs.resultNumber = int.Parse(cmd.ExecuteScalar().ToString());

                rs.resultText = rs.resultNumber + " row(s) affected";

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                rs.resultText = "Lỗi: " + ex.Message;
            }
            con.Close();
            return rs;
        }

        

        protected void insertNewRow(string[] arr) {
            DataTable table = (DataTable)dtGrid.DataSource;

            DataRow row = table.NewRow();

            for (int i = 0; i < arr.Length; i++) {
                row[i] = arr[i];
            }

            table.Rows.Add(row);

            dtGrid.ClearSelection();
            dtGrid.CurrentCell = dtGrid.Rows[dtGrid.Rows.Count - 1].Cells[0];

            cellclick(dtGrid.Rows[dtGrid.Rows.Count - 1]);
        }

        protected void UpdateRow(string[] arr)
        {
            DataGridViewRow currentRow = dtGrid.CurrentRow;

            if (currentRow != null) {
                for (int i = 0; i < arr.Length; i++)
                {
                    currentRow.Cells[i].Value = arr[i];
                }
            }
        }

        protected void execInsert(string query, T entity,CommandType type=CommandType.Text,params SqlParameter[] param)
        {
            lblMessage.Text = "...Processing...";
            ResultExec rs = execute(query,type,param);

            if (rs.resultNumber > 0) {
                InsertNewRow(entity);
                rs.resultText = "Insert Successfully";
            }

            lblMessage.Text = rs.resultText;
        }

        protected int execInsert(string query, params SqlParameter[] param)
        {
            lblMessage.Text = "...Processing...";
            ResultExec rs = executeReturnValue(query, param);

            if (rs.resultNumber > 0)
            {
                lblMessage.Text = "Insert Successfully";

                return rs.resultNumber;
            }

            lblMessage.Text = rs.resultText;
            return -1;
        }

        protected void execUpdate(string query, T entity,CommandType type=CommandType.Text,params SqlParameter[] param)
        {
            lblMessage.Text = "...Processing...";
            ResultExec rs = execute(query,type,param);

            if (rs.resultNumber > 0)
            {
                UpdateRow(entity);
            }

            lblMessage.Text = rs.resultText;
        }

        protected string BeforeDelete(int index=0) {
            
            if (dtGrid.CurrentRow == null)
            {
                lblMessage.Text = "Vui lòng chọn 1 row để xóa";
                return null;
            }

            string key=dtGrid.CurrentRow.Cells[index].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa row " + key + "?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return key;
            }
            return null;
        }

        protected void execDelete(string query, CommandType type = CommandType.Text, params SqlParameter[] param)
        {
            lblMessage.Text = "...Processing...";
            ResultExec rs = execute(query,type,param);
            if (rs.resultNumber > 0)
            {
                DeleteRow();
            }

            lblMessage.Text = rs.resultText;
            cellclick(dtGrid.CurrentRow);
        }


        public void setControl(DataGridView dtGrid, Label lblMessage)
        {
            this.dtGrid = dtGrid;
            this.lblMessage = lblMessage;
            setEventToDataGridView();

        }

        private void setEventToDataGridView() {
            if (dtGrid != null)
            {
                dtGrid.CellClick += new DataGridViewCellEventHandler(dtGrid_CellClick);
                dtGrid.KeyUp += new KeyEventHandler(dtGrid_KeyUp);
            }
        }

        void dtGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                cellclick(dtGrid.CurrentRow);
            }
        }

        public void ShowDetail(eventCellClick e) {
            cellclick = new eventCellClick(e);
        }

        void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellclick(dtGrid.CurrentRow);
        }

        private void DeleteRow() {
            if (dtGrid.CurrentRow != null)
                dtGrid.Rows.Remove(dtGrid.CurrentRow);
        }

       
    }
}
