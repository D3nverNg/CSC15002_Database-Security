using System.Drawing;
using System.Windows.Forms;

namespace QLSVNhomApp.Forms
{
    partial class ClassManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblGreeting;
        private Button btnLogout;
        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvClasses;
        private TableLayoutPanel mainLayout; // Bố cục chính

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
            lblGreeting = new Label();
            btnLogout = new Button();
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvClasses = new DataGridView();
            mainLayout = new TableLayoutPanel(); // Dùng TableLayoutPanel để sắp xếp

            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            SuspendLayout();

            // ========== mainLayout (Bố cục chính) ==========
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowCount = 3;
            mainLayout.ColumnCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Hàng 1: Tiêu đề
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Hàng 2: Thanh tìm kiếm
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Hàng 3: DataGridView
            mainLayout.Controls.Add(lblTitle, 0, 0);
            mainLayout.Controls.Add(CreateSearchPanel(), 0, 1);
            mainLayout.Controls.Add(dgvClasses, 0, 2);

            // ========== lblTitle ==========
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Text = "Quản lý lớp học";

            // ========== dgvClasses ==========
            dgvClasses.Dock = DockStyle.Fill;
            dgvClasses.Margin = new Padding(10);
            dgvClasses.BackgroundColor = Color.White;
            dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClasses.CellContentClick += DgvClasses_CellContentClick;

            // ========== Form Layout ==========
            Controls.Add(mainLayout);

            Name = "ClassManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(900, 600);
            Text = "Quản lý lớp học";

            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            ResumeLayout(false);
        }

        private Panel CreateSearchPanel()
        {
            Panel searchPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 40,
                Padding = new Padding(10)
            };

            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(10, 5);
            txtSearch.Size = new Size(400, 30);
            txtSearch.Text = "Tìm kiếm lớp học theo mã lớp hoặc tên lớp";

            btnSearch.Font = new Font("Segoe UI", 10F);
            btnSearch.Location = new Point(420, 5);
            btnSearch.Size = new Size(60, 30);
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;

            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(btnSearch);

            return searchPanel;
        }
    }
}
