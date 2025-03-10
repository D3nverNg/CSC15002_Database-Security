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
            lblMaSV = new System.Windows.Forms.Label();
            txtMaSV = new System.Windows.Forms.TextBox();
            lblMaHP = new System.Windows.Forms.Label();
            txtMaHP = new System.Windows.Forms.TextBox();
            lblDiem = new System.Windows.Forms.Label();
            txtDiem = new System.Windows.Forms.TextBox();
            btnSubmit = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            lblMessage = new System.Windows.Forms.Label();

            SuspendLayout();

            // Label "Mã SV"
            lblMaSV.AutoSize = true;
            lblMaSV.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblMaSV.Location = new System.Drawing.Point(30, 20);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new System.Drawing.Size(90, 23);
            lblMaSV.Text = "Mã sinh viên:";

            // TextBox "Mã SV"
            txtMaSV.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtMaSV.Location = new System.Drawing.Point(140, 17);
            txtMaSV.Size = new System.Drawing.Size(200, 30);

            // Label "Mã HP"
            lblMaHP.AutoSize = true;
            lblMaHP.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblMaHP.Location = new System.Drawing.Point(30, 60);
            lblMaHP.Name = "lblMaHP";
            lblMaHP.Size = new System.Drawing.Size(100, 23);
            lblMaHP.Text = "Mã học phần:";

            // TextBox "Mã HP"
            txtMaHP.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtMaHP.Location = new System.Drawing.Point(140, 57);
            txtMaHP.Size = new System.Drawing.Size(200, 30);

            // Label "Điểm"
            lblDiem.AutoSize = true;
            lblDiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblDiem.Location = new System.Drawing.Point(30, 100);
            lblDiem.Size = new System.Drawing.Size(55, 23);
            lblDiem.Text = "Điểm:";

            // TextBox "Điểm"
            txtDiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtDiem.Location = new System.Drawing.Point(140, 97);
            txtDiem.Size = new System.Drawing.Size(200, 30);

            // Button "Hoàn tất"
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnSubmit.Location = new System.Drawing.Point(140, 150);
            btnSubmit.Size = new System.Drawing.Size(100, 35);
            btnSubmit.Text = "Hoàn tất";
            btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // Button "Hủy"
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnCancel.Location = new System.Drawing.Point(260, 150);
            btnCancel.Size = new System.Drawing.Size(100, 35);
            btnCancel.Text = "Hủy";
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Label Message
            lblMessage.AutoSize = true;
            lblMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Location = new System.Drawing.Point(30, 200);
            lblMessage.Size = new System.Drawing.Size(0, 23);

            // Form
            ClientSize = new System.Drawing.Size(400, 250);
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
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Nhập điểm";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
