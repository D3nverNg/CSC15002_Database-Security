using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QLSVNhomApp.Data;

namespace QLSVNhomApp.Forms
{
    public partial class ClassDetailForm : Form
    {
        private string connectionString;
        private string classId;
        private string loggedInEmployeeId; // Mã nhân viên đăng nhập
        private string classTeacherId; // Mã giáo viên chủ nhiệm lớp

        public ClassDetailForm(string connStr, string classId, string loggedInEmployeeId)
        {
            this.connectionString = connStr;
            this.classId = classId;
            this.loggedInEmployeeId = loggedInEmployeeId;
            InitializeComponent();
            lblTitle.Text = "Thông tin chi tiết lớp " + classId;

            GetClassTeacher();  // Lấy mã giáo viên chủ nhiệm của lớp
            LoadStudents();      // Load danh sách sinh viên
            CheckPermission();   // Kiểm tra quyền hiển thị nút
        }

        /// <summary>
        /// Lấy mã giáo viên chủ nhiệm của lớp từ database
        /// </summary>
        private void GetClassTeacher()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT MANV FROM LOP WHERE MALOP = @MALOP", conn))
                {
                    cmd.Parameters.AddWithValue("@MALOP", classId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        classTeacherId = result.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Kiểm tra quyền hiển thị các nút
        /// </summary>
        private void CheckPermission()
        {
            // Nếu mã nhân viên đăng nhập không phải là giáo viên chủ nhiệm của lớp, ẩn các nút chức năng
            if (loggedInEmployeeId != classTeacherId)
            {
                btnUpdateStudent.Visible = false;
                btnAddStudent.Visible = false;
                btnDeleteStudent.Visible = false;
                btnInputScore.Visible = false;
            }
        }

        /// <summary>
        /// Load toàn bộ danh sách sinh viên trong lớp
        /// </summary>
        private void LoadStudents()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GET_STUDENTS_BY_CLASS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MALOP", classId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            dgvStudents.DataSource = dt;
        }

        /// <summary>
        /// Tìm kiếm sinh viên theo MASV hoặc MALOP
        /// </summary>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchQuery))
            {
                LoadStudents();
                return;
            }

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_FIND_STUDENT_IN_CLASS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MALOP", classId);
                    cmd.Parameters.AddWithValue("@MASV", searchQuery);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            dgvStudents.DataSource = dt;

            // Kiểm tra nếu không có dữ liệu
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Khi người dùng bấm vào ô tìm kiếm, xóa placeholder
        /// </summary>
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm sinh viên theo mã hoặc tên")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Khi người dùng rời khỏi ô tìm kiếm mà không nhập gì, đặt lại placeholder
        /// </summary>
        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm sinh viên theo mã hoặc tên";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Mở form cập nhật thông tin sinh viên
        /// </summary>
        private void BtnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                //string studentId = dgvStudents.SelectedRows[0].Cells["MASV"].Value.ToString();
                UpdateStudentForm frm = new UpdateStudentForm(connectionString, classId);
                frm.ShowDialog();
                LoadStudents();
            }
        }

        /// <summary>
        /// Mở form thêm sinh viên vào lớp
        /// </summary>
        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudentForm frm = new AddStudentForm(connectionString, classId);
            frm.ShowDialog();
            LoadStudents();
        }

        /// <summary>
        /// Mở form xóa sinh viên khỏi lớp
        /// </summary>
        private void BtnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                //string studentId = dgvStudents.SelectedRows[0].Cells["MASV"].Value.ToString();
                DeleteStudentForm frm = new DeleteStudentForm(connectionString, classId);
                frm.ShowDialog();
                LoadStudents();
            }
        }

        /// <summary>
        /// Mở form nhập điểm cho sinh viên
        /// </summary>
        private void BtnInputScore_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                //string studentId = dgvStudents.SelectedRows[0].Cells["MASV"].Value.ToString();
                InputScoreForm frm = new InputScoreForm(connectionString, loggedInEmployeeId, classId);
                frm.ShowDialog();
                LoadStudents();
            }
        }
    }
}
