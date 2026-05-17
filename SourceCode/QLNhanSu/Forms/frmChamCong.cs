using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLNhanSu.Forms
{

    public partial class frmChamCong : Form
    {
        private readonly string _maNV;
        private Timer _dongHoTimer;

        // Constructor mặc định: lấy MaNV từ session (nhân viên tự chấm công)
        public frmChamCong() : this(SessionInfo.MaNV) { }

        // Constructor có tham số: Admin mở xem cho nhân viên cụ thể
        public frmChamCong(string maNV)
        {
            InitializeComponent();
            _maNV = maNV;
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            // Đồng hồ cập nhật giờ thực mỗi giây
            _dongHoTimer = new Timer { Interval = 1000 };
            _dongHoTimer.Tick += (s, _) =>
                lblGioHienTai.Text = DateTime.Now.ToString("HH:mm:ss  |  dd/MM/yyyy");
            _dongHoTimer.Start();

            lblGioHienTai.Text = DateTime.Now.ToString("HH:mm:ss  |  dd/MM/yyyy");

            // Hiển thị thông tin nhân viên
            HienThiThongTinNV();

            // Cấu hình DataGridView lịch sử chấm công
            CauHinhDgv();

            // Load trạng thái hôm nay + lịch sử tháng này
            KiemTraTrangThaiHomNay();
            LoadLichSuThang();
        }

        private void frmChamCong_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dongHoTimer?.Stop();
            _dongHoTimer?.Dispose();
        }

        //  HIỂN THỊ THÔNG TIN NHÂN VIÊN
        private void HienThiThongTinNV()
        {
            DataTable dt = DataProvider.ExecuteQuery(
                @"SELECT nv.MaNV, nv.HoNV + ' ' + nv.TenNV AS HoTen,
                         cv.TenCV, pb.TenPB
                  FROM NhanVien nv
                  LEFT JOIN ChucVu  cv ON nv.MaCV = cv.MaCV
                  LEFT JOIN PhongBan pb ON nv.MaPB = pb.MaPB
                  WHERE nv.MaNV = @MaNV",
                new[] { new SqlParameter("@MaNV", _maNV) });

            if (dt.Rows.Count == 0) return;
            lblMaNV.Text = "Mã NV: " + dt.Rows[0]["MaNV"].ToString();
            lblHoTen.Text = "Họ tên: " + dt.Rows[0]["HoTen"].ToString();
            lblChucVu.Text = "Chức vụ: " + dt.Rows[0]["TenCV"].ToString();
            lblPhong.Text = "Phòng ban: " + dt.Rows[0]["TenPB"].ToString();
        }

        private void CauHinhDgv()
        {
            dgvLichSu.AutoGenerateColumns = false;
            dgvLichSu.ReadOnly = true;
            dgvLichSu.AllowUserToAddRows = false;
            dgvLichSu.RowHeadersVisible = false;
            dgvLichSu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvLichSu.Columns.Clear();
            dgvLichSu.Columns.AddRange(
                Col("NgayChamCong", "Ngày", 80, "dd/MM/yyyy"),
                Col("GioBatDau", "Bắt đầu ca", 90, "HH:mm"),
                Col("GioKetThuc", "Kết thúc ca", 90, "HH:mm"),
                Col("SoGioLam", "Số giờ làm", 80, "N1"),
                Col("TrangThai", "Trạng thái", 100, null)
            );

            // Tô màu dòng theo trạng thái
            dgvLichSu.CellFormatting += DgvLichSu_CellFormatting;
        }

        private DataGridViewTextBoxColumn Col(string dataField, string header,
            int width, string format)
        {
            var c = new DataGridViewTextBoxColumn
            {
                Name = dataField,
                DataPropertyName = dataField,
                HeaderText = header,
                Width = width,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            if (!string.IsNullOrEmpty(format))
                c.DefaultCellStyle.Format = format;
            return c;
        }

        private void DgvLichSu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLichSu.Rows[e.RowIndex];
            string tt = row.Cells["TrangThai"].Value?.ToString() ?? "";
            switch (tt)
            {
                case "Hoàn thành": row.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220); break;
                case "Đang làm": row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200); break;
                case "Vắng": row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220); break;
            }
        }

        //  KIỂM TRA TRẠNG THÁI CHẤM CÔNG HÔM NAY
        private void KiemTraTrangThaiHomNay()
        {
            DateTime homNay = DateTime.Today;
            lblNgayHomNay.Text = "📅 Hôm nay: " + homNay.ToString("dddd, dd/MM/yyyy");

            DataTable dt = DataProvider.ExecuteQuery(
                @"SELECT GioBatDau, GioKetThuc, TrangThai
                  FROM ChamCong
                  WHERE MaNV = @MaNV AND NgayChamCong = @Ngay",
                new[]
                {
                    new SqlParameter("@MaNV", _maNV),
                    new SqlParameter("@Ngay", homNay)
                });

            bool daVao = false, daRa = false;

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                daVao = r["GioBatDau"] != DBNull.Value;
                daRa = r["GioKetThuc"] != DBNull.Value;

                if (daVao)
                    lblBatDau.Text = "🟢 Bắt đầu ca: " +
                        Convert.ToDateTime(r["GioBatDau"]).ToString("HH:mm:ss");
                else
                    lblBatDau.Text = "🔴 Chưa bắt đầu ca";

                if (daRa)
                    lblKetThuc.Text = "✅ Kết thúc ca: " +
                        Convert.ToDateTime(r["GioKetThuc"]).ToString("HH:mm:ss");
                else
                    lblKetThuc.Text = "⏸ Chưa kết thúc ca";
            }
            else
            {
                lblBatDau.Text = "🔴 Chưa bắt đầu ca";
                lblKetThuc.Text = "⏸ Chưa kết thúc ca";
            }

            bool laNhanVien = SessionInfo.VaiTro == "NhanVien";

            // Nút Bắt đầu: kích hoạt khi NhanVien và chưa vào ca
            btnBatDauCa.Enabled = laNhanVien && !daVao;
            // Nút Kết thúc: kích hoạt khi NhanVien, đã vào ca và chưa ra ca
            btnKetThucCa.Enabled = laNhanVien && daVao && !daRa;

            // Nếu đã hoàn thành: tắt cả 2
            if (daVao && daRa)
            {
                btnBatDauCa.Enabled = false;
                btnKetThucCa.Enabled = false;
                pnlStatus.BackColor = Color.FromArgb(220, 255, 220); // xanh lá nhạt
            }
            else if (daVao)
            {
                pnlStatus.BackColor = Color.FromArgb(255, 255, 200); // vàng nhạt - đang làm
            }
            else
            {
                pnlStatus.BackColor = Color.FromArgb(240, 240, 240); // xám nhạt - chưa vào
            }
        }

        //  TẢI LỊCH SỬ CHẤM CÔNG THÁNG NÀY
        private void LoadLichSuThang()
        {
            int thang = (int)numThang.Value;
            int nam = (int)numNam.Value;

            DataTable dt = DataProvider.ExecuteQuery(
                @"SELECT NgayChamCong, GioBatDau, GioKetThuc,
                         SoGioLam, TrangThai, GhiChu
                  FROM ChamCong
                  WHERE MaNV = @MaNV
                    AND MONTH(NgayChamCong) = @Thang
                    AND YEAR(NgayChamCong)  = @Nam
                  ORDER BY NgayChamCong DESC",
                new[]
                {
                    new SqlParameter("@MaNV",  _maNV),
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam",   nam)
                });

            dgvLichSu.DataSource = dt;

            // Thống kê cuối form
            int tongNgay = 0;
            decimal tongGio = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r["TrangThai"].ToString() == "Hoàn thành") tongNgay++;
                if (r["SoGioLam"] != DBNull.Value)
                    tongGio += Convert.ToDecimal(r["SoGioLam"]);
            }

            lblThongKe.Text = $"📊 Tháng {thang}/{nam}:  " +
                              $"Số ngày công: {tongNgay}  |  " +
                              $"Tổng giờ làm: {tongGio:N1} giờ";
        }

        //  NÚT BẮT ĐẦU CA

        private void btnBatDauCa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_maNV))
            {
                MessageBox.Show("Tài khoản của bạn chưa được liên kết với nhân viên.\n" +
                                "Vui lòng liên hệ Admin để cập nhật.", "Lỗi cấu hình",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Xác nhận MaNV tồn tại trong NhanVien
            int nvExist = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV",
                new[] { new SqlParameter("@MaNV", _maNV) }));

            if (nvExist == 0)
            {
                MessageBox.Show($"Mã nhân viên '{_maNV}' không tồn tại trong hệ thống.\n" +
                                "Vui lòng liên hệ Admin.", "Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime gioBatDau = DateTime.Now;
            DateTime ngay = DateTime.Today;

            // Kiểm tra đã có bản ghi hôm nay chưa
            int exist = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM ChamCong WHERE MaNV=@MaNV AND NgayChamCong=@Ngay",
                new[] { new SqlParameter("@MaNV", _maNV), new SqlParameter("@Ngay", ngay) }));

            if (exist > 0)
            {
                MessageBox.Show("Bạn đã bắt đầu ca hôm nay rồi!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(
                $"Bắt đầu ca làm việc lúc {gioBatDau:HH:mm:ss}?",
                "Xác nhận bắt đầu ca",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int kq = DataProvider.ExecuteNonQuery(
                @"INSERT INTO ChamCong (MaNV, NgayChamCong, GioBatDau, TrangThai)
                  VALUES (@MaNV, @Ngay, @GioBatDau, N'Đang làm')",
                new[]
                {
                    new SqlParameter("@MaNV",      _maNV),
                    new SqlParameter("@Ngay",      ngay),
                    new SqlParameter("@GioBatDau", gioBatDau)
                });

            if (kq > 0)
            {
                MessageBox.Show(
                    $"✅ Đã ghi nhận bắt đầu ca lúc {gioBatDau:HH:mm:ss}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KiemTraTrangThaiHomNay();
                LoadLichSuThang();
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //  NÚT KẾT THÚC CA
        private void btnKetThucCa_Click(object sender, EventArgs e)
        {
            DateTime gioKetThuc = DateTime.Now;
            DateTime ngay = DateTime.Today;

            // Lấy giờ bắt đầu để tính số giờ làm
            object gioBDObj = DataProvider.ExecuteScalar(
                "SELECT GioBatDau FROM ChamCong WHERE MaNV=@MaNV AND NgayChamCong=@Ngay",
                new[] { new SqlParameter("@MaNV", _maNV), new SqlParameter("@Ngay", ngay) });

            if (gioBDObj == null || gioBDObj == DBNull.Value)
            {
                MessageBox.Show("Chưa có dữ liệu bắt đầu ca hôm nay!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime gioBatDau = Convert.ToDateTime(gioBDObj);
            decimal soGioLam = (decimal)(gioKetThuc - gioBatDau).TotalHours;
            soGioLam = Math.Round(soGioLam, 2);

            if (soGioLam <= 0)
            {
                MessageBox.Show("Giờ kết thúc không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                $"Kết thúc ca làm việc lúc {gioKetThuc:HH:mm:ss}?\n" +
                $"Tổng thời gian làm: {soGioLam:N2} giờ",
                "Xác nhận kết thúc ca",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int kq = DataProvider.ExecuteNonQuery(
                @"UPDATE ChamCong
                  SET GioKetThuc = @GioKetThuc,
                      SoGioLam   = @SoGioLam,
                      TrangThai  = N'Hoàn thành'
                  WHERE MaNV = @MaNV AND NgayChamCong = @Ngay",
                new[]
                {
                    new SqlParameter("@GioKetThuc", gioKetThuc),
                    new SqlParameter("@SoGioLam",   soGioLam),
                    new SqlParameter("@MaNV",        _maNV),
                    new SqlParameter("@Ngay",        ngay)
                });

            if (kq > 0)
            {
                MessageBox.Show(
                    $"✅ Hoàn thành ca làm việc!\n" +
                    $"Bắt đầu: {gioBatDau:HH:mm}  →  Kết thúc: {gioKetThuc:HH:mm}\n" +
                    $"Tổng: {soGioLam:N2} giờ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KiemTraTrangThaiHomNay();
                LoadLichSuThang();
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  CHỌN THÁNG / NĂM ĐỂ XEM LỊCH SỬ
        private void numThang_ValueChanged(object sender, EventArgs e) => LoadLichSuThang();
        private void numNam_ValueChanged(object sender, EventArgs e) => LoadLichSuThang();

        //  PHƯƠNG THỨC TĨNH: LẤY SỐ NGÀY CÔNG TỪ ChamCong
        //  (Được gọi từ frmBangLuong khi tính lương tự động)
        public static decimal LayNgayCong(string maNV, int thang, int nam)
        {
            object result = DataProvider.ExecuteScalar(
                @"SELECT COUNT(*)
                  FROM ChamCong
                  WHERE MaNV = @MaNV
                    AND MONTH(NgayChamCong) = @Thang
                    AND YEAR(NgayChamCong)  = @Nam
                    AND TrangThai = N'Hoàn thành'",
                new[]
                {
                    new SqlParameter("@MaNV",  maNV),
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam",   nam)
                });
            return result != null && result != DBNull.Value
                ? Convert.ToDecimal(result) : 0;
        }
    }
}