using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Nhom3_QuanLyNhanSu.Reports
{
    public partial class Frm_Report_NhanVien : Form
    {
        
        public Frm_Report_NhanVien(List<Entities.ReportNhanVien> ldata,string TTitle)
        {
            InitializeComponent();

            reportNhanVienBindingSource.DataSource = ldata;

            DateTime now = DateTime.Now;
            this.reportPageBindingSource.DataSource = new Entities.ReportPage() { Title = TTitle, Day = now.Day, Month = now.Month, Year = now.Year,SumItem=ldata.Count,HoTenNV=NVLG.HoTenNVLG };
            this.reportViewer1.RefreshReport();
        }

        private void Frm_Report_NhanVien_Load(object sender, EventArgs e)
        {
           
        }
    }
}
