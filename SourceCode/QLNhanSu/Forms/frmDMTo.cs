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
    public partial class frmDMTo : Form
    {
        public frmDMTo()
        {
            InitializeComponent();
        }

        private void frmDMTo_Load(object sender, EventArgs e)
        {
            LoadComboPhongBan();
            LoadData();
            SetReadOnly(true);
        }
        private void LoadComboPhongBan()
        {
            DataTable dt = DataProvider.ExecuteQuery("SELECT MaPB, TenPB FROM PhongBan ORDER BY MaPB");
            cbomaphong.DataSource = dt;
            cbomaphong.DisplayMember = "TenPB";
            cbomaphong.ValueMember = "MaPB";
            cbomaphong.SelectedIndex = -1;
        }
        private void LoadData()
        {
            string sql = @"SELECT t.MaTo AS mato, t.TenTo AS tento, p.TenPB AS tenphong 
                           FROM To_ t JOIN PhongBan p ON t.MaPB = p.MaPB ORDER BY t.MaTo";
            dgv_DMTO.DataSource = DataProvider.ExecuteQuery(sql);
        }
        private void SetReadOnly(bool readOnly)
        { txtmato.ReadOnly = readOnly; txttento.ReadOnly = readOnly; cbomaphong.Enabled = !readOnly; }

        private void dgv_DMTO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv_DMTO.Rows[e.RowIndex].IsNewRow) return;
            txtmato.Text = dgv_DMTO.Rows[e.RowIndex].Cells["MaTo"].Value.ToString();
            txttento.Text = dgv_DMTO.Rows[e.RowIndex].Cells["TenTo"].Value.ToString();

            // Tìm MaPB tương ứng để set ComboBox
            DataTable dt = DataProvider.ExecuteQuery(
                "SELECT MaPB FROM To_ WHERE MaTo=@Ma",
                new[] { new SqlParameter("@Ma", txtmato.Text) });
            if (dt.Rows.Count > 0)
                cbomaphong.SelectedValue = dt.Rows[0]["MaPB"].ToString();

            SetReadOnly(false); txtmato.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmato.Clear(); txttento.Clear(); cbomaphong.SelectedIndex = -1;
            SetReadOnly(false); txtmato.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmato.Text.Trim() == "") { MessageBox.Show("Chọn tổ cần sửa!"); return; }
            SetReadOnly(false); txtmato.ReadOnly = true; txttento.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmato.Text.Trim() == "" || txttento.Text.Trim() == "" || cbomaphong.SelectedValue == null)
            { MessageBox.Show("Nhập đầy đủ Mã tổ, Tên tổ và chọn Phòng ban!"); return; }

            string maPB = cbomaphong.SelectedValue.ToString();
            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM To_ WHERE MaTo=@Ma",
                new[] { new SqlParameter("@Ma", txtmato.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE To_ SET TenTo=@Ten, MaPB=@MaPB WHERE MaTo=@Ma"
                : "INSERT INTO To_(MaTo,TenTo,MaPB) VALUES(@Ma,@Ten,@MaPB)";

            if (DataProvider.ExecuteNonQuery(sql, new[] {
                new SqlParameter("@Ma",   txtmato.Text.Trim()),
                new SqlParameter("@Ten",  txttento.Text.Trim()),
                new SqlParameter("@MaPB", maPB) }) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                LoadData(); txtmato.Clear(); txttento.Clear(); cbomaphong.SelectedIndex = -1; SetReadOnly(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmato.Text.Trim() == "") { MessageBox.Show("Chọn tổ cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa tổ '" + txttento.Text + "'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery("DELETE FROM To_ WHERE MaTo=@Ma",
                    new[] { new SqlParameter("@Ma", txtmato.Text.Trim()) }) > 0)
                {
                    MessageBox.Show("Xóa thành công!"); LoadData();
                    txtmato.Clear(); txttento.Clear(); cbomaphong.SelectedIndex = -1; SetReadOnly(true);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
