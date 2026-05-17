using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLNhanSu.Forms
{
    /// <summary>
    /// Báo cáo Khen Thưởng - Kỷ Luật theo tháng/năm.
    /// Quy tắc:
    ///   - Khen thưởng : ngày công >= 20 VÀ không đi trễ VÀ có tăng ca (SoGioLam > 8h)
    ///   - Kỷ luật     : ngày công <  20 HOẶC có ít nhất 1 ngày đi trễ sau 7h30
    ///   - Bình thường : còn lại
    /// </summary>
    public partial class frmBaoCaoKTKL : Form
    {
        public frmBaoCaoKTKL()
        {
            InitializeComponent();
        }
       
        private void frmBaoCaoKTKL_Load(object sender, EventArgs e)
        {
            // Mặc định: tháng/năm hiện tại
            numThang.Value = DateTime.Now.Month;
            numNam.Value = DateTime.Now.Year;

            // Combobox lọc kết quả
            cboLocKetQua.Items.AddRange(new object[]
            {
                "Tất cả", "Khen thưởng", "Kỷ luật", "Bình thường"
            });
            cboLocKetQua.SelectedIndex = 0;

            // Load phòng ban
            DataTable dtPB = DataProvider.ExecuteQuery(
                "SELECT '' AS MaPB, N'-- Tất cả phòng ban --' AS TenPB " +
                "UNION SELECT MaPB, TenPB FROM PhongBan ORDER BY TenPB");
            cboPB.DataSource = dtPB;
            cboPB.DisplayMember = "TenPB";
            cboPB.ValueMember = "MaPB";
            cboPB.SelectedIndex = 0;

            XemThongKe();
        }

        private DataTable LayDuLieu(int thang, int nam, string locKetQua, string maPB)
        {
            var paramList = new List<SqlParameter>
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam",   nam)
            };

            string wherePB = string.IsNullOrEmpty(maPB)
                ? "" : " AND nv.MaPB = @MaPB";

            if (!string.IsNullOrEmpty(maPB))
                paramList.Add(new SqlParameter("@MaPB", maPB));

            // WHERE lọc kết quả — được nhúng vào HAVING của subquery sau
            string havingFilter = "";
            if (locKetQua == "Khen thưởng")
                havingFilter = " HAVING KetQua = N'Khen thưởng'";
            else if (locKetQua == "Kỷ luật")
                havingFilter = " HAVING KetQua = N'Kỷ luật'";
            else if (locKetQua == "Bình thường")
                havingFilter = " HAVING KetQua = N'Bình thường'";

            string sql = $@"
SELECT
    nv.MaNV,
    nv.HoNV + N' ' + nv.TenNV                                        AS HoTen,
    ISNULL(pb.TenPB, N'')                                             AS TenPB,
    ISNULL(cv.TenCV, N'')                                             AS TenCV,

    -- Số ngày công hoàn thành
    COUNT(CASE WHEN cc.TrangThai = N'Hoàn thành' THEN 1 END)         AS SoNgayCong,

    -- Số ngày đi trễ (GioBatDau > 07:30:00)
    COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00'
               AND cc.TrangThai = N'Hoàn thành' THEN 1 END)          AS SoNgayDiTre,

    -- Số ngày tăng ca (SoGioLam > 8 giờ)
    COUNT(CASE WHEN cc.SoGioLam > 8
               AND cc.TrangThai = N'Hoàn thành' THEN 1 END)          AS SoNgayTangCa,

    -- Xác định kết quả
    CASE
        WHEN COUNT(CASE WHEN cc.TrangThai = N'Hoàn thành' THEN 1 END) < 20
             OR COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00'
                           AND cc.TrangThai = N'Hoàn thành' THEN 1 END) > 0
            THEN N'Kỷ luật'

        WHEN COUNT(CASE WHEN cc.TrangThai = N'Hoàn thành' THEN 1 END) >= 20
             AND COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00'
                            AND cc.TrangThai = N'Hoàn thành' THEN 1 END) = 0
             AND COUNT(CASE WHEN cc.SoGioLam > 8
                            AND cc.TrangThai = N'Hoàn thành' THEN 1 END) > 0
            THEN N'Khen thưởng'

        ELSE N'Bình thường'
    END                                                               AS KetQua,

    -- Lý do tự động
    CASE
        WHEN COUNT(CASE WHEN cc.TrangThai = N'Hoàn thành' THEN 1 END) < 20
             AND COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00'
                            AND cc.TrangThai = N'Hoàn thành' THEN 1 END) > 0
            THEN N'Ngày công dưới 20 ngày và có ngày đi trễ'

        WHEN COUNT(CASE WHEN cc.TrangThai = N'Hoàn thành' THEN 1 END) < 20
            THEN N'Ngày công dưới 20 ngày'

        WHEN COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00'
                        AND cc.TrangThai = N'Hoàn thành' THEN 1 END) > 0
            THEN N'Có ' +
                 CAST(COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00'
                                 AND cc.TrangThai = N'Hoàn thành' THEN 1 END) AS NVARCHAR)
                 + N' ngày đi trễ sau 7h30'

        WHEN COUNT(CASE WHEN cc.SoGioLam > 8
                        AND cc.TrangThai = N'Hoàn thành' THEN 1 END) > 0
             AND COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00'
                            AND cc.TrangThai = N'Hoàn thành' THEN 1 END) = 0
            THEN N'Đủ công, đúng giờ, có ' +
                 CAST(COUNT(CASE WHEN cc.SoGioLam > 8
                                 AND cc.TrangThai = N'Hoàn thành' THEN 1 END) AS NVARCHAR)
                 + N' ngày tăng ca'

        ELSE N'Đủ công, đúng giờ, không tăng ca'
    END                                                               AS LyDo

