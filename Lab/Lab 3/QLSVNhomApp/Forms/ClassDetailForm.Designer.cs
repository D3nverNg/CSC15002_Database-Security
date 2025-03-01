using System.Drawing;
using System.Windows.Forms;

namespace QLSVNhomApp.Forms
{
    partial class ClassDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;            // Tiêu đề: "Thông tin chi tiết lớp ..."
        private DataGridView dgvStudents;  // Bảng hiển thị thông tin sinh viên
        private Button btnUpdateStudent;   // "Thay đổi thông tin sinh viên"
        private Button btnAddStudent;      // "Thêm sinh viên"
        private Button btnDeleteStudent;   // "Xóa sinh viên"
        private Button btnInputScore;      // "Nhập điểm"

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            dgvStudents = new DataGridView();
            btnUpdateStudent = new Button();
            btnAddStudent = new Button();
            btnDeleteStudent = new Button();
            btnInputScore = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thông tin chi tiết lớp";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(20, 60);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(760, 350);
            dgvStudents.TabIndex = 1;
            dgvStudents.RowPostPaint += DgvStudents_RowPostPaint;
            // 
            // btnUpdateStudent
            // 
            btnUpdateStudent.Font = new Font("Segoe UI", 10F);
            btnUpdateStudent.Location = new Point(20, 430);
            btnUpdateStudent.Name = "btnUpdateStudent";
            btnUpdateStudent.Size = new Size(180, 40);
            btnUpdateStudent.TabIndex = 2;
            btnUpdateStudent.Text = "Thay đổi thông tin sinh viên";
            btnUpdateStudent.UseVisualStyleBackColor = true;
            btnUpdateStudent.Click += BtnUpdateStudent_Click;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Font = new Font("Segoe UI", 10F);
            btnAddStudent.Location = new Point(254, 430);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(140, 40);
            btnAddStudent.TabIndex = 3;
            btnAddStudent.Text = "Thêm sinh viên";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += BtnAddStudent_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Font = new Font("Segoe UI", 10F);
            btnDeleteStudent.Location = new Point(448, 430);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(140, 40);
            btnDeleteStudent.TabIndex = 4;
            btnDeleteStudent.Text = "Xóa sinh viên";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            btnDeleteStudent.Click += BtnDeleteStudent_Click;
            // 
            // btnInputScore
            // 
            btnInputScore.Font = new Font("Segoe UI", 10F);
            btnInputScore.Location = new Point(640, 430);
            btnInputScore.Name = "btnInputScore";
            btnInputScore.Size = new Size(140, 40);
            btnInputScore.TabIndex = 5;
            btnInputScore.Text = "Nhập điểm";
            btnInputScore.UseVisualStyleBackColor = true;
            btnInputScore.Click += BtnInputScore_Click;
            // 
            // ClassDetailForm
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(lblTitle);
            Controls.Add(dgvStudents);
            Controls.Add(btnUpdateStudent);
            Controls.Add(btnAddStudent);
            Controls.Add(btnDeleteStudent);
            Controls.Add(btnInputScore);
            Name = "ClassDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin chi tiết lớp";
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }

        /// <summary>
        /// Thiết lập cột mặc định cho DataGridView: STT, Mã SV, Họ Tên, Ngày sinh, Địa chỉ, Mã lớp
        /// </summary>
        private void SetupDataGridViewColumns()
        {
            dgvStudents.Columns.Clear();

            // 1) STT
            var colSTT = new DataGridViewTextBoxColumn()
            {
                Name = "colSTT",
                HeaderText = "STT",
                Width = 60,
                ReadOnly = true
            };
            colSTT.HeaderCell.Style.Font = new Font(dgvStudents.Font, FontStyle.Bold);
            colSTT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 2) Mã SV
            var colMaSV = new DataGridViewTextBoxColumn()
            {
                Name = "colMaSV",
                DataPropertyName = "MASV",
                HeaderText = "Mã SV",
                Width = 100,
                ReadOnly = true
            };
            colMaSV.HeaderCell.Style.Font = new Font(dgvStudents.Font, FontStyle.Bold);
            colMaSV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 3) Họ Tên
            var colHoTen = new DataGridViewTextBoxColumn()
            {
                Name = "colHoTen",
                DataPropertyName = "HOTEN",
                HeaderText = "Họ Tên",
                Width = 150,
                ReadOnly = true
            };
            colHoTen.HeaderCell.Style.Font = new Font(dgvStudents.Font, FontStyle.Bold);
            colHoTen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 4) Ngày sinh
            var colNgaySinh = new DataGridViewTextBoxColumn()
            {
                Name = "colNgaySinh",
                DataPropertyName = "NGAYSINH",
                HeaderText = "Ngày sinh",
                Width = 120,
                ReadOnly = true
            };
            colNgaySinh.HeaderCell.Style.Font = new Font(dgvStudents.Font, FontStyle.Bold);
            colNgaySinh.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 5) Địa chỉ
            var colDiaChi = new DataGridViewTextBoxColumn()
            {
                Name = "colDiaChi",
                DataPropertyName = "DIACHI",
                HeaderText = "Địa chỉ",
                Width = 180,
                ReadOnly = true
            };
            colDiaChi.HeaderCell.Style.Font = new Font(dgvStudents.Font, FontStyle.Bold);
            // Không bắt buộc căn giữa cho địa chỉ

            // 6) Mã lớp
            var colMaLop = new DataGridViewTextBoxColumn()
            {
                Name = "colMaLop",
                DataPropertyName = "MALOP",
                HeaderText = "Mã lớp",
                Width = 80,
                ReadOnly = true
            };
            colMaLop.HeaderCell.Style.Font = new Font(dgvStudents.Font, FontStyle.Bold);
            colMaLop.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvStudents.Columns.AddRange(new DataGridViewColumn[]
            {
                colSTT, colMaSV, colHoTen, colNgaySinh, colDiaChi, colMaLop
            });
        }

        #endregion
    }
}
