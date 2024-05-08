using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nhom3_QuanLyNhanSu.Reports
{
    public partial class Frm_Report_PhongBan : Form
    {
        public Frm_Report_PhongBan(List<Entities.PhongBan> ldata)
        {
            InitializeComponent();

            PhongBanBindingSource.DataSource = ldata;

            DateTime now = DateTime.Now;
            this.ReportPageBindingSource.DataSource = new Entities.ReportPage() { Day = now.Day, Month = now.Month, Year = now.Year, SumItem = ldata.Count, HoTenNV = NVLG.HoTenNVLG };
            this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }

        private void Frm_Report_PhongBan_Load(object sender, EventArgs e)
        {

           
        }
    }
}
