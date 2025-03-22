namespace QLSVNhomApp.Forms
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblManv;
        private System.Windows.Forms.Label lblHoten;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblManv = new Label();
            lblHoten = new Label();
            lblEmail = new Label();
            lblLuong = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(152, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thông tin nhân viên";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblManv
            // 
            lblManv.AutoSize = true;
            lblManv.Location = new Point(30, 70);
            lblManv.Name = "lblManv";
            lblManv.Size = new Size(122, 25);
            lblManv.TabIndex = 1;
            lblManv.Text = "Mã nhân viên:";
            // 
            // lblHoten
            // 
            lblHoten.AutoSize = true;
            lblHoten.Location = new Point(30, 110);
            lblHoten.Name = "lblHoten";
            lblHoten.Size = new Size(70, 25);
            lblHoten.TabIndex = 2;
            lblHoten.Text = "Họ tên:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 150);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // lblLuong
            // 
            lblLuong.AutoSize = true;
            lblLuong.Location = new Point(30, 190);
            lblLuong.MaximumSize = new Size(400, 0);
            lblLuong.Name = "lblLuong";
            lblLuong.Size = new Size(142, 25);
            lblLuong.TabIndex = 4;
            lblLuong.Text = "Lương (mã hóa):";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(455, 352);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 45);
            btnClose.TabIndex = 5;
            btnClose.Text = "Đóng";
            btnClose.Click += btnClose_Click;
            // 
            // ProfileForm
            // 
            ClientSize = new Size(557, 409);
            Controls.Add(lblTitle);
            Controls.Add(lblManv);
            Controls.Add(lblHoten);
            Controls.Add(lblEmail);
            Controls.Add(lblLuong);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ProfileForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin nhân viên";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

