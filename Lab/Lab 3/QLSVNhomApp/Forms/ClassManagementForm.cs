using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;   // Sử dụng Microsoft.Data.SqlClient
using QLSVNhomApp.Data;

namespace QLSVNhomApp.Forms
{
    public partial class ClassManagementForm : Form
    {
        // Thuộc tính tĩnh lưu thông tin đăng nhập
        public static string LoggedInEmployeeID { get; set; }
        public static string LoggedInUserName { get; set; }

        private string connectionString;

        public ClassManagementForm(string connStr)
        {
            connectionString = connStr;
            InitializeComponent();   // Gọi hàm trong file Designer
            LoadClasses();           // Tải danh sách lớp ban đầu
        }

        // Nút "Đăng xuất"
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        // Placeholder: xóa placeholder khi Enter
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm lớp học theo mã lớp hoặc tên lớp")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        // Placeholder: đặt lại placeholder khi Leave
        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm lớp học theo mã lớp hoặc tên lớp";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        // Nút "Tìm"
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            // Nếu vẫn là placeholder, coi như rỗng
            if (searchQuery == "Tìm kiếm lớp học theo mã lớp hoặc tên lớp")
            {
                searchQuery = "";
            }
            LoadClasses(searchQuery);
        }

        // Hàm tải danh sách lớp, gọi stored procedure
        private void LoadClasses(string searchQuery = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd;

                if (string.IsNullOrEmpty(searchQuery))
                {
                    // Gọi SP_GET_CLASSES_BY_EMPLOYEE (giả sử đã tạo trong SQL)
                    cmd = new SqlCommand("SP_GET_CLASSES_BY_EMPLOYEE", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@MANV", LoggedInEmployeeID);
                }
                else
                {
                    // Gọi SP_SEARCH_CLASSES_BY_EMPLOYEE
                    cmd = new SqlCommand("SP_SEARCH_CLASSES_BY_EMPLOYEE", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@MANV", LoggedInEmployeeID);
                    cmd.Parameters.AddWithValue("@TENLOP", searchQuery);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            // Gán DataSource
            dgvClasses.DataSource = dt;

            // Highlight các dòng chứa searchQuery (không phân biệt hoa thường)
            if (!string.IsNullOrEmpty(searchQuery))
            {
                foreach (DataGridViewRow row in dgvClasses.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null &&
                            cell.Value.ToString().IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                            break;
                        }
                    }
                }
            }
        }

        // Khi bấm vào cột "Chi tiết" (link "Xem")
        private void DgvClasses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClasses.Columns[e.ColumnIndex].Name == "colDetail")
            {
                // Lấy mã lớp từ cột colMaLop
                string classId = dgvClasses.Rows[e.RowIndex].Cells["colMaLop"].Value.ToString();
                // Mở ClassDetailForm
                ClassDetailForm detailForm = new ClassDetailForm(connectionString, classId);
                detailForm.ShowDialog();
            }
        }

        // Sự kiện RowPostPaint để vẽ STT
        private void DgvClasses_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            string rowIdx = (e.RowIndex + 1).ToString();
            using (var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                // Tìm cột colSTT
                int sttIndex = grid.Columns["colSTT"].Index;
                // Lấy vùng ô hiển thị
                Rectangle cellBounds = grid.GetCellDisplayRectangle(sttIndex, e.RowIndex, true);

                e.Graphics.DrawString(rowIdx,
                    this.Font,
                    SystemBrushes.ControlText,
                    cellBounds,
                    centerFormat);
            }
        }
    }
}
