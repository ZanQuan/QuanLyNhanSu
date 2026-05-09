using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLNhanSu.Forms
{
    public partial class frmInHoSoNhanVien : Form
    {
        public frmInHoSoNhanVien()
        {
            InitializeComponent();
        }

        private void frmInHoSoNhanVien_Load(object sender, EventArgs e)
        {
            
        }

        public void HienThiBaoCao(string tenReport,
                                   List<ReportDataSource> dsSources,
                                   string tieuDe = "")
        {
            try
            {
                this.Text = "Báo cáo - " + tieuDe;

                string reportPath = System.IO.Path.Combine(
                    Application.StartupPath, "Reports", tenReport);

                reportViewer1.LocalReport.ReportPath = reportPath;
                reportViewer1.LocalReport.DataSources.Clear();

                foreach (var ds in dsSources)
                    reportViewer1.LocalReport.DataSources.Add(ds);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}