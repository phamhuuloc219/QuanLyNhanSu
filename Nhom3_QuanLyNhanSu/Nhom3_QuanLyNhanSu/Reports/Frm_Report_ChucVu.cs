using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nhom3_QuanLyNhanSu.Reports
{
    public partial class Frm_Report_ChucVu : Form
    {
        public Frm_Report_ChucVu(List<Entities.ChucVu> ldata)
        {
            InitializeComponent();

            ChucVuBindingSource.DataSource = ldata;

            DateTime now = DateTime.Now;
            this.ReportPageBindingSource.DataSource = new Entities.ReportPage() { Title = "DANH SÁCH CHỨC VỤ", Day = now.Day, Month = now.Month, Year = now.Year, SumItem = ldata.Count, HoTenNV = NVLG.HoTenNVLG };
            this.reportViewer1.RefreshReport();
        }

        private void Frm_Report_ChucVu_Load(object sender, EventArgs e)
        {

        }
    }
}
