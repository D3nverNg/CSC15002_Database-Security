using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using QLSVNhomApp.Data;
using Microsoft.Data.SqlClient;

namespace QLSVNhomApp.Forms
{
    public partial class ProfileForm : Form
    {
        private string connectionString;
        private string tendn;
        private string rawPassword;

        public ProfileForm(string connStr, string tendn, string password)
        {
            InitializeComponent();
            this.connectionString = connStr;
            this.tendn = tendn;
            this.rawPassword = password;
            LoadProfile();
        }

        private void LoadProfile()
        {
            byte[] hashedPassword = HashPasswordSHA1(rawPassword);

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_SEL_PUBLIC_ENCRYPT_NHANVIEN", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TENDN", tendn);
                cmd.Parameters.Add("@MK", SqlDbType.VarBinary, 20).Value = hashedPassword;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblManv.Text = "Mã nhân viên: " + reader["MANV"].ToString();
                        lblHoten.Text = "Họ tên: " + reader["HOTEN"].ToString();
                        lblEmail.Text = "Email: " + reader["EMAIL"].ToString();
                        byte[] encryptedLuong = (byte[])reader["LUONG"];
                        string hexString = "0x" + BitConverter.ToString(encryptedLuong).Replace("-", "");
                        lblLuong.Text = "Lương (mã hóa): " + hexString;

                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
