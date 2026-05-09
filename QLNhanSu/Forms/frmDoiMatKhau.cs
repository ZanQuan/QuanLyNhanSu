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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string mkCu = txtmkcu.Text.Trim();
            string mkMoi = txtmkmoi.Text.Trim();
            string mkMoi2 = txtmkmoi2.Text.Trim();

            if (mkCu == "" || mkMoi == "" || mkMoi2 == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (mkMoi != mkMoi2)
            {
                MessageBox.Show("Mật khẩu mới nhập lại không khớp!", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmkmoi2.Clear(); txtmkmoi2.Focus(); return;
            }

            if (mkMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            // Kiểm tra mật khẩu cũ
            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap=@TenDN AND MatKhau=@MKCu",
                new[] {
                    new SqlParameter("@TenDN", frmDangNhap.TaiKhoanDangNhap),
                    new SqlParameter("@MKCu",  mkCu)
                }));

            if (count == 0)
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmkcu.Clear(); txtmkcu.Focus(); return;
            }

            // Cập nhật mật khẩu mới
            if (DataProvider.ExecuteNonQuery(
                "UPDATE TaiKhoan SET MatKhau=@MKMoi WHERE TenDangNhap=@TenDN",
                new[] {
                    new SqlParameter("@MKMoi", mkMoi),
                    new SqlParameter("@TenDN", frmDangNhap.TaiKhoanDangNhap)
                }) > 0)
            {
                MessageBox.Show("Đổi mật khẩu thành công!\nVui lòng đăng nhập lại.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
