using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu.Forms
{
    public partial class frmXemBaoCao : Form
    {
        public frmXemBaoCao()
        {
            InitializeComponent();
        }

        // Gọi từ bên ngoài để hiển thị báo cáo
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
        public void HienThiBaoCaoVoiParameter(string tenReport,
                                       List<ReportDataSource> dsSources,
                                       List<ReportParameter> parameters,
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

                if (parameters != null && parameters.Count > 0)
                    reportViewer1.LocalReport.SetParameters(parameters);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmXemBaoCao_Load(object sender, EventArgs e)
        {
        }
    }
}
