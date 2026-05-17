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
    public partial class frmDMTonGiao : Form
    {
        public frmDMTonGiao()
        {
            InitializeComponent();
        }

        private void frmDMTonGiao_Load(object sender, EventArgs e)
        {
            LoadData(); 
            SetReadOnly(true);
        }
        private void LoadData()
        {
            dgv_DMTG.DataSource = DataProvider.ExecuteQuery(
                "SELECT MaTG AS MATG, TenTG AS TenTG FROM TonGiao ORDER BY MaTG");
        }
        private void SetReadOnly(bool readOnly)
        { txtmatg.ReadOnly = readOnly; txttentg.ReadOnly = readOnly; }

        private void dgv_DMTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtmatg.Text = dgv_DMTG.Rows[e.RowIndex].Cells["MaTG"].Value.ToString();
            txttentg.Text = dgv_DMTG.Rows[e.RowIndex].Cells["TenTG"].Value.ToString();
            SetReadOnly(false); txtmatg.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmatg.Clear(); txttentg.Clear(); SetReadOnly(false); txtmatg.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmatg.Text.Trim() == "") { MessageBox.Show("Chọn tôn giáo cần sửa!"); return; }
            SetReadOnly(false); txtmatg.ReadOnly = true; txttentg.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmatg.Text.Trim() == "" || txttentg.Text.Trim() == "")
            { MessageBox.Show("Nhập đầy đủ Mã và Tên tôn giáo!"); return; }

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM TonGiao WHERE MaTG=@Ma",
                new[] { new SqlParameter("@Ma", txtmatg.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE TonGiao SET TenTG=@Ten WHERE MaTG=@Ma"
                : "INSERT INTO TonGiao(MaTG,TenTG) VALUES(@Ma,@Ten)";

            if (DataProvider.ExecuteNonQuery(sql, new[] {
                new SqlParameter("@Ma",  txtmatg.Text.Trim()),
                new SqlParameter("@Ten", txttentg.Text.Trim()) }) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                LoadData(); txtmatg.Clear(); txttentg.Clear(); SetReadOnly(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmatg.Text.Trim() == "") { MessageBox.Show("Chọn tôn giáo cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa tôn giáo '" + txttentg.Text + "'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery("DELETE FROM TonGiao WHERE MaTG=@Ma",
                    new[] { new SqlParameter("@Ma", txtmatg.Text.Trim()) }) > 0)
                { MessageBox.Show("Xóa thành công!"); LoadData(); txtmatg.Clear(); txttentg.Clear(); SetReadOnly(true); }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
