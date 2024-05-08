using System;
using Nhom3_QuanLyNhanSu.Entities;

namespace Nhom3_QuanLyNhanSu.Models
{
    public class PhongBanModel:BaseModel<PhongBan>
    {

        public override void getAllData()
        {
            dtGrid.DataSource = execQuery("select MAPB as N'Mã Phòng',TEN_PB as N'Tên Phòng',(select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.PHONG=PHONG_BAN.MAPB) as N'Số Nhân Viên' from PHONG_BAN");
        }

        public override void getAllData(string orderBy)
        {
            dtGrid.DataSource = execQuery("select MAPB as N'Mã Phòng',TEN_PB as N'Tên Phòng',(select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.PHONG=PHONG_BAN.MAPB) as N'Số Nhân Viên' from PHONG_BAN order by "+orderBy);
        }

        public override void getAllData(string orderBy, string key)
        {
            try
            {
                int testkey = int.Parse(key);
                dtGrid.DataSource = execQuery("select MAPB as N'Mã Phòng',TEN_PB as N'Tên Phòng',(select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.PHONG=PHONG_BAN.MAPB) as N'Số Nhân Viên' from PHONG_BAN where (select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.PHONG=PHONG_BAN.MAPB)=" + key + " order by " + orderBy);
            }
            catch {
                dtGrid.DataSource = execQuery("select MAPB as N'Mã Phòng',TEN_PB as N'Tên Phòng',(select count(MANV) FROM NHAN_VIEN WHERE NHAN_VIEN.PHONG=PHONG_BAN.MAPB) as N'Số Nhân Viên' from PHONG_BAN where MAPB='" + key + "' or TEN_PB like N'%"+key+"%' order by " + orderBy);
            }
       }

        public override string[] getInfo(string query)
        {
            throw new NotImplementedException();
        }

        protected override void InsertNewRow(PhongBan entity)
        {
            insertNewRow(new string[] { entity.Ma, entity.Ten, "0"});
        }

        protected override void UpdateRow(PhongBan entity)
        {
            UpdateRow(new string[] { entity.Ma, entity.Ten, entity.SoNV.ToString() });
        }

        public override void insert(PhongBan entity)
        {
            execInsert("insert into PHONG_BAN values('"+entity.Ma+"',N'"+entity.Ten+"')",entity);
        }

        public override void update(PhongBan entity)
        {
            execUpdate("update PHONG_BAN set TEN_PB=N'" + entity.Ten + "' where MAPB='" + entity.Ma + "'",entity);
        }

        public override void delete()
        {
            string key = BeforeDelete();
            if (key != null)
                execDelete("delete PHONG_BAN where MAPB='" + key + "'");
        }
    }
}
