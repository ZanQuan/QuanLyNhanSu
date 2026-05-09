using System;

namespace QLNhanSu.Forms
{
    partial class frmChonBCLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonBCLuong));
            this.cbothangbh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInBH = new System.Windows.Forms.Button();
            this.cboto = new System.Windows.Forms.ComboBox();
            this.cbophong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbonambc = new System.Windows.Forms.ComboBox();
            this.cbothangbc = new System.Windows.Forms.ComboBox();
            this.cbonambh = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabbcbh = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnIn = new System.Windows.Forms.Button();
            this.tabbcluong = new System.Windows.Forms.TabPage();
            this.tabbcchung = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.tabbcbh.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabbcluong.SuspendLayout();
            this.tabbcchung.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbothangbh
            // 
            this.cbothangbh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbothangbh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbothangbh.FormattingEnabled = true;
            this.cbothangbh.Location = new System.Drawing.Point(87, 32);
            this.cbothangbh.Margin = new System.Windows.Forms.Padding(4);
            this.cbothangbh.Name = "cbothangbh";
            this.cbothangbh.Size = new System.Drawing.Size(60, 24);
            this.cbothangbh.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Năm :";
            // 
            // btnInBH
            // 
            this.btnInBH.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInBH.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBH.Image = ((System.Drawing.Image)(resources.GetObject("btnInBH.Image")));
            this.btnInBH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInBH.Location = new System.Drawing.Point(105, 92);
            this.btnInBH.Margin = new System.Windows.Forms.Padding(4);
            this.btnInBH.Name = "btnInBH";
            this.btnInBH.Size = new System.Drawing.Size(124, 37);
            this.btnInBH.TabIndex = 8;
            this.btnInBH.Tag = "";
            this.btnInBH.Text = "In";
            this.btnInBH.UseVisualStyleBackColor = false;
            this.btnInBH.Click += new System.EventHandler(this.btnInBH_Click);
            // 
            // cboto
            // 
            this.cboto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboto.FormattingEnabled = true;
            this.cboto.Location = new System.Drawing.Point(89, 79);
            this.cboto.Margin = new System.Windows.Forms.Padding(4);
            this.cboto.Name = "cboto";
            this.cboto.Size = new System.Drawing.Size(209, 24);
            this.cboto.TabIndex = 36;
            // 
            // cbophong
            // 
            this.cbophong.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbophong.FormattingEnabled = true;
            this.cbophong.Location = new System.Drawing.Point(89, 44);
            this.cbophong.Margin = new System.Windows.Forms.Padding(4);
            this.cbophong.Name = "cbophong";
            this.cbophong.Size = new System.Drawing.Size(209, 24);
            this.cbophong.TabIndex = 35;
            this.cbophong.SelectedIndexChanged += new System.EventHandler(this.cbophong_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 19);
            this.label5.TabIndex = 34;
            this.label5.Text = "Tổ :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 19);
            this.label6.TabIndex = 33;
            this.label6.Text = "Phòng :";
            // 
            // cbonambc
            // 
            this.cbonambc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbonambc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbonambc.FormattingEnabled = true;
            this.cbonambc.Location = new System.Drawing.Point(224, 10);
            this.cbonambc.Margin = new System.Windows.Forms.Padding(4);
            this.cbonambc.Name = "cbonambc";
            this.cbonambc.Size = new System.Drawing.Size(75, 24);
            this.cbonambc.TabIndex = 32;
            // 
            // cbothangbc
            // 
            this.cbothangbc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbothangbc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbothangbc.FormattingEnabled = true;
            this.cbothangbc.Location = new System.Drawing.Point(89, 10);
            this.cbothangbc.Margin = new System.Windows.Forms.Padding(4);
            this.cbothangbc.Name = "cbothangbc";
            this.cbothangbc.Size = new System.Drawing.Size(57, 24);
            this.cbothangbc.TabIndex = 31;
            // 
            // cbonambh
            // 
            this.cbonambh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbonambh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbonambh.FormattingEnabled = true;
            this.cbonambh.Location = new System.Drawing.Point(223, 32);
            this.cbonambh.Margin = new System.Windows.Forms.Padding(4);
            this.cbonambh.Name = "cbonambh";
            this.cbonambh.Size = new System.Drawing.Size(75, 24);
            this.cbonambh.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.cbonambh);
            this.panel1.Controls.Add(this.cbothangbh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnInBH);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 160);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tháng :";
            // 
            // tabbcbh
            // 
            this.tabbcbh.Controls.Add(this.panel1);
            this.tabbcbh.Location = new System.Drawing.Point(4, 25);
            this.tabbcbh.Margin = new System.Windows.Forms.Padding(4);
            this.tabbcbh.Name = "tabbcbh";
            this.tabbcbh.Padding = new System.Windows.Forms.Padding(4);
            this.tabbcbh.Size = new System.Drawing.Size(331, 175);
            this.tabbcbh.TabIndex = 1;
            this.tabbcbh.Text = "Báo cáo Bảo hiểm";
            this.tabbcbh.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(164, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Năm :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 19);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tháng :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.cboto);
            this.panel2.Controls.Add(this.cbophong);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbonambc);
            this.panel2.Controls.Add(this.cbothangbc);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnIn);
            this.panel2.Location = new System.Drawing.Point(5, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 160);
            this.panel2.TabIndex = 5;
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(97, 113);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(124, 37);
            this.btnIn.TabIndex = 8;
            this.btnIn.Tag = "";
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // tabbcluong
            // 
            this.tabbcluong.Controls.Add(this.panel2);
            this.tabbcluong.Location = new System.Drawing.Point(4, 25);
            this.tabbcluong.Margin = new System.Windows.Forms.Padding(4);
            this.tabbcluong.Name = "tabbcluong";
            this.tabbcluong.Padding = new System.Windows.Forms.Padding(4);
            this.tabbcluong.Size = new System.Drawing.Size(331, 175);
            this.tabbcluong.TabIndex = 0;
            this.tabbcluong.Text = "Bảng lương";
            this.tabbcluong.UseVisualStyleBackColor = true;
            // 
            // tabbcchung
            // 
            this.tabbcchung.Controls.Add(this.tabbcluong);
            this.tabbcchung.Controls.Add(this.tabbcbh);
            this.tabbcchung.Location = new System.Drawing.Point(5, 8);
            this.tabbcchung.Margin = new System.Windows.Forms.Padding(4);
            this.tabbcchung.Name = "tabbcchung";
            this.tabbcchung.SelectedIndex = 0;
            this.tabbcchung.Size = new System.Drawing.Size(339, 204);
            this.tabbcchung.TabIndex = 2;
            // 
            // frmChonBCLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(348, 220);
            this.Controls.Add(this.tabbcchung);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonBCLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo lương tháng";
            this.Load += new System.EventHandler(this.frmChonBCLuong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabbcbh.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabbcluong.ResumeLayout(false);
            this.tabbcchung.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbothangbh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInBH;
        private System.Windows.Forms.ComboBox cboto;
        private System.Windows.Forms.ComboBox cbophong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbonambc;
        private System.Windows.Forms.ComboBox cbothangbc;
        private System.Windows.Forms.ComboBox cbonambh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabbcbh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.TabPage tabbcluong;
        private System.Windows.Forms.TabControl tabbcchung;
    }
}