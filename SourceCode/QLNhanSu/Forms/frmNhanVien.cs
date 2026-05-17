using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLNhanSu.Forms
{
    public partial class frmNhanVien : Form
    {
        private bool _isAdding = false;
        private string _pendingHinhAnh = "";
        public frmNhanVien() { InitializeComponent(); }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            picHinh.SizeMode = PictureBoxSizeMode.Zoom;
            dgv_ChitietNN.AllowUserToAddRows = true;
            dgv_ChitietCM.AllowUserToAddRows = true;
            LoadCombo();
            LoadDanhSachNV();
            SetReadOnly(true);
        }

        // HÀM PHỤ TRỢ
        private void SetReadOnly(bool readOnly)
        {
            Color mauNhap = Color.White;
            Color mauKhoaNen = SystemColors.ControlLight;

            foreach (TextBoxBase txt in new TextBoxBase[] {
            txtsymanv, txtsyhonv, txtsytennv,
            txtsynoisinh, txtsysocmnd,          
            txtsyhokhau, txtsychohientai,       
            txtsydienthoai, txtsydtdd, txtsysoBHXH, txtsysoBHYT,
            txtsysotheATM, txtsyghichu })
            {
                txt.Enabled = true;
                txt.ReadOnly = readOnly;
                txt.BackColor = readOnly ? mauKhoaNen : mauNhap;
            }

            dtpNgaySinh.Enabled = !readOnly;
            dtpNgayVL.Enabled = !readOnly;

            cbosydantoc.Enabled = !readOnly;
            cbosytongiao.Enabled = !readOnly;
            cbosyphong.Enabled = !readOnly;
            cbosychucvu.Enabled = !readOnly;
            cbosyto.Enabled = !readOnly;
            cbosytinhtrang.Enabled = !readOnly;
            optNam.Enabled = !readOnly;
            optNu.Enabled = !readOnly;
        }

        private bool KiemTraInput()
        {
            if (txtsymanv.Text.Trim() == "")
            { MessageBox.Show("Nhập Mã nhân viên!"); txtsymanv.Focus(); return false; }
            if (txtsyhonv.Text.Trim() == "")
            { MessageBox.Show("Nhập Họ nhân viên!"); txtsyhonv.Focus(); return false; }
            if (txtsytennv.Text.Trim() == "")
            { MessageBox.Show("Nhập Tên nhân viên!"); txtsytennv.Focus(); return false; }

            // Validate SĐT (nếu có nhập)
            string sdt = txtsydienthoai.Text.Trim();
            if (sdt != "" && !Regex.IsMatch(sdt, @"^(0[3-9]\d{8})$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!\nVí dụ đúng: 0901234567",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsydienthoai.Focus(); return false;
            }

            // Validate CMND/CCCD (nếu có nhập): 9 hoặc 12 chữ số
            string cmnd = txtsysocmnd.Text.Trim();
            if (cmnd != "" && !Regex.IsMatch(cmnd, @"^\d{9}$|^\d{12}$"))
            {
                MessageBox.Show("Số CMND/CCCD không hợp lệ!\nPhải là 9 hoặc 12 chữ số.",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsysocmnd.Focus(); return false;
            }

            return true;
        }

        private void XoaForm()
        {

            _isAdding = true;

            txtsymanv.Clear(); txtsyhonv.Clear(); txtsytennv.Clear();
            txtsynoisinh.Clear(); txtsysocmnd.Clear();
            txtsyhokhau.Clear(); txtsychohientai.Clear(); txtsydienthoai.Clear();
            txtsydtdd.Clear(); txtsysoBHXH.Clear(); txtsysoBHYT.Clear();
            txtsysotheATM.Clear(); txtsyghichu.Clear();

            dtpNgaySinh.Checked = false;
            dtpNgayVL.Checked = false;

            cbosydantoc.SelectedIndex = -1;
            cbosytongiao.SelectedIndex = -1;
            cbosyphong.SelectedIndex = -1;
            cbosychucvu.SelectedIndex = -1;
            cbosyto.SelectedIndex = -1;
            cbosytinhtrang.SelectedIndex = 0; 
            cbosyHonNhan.SelectedIndex = -1;
            optNam.Checked = true;
            picHinh.Image = null;
            txtknmanv.Clear();
            txtknhotennv.Clear();
            _pendingHinhAnh = "";

            _isAdding = false;
        }

        private void LoadCombo()
        {
            var dtPhong = DataProvider.ExecuteQuery("SELECT MaPB, TenPB FROM PhongBan ORDER BY MaPB");
            cbosyphong.DisplayMember = "TenPB"; cbosyphong.ValueMember = "MaPB";
            cbosyphong.DataSource = dtPhong;
            cbosyphong.SelectedIndex = -1;

            // cboPhong (combo lọc danh sách) — cùng dữ liệu
            cboPhong.DisplayMember = "TenPB"; cboPhong.ValueMember = "MaPB";
            cboPhong.DataSource = DataProvider.ExecuteQuery("SELECT MaPB, TenPB FROM PhongBan ORDER BY MaPB");
            cboPhong.SelectedIndex = -1;

            var dtCV = DataProvider.ExecuteQuery("SELECT MaCV, TenCV FROM ChucVu ORDER BY MaCV");
            cbosychucvu.DisplayMember = "TenCV"; cbosychucvu.ValueMember = "MaCV";
            cbosychucvu.DataSource = dtCV;
            cbosychucvu.SelectedIndex = -1;

            var dtDT = DataProvider.ExecuteQuery("SELECT MaDT, TenDT FROM DanToc ORDER BY MaDT");
            cbosydantoc.DisplayMember = "TenDT"; cbosydantoc.ValueMember = "MaDT";
            cbosydantoc.DataSource = dtDT;
            cbosydantoc.SelectedIndex = -1;

            var dtTG = DataProvider.ExecuteQuery("SELECT MaTG, TenTG FROM TonGiao ORDER BY MaTG");
            cbosytongiao.DisplayMember = "TenTG"; cbosytongiao.ValueMember = "MaTG";
            cbosytongiao.DataSource = dtTG;
            cbosytongiao.SelectedIndex = -1;

            cbosytinhtrang.Items.Clear();
            cbosytinhtrang.Items.AddRange(new[] { "Đang làm", "Nghỉ việc", "Tạm nghỉ", "Thai sản" });
            cbosytinhtrang.SelectedIndex = -1;

            cbosyHonNhan.Items.Clear();
            cbosyHonNhan.Items.AddRange(new[] { "Độc thân", "Đã kết hôn", "Ly hôn", "Góa" });
            cbosyHonNhan.SelectedIndex = -1;

            var dtHD = DataProvider.ExecuteQuery("SELECT MaLoaiHD, TenLoai FROM LoaiHopDong ORDER BY MaLoaiHD");
            cbohdloaihd.DisplayMember = "TenLoai"; cbohdloaihd.ValueMember = "MaLoaiHD";
            cbohdloaihd.DataSource = dtHD;
            cbohdloaihd.SelectedIndex = -1;

            optNam.Checked = true;
        }

        private void LoadComboTo(string maPB)
        {
            var dt = DataProvider.ExecuteQuery(
                "SELECT MaTo, TenTo FROM To_ WHERE MaPB=@MaPB ORDER BY MaTo",
                new[] { new SqlParameter("@MaPB", maPB) });
            cbosyto.DisplayMember = "TenTo"; cbosyto.ValueMember = "MaTo";
            cbosyto.DataSource = dt;
            cbosyto.SelectedIndex = -1;
        }

        // DANH SÁCH NHÂN VIÊN
        private void LoadDanhSachNV(string keyword = "")
        {
            string sql = keyword == ""
                ? "SELECT MaNV, HoNV, TenNV FROM NhanVien ORDER BY MaNV"
                : "SELECT MaNV, HoNV, TenNV FROM NhanVien WHERE MaNV LIKE @KW OR TenNV LIKE @KW OR HoNV LIKE @KW ORDER BY MaNV";
            SqlParameter[] p = keyword == "" ? null : new[] { new SqlParameter("@KW", "%" + keyword + "%") };
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            lstNhanvien.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaNV"].ToString());
                item.SubItems.Add(row["HoNV"].ToString());
                item.SubItems.Add(row["TenNV"].ToString());
                item.Tag = row["MaNV"].ToString();
                lstNhanvien.Items.Add(item);
            }
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isAdding) return;
            if (cboPhong.SelectedValue == null || cboPhong.SelectedIndex < 0)
            { LoadDanhSachNV(); return; }

            DataTable dt = DataProvider.ExecuteQuery(
                "SELECT MaNV, HoNV, TenNV FROM NhanVien WHERE MaPB=@MaPB ORDER BY MaNV",
                new[] { new SqlParameter("@MaPB", cboPhong.SelectedValue.ToString()) });
            lstNhanvien.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaNV"].ToString());
                item.SubItems.Add(row["HoNV"].ToString());
                item.SubItems.Add(row["TenNV"].ToString());
                item.Tag = row["MaNV"].ToString();
                lstNhanvien.Items.Add(item);
            }
        }

        private void lstNhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isAdding) return;
            if (lstNhanvien.SelectedItems.Count == 0) return;
            string maNV = lstNhanvien.SelectedItems[0].Tag.ToString();
            HienThiNhanVien(maNV);
            LoadChiTietNgoaiNgu(maNV);
            LoadChiTietChuyenMon(maNV);
            LoadChiTietHopDong(maNV);
            LoadHoSoLuong(maNV);
        }

        private void txttkmanv_TextChanged(object sender, EventArgs e)
            => LoadDanhSachNV(txttkmanv.Text.Trim());

        // TAB 1: SƠ YẾU LÝ LỊCH
        private void HienThiNhanVien(string maNV)
        {
            DataTable dt = DataProvider.ExecuteQuery(
                "SELECT * FROM NhanVien WHERE MaNV=@MaNV",
                new[] { new SqlParameter("@MaNV", maNV) });
            if (dt.Rows.Count == 0) return;
            DataRow r = dt.Rows[0];

            txtsymanv.Text = r["MaNV"].ToString();
            txtsyhonv.Text = r["HoNV"].ToString();
            txtsytennv.Text = r["TenNV"].ToString();
            txtsynoisinh.Text = r["NoiSinh"].ToString();
            txtsysocmnd.Text = r["SoCMND"].ToString();
            txtsyhokhau.Text = r["HoKhau"].ToString();
            txtsychohientai.Text = r["ChoHienTai"].ToString();
            txtsydienthoai.Text = r["DienThoai"].ToString();
            txtsydtdd.Text = r["DienThoaiDD"].ToString();
            txtsysoBHXH.Text = r["SoBHXH"].ToString();
            txtsysoBHYT.Text = r["SoBHYT"].ToString();
            txtsysotheATM.Text = r["SoTheATM"].ToString();
            txtsyghichu.Text = r["GhiChu"].ToString();

            txtknmanv.Text = r["MaNV"].ToString();
            txtknhotennv.Text = r["HoNV"].ToString() + " " + r["TenNV"].ToString();

            if (r["NgaySinh"] != DBNull.Value)
            { dtpNgaySinh.Checked = true; dtpNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]); }
            else
                dtpNgaySinh.Checked = false;

            if (r["NgayVaoLam"] != DBNull.Value)
            { dtpNgayVL.Checked = true; dtpNgayVL.Value = Convert.ToDateTime(r["NgayVaoLam"]); }
            else
                dtpNgayVL.Checked = false;

            optNam.Checked = r["GioiTinh"].ToString() == "Nam";
            optNu.Checked = r["GioiTinh"].ToString() == "Nữ";

            _isAdding = true;
            cbosydantoc.SelectedValue = r["MaDT"]?.ToString();
            cbosytongiao.SelectedValue = r["MaTG"]?.ToString();
            cbosyphong.SelectedValue = r["MaPB"]?.ToString();
            cbosychucvu.SelectedValue = r["MaCV"]?.ToString();
            cbosytinhtrang.Text = r["TinhTrang"].ToString();
            cbosyHonNhan.Text = r["TinhHonNhan"] != DBNull.Value ? r["TinhHonNhan"].ToString() : "";
            _isAdding = false;

            // Load Tổ theo Phòng rồi chọn đúng Tổ
            if (r["MaPB"] != DBNull.Value) LoadComboTo(r["MaPB"].ToString());
            if (r["MaTo"] != DBNull.Value) cbosyto.SelectedValue = r["MaTo"].ToString();

            picHinh.Image = null;
            if (r["HinhAnh"] != DBNull.Value && r["HinhAnh"].ToString() != "")
            {
                string path = r["HinhAnh"].ToString();
                if (File.Exists(path)) picHinh.Image = Image.FromFile(path);
            }

            SetReadOnly(false);
            txtsymanv.ReadOnly = true; // Không cho sửa MaNV
        }

        private void cbosyphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isAdding) return;
            if (cbosyphong.SelectedValue == null || cbosyphong.SelectedIndex < 0) return;
            LoadComboTo(cbosyphong.SelectedValue.ToString());
        }

        // CRUD NHÂN VIÊN 
        private void btnThem_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            lstNhanvien.SelectedItems.Clear();
            _isAdding = false;

            XoaForm();
            SetReadOnly(false);
            txtsymanv.ReadOnly = false;
            txtsymanv.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtsymanv.Text.Trim() == "") { MessageBox.Show("Chọn nhân viên cần sửa!"); return; }
            SetReadOnly(false);
            txtsymanv.ReadOnly = true;  // Khi sửa thì KHÔNG cho đổi MaNV
            txtsyhonv.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraInput()) return;

            string maNV = txtsymanv.Text.Trim();
            DateTime? ngaySinh = dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : (DateTime?)null;

            DateTime? ngayVL = dtpNgayVL.Checked ? dtpNgayVL.Value.Date : (DateTime?)null;
            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM NhanVien WHERE MaNV=@MaNV",
                new[] { new SqlParameter("@MaNV", maNV) }));

            string sql = count > 0
    ? @"UPDATE NhanVien SET
            HoNV=@Ho, TenNV=@Ten, NgaySinh=@NS, NoiSinh=@NoiSinh,
            GioiTinh=@GT, SoCMND=@CMND, HoKhau=@HK, ChoHienTai=@CHT,
            DienThoai=@DT, DienThoaiDD=@DTDD, MaDT=@MaDT, MaTG=@MaTG,
            MaPB=@MaPB, MaCV=@MaCV, MaTo=@MaTo, TinhTrang=@TT,TinhHonNhan=@HN,
            NgayVaoLam=@NVL, SoBHXH=@BHXH, SoBHYT=@BHYT, SoTheATM=@ATM,
            GhiChu=@GC,
            HinhAnh = CASE WHEN @HA IS NULL THEN HinhAnh ELSE @HA END
        WHERE MaNV=@MaNV"
    : @"INSERT INTO NhanVien
            (MaNV, HoNV, TenNV, NgaySinh, NoiSinh, GioiTinh,
             SoCMND, HoKhau, ChoHienTai, DienThoai, DienThoaiDD,
             MaDT, MaTG, MaPB, MaCV, MaTo, TinhTrang,TinhHonNhan,
             NgayVaoLam, SoBHXH, SoBHYT, SoTheATM, GhiChu, HinhAnh)
        VALUES
            (@MaNV, @Ho, @Ten, @NS, @NoiSinh, @GT,
             @CMND, @HK, @CHT, @DT, @DTDD,
             @MaDT, @MaTG, @MaPB, @MaCV, @MaTo, @TT, @HN,
             @NVL, @BHXH, @BHYT, @ATM, @GC, @HA)";

            SqlParameter[] p = {
                new SqlParameter("@MaNV",    maNV),
                new SqlParameter("@Ho",      txtsyhonv.Text.Trim()),
                new SqlParameter("@Ten",     txtsytennv.Text.Trim()),
                new SqlParameter("@NS",  ngaySinh.HasValue ? (object)ngaySinh.Value : DBNull.Value),
                new SqlParameter("@NoiSinh", txtsynoisinh.Text.Trim()),
                new SqlParameter("@GT",      optNam.Checked ? "Nam" : "Nữ"),
                new SqlParameter("@CMND",    txtsysocmnd.Text.Trim()),
                new SqlParameter("@HK",      txtsyhokhau.Text.Trim()),
                new SqlParameter("@CHT",     txtsychohientai.Text.Trim()),
                new SqlParameter("@DT",      txtsydienthoai.Text.Trim()),
                new SqlParameter("@DTDD",    txtsydtdd.Text.Trim()),
                new SqlParameter("@MaDT",    cbosydantoc.SelectedValue  == null ? (object)DBNull.Value : cbosydantoc.SelectedValue.ToString()),
                new SqlParameter("@MaTG",    cbosytongiao.SelectedValue == null ? (object)DBNull.Value : cbosytongiao.SelectedValue.ToString()),
                new SqlParameter("@MaPB",    cbosyphong.SelectedValue   == null ? (object)DBNull.Value : cbosyphong.SelectedValue.ToString()),
                new SqlParameter("@MaCV",    cbosychucvu.SelectedValue  == null ? (object)DBNull.Value : cbosychucvu.SelectedValue.ToString()),
                new SqlParameter("@MaTo",    cbosyto.SelectedValue      == null ? (object)DBNull.Value : cbosyto.SelectedValue.ToString()),
                new SqlParameter("@TT",      cbosytinhtrang.Text),
                new SqlParameter("@HN", cbosyHonNhan.SelectedIndex >= 0
                        ? (object)cbosyHonNhan.Text
                        : DBNull.Value),
                new SqlParameter("@NVL", ngayVL.HasValue   ? (object)ngayVL.Value   : DBNull.Value),
                new SqlParameter("@BHXH",    txtsysoBHXH.Text.Trim()),
                new SqlParameter("@BHYT",    txtsysoBHYT.Text.Trim()),
                new SqlParameter("@ATM",     txtsysotheATM.Text.Trim()),
                new SqlParameter("@GC",      txtsyghichu.Text.Trim()),
                new SqlParameter("@HA", _pendingHinhAnh == "" ? (object)DBNull.Value : _pendingHinhAnh)
            };

            if (DataProvider.ExecuteNonQuery(sql, p) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm nhân viên thành công!");
                _pendingHinhAnh = "";
                LoadDanhSachNV();
                SetReadOnly(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtsymanv.Text.Trim() == "") { MessageBox.Show("Chọn nhân viên cần xóa!"); return; }
            if (MessageBox.Show(
                    "Xóa nhân viên '" + txtsyhonv.Text + " " + txtsytennv.Text + "'?\nTất cả dữ liệu liên quan cũng bị xóa!",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string maNV = txtsymanv.Text.Trim();
                DataProvider.ExecuteNonQuery("DELETE FROM ChiTietNgoaiNgu WHERE MaNV=@Ma", new[] { new SqlParameter("@Ma", maNV) });
                DataProvider.ExecuteNonQuery("DELETE FROM ChiTietChuyenMon WHERE MaNV=@Ma", new[] { new SqlParameter("@Ma", maNV) });
                DataProvider.ExecuteNonQuery("DELETE FROM HoSoLuong WHERE MaNV=@Ma", new[] { new SqlParameter("@Ma", maNV) });
                DataProvider.ExecuteNonQuery("DELETE FROM HopDong WHERE MaNV=@Ma", new[] { new SqlParameter("@Ma", maNV) });
                DataProvider.ExecuteNonQuery("DELETE FROM BangLuong WHERE MaNV=@Ma", new[] { new SqlParameter("@Ma", maNV) });
                if (DataProvider.ExecuteNonQuery("DELETE FROM NhanVien WHERE MaNV=@Ma", new[] { new SqlParameter("@Ma", maNV) }) > 0)
                { MessageBox.Show("Xóa thành công!"); LoadDanhSachNV(); XoaForm(); SetReadOnly(true); }
            }
        }

        private void btnbrowser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                dlg.Title = "Chọn ảnh nhân viên";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                // Copy ảnh vào thư mục cố định của app để tránh mất file
                string folder = System.IO.Path.Combine(Application.StartupPath, "Images", "NhanVien");
                System.IO.Directory.CreateDirectory(folder);

                string ext = System.IO.Path.GetExtension(dlg.FileName);
                string tenFile = "NV_" + (txtsymanv.Text.Trim() == ""
                                 ? Guid.NewGuid().ToString("N").Substring(0, 8)
                                 : txtsymanv.Text.Trim()) + ext;
                string destPath = System.IO.Path.Combine(folder, tenFile);

                System.IO.File.Copy(dlg.FileName, destPath, overwrite: true);

                picHinh.Image = Image.FromFile(destPath);

                string maNV = txtsymanv.Text.Trim();
                if (maNV != "")
                {
                    // Nhân viên đã tồn tại → UPDATE luôn
                    DataProvider.ExecuteNonQuery(
                        "UPDATE NhanVien SET HinhAnh=@Anh WHERE MaNV=@MaNV",
                        new[] { new SqlParameter("@Anh",  destPath),
                        new SqlParameter("@MaNV", maNV) });
                }
                else
                {
                    // Đang thêm mới → lưu tạm, sẽ ghi vào DB khi btnLuu_Click
                    _pendingHinhAnh = destPath;
                }
            }
        }

        // IN HỒ SƠ
        private void btnInNhanvien_Click(object sender, EventArgs e)
        {
            if (txtsymanv.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần in hồ sơ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maNV = txtsymanv.Text.Trim();

            string sqlHoSo = @"
                SELECT nv.MaNV,
                       nv.HoNV + N' ' + nv.TenNV AS HoTen,
                       nv.NgaySinh, nv.GioiTinh, nv.SoCMND,
                       nv.DienThoai, nv.DienThoaiDD, nv.NgayVaoLam,
                       nv.ChoHienTai, nv.NoiSinh, nv.HoKhau, nv.GhiChu,
                       nv.SoBHXH, nv.SoBHYT, nv.SoTheATM, nv.TinhTrang,
                       nv.HinhAnh AS Anh,
                       pb.TenPB, cv.TenCV, dt.TenDT, tg.TenTG
                FROM NhanVien nv
                LEFT JOIN PhongBan pb ON nv.MaPB = pb.MaPB
                LEFT JOIN ChucVu   cv ON nv.MaCV = cv.MaCV
                LEFT JOIN DanToc   dt ON nv.MaDT = dt.MaDT
                LEFT JOIN TonGiao  tg ON nv.MaTG = tg.MaTG
                WHERE nv.MaNV = @MaNV";

            DataTable dtHoSo = DataProvider.ExecuteQuery(sqlHoSo, new[] { new SqlParameter("@MaNV", maNV) });
            if (dtHoSo.Rows.Count == 0) { MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi"); return; }

            dtHoSo.Columns.Add("AnhBytes", typeof(byte[]));
            string anhPath = dtHoSo.Rows[0]["Anh"] != DBNull.Value ? dtHoSo.Rows[0]["Anh"].ToString() : "";
            dtHoSo.Rows[0]["AnhBytes"] = !string.IsNullOrEmpty(anhPath) && File.Exists(anhPath)
                ? File.ReadAllBytes(anhPath)
                : (object)new byte[] {
                    0x89,0x50,0x4E,0x47,0x0D,0x0A,0x1A,0x0A,0x00,0x00,0x00,0x0D,
                    0x49,0x48,0x44,0x52,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,
                    0x08,0x02,0x00,0x00,0x00,0x90,0x77,0x53,0xDE,0x00,0x00,0x00,
                    0x0C,0x49,0x44,0x41,0x54,0x08,0xD7,0x63,0xF8,0xCF,0xC0,0x00,
                    0x00,0x00,0x02,0x00,0x01,0xE2,0x21,0xBC,0x33,0x00,0x00,0x00,
                    0x00,0x49,0x45,0x4E,0x44,0xAE,0x42,0x60,0x82 };

            string sqlNN = @"
                SELECT nn.TenNN AS TenNgoaiNgu, td.TenTD AS TrinhDo, ct.NgayCap, ct.NoiCap
                FROM ChiTietNgoaiNgu ct
                JOIN NgoaiNgu nn ON ct.MaNN = nn.MaNN
                JOIN TrinhDo  td ON ct.MaTD = td.MaTD
                WHERE ct.MaNV = @MaNV";
            DataTable dtNN = DataProvider.ExecuteQuery(sqlNN, new[] { new SqlParameter("@MaNV", maNV) });

            string sqlCM = @"
                SELECT cm.TenCM AS TenChuyenMon, td.TenTD AS TrinhDo, ct.NgayCap, ct.Truong
                FROM ChiTietChuyenMon ct
                JOIN ChuyenMon cm ON ct.MaCM = cm.MaCM
                JOIN TrinhDo   td ON ct.MaTD = td.MaTD
                WHERE ct.MaNV = @MaNV";
            DataTable dtCM = DataProvider.ExecuteQuery(sqlCM, new[] { new SqlParameter("@MaNV", maNV) });

            var dsSources = new List<ReportDataSource>
            {
                new ReportDataSource("dsHoSo",      dtHoSo),
                new ReportDataSource("dsNgoaiNgu",  dtNN),
                new ReportDataSource("dsChuyenMon", dtCM)
            };

            frmInHoSoNhanVien frm = new frmInHoSoNhanVien();
            frm.HienThiBaoCao("rptHoSoNhanVien.rdlc", dsSources,
                "Hồ sơ nhân viên - " + txtsyhonv.Text + " " + txtsytennv.Text);
            frm.ShowDialog();
        }

        // TAB 2: TRÌNH ĐỘ — NGOẠI NGỮ & CHUYÊN MÔN
        private void LoadChiTietNgoaiNgu(string maNV)
        {
            string sql = @"SELECT ct.ID, ct.MaNV AS manv,
                               nn.TenNN AS mangoaingu, td.TenTD AS TrinhDo,
                               ct.NgayCap, ct.NoiCap
                           FROM ChiTietNgoaiNgu ct
                           JOIN NgoaiNgu nn ON ct.MaNN = nn.MaNN
                           JOIN TrinhDo  td ON ct.MaTD = td.MaTD
                           WHERE ct.MaNV=@MaNV";
            dgv_ChitietNN.DataSource = DataProvider.ExecuteQuery(sql, new[] { new SqlParameter("@MaNV", maNV) });
        }

        private void LoadChiTietChuyenMon(string maNV)
        {
            string sql = @"SELECT ct.ID, ct.MaNV AS manv,
                               cm.TenCM AS MaChuyenMon, td.TenTD AS MaTrinhDo,
                               ct.NgayCap, ct.Truong
                           FROM ChiTietChuyenMon ct
                           JOIN ChuyenMon cm ON ct.MaCM = cm.MaCM
                           JOIN TrinhDo   td ON ct.MaTD = td.MaTD
                           WHERE ct.MaNV=@MaNV";
            dgv_ChitietCM.DataSource = DataProvider.ExecuteQuery(sql, new[] { new SqlParameter("@MaNV", maNV) });
        }

        private void btnCapNhatNN_Click(object sender, EventArgs e)
        {
            string maNV = txtknmanv.Text.Trim();
            if (maNV == "") { MessageBox.Show("Chọn nhân viên trước!"); return; }

            // Validate trước khi xóa
            foreach (DataGridViewRow row in dgv_ChitietNN.Rows)
            {
                if (row.IsNewRow) continue;
                string tenNN = row.Cells["mann"].Value?.ToString();
                string tenTD = row.Cells["TrinhDo"].Value?.ToString();
                if (string.IsNullOrEmpty(tenNN)) { MessageBox.Show("Vui lòng nhập Tên Ngoại Ngữ cho tất cả các dòng!"); return; }
                if (string.IsNullOrEmpty(tenTD)) { MessageBox.Show($"Dòng '{tenNN}': chưa nhập Trình Độ!"); return; }
            }

            DataProvider.ExecuteNonQuery("DELETE FROM ChiTietNgoaiNgu WHERE MaNV=@MaNV",
                new[] { new SqlParameter("@MaNV", maNV) });

            int soLuongLuu = 0;
            foreach (DataGridViewRow row in dgv_ChitietNN.Rows)
            {
                if (row.IsNewRow) continue;
                string tenNN = row.Cells["mann"].Value?.ToString();
                string tenTD = row.Cells["TrinhDo"].Value?.ToString();
                string noiCap = row.Cells["NoiCap"].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(tenNN)) continue;

                object maNN = DataProvider.ExecuteScalar("SELECT MaNN FROM NgoaiNgu WHERE TenNN=@Ten", new[] { new SqlParameter("@Ten", tenNN) });
                object maTD = DataProvider.ExecuteScalar("SELECT MaTD FROM TrinhDo WHERE TenTD=@Ten", new[] { new SqlParameter("@Ten", tenTD) });

                if (maNN == null) { MessageBox.Show($"Ngoại ngữ '{tenNN}' không tồn tại trong danh mục!"); LoadChiTietNgoaiNgu(maNV); return; }
                if (maTD == null) { MessageBox.Show($"Trình độ '{tenTD}' không tồn tại trong danh mục!"); LoadChiTietNgoaiNgu(maNV); return; }

                
                object ngayRaw = row.Cells["ngaycapnn"].Value;
                DateTime ngayCap = default;
                if (ngayRaw is DateTime dtNN)
                    ngayCap = dtNN;
                else if (ngayRaw != null && ngayRaw != DBNull.Value)
                    DateTime.TryParseExact(ngayRaw.ToString(), new[] { "dd/MM/yyyy", "M/d/yyyy", "yyyy-MM-dd" },
                        null, System.Globalization.DateTimeStyles.None, out ngayCap);

                DataProvider.ExecuteNonQuery(
                    "INSERT INTO ChiTietNgoaiNgu(MaNV, MaNN, MaTD, NgayCap, NoiCap) VALUES(@MaNV, @MaNN, @MaTD, @NC, @NoiCap)",
                    new[] {
                        new SqlParameter("@MaNV",   maNV),
                        new SqlParameter("@MaNN",   maNN),
                        new SqlParameter("@MaTD",   maTD),
                        new SqlParameter("@NC",     ngayCap == default ? (object)DBNull.Value : ngayCap),
                        new SqlParameter("@NoiCap", noiCap)
                    });
                soLuongLuu++;
            }
            MessageBox.Show($"Cập nhật {soLuongLuu} ngoại ngữ thành công!");
            LoadChiTietNgoaiNgu(maNV);
        }

        private void btnCapNhatBC_Click(object sender, EventArgs e)
        {
            string maNV = txtknmanv.Text.Trim();
            if (maNV == "") { MessageBox.Show("Chọn nhân viên trước!"); return; }

            DataProvider.ExecuteNonQuery("DELETE FROM ChiTietChuyenMon WHERE MaNV=@MaNV",
                new[] { new SqlParameter("@MaNV", maNV) });

            int soLuongLuu = 0;
            foreach (DataGridViewRow row in dgv_ChitietCM.Rows)
            {
                if (row.IsNewRow) continue;
                string tenCM = row.Cells["MaChuyenMon"].Value?.ToString();
                string tenTD = row.Cells["MaTrinhDo"].Value?.ToString();
                string truong = row.Cells["Truong"].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(tenCM)) continue;

                object maCM = DataProvider.ExecuteScalar("SELECT MaCM FROM ChuyenMon WHERE TenCM=@Ten", new[] { new SqlParameter("@Ten", tenCM) });
                object maTD = DataProvider.ExecuteScalar("SELECT MaTD FROM TrinhDo WHERE TenTD=@Ten", new[] { new SqlParameter("@Ten", tenTD) });
                if (maCM == null)
                {
                    MessageBox.Show($"Chuyên môn '{tenCM}' không tồn tại trong danh mục!\nVui lòng kiểm tra lại.",
                        "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadChiTietChuyenMon(maNV);
                    return;
                }
                if (maTD == null)
                {
                    MessageBox.Show($"Trình độ '{tenTD}' không tồn tại trong danh mục!\nVui lòng kiểm tra lại.",
                        "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadChiTietChuyenMon(maNV);
                    return;
                }


                object ngayRaw = row.Cells["NgayCap"].Value;
                DateTime ngayCap = default;
                if (ngayRaw is DateTime dtCM)
                    ngayCap = dtCM;
                else if (ngayRaw != null && ngayRaw != DBNull.Value)
                    DateTime.TryParseExact(ngayRaw.ToString(), new[] { "dd/MM/yyyy", "M/d/yyyy", "yyyy-MM-dd" },
                        null, System.Globalization.DateTimeStyles.None, out ngayCap);
                DataProvider.ExecuteNonQuery(
                    "INSERT INTO ChiTietChuyenMon(MaNV,MaCM,MaTD,NgayCap,Truong) VALUES(@MaNV,@MaCM,@MaTD,@NC,@Truong)",
                    new[] {
                        new SqlParameter("@MaNV",   maNV),
                        new SqlParameter("@MaCM",   maCM),
                        new SqlParameter("@MaTD",   maTD),
                        new SqlParameter("@NC",     ngayCap == default ? (object)DBNull.Value : ngayCap),
                        new SqlParameter("@Truong", truong)
                    });
                soLuongLuu++;
            }
            MessageBox.Show($"Cập nhật {soLuongLuu} bằng cấp thành công!");
            LoadChiTietChuyenMon(maNV);
        }

        // TAB 3: HỢP ĐỒNG LAO ĐỘNg
        private void LoadChiTietHopDong(string maNV)
        {
            string sql = @"SELECT hd.MaHD, lhd.TenLoai AS TenLoaiHD, hd.MaLoaiHD,
                               hd.MaNV AS MaNVHD, hd.NgayKy AS Ngayky,
                               hd.NgayKetThuc AS NgayKT, hd.LuongCoBan AS luongcb
                           FROM HopDong hd
                           JOIN LoaiHopDong lhd ON hd.MaLoaiHD = lhd.MaLoaiHD
                           WHERE hd.MaNV=@MaNV ORDER BY hd.NgayKy";
            dgv_ChiTietHopDong.DataSource = DataProvider.ExecuteQuery(sql, new[] { new SqlParameter("@MaNV", maNV) });
            if (dgv_ChiTietHopDong.Columns.Contains("MaNVHD")) dgv_ChiTietHopDong.Columns["MaNVHD"].Visible = false;
            if (dgv_ChiTietHopDong.Columns.Contains("MaLoaiHD")) dgv_ChiTietHopDong.Columns["MaLoaiHD"].Visible = false;
        }

        private void dgv_ChiTietHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv_ChiTietHopDong.Rows[e.RowIndex];
            txthdmahd.Text = row.Cells["MaHD"].Value?.ToString();
            txthdmanv.Text = txtsymanv.Text;
            txthdhotennv.Text = txtsyhonv.Text + " " + txtsytennv.Text;
            if (row.Cells["MaLoaiHD"].Value != null)
                cbohdloaihd.SelectedValue = row.Cells["MaLoaiHD"].Value.ToString();
            if (row.Cells["Ngayky"].Value != DBNull.Value)
            { dtpHDNgayKy.Checked = true; dtpHDNgayKy.Value = Convert.ToDateTime(row.Cells["Ngayky"].Value); }

            if (row.Cells["NgayKT"].Value != DBNull.Value)
            {
                DateTime ngayKT = Convert.ToDateTime(row.Cells["NgayKT"].Value);
                if (ngayKT >= DateTimePicker.MinimumDateTime && ngayKT <= DateTimePicker.MaximumDateTime)
                {
                    dtpHDNgayKT.Checked = true;
                    dtpHDNgayKT.Value = ngayKT;
                }
                else
                    dtpHDNgayKT.Checked = false;
            }
            else
                dtpHDNgayKT.Checked = false;

            txthdluongcb.Text = row.Cells["luongcb"].Value?.ToString();
        }

        private void btnHDThem_Click(object sender, EventArgs e)
        {
            if (txtsymanv.Text.Trim() == "") { MessageBox.Show("Chọn nhân viên trước!"); return; }
            txthdmahd.Clear();
            dtpHDNgayKy.Value = DateTime.Today;   
            dtpHDNgayKT.Checked = false;             
            txthdluongcb.Clear();
            txthdmanv.Text = txtsymanv.Text;
            txthdhotennv.Text = txtsyhonv.Text + " " + txtsytennv.Text;
            cbohdloaihd.SelectedIndex = -1;
            txthdmahd.Focus();
        }

        private void btnHDLuu_Click(object sender, EventArgs e)
        {
            if (txthdmahd.Text.Trim() == "") { MessageBox.Show("Nhập số hợp đồng!"); return; }
            if (txthdmanv.Text.Trim() == "") { MessageBox.Show("Thiếu mã nhân viên!"); return; }
            if (cbohdloaihd.SelectedValue == null) { MessageBox.Show("Chọn loại hợp đồng!"); return; }
            
            DateTime ngayKy = dtpHDNgayKy.Value.Date;
            DateTime? ngayKT = dtpHDNgayKT.Checked ? dtpHDNgayKT.Value.Date : (DateTime?)null;
            
            decimal.TryParse(txthdluongcb.Text.Trim(), out decimal luongCB);

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM HopDong WHERE MaHD=@MaHD",
                new[] { new SqlParameter("@MaHD", txthdmahd.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE HopDong SET MaLoaiHD=@ML,NgayKy=@NK,NgayKetThuc=@NKT,LuongCoBan=@LCB WHERE MaHD=@MaHD"
                : "INSERT INTO HopDong(MaHD,MaNV,MaLoaiHD,NgayKy,NgayKetThuc,LuongCoBan) VALUES(@MaHD,@MaNV,@ML,@NK,@NKT,@LCB)";

            SqlParameter[] p = {
                new SqlParameter("@MaHD", txthdmahd.Text.Trim()),
                new SqlParameter("@MaNV", txthdmanv.Text.Trim()),
                new SqlParameter("@ML",   cbohdloaihd.SelectedValue.ToString()),
                new SqlParameter("@NK",  ngayKy),
                new SqlParameter("@NKT", ngayKT.HasValue ? (object)ngayKT.Value : DBNull.Value),
                new SqlParameter("@LCB",  luongCB)
            };
            if (DataProvider.ExecuteNonQuery(sql, p) > 0)
            { MessageBox.Show(count > 0 ? "Cập nhật hợp đồng thành công!" : "Thêm hợp đồng thành công!"); LoadChiTietHopDong(txthdmanv.Text); }
        }

        private void btnHDSua_Click(object sender, EventArgs e)
        {
            if (txthdmahd.Text.Trim() == "") { MessageBox.Show("Chọn hợp đồng cần sửa!"); return; }
            MessageBox.Show("Sửa thông tin rồi nhấn Lưu để cập nhật!", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtpHDNgayKy.Focus();
        }

        private void btnHDXoa_Click(object sender, EventArgs e)
        {
            if (txthdmahd.Text.Trim() == "") { MessageBox.Show("Chọn hợp đồng cần xóa!"); return; }
            if (MessageBox.Show("Xóa hợp đồng '" + txthdmahd.Text + "'?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataProvider.ExecuteNonQuery("DELETE FROM HoSoLuong WHERE MaHD=@MaHD", new[] { new SqlParameter("@MaHD", txthdmahd.Text.Trim()) });
                if (DataProvider.ExecuteNonQuery("DELETE FROM HopDong WHERE MaHD=@MaHD", new[] { new SqlParameter("@MaHD", txthdmahd.Text.Trim()) }) > 0)
                { MessageBox.Show("Xóa thành công!"); LoadChiTietHopDong(txthdmanv.Text); txthdmahd.Clear(); }
            }
        }

        // TAB 4: HỒ SƠ LƯƠNG
        private void LoadHoSoLuong(string maNV)
        {
            var dtHD = DataProvider.ExecuteQuery(
                "SELECT MaHD FROM HopDong WHERE MaNV=@MaNV ORDER BY NgayKy",
                new[] { new SqlParameter("@MaNV", maNV) });
            cbohslMaHD.DisplayMember = "MaHD"; cbohslMaHD.ValueMember = "MaHD";
            cbohslMaHD.DataSource = dtHD;
            cbohslMaHD.SelectedIndex = -1;

            string sql = "SELECT ID AS HSLId, MaHD, MucLuong, NgayLL FROM HoSoLuong WHERE MaNV=@MaNV ORDER BY NgayLL DESC";
            dgv_Hosoluong.AutoGenerateColumns = false;
            dgv_Hosoluong.DataSource = DataProvider.ExecuteQuery(sql, new[] { new SqlParameter("@MaNV", maNV) });
        }

        private void dgv_Hosoluong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv_Hosoluong.Rows[e.RowIndex];
            txthslmanv.Text = txtsymanv.Text;
            txthslhotennv.Text = txtsyhonv.Text + " " + txtsytennv.Text;
            if (row.Cells["HSLMahd"].Value != DBNull.Value)
                cbohslMaHD.Text = row.Cells["HSLMahd"].Value?.ToString();
            txthslmucluong.Text = row.Cells["HSLMucLuong"].Value?.ToString();
            if (row.Cells["HSLNgayLL"].Value != DBNull.Value)
            { dtpHSLNgayLL.Checked = true; dtpHSLNgayLL.Value = Convert.ToDateTime(row.Cells["HSLNgayLL"].Value); }
            else
                dtpHSLNgayLL.Checked = false;
        }

        private void btnLuongThem_Click(object sender, EventArgs e)
        {
            if (txtsymanv.Text.Trim() == "") { MessageBox.Show("Chọn nhân viên trước!"); return; }
            cbohslMaHD.SelectedIndex = -1;
            txthslmucluong.Clear();
            dtpHSLNgayLL.Value = DateTime.Today;
            txthslmanv.Text = txtsymanv.Text;
            txthslhotennv.Text = txtsyhonv.Text + " " + txtsytennv.Text;
            txthslmucluong.Focus();
        }

        private void btnLuongLuu_Click(object sender, EventArgs e)
        {
            if (txthslmanv.Text.Trim() == "" || txthslmucluong.Text.Trim() == "")
            { MessageBox.Show("Nhập đầy đủ: Mức lương và Ngày lên lương!"); return; }
            if (!decimal.TryParse(txthslmucluong.Text.Trim(), out decimal mucLuong))
            { MessageBox.Show("Mức lương phải là số! Ví dụ: 10000000"); return; }

            DateTime ngayLL = dtpHSLNgayLL.Value.Date;   

            string MaHD = cbohslMaHD.Text.Trim();
            SqlParameter[] p = {
                new SqlParameter("@MaNV", txthslmanv.Text.Trim()),
                new SqlParameter("@MaHD", MaHD == "" ? (object)DBNull.Value : MaHD),
                new SqlParameter("@ML",   mucLuong),
                new SqlParameter("@NLL", ngayLL),
            };
            if (DataProvider.ExecuteNonQuery("INSERT INTO HoSoLuong(MaNV,MaHD,MucLuong,NgayLL) VALUES(@MaNV,@MaHD,@ML,@NLL)", p) > 0)
            { MessageBox.Show("Thêm hồ sơ lương thành công!"); LoadHoSoLuong(txthslmanv.Text); }
        }

        private void btnLuongSua_Click(object sender, EventArgs e)
        {
            if (dgv_Hosoluong.SelectedRows.Count == 0) { MessageBox.Show("Chọn dòng lương cần sửa!"); return; }
            if (!decimal.TryParse(txthslmucluong.Text.Trim(), out decimal mucLuong)) { MessageBox.Show("Mức lương phải là số!"); return; }
            DateTime ngayLL = dtpHSLNgayLL.Value.Date;

            var dt = (System.Data.DataTable)dgv_Hosoluong.DataSource;
            int id = Convert.ToInt32(dt.Rows[dgv_Hosoluong.SelectedRows[0].Index]["HSLId"]);
            string MaHD = cbohslMaHD.Text.Trim();
            SqlParameter[] p = {
                new SqlParameter("@ML",   mucLuong),
                new SqlParameter("@NLL",  ngayLL),
                new SqlParameter("@MaHD", MaHD == "" ? (object)DBNull.Value : MaHD),
                new SqlParameter("@ID",   id)
            };
            if (DataProvider.ExecuteNonQuery("UPDATE HoSoLuong SET MucLuong=@ML,NgayLL=@NLL,MaHD=@MaHD WHERE ID=@ID", p) > 0)
            { MessageBox.Show("Cập nhật lương thành công!"); LoadHoSoLuong(txthslmanv.Text); }
        }

        private void btnLuongXoa_Click(object sender, EventArgs e)
        {
            if (dgv_Hosoluong.SelectedRows.Count == 0) { MessageBox.Show("Chọn dòng lương cần xóa!"); return; }
            if (MessageBox.Show("Xóa dòng lương này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var dt = (System.Data.DataTable)dgv_Hosoluong.DataSource;
                int id = Convert.ToInt32(dt.Rows[dgv_Hosoluong.SelectedRows[0].Index]["HSLId"]);
                if (DataProvider.ExecuteNonQuery("DELETE FROM HoSoLuong WHERE ID=@ID", new[] { new SqlParameter("@ID", id) }) > 0)
                { MessageBox.Show("Xóa thành công!"); LoadHoSoLuong(txthslmanv.Text); }
            }
        }
    }
}