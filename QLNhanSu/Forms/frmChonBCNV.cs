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
    public partial class frmChonBCNV : Form
    {
        public frmChonBCNV()
        {
            InitializeComponent();
        }

        private void frmChonBCNV_Load(object sender, EventArgs e)
        {
            // Load phòng ban
            DataTable dtPB = DataProvider.ExecuteQuery("SELECT MaPB, TenPB FROM PhongBan ORDER BY MaPB");
            cbophong.DataSource = dtPB;
            cbophong.DisplayMember = "TenPB";
            cbophong.ValueMember = "MaPB";
            cbophong.SelectedIndex = -1;
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Dùng parameter thay vì nối chuỗi trực tiếp — tránh SQL Injection
            var paramList = new List<SqlParameter>();

            string wherePB = "";
            if (cbophong.SelectedValue != null)
            {
                wherePB = " AND nv.MaPB=@MaPB";
                paramList.Add(new SqlParameter("@MaPB", cbophong.SelectedValue.ToString()));
            }

            string whereTo = "";
            if (cboto.SelectedValue != null)
            {
                whereTo = " AND nv.MaTo=@MaTo";
                paramList.Add(new SqlParameter("@MaTo", cboto.SelectedValue.ToString()));
            }

            string sql = $@"SELECT 
        nv.MaNV,
        nv.HoNV + ' ' + nv.TenNV AS HoTen,
        nv.GioiTinh,
        CONVERT(NVARCHAR,nv.NgaySinh,103) AS NgaySinh,
        p.TenPB,
        cv.TenCV,
        nv.DienThoai,
        nv.TinhTrang
        FROM NhanVien nv
        LEFT JOIN PhongBan p ON nv.MaPB = p.MaPB
        LEFT JOIN ChucVu cv  ON nv.MaCV = cv.MaCV
        WHERE 1=1{wherePB}{whereTo}
        ORDER BY nv.MaNV";

            DataTable dt = DataProvider.ExecuteQuery(sql,
                paramList.Count > 0 ? paramList.ToArray() : null);

            if (dt.Rows.Count == 0)
            { MessageBox.Show("Không có dữ liệu nhân sự!"); return; }

            // Mở form xem báo cáo
            frmXemBaoCao frm = new frmXemBaoCao();
            var dsSources = new List<Microsoft.Reporting.WinForms.ReportDataSource>
            {
                new Microsoft.Reporting.WinForms.ReportDataSource("dsDanhSachNV", dt)
            };
            frm.HienThiBaoCao(
                "rptDanhSachNhanVien.rdlc",
                dsSources,
                "Danh sách nhân viên"
            );
            frm.ShowDialog();
        }
    }
}