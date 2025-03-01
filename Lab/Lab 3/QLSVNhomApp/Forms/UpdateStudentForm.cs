using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Dùng Microsoft.Data.SqlClient
using QLSVNhomApp.Data;

namespace QLSVNhomApp.Forms
{
    public partial class UpdateStudentForm : Form
    {
        private string connectionString;
        private string currentClassId; // Lớp hiện tại (được truyền từ ClassDetailForm)

        public UpdateStudentForm(string connStr, string classId)
        {
            connectionString = connStr;
            currentClassId = classId;
            InitializeComponent();
        }

        // Khi bấm nút "Tìm"
        private void btnFind_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string masv = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(masv))
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Vui lòng nhập mã sinh viên.";
                return;
            }

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_FIND_STUDENT_IN_CLASS", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MASV", masv);
                    cmd.Parameters.AddWithValue("@MALOP", currentClassId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtHoTen.Text = row["HOTEN"].ToString();
                DateTime dob;
                if (DateTime.TryParse(row["NGAYSINH"].ToString(), out dob))
                {
                    dtpNgaySinh.Value = dob;
                }
                txtDiaChi.Text = row["DIACHI"].ToString();
                txtMaLop.Text = row["MALOP"].ToString();
                lblError.Text = "";
            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Mã SV không tồn tại trong lớp";
            }
        }

        // Khi bấm nút "Hoàn tất"
        private void btnComplete_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string masv = txtMaSV.Text.Trim();
            string hoten = txtHoTen.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            DateTime ngaysinh = dtpNgaySinh.Value;
            string newClassId = txtMaLop.Text.Trim();

            // Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrEmpty(masv) || string.IsNullOrEmpty(hoten) ||
                string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(newClassId))
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Vui lòng điền đầy đủ thông tin.";
                return;
            }

            // Gọi stored procedure SP_UPDATE_STUDENT_INFO
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_STUDENT_INFO", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MASV", masv);
                        cmd.Parameters.AddWithValue("@HOTEN", hoten);
                        cmd.Parameters.AddWithValue("@NGAYSINH", ngaysinh);
                        cmd.Parameters.AddWithValue("@DIACHI", diachi);
                        cmd.Parameters.AddWithValue("@OLD_MALOP", currentClassId);
                        cmd.Parameters.AddWithValue("@NEW_MALOP", newClassId);

                        // Thêm output parameter để nhận thông báo lỗi
                        SqlParameter outParam = new SqlParameter("@ErrorMessage", System.Data.SqlDbType.NVarChar, 200)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outParam);

                        cmd.ExecuteNonQuery();
                        string errorMsg = outParam.Value.ToString();
                        if (!string.IsNullOrEmpty(errorMsg))
                        {
                            lblError.ForeColor = Color.Red;
                            lblError.Text = errorMsg;
                        }
                        else
                        {
                            lblError.ForeColor = Color.Green;
                            lblError.Text = "Cập nhật thành công.";
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

        // Khi bấm nút "Hủy"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
