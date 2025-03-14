namespace QLSVNhomApp.Forms
{
    partial class AddStudentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaSV;
        internal System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblHoTen;
        internal System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        internal System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblDiaChi;
        internal System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblTenDN;
        internal System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label lblMatKhau;
        internal System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label lblError;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblMaSV = new Label();
            txtMaSV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblTenDN = new Label();
            txtTenDN = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            btnComplete = new Button();
            btnCancel = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // lblMaSV
            // 
            lblMaSV.AutoSize = true;
            lblMaSV.Font = new Font("Segoe UI", 10F);
            lblMaSV.Location = new Point(30, 20);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(72, 28);
            lblMaSV.TabIndex = 0;
            lblMaSV.Text = "Mã SV:";
            // 
            // txtMaSV
            // 
            txtMaSV.Font = new Font("Segoe UI", 10F);
            txtMaSV.Location = new Point(140, 17);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.ReadOnly = true;
            txtMaSV.Size = new Size(407, 34);
            txtMaSV.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.Location = new Point(30, 60);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(75, 28);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.Location = new Point(140, 57);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(407, 34);
            txtHoTen.TabIndex = 3;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10F);
            lblNgaySinh.Location = new Point(30, 100);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(103, 28);
            lblNgaySinh.TabIndex = 4;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "MM/dd/yyyy";
            dtpNgaySinh.Font = new Font("Segoe UI", 10F);
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(140, 95);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(407, 34);
            dtpNgaySinh.TabIndex = 5;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(30, 140);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(75, 28);
            lblDiaChi.TabIndex = 6;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.Location = new Point(140, 134);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(407, 34);
            txtDiaChi.TabIndex = 7;
            // 
            // lblTenDN
            // 
            lblTenDN.AutoSize = true;
            lblTenDN.Font = new Font("Segoe UI", 10F);
            lblTenDN.Location = new Point(30, 180);
            lblTenDN.Name = "lblTenDN";
            lblTenDN.Size = new Size(79, 28);
            lblTenDN.TabIndex = 8;
            lblTenDN.Text = "Tên ĐN:";
            // 
            // txtTenDN
            // 
            txtTenDN.Font = new Font("Segoe UI", 10F);
            txtTenDN.Location = new Point(140, 177);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(407, 34);
            txtTenDN.TabIndex = 9;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 10F);
            lblMatKhau.Location = new Point(30, 220);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(98, 28);
            lblMatKhau.TabIndex = 10;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10F);
            txtMatKhau.Location = new Point(140, 217);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(407, 34);
            txtMatKhau.TabIndex = 11;
            // 
            // btnComplete
            // 
            btnComplete.Font = new Font("Segoe UI", 10F);
            btnComplete.Location = new Point(153, 275);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(100, 35);
            btnComplete.TabIndex = 12;
            btnComplete.Text = "Hoàn tất";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += btnComplete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(357, 275);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 10F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(30, 310);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 28);
            lblError.TabIndex = 14;
            // 
            // AddStudentForm
            // 
            ClientSize = new Size(593, 346);
            Controls.Add(lblMaSV);
            Controls.Add(txtMaSV);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblNgaySinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblDiaChi);
            Controls.Add(txtDiaChi);
            Controls.Add(lblTenDN);
            Controls.Add(txtTenDN);
            Controls.Add(lblMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(btnComplete);
            Controls.Add(btnCancel);
            Controls.Add(lblError);
            Name = "AddStudentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm mới sinh viên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
