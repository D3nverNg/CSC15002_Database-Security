using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Sử dụng Microsoft.Data.SqlClient
using QLSVNhomApp.Data;

namespace QLSVNhomApp.Forms
{
    public partial class DeleteStudentForm : Form
    {
        private string connectionString;
        private string currentClassId; // Lớp hiện tại được truyền từ form cha

        public DeleteStudentForm(string connStr, string classId)
        {
            connectionString = connStr;
            currentClassId = classId;
            InitializeComponent();
        }

        // Khi nhấn nút "Tìm"
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
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_FIND_STUDENT_IN_CLASS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
                    else
                    {
                        dtpNgaySinh.Value = DateTime.Now;
                    }
                    txtDiaChi.Text = row["DIACHI"].ToString();
                    lblError.Text = "";
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Mã SV không tồn tại trong lớp";
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    dtpNgaySinh.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Lỗi: " + ex.Message;
            }
        }

        // Khi nhấn nút "Xóa sinh viên"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string masv = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(masv))
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Vui lòng nhập mã sinh viên.";
                return;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Không tìm thấy thông tin sinh viên. Vui lòng kiểm tra lại.";
                return;
            }

            // Yêu cầu xác nhận xóa
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SP_DELETE_STUDENT", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MASV", masv);
                            cmd.Parameters.AddWithValue("@MALOP", currentClassId);
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
                                lblError.Text = "Xóa sinh viên thành công.";
                                // Optionally, clear các ô thông tin
                                txtMaSV.Text = "";
                                txtHoTen.Text = "";
                                txtDiaChi.Text = "";
                                dtpNgaySinh.Value = DateTime.Now;
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
        }

        // Khi nhấn nút "Hủy"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
