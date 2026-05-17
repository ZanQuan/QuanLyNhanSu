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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            cbogroup.Items.Clear();
            cbogroup.Items.Add("Admin");
            cbogroup.Items.Add("NhanVien");
            cbogroup.SelectedIndex = 1;

            LoadData();
        }
        private void LoadData()
        {
            string sql = "SELECT MaTK, TenDangNhap AS id, VaiTro AS nhom, TrangThai FROM TaiKhoan ORDER BY TenDangNhap";
            dgvUser.DataSource = DataProvider.ExecuteQuery(sql);

            if (dgvUser.Columns["Pass"] != null)
                dgvUser.Columns["Pass"].Visible = false;
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvUser.Rows[e.RowIndex].IsNewRow) return;
            txtusername.Text = dgvUser.Rows[e.RowIndex].Cells["username"].Value?.ToString();
            txtpassword.Clear();
            cbogroup.Text = dgvUser.Rows[e.RowIndex].Cells["Group"].Value?.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            cbogroup.SelectedIndex = 1;
            txtusername.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string group = cbogroup.Text;
            string password = txtpassword.Text.Trim();

            if (username == "")
            {
                MessageBox.Show("Chọn tài khoản cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu người dùng KHÔNG nhập mật khẩu → chỉ cập nhật VaiTro
            // Nếu có nhập → kiểm tra độ dài rồi cập nhật cả hai
            if (password != "" && password.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpassword.Focus();
                return;
            }

            string sql;
            SqlParameter[] p;

            if (password == "")
            {
                // Chỉ đổi vai trò
                sql = "UPDATE TaiKhoan SET VaiTro=@VT WHERE TenDangNhap=@TenDN";
                p = new[]
                {
            new SqlParameter("@VT",    group),
            new SqlParameter("@TenDN", username)
        };
            }
            else
            {
                // Đổi cả mật khẩu lẫn vai trò
                sql = "UPDATE TaiKhoan SET MatKhau=@MK, VaiTro=@VT WHERE TenDangNhap=@TenDN";
                p = new[]
                {
            new SqlParameter("@MK",    DataProvider.HashPassword(password)),
            new SqlParameter("@VT",    group),
            new SqlParameter("@TenDN", username)
        };
            }

            if (DataProvider.ExecuteNonQuery(sql, p) > 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                txtpassword.Clear();
            }
        }

        private void cmdluu_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();
            string group = cbogroup.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            // Kiểm tra đã tồn tại chưa
            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap=@TenDN",
                new[] { new SqlParameter("@TenDN", username) }));

            if (count > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!\nDùng nút Sửa để cập nhật.",
                    "Trùng tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maTK = "TK" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            string sql = "INSERT INTO TaiKhoan(MaTK,TenDangNhap,MatKhau,VaiTro,TrangThai) VALUES(@MaTK,@TenDN,@MK,@VT,1)";
            SqlParameter[] p = {
                new SqlParameter("@MaTK",  maTK),
                new SqlParameter("@TenDN", username),
                new SqlParameter("@MK", DataProvider.HashPassword(password)),
                new SqlParameter("@VT",    group)
            };

            if (DataProvider.ExecuteNonQuery(sql, p) > 0)
            {
                MessageBox.Show("Tạo tài khoản thành công!\nMã TK: " + maTK, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnthem_Click(sender, e);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            if (username == "") { MessageBox.Show("Chọn tài khoản cần xóa!"); return; }

            // Không cho xóa tài khoản đang đăng nhập
            if (username == SessionInfo.TenDangNhap)
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận xóa tài khoản '{username}'?", "Xác nhận",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                object maTKObj = DataProvider.ExecuteScalar(
                    "SELECT MaTK FROM TaiKhoan WHERE TenDangNhap=@TenDN",
                    new[] { new SqlParameter("@TenDN", username) });

                if (maTKObj == null) { MessageBox.Show("Không tìm thấy tài khoản!"); return; }
                string maTK = maTKObj.ToString();

                DataProvider.ExecuteNonQuery(
                    "DELETE FROM PhanQuyen WHERE MaTK=@MaTK",
                    new[] { new SqlParameter("@MaTK", maTK) });

                if (DataProvider.ExecuteNonQuery(
                    "DELETE FROM TaiKhoan WHERE TenDangNhap=@TenDN",
                    new[] { new SqlParameter("@TenDN", username) }) > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    btnthem_Click(sender, e);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
