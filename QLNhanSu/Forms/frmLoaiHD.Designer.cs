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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiHD));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txttenloai = new System.Windows.Forms.TextBox();
            this.txtmahd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_DMHD = new System.Windows.Forms.DataGridView();
            this.MaLoaiHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpbox = new System.Windows.Forms.GroupBox();
            this.cmdluu = new System.Windows.Forms.Button();
            this.cmdthoat = new System.Windows.Forms.Button();
            this.cmdthem = new System.Windows.Forms.Button();
            this.cmdCapnhat = new System.Windows.Forms.Button();
            this.cmdxoa = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(447, 292);
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
            this.dgv_DMHD.Size = new System.Drawing.Size(419, 197);
            this.dgv_DMHD.TabIndex = 1;
            // 
            // MaLoaiHD
            // 
            this.MaLoaiHD.DataPropertyName = "Maloaihd";
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
            this.TenLoaiHD.DataPropertyName = "tenloaihd";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.TenLoaiHD.DefaultCellStyle = dataGridViewCellStyle2;
            this.TenLoaiHD.HeaderText = "Tên loại HĐ";
            this.TenLoaiHD.MinimumWidth = 6;
            this.TenLoaiHD.Name = "TenLoaiHD";
            this.TenLoaiHD.ReadOnly = true;
            this.TenLoaiHD.Width = 180;
            // 
            // grpbox
            // 
            this.grpbox.Controls.Add(this.cmdluu);
            this.grpbox.Controls.Add(this.cmdthoat);
            this.grpbox.Controls.Add(this.cmdthem);
            this.grpbox.Controls.Add(this.cmdCapnhat);
            this.grpbox.Controls.Add(this.cmdxoa);
            this.grpbox.Location = new System.Drawing.Point(468, 10);
            this.grpbox.Margin = new System.Windows.Forms.Padding(4);
            this.grpbox.Name = "grpbox";
            this.grpbox.Padding = new System.Windows.Forms.Padding(4);
            this.grpbox.Size = new System.Drawing.Size(108, 299);
            this.grpbox.TabIndex = 19;
            this.grpbox.TabStop = false;
            // 
            // cmdluu
            // 
            this.cmdluu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdluu.Image = ((System.Drawing.Image)(resources.GetObject("cmdluu.Image")));
            this.cmdluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdluu.Location = new System.Drawing.Point(5, 186);
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
            this.cmdthoat.Location = new System.Drawing.Point(5, 240);
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
            this.cmdthem.Location = new System.Drawing.Point(5, 22);
            this.cmdthem.Margin = new System.Windows.Forms.Padding(4);
            this.cmdthem.Name = "cmdthem";
            this.cmdthem.Size = new System.Drawing.Size(97, 37);
            this.cmdthem.TabIndex = 13;
            this.cmdthem.Text = "Thêm";
            this.cmdthem.UseVisualStyleBackColor = true;
            // 
            // cmdCapnhat
            // 
            this.cmdCapnhat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCapnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCapnhat.Image = ((System.Drawing.Image)(resources.GetObject("cmdCapnhat.Image")));
            this.cmdCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCapnhat.Location = new System.Drawing.Point(5, 78);
            this.cmdCapnhat.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCapnhat.Name = "cmdCapnhat";
            this.cmdCapnhat.Size = new System.Drawing.Size(97, 37);
            this.cmdCapnhat.TabIndex = 10;
            this.cmdCapnhat.Text = "Sửa";
            this.cmdCapnhat.UseVisualStyleBackColor = true;
            // 
            // cmdxoa
            // 
            this.cmdxoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdxoa.Image = ((System.Drawing.Image)(resources.GetObject("cmdxoa.Image")));
            this.cmdxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdxoa.Location = new System.Drawing.Point(5, 132);
            this.cmdxoa.Margin = new System.Windows.Forms.Padding(4);
            this.cmdxoa.Name = "cmdxoa";
            this.cmdxoa.Size = new System.Drawing.Size(97, 37);
            this.cmdxoa.TabIndex = 12;
            this.cmdxoa.Text = "Xóa";
            this.cmdxoa.UseVisualStyleBackColor = true;
            // 
            // frmLoaiHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(590, 318);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoaiHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loại Hợp Đồng";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiHD;
        private System.Windows.Forms.GroupBox grpbox;
        private System.Windows.Forms.Button cmdluu;
        private System.Windows.Forms.Button cmdthoat;
        private System.Windows.Forms.Button cmdthem;
        private System.Windows.Forms.Button cmdCapnhat;
        private System.Windows.Forms.Button cmdxoa;
    }
}