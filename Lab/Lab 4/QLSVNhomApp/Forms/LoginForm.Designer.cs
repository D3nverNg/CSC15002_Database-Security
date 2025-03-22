namespace QLSVNhomApp.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // Các control của form
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGroupInfo;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.TextBox txtUsername;
        internal System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblGroupInfo = new Label();
            lblLogin = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            buttonAddEmploy = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(140, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(542, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chương trình quản lý sinh viên";
            // 
            // lblGroupInfo
            // 
            lblGroupInfo.AutoSize = true;
            lblGroupInfo.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblGroupInfo.Location = new Point(70, 60);
            lblGroupInfo.Name = "lblGroupInfo";
            lblGroupInfo.Size = new Size(657, 28);
            lblGroupInfo.TabIndex = 1;
            lblGroupInfo.Text = "Nhóm 5: Nguyễn Hồ Đăng Duy 22127085 + Phạm Quang Duy 22127088";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogin.Location = new Point(260, 97);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(161, 38);
            lblLogin.TabIndex = 2;
            lblLogin.Text = "Đăng nhập";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F);
            lblUsername.Location = new Point(80, 150);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(93, 32);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Mã NV:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(80, 200);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(120, 32);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(180, 145);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 39);
            txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(180, 195);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(300, 39);
            txtPassword.TabIndex = 6;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 12F);
            btnConfirm.Location = new Point(180, 250);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(120, 40);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.Location = new Point(360, 250);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // buttonAddEmploy
            // 
            buttonAddEmploy.Location = new Point(245, 325);
            buttonAddEmploy.Name = "buttonAddEmploy";
            buttonAddEmploy.Size = new Size(165, 34);
            buttonAddEmploy.TabIndex = 9;
            buttonAddEmploy.Text = "Thêm nhân viên";
            buttonAddEmploy.UseVisualStyleBackColor = true;
            buttonAddEmploy.Click += buttonAddEmploy_Click;
            // 
            // LoginForm
            // 
            ClientSize = new Size(618, 400);
            Controls.Add(buttonAddEmploy);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblLogin);
            Controls.Add(lblGroupInfo);
            Controls.Add(lblTitle);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - Quản lý Sinh Viên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddEmploy;
    }
}
