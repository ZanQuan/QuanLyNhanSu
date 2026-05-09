namespace QLNhanSu.Forms
{
    partial class frmLoaiHD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiHD));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txttenloai = new System.Windows.Forms.TextBox();
            this.txtmahd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_DMHD = new System.Windows.Forms.DataGridView();
            this.grpbox = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.MaLoaiHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DMHD)).BeginInit();
            this.grpbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txttenloai);
            this.panel1.Controls.Add(this.txtmahd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dgv_DMHD);
            this.panel1.Location = new System.Drawing.Point(14, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 292);
            this.panel1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tên Loại HĐ";
            // 
            // txttenloai
            // 
            this.txttenloai.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txttenloai.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenloai.Location = new System.Drawing.Point(132, 47);
            this.txttenloai.Margin = new System.Windows.Forms.Padding(4);
            this.txttenloai.MaxLength = 50;
            this.txttenloai.Name = "txttenloai";
            this.txttenloai.ReadOnly = true;
            this.txttenloai.Size = new System.Drawing.Size(269, 26);
            this.txttenloai.TabIndex = 26;
            this.txttenloai.Tag = "";
            // 
            // txtmahd
            // 
            this.txtmahd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtmahd.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmahd.Location = new System.Drawing.Point(132, 11);
            this.txtmahd.Margin = new System.Windows.Forms.Padding(4);
            this.txtmahd.MaxLength = 8;
            this.txtmahd.Name = "txtmahd";
            this.txtmahd.ReadOnly = true;
            this.txtmahd.Size = new System.Drawing.Size(143, 26);
            this.txtmahd.TabIndex = 24;
            this.txtmahd.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.AliceBlue;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "Mã Loại HĐ";
            // 
            // dgv_DMHD
            // 
            this.dgv_DMHD.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_DMHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DMHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoaiHD,
            this.TenLoaiHD});
            this.dgv_DMHD.Location = new System.Drawing.Point(13, 87);
            this.dgv_DMHD.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_DMHD.Name = "dgv_DMHD";
            this.dgv_DMHD.ReadOnly = true;
            this.dgv_DMHD.RowHeadersWidth = 51;
            this.dgv_DMHD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_DMHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DMHD.Size = new System.Drawing.Size(664, 197);
            this.dgv_DMHD.TabIndex = 1;
            this.dgv_DMHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DMHD_CellClick);
            // 
            // grpbox
            // 
            this.grpbox.Controls.Add(this.btnLuu);
            this.grpbox.Controls.Add(this.btnThoat);
            this.grpbox.Controls.Add(this.btnThem);
            this.grpbox.Controls.Add(this.btnSua);
            this.grpbox.Controls.Add(this.btnXoa);
            this.grpbox.Location = new System.Drawing.Point(703, 17);
            this.grpbox.Margin = new System.Windows.Forms.Padding(4);
            this.grpbox.Name = "grpbox";
            this.grpbox.Padding = new System.Windows.Forms.Padding(4);
            this.grpbox.Size = new System.Drawing.Size(108, 299);
            this.grpbox.TabIndex = 19;
            this.grpbox.TabStop = false;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(5, 186);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(97, 37);
            this.btnLuu.TabIndex = 14;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(5, 240);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(97, 37);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(5, 22);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(97, 37);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(5, 78);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(97, 37);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(5, 132);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(97, 37);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // MaLoaiHD
            // 
            this.MaLoaiHD.DataPropertyName = "MaLoaiHD";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.MaLoaiHD.DefaultCellStyle = dataGridViewCellStyle1;
            this.MaLoaiHD.Frozen = true;
            this.MaLoaiHD.HeaderText = "Mã loại HĐ";
            this.MaLoaiHD.MinimumWidth = 6;
            this.MaLoaiHD.Name = "MaLoaiHD";
            this.MaLoaiHD.ReadOnly = true;
            this.MaLoaiHD.Width = 125;
            // 
            // TenLoaiHD
            // 
            this.TenLoaiHD.DataPropertyName = "TenLoai";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.TenLoaiHD.DefaultCellStyle = dataGridViewCellStyle2;
            this.TenLoaiHD.HeaderText = "Tên loại HĐ";
            this.TenLoaiHD.MinimumWidth = 6;
            this.TenLoaiHD.Name = "TenLoaiHD";
            this.TenLoaiHD.ReadOnly = true;
            this.TenLoaiHD.Width = 300;
            // 
            // frmLoaiHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(824, 318);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoaiHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loại Hợp Đồng";
            this.Load += new System.EventHandler(this.frmLoaiHD_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DMHD)).EndInit();
            this.grpbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttenloai;
        private System.Windows.Forms.TextBox txtmahd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_DMHD;
        private System.Windows.Forms.GroupBox grpbox;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiHD;
    }
}