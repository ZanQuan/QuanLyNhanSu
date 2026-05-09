using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu.Forms
{
    public partial class frmChonBCLuong : Form
    {
        public frmChonBCLuong()
        {
            InitializeComponent();
        }

        private void frmChonBCLuong_Load(object sender, EventArgs e)
        {
            // Phòng ban
            DataTable dtPB = DataProvider.ExecuteQuery("SELECT MaPB, TenPB FROM PhongBan ORDER BY MaPB");
            cbophong.DataSource = dtPB;
            cbophong.DisplayMember = "TenPB";
            cbophong.ValueMember = "MaPB";
            cbophong.SelectedIndex = -1;

            // Tháng/Năm báo cáo lương
            for (int i = 1; i <= 12; i++) cbothangbc.Items.Add(i);
            cbothangbc.SelectedItem = DateTime.Now.Month;
            for (int y = DateTime.Now.Year - 2; y <= DateTime.Now.Year + 1; y++) cbonambc.Items.Add(y);
            cbonambc.SelectedItem = DateTime.Now.Year;

            // Tháng/Năm BHXH
            for (int i = 1; i <= 12; i++) cbothangbh.Items.Add(i);
            cbothangbh.SelectedItem = DateTime.Now.Month;
            for (int y = DateTime.Now.Year - 2; y <= DateTime.Now.Year + 1; y++) cbonambh.Items.Add(y);
            cbonambh.SelectedItem = DateTime.Now.Year;
        }

        private void cbophong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbophong.SelectedValue == null) return;
            DataTable dtTo = DataProvider.ExecuteQuery(
                "SELECT MaTo, TenTo FROM To_ WHERE MaPB=@MaPB ORDER BY MaTo",
                new[] { new SqlParameter("@MaPB", cbophong.SelectedValue.ToString()) });
            cboto.DataSource = dtTo;
            cboto.DisplayMember = "TenTo";
            cboto.ValueMember = "MaTo";
            cboto.SelectedIndex = -1;
        }

        // Nút In báo cáo lương
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (cbothangbc.SelectedItem == null || cbonambc.SelectedItem == null)
            { MessageBox.Show("Chọn tháng và năm!"); return; }

            int thang = (int)cbothangbc.SelectedItem;
            int nam = (int)cbonambc.SelectedItem;

            // Dùng parameter thay vì nối chuỗi trực tiếp — tránh SQL Injection
            var paramList = new List<SqlParameter>
            {
                new SqlParameter("@T", thang),
                new SqlParameter("@N", nam)
            };

            string wherePB = "";
            if (cbophong.SelectedValue != null)
            {
                wherePB = " AND nv.MaPB=@MaPB";
                paramList.Add(new SqlParameter("@MaPB", cbophong.SelectedValue.ToString()));
            }

            string sql = $@"SELECT 
        nv.MaNV,
        nv.HoNV + ' ' + nv.TenNV AS HoTen,
        p.TenPB,
        bl.LuongCoBan,
        bl.NgayCongChuan AS NgayCong,
        bl.LuongNgayCong,
        bl.LuongTangCa,
        bl.PhuCap,
        bl.BHXHvaBHYT,
        bl.ThuCLanh
        FROM BangLuong bl
        JOIN NhanVien nv ON bl.MaNV = nv.MaNV
        LEFT JOIN PhongBan p ON nv.MaPB = p.MaPB
        WHERE bl.Thang=@T AND bl.Nam=@N{wherePB}
        ORDER BY nv.MaPB, nv.MaNV";

            DataTable dt = DataProvider.ExecuteQuery(sql, paramList.ToArray());

            if (dt.Rows.Count == 0)
            { MessageBox.Show($"Không có dữ liệu lương tháng {thang}/{nam}!"); return; }

            frmXemBaoCao frm = new frmXemBaoCao();
            var dsSources = new List<Microsoft.Reporting.WinForms.ReportDataSource>
            {
                new Microsoft.Reporting.WinForms.ReportDataSource("dsBangLuong", dt)
            };
            frm.HienThiBaoCao(
                "rptBangLuong.rdlc",
                dsSources,
                $"Bảng lương tháng {thang}/{nam}"
            );
            frm.ShowDialog();
        }
        // Nút In báo cáo bảo hiểm
        private void btnInBH_Click(object sender, EventArgs e)
        {
            if (cbothangbh.SelectedItem == null || cbonambh.SelectedItem == null)
            { MessageBox.Show("Chọn tháng và năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int thang = (int)cbothangbh.SelectedItem;
            int nam = (int)cbonambh.SelectedItem;

            var paramList = new List<SqlParameter>
            {
                new SqlParameter("@T", thang),
                new SqlParameter("@N", nam)
            };

            string sql = @"SELECT
                nv.MaNV,
                nv.HoNV + ' ' + nv.TenNV AS HoTen,
                p.TenPB,
                ISNULL(nv.SoBHXH, '') AS SoBHXH,
                ISNULL(nv.SoBHYT, '') AS SoBHYT,
                bl.LuongCoBan,
                bl.BHXHvaBHYT
            FROM BangLuong bl
            JOIN NhanVien nv ON bl.MaNV = nv.MaNV
            LEFT JOIN PhongBan p ON nv.MaPB = p.MaPB
            WHERE bl.Thang = @T AND bl.Nam = @N
            ORDER BY nv.MaPB, nv.MaNV";

            DataTable dt = DataProvider.ExecuteQuery(sql, paramList.ToArray());

            if (dt.Rows.Count == 0)
            { MessageBox.Show($"Không có dữ liệu bảo hiểm tháng {thang}/{nam}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            frmXemBaoCao frm = new frmXemBaoCao();
            var dsSources = new List<Microsoft.Reporting.WinForms.ReportDataSource>
            {
                new Microsoft.Reporting.WinForms.ReportDataSource("dsBaoCaoBaoHiem", dt)
            };
            frm.HienThiBaoCao(
                "rptBaoCaoBaoHiem.rdlc",
                dsSources,
                $"Báo cáo bảo hiểm tháng {thang}/{nam}"
            );
            frm.ShowDialog();
        }
    }
}