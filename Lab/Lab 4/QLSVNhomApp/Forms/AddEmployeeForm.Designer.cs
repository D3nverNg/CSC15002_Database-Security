namespace QLSVNhomApp.Forms
{
    partial class AddEmployeeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblManv;
        private System.Windows.Forms.Label lblHoten;
        private System.Windows.Forms.Label lblTendn;
        private System.Windows.Forms.Label lblMatkhau;
        private System.Windows.Forms.Label lblLuongcb;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtManv;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtTendn;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.TextBox txtLuongcb;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblManv = new System.Windows.Forms.Label();
            this.lblHoten = new System.Windows.Forms.Label();
            this.lblTendn = new System.Windows.Forms.Label();
            this.lblMatkhau = new System.Windows.Forms.Label();
            this.lblLuongcb = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtManv = new System.Windows.Forms.TextBox();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtTendn = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.txtLuongcb = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // 
            // Labels and TextBoxes
            // 
            this.lblManv.Text = "Mã nhân viên:";
            this.lblManv.Location = new System.Drawing.Point(30, 20);
            this.txtManv.Location = new System.Drawing.Point(150, 20);
            this.txtManv.Width = 200;

            this.lblHoten.Text = "Họ tên:";
            this.lblHoten.Location = new System.Drawing.Point(30, 60);
            this.txtHoten.Location = new System.Drawing.Point(150, 60);
            this.txtHoten.Width = 200;

            this.lblTendn.Text = "Tên đăng nhập:";
            this.lblTendn.Location = new System.Drawing.Point(30, 100);
            this.txtTendn.Location = new System.Drawing.Point(150, 100);
            this.txtTendn.Width = 200;

            this.lblMatkhau.Text = "Mật khẩu:";
            this.lblMatkhau.Location = new System.Drawing.Point(30, 140);
            this.txtMatkhau.Location = new System.Drawing.Point(150, 140);
            this.txtMatkhau.Width = 200;
            this.txtMatkhau.PasswordChar = '*';

            this.lblLuongcb.Text = "Lương cơ bản:";
            this.lblLuongcb.Location = new System.Drawing.Point(30, 180);
            this.txtLuongcb.Location = new System.Drawing.Point(150, 180);
            this.txtLuongcb.Width = 200;

            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(30, 220);
            this.txtEmail.Location = new System.Drawing.Point(150, 220);
            this.txtEmail.Width = 200;

            // 
            // Buttons
            // 
            this.btnSave.Text = "Lưu";
            this.btnSave.Location = new System.Drawing.Point(80, 270);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Hủy";
            this.btnCancel.Location = new System.Drawing.Point(200, 270);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // AddEmployeeForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 330);
            this.Controls.Add(this.lblManv);
            this.Controls.Add(this.txtManv);
            this.Controls.Add(this.lblHoten);
            this.Controls.Add(this.txtHoten);
            this.Controls.Add(this.lblTendn);
            this.Controls.Add(this.txtTendn);
            this.Controls.Add(this.lblMatkhau);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.lblLuongcb);
            this.Controls.Add(this.txtLuongcb);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Text = "Thêm nhân viên";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
    }
}