FROM NhanVien nv
LEFT JOIN ChamCong cc
       ON nv.MaNV = cc.MaNV
      AND MONTH(cc.NgayChamCong) = @Thang
      AND YEAR(cc.NgayChamCong)  = @Nam
LEFT JOIN PhongBan pb ON nv.MaPB = pb.MaPB
LEFT JOIN ChucVu   cv ON nv.MaCV = cv.MaCV
WHERE nv.TinhTrang = N'Đang làm' {wherePB}
GROUP BY nv.MaNV, nv.HoNV, nv.TenNV, pb.TenPB, cv.TenCV
{havingFilter}
ORDER BY
    CASE WHEN CASE
        WHEN COUNT(CASE WHEN cc.TrangThai=N'Hoàn thành' THEN 1 END) < 20
             OR  COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00' AND cc.TrangThai=N'Hoàn thành' THEN 1 END) > 0
        THEN N'Kỷ luật'
        WHEN COUNT(CASE WHEN cc.TrangThai=N'Hoàn thành' THEN 1 END) >= 20
             AND COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00' AND cc.TrangThai=N'Hoàn thành' THEN 1 END) = 0
             AND COUNT(CASE WHEN cc.SoGioLam > 8 AND cc.TrangThai=N'Hoàn thành' THEN 1 END) > 0
        THEN N'Khen thưởng'
        ELSE N'Bình thường' END = N'Kỷ luật' THEN 1
        WHEN CASE
        WHEN COUNT(CASE WHEN cc.TrangThai=N'Hoàn thành' THEN 1 END) < 20
             OR  COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00' AND cc.TrangThai=N'Hoàn thành' THEN 1 END) > 0
        THEN N'Kỷ luật'
        WHEN COUNT(CASE WHEN cc.TrangThai=N'Hoàn thành' THEN 1 END) >= 20
             AND COUNT(CASE WHEN CAST(cc.GioBatDau AS TIME) > '07:30:00' AND cc.TrangThai=N'Hoàn thành' THEN 1 END) = 0
             AND COUNT(CASE WHEN cc.SoGioLam > 8 AND cc.TrangThai=N'Hoàn thành' THEN 1 END) > 0
        THEN N'Khen thưởng'
        ELSE N'Bình thường' END = N'Khen thưởng' THEN 2
        ELSE 3 END,
    nv.MaNV";

            return DataProvider.ExecuteQuery(sql, paramList.ToArray());
        }

        //  XEM THỐNG KÊ NHANH TRÊN FORM
        private void XemThongKe()
        {
            int thang = (int)numThang.Value;
            int nam = (int)numNam.Value;
            string maPB = cboPB.SelectedValue?.ToString() ?? "";

            DataTable dt = LayDuLieu(thang, nam, "Tất cả", maPB);
            dgvKetQua.DataSource = dt;

            // Đếm
            int soKT = 0, soKL = 0, soBT = 0;
            foreach (DataRow r in dt.Rows)
            {
                string kq = r["KetQua"].ToString();
                if (kq == "Khen thưởng") soKT++;
                else if (kq == "Kỷ luật") soKL++;
                else soBT++;
            }

            lblThongKe.Text =
                $"Tổng: {dt.Rows.Count} NV   |   " +
                $"🌟 Khen thưởng: {soKT}   |   " +
                $"⚠ Kỷ luật: {soKL}   |   " +
                $"✔ Bình thường: {soBT}";

            // Tô màu dòng
            TomauDgv();
        }

        private void TomauDgv()
        {
            foreach (DataGridViewRow row in dgvKetQua.Rows)
            {
                if (row.IsNewRow) continue;
                string kq = row.Cells["KetQua"].Value?.ToString() ?? "";
                switch (kq)
                {
                    case "Khen thưởng":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 245, 200);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(20, 100, 20);
                        break;
                    case "Kỷ luật":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 210, 210);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(160, 0, 0);
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }
        //  SỰ KIỆN
        private void btnXem_Click(object sender, EventArgs e)
        {
            XemThongKe();
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            int thang = (int)numThang.Value;
            int nam = (int)numNam.Value;
            string locKetQua = cboLocKetQua.SelectedItem?.ToString() ?? "Tất cả";
            string maPB = cboPB.SelectedValue?.ToString() ?? "";

            DataTable dt = LayDuLieu(thang, nam, locKetQua, maPB);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phù hợp để in báo cáo!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Đếm để truyền vào parameter
            int soKhenThuong = 0, soKyLuat = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r["KetQua"].ToString() == "Khen thưởng") soKhenThuong++;
                else if (r["KetQua"].ToString() == "Kỷ luật") soKyLuat++;
            }

            string filter = locKetQua == "Tất cả" ? "" : $" - Lọc: {locKetQua}";
            string tieuDe = $"Tháng {thang:D2} / Năm {nam}{filter}";

            var dsSources = new List<Microsoft.Reporting.WinForms.ReportDataSource>
            {
                new Microsoft.Reporting.WinForms.ReportDataSource("dsKhenThuongKyLuat", dt)
            };

            var parameters = new List<Microsoft.Reporting.WinForms.ReportParameter>
            {
                new Microsoft.Reporting.WinForms.ReportParameter("TieuDeTrangThai", tieuDe),
                new Microsoft.Reporting.WinForms.ReportParameter("SoKhenThuong", soKhenThuong.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("SoKyLuat", soKyLuat.ToString())
            };

            frmXemBaoCao frm = new frmXemBaoCao();
            frm.HienThiBaoCaoVoiParameter(
                "rptKhenThuongKyLuat.rdlc",
                dsSources,
                parameters,
                $"Khen Thưởng - Kỷ Luật ({tieuDe})"
            );
            frm.ShowDialog();
        }
        private void numThang_ValueChanged(object sender, EventArgs e) => XemThongKe();
        private void numNam_ValueChanged(object sender, EventArgs e) => XemThongKe();
        private void cboPB_SelectedIndexChanged(object sender, EventArgs e) => XemThongKe();
    }
}