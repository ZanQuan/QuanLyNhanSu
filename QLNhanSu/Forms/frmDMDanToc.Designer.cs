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
            this.cmdluu = new System.Windows.Forms.Button();
            this.cmdthoat = new System.Windows.Forms.Button();
            this.cmdthem = new System.Windows.Forms.Button();
            this.cmdCapnhat = new System.Windows.Forms.Button();
            this.cmdxoa = new System.Windows.Forms.Button();
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
            this.panel1.Location = new System.Drawing.Point(25, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 237);
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
            this.dgv_DMDanToc.Location = new System.Drawing.Point(9, 93);
            this.dgv_DMDanToc.Name = "dgv_DMDanToc";
            this.dgv_DMDanToc.ReadOnly = true;
            this.dgv_DMDanToc.RowHeadersWidth = 51;
            this.dgv_DMDanToc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_DMDanToc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DMDanToc.Size = new System.Drawing.Size(310, 130);
            this.dgv_DMDanToc.TabIndex = 9;
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
            this.grpbox.Controls.Add(this.cmdluu);
            this.grpbox.Controls.Add(this.cmdthoat);
            this.grpbox.Controls.Add(this.cmdthem);
            this.grpbox.Controls.Add(this.cmdCapnhat);
            this.grpbox.Controls.Add(this.cmdxoa);
            this.grpbox.Location = new System.Drawing.Point(359, 13);
            this.grpbox.Name = "grpbox";
            this.grpbox.Size = new System.Drawing.Size(87, 237);
            this.grpbox.TabIndex = 14;
            this.grpbox.TabStop = false;
            // 
            // cmdluu
            // 
            this.cmdluu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdluu.Image = ((System.Drawing.Image)(resources.GetObject("cmdluu.Image")));
            this.cmdluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdluu.Location = new System.Drawing.Point(8, 147);
            this.cmdluu.Name = "cmdluu";
            this.cmdluu.Size = new System.Drawing.Size(73, 30);
            this.cmdluu.TabIndex = 19;
            this.cmdluu.Text = "Lưu";
            this.cmdluu.UseVisualStyleBackColor = true;
            // 
            // cmdthoat
            // 
            this.cmdthoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdthoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdthoat.Image")));
            this.cmdthoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdthoat.Location = new System.Drawing.Point(8, 191);
            this.cmdthoat.Name = "cmdthoat";
            this.cmdthoat.Size = new System.Drawing.Size(73, 30);
            this.cmdthoat.TabIndex = 16;
            this.cmdthoat.Text = "Thoát";
            this.cmdthoat.UseVisualStyleBackColor = true;
            // 
            // cmdthem
            // 
            this.cmdthem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdthem.Image = ((System.Drawing.Image)(resources.GetObject("cmdthem.Image")));
            this.cmdthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdthem.Location = new System.Drawing.Point(7, 15);
            this.cmdthem.Name = "cmdthem";
            this.cmdthem.Size = new System.Drawing.Size(73, 30);
            this.cmdthem.TabIndex = 18;
            this.cmdthem.Text = "Thêm";
            this.cmdthem.UseVisualStyleBackColor = true;
            // 
            // cmdCapnhat
            // 
            this.cmdCapnhat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCapnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCapnhat.Image = ((System.Drawing.Image)(resources.GetObject("cmdCapnhat.Image")));
            this.cmdCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCapnhat.Location = new System.Drawing.Point(8, 59);
            this.cmdCapnhat.Name = "cmdCapnhat";
            this.cmdCapnhat.Size = new System.Drawing.Size(73, 30);
            this.cmdCapnhat.TabIndex = 15;
            this.cmdCapnhat.Text = "sửa";
            this.cmdCapnhat.UseVisualStyleBackColor = true;
            // 
            // cmdxoa
            // 
            this.cmdxoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdxoa.Image = ((System.Drawing.Image)(resources.GetObject("cmdxoa.Image")));
            this.cmdxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdxoa.Location = new System.Drawing.Point(8, 103);
            this.cmdxoa.Name = "cmdxoa";
            this.cmdxoa.Size = new System.Drawing.Size(73, 30);
            this.cmdxoa.TabIndex = 17;
            this.cmdxoa.Text = "Xóa";
            this.cmdxoa.UseVisualStyleBackColor = true;
            // 
            // frmDMDanToc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(458, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMDanToc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục Dân Tộc";
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
        private System.Windows.Forms.Button cmdluu;
        private System.Windows.Forms.Button cmdthoat;
        private System.Windows.Forms.Button cmdthem;
        private System.Windows.Forms.Button cmdCapnhat;
        private System.Windows.Forms.Button cmdxoa;
    }
}