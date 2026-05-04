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
            // Lấy đúng tên cột trong DB — map vào DataPropertyName của Designer
            string sql = @"SELECT TenDangNhap AS id, MatKhau AS pass, VaiTro AS nhom 
                           FROM TaiKhoan ORDER BY TenDangNhap";
            dgvUser.DataSource = DataProvider.ExecuteQuery(sql);
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtusername.Text = dgvUser.Rows[e.RowIndex].Cells["username"].Value.ToString();
            txtpassword.Text = dgvUser.Rows[e.RowIndex].Cells["Pass"].Value.ToString();
            cbogroup.Text = dgvUser.Rows[e.RowIndex].Cells["Group"].Value.ToString();
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
            string password = txtpassword.Text.Trim();
            string group = cbogroup.Text;

            if (username == "" || password == "")
            { MessageBox.Show("Chọn tài khoản cần sửa!"); return; }

            string sql = "UPDATE TaiKhoan SET MatKhau=@MK, VaiTro=@VT WHERE TenDangNhap=@TenDN";
            SqlParameter[] p = {
                new SqlParameter("@MK",    password),
                new SqlParameter("@VT",    group),
                new SqlParameter("@TenDN", username)
            };

            if (DataProvider.ExecuteNonQuery(sql, p) > 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
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

            // Tạo MaTK tự động: TK + số thứ tự
            object maxObj = DataProvider.ExecuteScalar(
                "SELECT MAX(CAST(SUBSTRING(MaTK,3,LEN(MaTK)) AS INT)) FROM TaiKhoan WHERE MaTK LIKE 'TK%'");
            int nextNum = (maxObj == DBNull.Value || maxObj == null) ? 1 : Convert.ToInt32(maxObj) + 1;
            string maTK = "TK" + nextNum.ToString("D2");

            string sql = "INSERT INTO TaiKhoan(MaTK,TenDangNhap,MatKhau,VaiTro,TrangThai) VALUES(@MaTK,@TenDN,@MK,@VT,1)";
            SqlParameter[] p = {
                new SqlParameter("@MaTK",  maTK),
                new SqlParameter("@TenDN", username),
                new SqlParameter("@MK",    password),
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
            if (username == frmDangNhap.TaiKhoanDangNhap)
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận xóa tài khoản '{username}'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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
