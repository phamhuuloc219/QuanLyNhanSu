using Nhom3_QuanLyNhanSu.Entities;
using System.Data.SqlClient;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class DanTocModel:BaseModel<DanToc>
    {

        public override void getAllData()
        {
            dtGrid.DataSource = execQuery("select MADT as N'Mã Dân Tộc',TEN_DT as 'Tên Dân Tộc',PHU_CAP as N'Phụ Cấp',(select count(MAHS) FROM HO_SO WHERE HO_SO.DANTOC=DAN_TOC.MADT) as N'Số Nhân Viên' from DAN_TOC");
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
                dtGrid.DataSource = execQuery("select MADT as N'Mã Dân Tộc',TEN_DT as 'Tên Dân Tộc',PHU_CAP as N'Phụ Cấp',(select count(MAHS) FROM HO_SO WHERE HO_SO.DANTOC=DAN_TOC.MADT) as N'Số Nhân Viên' from DAN_TOC where MADT="+key+" or PHU_CAP=" + key + " OR (select count(MAHS) FROM HO_SO WHERE HO_SO.DANTOC=DAN_TOC.MADT)=" + key);
            }
            catch
            {
                dtGrid.DataSource = execQuery("select MADT as N'Mã Dân Tộc',TEN_DT as 'Tên Dân Tộc',PHU_CAP as N'Phụ Cấp',(select count(MAHS) FROM HO_SO WHERE HO_SO.DANTOC=DAN_TOC.MADT) as N'Số Nhân Viên' from DAN_TOC where TEN_DT like N'%" + key + "%'");
            }
        }

        public override string[] getInfo(string query)
        {
            throw new System.NotImplementedException();
        }

        protected override void InsertNewRow(DanToc entity)
        {
            insertNewRow(new string[] { entity.Ma, entity.Ten, string.Format("{0:0,0}", double.Parse(entity.PhuCap)), "0" });
        }

        protected override void UpdateRow(DanToc entity)
        {
            UpdateRow(new string[] { entity.Ma, entity.Ten, entity.PhuCap, entity.SoNV.ToString() });
        }

        public override void insert(DanToc entity)
        {
            SqlParameter tendt = new SqlParameter("@TEN_DT",entity.Ten);
            SqlParameter phucap = new SqlParameter("@PHU_CAP", entity.PhuCap);

            int result=execInsert("InsertDanToc",tendt,phucap);

            if (result > 0) { 
                entity.Ma=result.ToString();
                InsertNewRow(entity);
            }
        }

        public override void update(DanToc entity)
        {
            execUpdate("update DAN_TOC set TEN_DT=N'" + entity.Ten + "',PHU_CAP=" + entity.PhuCap + " where MADT=" + entity.Ma, entity);
        }

        public override void delete()
        {
            string key = BeforeDelete();
            if (key != null)
                execDelete("delete DAN_TOC where MADT=" + key + "");
        }
    }
}
