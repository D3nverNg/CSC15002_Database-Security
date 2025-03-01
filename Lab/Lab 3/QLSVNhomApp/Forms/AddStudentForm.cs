using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // Sử dụng Microsoft.Data.SqlClient
using QLSVNhomApp.Data;

namespace QLSVNhomApp.Forms
{
    public partial class AddStudentForm : Form
    {
        private string connectionString;

        public AddStudentForm(string connStr)
        {
            connectionString = connStr;
            InitializeComponent();
            GenerateStudentID();
        }

        // Gọi SP_GENERATE_NEW_STUDENT_ID để hiển thị mã sinh viên mới
        private void GenerateStudentID()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GENERATE_NEW_STUDENT_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            txtMaSV.Text = result.ToString();
                        }
                        else
                        {
                            txtMaSV.Text = "S001"; // Mặc định
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Lỗi tạo mã sinh viên: " + ex.Message;
            }
        }

        // Nút "Hoàn tất": kiểm tra dữ liệu và gọi SP_INSERT_STUDENT
        private void btnComplete_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            // Lấy dữ liệu từ các ô
            string masv = txtMaSV.Text.Trim(); // Đã được tự động tạo
            string hoten = txtHoTen.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string tendn = txtTenDN.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();
            DateTime ngaysinh = dtpNgaySinh.Value;

            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(diachi) ||
                string.IsNullOrEmpty(tendn) || string.IsNullOrEmpty(matkhau))
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Vui lòng điền đầy đủ các thông tin bắt buộc.";
                return;
            }

            // (Nếu cần kiểm tra định dạng của các trường khác, thêm ở đây)

            // Gọi stored procedure SP_INSERT_STUDENT
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_STUDENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@HOTEN", hoten);
                        cmd.Parameters.AddWithValue("@NGAYSINH", ngaysinh);
                        cmd.Parameters.AddWithValue("@DIACHI", diachi);
                        cmd.Parameters.AddWithValue("@TENDN", tendn);
                        cmd.Parameters.AddWithValue("@MATKHAU", matkhau);

                        // Output parameters: mã sinh viên và thông báo lỗi
                        SqlParameter outMasv = new SqlParameter("@MASV", System.Data.SqlDbType.NVarChar, 20)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outMasv);

                        SqlParameter outError = new SqlParameter("@ErrorMessage", System.Data.SqlDbType.NVarChar, 200)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outError);

                        cmd.ExecuteNonQuery();

                        string errorMsg = outError.Value.ToString();
                        if (!string.IsNullOrEmpty(errorMsg))
                        {
                            lblError.ForeColor = Color.Red;
                            lblError.Text = errorMsg;
                        }
                        else
                        {
                            // Thành công: có thể hiển thị thông báo và/hoặc đóng form
                            lblError.ForeColor = Color.Green;
                            lblError.Text = "Thêm sinh viên thành công. Mã SV: " + outMasv.Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Lỗi: " + ex.Message;
            }
        }

        // Nút "Hủy": đóng form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
