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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvStudents = new DataGridView();
            btnUpdateStudent = new Button();
            btnAddStudent = new Button();
            btnDeleteStudent = new Button();
            btnInputScore = new Button();
            mainLayout = new TableLayoutPanel();
            searchLayout = new TableLayoutPanel();
            buttonLayout = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            mainLayout.SuspendLayout();
            searchLayout.SuspendLayout();
            buttonLayout.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(894, 50);
            lblTitle.TabIndex = 0;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(3, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(709, 34);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Tìm kiếm sinh viên theo mã sinh viên";
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.Font = new Font("Segoe UI", 10F);
            btnSearch.Location = new Point(718, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(173, 28);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm";
            btnSearch.Click += BtnSearch_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvStudents.DefaultCellStyle = dataGridViewCellStyle2;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(3, 93);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 62;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(894, 444);
            dgvStudents.TabIndex = 2;
            // 
            // btnUpdateStudent
            // 
            btnUpdateStudent.Dock = DockStyle.Fill;
            btnUpdateStudent.Font = new Font("Segoe UI", 10F);
            btnUpdateStudent.Location = new Point(3, 3);
            btnUpdateStudent.Name = "btnUpdateStudent";
            btnUpdateStudent.Size = new Size(217, 48);
            btnUpdateStudent.TabIndex = 0;
            btnUpdateStudent.Text = "Thay đổi thông tin";
            btnUpdateStudent.Click += BtnUpdateStudent_Click;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Dock = DockStyle.Fill;
            btnAddStudent.Font = new Font("Segoe UI", 10F);
            btnAddStudent.Location = new Point(226, 3);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(217, 48);
            btnAddStudent.TabIndex = 1;
            btnAddStudent.Text = "Thêm sinh viên";
            btnAddStudent.Click += BtnAddStudent_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Dock = DockStyle.Fill;
            btnDeleteStudent.Font = new Font("Segoe UI", 10F);
            btnDeleteStudent.Location = new Point(449, 3);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(217, 48);
            btnDeleteStudent.TabIndex = 2;
            btnDeleteStudent.Text = "Xóa sinh viên";
            btnDeleteStudent.Click += BtnDeleteStudent_Click;
            // 
            // btnInputScore
            // 
            btnInputScore.Dock = DockStyle.Fill;
            btnInputScore.Font = new Font("Segoe UI", 10F);
            btnInputScore.Location = new Point(672, 3);
            btnInputScore.Name = "btnInputScore";
            btnInputScore.Size = new Size(219, 48);
            btnInputScore.TabIndex = 3;
            btnInputScore.Text = "Nhập điểm";
            btnInputScore.Click += BtnInputScore_Click;
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            mainLayout.Controls.Add(lblTitle, 0, 0);
            mainLayout.Controls.Add(searchLayout, 0, 1);
            mainLayout.Controls.Add(dgvStudents, 0, 2);
            mainLayout.Controls.Add(buttonLayout, 0, 3);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 4;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.Size = new Size(900, 600);
            mainLayout.TabIndex = 0;
            // 
            // searchLayout
            // 
            searchLayout.ColumnCount = 2;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            searchLayout.Controls.Add(txtSearch, 0, 0);
            searchLayout.Controls.Add(btnSearch, 1, 0);
            searchLayout.Dock = DockStyle.Fill;
            searchLayout.Location = new Point(3, 53);
            searchLayout.Name = "searchLayout";
            searchLayout.RowCount = 1;
            searchLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            searchLayout.Size = new Size(894, 34);
            searchLayout.TabIndex = 1;
            // 
            // buttonLayout
            // 
            buttonLayout.ColumnCount = 4;
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            buttonLayout.Controls.Add(btnUpdateStudent, 0, 0);
            buttonLayout.Controls.Add(btnAddStudent, 1, 0);
            buttonLayout.Controls.Add(btnDeleteStudent, 2, 0);
            buttonLayout.Controls.Add(btnInputScore, 3, 0);
            buttonLayout.Dock = DockStyle.Fill;
            buttonLayout.Location = new Point(3, 543);
            buttonLayout.Name = "buttonLayout";
            buttonLayout.RowCount = 1;
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            buttonLayout.Size = new Size(894, 54);
            buttonLayout.TabIndex = 3;
            // 
            // ClassDetailForm
            // 
            ClientSize = new Size(900, 600);
            Controls.Add(mainLayout);
            Name = "ClassDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin chi tiết lớp";
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            mainLayout.ResumeLayout(false);
            searchLayout.ResumeLayout(false);
            searchLayout.PerformLayout();
            buttonLayout.ResumeLayout(false);
            ResumeLayout(false);
        }
        private TableLayoutPanel searchLayout;
    }
}