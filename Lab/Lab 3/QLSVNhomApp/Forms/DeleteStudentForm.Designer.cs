namespace QLSVNhomApp.Forms
{
    partial class DeleteStudentForm
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
        private System.Windows.Forms.Button btnDelete;
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
            btnDelete = new Button();
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
            lblMaSV.Size = new Size(125, 28);
            lblMaSV.TabIndex = 0;
            lblMaSV.Text = "Mã sinh viên:";
            // 
            // txtMaSV
            // 
            txtMaSV.Font = new Font("Segoe UI", 10F);
            txtMaSV.Location = new Point(140, 17);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(316, 34);
            txtMaSV.TabIndex = 1;
            // 
            // btnFind
            // 
            btnFind.Font = new Font("Segoe UI", 10F);
            btnFind.Location = new Point(462, 16);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(74, 37);
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
            lblHoTen.Size = new Size(75, 28);
            lblHoTen.TabIndex = 3;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.Location = new Point(140, 57);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.ReadOnly = true;
            txtHoTen.Size = new Size(382, 34);
            txtHoTen.TabIndex = 4;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10F);
            lblNgaySinh.Location = new Point(30, 100);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(103, 28);
            lblNgaySinh.TabIndex = 5;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "MM/dd/yyyy";
            dtpNgaySinh.Font = new Font("Segoe UI", 10F);
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(140, 95);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(382, 34);
            dtpNgaySinh.TabIndex = 6;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(30, 140);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(75, 28);
            lblDiaChi.TabIndex = 7;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.Location = new Point(140, 137);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.ReadOnly = true;
            txtDiaChi.Size = new Size(382, 34);
            txtDiaChi.TabIndex = 8;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 10F);
            btnDelete.Location = new Point(91, 198);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(180, 35);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa sinh viên";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(314, 198);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 10F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(30, 230);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 28);
            lblError.TabIndex = 11;
            // 
            // DeleteStudentForm
            // 
            ClientSize = new Size(558, 269);
            Controls.Add(lblMaSV);
            Controls.Add(txtMaSV);
            Controls.Add(btnFind);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblNgaySinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblDiaChi);
            Controls.Add(txtDiaChi);
            Controls.Add(btnDelete);
            Controls.Add(btnCancel);
            Controls.Add(lblError);
            Name = "DeleteStudentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xóa sinh viên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
