using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLSVNhomApp.Data;

namespace QLSVNhomApp.Forms
{
    public class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Đăng Nhập";
            this.Width = 300;
            this.Height = 200;

            Label lblUsername = new Label() { Text = "Tài khoản:", Left = 20, Top = 20, Width = 80 };
            Label lblPassword = new Label() { Text = "Mật khẩu:", Left = 20, Top = 60, Width = 80 };

            txtUsername = new TextBox() { Left = 110, Top = 20, Width = 150 };
            txtPassword = new TextBox() { Left = 110, Top = 60, Width = 150, PasswordChar = '*' };

            btnLogin = new Button() { Text = "Đăng nhập", Left = 110, Top = 100, Width = 100 };
            btnLogin.Click += btnLogin_Click;

            this.Controls.Add(lblUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtUsername);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEL_PUBLIC_NHANVIEN", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TENDN", username);
                    cmd.Parameters.AddWithValue("@MK", password);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Lưu thông tin nhân viên đã đăng nhập (sử dụng MANV làm Public Key)
                        MainForm.LoggedInEmployeeID = reader["MANV"].ToString();

                        // Mở MainForm và ẩn LoginForm
                        MainForm mainForm = new MainForm(DatabaseHelper.ConnectionString);
                        this.Hide();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập không thành công! Kiểm tra lại tài khoản hoặc mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
