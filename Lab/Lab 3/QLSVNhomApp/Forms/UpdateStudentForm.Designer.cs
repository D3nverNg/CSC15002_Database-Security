namespace QLSVNhomApp.Forms
{
    partial class UpdateStudentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaSV;
        internal System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblHoTen;
        internal System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        internal System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblDiaChi;
        internal System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblMaLop;
        internal System.Windows.Forms.TextBox txtMaLop;
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
            btnFind = new Button();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblMaLop = new Label();
            txtMaLop = new TextBox();
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
            lblMaSV.Size = new Size(63, 23);
            lblMaSV.TabIndex = 0;
            lblMaSV.Text = "Mã SV:";
            // 
            // txtMaSV
            // 
            txtMaSV.Font = new Font("Segoe UI", 10F);
            txtMaSV.Location = new Point(130, 17);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(150, 30);
            txtMaSV.TabIndex = 1;
            // 
            // btnFind
            // 
            btnFind.Font = new Font("Segoe UI", 10F);
            btnFind.Location = new Point(290, 15);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(60, 30);
            btnFind.TabIndex = 2;
            btnFind.Text = "Tìm";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.Location = new Point(30, 60);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(66, 23);
            lblHoTen.TabIndex = 3;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.Location = new Point(130, 57);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(220, 30);
            txtHoTen.TabIndex = 4;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10F);
            lblNgaySinh.Location = new Point(30, 100);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(90, 23);
            lblNgaySinh.TabIndex = 5;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "MM/dd/yyyy";
            dtpNgaySinh.Font = new Font("Segoe UI", 10F);
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(130, 95);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(134, 30);
            dtpNgaySinh.TabIndex = 6;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(30, 140);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(66, 23);
            lblDiaChi.TabIndex = 7;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.Location = new Point(130, 137);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(220, 30);
            txtDiaChi.TabIndex = 8;
            // 
            // lblMaLop
            // 
            lblMaLop.AutoSize = true;
            lblMaLop.Font = new Font("Segoe UI", 10F);
            lblMaLop.Location = new Point(30, 180);
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Size = new Size(67, 23);
            lblMaLop.TabIndex = 9;
            lblMaLop.Text = "Mã lớp:";
            // 
            // txtMaLop
            // 
            txtMaLop.Font = new Font("Segoe UI", 10F);
            txtMaLop.Location = new Point(130, 177);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(150, 30);
            txtMaLop.TabIndex = 10;
            // 
            // btnComplete
            // 
            btnComplete.Font = new Font("Segoe UI", 10F);
            btnComplete.Location = new Point(130, 220);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(100, 35);
            btnComplete.TabIndex = 11;
            btnComplete.Text = "Hoàn tất";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += btnComplete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(250, 220);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 10F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(30, 270);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 23);
            lblError.TabIndex = 13;
            // 
            // UpdateStudentForm
            // 
            ClientSize = new Size(400, 300);
            Controls.Add(lblMaSV);
            Controls.Add(txtMaSV);
            Controls.Add(btnFind);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblNgaySinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblDiaChi);
            Controls.Add(txtDiaChi);
            Controls.Add(lblMaLop);
            Controls.Add(txtMaLop);
            Controls.Add(btnComplete);
            Controls.Add(btnCancel);
            Controls.Add(lblError);
            Name = "UpdateStudentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thay đổi thông tin sinh viên";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
