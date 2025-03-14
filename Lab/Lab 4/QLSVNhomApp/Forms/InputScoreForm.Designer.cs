namespace QLSVNhomApp.Forms
{
    partial class InputScoreForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Label lblMaHP;
        private System.Windows.Forms.Label lblDiem;
        internal System.Windows.Forms.TextBox txtMaSV;
        internal System.Windows.Forms.TextBox txtMaHP;
        internal System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label lblMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaSV = new Label();
            txtMaSV = new TextBox();
            lblMaHP = new Label();
            txtMaHP = new TextBox();
            lblDiem = new Label();
            txtDiem = new TextBox();
            btnSubmit = new Button();
            btnCancel = new Button();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // lblMaSV
            // 
            lblMaSV.AutoSize = true;
            lblMaSV.Font = new Font("Segoe UI", 10F);
            lblMaSV.Location = new Point(30, 60);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(125, 28);
            lblMaSV.TabIndex = 0;
            lblMaSV.Text = "Mã sinh viên:";
            // 
            // txtMaSV
            // 
            txtMaSV.Font = new Font("Segoe UI", 10F);
            txtMaSV.Location = new Point(166, 60);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(318, 34);
            txtMaSV.TabIndex = 1;
            // 
            // lblMaHP
            // 
            lblMaHP.AutoSize = true;
            lblMaHP.Font = new Font("Segoe UI", 10F);
            lblMaHP.Location = new Point(30, 113);
            lblMaHP.Name = "lblMaHP";
            lblMaHP.Size = new Size(130, 28);
            lblMaHP.TabIndex = 2;
            lblMaHP.Text = "Mã học phần:";
            // 
            // txtMaHP
            // 
            txtMaHP.Font = new Font("Segoe UI", 10F);
            txtMaHP.Location = new Point(166, 113);
            txtMaHP.Name = "txtMaHP";
            txtMaHP.Size = new Size(318, 34);
            txtMaHP.TabIndex = 3;
            // 
            // lblDiem
            // 
            lblDiem.AutoSize = true;
            lblDiem.Font = new Font("Segoe UI", 10F);
            lblDiem.Location = new Point(30, 162);
            lblDiem.Name = "lblDiem";
            lblDiem.Size = new Size(62, 28);
            lblDiem.TabIndex = 4;
            lblDiem.Text = "Điểm:";
            // 
            // txtDiem
            // 
            txtDiem.Font = new Font("Segoe UI", 10F);
            txtDiem.Location = new Point(166, 162);
            txtDiem.Name = "txtDiem";
            txtDiem.Size = new Size(318, 34);
            txtDiem.TabIndex = 5;
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Segoe UI", 10F);
            btnSubmit.Location = new Point(104, 262);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(140, 48);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Hoàn tất";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(313, 262);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 48);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 10F);
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(30, 200);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 28);
            lblMessage.TabIndex = 8;
            // 
            // InputScoreForm
            // 
            ClientSize = new Size(561, 363);
            Controls.Add(lblMaSV);
            Controls.Add(txtMaSV);
            Controls.Add(lblMaHP);
            Controls.Add(txtMaHP);
            Controls.Add(lblDiem);
            Controls.Add(txtDiem);
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
            Controls.Add(lblMessage);
            Name = "InputScoreForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhập điểm";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
