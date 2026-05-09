using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QLNhanSu.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Hiển thị tên người đăng nhập ở thanh trạng thái
            toolStripStatusLabel2.Text = "Người đăng nhập: " + frmDangNhap.TaiKhoanDangNhap
                                + "  |  Vai trò: " + frmDangNhap.VaiTroDangNhap;
            trangthai.Text = "Trạng thái: Sẵn sàng";

            HienThiAnhNen();
            // Admin thấy tất cả, không cần check từng quyền
            if (frmDangNhap.VaiTroDangNhap == "Admin") return;

            // Ẩn menu Bảo mật với non-Admin
            menubaomat.Visible = false;

            // ← THÊM: Hàm tiện ích kiểm tra quyền
            bool CoQuyen(string tenChucNang) =>
                frmDangNhap.DanhSachQuyen.Contains(tenChucNang);

            // ← THÊM: Áp dụng quyền cho từng menu item
            // (Tên chức năng phải khớp chính xác với TenChucNang trong bảng PhanQuyen)
            hồSơCNVToolStripMenuItem.Visible = CoQuyen("Hồ sơ nhân viên");
            danhMụcPhòngBanToolStripMenuItem.Visible = CoQuyen("Danh mục phòng ban");
            toolStripMenuItem4.Visible = CoQuyen("Danh mục chức vụ");
            danhMụcToolStripMenuItem.Visible = CoQuyen("Danh mục dân tộc");
            danhMụcTônGiáoToolStripMenuItem.Visible = CoQuyen("Danh mục tôn giáo");
            danhMụcTrìnhĐộToolStripMenuItem.Visible = CoQuyen("Danh mục trình độ");
            danhMụcChuyênMônToolStripMenuItem.Visible = CoQuyen("Danh mục chuyên môn");
            danhMụcNgoạiNgữToolStripMenuItem.Visible = CoQuyen("Danh mục ngoại ngữ");
            danhMụcTổToolStripMenuItem.Visible = CoQuyen("Danh mục tổ");
            danhMụcLoạiHĐToolStripMenuItem.Visible = CoQuyen("Danh mục loại HĐ");
            bảngChấmCôngToolStripMenuItem.Visible = CoQuyen("Bảng lương");
            bangtieleluongToolStripMenuItem.Visible = CoQuyen("Tỉ lệ lương");
            báoCáoNhânSựToolStripMenuItem.Visible = CoQuyen("Báo cáo nhân sự");
            báoCáoLươngthángToolStripMenuItem.Visible = CoQuyen("Báo cáo lương");
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmDangNhap frm = new frmDangNhap();
                frm.Show();
                this.Close();
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void tạoNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            frm.ShowDialog();
        }

        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhanQuyen frm = new frmPhanQuyen();
            frm.ShowDialog();
        }

        private void hồSơCNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void hồSơĐiềuĐộngKThưởngKLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChonBCNV frm = new frmChonBCNV();
            frm.ShowDialog();
        }

        private void hoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKiemTraHDHetHan frm = new frmKiemTraHDHetHan();
            frm.ShowDialog();
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMDanToc frm = new frmDMDanToc();
            frm.ShowDialog();
        }

        private void danhMụcTônGiáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMTonGiao frm = new frmDMTonGiao();
            frm.ShowDialog();
        }

        private void danhMụcTrìnhĐộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMTrinhDo frm = new frmDMTrinhDo();
            frm.ShowDialog();
        }

        private void danhMụcChuyênMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMChuyenMon frm = new frmDMChuyenMon();
            frm.ShowDialog();
        }

        private void danhMụcNgoạiNgữToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMNgoaiNgu frm = new frmDMNgoaiNgu();
            frm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmDMChucVu frm = new frmDMChucVu();
            frm.ShowDialog();
        }

        private void danhMụcPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMPhongBan frm = new frmDMPhongBan();
            frm.ShowDialog();
        }

        private void danhMụcTổToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMTo frm = new frmDMTo();
            frm.ShowDialog();
        }

        private void danhMụcLoạiHĐToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiHD frm = new frmLoaiHD();
            frm.ShowDialog();
        }

        private void danhmuchieuquaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bangtieleluongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBangTiLeLuong frm = new frmBangTiLeLuong();
            frm.ShowDialog();
        }

        private void bảngChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBangLuong frm = new frmBangLuong();
            frm.ShowDialog();
        }

        private void báoCáoNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChonBCNV frm = new frmChonBCNV();
            frm.ShowDialog();
        }

        private void báoCáoLươngthángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChonBCLuong frm = new frmChonBCLuong();
            frm.ShowDialog();
        }

        private void hướngDẫnSửDụngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm Quản lý Nhân sự - Tiền lương\nPhiên bản 1.0",
                "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thôngTinVềSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmGioiThieu frm = new frmGioiThieu(true);
            frm.ShowDialog();
        }
        private void HienThiAnhNen()
        {
            string anhPath = System.IO.Path.Combine(
                Application.StartupPath, "Images", "banner-Main.jpg");

            if (!System.IO.File.Exists(anhPath)) return;

            PictureBox pic = new PictureBox();
            pic.Image = Image.FromFile(anhPath);
            pic.SizeMode = PictureBoxSizeMode.Zoom;      
            pic.Dock = DockStyle.Fill;               
            pic.BackColor = Color.White;

            
            this.Controls.Add(pic);
            pic.BringToFront();
            pic.SendToBack();   
        }
    }
}
