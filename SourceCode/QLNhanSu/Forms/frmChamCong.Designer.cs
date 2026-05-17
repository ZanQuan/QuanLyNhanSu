namespace QLNhanSu.Forms
{
    partial class frmChamCong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblGioHienTai = new System.Windows.Forms.Label();
            this.grpHomNay = new System.Windows.Forms.GroupBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblNgayHomNay = new System.Windows.Forms.Label();
            this.lblBatDau = new System.Windows.Forms.Label();
            this.lblKetThuc = new System.Windows.Forms.Label();
            this.btnBatDauCa = new System.Windows.Forms.Button();
            this.btnKetThucCa = new System.Windows.Forms.Button();
            this.grpLichSu = new System.Windows.Forms.GroupBox();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblThang = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.grpHomNay.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.grpLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pnlTop.Controls.Add(this.lblMaNV);
            this.pnlTop.Controls.Add(this.lblHoTen);
            this.pnlTop.Controls.Add(this.lblChucVu);
            this.pnlTop.Controls.Add(this.lblPhong);
            this.pnlTop.Controls.Add(this.lblGioHienTai);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlTop.Size = new System.Drawing.Size(695, 100);
            this.pnlTop.TabIndex = 0;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaNV.ForeColor = System.Drawing.Color.White;
            this.lblMaNV.Location = new System.Drawing.Point(12, 10);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(0, 23);
            this.lblMaNV.TabIndex = 0;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHoTen.ForeColor = System.Drawing.Color.White;
            this.lblHoTen.Location = new System.Drawing.Point(12, 30);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(0, 30);
            this.lblHoTen.TabIndex = 1;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblChucVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.lblChucVu.Location = new System.Drawing.Point(12, 60);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(0, 21);
            this.lblChucVu.TabIndex = 2;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.lblPhong.Location = new System.Drawing.Point(12, 78);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(0, 21);
            this.lblPhong.TabIndex = 3;
            // 
            // lblGioHienTai
            // 
            this.lblGioHienTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGioHienTai.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblGioHienTai.ForeColor = System.Drawing.Color.White;
            this.lblGioHienTai.Location = new System.Drawing.Point(835, 30);
            this.lblGioHienTai.Name = "lblGioHienTai";
            this.lblGioHienTai.Size = new System.Drawing.Size(300, 40);
            this.lblGioHienTai.TabIndex = 4;
            this.lblGioHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpHomNay
            // 
            this.grpHomNay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHomNay.Controls.Add(this.pnlStatus);
            this.grpHomNay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpHomNay.Location = new System.Drawing.Point(10, 108);
            this.grpHomNay.Name = "grpHomNay";
            this.grpHomNay.Size = new System.Drawing.Size(681, 170);
            this.grpHomNay.TabIndex = 1;
            this.grpHomNay.TabStop = false;
            this.grpHomNay.Text = "📋 Chấm công hôm nay";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.lblNgayHomNay);
            this.pnlStatus.Controls.Add(this.lblBatDau);
            this.pnlStatus.Controls.Add(this.lblKetThuc);
            this.pnlStatus.Controls.Add(this.btnBatDauCa);
            this.pnlStatus.Controls.Add(this.btnKetThucCa);
            this.pnlStatus.Location = new System.Drawing.Point(8, 22);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(665, 100);
            this.pnlStatus.TabIndex = 0;
            // 
            // lblNgayHomNay
            // 
            this.lblNgayHomNay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNgayHomNay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNgayHomNay.Location = new System.Drawing.Point(8, 8);
            this.lblNgayHomNay.Name = "lblNgayHomNay";
            this.lblNgayHomNay.Size = new System.Drawing.Size(400, 22);
            this.lblNgayHomNay.TabIndex = 0;
            // 
            // lblBatDau
            // 
            this.lblBatDau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBatDau.Location = new System.Drawing.Point(8, 36);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Size = new System.Drawing.Size(280, 24);
            this.lblBatDau.TabIndex = 1;
            // 
            // lblKetThuc
            // 
            this.lblKetThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKetThuc.Location = new System.Drawing.Point(8, 62);
            this.lblKetThuc.Name = "lblKetThuc";
            this.lblKetThuc.Size = new System.Drawing.Size(280, 24);
            this.lblKetThuc.TabIndex = 2;
            // 
            // btnBatDauCa
            // 
            this.btnBatDauCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnBatDauCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatDauCa.FlatAppearance.BorderSize = 0;
            this.btnBatDauCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatDauCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBatDauCa.ForeColor = System.Drawing.Color.White;
            this.btnBatDauCa.Location = new System.Drawing.Point(300, 10);
            this.btnBatDauCa.Name = "btnBatDauCa";
            this.btnBatDauCa.Size = new System.Drawing.Size(170, 80);
            this.btnBatDauCa.TabIndex = 3;
            this.btnBatDauCa.Text = "▶  BẮT ĐẦU CA";
            this.btnBatDauCa.UseVisualStyleBackColor = false;
            this.btnBatDauCa.Click += new System.EventHandler(this.btnBatDauCa_Click);
            // 
            // btnKetThucCa
            // 
            this.btnKetThucCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnKetThucCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKetThucCa.FlatAppearance.BorderSize = 0;
            this.btnKetThucCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKetThucCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnKetThucCa.ForeColor = System.Drawing.Color.White;
            this.btnKetThucCa.Location = new System.Drawing.Point(480, 10);
            this.btnKetThucCa.Name = "btnKetThucCa";
            this.btnKetThucCa.Size = new System.Drawing.Size(170, 80);
            this.btnKetThucCa.TabIndex = 4;
            this.btnKetThucCa.Text = "⏹  KẾT THÚC CA";
            this.btnKetThucCa.UseVisualStyleBackColor = false;
            this.btnKetThucCa.Click += new System.EventHandler(this.btnKetThucCa_Click);
            // 
            // grpLichSu
            // 
            this.grpLichSu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLichSu.Controls.Add(this.dgvLichSu);
            this.grpLichSu.Controls.Add(this.pnlFilter);
            this.grpLichSu.Controls.Add(this.lblThongKe);
            this.grpLichSu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpLichSu.Location = new System.Drawing.Point(10, 285);
            this.grpLichSu.Name = "grpLichSu";
            this.grpLichSu.Size = new System.Drawing.Size(681, 295);
            this.grpLichSu.TabIndex = 2;
            this.grpLichSu.TabStop = false;
            this.grpLichSu.Text = "📅 Lịch sử chấm công";
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichSu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLichSu.ColumnHeadersHeight = 30;
            this.dgvLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSu.EnableHeadersVisualStyles = false;
            this.dgvLichSu.GridColor = System.Drawing.Color.LightGray;
            this.dgvLichSu.Location = new System.Drawing.Point(3, 64);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.RowHeadersWidth = 51;
            this.dgvLichSu.RowTemplate.Height = 26;
            this.dgvLichSu.Size = new System.Drawing.Size(675, 200);
            this.dgvLichSu.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.lblThang);
            this.pnlFilter.Controls.Add(this.numThang);
            this.pnlFilter.Controls.Add(this.lblNam);
            this.pnlFilter.Controls.Add(this.numNam);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(3, 26);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(6, 6, 6, 4);
            this.pnlFilter.Size = new System.Drawing.Size(675, 38);
            this.pnlFilter.TabIndex = 1;
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblThang.Location = new System.Drawing.Point(6, 8);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(56, 21);
            this.lblThang.TabIndex = 0;
            this.lblThang.Text = "Tháng:";
            // 
            // numThang
            // 
            this.numThang.Location = new System.Drawing.Point(58, 6);
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
            this.numThang.Size = new System.Drawing.Size(50, 30);
            this.numThang.TabIndex = 1;
            this.numThang.Value = new System.DateTime(2026, 5, 14, 9, 30, 35, 415).Month;
            this.numThang.ValueChanged += new System.EventHandler(this.numThang_ValueChanged);
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNam.Location = new System.Drawing.Point(120, 8);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(47, 21);
            this.lblNam.TabIndex = 2;
            this.lblNam.Text = "Năm:";
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(173, 6);
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
            this.numNam.Size = new System.Drawing.Size(69, 30);
            this.numNam.TabIndex = 3;
            this.numNam.Value = new System.DateTime(2026, 5, 14, 9, 30, 35, 421).Year;
            this.numNam.ValueChanged += new System.EventHandler(this.numNam_ValueChanged);
            // 
            // lblThongKe
            // 
            this.lblThongKe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.lblThongKe.Location = new System.Drawing.Point(3, 264);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblThongKe.Size = new System.Drawing.Size(675, 28);
            this.lblThongKe.TabIndex = 2;
            this.lblThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmChamCong
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(695, 573);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHomNay);
            this.Controls.Add(this.grpLichSu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(660, 580);
            this.Name = "frmChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chấm Công Ca Làm Việc";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChamCong_FormClosed);
            this.Load += new System.EventHandler(this.frmChamCong_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpHomNay.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.grpLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        // Controls
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblGioHienTai;

        private System.Windows.Forms.GroupBox grpHomNay;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblNgayHomNay;
        private System.Windows.Forms.Label lblBatDau;
        private System.Windows.Forms.Label lblKetThuc;
        private System.Windows.Forms.Button btnBatDauCa;
        private System.Windows.Forms.Button btnKetThucCa;

        private System.Windows.Forms.GroupBox grpLichSu;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.DataGridView dgvLichSu;
    }
}