using System.Drawing;
using System.Windows.Forms;

namespace QLSVNhomApp.Forms
{
    partial class ClassManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblGreeting;    // "Xin chào ..."
        private Button btnLogout;     // "Đăng xuất"
        private Label lblTitle;       // "Quản lý lớp học"
        private TextBox txtSearch;    // Ô tìm kiếm
        private Button btnSearch;     // Nút "Tìm"
        private DataGridView dgvClasses;

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
            lblGreeting = new Label();
            btnLogout = new Button();
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvClasses = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            SuspendLayout();
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Font = new Font("Segoe UI", 10F);
            lblGreeting.Location = new Point(660, 14);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(93, 23);
            lblGreeting.TabIndex = 0;
            lblGreeting.Text = "Xin chào ...";
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 10F);
            btnLogout.Location = new Point(770, 10);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(110, 30);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += BtnLogout_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(900, 40);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Quản lý lớp học";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(20, 100);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(400, 30);
            txtSearch.TabIndex = 3;
            txtSearch.Text = "Tìm kiếm lớp học theo mã lớp hoặc tên lớp";
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 10F);
            btnSearch.Location = new Point(430, 98);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(60, 30);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // dgvClasses
            // 
            dgvClasses.AllowUserToAddRows = false;
            dgvClasses.AllowUserToDeleteRows = false;
            dgvClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClasses.Location = new Point(20, 150);
            dgvClasses.Name = "dgvClasses";
            dgvClasses.ReadOnly = true;
            dgvClasses.RowHeadersVisible = false;
            dgvClasses.RowHeadersWidth = 51;
            dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasses.Size = new Size(860, 420);
            dgvClasses.TabIndex = 5;
            dgvClasses.CellContentClick += DgvClasses_CellContentClick;
            dgvClasses.RowPostPaint += DgvClasses_RowPostPaint;
            // 
            // ClassManagementForm
            // 
            ClientSize = new Size(900, 600);
            Controls.Add(lblGreeting);
            Controls.Add(btnLogout);
            Controls.Add(lblTitle);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(dgvClasses);
            Name = "ClassManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý lớp học";
            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Thêm cột mặc định cho DataGridView (STT, Mã lớp, Tên lớp, GVCN, Chi tiết)
        /// </summary>
        private void SetupDataGridViewColumns()
        {
            this.dgvClasses.Columns.Clear();

            // 1) STT
            var colSTT = new DataGridViewTextBoxColumn()
            {
                Name = "colSTT",
                HeaderText = "STT",
                Width = 60,
                ReadOnly = true
            };
            colSTT.HeaderCell.Style.Font = new Font(dgvClasses.Font, FontStyle.Bold);
            colSTT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 2) Mã lớp
            var colMaLop = new DataGridViewTextBoxColumn()
            {
                Name = "colMaLop",
                DataPropertyName = "MALOP",
                HeaderText = "Mã lớp",
                Width = 150,
                ReadOnly = true
            };
            colMaLop.HeaderCell.Style.Font = new Font(dgvClasses.Font, FontStyle.Bold);
            colMaLop.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 3) Tên lớp
            var colTenLop = new DataGridViewTextBoxColumn()
            {
                Name = "colTenLop",
                DataPropertyName = "TENLOP",
                HeaderText = "Tên lớp",
                Width = 250,
                ReadOnly = true
            };
            colTenLop.HeaderCell.Style.Font = new Font(dgvClasses.Font, FontStyle.Bold);
            colTenLop.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 4) Giáo viên chủ nhiệm (MANV)
            var colGVCN = new DataGridViewTextBoxColumn()
            {
                Name = "colGVCN",
                DataPropertyName = "MANV", // Mặc định hiển thị mã nhân viên
                HeaderText = "Giáo viên chủ nhiệm",
                Width = 200,
                ReadOnly = true
            };
            colGVCN.HeaderCell.Style.Font = new Font(dgvClasses.Font, FontStyle.Bold);
            colGVCN.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 5) Chi tiết (Link "Xem")
            var colDetail = new DataGridViewLinkColumn()
            {
                Name = "colDetail",
                HeaderText = "Chi tiết",
                Text = "Xem",
                UseColumnTextForLinkValue = true,
                Width = 80
            };
            colDetail.HeaderCell.Style.Font = new Font(dgvClasses.Font, FontStyle.Bold);
            colDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Thêm tất cả cột vào dgvClasses
            this.dgvClasses.Columns.AddRange(new DataGridViewColumn[]
            {
                colSTT, colMaLop, colTenLop, colGVCN, colDetail
            });
        }

        #endregion
    }
}
