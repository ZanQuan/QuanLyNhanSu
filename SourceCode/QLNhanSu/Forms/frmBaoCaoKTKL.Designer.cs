namespace QLNhanSu.Forms
{
    partial class frmBaoCaoKTKL
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblThang = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblPB = new System.Windows.Forms.Label();
            this.cboPB = new System.Windows.Forms.ComboBox();
            this.lblLoc = new System.Windows.Forms.Label();
            this.cboLocKetQua = new System.Windows.Forms.ComboBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.pnlTop.Controls.Add(this.lblTieuDe);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1000, 55);
            this.pnlTop.TabIndex = 3;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(1000, 55);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "⭐  BÁO CÁO KHEN THƯỞNG - KỶ LUẬT";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.pnlFilter.Controls.Add(this.lblThang);
            this.pnlFilter.Controls.Add(this.numThang);
            this.pnlFilter.Controls.Add(this.lblNam);
            this.pnlFilter.Controls.Add(this.numNam);
            this.pnlFilter.Controls.Add(this.lblPB);
            this.pnlFilter.Controls.Add(this.cboPB);
            this.pnlFilter.Controls.Add(this.lblLoc);
            this.pnlFilter.Controls.Add(this.cboLocKetQua);
            this.pnlFilter.Controls.Add(this.btnXem);
            this.pnlFilter.Controls.Add(this.btnInBaoCao);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 55);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1000, 58);
            this.pnlFilter.TabIndex = 2;
            // 
            // lblThang
            // 
            this.lblThang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThang.Location = new System.Drawing.Point(2, 17);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(61, 20);
            this.lblThang.TabIndex = 0;
            this.lblThang.Text = "Tháng:";
            // 
            // numThang
            // 
            this.numThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numThang.Location = new System.Drawing.Point(62, 15);
            this.numThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(50, 27);
            this.numThang.TabIndex = 1;
            this.numThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThang.ValueChanged += new System.EventHandler(this.numThang_ValueChanged);
            // 
            // lblNam
            // 
            this.lblNam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNam.Location = new System.Drawing.Point(118, 18);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(51, 20);
            this.lblNam.TabIndex = 2;
            this.lblNam.Text = "Năm:";
            // 
            // numNam
            // 
            this.numNam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numNam.Location = new System.Drawing.Point(166, 14);
            this.numNam.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.numNam.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(68, 27);
            this.numNam.TabIndex = 3;
            this.numNam.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numNam.ValueChanged += new System.EventHandler(this.numNam_ValueChanged);
            // 
            // lblPB
            // 
            this.lblPB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPB.Location = new System.Drawing.Point(240, 18);
            this.lblPB.Name = "lblPB";
            this.lblPB.Size = new System.Drawing.Size(75, 20);
            this.lblPB.TabIndex = 4;
            this.lblPB.Text = "Phòng ban:";
            // 
            // cboPB
            // 
            this.cboPB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboPB.Location = new System.Drawing.Point(318, 14);
            this.cboPB.Name = "cboPB";
            this.cboPB.Size = new System.Drawing.Size(180, 28);
            this.cboPB.TabIndex = 5;
            this.cboPB.SelectedIndexChanged += new System.EventHandler(this.cboPB_SelectedIndexChanged);
            // 
            // lblLoc
            // 
            this.lblLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLoc.Location = new System.Drawing.Point(508, 18);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(35, 20);
            this.lblLoc.TabIndex = 6;
            this.lblLoc.Text = "Lọc:";
            // 
            // cboLocKetQua
            // 
            this.cboLocKetQua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocKetQua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLocKetQua.Location = new System.Drawing.Point(545, 14);
            this.cboLocKetQua.Name = "cboLocKetQua";
            this.cboLocKetQua.Size = new System.Drawing.Size(130, 28);
            this.cboLocKetQua.TabIndex = 7;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(120)))), ((int)(((byte)(190)))));
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(688, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(90, 30);
            this.btnXem.TabIndex = 8;
            this.btnXem.Text = "🔍  Xem";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnInBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnInBaoCao.Location = new System.Drawing.Point(788, 12);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(120, 30);
            this.btnInBaoCao.TabIndex = 9;
            this.btnInBaoCao.Text = "🖨  In báo cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = false;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // lblThongKe
            // 
            this.lblThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.lblThongKe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblThongKe.Location = new System.Drawing.Point(0, 572);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(1000, 28);
            this.lblThongKe.TabIndex = 1;
            this.lblThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKetQua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKetQua.ColumnHeadersHeight = 29;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.EnableHeadersVisualStyles = false;
            this.dgvKetQua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvKetQua.Location = new System.Drawing.Point(0, 113);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersVisible = false;
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.RowTemplate.Height = 26;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(1000, 459);
            this.dgvKetQua.TabIndex = 0;
            // 
            // frmBaoCaoKTKL
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.lblThongKe);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "frmBaoCaoKTKL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo Khen Thưởng - Kỷ Luật";
            this.Load += new System.EventHandler(this.frmBaoCaoKTKL_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lblPB;
        private System.Windows.Forms.ComboBox cboPB;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.ComboBox cboLocKetQua;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenPB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenCV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoNgayCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoNgayDiTre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoNgayTangCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLyDo;
    }
}