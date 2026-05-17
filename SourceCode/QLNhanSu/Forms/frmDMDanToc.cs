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
    public partial class frmDMDanToc : Form
    {
        public frmDMDanToc()
        {
            InitializeComponent();
        }

        private void frmDMDanToc_Load(object sender, EventArgs e)
        {
            LoadData();
            SetReadOnly(true);
        }
        private void LoadData()
        {
            dgv_DMDanToc.DataSource = DataProvider.ExecuteQuery(
                "SELECT MaDT, TenDT FROM DanToc ORDER BY MaDT");
        }
        private void SetReadOnly(bool readOnly)
        {
            txtmadantoc.ReadOnly = readOnly;
            txttendantoc.ReadOnly = readOnly;
        }

        private void dgv_DMDanToc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtmadantoc.Text = dgv_DMDanToc.Rows[e.RowIndex].Cells["MaDT"].Value.ToString();
            txttendantoc.Text = dgv_DMDanToc.Rows[e.RowIndex].Cells["TenDT"].Value.ToString();
            SetReadOnly(false); txtmadantoc.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmadantoc.Clear(); txttendantoc.Clear();
            SetReadOnly(false); txtmadantoc.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmadantoc.Text.Trim() == "") { MessageBox.Show("Chọn dân tộc cần sửa!"); return; }
            SetReadOnly(false); txtmadantoc.ReadOnly = true; txttendantoc.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmadantoc.Text.Trim() == "" || txttendantoc.Text.Trim() == "")
            { MessageBox.Show("Nhập đầy đủ Mã và Tên dân tộc!"); return; }

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM DanToc WHERE MaDT=@Ma",
                new[] { new SqlParameter("@Ma", txtmadantoc.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE DanToc SET TenDT=@Ten WHERE MaDT=@Ma"
                : "INSERT INTO DanToc(MaDT,TenDT) VALUES(@Ma,@Ten)";

            if (DataProvider.ExecuteNonQuery(sql, new[] {
                new SqlParameter("@Ma",  txtmadantoc.Text.Trim()),
                new SqlParameter("@Ten", txttendantoc.Text.Trim()) }) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                LoadData(); txtmadantoc.Clear(); txttendantoc.Clear(); SetReadOnly(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmadantoc.Text.Trim() == "") { MessageBox.Show("Chọn dân tộc cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa '" + txttendantoc.Text + "'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery("DELETE FROM DanToc WHERE MaDT=@Ma",
                    new[] { new SqlParameter("@Ma", txtmadantoc.Text.Trim()) }) > 0)
                { MessageBox.Show("Xóa thành công!"); LoadData(); txtmadantoc.Clear(); txttendantoc.Clear(); SetReadOnly(true); }
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
