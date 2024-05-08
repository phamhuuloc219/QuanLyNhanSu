namespace Nhom3_QuanLyNhanSu.Entities
{
    public class NhanVien:NhanVienLogin
    {
        public bool GioiTinh { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string HoKhau { get; set; }
        public string DiaChiLH { get; set; }
        public string CMND { get; set; }
        public int DanToc { get; set; }
        public int TonGiao { get; set; }
        public string SoDT { get; set; }
        public string Email { get; set; }
        public string NgoaiNgu { get; set; }
        public int TrinhDo { get; set; }
        public string GhiChu;

        public string MaHS { get; set; }
        public System.DateTime NgayVaoLam { get; set; }
        public int TinhTrang { get; set; }
        public int LoaiNV { get; set; }
        public string Phong { get; set; }
        public string ChucVu { get; set; }
        public int BacLuong { get; set; }


    }
}
