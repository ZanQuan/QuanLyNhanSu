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
    public partial class frmLoaiHD : Form
    {
        public frmLoaiHD()
        {
            InitializeComponent();
        }

        private void frmLoaiHD_Load(object sender, EventArgs e)
        {
            LoadData(); 
            SetReadOnly(true);
        }
        private void LoadData()
        {
            dgv_DMHD.DataSource = DataProvider.ExecuteQuery(
                "SELECT MaLoai AS Maloaihd, TenLoai AS tenloaihd FROM LoaiHD ORDER BY MaLoai");
        }

        private void SetReadOnly(bool readOnly)
        { txtmahd.ReadOnly = readOnly; txttenloai.ReadOnly = readOnly; }

        private void dgv_DMHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtmahd.Text = dgv_DMHD.Rows[e.RowIndex].Cells["MaLoaiHD"].Value.ToString();
            txttenloai.Text = dgv_DMHD.Rows[e.RowIndex].Cells["TenLoaiHD"].Value.ToString();
            SetReadOnly(false); txtmahd.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmahd.Clear(); txttenloai.Clear(); SetReadOnly(false); txtmahd.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmahd.Text.Trim() == "") { MessageBox.Show("Chọn loại HĐ cần sửa!"); return; }
            SetReadOnly(false); txtmahd.ReadOnly = true; txttenloai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmahd.Text.Trim() == "" || txttenloai.Text.Trim() == "")
            { MessageBox.Show("Nhập đầy đủ Mã và Tên loại hợp đồng!"); return; }

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM LoaiHD WHERE MaLoai=@Ma",
                new[] { new SqlParameter("@Ma", txtmahd.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE LoaiHD SET TenLoai=@Ten WHERE MaLoai=@Ma"
                : "INSERT INTO LoaiHD(MaLoai,TenLoai) VALUES(@Ma,@Ten)";

            if (DataProvider.ExecuteNonQuery(sql, new[] {
                new SqlParameter("@Ma",  txtmahd.Text.Trim()),
                new SqlParameter("@Ten", txttenloai.Text.Trim()) }) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                LoadData(); txtmahd.Clear(); txttenloai.Clear(); SetReadOnly(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmahd.Text.Trim() == "") { MessageBox.Show("Chọn loại HĐ cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa '" + txttenloai.Text + "'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery("DELETE FROM LoaiHD WHERE MaLoai=@Ma",
                    new[] { new SqlParameter("@Ma", txtmahd.Text.Trim()) }) > 0)
                { MessageBox.Show("Xóa thành công!"); LoadData(); txtmahd.Clear(); txttenloai.Clear(); SetReadOnly(true); }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
