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
    public partial class frmDMTrinhDo : Form
    {
        public frmDMTrinhDo()
        {
            InitializeComponent();
        }

        private void frmDMTrinhDo_Load(object sender, EventArgs e)
        {
            LoadData(); 
            SetReadOnly(true);
        }
        private void LoadData()
        {
            dgv_DMTD.DataSource = DataProvider.ExecuteQuery(
                "SELECT MaTD AS matrinhdo, TenTD AS tentrinhdo FROM TrinhDo ORDER BY MaTD");
        }

        private void SetReadOnly(bool readOnly)
        { txtmaTD.ReadOnly = readOnly; txttenTD.ReadOnly = readOnly; }

        private void dgv_DMTD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtmaTD.Text = dgv_DMTD.Rows[e.RowIndex].Cells["matrinhdo"].Value.ToString();
            txttenTD.Text = dgv_DMTD.Rows[e.RowIndex].Cells["tentrinhdo"].Value.ToString();
            SetReadOnly(false); txtmaTD.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmaTD.Clear(); txttenTD.Clear(); SetReadOnly(false); txtmaTD.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmaTD.Text.Trim() == "") { MessageBox.Show("Chọn trình độ cần sửa!"); return; }
            SetReadOnly(false); txtmaTD.ReadOnly = true; txttenTD.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmaTD.Text.Trim() == "" || txttenTD.Text.Trim() == "")
            { MessageBox.Show("Nhập đầy đủ Mã và Tên trình độ!"); return; }

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM TrinhDo WHERE MaTD=@Ma",
                new[] { new SqlParameter("@Ma", txtmaTD.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE TrinhDo SET TenTD=@Ten WHERE MaTD=@Ma"
                : "INSERT INTO TrinhDo(MaTD,TenTD) VALUES(@Ma,@Ten)";

            if (DataProvider.ExecuteNonQuery(sql, new[] {
                new SqlParameter("@Ma",  txtmaTD.Text.Trim()),
                new SqlParameter("@Ten", txttenTD.Text.Trim()) }) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                LoadData(); txtmaTD.Clear(); txttenTD.Clear(); SetReadOnly(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmaTD.Text.Trim() == "") { MessageBox.Show("Chọn trình độ cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa '" + txttenTD.Text + "'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery("DELETE FROM TrinhDo WHERE MaTD=@Ma",
                    new[] { new SqlParameter("@Ma", txtmaTD.Text.Trim()) }) > 0)
                { MessageBox.Show("Xóa thành công!"); LoadData(); txtmaTD.Clear(); txttenTD.Clear(); SetReadOnly(true); }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
