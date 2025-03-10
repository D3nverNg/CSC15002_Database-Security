using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QLSVNhomApp.Data;

namespace QLSVNhomApp.Forms
{
    public partial class ClassManagementForm : Form
    {
        public static string LoggedInEmployeeID { get; set; }
        public static string LoggedInUserName { get; set; }

        private string connectionString;
        private string searchPlaceholder = "Tìm kiếm lớp học theo mã lớp hoặc tên lớp";

        public ClassManagementForm(string connStr)
        {
            connectionString = connStr;
            InitializeComponent();
            lblGreeting.Text = "Xin chào " + LoggedInUserName;
            AdjustDataGridViewSize();
            SetupSearchBoxEvents();
            LoadClasses();
        }

        private void LoadClasses(string searchQuery = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd;

                if (string.IsNullOrEmpty(searchQuery) || searchQuery == searchPlaceholder)
                {
                    cmd = new SqlCommand("SP_GET_CLASSES", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd = new SqlCommand("SP_SEARCH_CLASSES", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MALOP", searchQuery);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                SetupDataGridViewColumns();
                dgvClasses.DataSource = dt;
            }
        }

        private void SetupDataGridViewColumns()
        {
            dgvClasses.Columns.Clear();
            dgvClasses.AllowUserToAddRows = false;
            var colMaLop = new DataGridViewTextBoxColumn()
            {
                Name = "colMaLop",
                DataPropertyName = "MALOP",
                HeaderText = "Mã lớp",
                Width = 120,
                ReadOnly = true
            };

            var colTenLop = new DataGridViewTextBoxColumn()
            {
                Name = "colTenLop",
                DataPropertyName = "TENLOP",
                HeaderText = "Tên lớp",
                Width = 200,
                ReadOnly = true
            };

            var colGVCN = new DataGridViewTextBoxColumn()
            {
                Name = "colGVCN",
                DataPropertyName = "MANV",
                HeaderText = "Giáo viên chủ nhiệm",
                Width = 200,
                ReadOnly = true
            };

            var colDetail = new DataGridViewLinkColumn()
            {
                Name = "colDetail",
                HeaderText = "Chi tiết",
                Text = "Xem",
                UseColumnTextForLinkValue = true,
                Width = 80
            };

            dgvClasses.Columns.AddRange(new DataGridViewColumn[] { colMaLop, colTenLop, colGVCN, colDetail });
        }

        private void AdjustDataGridViewSize()
        {
            dgvClasses.Dock = DockStyle.Fill;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            LoadClasses(searchQuery);
        }

        private void SetupSearchBoxEvents()
        {
            txtSearch.Enter += (sender, e) =>
            {
                if (txtSearch.Text == searchPlaceholder)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = searchPlaceholder;
                    txtSearch.ForeColor = Color.Gray;
                }
            };
        }

        private void DgvClasses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClasses.Columns[e.ColumnIndex].Name == "colDetail")
            {
                string classId = dgvClasses.Rows[e.RowIndex].Cells["colMaLop"].Value.ToString();
                ClassDetailForm detailForm = new ClassDetailForm(connectionString, classId);
                detailForm.ShowDialog();
            }
        }
    }
}
