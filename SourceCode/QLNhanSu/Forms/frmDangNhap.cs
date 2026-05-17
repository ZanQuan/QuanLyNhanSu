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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (tenDN == "") { MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtTenDangNhap.Focus(); return; }
            if (matKhau == "") { MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtMatKhau.Focus(); return; }

            string sql = @"SELECT MaTK, TenDangNhap, VaiTro, MaNV 
                       FROM TaiKhoan 
                       WHERE TenDangNhap = @TenDN AND MatKhau = @MK AND TrangThai = 1";

            SqlParameter[] parameters = {
            new SqlParameter("@TenDN", tenDN),
            new SqlParameter("@MK", DataProvider.HashPassword(matKhau))
        };

            DataTable dt = DataProvider.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                SessionInfo.MaTK = dt.Rows[0]["MaTK"].ToString();
                SessionInfo.TenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
                SessionInfo.VaiTro = dt.Rows[0]["VaiTro"].ToString();
                SessionInfo.MaNV = dt.Rows[0]["MaNV"].ToString();

                SessionInfo.DanhSachQuyen.Clear();
                DataTable dtQuyen = DataProvider.ExecuteQuery(
                    "SELECT TenChucNang FROM PhanQuyen WHERE MaTK=@MaTK AND CoQuyen=1",
                    new[] { new SqlParameter("@MaTK", SessionInfo.MaTK) });
                foreach (DataRow row in dtQuyen.Rows)
                    SessionInfo.DanhSachQuyen.Add(row["TenChucNang"].ToString());


                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!\nHoặc tài khoản đã bị khóa.",
                    "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // Xóa trắng 2 ô khi form mở
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtTenDangNhap.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap_Click(sender, e);
        }
    }
}
