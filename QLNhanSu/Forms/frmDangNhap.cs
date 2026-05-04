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
        public static string TaiKhoanDangNhap = "";
        public static string VaiTroDangNhap = "";
        public static string MaNVDangNhap = "";
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // Kiểm tra không được để trống
            if (tenDN == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }
            if (matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // Truy vấn database
            string sql = @"SELECT MaTK, TenDangNhap, VaiTro, MaNV 
                           FROM TaiKhoan 
                           WHERE TenDangNhap = @TenDN 
                             AND MatKhau = @MK 
                             AND TrangThai = 1";

            SqlParameter[] parameters = {
                new SqlParameter("@TenDN", tenDN),
                new SqlParameter("@MK",   matKhau)
            };

            DataTable dt = DataProvider.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                // Lưu thông tin đăng nhập vào biến tĩnh
                TaiKhoanDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
                VaiTroDangNhap = dt.Rows[0]["VaiTro"].ToString();
                MaNVDangNhap = dt.Rows[0]["MaNV"].ToString();

                // Mở form chính
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide(); // Ẩn form đăng nhập (không đóng)
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!\nHoặc tài khoản đã bị khóa.",
                    "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
