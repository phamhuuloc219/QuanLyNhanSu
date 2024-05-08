namespace Nhom3_QuanLyNhanSu.Reports
{
    partial class Frm_Report_PhongBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportPageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PhongBanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReportPageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhongBanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportPageBindingSource
            // 
            this.ReportPageBindingSource.DataSource = typeof(Nhom3_QuanLyNhanSu.Entities.ReportPage);
            // 
            // PhongBanBindingSource
            // 
            this.PhongBanBindingSource.DataSource = typeof(Nhom3_QuanLyNhanSu.Entities.PhongBan);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReportPageBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.PhongBanBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Nhom3_QuanLyNhanSu.Reports.Report_PhongBan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(930, 468);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // Frm_Report_PhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 468);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Report_PhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất Danh Sách Phòng Ban";
            this.Load += new System.EventHandler(this.Frm_Report_PhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportPageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhongBanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReportPageBindingSource;
        private System.Windows.Forms.BindingSource PhongBanBindingSource;
    }
}