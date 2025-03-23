using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QLSVNhomApp.Data;
using QLSVNhomApp.Forms;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Diagnostics;

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
            byte[] hashedPasswordBytes = HashPasswordSHA1(password);

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_LOGIN_NHANVIEN", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MANV", username);
                    SqlParameter mkParam = new SqlParameter("@MK", SqlDbType.VarBinary, 20);
                    mkParam.Value = hashedPasswordBytes;
                    cmd.Parameters.Add(mkParam);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() && reader["MANV"] != DBNull.Value)
                    {
                        string employeeId = reader["MANV"].ToString();
                        // Lưu thông tin đăng nhập (ví dụ: MANV và HOTEN)
                        ClassManagementForm.LoggedInEmployeeID = reader["MANV"].ToString();
                        ClassManagementForm.LoggedInUserName = reader["HOTEN"].ToString();

                        // Mở giao diện quản lý lớp học
                        ClassManagementForm cmf = new ClassManagementForm(DatabaseHelper.ConnectionString, employeeId, hashedPasswordBytes);
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
        private byte[] HashPasswordSHA1(string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void buttonAddEmploy_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addForm = new AddEmployeeForm();
            addForm.ShowDialog();
        }
    }
}
