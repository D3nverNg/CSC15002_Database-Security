using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QLSVNhomApp.Data;

namespace QLSVNhomApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
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
                        // Lưu thông tin đăng nhập (ví dụ: MANV và HOTEN)
                        ClassManagementForm.LoggedInEmployeeID = reader["MANV"].ToString();
                        ClassManagementForm.LoggedInUserName = reader["HOTEN"].ToString();

                        // Mở giao diện quản lý lớp học
                        ClassManagementForm cmf = new ClassManagementForm(DatabaseHelper.ConnectionString);
                        this.Hide();
                        cmf.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập không thành công! Kiểm tra lại tài khoản hoặc mật khẩu.",
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
