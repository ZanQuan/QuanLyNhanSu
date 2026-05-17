using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLNhanSu.Forms
{
    public partial class frmPhanQuyen : Form
    {
        private DataTable _dtQuyen;
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.ExecuteQuery(
                "SELECT MaTK, TenDangNhap + ' (' + VaiTro + ')' AS TenHienThi FROM TaiKhoan ORDER BY TenDangNhap");

            cboNguoiDung.DisplayMember = "TenHienThi";
            cboNguoiDung.ValueMember = "MaTK";
            cboNguoiDung.DataSource = dt;
            cboNguoiDung.SelectedIndex = -1;
        }

        private void cboNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNguoiDung.SelectedIndex < 0 || cboNguoiDung.SelectedValue == null) return;
            string maTK = cboNguoiDung.SelectedValue.ToString();
            LoadPhanQuyen(maTK);
        }

        private void LoadPhanQuyen(string maTK)
        {
            string sql = @"SELECT MaQuyen AS idform, TenChucNang AS tenform,
                       CAST(CoQuyen AS bit) AS rights
                       FROM PhanQuyen
                       WHERE MaTK = @MaTK
                       ORDER BY TenChucNang";

            _dtQuyen = DataProvider.ExecuteQuery(sql,
                new[] { new SqlParameter("@MaTK", maTK) });

            if (_dtQuyen.Rows.Count == 0)
            {
                string[] danhSachChucNang = {
                "Hồ sơ nhân viên",    "Danh mục phòng ban",  "Danh mục chức vụ",
                "Danh mục dân tộc",   "Danh mục tôn giáo",   "Danh mục trình độ",
                "Danh mục chuyên môn","Danh mục ngoại ngữ",  "Danh mục tổ",
                "Danh mục loại HĐ",   "Bảng lương",          "Tỉ lệ lương",
                "Phân quyền",         "Quản lý tài khoản",   "Báo cáo nhân sự",
                "Báo cáo lương"
            };

                foreach (string cn in danhSachChucNang)
                    DataProvider.ExecuteNonQuery(
                        "INSERT INTO PhanQuyen(MaTK, TenChucNang, CoQuyen) VALUES(@MaTK, @CN, 0)",
                        new[] {
                        new SqlParameter("@MaTK", maTK),
                        new SqlParameter("@CN",   cn)
                        });

                _dtQuyen = DataProvider.ExecuteQuery(sql, new[] { new SqlParameter("@MaTK", maTK) });
            }

            dgvPhanQuyen.DataSource = _dtQuyen;

            if (dgvPhanQuyen.Columns["idform"] != null) { dgvPhanQuyen.Columns["idform"].Visible = false; }
            if (dgvPhanQuyen.Columns["tenform"] != null) { dgvPhanQuyen.Columns["tenform"].HeaderText = "Chức năng"; dgvPhanQuyen.Columns["tenform"].Width = 220; dgvPhanQuyen.Columns["tenform"].ReadOnly = true; }
            if (dgvPhanQuyen.Columns["rights"] != null) { dgvPhanQuyen.Columns["rights"].HeaderText = "Có quyền"; dgvPhanQuyen.Columns["rights"].Width = 80; }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboNguoiDung.SelectedIndex < 0 || cboNguoiDung.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongCapNhat = 0;

            
            foreach (DataRow row in _dtQuyen.Rows)
            {
                string idForm = row["idform"].ToString();
                bool quyen = row["rights"] != DBNull.Value && Convert.ToBoolean(row["rights"]);

                DataProvider.ExecuteNonQuery(
                    "UPDATE PhanQuyen SET CoQuyen = @CQ WHERE MaQuyen = @ID",
                    new[] {
                    new SqlParameter("@CQ", quyen ? 1 : 0),
                    new SqlParameter("@ID", int.Parse(idForm))
                    });
                soLuongCapNhat++;
            }

            MessageBox.Show($"Cập nhật {soLuongCapNhat} quyền thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
}