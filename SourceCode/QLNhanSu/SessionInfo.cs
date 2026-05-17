using System.Collections.Generic;

namespace QLNhanSu
{
    /// <summary>
    /// Thông tin người dùng đang đăng nhập — dùng thay cho static field trên frmDangNhap
    /// </summary>
    public static class SessionInfo
    {
        public static string MaTK { get; set; } = "";
        public static string TenDangNhap { get; set; } = "";
        public static string VaiTro { get; set; } = "";
        public static string MaNV { get; set; } = "";
        public static List<string> DanhSachQuyen { get; set; } = new List<string>();

        public static bool IsAdmin => VaiTro == "Admin";

        public static bool CoQuyen(string tenChucNang)
            => IsAdmin || DanhSachQuyen.Contains(tenChucNang);

        public static void Reset()
        {
            MaTK = TenDangNhap = VaiTro = MaNV = "";
            DanhSachQuyen.Clear();
        }
    }
}