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
    public partial class frmDMChucVu : Form
    {
        public frmDMChucVu()
        {
            InitializeComponent();
        }

        private void frmDMChucVu_Load(object sender, EventArgs e)
        {
            LoadData(); 
            SetReadOnly(true);
        }
        private void LoadData()
        {
            dgv_DMChucVu.DataSource = DataProvider.ExecuteQuery(
                "SELECT MaCV AS MaChucVu, TenCV AS TenChucVu, PhuCap AS PhuCap FROM ChucVu ORDER BY MaCV");
        }
        private void SetReadOnly(bool readOnly)
        { txtmachucvu.ReadOnly = readOnly; txttenchucvu.ReadOnly = readOnly; txtphucap.ReadOnly = readOnly; }

        private void dgv_DMChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv_DMChucVu.Rows[e.RowIndex].IsNewRow) return;
            txtmachucvu.Text = dgv_DMChucVu.Rows[e.RowIndex].Cells["MaChucVu"].Value.ToString();
            txttenchucvu.Text = dgv_DMChucVu.Rows[e.RowIndex].Cells["TenChucVu"].Value.ToString();
            txtphucap.Text = dgv_DMChucVu.Rows[e.RowIndex].Cells["PhuCap"].Value?.ToString();
            SetReadOnly(false); txtmachucvu.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmachucvu.Clear(); txttenchucvu.Clear(); txtphucap.Clear();
            SetReadOnly(false); txtmachucvu.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmachucvu.Text.Trim() == "") { MessageBox.Show("Chọn chức vụ cần sửa!"); return; }
            SetReadOnly(false); txtmachucvu.ReadOnly = true; txttenchucvu.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmachucvu.Text.Trim() == "" || txttenchucvu.Text.Trim() == "")
            { MessageBox.Show("Nhập đầy đủ Mã và Tên chức vụ!"); return; }

            decimal phuCap = 0;
            if (txtphucap.Text.Trim() != "")
                if (!decimal.TryParse(txtphucap.Text.Trim(), out phuCap))
                { MessageBox.Show("Phụ cấp phải là số!"); txtphucap.Focus(); return; }

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM ChucVu WHERE MaCV=@Ma",
                new[] { new SqlParameter("@Ma", txtmachucvu.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE ChucVu SET TenCV=@Ten, PhuCap=@PC WHERE MaCV=@Ma"
                : "INSERT INTO ChucVu(MaCV,TenCV,PhuCap) VALUES(@Ma,@Ten,@PC)";

            if (DataProvider.ExecuteNonQuery(sql, new[] {
                new SqlParameter("@Ma",  txtmachucvu.Text.Trim()),
                new SqlParameter("@Ten", txttenchucvu.Text.Trim()),
                new SqlParameter("@PC",  phuCap) }) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                LoadData(); txtmachucvu.Clear(); txttenchucvu.Clear(); txtphucap.Clear(); SetReadOnly(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmachucvu.Text.Trim() == "") { MessageBox.Show("Chọn chức vụ cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa chức vụ '" + txttenchucvu.Text + "'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery("DELETE FROM ChucVu WHERE MaCV=@Ma",
                    new[] { new SqlParameter("@Ma", txtmachucvu.Text.Trim()) }) > 0)
                {
                    MessageBox.Show("Xóa thành công!"); LoadData();
                    txtmachucvu.Clear(); txttenchucvu.Clear(); txtphucap.Clear(); SetReadOnly(true);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
