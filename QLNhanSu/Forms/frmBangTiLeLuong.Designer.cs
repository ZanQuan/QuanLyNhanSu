namespace QLNhanSu.Forms
{
    partial class frmBangTiLeLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBangTiLeLuong));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdluu = new System.Windows.Forms.Button();
            this.cmdthoat = new System.Windows.Forms.Button();
            this.cmdthem = new System.Windows.Forms.Button();
            this.cmdxoa = new System.Windows.Forms.Button();
            this.grpbox = new System.Windows.Forms.GroupBox();
            this.cmdCapnhat = new System.Windows.Forms.Button();
            this.maphong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songaycong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tileluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboto = new System.Windows.Forms.ComboBox();
            this.cbonam = new System.Windows.Forms.ComboBox();
            this.cbothang = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsongaycong = new System.Windows.Forms.TextBox();
            this.txttll = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.dgv_TiLeLuong = new System.Windows.Forms.DataGridView();
            this.pnlthongtin = new System.Windows.Forms.Panel();
            this.grpbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TiLeLuong)).BeginInit();
            this.pnlthongtin.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdluu
            // 
            this.cmdluu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdluu.Image = ((System.Drawing.Image)(resources.GetObject("cmdluu.Image")));
            this.cmdluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdluu.Location = new System.Drawing.Point(296, 11);
            this.cmdluu.Margin = new System.Windows.Forms.Padding(4);
            this.cmdluu.Name = "cmdluu";
            this.cmdluu.Size = new System.Drawing.Size(96, 37);
            this.cmdluu.TabIndex = 4;
            this.cmdluu.Text = "Lưu";
            this.cmdluu.UseVisualStyleBackColor = true;
            // 
            // cmdthoat
            // 
            this.cmdthoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdthoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdthoat.Image")));
            this.cmdthoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdthoat.Location = new System.Drawing.Point(393, 11);
            this.cmdthoat.Margin = new System.Windows.Forms.Padding(4);
            this.cmdthoat.Name = "cmdthoat";
            this.cmdthoat.Size = new System.Drawing.Size(96, 37);
            this.cmdthoat.TabIndex = 5;
            this.cmdthoat.Text = "Thoát";
            this.cmdthoat.UseVisualStyleBackColor = true;
            // 
            // cmdthem
            // 
            this.cmdthem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdthem.Image = ((System.Drawing.Image)(resources.GetObject("cmdthem.Image")));
            this.cmdthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdthem.Location = new System.Drawing.Point(7, 11);
            this.cmdthem.Margin = new System.Windows.Forms.Padding(4);
            this.cmdthem.Name = "cmdthem";
            this.cmdthem.Size = new System.Drawing.Size(96, 37);
            this.cmdthem.TabIndex = 1;
            this.cmdthem.Text = "Thêm";
            this.cmdthem.UseVisualStyleBackColor = true;
            // 
            // cmdxoa
            // 
            this.cmdxoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdxoa.Image = ((System.Drawing.Image)(resources.GetObject("cmdxoa.Image")));
            this.cmdxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdxoa.Location = new System.Drawing.Point(199, 11);
            this.cmdxoa.Margin = new System.Windows.Forms.Padding(4);
            this.cmdxoa.Name = "cmdxoa";
            this.cmdxoa.Size = new System.Drawing.Size(96, 37);
            this.cmdxoa.TabIndex = 3;
            this.cmdxoa.Text = "Xóa";
            this.cmdxoa.UseVisualStyleBackColor = true;
            // 
            // grpbox
            // 
            this.grpbox.Controls.Add(this.cmdluu);
            this.grpbox.Controls.Add(this.cmdthoat);
            this.grpbox.Controls.Add(this.cmdthem);
            this.grpbox.Controls.Add(this.cmdCapnhat);
            this.grpbox.Controls.Add(this.cmdxoa);
            this.grpbox.Location = new System.Drawing.Point(81, 324);
            this.grpbox.Margin = new System.Windows.Forms.Padding(4);
            this.grpbox.Name = "grpbox";
            this.grpbox.Padding = new System.Windows.Forms.Padding(4);
            this.grpbox.Size = new System.Drawing.Size(499, 52);
            this.grpbox.TabIndex = 16;
            this.grpbox.TabStop = false;
            // 
            // cmdCapnhat
            // 
            this.cmdCapnhat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCapnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCapnhat.Image = ((System.Drawing.Image)(resources.GetObject("cmdCapnhat.Image")));
            this.cmdCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCapnhat.Location = new System.Drawing.Point(104, 11);
            this.cmdCapnhat.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCapnhat.Name = "cmdCapnhat";
            this.cmdCapnhat.Size = new System.Drawing.Size(96, 37);
            this.cmdCapnhat.TabIndex = 2;
            this.cmdCapnhat.Text = "Sửa";
            this.cmdCapnhat.UseVisualStyleBackColor = true;
            // 
            // maphong
            // 
            this.maphong.DataPropertyName = "maphong";
            this.maphong.HeaderText = "Maphong";
            this.maphong.MinimumWidth = 6;
            this.maphong.Name = "maphong";
            this.maphong.ReadOnly = true;
            this.maphong.Visible = false;
            this.maphong.Width = 125;
            // 
            // MaTo
            // 
            this.MaTo.DataPropertyName = "mato";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.MaTo.DefaultCellStyle = dataGridViewCellStyle1;
            this.MaTo.HeaderText = "mato";
            this.MaTo.MinimumWidth = 6;
            this.MaTo.Name = "MaTo";
            this.MaTo.ReadOnly = true;
            this.MaTo.Visible = false;
            this.MaTo.Width = 80;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Mã";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 80;
            // 
            // songaycong
            // 
            this.songaycong.DataPropertyName = "songaycongthang";
            this.songaycong.HeaderText = "Số ngày công tháng";
            this.songaycong.MinimumWidth = 6;
            this.songaycong.Name = "songaycong";
            this.songaycong.ReadOnly = true;
            this.songaycong.Width = 160;
            // 
            // tileluong
            // 
            this.tileluong.DataPropertyName = "tileluong";
            this.tileluong.HeaderText = "Tỉ lệ lương";
            this.tileluong.MinimumWidth = 6;
            this.tileluong.Name = "tileluong";
            this.tileluong.ReadOnly = true;
            this.tileluong.Width = 120;
            // 
            // TenTo
            // 
            this.TenTo.DataPropertyName = "tento";
            this.TenTo.HeaderText = "Tổ";
            this.TenTo.MinimumWidth = 6;
            this.TenTo.Name = "TenTo";
            this.TenTo.ReadOnly = true;
            this.TenTo.Width = 150;
            // 
            // tenPhong
            // 
            this.tenPhong.DataPropertyName = "tenphong";
            this.tenPhong.HeaderText = "Phòng";
            this.tenPhong.MinimumWidth = 6;
            this.tenPhong.Name = "tenPhong";
            this.tenPhong.ReadOnly = true;
            this.tenPhong.Width = 165;
            // 
            // nam
            // 
            this.nam.DataPropertyName = "nam";
            this.nam.HeaderText = "Năm";
            this.nam.MinimumWidth = 6;
            this.nam.Name = "nam";
            this.nam.ReadOnly = true;
            this.nam.Width = 125;
            // 
            // thang
            // 
            this.thang.DataPropertyName = "thang";
            this.thang.HeaderText = "Tháng";
            this.thang.MinimumWidth = 6;
            this.thang.Name = "thang";
            this.thang.ReadOnly = true;
            this.thang.Width = 125;
            // 
            // cboto
            // 
            this.cboto.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboto.Enabled = false;
            this.cboto.ForeColor = System.Drawing.Color.Black;
            this.cboto.FormattingEnabled = true;
            this.cboto.Location = new System.Drawing.Point(400, 43);
            this.cboto.Margin = new System.Windows.Forms.Padding(4);
            this.cboto.Name = "cboto";
            this.cboto.Size = new System.Drawing.Size(195, 24);
            this.cboto.TabIndex = 4;
            // 
            // cbonam
            // 
            this.cbonam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbonam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbonam.Enabled = false;
            this.cbonam.ForeColor = System.Drawing.Color.Black;
            this.cbonam.FormattingEnabled = true;
            this.cbonam.Location = new System.Drawing.Point(400, 7);
            this.cbonam.Margin = new System.Windows.Forms.Padding(4);
            this.cbonam.Name = "cbonam";
            this.cbonam.Size = new System.Drawing.Size(85, 24);
            this.cbonam.TabIndex = 2;
            // 
            // cbothang
            // 
            this.cbothang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbothang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbothang.Enabled = false;
            this.cbothang.ForeColor = System.Drawing.Color.Black;
            this.cbothang.FormattingEnabled = true;
            this.cbothang.Location = new System.Drawing.Point(244, 7);
            this.cbothang.Margin = new System.Windows.Forms.Padding(4);
            this.cbothang.Name = "cbothang";
            this.cbothang.Size = new System.Drawing.Size(60, 24);
            this.cbothang.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(351, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 19);
            this.label7.TabIndex = 28;
            this.label7.Text = "Năm :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tháng :";
            // 
            // txtsongaycong
            // 
            this.txtsongaycong.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtsongaycong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsongaycong.Location = new System.Drawing.Point(469, 74);
            this.txtsongaycong.Margin = new System.Windows.Forms.Padding(4);
            this.txtsongaycong.MaxLength = 2;
            this.txtsongaycong.Name = "txtsongaycong";
            this.txtsongaycong.Size = new System.Drawing.Size(39, 26);
            this.txtsongaycong.TabIndex = 6;
            this.txtsongaycong.Tag = "";
            this.txtsongaycong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txttll
            // 
            this.txttll.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txttll.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttll.Location = new System.Drawing.Point(233, 74);
            this.txttll.Margin = new System.Windows.Forms.Padding(4);
            this.txttll.MaxLength = 6;
            this.txttll.Name = "txttll";
            this.txttll.Size = new System.Drawing.Size(71, 26);
            this.txttll.TabIndex = 5;
            this.txttll.Tag = "";
            this.txttll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(351, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 19);
            this.label6.TabIndex = 24;
            this.label6.Text = "Số ngày công :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(116, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 19);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tỉ lệ lương :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Phòng :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(351, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tổ :";
            // 
            // cboPhong
            // 
            this.cboPhong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.Enabled = false;
            this.cboPhong.ForeColor = System.Drawing.Color.Black;
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(81, 42);
            this.cboPhong.Margin = new System.Windows.Forms.Padding(4);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(223, 24);
            this.cboPhong.TabIndex = 3;
            // 
            // dgv_TiLeLuong
            // 
            this.dgv_TiLeLuong.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_TiLeLuong.ColumnHeadersHeight = 29;
            this.dgv_TiLeLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.thang,
            this.nam,
            this.tenPhong,
            this.TenTo,
            this.tileluong,
            this.songaycong,
            this.id,
            this.MaTo,
            this.maphong});
            this.dgv_TiLeLuong.Location = new System.Drawing.Point(12, 110);
            this.dgv_TiLeLuong.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_TiLeLuong.Name = "dgv_TiLeLuong";
            this.dgv_TiLeLuong.ReadOnly = true;
            this.dgv_TiLeLuong.RowHeadersWidth = 51;
            this.dgv_TiLeLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_TiLeLuong.Size = new System.Drawing.Size(600, 197);
            this.dgv_TiLeLuong.TabIndex = 1;
            // 
            // pnlthongtin
            // 
            this.pnlthongtin.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlthongtin.Controls.Add(this.cboto);
            this.pnlthongtin.Controls.Add(this.cbonam);
            this.pnlthongtin.Controls.Add(this.cbothang);
            this.pnlthongtin.Controls.Add(this.label7);
            this.pnlthongtin.Controls.Add(this.label3);
            this.pnlthongtin.Controls.Add(this.txtsongaycong);
            this.pnlthongtin.Controls.Add(this.txttll);
            this.pnlthongtin.Controls.Add(this.label6);
            this.pnlthongtin.Controls.Add(this.label4);
            this.pnlthongtin.Controls.Add(this.label1);
            this.pnlthongtin.Controls.Add(this.label2);
            this.pnlthongtin.Controls.Add(this.cboPhong);
            this.pnlthongtin.Controls.Add(this.dgv_TiLeLuong);
            this.pnlthongtin.Location = new System.Drawing.Point(18, 11);
            this.pnlthongtin.Margin = new System.Windows.Forms.Padding(4);
            this.pnlthongtin.Name = "pnlthongtin";
            this.pnlthongtin.Size = new System.Drawing.Size(624, 314);
            this.pnlthongtin.TabIndex = 15;
            // 
            // frmBangTiLeLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(660, 387);
            this.Controls.Add(this.grpbox);
            this.Controls.Add(this.pnlthongtin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBangTiLeLuong";
            this.Text = "Bảng Tỉ Lệ Lương Tháng";
            this.grpbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TiLeLuong)).EndInit();
            this.pnlthongtin.ResumeLayout(false);
            this.pnlthongtin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdluu;
        private System.Windows.Forms.Button cmdthoat;
        private System.Windows.Forms.Button cmdthem;
        private System.Windows.Forms.Button cmdxoa;
        private System.Windows.Forms.GroupBox grpbox;
        private System.Windows.Forms.Button cmdCapnhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn maphong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn songaycong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tileluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn thang;
        private System.Windows.Forms.ComboBox cboto;
        private System.Windows.Forms.ComboBox cbonam;
        private System.Windows.Forms.ComboBox cbothang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsongaycong;
        private System.Windows.Forms.TextBox txttll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.DataGridView dgv_TiLeLuong;
        private System.Windows.Forms.Panel pnlthongtin;
    }
}