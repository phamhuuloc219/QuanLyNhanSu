namespace Nhom3_QuanLyNhanSu
{
    partial class FrmCMND
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoiCap = new System.Windows.Forms.TextBox();
            this.dtNgayCap = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblIconCMND = new System.Windows.Forms.Label();
            this.lblIconNgayCap = new System.Windows.Forms.Label();
            this.lblIconNoiCap = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CMND:";
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(98, 20);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(149, 20);
            this.txtCMND.TabIndex = 1;
            this.txtCMND.Leave += new System.EventHandler(this.txtCMND_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngày Cấp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nơi Cấp:";
            // 
            // txtNoiCap
            // 
            this.txtNoiCap.Location = new System.Drawing.Point(98, 95);
            this.txtNoiCap.Name = "txtNoiCap";
            this.txtNoiCap.Size = new System.Drawing.Size(149, 20);
            this.txtNoiCap.TabIndex = 7;
            this.txtNoiCap.Leave += new System.EventHandler(this.txtNoiCap_Leave);
            // 
            // dtNgayCap
            // 
            this.dtNgayCap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayCap.Location = new System.Drawing.Point(98, 57);
            this.dtNgayCap.Name = "dtNgayCap";
            this.dtNgayCap.Size = new System.Drawing.Size(149, 20);
            this.dtNgayCap.TabIndex = 4;
            this.dtNgayCap.ValueChanged += new System.EventHandler(this.dtNgayCap_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(201, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Đóng";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblIconCMND
            // 
            this.lblIconCMND.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.yes;
            this.lblIconCMND.Location = new System.Drawing.Point(253, 24);
            this.lblIconCMND.Name = "lblIconCMND";
            this.lblIconCMND.Size = new System.Drawing.Size(19, 13);
            this.lblIconCMND.TabIndex = 2;
            this.lblIconCMND.Visible = false;
            // 
            // lblIconNgayCap
            // 
            this.lblIconNgayCap.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.yes;
            this.lblIconNgayCap.Location = new System.Drawing.Point(253, 61);
            this.lblIconNgayCap.Name = "lblIconNgayCap";
            this.lblIconNgayCap.Size = new System.Drawing.Size(19, 13);
            this.lblIconNgayCap.TabIndex = 5;
            this.lblIconNgayCap.Visible = false;
            // 
            // lblIconNoiCap
            // 
            this.lblIconNoiCap.Image = global::Nhom3_QuanLyNhanSu.Properties.Resources.yes;
            this.lblIconNoiCap.Location = new System.Drawing.Point(253, 99);
            this.lblIconNoiCap.Name = "lblIconNoiCap";
            this.lblIconNoiCap.Size = new System.Drawing.Size(19, 13);
            this.lblIconNoiCap.TabIndex = 8;
            this.lblIconNoiCap.Visible = false;
            // 
            // FrmCMND
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(284, 156);
            this.Controls.Add(this.lblIconNoiCap);
            this.Controls.Add(this.lblIconNgayCap);
            this.Controls.Add(this.lblIconCMND);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtNgayCap);
            this.Controls.Add(this.txtNoiCap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCMND";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMND";
            this.Load += new System.EventHandler(this.FrmCMND_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoiCap;
        private System.Windows.Forms.DateTimePicker dtNgayCap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblIconCMND;
        private System.Windows.Forms.Label lblIconNgayCap;
        private System.Windows.Forms.Label lblIconNoiCap;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}