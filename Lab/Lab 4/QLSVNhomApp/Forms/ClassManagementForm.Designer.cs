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
            mainLayout = new TableLayoutPanel();
            buttonInfo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            mainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // lblGreeting
            // 
            lblGreeting.Location = new Point(0, 0);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(100, 23);
            lblGreeting.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(0, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(894, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý lớp học";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 31);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(0, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 0;
            // 
            // dgvClasses
            // 
            dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClasses.BackgroundColor = Color.White;
            dgvClasses.ColumnHeadersHeight = 34;
            dgvClasses.Dock = DockStyle.Fill;
            dgvClasses.Location = new Point(10, 100);
            dgvClasses.Margin = new Padding(10);
            dgvClasses.Name = "dgvClasses";
            dgvClasses.RowHeadersWidth = 62;
            dgvClasses.Size = new Size(880, 490);
            dgvClasses.TabIndex = 1;
            dgvClasses.CellContentClick += DgvClasses_CellContentClick;
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            mainLayout.Controls.Add(buttonInfo, 0, 1);
            mainLayout.Controls.Add(lblTitle, 0, 0);
            mainLayout.Controls.Add(dgvClasses, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(900, 600);
            mainLayout.TabIndex = 0;
            // 
            // buttonInfo
            // 
            buttonInfo.Location = new Point(3, 53);
            buttonInfo.Name = "buttonInfo";
            buttonInfo.Size = new Size(170, 34);
            buttonInfo.TabIndex = 1;
            buttonInfo.Text = "Thông tin cá nhân";
            buttonInfo.UseVisualStyleBackColor = true;
            buttonInfo.Click += button1_Click;
            // 
            // ClassManagementForm
            // 
            ClientSize = new Size(900, 600);
            Controls.Add(mainLayout);
            Name = "ClassManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý lớp học";
            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            mainLayout.ResumeLayout(false);
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
            txtSearch.Text = "Tìm kiếm lớp học theo mã lớp";

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
        private Button buttonInfo;
    }
}
