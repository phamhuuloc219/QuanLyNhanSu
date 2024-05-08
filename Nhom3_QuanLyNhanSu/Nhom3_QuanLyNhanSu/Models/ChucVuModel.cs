namespace Nhom3_QuanLyNhanSu.Models
{
    public class ChucVuModel:BaseModel<Nhom3_QuanLyNhanSu.Entities.ChucVu>
    {

        public override void getAllData()
        {
            throw new System.NotImplementedException();
        }

        public override void getAllData(string orderBy)
        {
            dtGrid.DataSource = execQuery("select MACV,TEN_CV,PHU_CAP,(select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.CHUCVU=CHUC_VU.MACV) as SONV from CHUC_VU order by " + orderBy);
        }

        public override void getAllData(string orderBy, string key)
        {
            try
            {
                int testkey = int.Parse(key);
                dtGrid.DataSource = execQuery("select MACV,TEN_CV,PHU_CAP,(select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.CHUCVU=CHUC_VU.MACV) as SONV from CHUC_VU where PHU_CAP="+key+" OR (select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.CHUCVU=CHUC_VU.MACV)=" + key);
            }
            catch
            {
                dtGrid.DataSource = execQuery("select MACV,TEN_CV,PHU_CAP,(select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.CHUCVU=CHUC_VU.MACV) as SONV from CHUC_VU where MACV='" + key + "' or TEN_CV like N'%" + key + "%'");
            }
        }

        public override string[] getInfo(string query)
        {
            throw new System.NotImplementedException();
        }

        protected override void InsertNewRow(Entities.ChucVu entity)
        {
            insertNewRow(new string[] { entity.Ma, entity.Ten, string.Format("{0:0,0}", double.Parse(entity.PhuCap)), "0" });
        }

        protected override void UpdateRow(Entities.ChucVu entity)
        {
            UpdateRow(new string[] { entity.Ma, entity.Ten, entity.PhuCap, entity.SoNV.ToString() });
        }

        public override void insert(Entities.ChucVu entity)
        {
            execInsert("insert into CHUC_VU values('" + entity.Ma + "',N'" + entity.Ten + "',"+entity.PhuCap+")", entity);
        }

        public override void update(Entities.ChucVu entity)
        {
            execUpdate("update CHUC_VU set TEN_CV=N'" + entity.Ten + "',PHU_CAP=" + entity.PhuCap + " where MACV='"+entity.Ma+"'", entity);
        }

        public override void delete()
        {
            string key = BeforeDelete();
            if (key != null)
                execDelete("delete CHUC_VU where MACV='" + key + "'");
        }
    }
}
