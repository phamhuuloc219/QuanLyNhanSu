using Nhom3_QuanLyNhanSu.Entities;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class HocVanModel:BaseModel<HocVan>
    {
        public override void getAllData()
        {
            dtGrid.DataSource = execQuery("select MAHV as N'Mã Học Vấn',TENHV as 'Tên Học Vấn',CHUYEN_NGANH as 'Chuyên Ngành',(select count(MAHS) FROM HO_SO WHERE HO_SO.TRINH_DO_HV=HOC_VAN.MAHV) as N'Số Nhân Viên' from HOC_VAN");
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
                dtGrid.DataSource = execQuery("select MAHV as N'Mã Học Vấn',TENHV as 'Tên Học Vấn',CHUYEN_NGANH as 'Chuyên Ngành',(select count(MAHS) FROM HO_SO WHERE HO_SO.TRINH_DO_HV=HOC_VAN.MAHV) as N'Số Nhân Viên' from HOC_VAN where MAHV=" + key + " OR (select count(MAHS) FROM HO_SO WHERE HO_SO.TRINH_DO_HV=HOC_VAN.MAHV)=" + key);
            }
            catch
            {
                dtGrid.DataSource = execQuery("select MAHV as N'Mã Học Vấn',TENHV as 'Tên Học Vấn',CHUYEN_NGANH as 'Chuyên Ngành',(select count(MAHS) FROM HO_SO WHERE HO_SO.TRINH_DO_HV=HOC_VAN.MAHV) as N'Số Nhân Viên' from HOC_VAN where TENHV like N'%" + key + "%' OR CHUYEN_NGANH like '%"+key+"%'");
            }
        }

        public override string[] getInfo(string query)
        {
            throw new System.NotImplementedException();
        }

        protected override void InsertNewRow(HocVan entity)
        {
            insertNewRow(new string[] { entity.Ma, entity.Ten,entity.TenCN, "0" });
        }

        protected override void UpdateRow(HocVan entity)
        {
            UpdateRow(new string[] { entity.Ma, entity.Ten,entity.TenCN, entity.SoNV.ToString() });
        }

        public override void insert(HocVan entity)
        {
            System.Data.SqlClient.SqlParameter tenhv = new System.Data.SqlClient.SqlParameter("@TENHV", entity.Ten);
            System.Data.SqlClient.SqlParameter tencn = new System.Data.SqlClient.SqlParameter("@CHUYEN_NGANH", entity.TenCN);

            int result = execInsert("InsertHocVan", tenhv,tencn);

            if (result > 0)
            {
                entity.Ma = result.ToString();
                InsertNewRow(entity);
            }
        }

        public override void update(HocVan entity)
        {
            execUpdate("update HOC_VAN set TENHV=N'" + entity.Ten + "',CHUYEN_NGANH=N'" + entity.TenCN + "' where MAHV=" + entity.Ma, entity);
        }

        public override void delete()
        {
            string key = BeforeDelete();
            if (key != null)
                execDelete("delete HOC_VAN where MAHV=" + key + "");
        }
    }
}
