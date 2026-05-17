namespace QLNhanSu.Forms
{
    partial class frmDMTonGiao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMTonGiao));
            this.dgv_DMTG = new System.Windows.Forms.DataGridView();
            this.MaTG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txttentg = new System.Windows.Forms.TextBox();
            this.txtmatg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpbox = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DMTG)).BeginInit();
            this.panel1.SuspendLayout();
            this.grpbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DMTG
            // 
            this.dgv_DMTG.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_DMTG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DMTG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTG,
            this.TenTG});
            this.dgv_DMTG.Location = new System.Drawing.Point(13, 84);
            this.dgv_DMTG.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_DMTG.Name = "dgv_DMTG";
            this.dgv_DMTG.ReadOnly = true;
            this.dgv_DMTG.RowHeadersWidth = 51;
            this.dgv_DMTG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_DMTG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DMTG.Size = new System.Drawing.Size(397, 197);
            this.dgv_DMTG.TabIndex = 0;
            this.dgv_DMTG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DMTG_CellClick);
            // 
            // MaTG
            // 
            this.MaTG.DataPropertyName = "MATG";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.MaTG.DefaultCellStyle = dataGridViewCellStyle5;
            this.MaTG.Frozen = true;
            this.MaTG.HeaderText = "Mã tôn giáo";
            this.MaTG.MinimumWidth = 6;
            this.MaTG.Name = "MaTG";
            this.MaTG.ReadOnly = true;
            this.MaTG.Width = 125;
            // 
            // TenTG
            // 
            this.TenTG.DataPropertyName = "TenTG";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.TenTG.DefaultCellStyle = dataGridViewCellStyle6;
            this.TenTG.HeaderText = "Tên tôn giáo";
            this.TenTG.MinimumWidth = 6;
            this.TenTG.Name = "TenTG";
            this.TenTG.ReadOnly = true;
            this.TenTG.Width = 150;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txttentg);
            this.panel1.Controls.Add(this.txtmatg);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgv_DMTG);
            this.panel1.Location = new System.Drawing.Point(13, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 292);
            this.panel1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tên tôn giáo :";
            // 
            // txttentg
            // 
            this.txttentg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txttentg.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttentg.Location = new System.Drawing.Point(149, 46);
            this.txttentg.Margin = new System.Windows.Forms.Padding(4);
            this.txttentg.MaxLength = 50;
            this.txttentg.Name = "txttentg";
            this.txttentg.ReadOnly = true;
            this.txttentg.Size = new System.Drawing.Size(260, 26);
            this.txttentg.TabIndex = 26;
            this.txttentg.Tag = "";
            // 
            // txtmatg
            // 
            this.txtmatg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtmatg.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmatg.Location = new System.Drawing.Point(149, 7);
            this.txtmatg.Margin = new System.Windows.Forms.Padding(4);
            this.txtmatg.MaxLength = 8;
            this.txtmatg.Name = "txtmatg";
            this.txtmatg.ReadOnly = true;
            this.txtmatg.Size = new System.Drawing.Size(143, 26);
            this.txtmatg.TabIndex = 24;
            this.txtmatg.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "Mã tôn giáo :";
            // 
            // grpbox
            // 
            this.grpbox.Controls.Add(this.btnLuu);
            this.grpbox.Controls.Add(this.btnThoat);
            this.grpbox.Controls.Add(this.btnThem);
            this.grpbox.Controls.Add(this.btnSua);
            this.grpbox.Controls.Add(this.btnXoa);
            this.grpbox.Location = new System.Drawing.Point(444, 8);
            this.grpbox.Margin = new System.Windows.Forms.Padding(4);
            this.grpbox.Name = "grpbox";
            this.grpbox.Padding = new System.Windows.Forms.Padding(4);
            this.grpbox.Size = new System.Drawing.Size(111, 303);
            this.grpbox.TabIndex = 21;
            this.grpbox.TabStop = false;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(7, 187);
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
            this.btnThoat.Location = new System.Drawing.Point(7, 241);
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
            this.btnThem.Location = new System.Drawing.Point(7, 25);
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
            this.btnSua.Location = new System.Drawing.Point(7, 79);
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
            this.btnXoa.Location = new System.Drawing.Point(7, 133);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(97, 37);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmDMTonGiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(569, 318);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMTonGiao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục Tôn Giáo";
            this.Load += new System.EventHandler(this.frmDMTonGiao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DMTG)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DMTG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTG;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttentg;
        private System.Windows.Forms.TextBox txtmatg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpbox;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
    }
}