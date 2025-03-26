using Microsoft.Data.SqlClient;
using QLSVNhomApp.Data;
using QLSVNhomApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVNhomApp.Forms
{
    public partial class AddEmployeeForm: Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text.Trim();
            string hoten = txtHoten.Text.Trim();
            string tendn = txtTendn.Text.Trim();
            string matkhau = txtMatkhau.Text.Trim();
            string luongcb = txtLuongcb.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(manv) || string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(tendn) ||
                string.IsNullOrEmpty(matkhau) || string.IsNullOrEmpty(luongcb) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] hashedPassword = EncryptionHelper.HashPasswordSHA1(matkhau);
            var (encryptedLuong, pubkeyXml, privateKeyXml) = EncryptionHelper.EncryptDataRSA(luongcb, hashedPassword, manv);
            EncryptionHelper.SavePrivateKeyToFile(manv, privateKeyXml);
            string newKey = EncryptionHelper.LoadPrivateKeyFromFile(manv);

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_INS_PUBLIC_ENCRYPT_NHANVIEN", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MANV", manv);
                    cmd.Parameters.AddWithValue("@HOTEN", hoten);
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@TENDN", tendn);
                    cmd.Parameters.AddWithValue("@PUBKEY", pubkeyXml);

                    // Password: VARBINARY
                    cmd.Parameters.Add("@MK", SqlDbType.VarBinary, 20).Value = hashedPassword;

                    // Lương: VARBINARY
                    cmd.Parameters.Add("@LUONGCB", SqlDbType.VarBinary, -1).Value = encryptedLuong;

                    SqlParameter outError = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 200)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outError);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    string error = outError.Value.ToString();
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Lỗi thêm nhân viên: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form nếu thành công
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
