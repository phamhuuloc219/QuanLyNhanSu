using Nhom3_QuanLyNhanSu.Entities;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class TonGiaoModel:BaseModel<TonGiao>
    {

        public override void getAllData()
        {
            dtGrid.DataSource = execQuery("select MATG as N'Mã Tôn Giáo',TEN_TG as 'Tên Tôn Giáo',(select count(MAHS) FROM HO_SO WHERE HO_SO.TONGIAO=TON_GIAO.MATG) as N'Số Nhân Viên' from TON_GIAO");
        }

        public override void getAllData(string orderBy)
        {
            throw new System.NotImplementedException();
        }

        public override void getAllData(string orderBy, string key)
        {
            try
            {
                int testkey = int.Parse(key);
                dtGrid.DataSource = execQuery("select MATG as N'Mã Tôn Giáo',TEN_TG as 'Tên Tôn Giáo',(select count(MAHS) FROM HO_SO WHERE HO_SO.TONGIAO=TON_GIAO.MATG) as N'Số Nhân Viên' from TON_GIAO where MATG=" + key + " OR (select count(MAHS) FROM HO_SO WHERE HO_SO.TONGIAO=TON_GIAO.MATG)=" + key);
            }
            catch
            {
                dtGrid.DataSource = execQuery("select MATG as N'Mã Tôn Giáo',TEN_TG as 'Tên Tôn Giáo',(select count(MAHS) FROM HO_SO WHERE HO_SO.TONGIAO=TON_GIAO.MATG) as N'Số Nhân Viên' from TON_GIAO where TEN_TG like N'%" + key + "%'");
            }
        }

        public override string[] getInfo(string query)
        {
            throw new System.NotImplementedException();
        }

        protected override void InsertNewRow(TonGiao entity)
        {
            insertNewRow(new string[] { entity.Ma, entity.Ten, "0" });
        }

        protected override void UpdateRow(TonGiao entity)
        {
            UpdateRow(new string[] { entity.Ma, entity.Ten, entity.SoNV.ToString() });
        }

        public override void insert(TonGiao entity)
        {
            System.Data.SqlClient.SqlParameter tendt = new System.Data.SqlClient.SqlParameter("@TEN_TG", entity.Ten);

            int result = execInsert("InsertTonGiao", tendt);

            if (result > 0)
            {
                entity.Ma = result.ToString();
                InsertNewRow(entity);
            }
        }

        public override void update(TonGiao entity)
        {
            execUpdate("update TON_GIAO set TEN_TG=N'" + entity.Ten + "' where MATG=" + entity.Ma, entity);
        }

        public override void delete()
        {
            string key = BeforeDelete();
            if (key != null)
                execDelete("delete TON_GIAO where MATG=" + key + "");
        }
    }
}
