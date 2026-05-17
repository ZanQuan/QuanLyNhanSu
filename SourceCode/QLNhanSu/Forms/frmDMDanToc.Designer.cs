namespace QLNhanSu.Forms
{
    partial class frmDMDanToc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMDanToc));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txttendantoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmadantoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_DMDanToc = new System.Windows.Forms.DataGridView();
            this.MaDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpbox = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DMDanToc)).BeginInit();
            this.grpbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.txttendantoc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtmadantoc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgv_DMDanToc);
            this.panel1.Location = new System.Drawing.Point(17, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 310);
            this.panel1.TabIndex = 13;
            // 
            // txttendantoc
            // 
            this.txttendantoc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txttendantoc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttendantoc.Location = new System.Drawing.Point(120, 49);
            this.txttendantoc.MaxLength = 50;
            this.txttendantoc.Name = "txttendantoc";
            this.txttendantoc.ReadOnly = true;
            this.txttendantoc.Size = new System.Drawing.Size(199, 26);
            this.txttendantoc.TabIndex = 13;
            this.txttendantoc.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tên Dân Tộc";
            // 
            // txtmadantoc
            // 
            this.txtmadantoc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtmadantoc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmadantoc.Location = new System.Drawing.Point(120, 14);
            this.txtmadantoc.MaxLength = 8;
            this.txtmadantoc.Name = "txtmadantoc";
            this.txtmadantoc.ReadOnly = true;
            this.txtmadantoc.Size = new System.Drawing.Size(121, 26);
            this.txtmadantoc.TabIndex = 11;
            this.txtmadantoc.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mã Dân Tộc";
            // 
            // dgv_DMDanToc
            // 
            this.dgv_DMDanToc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_DMDanToc.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_DMDanToc.ColumnHeadersHeight = 29;
            this.dgv_DMDanToc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDT,
            this.TenDT});
            this.dgv_DMDanToc.GridColor = System.Drawing.SystemColors.ControlText;
            this.dgv_DMDanToc.Location = new System.Drawing.Point(7, 81);
            this.dgv_DMDanToc.Name = "dgv_DMDanToc";
            this.dgv_DMDanToc.ReadOnly = true;
            this.dgv_DMDanToc.RowHeadersWidth = 51;
            this.dgv_DMDanToc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_DMDanToc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DMDanToc.Size = new System.Drawing.Size(381, 215);
            this.dgv_DMDanToc.TabIndex = 9;
            this.dgv_DMDanToc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DMDanToc_CellClick);
            // 
            // MaDT
            // 
            this.MaDT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaDT.DataPropertyName = "MaDT";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.MaDT.DefaultCellStyle = dataGridViewCellStyle1;
            this.MaDT.HeaderText = "Mã dân tộc";
            this.MaDT.MinimumWidth = 6;
            this.MaDT.Name = "MaDT";
            this.MaDT.ReadOnly = true;
            this.MaDT.Width = 86;
            // 
            // TenDT
            // 
            this.TenDT.DataPropertyName = "TenDT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.TenDT.DefaultCellStyle = dataGridViewCellStyle2;
            this.TenDT.HeaderText = "Tên dân tộc";
            this.TenDT.MinimumWidth = 6;
            this.TenDT.Name = "TenDT";
            this.TenDT.ReadOnly = true;
            this.TenDT.Width = 154;
            // 
            // grpbox
            // 
            this.grpbox.Controls.Add(this.btnLuu);
            this.grpbox.Controls.Add(this.btnThoat);
            this.grpbox.Controls.Add(this.btnThem);
            this.grpbox.Controls.Add(this.btnSua);
            this.grpbox.Controls.Add(this.btnXoa);
            this.grpbox.Location = new System.Drawing.Point(439, 12);
            this.grpbox.Name = "grpbox";
            this.grpbox.Size = new System.Drawing.Size(113, 310);
            this.grpbox.TabIndex = 14;
            this.grpbox.TabStop = false;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(23, 188);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(84, 38);
            this.btnLuu.TabIndex = 19;
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
            this.btnThoat.Location = new System.Drawing.Point(23, 246);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 38);
            this.btnThoat.TabIndex = 16;
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
            this.btnThem.Location = new System.Drawing.Point(22, 21);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(84, 38);
            this.btnThem.TabIndex = 18;
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
            this.btnSua.Location = new System.Drawing.Point(23, 76);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(84, 38);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(23, 130);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(84, 38);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmDMDanToc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(564, 334);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMDanToc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục Dân Tộc";
            this.Load += new System.EventHandler(this.frmDMDanToc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DMDanToc)).EndInit();
            this.grpbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txttendantoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmadantoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_DMDanToc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDT;
        private System.Windows.Forms.GroupBox grpbox;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
    }
}