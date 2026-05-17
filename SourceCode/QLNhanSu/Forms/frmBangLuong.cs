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
using Microsoft.Reporting.WinForms;

namespace QLNhanSu.Forms
{
    public partial class frmBangLuong : Form
    {
        private static readonly decimal LUONG_CO_SO =
    decimal.Parse(System.Configuration.ConfigurationManager
                        .AppSettings["LuongCoSo"] ?? "2340000");
        public frmBangLuong()
        {
            InitializeComponent();
        }

        private void frmBangLuong_Load(object sender, EventArgs e)
        {
            lstNhanvien.View = View.Details;
            lstNhanvien.FullRowSelect = true;
            lstNhanvien.GridLines = true;
            if (lstNhanvien.Columns.Count == 0)
            {
                lstNhanvien.Columns.Add("Mã NV", 60);
                lstNhanvien.Columns.Add("Họ tên", 140);
            }

            LoadCboPhong();
            LoadDanhSachNV();

            numThang.Value = DateTime.Now.Month;
            numNam.Value = DateTime.Now.Year;

            // Điền sẵn 2 giá trị cố định theo chính sách công ty
            txtNgayChuanThang.Text = "26";
            txtsongayphep.Text = "2";

            //  Nếu đang đăng nhập với quyền NhanVien,tự động chọn nhân viên tương ứng và hạn chế quyền
            if (SessionInfo.VaiTro == "NhanVien")
            {
                ApdungCheDoBietNhanVien();
            }
        }

        /// Khi đăng nhập là NhanVien: chỉ hiển thị bảng lương của bản thân,
        /// ẩn list chọn nhân viên khác, tắt các nút chỉnh sửa.
        private void ApdungCheDoBietNhanVien()
        {
            // Ẩn list chọn nhân viên + bộ lọc phòng/tổ (không cần chọn người khác)
            if (lstNhanvien.Parent != null) lstNhanvien.Parent.Visible = false;
            if (cboPhong.Parent != null) cboPhong.Parent.Visible = false;

            // Tắt nút Lưu, Tính lương, Xóa — NhanVien chỉ được xem
            if (btnLuu != null) btnLuu.Enabled = false;
            if (btnTinhLuong != null) btnTinhLuong.Enabled = false;
            if (btnXoa != null) btnXoa.Enabled = false;

            // Đổi nhãn nút Chấm công → mở form chấm công
            if (btnChamLuong != null)
            {
                btnChamLuong.Text = "⏱ Chấm công ca";
                btnChamLuong.BackColor = Color.FromArgb(34, 139, 34);
                btnChamLuong.ForeColor = Color.White;
            }

            // Tự động tải thông tin bản thân
            string maNV = SessionInfo.MaNV;
            if (!string.IsNullOrEmpty(maNV))
            {
                HienThiThongTinNV(maNV);
                LoadBangLuong(maNV);
            }
        }

        private void LoadCboPhong()
        {
            cboPhong.DataSource = DataProvider.ExecuteQuery("SELECT MaPB, TenPB FROM PhongBan ORDER BY MaPB");
            cboPhong.DisplayMember = "TenPB";
            cboPhong.ValueMember = "MaPB";
            cboPhong.SelectedIndex = -1;
        }

        private void LoadDanhSachNV(string maPB = "", string maTo = "")
        {
            // NhanVien chỉ thấy bản thân trong list
            if (SessionInfo.VaiTro == "NhanVien")
            {
                string sqlNV = @"SELECT MaNV, HoNV + ' ' + TenNV AS HoTen
                                 FROM NhanVien WHERE MaNV = @MaNV";
                DataTable dtNV = DataProvider.ExecuteQuery(sqlNV,
                    new[] { new SqlParameter("@MaNV", SessionInfo.MaNV) });
                lstNhanvien.Items.Clear();
                foreach (DataRow row in dtNV.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaNV"].ToString());
                    item.SubItems.Add(row["HoTen"].ToString());
                    item.Tag = row["MaNV"].ToString();
                    lstNhanvien.Items.Add(item);
                }
                return;
            }

            // Admin: load bình thường
            string sql = @"SELECT MaNV, HoNV + ' ' + TenNV AS HoTen 
                           FROM NhanVien WHERE TinhTrang = N'Đang làm'";
            if (maPB != "") sql += " AND MaPB=@MaPB";
            if (maTo != "") sql += " AND MaTo=@MaTo";
            sql += " ORDER BY MaNV";

            SqlParameter[] p = null;
            if (maPB != "" && maTo != "")
                p = new[] { new SqlParameter("@MaPB", maPB), new SqlParameter("@MaTo", maTo) };
            else if (maPB != "")
                p = new[] { new SqlParameter("@MaPB", maPB) };
            else if (maTo != "")
                p = new[] { new SqlParameter("@MaTo", maTo) };

            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            lstNhanvien.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaNV"].ToString());
                item.SubItems.Add(row["HoTen"].ToString());
                item.Tag = row["MaNV"].ToString();
                lstNhanvien.Items.Add(item);
            }
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue == null) return;
            string maPB = cboPhong.SelectedValue.ToString();

