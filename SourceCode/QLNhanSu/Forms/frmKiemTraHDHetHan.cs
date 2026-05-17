using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLNhanSu.Forms
{
    public partial class frmKiemTraHDHetHan : Form
    {
        public frmKiemTraHDHetHan()
        {
            InitializeComponent();
        }

        private void frmKiemTraHDHetHan_Load(object sender, EventArgs e)
        {
            LoadComboThangNam();
            FormatDataGridView();
            // Mặc định: hiển thị HĐ hết hạn trong 30 ngày tới
            KiemTraHDHetHan(null, null);
        }

        // HÀM PHỤ TRỢ
        private void LoadComboThangNam()
        {
            // Tháng 1-12
            cbothangkt.Items.Clear();
            cbothangkt.Items.Add("-- Tất cả --");
            for (int i = 1; i <= 12; i++)
                cbothangkt.Items.Add("Tháng " + i);
            cbothangkt.SelectedIndex = 0;

            // Năm: năm hiện tại ± 3
            int namHienTai = DateTime.Now.Year;
            cbonamkt.Items.Clear();
            cbonamkt.Items.Add("-- Tất cả --");
            for (int y = namHienTai - 1; y <= namHienTai + 3; y++)
                cbonamkt.Items.Add(y.ToString());
            // Mặc định chọn năm hiện tại
            cbonamkt.SelectedItem = namHienTai.ToString();
        }

        private void FormatDataGridView()
        {
            dgv_NV_HopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_NV_HopDong.RowHeadersVisible = false;
            dgv_NV_HopDong.AllowUserToAddRows = false;
            dgv_NV_HopDong.ReadOnly = true;
            dgv_NV_HopDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_NV_HopDong.DefaultCellStyle.Font = new Font("Times New Roman", 10);
            dgv_NV_HopDong.ColumnHeadersDefaultCellStyle.Font =
                new Font("Times New Roman", 10, FontStyle.Bold);
            dgv_NV_HopDong.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgv_NV_HopDong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_NV_HopDong.EnableHeadersVisualStyles = false;
        }

        // LOAD DỮ LIỆU — HỢP ĐỒNG HẾT HẠN
        private void KiemTraHDHetHan(int? thang, int? nam)
        {
            string dieuKienThoiGian;
            SqlParameter[] parameters;

            if (thang.HasValue && nam.HasValue)
            {
                // Lọc theo tháng + năm cụ thể
                dieuKienThoiGian = @"
                    AND MONTH(hd.NgayKetThuc) = @Thang
                    AND YEAR(hd.NgayKetThuc)  = @Nam";
                parameters = new[]
                {
                    new SqlParameter("@Thang", thang.Value),
                    new SqlParameter("@Nam",   nam.Value)
                };
            }
            else if (nam.HasValue)
            {
                // Lọc theo năm cụ thể (tất cả tháng)
                dieuKienThoiGian = "AND YEAR(hd.NgayKetThuc) = @Nam";
                parameters = new[] { new SqlParameter("@Nam", nam.Value) };
            }
            else
            {
                // Mặc định: 30 ngày tới
                dieuKienThoiGian = @"
                    AND hd.NgayKetThuc >= DATEADD(DAY, -0, CAST(GETDATE() AS DATE))
                    AND hd.NgayKetThuc <= DATEADD(DAY, 30, GETDATE())";
                parameters = null;
            }

            string sql = $@"
                SELECT
                    hd.MaHD                                    AS sohd,
                    nv.MaNV                                    AS manv,
                    nv.HoNV                                    AS ho,
                    nv.TenNV                                   AS ten,
                    nv.HoNV + N' ' + nv.TenNV                 AS HoTen,
                    ISNULL(pb.TenPB, N'Chưa phân')             AS tenphong,
                    ISNULL(t.TenTo,  N'Chưa phân')             AS tento,
                    ISNULL(lhd.TenLoai, N'')                   AS LoaiHD,
                    hd.NgayKy,
                    hd.NgayKetThuc                             AS ngaykt,
                    DATEDIFF(DAY, GETDATE(), hd.NgayKetThuc)   AS SoNgayConLai
                FROM HopDong hd
                JOIN  NhanVien    nv  ON hd.MaNV      = nv.MaNV
                JOIN  LoaiHopDong lhd ON hd.MaLoaiHD  = lhd.MaLoaiHD
                LEFT JOIN PhongBan pb ON nv.MaPB       = pb.MaPB
                LEFT JOIN To_      t  ON nv.MaTo       = t.MaTo
                WHERE hd.NgayKetThuc IS NOT NULL
                {dieuKienThoiGian}
                ORDER BY hd.NgayKetThuc ASC";

            DataTable dt = DataProvider.ExecuteQuery(sql, parameters);
            dgv_NV_HopDong.DataSource = dt;

            // Ẩn cột không cần hiển thị
            HideColumnIfExists("sohd");
            HideColumnIfExists("ho");
            HideColumnIfExists("ten");
            HideColumnIfExists("HoTen");
            HideColumnIfExists("NgayKy");

            // Đổi tên cột hiển thị
            SetColumnHeader("manv", "Mã NV");
            SetColumnHeader("tenphong", "Phòng Ban");
            SetColumnHeader("tento", "Tổ");
            SetColumnHeader("LoaiHD", "Loại Hợp Đồng");
            SetColumnHeader("ngaykt", "Ngày Kết Thúc");
            SetColumnHeader("SoNgayConLai", "Số Ngày Còn Lại");

            // Thêm cột "Họ Tên" hiển thị thay thế ho+ten
            if (!dgv_NV_HopDong.Columns.Contains("colHoTen"))
            {
                var colHT = new DataGridViewTextBoxColumn
                {
                    Name = "colHoTen",
                    HeaderText = "Họ Tên",
                    DataPropertyName = "HoTen",
                    DisplayIndex = 1
                };
                dgv_NV_HopDong.Columns.Insert(1, colHT);
            }

            // Tô màu theo trạng thái
            TomauDongDuLieu();

            // Cập nhật tiêu đề form
            int soLuong = dt.Rows.Count;
            this.Text = $"Kiểm tra hợp đồng hết hạn — {soLuong} hợp đồng";
        }

        private void HideColumnIfExists(string colName)
        {
            if (dgv_NV_HopDong.Columns.Contains(colName))
                dgv_NV_HopDong.Columns[colName].Visible = false;
        }

        private void SetColumnHeader(string colName, string header)
        {
            if (dgv_NV_HopDong.Columns.Contains(colName))
                dgv_NV_HopDong.Columns[colName].HeaderText = header;
        }

        private void TomauDongDuLieu()
        {
            foreach (DataGridViewRow row in dgv_NV_HopDong.Rows)
            {
                if (row.Cells["SoNgayConLai"].Value == null) continue;
                int soNgay = Convert.ToInt32(row.Cells["SoNgayConLai"].Value);

                if (soNgay < 0)
                {
                    // Đã hết hạn → đỏ
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (soNgay <= 7)
                {
                    // Hết hạn trong 7 ngày → cam đậm
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 180, 100);
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (soNgay <= 30)
                {
                    // Hết hạn trong 30 ngày → vàng nhạt
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 180);
                    row.DefaultCellStyle.ForeColor = Color.DarkOliveGreen;
                }
                else
                {
                    // Còn nhiều thời gian → xanh nhạt
                    row.DefaultCellStyle.BackColor = Color.FromArgb(200, 240, 200);
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }
        // NÚT XEM — LỌC THEO THÁNG/NĂM
        

        // NÚT IN — IN BÁO CÁO HĐ HẾT HẠN
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgv_NV_HopDong.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy lại data cho báo cáo
            int? thang = null, nam = null;
            if (cbothangkt.SelectedIndex > 0) thang = cbothangkt.SelectedIndex;
            if (cbonamkt.SelectedIndex > 0 && int.TryParse(cbonamkt.SelectedItem.ToString(), out int y)) nam = y;

            string dieuKienThoiGian;
            SqlParameter[] parameters;

            if (thang.HasValue && nam.HasValue)
            {
                dieuKienThoiGian = "AND MONTH(hd.NgayKetThuc)=@Thang AND YEAR(hd.NgayKetThuc)=@Nam";
                parameters = new[] { new SqlParameter("@Thang", thang.Value), new SqlParameter("@Nam", nam.Value) };
            }
            else if (nam.HasValue)
            {
                dieuKienThoiGian = "AND YEAR(hd.NgayKetThuc)=@Nam";
                parameters = new[] { new SqlParameter("@Nam", nam.Value) };
            }
            else
            {
                dieuKienThoiGian = "AND hd.NgayKetThuc >= CAST(GETDATE() AS DATE) AND hd.NgayKetThuc <= DATEADD(DAY,30,GETDATE())";
                parameters = null;
            }

            string sql = $@"
                SELECT
                    ROW_NUMBER() OVER (ORDER BY hd.NgayKetThuc) AS STT,
                    nv.MaNV,
                    nv.HoNV + N' ' + nv.TenNV                AS HoTen,
                    ISNULL(pb.TenPB, N'Chưa phân')            AS TenPhong,
                    ISNULL(t.TenTo,  N'Chưa phân')            AS TenTo,
                    ISNULL(lhd.TenLoai, N'')                  AS LoaiHD,
                    hd.MaHD                                   AS SoHD,
                    CONVERT(VARCHAR,hd.NgayKy,103)            AS NgayKy,
                    CONVERT(VARCHAR,hd.NgayKetThuc,103)       AS NgayKetThuc,
                    DATEDIFF(DAY,GETDATE(),hd.NgayKetThuc)    AS SoNgayConLai,
                    CASE
                        WHEN DATEDIFF(DAY,GETDATE(),hd.NgayKetThuc) < 0  THEN N'Đã hết hạn'
                        WHEN DATEDIFF(DAY,GETDATE(),hd.NgayKetThuc) <= 7 THEN N'Sắp hết hạn (≤7 ngày)'
                        WHEN DATEDIFF(DAY,GETDATE(),hd.NgayKetThuc) <= 30 THEN N'Sắp hết hạn (≤30 ngày)'
                        ELSE N'Còn hạn'
                    END AS TrangThai
                FROM HopDong hd
                JOIN  NhanVien    nv  ON hd.MaNV     = nv.MaNV
                JOIN  LoaiHopDong lhd ON hd.MaLoaiHD = lhd.MaLoaiHD
                LEFT JOIN PhongBan pb ON nv.MaPB      = pb.MaPB
                LEFT JOIN To_      t  ON nv.MaTo      = t.MaTo
                WHERE hd.NgayKetThuc IS NOT NULL
                {dieuKienThoiGian}
                ORDER BY hd.NgayKetThuc ASC";

            DataTable dtBaoCao = DataProvider.ExecuteQuery(sql, parameters);

            // Tạo tiêu đề lọc cho báo cáo
            string tieuDeLoc = "Tất cả thời gian";
            if (thang.HasValue && nam.HasValue)
                tieuDeLoc = $"Tháng {thang.Value}/{nam.Value}";
            else if (nam.HasValue)
                tieuDeLoc = $"Năm {nam.Value}";
            else
                tieuDeLoc = "30 ngày tới (từ hôm nay)";

            // Thêm cột TieuDeLoc vào DataTable để truyền vào report
            dtBaoCao.Columns.Add("TieuDeLoc", typeof(string));
            foreach (DataRow row in dtBaoCao.Rows)
                row["TieuDeLoc"] = tieuDeLoc;

            var dsSources = new List<ReportDataSource>
            {
                new ReportDataSource("dsHDHetHan", dtBaoCao)
            };

            frmXemBaoCao frm = new frmXemBaoCao();
            frm.HienThiBaoCao("rptHDHetHan.rdlc", dsSources,
                "Danh sách hợp đồng hết hạn — " + tieuDeLoc);
            frm.ShowDialog();
        }

        private void cmdxem_Click_1(object sender, EventArgs e)
        {
            int? thang = null;
            int? nam = null;

            // Lấy tháng nếu không phải "Tất cả"
            if (cbothangkt.SelectedIndex > 0)
                thang = cbothangkt.SelectedIndex; // index 1 = Tháng 1, ...

            // Lấy năm nếu không phải "Tất cả"
            if (cbonamkt.SelectedIndex > 0 && int.TryParse(cbonamkt.SelectedItem.ToString(), out int namVal))
                nam = namVal;

            KiemTraHDHetHan(thang, nam);
        }
    }
}