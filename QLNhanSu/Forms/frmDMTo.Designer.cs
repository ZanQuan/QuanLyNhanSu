namespace QLNhanSu.Forms
{
    partial class frmDMTo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMTo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdluu = new System.Windows.Forms.Button();
            this.cmdthoat = new System.Windows.Forms.Button();
            this.cmdthem = new System.Windows.Forms.Button();
            this.cmdxoa = new System.Windows.Forms.Button();
            this.grpbox = new System.Windows.Forms.GroupBox();
            this.cmdCapnhat = new System.Windows.Forms.Button();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txttento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmato = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbomaphong = new System.Windows.Forms.ComboBox();
            this.dgv_DMTO = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DMTO)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdluu
            // 
            this.cmdluu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdluu.Image = ((System.Drawing.Image)(resources.GetObject("cmdluu.Image")));
            this.cmdluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdluu.Location = new System.Drawing.Point(7, 185);
            this.cmdluu.Margin = new System.Windows.Forms.Padding(4);
            this.cmdluu.Name = "cmdluu";
            this.cmdluu.Size = new System.Drawing.Size(97, 37);
            this.cmdluu.TabIndex = 14;
            this.cmdluu.Text = "Lưu";
            this.cmdluu.UseVisualStyleBackColor = true;
            // 
            // cmdthoat
            // 
            this.cmdthoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdthoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdthoat.Image")));
            this.cmdthoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdthoat.Location = new System.Drawing.Point(7, 239);
            this.cmdthoat.Margin = new System.Windows.Forms.Padding(4);
            this.cmdthoat.Name = "cmdthoat";
            this.cmdthoat.Size = new System.Drawing.Size(97, 37);
            this.cmdthoat.TabIndex = 11;
            this.cmdthoat.Text = "Thoát";
            this.cmdthoat.UseVisualStyleBackColor = true;
            // 
            // cmdthem
            // 
            this.cmdthem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdthem.Image = ((System.Drawing.Image)(resources.GetObject("cmdthem.Image")));
            this.cmdthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdthem.Location = new System.Drawing.Point(7, 22);
            this.cmdthem.Margin = new System.Windows.Forms.Padding(4);
            this.cmdthem.Name = "cmdthem";
            this.cmdthem.Size = new System.Drawing.Size(97, 37);
            this.cmdthem.TabIndex = 13;
            this.cmdthem.Text = "Thêm";
            this.cmdthem.UseVisualStyleBackColor = true;
            // 
            // cmdxoa
            // 
            this.cmdxoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdxoa.Image = ((System.Drawing.Image)(resources.GetObject("cmdxoa.Image")));
            this.cmdxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdxoa.Location = new System.Drawing.Point(7, 130);
            this.cmdxoa.Margin = new System.Windows.Forms.Padding(4);
            this.cmdxoa.Name = "cmdxoa";
            this.cmdxoa.Size = new System.Drawing.Size(97, 37);
            this.cmdxoa.TabIndex = 12;
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
            this.grpbox.Location = new System.Drawing.Point(531, 12);
            this.grpbox.Margin = new System.Windows.Forms.Padding(4);
            this.grpbox.Name = "grpbox";
            this.grpbox.Padding = new System.Windows.Forms.Padding(4);
            this.grpbox.Size = new System.Drawing.Size(111, 299);
            this.grpbox.TabIndex = 15;
            this.grpbox.TabStop = false;
            // 
            // cmdCapnhat
            // 
            this.cmdCapnhat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCapnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCapnhat.Image = ((System.Drawing.Image)(resources.GetObject("cmdCapnhat.Image")));
            this.cmdCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCapnhat.Location = new System.Drawing.Point(7, 76);
            this.cmdCapnhat.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCapnhat.Name = "cmdCapnhat";
            this.cmdCapnhat.Size = new System.Drawing.Size(97, 37);
            this.cmdCapnhat.TabIndex = 10;
            this.cmdCapnhat.Text = "Sửa";
            this.cmdCapnhat.UseVisualStyleBackColor = true;
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "tenphong";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.MaPhong.DefaultCellStyle = dataGridViewCellStyle1;
            this.MaPhong.HeaderText = "Phòng";
            this.MaPhong.MinimumWidth = 6;
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.ReadOnly = true;
            this.MaPhong.Width = 120;
            // 
            // TenTo
            // 
            this.TenTo.DataPropertyName = "tento";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.TenTo.DefaultCellStyle = dataGridViewCellStyle2;
            this.TenTo.HeaderText = "Tổ";
            this.TenTo.MinimumWidth = 6;
            this.TenTo.Name = "TenTo";
            this.TenTo.ReadOnly = true;
            this.TenTo.Width = 120;
            // 
            // MaTo
            // 
            this.MaTo.DataPropertyName = "mato";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.MaTo.DefaultCellStyle = dataGridViewCellStyle3;
            this.MaTo.HeaderText = "Mã Tổ";
            this.MaTo.MinimumWidth = 6;
            this.MaTo.Name = "MaTo";
            this.MaTo.ReadOnly = true;
            this.MaTo.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Phòng :";
            // 
            // txttento
            // 
            this.txttento.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txttento.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttento.Location = new System.Drawing.Point(179, 52);
            this.txttento.Margin = new System.Windows.Forms.Padding(4);
            this.txttento.MaxLength = 50;
            this.txttento.Name = "txttento";
            this.txttento.ReadOnly = true;
            this.txttento.Size = new System.Drawing.Size(264, 26);
            this.txttento.TabIndex = 17;
            this.txttento.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tên Tổ :";
            // 
            // txtmato
            // 
            this.txtmato.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtmato.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmato.Location = new System.Drawing.Point(116, 12);
            this.txtmato.Margin = new System.Windows.Forms.Padding(4);
            this.txtmato.MaxLength = 3;
            this.txtmato.Name = "txtmato";
            this.txtmato.ReadOnly = true;
            this.txtmato.Size = new System.Drawing.Size(143, 26);
            this.txtmato.TabIndex = 15;
            this.txtmato.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Mã Tổ :";
            // 
            // cbomaphong
            // 
            this.cbomaphong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbomaphong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbomaphong.Enabled = false;
            this.cbomaphong.FormattingEnabled = true;
            this.cbomaphong.Location = new System.Drawing.Point(345, 14);
            this.cbomaphong.Margin = new System.Windows.Forms.Padding(4);
            this.cbomaphong.Name = "cbomaphong";
            this.cbomaphong.Size = new System.Drawing.Size(160, 24);
            this.cbomaphong.TabIndex = 2;
            // 
            // dgv_DMTO
            // 
            this.dgv_DMTO.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_DMTO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DMTO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTo,
            this.TenTo,
            this.MaPhong});
            this.dgv_DMTO.Location = new System.Drawing.Point(13, 89);
            this.dgv_DMTO.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_DMTO.Name = "dgv_DMTO";
            this.dgv_DMTO.ReadOnly = true;
            this.dgv_DMTO.RowHeadersWidth = 51;
            this.dgv_DMTO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_DMTO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DMTO.Size = new System.Drawing.Size(493, 197);
            this.dgv_DMTO.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txttento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtmato);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbomaphong);
            this.panel1.Controls.Add(this.dgv_DMTO);
            this.panel1.Location = new System.Drawing.Point(13, 19);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 292);
            this.panel1.TabIndex = 14;
            // 
            // frmDMTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(655, 322);
            this.Controls.Add(this.grpbox);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMTo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục Tổ";
            this.grpbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DMTO)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdluu;
        private System.Windows.Forms.Button cmdthoat;
        private System.Windows.Forms.Button cmdthem;
        private System.Windows.Forms.Button cmdxoa;
        private System.Windows.Forms.GroupBox grpbox;
        private System.Windows.Forms.Button cmdCapnhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbomaphong;
        private System.Windows.Forms.DataGridView dgv_DMTO;
        private System.Windows.Forms.Panel panel1;
    }
}