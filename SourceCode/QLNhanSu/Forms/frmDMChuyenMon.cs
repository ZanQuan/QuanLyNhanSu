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
    public partial class frmDMChuyenMon : Form
    {
        public frmDMChuyenMon()
        {
            InitializeComponent();
        }

        private void frmDMChuyenMon_Load(object sender, EventArgs e)
        {
            LoadData(); 
            SetReadOnly(true);
        }
        private void LoadData()
        {
            dgv_DMchuyenmon.DataSource = DataProvider.ExecuteQuery(
                "SELECT MaCM AS MaChuyenMon, TenCM AS TenChuyenMon FROM ChuyenMon ORDER BY MaCM");
        }

        private void SetReadOnly(bool readOnly)
        { txtmaCM.ReadOnly = readOnly; txttenCM.ReadOnly = readOnly; }

        private void dgv_DMchuyenmon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtmaCM.Text = dgv_DMchuyenmon.Rows[e.RowIndex].Cells["MaChuyenMon"].Value.ToString();
            txttenCM.Text = dgv_DMchuyenmon.Rows[e.RowIndex].Cells["TenChuyenMon"].Value.ToString();
            SetReadOnly(false); txtmaCM.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmaCM.Clear(); txttenCM.Clear(); SetReadOnly(false); txtmaCM.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmaCM.Text.Trim() == "") { MessageBox.Show("Chọn chuyên môn cần sửa!"); return; }
            SetReadOnly(false); txtmaCM.ReadOnly = true; txttenCM.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmaCM.Text.Trim() == "" || txttenCM.Text.Trim() == "")
            { MessageBox.Show("Nhập đầy đủ Mã và Tên chuyên môn!"); return; }

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM ChuyenMon WHERE MaCM=@Ma",
                new[] { new SqlParameter("@Ma", txtmaCM.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE ChuyenMon SET TenCM=@Ten WHERE MaCM=@Ma"
                : "INSERT INTO ChuyenMon(MaCM,TenCM) VALUES(@Ma,@Ten)";

            if (DataProvider.ExecuteNonQuery(sql, new[] {
                new SqlParameter("@Ma",  txtmaCM.Text.Trim()),
                new SqlParameter("@Ten", txttenCM.Text.Trim()) }) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                LoadData(); txtmaCM.Clear(); txttenCM.Clear(); SetReadOnly(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmaCM.Text.Trim() == "") { MessageBox.Show("Chọn chuyên môn cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa '" + txttenCM.Text + "'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery("DELETE FROM ChuyenMon WHERE MaCM=@Ma",
                    new[] { new SqlParameter("@Ma", txtmaCM.Text.Trim()) }) > 0)
                { MessageBox.Show("Xóa thành công!"); LoadData(); txtmaCM.Clear(); txttenCM.Clear(); SetReadOnly(true); }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
