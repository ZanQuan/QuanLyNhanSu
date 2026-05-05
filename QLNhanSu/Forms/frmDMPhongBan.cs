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
    public partial class frmDMPhongBan : Form
    {
        public frmDMPhongBan()
        {
            InitializeComponent();
        }

        private void frmDMPhongBan_Load(object sender, EventArgs e)
        {
            LoadData();
            SetReadOnly(true);
        }
        private void LoadData()
        {
            string sql = "SELECT MaPB AS maphong, TenPB AS tenphong, DienThoai AS dienthoai FROM PhongBan ORDER BY MaPB";
            dgv_DMPB.DataSource = DataProvider.ExecuteQuery(sql);
        }
        private void SetReadOnly(bool readOnly)
        {
            txtmaPB.ReadOnly = readOnly;
            txttenPB.ReadOnly = readOnly;
            txtdienthoai.ReadOnly = readOnly;
        }
        private void dgv_DMPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtmaPB.Text = dgv_DMPB.Rows[e.RowIndex].Cells["MaPhong"].Value.ToString();
            txttenPB.Text = dgv_DMPB.Rows[e.RowIndex].Cells["TenPhong"].Value.ToString();
            txtdienthoai.Text = dgv_DMPB.Rows[e.RowIndex].Cells["DienThoai"].Value?.ToString();
            SetReadOnly(false);     
            txtmaPB.ReadOnly = true;
        }

        //Thêm xóa trắng form để nhập mới
        private void cmdthem_Click(object sender, EventArgs e)
        {
            txtmaPB.Clear(); txttenPB.Clear(); txtdienthoai.Clear();
            SetReadOnly(false); 
            txtmaPB.Focus();
        }
        //Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmaPB.Text.Trim() == "") { MessageBox.Show("Chọn phòng ban cần sửa!"); return; }
            SetReadOnly(false);
            txtmaPB.ReadOnly = true; // Khóa mã, chỉ sửa tên và điện thoại
            txttenPB.Focus();
        }
        //Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmaPB.Text.Trim() == "") { MessageBox.Show("Chọn phòng ban cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa phòng ban '" + txttenPB.Text + "'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DataProvider.ExecuteNonQuery(
                    "DELETE FROM PhongBan WHERE MaPB=@MaPB",
                    new[] { new SqlParameter("@MaPB", txtmaPB.Text.Trim()) }) > 0)
                {
                    MessageBox.Show("Xóa thành công!"); LoadData();
                    txtmaPB.Clear(); txttenPB.Clear(); txtdienthoai.Clear();
                    SetReadOnly(true);
                }
            }
        }
        //Lưu bản ghi mới vào DB
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmaPB.Text.Trim() == "" || txttenPB.Text.Trim() == "")
            {
                MessageBox.Show("Nhập đầy đủ Mã và Tên phòng ban!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            int count = Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM PhongBan WHERE MaPB=@MaPB",
                new[] { new SqlParameter("@MaPB", txtmaPB.Text.Trim()) }));

            string sql = count > 0
                ? "UPDATE PhongBan SET TenPB=@TenPB, DienThoai=@DT WHERE MaPB=@MaPB"
                : "INSERT INTO PhongBan(MaPB,TenPB,DienThoai) VALUES(@MaPB,@TenPB,@DT)";

            SqlParameter[] p = {
                new SqlParameter("@MaPB",  txtmaPB.Text.Trim()),
                new SqlParameter("@TenPB", txttenPB.Text.Trim()),
                new SqlParameter("@DT",    txtdienthoai.Text.Trim())
            };

            if (DataProvider.ExecuteNonQuery(sql, p) > 0)
            {
                MessageBox.Show(count > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                LoadData();
                txtmaPB.Clear(); txttenPB.Clear(); txtdienthoai.Clear();
                SetReadOnly(true); // Khóa lại sau khi lưu
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
