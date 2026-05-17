using System;
using System.Data;
using System.Data.SqlClient;
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
            dgv_DMHD.AutoGenerateColumns = false;
            dgv_DMHD.DataSource = DataProvider.ExecuteQuery(
                "SELECT MaLoaiHD, TenLoai FROM LoaiHopDong ORDER BY MaLoaiHD");
        }

        private void SetReadOnly(bool readOnly)
        {
            txtmahd.ReadOnly = readOnly;
            txttenloai.ReadOnly = readOnly;
        }

        private void dgv_DMHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_DMHD.Rows.Count) return;

            DataGridViewRow row = dgv_DMHD.Rows[e.RowIndex];

            if (row.IsNewRow) return;

            txtmahd.Text = row.Cells["MaLoaiHD"].Value?.ToString() ?? "";
            txttenloai.Text = row.Cells["TenLoaiHD"].Value?.ToString() ?? "";

            SetReadOnly(false);
            txtmahd.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmahd.Clear();
            txttenloai.Clear();
            SetReadOnly(false);
            txtmahd.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmahd.Text.Trim() == "")
            {
                MessageBox.Show("Chọn loại hợp đồng cần sửa!");
                return;
            }

            SetReadOnly(false);
            txtmahd.ReadOnly = true;
            txttenloai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmahd.Text.Trim() == "" || txttenloai.Text.Trim() == "")
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu!");
                return;
            }

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM LoaiHopDong WHERE MaLoaiHD=@Ma",
                new[] { new SqlParameter("@Ma", txtmahd.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE LoaiHopDong SET TenLoai=@Ten WHERE MaLoaiHD=@Ma"
                : "INSERT INTO LoaiHopDong(MaLoaiHD, TenLoai) VALUES(@Ma, @Ten)";

            if (DataProvider.ExecuteNonQuery(sql, new[]
            {
                new SqlParameter("@Ma", txtmahd.Text.Trim()),
                new SqlParameter("@Ten", txttenloai.Text.Trim())
            }) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                LoadData();
                txtmahd.Clear();
                txttenloai.Clear();
                SetReadOnly(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmahd.Text.Trim() == "")
            {
                MessageBox.Show("Chọn loại cần xóa!");
                return;
            }

            if (MessageBox.Show("Xóa loại hợp đồng này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery(
                    "DELETE FROM LoaiHopDong WHERE MaLoaiHD=@Ma",
                    new[] { new SqlParameter("@Ma", txtmahd.Text.Trim()) }) > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    txtmahd.Clear();
                    txttenloai.Clear();
                    SetReadOnly(true);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}