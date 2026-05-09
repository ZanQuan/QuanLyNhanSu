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
    public partial class frmBangTiLeLuong : Form
    {
        public frmBangTiLeLuong()
        {
            InitializeComponent();
        }

        private void SetInputEnabled(bool enabled)
        {
            cbothang.Enabled = enabled;
            cbonam.Enabled = enabled;
            cboPhong.Enabled = enabled;
            cboto.Enabled = enabled;
            txttll.ReadOnly = !enabled;
            txtsongaycong.ReadOnly = !enabled;
        }
        private void frmBangTiLeLuong_Load(object sender, EventArgs e)
        {
            // ComboBox Tháng
            cbothang.Items.Clear();
            for (int i = 1; i <= 12; i++) cbothang.Items.Add(i);
            cbothang.SelectedItem = DateTime.Now.Month;

            // ComboBox Năm
            cbonam.Items.Clear();
            for (int y = DateTime.Now.Year - 2; y <= DateTime.Now.Year + 1; y++)
                cbonam.Items.Add(y);
            cbonam.SelectedItem = DateTime.Now.Year;

            // ComboBox Phòng ban
            DataTable dtPB = DataProvider.ExecuteQuery("SELECT MaPB, TenPB FROM PhongBan ORDER BY MaPB");
            cboPhong.DataSource = dtPB;
            cboPhong.DisplayMember = "TenPB";
            cboPhong.ValueMember = "MaPB";
            cboPhong.SelectedIndex = -1;

            LoadData();
        }
        private void LoadData()
        {
            dgv_TiLeLuong.AutoGenerateColumns = false;
            int thang = cbothang.SelectedItem != null ? (int)cbothang.SelectedItem : DateTime.Now.Month;
            int nam = cbonam.SelectedItem != null ? (int)cbonam.SelectedItem : DateTime.Now.Year;

            string sql = @"SELECT t.ID AS id, p.TenPB AS tenphong, p.MaPB AS maphong,
                           ISNULL(to_.TenTo,'') AS tento, ISNULL(t.MaTo,'') AS mato,
                           t.Thang AS thang, t.Nam AS nam,
                           t.SoNgayCongThang AS songaycongthang,
                           t.TiLeLuong AS tileluong
                           FROM TiLeLuong t
                           JOIN PhongBan p ON t.MaPB = p.MaPB
                           LEFT JOIN To_ to_ ON t.MaTo = to_.MaTo
                           WHERE t.Thang=@T AND t.Nam=@N
                           ORDER BY p.MaPB";

            dgv_TiLeLuong.DataSource = DataProvider.ExecuteQuery(sql, new[] {
                new SqlParameter("@T", thang),
                new SqlParameter("@N", nam)
            });
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue == null) return;
            DataTable dtTo = DataProvider.ExecuteQuery(
                "SELECT MaTo, TenTo FROM To_ WHERE MaPB=@MaPB ORDER BY MaTo",
                new[] { new SqlParameter("@MaPB", cboPhong.SelectedValue.ToString()) });
            cboto.DataSource = dtTo;
            cboto.DisplayMember = "TenTo";
            cboto.ValueMember = "MaTo";
            cboto.SelectedIndex = -1;
        }

        private void dgv_TiLeLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv_TiLeLuong.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            cboPhong.SelectedValue = row.Cells["maphong"].Value?.ToString();
            cboto.SelectedValue = row.Cells["mato"].Value?.ToString();
            txtsongaycong.Text = row.Cells["songaycong"].Value?.ToString();
            txttll.Text = row.Cells["tileluong"].Value?.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetInputEnabled(true);
            cboPhong.SelectedIndex = -1;
            cboto.SelectedIndex = -1;
            txtsongaycong.Text = "26";
            txttll.Text = "100";
            cboPhong.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue == null)
            { MessageBox.Show("Chọn phòng ban!"); return; }
            if (cbothang.SelectedItem == null || cbonam.SelectedItem == null)
            { MessageBox.Show("Chọn tháng và năm!"); return; }

            string maPB = cboPhong.SelectedValue.ToString();
            string maTo = cboto.SelectedValue?.ToString() ?? "";
            int thang = (int)cbothang.SelectedItem;
            int nam = (int)cbonam.SelectedItem;
            int ngayCong = 26;
            decimal tile = 100;

            int.TryParse(txtsongaycong.Text.Trim(), out ngayCong);
            decimal.TryParse(txttll.Text.Trim(), out tile);

            // Kiểm tra đã tồn tại chưa
            string checkSql = maTo == ""
                ? "SELECT COUNT(*) FROM TiLeLuong WHERE MaPB=@MaPB AND MaTo IS NULL AND Thang=@T AND Nam=@N"
                : "SELECT COUNT(*) FROM TiLeLuong WHERE MaPB=@MaPB AND MaTo=@MaTo AND Thang=@T AND Nam=@N";

            SqlParameter[] checkP = maTo == ""
                ? new[] { new SqlParameter("@MaPB", maPB), new SqlParameter("@T", thang), new SqlParameter("@N", nam) }
                : new[] { new SqlParameter("@MaPB", maPB), new SqlParameter("@MaTo", maTo), new SqlParameter("@T", thang), new SqlParameter("@N", nam) };

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(checkSql, checkP));

            string sql = count > 0
    ? (maTo == ""
        ? "UPDATE TiLeLuong SET SoNgayCongThang=@NC, TiLeLuong=@TL WHERE MaPB=@MaPB AND MaTo IS NULL AND Thang=@T AND Nam=@N"
        : "UPDATE TiLeLuong SET SoNgayCongThang=@NC, TiLeLuong=@TL WHERE MaPB=@MaPB AND MaTo=@MaTo AND Thang=@T AND Nam=@N")
    : "INSERT INTO TiLeLuong(MaPB,MaTo,Thang,Nam,SoNgayCongThang,TiLeLuong) VALUES(@MaPB,@MaTo,@T,@N,@NC,@TL)";

            SqlParameter[] p = {
                new SqlParameter("@MaPB", maPB),
                new SqlParameter("@MaTo", maTo == "" ? (object)DBNull.Value : maTo),
                new SqlParameter("@T",    thang),
                new SqlParameter("@N",    nam),
                new SqlParameter("@NC",   ngayCong),
                new SqlParameter("@TL",   tile)
            };

            if (DataProvider.ExecuteNonQuery(sql, p) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                SetInputEnabled(false); 
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv_TiLeLuong.SelectedRows.Count == 0) { MessageBox.Show("Chọn dòng cần xóa!"); return; }
            string id = dgv_TiLeLuong.SelectedRows[0].Cells["id"].Value?.ToString();
            if (MessageBox.Show("Xác nhận xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery("DELETE FROM TiLeLuong WHERE ID=@ID",
                    new[] { new SqlParameter("@ID", id) }) > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    SetInputEnabled(false); 
                    LoadData();
                }
            }
        }

        private void cbothang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbonam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
