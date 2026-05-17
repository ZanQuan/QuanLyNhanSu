namespace QLNhanSu.Forms
{
    partial class frmDMChuyenMon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMChuyenMon));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txttenCM = new System.Windows.Forms.TextBox();
            this.txtmaCM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_DMchuyenmon = new System.Windows.Forms.DataGridView();
            this.grpbox = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.MaChuyenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenChuyenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DMchuyenmon)).BeginInit();
            this.grpbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.txttenCM);
            this.panel1.Controls.Add(this.txtmaCM);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgv_DMchuyenmon);
            this.panel1.Location = new System.Drawing.Point(13, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 292);
            this.panel1.TabIndex = 19;
            // 
            // txttenCM
            // 
            this.txttenCM.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txttenCM.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenCM.Location = new System.Drawing.Point(72, 50);
            this.txttenCM.Margin = new System.Windows.Forms.Padding(4);
            this.txttenCM.MaxLength = 50;
            this.txttenCM.Name = "txttenCM";
            this.txttenCM.ReadOnly = true;
            this.txttenCM.Size = new System.Drawing.Size(277, 26);
            this.txttenCM.TabIndex = 18;
            this.txttenCM.Tag = "";
            // 
            // txtmaCM
            // 
            this.txtmaCM.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtmaCM.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmaCM.Location = new System.Drawing.Point(72, 12);
            this.txtmaCM.Margin = new System.Windows.Forms.Padding(4);
            this.txtmaCM.MaxLength = 8;
            this.txtmaCM.Name = "txtmaCM";
            this.txtmaCM.ReadOnly = true;
            this.txtmaCM.Size = new System.Drawing.Size(143, 26);
            this.txtmaCM.TabIndex = 16;
            this.txtmaCM.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tên :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mã :";
            // 
            // dgv_DMchuyenmon
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgv_DMchuyenmon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DMchuyenmon.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DMchuyenmon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_DMchuyenmon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DMchuyenmon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChuyenMon,
            this.TenChuyenMon});
            this.dgv_DMchuyenmon.Location = new System.Drawing.Point(12, 94);
            this.dgv_DMchuyenmon.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_DMchuyenmon.Name = "dgv_DMchuyenmon";
            this.dgv_DMchuyenmon.ReadOnly = true;
            this.dgv_DMchuyenmon.RowHeadersWidth = 51;
            this.dgv_DMchuyenmon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_DMchuyenmon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DMchuyenmon.Size = new System.Drawing.Size(442, 185);
            this.dgv_DMchuyenmon.TabIndex = 1;
            this.dgv_DMchuyenmon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DMchuyenmon_CellClick);
            // 
            // grpbox
            // 
            this.grpbox.Controls.Add(this.btnXoa);
            this.grpbox.Controls.Add(this.btnLuu);
            this.grpbox.Controls.Add(this.btnThoat);
            this.grpbox.Controls.Add(this.btnThem);
            this.grpbox.Controls.Add(this.btnSua);
            this.grpbox.Location = new System.Drawing.Point(494, 17);
            this.grpbox.Margin = new System.Windows.Forms.Padding(4);
            this.grpbox.Name = "grpbox";
            this.grpbox.Padding = new System.Windows.Forms.Padding(4);
            this.grpbox.Size = new System.Drawing.Size(121, 299);
            this.grpbox.TabIndex = 20;
            this.grpbox.TabStop = false;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(12, 130);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(97, 37);
            this.btnXoa.TabIndex = 19;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(12, 185);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(97, 37);
            this.btnLuu.TabIndex = 18;
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
            this.btnThoat.Location = new System.Drawing.Point(12, 239);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(97, 37);
            this.btnThoat.TabIndex = 17;
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
            this.btnThem.Location = new System.Drawing.Point(12, 22);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(97, 37);
            this.btnThem.TabIndex = 16;
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
            this.btnSua.Location = new System.Drawing.Point(12, 76);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(97, 37);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // MaChuyenMon
            // 
            this.MaChuyenMon.DataPropertyName = "MaChuyenMon";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.MaChuyenMon.DefaultCellStyle = dataGridViewCellStyle3;
            this.MaChuyenMon.Frozen = true;
            this.MaChuyenMon.HeaderText = "Mã";
            this.MaChuyenMon.MinimumWidth = 6;
            this.MaChuyenMon.Name = "MaChuyenMon";
            this.MaChuyenMon.ReadOnly = true;
            this.MaChuyenMon.Width = 60;
            // 
            // TenChuyenMon
            // 
            this.TenChuyenMon.DataPropertyName = "TenChuyenMon";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.TenChuyenMon.DefaultCellStyle = dataGridViewCellStyle4;
            this.TenChuyenMon.HeaderText = "Tên chuyên môn";
            this.TenChuyenMon.MinimumWidth = 6;
            this.TenChuyenMon.Name = "TenChuyenMon";
            this.TenChuyenMon.ReadOnly = true;
            this.TenChuyenMon.Width = 250;
            // 
            // frmDMChuyenMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(628, 319);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMChuyenMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục Chuyên Môn";
            this.Load += new System.EventHandler(this.frmDMChuyenMon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DMchuyenmon)).EndInit();
            this.grpbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txttenCM;
        private System.Windows.Forms.TextBox txtmaCM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_DMchuyenmon;
        private System.Windows.Forms.GroupBox grpbox;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChuyenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenChuyenMon;
    }
}