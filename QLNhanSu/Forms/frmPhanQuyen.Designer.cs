namespace QLNhanSu.Forms
{
    partial class frmPhanQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanQuyen));
            this.dgvPhanQuyen = new System.Windows.Forms.DataGridView();
            this.tenform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rights = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.cboNguoiDung = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhanQuyen
            // 
            this.dgvPhanQuyen.AllowUserToAddRows = false;
            this.dgvPhanQuyen.AllowUserToDeleteRows = false;
            this.dgvPhanQuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanQuyen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tenform,
            this.rights,
            this.id});
            this.dgvPhanQuyen.GridColor = System.Drawing.Color.DarkCyan;
            this.dgvPhanQuyen.Location = new System.Drawing.Point(1, 63);
            this.dgvPhanQuyen.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPhanQuyen.Name = "dgvPhanQuyen";
            this.dgvPhanQuyen.RowHeadersVisible = false;
            this.dgvPhanQuyen.RowHeadersWidth = 51;
            this.dgvPhanQuyen.Size = new System.Drawing.Size(496, 247);
            this.dgvPhanQuyen.TabIndex = 7;
            // 
            // tenform
            // 
            this.tenform.DataPropertyName = "tenform";
            this.tenform.HeaderText = "Đối tượng";
            this.tenform.MinimumWidth = 6;
            this.tenform.Name = "tenform";
            this.tenform.Width = 200;
            // 
            // rights
            // 
            this.rights.DataPropertyName = "rights";
            this.rights.HeaderText = "Truy Cập";
            this.rights.MinimumWidth = 6;
            this.rights.Name = "rights";
            this.rights.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rights.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.rights.Width = 125;
            // 
            // id
            // 
            this.id.DataPropertyName = "idform";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(334, 12);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(145, 28);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Lưu phân quyền";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // cboNguoiDung
            // 
            this.cboNguoiDung.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboNguoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguoiDung.FormattingEnabled = true;
            this.cboNguoiDung.Location = new System.Drawing.Point(130, 14);
            this.cboNguoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.cboNguoiDung.Name = "cboNguoiDung";
            this.cboNguoiDung.Size = new System.Drawing.Size(160, 24);
            this.cboNguoiDung.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Người dùng :";
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(499, 323);
            this.Controls.Add(this.dgvPhanQuyen);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboNguoiDung);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhanQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân Quyền";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhanQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenform;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rights;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboNguoiDung;
        private System.Windows.Forms.Label label1;
    }
}