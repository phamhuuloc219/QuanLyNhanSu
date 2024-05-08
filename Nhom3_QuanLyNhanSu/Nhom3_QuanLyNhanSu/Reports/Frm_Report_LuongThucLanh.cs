using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Nhom3_QuanLyNhanSu.Reports
{
    public partial class Frm_Report_LuongThucLanh : Form
    {
        public Frm_Report_LuongThucLanh()
        {
            InitializeComponent();
        }

        private void Frm_Report_LuongThucLanh_Load(object sender, EventArgs e)
        {
            List<Entities.ReportLuongThucLanh> ldata = new List<Entities.ReportLuongThucLanh>();

            Nhom3_QuanLyNhanSu.Models.LuongModel model = new Models.LuongModel();
            Label lb = new Label();
            model.setControl(null, lb);
            int stt = 1;

            foreach (System.Data.DataRow row in model.getLuongData().Rows) {
                Entities.ReportLuongThucLanh item = new Entities.ReportLuongThucLanh();
                item.STT = stt++;
                item.MaNV = row[0].ToString();
                item.Ho = row[1].ToString();
                item.Ten = row[2].ToString();
                item.GioiTinh = row[3].ToString().Equals("True") ? "Nam" : "Nữ";
                DateTime ngaysinh = (DateTime)row[4];

                item.NgaySinh = ngaysinh.Day + "/" + ngaysinh.Month + "/" + ngaysinh.Year;
                item.ChucVu = row[5].ToString();
                item.PhuCap = string.Format("{0:0,0}", double.Parse(row[6].ToString()));
                item.LuongCB = string.Format("{0:0,0}", double.Parse(row[7].ToString()));
                item.ThucLanh = string.Format("{0:0,0}", double.Parse(row[6].ToString()) + double.Parse(row[7].ToString()));

                ldata.Add(item);
            }

            DateTime now = DateTime.Now;
            this.ReportPageBindingSource.DataSource = new Entities.ReportPage() { Day = now.Day, Month = now.Month, Year = now.Year, SumItem = ldata.Count, HoTenNV = NVLG.HoTenNVLG };
            this.reportLuongThucLanhBindingSource.DataSource = ldata;
            this.reportViewer1.RefreshReport();
        }
    }
}
