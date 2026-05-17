using QLNhanSu.Forms;
using System;
using System.Windows.Forms;

namespace QLNhanSu
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Kiểm tra kết nối DB trước khi mở app
            if (!DataProvider.TestConnection())
            {
                MessageBox.Show(
                    "Không kết nối được SQL Server!\n\n" +
                    "Kiểm tra lại:\n" +
                    "1. SQL Server đang chạy chưa?\n" +
                    "2. Tên instance có phải SQLEXPRESS không?\n" +
                    "3. User sa / password đúng chưa?\n" +
                    "4. Database QLNhanSu đã tạo chưa?",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            frmGioiThieu splash = new frmGioiThieu();
            if (splash.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMain());
            }
        }
    }
}