using System.Drawing;
using System.Windows.Forms;

namespace QLSVNhomApp.Forms
{
    partial class ClassDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvStudents;
        private Button btnUpdateStudent;
        private Button btnAddStudent;
        private Button btnDeleteStudent;
        private Button btnInputScore;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel buttonLayout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvStudents = new DataGridView();
            btnUpdateStudent = new Button();
            btnAddStudent = new Button();
            btnDeleteStudent = new Button();
            btnInputScore = new Button();
            mainLayout = new TableLayoutPanel();
            buttonLayout = new TableLayoutPanel();

            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();

            // Main Layout
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 4;
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Title
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Search bar
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // DataGridView
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F)); // Buttons

            // Title Label
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Search Layout
            var searchLayout = new TableLayoutPanel();
            searchLayout.ColumnCount = 2;
            searchLayout.RowCount = 1;
            searchLayout.Dock = DockStyle.Fill;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Text = "Tìm kiếm sinh viên theo mã hoặc tên";
            txtSearch.Enter += new System.EventHandler(this.TxtSearch_Enter);
            txtSearch.Leave += new System.EventHandler(this.TxtSearch_Leave);

            btnSearch.Font = new Font("Segoe UI", 10F);
            btnSearch.Text = "Tìm";
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            searchLayout.Controls.Add(txtSearch, 0, 0);
            searchLayout.Controls.Add(btnSearch, 1, 0);

            // DataGridView
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động fit cột
            dgvStudents.RowHeadersVisible = false; // Ẩn cột chỉ mục bên trái
            dgvStudents.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Cho phép xuống dòng
            dgvStudents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Button Layout
            buttonLayout.ColumnCount = 4;
            buttonLayout.RowCount = 1;
            buttonLayout.Dock = DockStyle.Fill;
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            btnUpdateStudent.Font = new Font("Segoe UI", 10F);
            btnUpdateStudent.Text = "Thay đổi thông tin";
            btnUpdateStudent.Dock = DockStyle.Fill;
            btnUpdateStudent.Click += new System.EventHandler(this.BtnUpdateStudent_Click);

            btnAddStudent.Font = new Font("Segoe UI", 10F);
            btnAddStudent.Text = "Thêm sinh viên";
            btnAddStudent.Dock = DockStyle.Fill;
            btnAddStudent.Click += new System.EventHandler(this.BtnAddStudent_Click);

            btnDeleteStudent.Font = new Font("Segoe UI", 10F);
            btnDeleteStudent.Text = "Xóa sinh viên";
            btnDeleteStudent.Dock = DockStyle.Fill;
            btnDeleteStudent.Click += new System.EventHandler(this.BtnDeleteStudent_Click);

            btnInputScore.Font = new Font("Segoe UI", 10F);
            btnInputScore.Text = "Nhập điểm";
            btnInputScore.Dock = DockStyle.Fill;
            btnInputScore.Click += new System.EventHandler(this.BtnInputScore_Click);

            buttonLayout.Controls.Add(btnUpdateStudent, 0, 0);
            buttonLayout.Controls.Add(btnAddStudent, 1, 0);
            buttonLayout.Controls.Add(btnDeleteStudent, 2, 0);
            buttonLayout.Controls.Add(btnInputScore, 3, 0);

            // Add components to main layout
            mainLayout.Controls.Add(lblTitle, 0, 0);
            mainLayout.Controls.Add(searchLayout, 0, 1);
            mainLayout.Controls.Add(dgvStudents, 0, 2);
            mainLayout.Controls.Add(buttonLayout, 0, 3);

            // Form
            ClientSize = new Size(900, 600);
            Controls.Add(mainLayout);
            Name = "ClassDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin chi tiết lớp";

            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }
    }
}
