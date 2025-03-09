using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // Sử dụng Microsoft.Data.SqlClient
using QLSVNhomApp.Data;

namespace QLSVNhomApp.Forms
{
    public partial class ClassDetailForm : Form
    {
        private string connectionString;
        private string classId;

        public ClassDetailForm(string connStr, string classId)
        {
            this.connectionString = connStr;
            this.classId = classId;
            InitializeComponent(); // Gọi hàm InitializeComponent() từ file Designer
            lblTitle.Text = "Thông tin chi tiết lớp " + classId;
            LoadStudents();
        }

        // Hàm tải danh sách sinh viên sử dụng stored procedure SP_GET_STUDENTS_BY_CLASS
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

        // Vẽ số thứ tự (STT) cho mỗi dòng trong DataGridView
        private void DgvStudents_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            string rowIndex = (e.RowIndex + 1).ToString();
            using (var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                int sttIndex = grid.Columns["colSTT"].Index;
                Rectangle cellBounds = grid.GetCellDisplayRectangle(sttIndex, e.RowIndex, true);
                e.Graphics.DrawString(rowIndex, this.Font, SystemBrushes.ControlText, cellBounds, centerFormat);
            }
        }

        // Nút "Thay đổi thông tin sinh viên"
        private void BtnUpdateStudent_Click(object sender, EventArgs e)
        {
            // Mở form cập nhật thông tin sinh viên dưới dạng modal (chặn thao tác với ClassDetailForm)
            UpdateStudentForm frm = new UpdateStudentForm(connectionString, classId);
            frm.ShowDialog();
        }

        // Nút "Thêm mới sinh viên"
        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudentForm frm = new AddStudentForm(connectionString);
            frm.ShowDialog();
        }

        // Nút "Xóa sinh viên"
        private void BtnDeleteStudent_Click(object sender, EventArgs e)
        {
            DeleteStudentForm frm = new DeleteStudentForm(connectionString, classId);
            frm.ShowDialog();
        }

        // Nút "Nhập điểm"
        //private void BtnInputScore_Click(object sender, EventArgs e)
        //{
        //    InputScoreForm frm = new InputScoreForm(connectionString, classId);
        //    frm.ShowDialog();
        //}
    }
}
