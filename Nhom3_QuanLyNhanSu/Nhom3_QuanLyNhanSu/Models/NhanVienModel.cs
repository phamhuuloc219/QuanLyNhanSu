using Nhom3_QuanLyNhanSu.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class NhanVienModel:BaseModel<NhanVien>
    {
        public override void getAllData()
        {
            dtGrid.DataSource = execQuery("select nv.MANV,hs.HO,hs.TEN,hs.GIOI_TINH,hs.NGAY_SINH,hs.SO_DT,nv.LOAI_NV,nv.PHONG,nv.CHUCVU,nv.NGAY_VAO_LAM,nv.TINH_TRANG,nv.LOAI_NV,nv.LA_ADMIN,nv.BAC_LUONG,hs.MAHS,hs.NOI_SINH,hs.HO_KHAU,hs.DC_LIEN_HE,hs.CMND,hs.DANTOC,hs.TONGIAO,hs.EMAIL,hs.NGOAI_NGU,hs.TRINH_DO_HV,hs.GHI_CHU from NHAN_VIEN nv inner join HO_SO hs on nv.MAHS=hs.MAHS order by TEN,HO");
        }

        public override void getAllData(string orderBy)
        {
           
        }

        public System.Data.DataTable getDataThanNhan()
        {
            return execQuery("select QUAN_HE,HOTEN,NAM_SINH,NGHE_NGHIEP,MAQHGD,MAHS,GIOI_TINH=case when GIOI_TINH=1 then 'Nam' else N'Nữ' end from QUAN_HE_GIA_DINH order by MAHS");
        }

        public override void getAllData(string orderBy, string key)
        {
            throw new System.NotImplementedException();
        }

        public List<DataItem> getList(string query) {
            OpenConnection();
            List<DataItem> l = new List<DataItem>();
           
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader read = cmd.ExecuteReader();

                

                while (read.Read())
                {
                    DataItem item = new DataItem();
                    item.Value = read.GetValue(0).ToString();
                    item.Name = read.GetValue(1).ToString();
                   

                    l.Add(item);
                }
                read.Close();
            }
            catch { 
                
            }
            con.Close();
            return l;
        }

        public override string[] getInfo(string query)
        {
            throw new System.NotImplementedException();
        }

        protected override void InsertNewRow(NhanVien entity)
        {
          
            insertNewRow(new string[] { entity.MaNV,entity.Ho, entity.Ten,entity.GioiTinh.ToString(), entity.NgaySinh.ToString(), entity.SoDT,entity.LoaiNV.ToString(),entity.Phong,entity.ChucVu,entity.NgayVaoLam.ToString(),
            entity.TinhTrang.ToString(),entity.LoaiNV.ToString(),entity.LaAdmin.ToString(),entity.BacLuong.ToString(),entity.MaHS,
            entity.NoiSinh,entity.HoKhau,entity.DiaChiLH,entity.CMND,entity.DanToc.ToString(),entity.TonGiao.ToString(),entity.Email,entity.NgoaiNgu,entity.TrinhDo.ToString(),entity.GhiChu});
        }

        protected override void UpdateRow(NhanVien entity)
        {
            UpdateRow(new string[] { entity.MaNV,entity.Ho, entity.Ten,entity.GioiTinh.ToString(), entity.NgaySinh.ToString(), entity.SoDT,entity.LoaiNV.ToString(),entity.Phong,entity.ChucVu,entity.NgayVaoLam.ToString(),
            entity.TinhTrang.ToString(),entity.LoaiNV.ToString(),entity.LaAdmin.ToString(),entity.BacLuong.ToString(),entity.MaHS,
            entity.NoiSinh,entity.HoKhau,entity.DiaChiLH,entity.CMND,entity.DanToc.ToString(),entity.TonGiao.ToString(),entity.Email,entity.NgoaiNgu,entity.TrinhDo.ToString(),entity.GhiChu});
        }

        private string executeReturnValueString(string query, params SqlParameter[] param)
        {
            string result = "";

            OpenConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                result = cmd.ExecuteScalar().ToString();

                cmd.Dispose();

               
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi: " + ex.Message;
                result = "";
            }
            con.Close();
            return result;
        }

        public override void insert(NhanVien entity)
        { 
            
        }

        public string insertNV(NhanVien entity)
        {
            SqlParameter HO = new SqlParameter("@HO", entity.Ho);
            SqlParameter TEN = new SqlParameter("@TEN", entity.Ten);
            SqlParameter GIOI_TINH = new SqlParameter("@GIOI_TINH", entity.GioiTinh);
            SqlParameter NGAY_SINH = new SqlParameter("@NGAY_SINH", entity.NgaySinh);
            SqlParameter NOI_SINH = new SqlParameter("@NOI_SINH", entity.NoiSinh);
            SqlParameter HO_KHAU = new SqlParameter("@HO_KHAU", entity.HoKhau);
            SqlParameter DC_LIEN_HE = new SqlParameter("@DC_LIEN_HE", entity.DiaChiLH);
            SqlParameter CMND = new SqlParameter("@CMND", entity.CMND);
            SqlParameter DANTOC = new SqlParameter("@DANTOC", entity.DanToc);
            SqlParameter TONGIAO = new SqlParameter("@TONGIAO", entity.TonGiao);
            SqlParameter SO_DT = new SqlParameter("@SO_DT", entity.SoDT);
            SqlParameter EMAIL = new SqlParameter("@EMAIL", entity.Email);
            SqlParameter NGOAI_NGU = new SqlParameter("NGOAI_NGU", entity.NgoaiNgu);
            SqlParameter TRINH_DO_HV = new SqlParameter("@TRINH_DO_HV", entity.TrinhDo);
            SqlParameter GHI_CHU = new SqlParameter("@GHI_CHU", entity.GhiChu);
            SqlParameter MANV = new SqlParameter("@MANV", entity.MaNV);
            SqlParameter NGAY_VAO_LAM = new SqlParameter("@NGAY_VAO_LAM", entity.NgayVaoLam);
            SqlParameter TINH_TRANG = new SqlParameter("@TINH_TRANG", entity.TinhTrang);
            SqlParameter LOAI_NV = new SqlParameter("@LOAI_NV", entity.LoaiNV);
            SqlParameter LA_ADMIN = new SqlParameter("@LA_ADMIN", entity.LaAdmin);
            SqlParameter PHONG = new SqlParameter("@PHONG", entity.Phong);
            SqlParameter CHUCVU = new SqlParameter("@CHUCVU", entity.ChucVu);
            SqlParameter BAC_LUONG = new SqlParameter("@BAC_LUONG", entity.BacLuong);


            string MaHS = executeReturnValueString("InsertHoSoNV", HO, TEN, GIOI_TINH, NGAY_SINH, NOI_SINH, HO_KHAU, DC_LIEN_HE,
                CMND,DANTOC,TONGIAO,SO_DT,EMAIL,NGOAI_NGU,TRINH_DO_HV,GHI_CHU,MANV,NGAY_VAO_LAM,TINH_TRANG,
                LOAI_NV,LA_ADMIN,PHONG,CHUCVU,BAC_LUONG);

            if (MaHS != "") {
                entity.MaHS = MaHS;
                InsertNewRow(entity);
                lblMessage.Text = "Thêm thành công. Mật khẩu đăng nhập là 123456";
            }

            return MaHS;
        }

        public string insertTN(string hoten,bool gioitinh, string quanhe,string namsinh,string nghenghiep,string mahs)
        {
            SqlParameter s1 = new SqlParameter("@MAHS", mahs);
            SqlParameter s2 = new SqlParameter("@HOTEN", hoten);
            SqlParameter s3 = new SqlParameter("@QUAN_HE", quanhe);
            SqlParameter s4 = new SqlParameter("@NAM_SINH",namsinh);
            SqlParameter s5 = new SqlParameter("@NGHE_NGHIEP", nghenghiep);
            SqlParameter s6 = new SqlParameter("@GIOI_TINH", gioitinh);
            return executeReturnValueString("InsertThanNhan", s1, s2, s3, s4, s5, s6);
        }

        public override void update(NhanVien entity)
        {
            SqlParameter HO = new SqlParameter("@HO", entity.Ho);
            SqlParameter TEN = new SqlParameter("@TEN", entity.Ten);
            SqlParameter GIOI_TINH = new SqlParameter("@GIOI_TINH", entity.GioiTinh);
            SqlParameter NGAY_SINH = new SqlParameter("@NGAY_SINH", entity.NgaySinh);
            SqlParameter NOI_SINH = new SqlParameter("@NOI_SINH", entity.NoiSinh);
            SqlParameter HO_KHAU = new SqlParameter("@HO_KHAU", entity.HoKhau);
            SqlParameter DC_LIEN_HE = new SqlParameter("@DC_LIEN_HE", entity.DiaChiLH);
            SqlParameter DANTOC = new SqlParameter("@DANTOC", entity.DanToc);
            SqlParameter TONGIAO = new SqlParameter("@TONGIAO", entity.TonGiao);
            SqlParameter SO_DT = new SqlParameter("@SO_DT", entity.SoDT);
            SqlParameter EMAIL = new SqlParameter("@EMAIL", entity.Email);
            SqlParameter NGOAI_NGU = new SqlParameter("NGOAI_NGU", entity.NgoaiNgu);
            SqlParameter TRINH_DO_HV = new SqlParameter("@TRINH_DO_HV", entity.TrinhDo);
            SqlParameter GHI_CHU = new SqlParameter("@GHI_CHU", entity.GhiChu);
            SqlParameter MANV = new SqlParameter("@MANV", entity.MaNV);
            SqlParameter NGAY_VAO_LAM = new SqlParameter("@NGAY_VAO_LAM", entity.NgayVaoLam);
            SqlParameter TINH_TRANG = new SqlParameter("@TINH_TRANG", entity.TinhTrang);
            SqlParameter LOAI_NV = new SqlParameter("@LOAI_NV", entity.LoaiNV);
            SqlParameter LA_ADMIN = new SqlParameter("@LA_ADMIN", entity.LaAdmin);
            SqlParameter PHONG = new SqlParameter("@PHONG", entity.Phong);
            SqlParameter CHUCVU = new SqlParameter("@CHUCVU", entity.ChucVu);
            SqlParameter BAC_LUONG = new SqlParameter("@BAC_LUONG", entity.BacLuong);
            SqlParameter MAHS = new SqlParameter("@MAHS", entity.MaHS);

            execUpdate("UpdateNV", entity, System.Data.CommandType.StoredProcedure, HO, TEN, GIOI_TINH, NGAY_SINH, NOI_SINH, HO_KHAU, DC_LIEN_HE,
                 DANTOC, TONGIAO, SO_DT, EMAIL, NGOAI_NGU, TRINH_DO_HV, GHI_CHU, MANV, NGAY_VAO_LAM, TINH_TRANG,
                LOAI_NV, LA_ADMIN, PHONG, CHUCVU, BAC_LUONG,MAHS);
        }

        protected bool execDeleteA(string query)
        {
            ResultExec rs = execute(query, System.Data.CommandType.Text);
            if (rs.resultNumber > 0)
            {
                return true;
            }
            return false;
        }

        public override void delete()
        {
            string key = BeforeDelete();
            if (key != null)
            {
                string MaHS = dtGrid.CurrentRow.Cells[14].Value.ToString();
                execDeleteA("delete QUAN_HE_GIA_DINH where MAHS='" + MaHS + "'");
                if (execDeleteA("delete NHAN_VIEN where MANV='" + key + "'"))
                {
                    execDelete("delete HO_SO where MAHS='" + MaHS + "'");
                }
            }
        }

        public int XoaTN(string MaQHGD) {
            ResultExec result = execute("delete QUAN_HE_GIA_DINH where MAQHGD=" + MaQHGD, System.Data.CommandType.Text);
            return result.resultNumber;
        }

        public int ResetPass(string manv) {
            if (execute("update NHAN_VIEN set MAT_KHAU='123456' where MANV='" + manv + "'",System.Data.CommandType.Text).resultNumber > 0) {
                return 1;
            }
            return -1;
        }
    }
}