            DataTable dtTo = DataProvider.ExecuteQuery(
                "SELECT MaTo, TenTo FROM To_ WHERE MaPB=@MaPB ORDER BY MaTo",
                new[] { new SqlParameter("@MaPB", maPB) });
            cboTo.DataSource = dtTo;
            cboTo.DisplayMember = "TenTo";
            cboTo.ValueMember = "MaTo";
            cboTo.SelectedIndex = -1;

            LoadDanhSachNV(maPB);
        }

        private void cboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maPB = cboPhong.SelectedValue?.ToString() ?? "";
            string maTo = cboTo.SelectedValue?.ToString() ?? "";
            LoadDanhSachNV(maPB, maTo);
        }

        private void lstNhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNhanvien.SelectedItems.Count == 0) return;
            string maNV = lstNhanvien.SelectedItems[0].Tag.ToString();
            HienThiThongTinNV(maNV);
            LoadBangLuong(maNV);
        }
        private void HienThiThongTinNV(string maNV)
        {
            string sql = @"SELECT nv.MaNV, nv.HoNV + ' ' + nv.TenNV AS HoTen,
               nv.DienThoai, nv.ChoHienTai,
               ISNULL(hd.LuongCoBan, 0) AS LuongCoBan
               FROM NhanVien nv
               LEFT JOIN HopDong hd ON nv.MaNV = hd.MaNV
                   AND hd.MaHD = (
                       SELECT TOP 1 MaHD FROM HopDong 
                       WHERE MaNV = nv.MaNV 
                       ORDER BY NgayKy DESC
                   )
               WHERE nv.MaNV = @MaNV";

            DataTable dt = DataProvider.ExecuteQuery(sql, new[] { new SqlParameter("@MaNV", maNV) });
            if (dt.Rows.Count == 0) return;

            txtmanv.Text = dt.Rows[0]["MaNV"].ToString();
            txthoten.Text = dt.Rows[0]["HoTen"].ToString();
            txtSdt.Text = dt.Rows[0]["DienThoai"].ToString();
            txtDiachi.Text = dt.Rows[0]["ChoHienTai"].ToString();
            txtluongcb.Text = string.Format("{0:N0}", dt.Rows[0]["LuongCoBan"]);
        }

        private void LoadBangLuong(string maNV)
        {
            dgv_bangluong.AutoGenerateColumns = false;

            string sql = @"SELECT 
        bl.Thang AS thang, bl.Nam AS nam,
        nv.MaPB AS maphong, nv.MaTo AS mato,
        nv.HoNV AS ho, nv.TenNV AS ten,
        bl.LuongCoBan   AS luongcoban,
        bl.NgayCongChuan AS songaylv,        
        bl.LuongNgayCong AS luonglamviec,
        bl.LuongTangCa   AS luongtangca,
        bl.PhuCap        AS phucapcv,
        bl.PhuCapKhac    AS phucapkhac,
        bl.BHXHvaBHYT    AS bhxhvabhyt,
        bl.OT1           AS sogiotangca,
        bl.OT2           AS sogiotangcaCN,
        ISNULL(bl.OT3, 0) AS sogiotangcaLe,
        bl.SoNgayPhep    AS songaynghiphep,
        bl.NgayNgungViec AS songaynghingungviec,
        bl.ThuCLanh      AS thuclanh,
        0 AS tilehq, 0 AS tileccvasinhhoat,
        0 AS mahieuqua,  0 AS pcsinhhoatcc,
        bl.MaNV AS manv
        FROM BangLuong bl
        JOIN NhanVien nv ON bl.MaNV = nv.MaNV
        WHERE bl.MaNV = @MaNV
        ORDER BY bl.Nam DESC, bl.Thang DESC";

            dgv_bangluong.DataSource = DataProvider.ExecuteQuery(sql,
                new[] { new SqlParameter("@MaNV", maNV) });
        }

        private void dgv_bangluong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv_bangluong.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            decimal ParseCell(string colName)
            {
                var val = row.Cells[colName].Value;
                if (val == null || val == DBNull.Value) return 0;
                decimal.TryParse(val.ToString(), System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out decimal result);
                return result;
            }

            txtNgaycongchuan.Text = row.Cells["songaylv"].Value?.ToString();
            txtluongngaycong.Text = ParseCell("Luonglv").ToString("N0");
            txtluongtangca.Text = ParseCell("luongtangca").ToString("N0");
            txtot1.Text = row.Cells["soot1"].Value?.ToString();
            txtot2.Text = row.Cells["SoOT2"].Value?.ToString();
            txtsongayphep.Text = row.Cells["Ngaynghiphep"].Value?.ToString();
            txtpckhac.Text = ParseCell("phucapkhac").ToString("N0");

            var ngayNgungViec = row.Cells["ngayngungviec"].Value;
            if (ngayNgungViec != null && ngayNgungViec != DBNull.Value)
                txtngayngungviec.Text = Convert.ToDateTime(ngayNgungViec).ToString("dd/MM/yyyy");
            else
                txtngayngungviec.Text = "";
        }

        private void TinhVaLuuLuong(int thang, int nam, bool moPhieuLuong)
        {
            const decimal SO_NGAY_CHUAN = 26m;
            const decimal NGAY_PHEP_LUONG = 2m;

            decimal luongCB = 0, ngayCong = 0, luongNgayCong = 0;
            decimal luongTC = 0, phuCap = 0, pcKhac = 0, bhxh = 0;
            decimal ot1 = 0, ot2 = 0, ot3 = 0, thuCLanh = 0;
            decimal soNgayPhep = 0;

            decimal.TryParse(txtluongcb.Text.Replace(".", "").Replace(",", ""), out luongCB);
            decimal.TryParse(txtNgaycongchuan.Text, out ngayCong);
            decimal.TryParse(txtluongngaycong.Text.Replace(".", "").Replace(",", ""), out luongNgayCong);
            decimal.TryParse(txtluongtangca.Text.Replace(".", "").Replace(",", ""), out luongTC);
            decimal.TryParse(txtot1.Text, out ot1);
            decimal.TryParse(txtot2.Text, out ot2);
            decimal.TryParse(txtot3.Text, out ot3);
            decimal.TryParse(txtsongayphep.Text, out soNgayPhep);
            decimal.TryParse(txtpckhac.Text.Replace(".", "").Replace(",", ""), out pcKhac);

            object pcObj = DataProvider.ExecuteScalar(
                @"SELECT ISNULL(cv.PhuCap, 0) 
          FROM NhanVien nv 
          LEFT JOIN ChucVu cv ON nv.MaCV = cv.MaCV 
          WHERE nv.MaNV = @MaNV",
                new[] { new SqlParameter("@MaNV", txtmanv.Text) });
            phuCap = (pcObj != null && pcObj != DBNull.Value) ? Convert.ToDecimal(pcObj) : 0;

            if (!decimal.TryParse(txtbhxhvabhyt.Text.Replace(".", "").Replace(",", ""), out bhxh) || bhxh <= 0)
            {
                decimal luongDongBHXH = Math.Min(luongCB, LUONG_CO_SO * 20);
                bhxh = Math.Round(luongDongBHXH * 0.105m, 0);
            }

            if (!decimal.TryParse(txtthuclanh.Text.Replace(".", "").Replace(",", ""), out thuCLanh) || thuCLanh == 0)
                thuCLanh = luongNgayCong + luongTC + phuCap + pcKhac - bhxh;

            DateTime? ngayNV = null;
            if (txtngayngungviec.Text.Trim() != "")
            {
                DateTime d;
                if (DateTime.TryParseExact(txtngayngungviec.Text, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out d))
                    ngayNV = d;
            }

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM BangLuong WHERE MaNV=@MaNV AND Thang=@T AND Nam=@N",
                new[] {
            new SqlParameter("@MaNV", txtmanv.Text),
            new SqlParameter("@T", thang),
            new SqlParameter("@N", nam)
                }));

            string sql = count > 0
                ? @"UPDATE BangLuong 
            SET LuongCoBan=@LCB, NgayCongChuan=@NCC,
                LuongNgayCong=@LNC, LuongTangCa=@LTC,
                PhuCap=@PC, PhuCapKhac=@PCK,
                BHXHvaBHYT=@BHXH, OT1=@OT1, OT2=@OT2, OT3=@OT3,
                SoNgayPhep=@SNP, NgayNgungViec=@NNV, ThuCLanh=@TCL
            WHERE MaNV=@MaNV AND Thang=@T AND Nam=@N"
                : @"INSERT INTO BangLuong
               (MaNV, Thang, Nam, LuongCoBan, NgayCongChuan,
                LuongNgayCong, LuongTangCa, PhuCap, PhuCapKhac,
                BHXHvaBHYT, OT1, OT2, OT3, SoNgayPhep, NgayNgungViec, ThuCLanh)
            VALUES
               (@MaNV, @T, @N, @LCB, @NCC,
                @LNC, @LTC, @PC, @PCK,
                @BHXH, @OT1, @OT2, @OT3, @SNP, @NNV, @TCL)";

            SqlParameter[] p = {
        new SqlParameter("@MaNV", txtmanv.Text.Trim()),
        new SqlParameter("@T",    thang),
        new SqlParameter("@N",    nam),
        new SqlParameter("@LCB",  luongCB),
        new SqlParameter("@NCC",  ngayCong),
        new SqlParameter("@LNC",  luongNgayCong),
        new SqlParameter("@LTC",  luongTC),
        new SqlParameter("@PC",   phuCap),
        new SqlParameter("@PCK",  pcKhac),
        new SqlParameter("@BHXH", bhxh),
        new SqlParameter("@OT1",  ot1),
        new SqlParameter("@OT2",  ot2),
        new SqlParameter("@OT3",  ot3),
        new SqlParameter("@SNP",  soNgayPhep),
        new SqlParameter("@NNV",  ngayNV.HasValue ? (object)ngayNV.Value : DBNull.Value),
        new SqlParameter("@TCL",  thuCLanh)
    };

            if (DataProvider.ExecuteNonQuery(sql, p) <= 0) return;

            MessageBox.Show(
                count > 0
                    ? $"Cập nhật lương tháng {thang}/{nam} thành công!\nThực lãnh: {thuCLanh:N0} đ"
                    : $"Lưu lương tháng {thang}/{nam} thành công!\nThực lãnh: {thuCLanh:N0} đ",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadBangLuong(txtmanv.Text);

            if (!moPhieuLuong) return;

            string sqlBC = @"SELECT 
        nv.MaNV, nv.HoNV + ' ' + nv.TenNV AS HoTen,
        p.TenPB, cv.TenCV,
        bl.LuongCoBan, bl.NgayCongChuan AS NgayCong,
        bl.LuongNgayCong, bl.LuongTangCa,
        bl.PhuCap, bl.PhuCapKhac,
        bl.BHXHvaBHYT, bl.ThuCLanh,
        bl.Thang, bl.Nam
        FROM BangLuong bl
        JOIN NhanVien nv ON bl.MaNV = nv.MaNV
        LEFT JOIN PhongBan p  ON nv.MaPB = p.MaPB
        LEFT JOIN ChucVu cv   ON nv.MaCV = cv.MaCV
        WHERE bl.MaNV=@MaNV AND bl.Thang=@T AND bl.Nam=@N";

            DataTable dt = DataProvider.ExecuteQuery(sqlBC, new[] {
        new SqlParameter("@MaNV", txtmanv.Text.Trim()),
        new SqlParameter("@T", thang),
        new SqlParameter("@N", nam)
    });

            frmXemBaoCao frm = new frmXemBaoCao();
            frm.HienThiBaoCao(
                "rptPhieuLuong.rdlc",
                new List<ReportDataSource> {
            new ReportDataSource("dsPhieuLuong", dt)
                },
                $"Phiếu lương tháng {thang}/{nam} - {txthoten.Text}"
            );
            frm.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text.Trim() == "")
            { MessageBox.Show("Chọn nhân viên trước!"); return; }

            TinhVaLuuLuong((int)numThang.Value, (int)numNam.Value, moPhieuLuong: false);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNgaycongchuan.Clear();
            txtluongngaycong.Clear();
            txtluongtangca.Clear();
            txtot1.Clear(); txtot2.Clear(); txtot3.Clear();
            txtpckhac.Clear(); txtngayngungviec.Clear();
            txtbhxhvabhyt.Clear(); txtthuclanh.Clear();

            txtNgayChuanThang.Text = "26";
            txtsongayphep.Text = "2";
        }

        //  NÚT CHẤM CÔNG — xử lý khác nhau theo vai trò
        private void btnChamLuong_Click(object sender, EventArgs e)
        {
            // ── CHẾ ĐỘ NHÂN VIÊN: mở form chấm công ca ─────────────
            if (SessionInfo.VaiTro == "NhanVien")
            {
                string maNV = SessionInfo.MaNV;

                // Mở form chấm công ca
                frmChamCong frmCC = new frmChamCong(maNV);
                frmCC.ShowDialog();

                // Sau khi đóng form chấm công → tự động cập nhật ngày công vào ô
                int thangCC = (int)numThang.Value;
                int namCC = (int)numNam.Value;

                decimal ngayCongTuChamCong = frmChamCong.LayNgayCong(maNV, thangCC, namCC);

                if (ngayCongTuChamCong > 0)
                {
                    txtNgaycongchuan.Text = ngayCongTuChamCong.ToString();
                    MessageBox.Show(
                        $"📊 Dữ liệu chấm công tháng {thangCC}/{namCC} đã được cập nhật:\n" +
                        $"Số ngày công ghi nhận: {ngayCongTuChamCong} ngày",
                        "Thông tin chấm công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            // CHẾ ĐỘ ADMIN
            if (txtmanv.Text.Trim() == "")
            { MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            const decimal SO_NGAY_CHUAN = 26m;
            const decimal NGAY_PHEP_LUONG = 2m;

            txtNgayChuanThang.Text = SO_NGAY_CHUAN.ToString();
            txtsongayphep.Text = NGAY_PHEP_LUONG.ToString();

            decimal soNgayThucLam = 0;
            decimal ot1 = 0, ot2 = 0, ot3 = 0, pcKhac = 0;

            //  Admin cũng có thể đọc từ bảng ChamCong ── Nếu nhân viên đã có dữ liệu chấm công tháng này → gợi ý tự động
            int thangA = (int)numThang.Value;
            int namA = (int)numNam.Value;
            decimal ngayCongCC = frmChamCong.LayNgayCong(txtmanv.Text, thangA, namA);

            if (ngayCongCC > 0 && string.IsNullOrWhiteSpace(txtNgaycongchuan.Text))
            {
                var ans = MessageBox.Show(
                    $"Nhân viên có {ngayCongCC} ngày công từ dữ liệu chấm công ca.\n" +
                    "Dùng số này tự động?",
                    "Đề xuất từ chấm công",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                    txtNgaycongchuan.Text = ngayCongCC.ToString();
            }

            decimal.TryParse(txtNgaycongchuan.Text.Trim(), out soNgayThucLam);
            decimal.TryParse(txtot1.Text.Trim(), out ot1);
            decimal.TryParse(txtot2.Text.Trim(), out ot2);
            decimal.TryParse(txtot3.Text.Trim(), out ot3);
            decimal.TryParse(txtpckhac.Text.Replace(",", ""), out pcKhac);

            if (soNgayThucLam < 0)
            { MessageBox.Show("Số ngày công không được âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (soNgayThucLam > SO_NGAY_CHUAN)
            { MessageBox.Show($"Số ngày công ({soNgayThucLam}) vượt quá ngày chuẩn tháng ({SO_NGAY_CHUAN})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            decimal luongCB = 0;
            decimal.TryParse(txtluongcb.Text.Replace(",", "").Replace(".", ""), out luongCB);
            if (luongCB <= 0)
            { MessageBox.Show("Nhân viên chưa có lương cơ bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int thang = (int)numThang.Value;
            int nam = (int)numNam.Value;

            string sqlNV = "SELECT MaPB, MaTo FROM NhanVien WHERE MaNV=@MaNV";
            DataTable dtNV = DataProvider.ExecuteQuery(sqlNV, new[] { new SqlParameter("@MaNV", txtmanv.Text) });
            string maPB = dtNV.Rows.Count > 0 ? dtNV.Rows[0]["MaPB"].ToString() : "";
            string maTo = dtNV.Rows.Count > 0 ? dtNV.Rows[0]["MaTo"]?.ToString() ?? "" : "";

            object tiLeObj = DataProvider.ExecuteScalar(
                @"SELECT TOP 1 ISNULL(TiLeLuong, 100) FROM TiLeLuong 
                  WHERE MaPB=@MaPB AND Thang=@T AND Nam=@N
                    AND (@MaTo = '' OR MaTo = @MaTo OR MaTo IS NULL)
                  ORDER BY CASE WHEN MaTo = @MaTo THEN 0 ELSE 1 END",
                new[] {
                    new SqlParameter("@MaPB", maPB),
                    new SqlParameter("@MaTo", maTo),
                    new SqlParameter("@T",    thang),
                    new SqlParameter("@N",    nam)
                });
            decimal tiLe = tiLeObj != null && tiLeObj != DBNull.Value ? Convert.ToDecimal(tiLeObj) / 100m : 1m;

            object pcObj = DataProvider.ExecuteScalar(
                "SELECT ISNULL(cv.PhuCap,0) FROM NhanVien nv LEFT JOIN ChucVu cv ON nv.MaCV=cv.MaCV WHERE nv.MaNV=@MaNV",
                new[] { new SqlParameter("@MaNV", txtmanv.Text) });
            decimal phuCap = pcObj != null && pcObj != DBNull.Value ? Convert.ToDecimal(pcObj) : 0;

            decimal luongMotNgay = luongCB * tiLe / SO_NGAY_CHUAN;
            decimal luongNgayCong = Math.Round(luongMotNgay * (soNgayThucLam + NGAY_PHEP_LUONG), 0);

            decimal luongMotGio = luongCB / SO_NGAY_CHUAN / 8;
            decimal luongTangCa = Math.Round(
                luongMotGio * ot1 * 1.5m +
                luongMotGio * ot2 * 2.0m +
                luongMotGio * ot3 * 3.0m, 0);

            decimal luongDongBHXH = Math.Min(luongCB, LUONG_CO_SO * 20);
            decimal bhxh = Math.Round(luongDongBHXH * 0.105m, 0);

            decimal thuCLanh = luongNgayCong + luongTangCa + phuCap + pcKhac - bhxh;

            txtNgaycongchuan.Text = soNgayThucLam.ToString();
            txtluongngaycong.Text = luongNgayCong.ToString("N0");
            txtluongtangca.Text = luongTangCa.ToString("N0");
            txtbhxhvabhyt.Text = bhxh.ToString("N0");
            txtthuclanh.Text = thuCLanh.ToString("N0");

            MessageBox.Show(
                $"✅ Đã tính xong! Tháng {thang}/{nam}\n\n" +
                $"Ngày chuẩn tháng : {SO_NGAY_CHUAN} ngày  |  Phép có lương: {NGAY_PHEP_LUONG} ngày\n" +
                $"Ngày công thực tế: {soNgayThucLam} ngày  →  Tổng tính lương: {soNgayThucLam + NGAY_PHEP_LUONG} ngày\n" +
                $"Tỉ lệ lương      : {tiLe * 100:0.##}%\n" +
                $"────────────────────\n" +
                $"Lương ngày công  : {luongNgayCong:N0} đ\n" +
                $"Lương tăng ca    : {luongTangCa:N0} đ\n" +
                $"  (OT thường {ot1}h×150%  |  OT CN {ot2}h×200%  |  OT lễ {ot3}h×300%)\n" +
                $"Phụ cấp CV       : {phuCap:N0} đ\n" +
                $"Phụ cấp khác     : {pcKhac:N0} đ\n" +
                $"BHXH & BHYT      : -{bhxh:N0} đ\n" +
                $"────────────────────\n" +
                $"Thực lãnh        : {thuCLanh:N0} đ",
                "Kết quả chấm công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text.Trim() == "")
            { MessageBox.Show("Chọn nhân viên trước!"); return; }

            TinhVaLuuLuong((int)numThang.Value, (int)numNam.Value, moPhieuLuong: true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text.Trim() == "") { MessageBox.Show("Chọn nhân viên trước!"); return; }

            int thang = (int)numThang.Value;
            int nam = (int)numNam.Value;

            if (MessageBox.Show($"Xóa lương tháng {thang}/{nam} của {txthoten.Text}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery(
                    "DELETE FROM BangLuong WHERE MaNV=@MaNV AND Thang=@T AND Nam=@N",
                    new[] { new System.Data.SqlClient.SqlParameter("@MaNV", txtmanv.Text),
                    new System.Data.SqlClient.SqlParameter("@T", thang),
                    new System.Data.SqlClient.SqlParameter("@N", nam) }) > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadBangLuong(txtmanv.Text);
                    btnReset_Click(sender, e);
                }
            }
        }

        private void numThang_ValueChanged(object sender, EventArgs e)
        {
            if (txtmanv.Text.Trim() != "")
                LoadBangLuong(txtmanv.Text);
        }

        private void numNam_ValueChanged(object sender, EventArgs e)
        {
            if (txtmanv.Text.Trim() != "")
                LoadBangLuong(txtmanv.Text);
        }
    }
}