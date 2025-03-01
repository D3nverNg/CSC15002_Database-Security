using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLSVNhomApp.Data;

namespace QLSVNhomApp.Forms
{
    public class MainForm : Form
    {
        public static string LoggedInEmployeeID { get; set; }
        private string connectionString;

        private TabControl tabControl;
        private TabPage tabClasses;
        private TabPage tabGrades;

        // Các control của tab Quản lý Lớp & Sinh viên
        private DataGridView dgvClasses;
        private DataGridView dgvStudents;

        // Các control của tab Nhập Điểm
        private TextBox txtMaSV, txtMaHP, txtGrade;
        private Button btnSaveGrade;

        public MainForm(string connStr)
        {
            connectionString = connStr;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Quản Lý Sinh Viên";
            this.Width = 800;
            this.Height = 600;

            // Tạo TabControl và các Tab
            tabControl = new TabControl() { Dock = DockStyle.Fill };

            tabClasses = new TabPage("Quản lý Lớp & Sinh viên");
            tabGrades = new TabPage("Nhập Điểm");

            // Tab Quản lý Lớp & Sinh viên
            dgvClasses = new DataGridView() { Left = 10, Top = 10, Width = 350, Height = 200 };
            dgvClasses.SelectionChanged += DgvClasses_SelectionChanged;
            dgvStudents = new DataGridView() { Left = 10, Top = 220, Width = 350, Height = 200 };

            tabClasses.Controls.Add(dgvClasses);
            tabClasses.Controls.Add(dgvStudents);

            // Tab Nhập Điểm
            Label lblMaSV = new Label() { Text = "Mã SV:", Left = 10, Top = 10, Width = 60 };
            txtMaSV = new TextBox() { Left = 80, Top = 10, Width = 150 };

            Label lblMaHP = new Label() { Text = "Mã HP:", Left = 10, Top = 40, Width = 60 };
            txtMaHP = new TextBox() { Left = 80, Top = 40, Width = 150 };

            Label lblGrade = new Label() { Text = "Điểm:", Left = 10, Top = 70, Width = 60 };
            txtGrade = new TextBox() { Left = 80, Top = 70, Width = 150 };

            btnSaveGrade = new Button() { Text = "Lưu Điểm", Left = 80, Top = 110, Width = 100 };
            btnSaveGrade.Click += BtnSaveGrade_Click;

            tabGrades.Controls.Add(lblMaSV);
            tabGrades.Controls.Add(txtMaSV);
            tabGrades.Controls.Add(lblMaHP);
            tabGrades.Controls.Add(txtMaHP);
            tabGrades.Controls.Add(lblGrade);
            tabGrades.Controls.Add(txtGrade);
            tabGrades.Controls.Add(btnSaveGrade);

            // Thêm các tab vào TabControl
            tabControl.TabPages.Add(tabClasses);
            tabControl.TabPages.Add(tabGrades);

            this.Controls.Add(tabControl);

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadClasses();
        }

        // Load danh sách lớp do nhân viên phụ trách (dựa trên LoggedInEmployeeID)
        private void LoadClasses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LOP WHERE MANV = @MANV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MANV", LoggedInEmployeeID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvClasses.DataSource = dt;
                }
            }
        }

        // Khi chọn một lớp, load danh sách sinh viên thuộc lớp đó
        private void DgvClasses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClasses.CurrentRow != null)
            {
                string classId = dgvClasses.CurrentRow.Cells["MALOP"].Value.ToString();
                LoadStudents(classId);
            }
        }

        private void LoadStudents(string classId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM SINHVIEN WHERE MALOP = @MALOP";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MALOP", classId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStudents.DataSource = dt;
                }
            }
        }

        // Xử lý lưu điểm cho sinh viên (gọi SP_INS_DIEM)
        private void BtnSaveGrade_Click(object sender, EventArgs e)
        {
            string masv = txtMaSV.Text.Trim();
            string mahp = txtMaHP.Text.Trim();
            if (!float.TryParse(txtGrade.Text.Trim(), out float diem))
            {
                MessageBox.Show("Điểm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_INS_DIEM", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MASV", masv);
                    cmd.Parameters.AddWithValue("@MAHP", mahp);
                    cmd.Parameters.AddWithValue("@DIEM", diem);
                    // Sử dụng LoggedInEmployeeID làm Public Key cho mã hóa điểm
                    cmd.Parameters.AddWithValue("@PUBKEY", LoggedInEmployeeID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
