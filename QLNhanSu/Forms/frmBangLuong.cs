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
                       ORDER BY NgayKy DESC   -- dùng TOP 1 thay vì MAX
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

            txtNgaycongchuan.Text = row.Cells["songaylv"].Value?.ToString();      
            txtluongngaycong.Text = row.Cells["Luonglv"].Value?.ToString();       
            txtluongtangca.Text = row.Cells["luongtangca"].Value?.ToString();   
            txtot1.Text = row.Cells["soot1"].Value?.ToString();        
            txtot2.Text = row.Cells["SoOT2"].Value?.ToString();         
            txtsongayphep.Text = row.Cells["Ngaynghiphep"].Value?.ToString();  
            txtpckhac.Text = row.Cells["phucapkhac"].Value?.ToString();    

            var ngayNgungViec = row.Cells["ngayngungviec"].Value;                 
            if (ngayNgungViec != null && ngayNgungViec != DBNull.Value)
                txtngayngungviec.Text = Convert.ToDateTime(ngayNgungViec).ToString("dd/MM/yyyy");
            else
                txtngayngungviec.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text.Trim() == "") { MessageBox.Show("Chọn nhân viên trước!"); return; }

            decimal luongCB = 0, ngayCong = 0, luongNgayCong = 0;
            decimal luongTC = 0, phuCap = 0, pcKhac = 0, bhxh = 0, ot1 = 0, ot2 = 0;
            decimal soNgayPhep = 0, thuCLanh = 0;

            decimal.TryParse(txtluongcb.Text.Replace(",", "").Replace(".", ""), out luongCB);
            decimal.TryParse(txtNgaycongchuan.Text, out ngayCong);
            decimal.TryParse(txtluongngaycong.Text.Replace(",", ""), out luongNgayCong);
            decimal.TryParse(txtluongtangca.Text.Replace(",", ""), out luongTC);
            decimal.TryParse(txtot1.Text, out ot1);
            decimal.TryParse(txtot2.Text, out ot2);
            decimal.TryParse(txtsongayphep.Text, out soNgayPhep);
            decimal.TryParse(txtpckhac.Text.Replace(",", ""), out pcKhac);

            // Tính phụ cấp từ chức vụ
            string sqlPC = @"SELECT ISNULL(cv.PhuCap, 0) FROM NhanVien nv 
                             LEFT JOIN ChucVu cv ON nv.MaCV = cv.MaCV 
                             WHERE nv.MaNV = @MaNV";
            object pcObj = DataProvider.ExecuteScalar(sqlPC, new[] { new SqlParameter("@MaNV", txtmanv.Text) });
            phuCap = pcObj != null && pcObj != DBNull.Value ? Convert.ToDecimal(pcObj) : 0;

            // Tính BHXH = 10.5% lương cơ bản
            bhxh = Math.Round(luongCB * 0.105m, 0);

            // Tính thực lãnh
            thuCLanh = luongNgayCong + luongTC + phuCap + pcKhac - bhxh;

            // Lấy tháng/năm hiện tại
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;

            DateTime? ngayNV = null;
            if (txtngayngungviec.Text.Trim() != "")
            {
                DateTime d;
                if (DateTime.TryParseExact(txtngayngungviec.Text, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out d)) ngayNV = d;
            }

            // Kiểm tra đã có bảng lương tháng này chưa
            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM BangLuong WHERE MaNV=@MaNV AND Thang=@T AND Nam=@N",
                new[] {
                    new SqlParameter("@MaNV", txtmanv.Text),
                    new SqlParameter("@T", thang),
                    new SqlParameter("@N", nam)
                }));

            string sql = count > 0
                ? @"UPDATE BangLuong SET LuongCoBan=@LCB, NgayCongChuan=@NCC,
                    LuongNgayCong=@LNC, LuongTangCa=@LTC, PhuCap=@PC,
                    PhuCapKhac=@PCK, BHXHvaBHYT=@BHXH, OT1=@OT1, OT2=@OT2,
                    SoNgayPhep=@SNP, NgayNgungViec=@NNV, ThuCLanh=@TCL
                    WHERE MaNV=@MaNV AND Thang=@T AND Nam=@N"
                : @"INSERT INTO BangLuong(MaNV,Thang,Nam,LuongCoBan,NgayCongChuan,
                    LuongNgayCong,LuongTangCa,PhuCap,PhuCapKhac,BHXHvaBHYT,
                    OT1,OT2,SoNgayPhep,NgayNgungViec,ThuCLanh)
                    VALUES(@MaNV,@T,@N,@LCB,@NCC,@LNC,@LTC,@PC,@PCK,@BHXH,
                    @OT1,@OT2,@SNP,@NNV,@TCL)";

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
                new SqlParameter("@SNP",  soNgayPhep),
                new SqlParameter("@NNV",  ngayNV.HasValue ? (object)ngayNV.Value : DBNull.Value),
                new SqlParameter("@TCL",  thuCLanh)
            };

            if (DataProvider.ExecuteNonQuery(sql, p) > 0)
            {
                MessageBox.Show(count > 0
                    ? $"Cập nhật lương tháng {thang}/{nam} thành công!\nThực lãnh: {thuCLanh:N0} đ"
                    : $"Lưu lương tháng {thang}/{nam} thành công!\nThực lãnh: {thuCLanh:N0} đ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBangLuong(txtmanv.Text);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNgaycongchuan.Clear(); txtluongngaycong.Clear();
            txtluongtangca.Clear(); txtot1.Clear(); txtot2.Clear();
            txtsongayphep.Clear(); txtpckhac.Clear(); txtngayngungviec.Clear();
        }

        private void btnChamLuong_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đã chọn nhân viên chưa
            if (txtmanv.Text.Trim() == "")
            { MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // 2. Đọc dữ liệu chấm công từ các ô nhập
            decimal ngayCongChuan = 0, ot1 = 0, ot2 = 0, ngayPhep = 0, ngayNghi = 0, pcKhac = 0;
            decimal.TryParse(txtNgaycongchuan.Text.Trim(), out ngayCongChuan);
            decimal.TryParse(txtot1.Text.Trim(), out ot1);
            decimal.TryParse(txtot2.Text.Trim(), out ot2);
            decimal.TryParse(txtsongayphep.Text.Trim(), out ngayPhep);
            decimal.TryParse(txtpckhac.Text.Replace(",", ""), out pcKhac);

            if (ngayCongChuan <= 0)
            { MessageBox.Show("Vui lòng nhập Ngày công chuẩn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // 3. Lấy lương cơ bản
            decimal luongCB = 0;
            decimal.TryParse(txtluongcb.Text.Replace(",", "").Replace(".", ""), out luongCB);
            if (luongCB <= 0)
            { MessageBox.Show("Nhân viên chưa có lương cơ bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // 4. Lấy tỉ lệ lương từ bảng TiLeLuong theo phòng/tổ/tháng/năm
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;

            string sqlNV = "SELECT MaPB, MaTo FROM NhanVien WHERE MaNV=@MaNV";
            DataTable dtNV = DataProvider.ExecuteQuery(sqlNV, new[] { new SqlParameter("@MaNV", txtmanv.Text) });
            string maPB = dtNV.Rows.Count > 0 ? dtNV.Rows[0]["MaPB"].ToString() : "";
            string maTo = dtNV.Rows.Count > 0 ? dtNV.Rows[0]["MaTo"]?.ToString() ?? "" : "";

            object tiLeObj = DataProvider.ExecuteScalar(
                @"SELECT TOP 1 ISNULL(TiLeLuong, 100) FROM TiLeLuong 
          WHERE MaPB=@MaPB AND Thang=@T AND Nam=@N ORDER BY MaTo",
                new[] { new SqlParameter("@MaPB", maPB),
                new SqlParameter("@T", thang),
                new SqlParameter("@N", nam) });
            decimal tiLe = tiLeObj != null && tiLeObj != DBNull.Value ? Convert.ToDecimal(tiLeObj) / 100m : 1m;

            // 5. Lấy phụ cấp chức vụ
            object pcObj = DataProvider.ExecuteScalar(
                "SELECT ISNULL(cv.PhuCap,0) FROM NhanVien nv LEFT JOIN ChucVu cv ON nv.MaCV=cv.MaCV WHERE nv.MaNV=@MaNV",
                new[] { new SqlParameter("@MaNV", txtmanv.Text) });
            decimal phuCap = pcObj != null && pcObj != DBNull.Value ? Convert.ToDecimal(pcObj) : 0;

            // 6. Tính toán
            // Lương 1 ngày công
            decimal luongMotNgay = luongCB * tiLe / ngayCongChuan;

            // Số ngày thực tế = chuẩn + ngày phép (nghỉ phép vẫn được tính lương)
            decimal ngayThucTe = ngayCongChuan + ngayPhep;

            // Lương ngày công
            decimal luongNgayCong = Math.Round(luongMotNgay * ngayThucTe, 0);

            // Lương tăng ca: OT1 = 150%, OT2 (ngày CN/lễ) = 200%
            decimal luongMotGio = luongCB / ngayCongChuan / 8;
            decimal luongTangCa = Math.Round(luongMotGio * ot1 * 1.5m + luongMotGio * ot2 * 2.0m, 0);

            // BHXH + BHYT = 10.5% lương cơ bản (NLĐ đóng)
            decimal bhxh = Math.Round(luongCB * 0.105m, 0);

            // Thực lãnh
            decimal thuCLanh = luongNgayCong + luongTangCa + phuCap + pcKhac - bhxh;

            // 7. Hiển thị kết quả lên form
            txtluongngaycong.Text = luongNgayCong.ToString("N0");
            txtluongtangca.Text = luongTangCa.ToString("N0");
            txtbhxhvabhyt.Text    = bhxh.ToString("N0");
            txtthuclanh.Text = thuCLanh.ToString("N0");

            MessageBox.Show(
                $"✅ Đã tính xong! Tháng {thang}/{nam}\n\n" +
                $"Lương ngày công : {luongNgayCong:N0} đ\n" +
                $"Lương tăng ca   : {luongTangCa:N0} đ\n" +
                $"Phụ cấp CV      : {phuCap:N0} đ\n" +
                $"Phụ cấp khác    : {pcKhac:N0} đ\n" +
                $"BHXH & BHYT     : -{bhxh:N0} đ\n" +
                $"────────────────────\n" +
                $"Thực lãnh       : {thuCLanh:N0} đ",
                "Kết quả chấm công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text.Trim() == "")
            { MessageBox.Show("Chọn nhân viên trước!"); return; }

            // Tính lương
            decimal luongCB = 0, ngayCong = 0, luongNgayCong = 0;
            decimal luongTC = 0, phuCap = 0, pcKhac = 0, bhxh = 0, ot1 = 0, ot2 = 0;
            decimal soNgayPhep = 0, thuCLanh = 0;

            decimal.TryParse(txtluongcb.Text.Replace(",", "").Replace(".", ""), out luongCB);
            decimal.TryParse(txtNgaycongchuan.Text, out ngayCong);
            decimal.TryParse(txtluongngaycong.Text.Replace(",", ""), out luongNgayCong);
            decimal.TryParse(txtluongtangca.Text.Replace(",", ""), out luongTC);
            decimal.TryParse(txtot1.Text, out ot1);
            decimal.TryParse(txtot2.Text, out ot2);
            decimal.TryParse(txtsongayphep.Text, out soNgayPhep);
            decimal.TryParse(txtpckhac.Text.Replace(",", ""), out pcKhac);

            // Lấy phụ cấp từ chức vụ
            object pcObj = DataProvider.ExecuteScalar(
                "SELECT ISNULL(cv.PhuCap,0) FROM NhanVien nv LEFT JOIN ChucVu cv ON nv.MaCV=cv.MaCV WHERE nv.MaNV=@MaNV",
                new[] { new SqlParameter("@MaNV", txtmanv.Text) });
            phuCap = pcObj != null && pcObj != DBNull.Value ? Convert.ToDecimal(pcObj) : 0;

            // Tính BHXH = 10.5% lương cơ bản
            bhxh = Math.Round(luongCB * 0.105m, 0);
            thuCLanh = luongNgayCong + luongTC + phuCap + pcKhac - bhxh;

            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;

            DateTime? ngayNV = null;
            if (txtngayngungviec.Text.Trim() != "")
            {
                DateTime d;
                if (DateTime.TryParseExact(txtngayngungviec.Text, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out d)) ngayNV = d;
            }

            // Lưu vào DB
            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM BangLuong WHERE MaNV=@MaNV AND Thang=@T AND Nam=@N",
                new[] { new SqlParameter("@MaNV", txtmanv.Text),
                new SqlParameter("@T", thang), new SqlParameter("@N", nam) }));

            string sql = count > 0
                ? @"UPDATE BangLuong SET LuongCoBan=@LCB,NgayCongChuan=@NCC,
            LuongNgayCong=@LNC,LuongTangCa=@LTC,PhuCap=@PC,PhuCapKhac=@PCK,
            BHXHvaBHYT=@BHXH,OT1=@OT1,OT2=@OT2,SoNgayPhep=@SNP,
            NgayNgungViec=@NNV,ThuCLanh=@TCL WHERE MaNV=@MaNV AND Thang=@T AND Nam=@N"
                : @"INSERT INTO BangLuong(MaNV,Thang,Nam,LuongCoBan,NgayCongChuan,
            LuongNgayCong,LuongTangCa,PhuCap,PhuCapKhac,BHXHvaBHYT,
            OT1,OT2,SoNgayPhep,NgayNgungViec,ThuCLanh)
            VALUES(@MaNV,@T,@N,@LCB,@NCC,@LNC,@LTC,@PC,@PCK,
            @BHXH,@OT1,@OT2,@SNP,@NNV,@TCL)";

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
        new SqlParameter("@SNP",  soNgayPhep),
        new SqlParameter("@NNV",  ngayNV.HasValue ? (object)ngayNV.Value : DBNull.Value),
        new SqlParameter("@TCL",  thuCLanh)
    };

            if (DataProvider.ExecuteNonQuery(sql, p) > 0)
            {
                LoadBangLuong(txtmanv.Text);

                // Mở phiếu lương luôn sau khi tính
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
            LEFT JOIN PhongBan p ON nv.MaPB = p.MaPB
            LEFT JOIN ChucVu cv  ON nv.MaCV = cv.MaCV
            WHERE bl.MaNV=@MaNV AND bl.Thang=@T AND bl.Nam=@N";

                DataTable dt = DataProvider.ExecuteQuery(sqlBC, new[] {
            new SqlParameter("@MaNV", txtmanv.Text.Trim()),
            new SqlParameter("@T", thang),
            new SqlParameter("@N", nam)
        });

                frmXemBaoCao frm = new frmXemBaoCao();
                var dsSources = new List<Microsoft.Reporting.WinForms.ReportDataSource>
{
    new Microsoft.Reporting.WinForms.ReportDataSource("dsPhieuLuong", dt)
};
                frm.HienThiBaoCao(
                    "rptPhieuLuong.rdlc",
                    dsSources,
                    $"Phiếu lương tháng {thang}/{nam} - {txthoten.Text}"
                );
                frm.ShowDialog();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text.Trim() == "") { MessageBox.Show("Chọn nhân viên trước!"); return; }

            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;

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
    }
}
