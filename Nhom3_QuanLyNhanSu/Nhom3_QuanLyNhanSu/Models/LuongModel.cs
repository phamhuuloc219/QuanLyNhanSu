using Nhom3_QuanLyNhanSu.Entities;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class LuongModel:BaseModel<Luong>
    {
        public override void getAllData()
        {
            //throw new System.NotImplementedException();
        }

        public override void getAllData(string orderBy)
        {
            dtGrid.DataSource = execQuery("select LUONG.*,(select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.BAC_LUONG=LUONG.BACLUONG) as SONV from LUONG order by " + orderBy);
        }

        public override void getAllData(string orderBy, string key)
        {
            try
            {
                int testkey = int.Parse(key);
                dtGrid.DataSource = execQuery("select LUONG.*,(select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.BAC_LUONG=LUONG.BACLUONG) as SONV from LUONG where BACLUONG=" + key + " or LUONG_CO_BAN=" + key + " order by "+orderBy);
            }
            catch
            {
                
            }
        }

        public override string[] getInfo(string query)
        {
            throw new System.NotImplementedException();
        }

        protected override void InsertNewRow(Luong entity)
        {
            insertNewRow(new string[] { entity.MaLuong, string.Format("{0:0,0}", double.Parse(entity.BacLuong)), "0" });
        }

        protected override void UpdateRow(Luong entity)
        {
            UpdateRow(new string[] { entity.MaLuong, entity.BacLuong, entity.SoNV.ToString() });
        }

        public override void insert(Luong entity)
        {
            System.Data.SqlClient.SqlParameter bacluong = new System.Data.SqlClient.SqlParameter("@LUONG_CO_BAN", entity.BacLuong);

            int result = execInsert("InsertLuong", bacluong);

            if (result > 0)
            {
                entity.MaLuong = result.ToString();
                InsertNewRow(entity);
            }
        }

        public override void update(Luong entity)
        {
            execUpdate("update LUONG set LUONG_CO_BAN=" + entity.BacLuong + " where BACLUONG=" + entity.MaLuong, entity);
        }

        public override void delete()
        {
            string key = BeforeDelete();
            if (key != null)
                execDelete("delete LUONG where BACLUONG=" + key + "");
        }

        public System.Data.DataTable getLuongData() {
            return execQuery("select NHAN_VIEN.MANV,HO,TEN,GIOI_TINH,NGAY_SINH,CHUC_VU.TEN_CV,(CHUC_VU.PHU_CAP+DAN_TOC.PHU_CAP),LUONG.LUONG_CO_BAN as TPHU_CAP from HO_SO inner join NHAN_VIEN on HO_SO.MAHS=NHAN_VIEN.MAHS inner join CHUC_VU on NHAN_VIEN.CHUCVU=CHUC_VU.MACV inner join DAN_TOC on HO_SO.DANTOC=DAN_TOC.MADT inner join LUONG on NHAN_VIEN.BAC_LUONG=LUONG.BACLUONG order by TEN,HO");
        } 
    }
}
