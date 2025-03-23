using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using QLSVNhomApp.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using QLSVNhomApp.Utils;

namespace QLSVNhomApp.Forms
{
    public partial class ProfileForm : Form
    {
        private string manv;
        private string connectionString;
        private string tendn;
        private byte[] HashedPassword;
        private byte[] encryptedLuong;

        public ProfileForm(string connStr, string tendn, byte[] hashedPassword, string manv)
        {
            InitializeComponent();
            this.connectionString = connStr;
            this.tendn = tendn;
            this.HashedPassword = hashedPassword;
            LoadProfile();
            this.manv = manv;
        }

        private void LoadProfile()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_SEL_PUBLIC_ENCRYPT_NHANVIEN", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TENDN", tendn);
                cmd.Parameters.Add("@MK", SqlDbType.VarBinary, 20).Value = HashedPassword;

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
                        this.encryptedLuong = encryptedLuong;

                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDecr_Click(object sender, EventArgs e)
        {
            if (encryptedLuong == null)
            {
                MessageBox.Show("Không có dữ liệu lương để giải mã.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //EncryptionHelper.PrintAllPrivateKeys();
            string newKey = EncryptionHelper.LoadPrivateKeyFromFile(manv);
            //Debug.WriteLine(newKey);
            string decryptedLuong = EncryptionHelper.DecryptDataRSA(encryptedLuong, newKey);

            Debug.WriteLine(decryptedLuong);

            if (!string.IsNullOrEmpty(decryptedLuong))
            {
                lblLuong.Text = "Lương (giải mã): " + decryptedLuong;
            }
        }

    }
}
