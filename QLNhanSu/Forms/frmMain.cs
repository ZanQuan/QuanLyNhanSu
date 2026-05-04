using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // Nếu không phải Admin → ẩn menu Bảo mật
            if (frmDangNhap.VaiTroDangNhap != "Admin")
                menubaomat.Visible = false;
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
            MessageBox.Show("Chức năng đang phát triển!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChonBCNV frm = new frmChonBCNV();
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
            MessageBox.Show("Phần mềm Quản lý Nhân sự\nNhóm sinh viên: Quân - Vinh\nNăm học: 2025-2026",
                "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
