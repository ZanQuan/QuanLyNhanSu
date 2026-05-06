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
    public partial class frmDMNgoaiNgu : Form
    {
        public frmDMNgoaiNgu()
        {
            InitializeComponent();
        }

        private void frmDMNgoaiNgu_Load(object sender, EventArgs e)
        {
            LoadData(); 
            SetReadOnly(true);
        }
        private void LoadData()
        {
            dgv_DMNN.DataSource = DataProvider.ExecuteQuery(
                "SELECT MaNN AS mangoaingu, TenNN AS tenngoaingu FROM NgoaiNgu ORDER BY MaNN");
        }
        private void SetReadOnly(bool readOnly)
        { txtmaNN.ReadOnly = readOnly; txttenNN.ReadOnly = readOnly; }

        private void dgv_DMNN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtmaNN.Text = dgv_DMNN.Rows[e.RowIndex].Cells["mangoaingu"].Value.ToString();
            txttenNN.Text = dgv_DMNN.Rows[e.RowIndex].Cells["tenngoaingu"].Value.ToString();
            SetReadOnly(false); txtmaNN.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmaNN.Clear(); txttenNN.Clear(); SetReadOnly(false); txtmaNN.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmaNN.Text.Trim() == "") { MessageBox.Show("Chọn ngoại ngữ cần sửa!"); return; }
            SetReadOnly(false); txtmaNN.ReadOnly = true; txttenNN.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmaNN.Text.Trim() == "" || txttenNN.Text.Trim() == "")
            { MessageBox.Show("Nhập đầy đủ Mã và Tên ngoại ngữ!"); return; }

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM NgoaiNgu WHERE MaNN=@Ma",
                new[] { new SqlParameter("@Ma", txtmaNN.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE NgoaiNgu SET TenNN=@Ten WHERE MaNN=@Ma"
                : "INSERT INTO NgoaiNgu(MaNN,TenNN) VALUES(@Ma,@Ten)";

            if (DataProvider.ExecuteNonQuery(sql, new[] {
                new SqlParameter("@Ma",  txtmaNN.Text.Trim()),
                new SqlParameter("@Ten", txttenNN.Text.Trim()) }) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                LoadData(); txtmaNN.Clear(); txttenNN.Clear(); SetReadOnly(true);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmaNN.Text.Trim() == "") { MessageBox.Show("Chọn ngoại ngữ cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa '" + txttenNN.Text + "'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery("DELETE FROM NgoaiNgu WHERE MaNN=@Ma",
                    new[] { new SqlParameter("@Ma", txtmaNN.Text.Trim()) }) > 0)
                { MessageBox.Show("Xóa thành công!"); LoadData(); txtmaNN.Clear(); txttenNN.Clear(); SetReadOnly(true); }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
