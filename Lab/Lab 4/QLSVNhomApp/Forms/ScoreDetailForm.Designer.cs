namespace QLSVNhomApp.Forms
{
    partial class ScoreDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvScores;
        private System.Windows.Forms.Button btnEditScore;

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
            lblTitle = new System.Windows.Forms.Label();
            dgvScores = new System.Windows.Forms.DataGridView();
            btnEditScore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(dgvScores)).BeginInit();
            SuspendLayout();
            dgvScores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvScores.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 
            // lblTitle
            // 
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(800, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Điểm chi tiết lớp";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // dgvScores
            // 
            dgvScores.AllowUserToAddRows = false;
            dgvScores.AllowUserToDeleteRows = false;
            dgvScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScores.Location = new System.Drawing.Point(20, 60);
            dgvScores.Name = "dgvScores";
            dgvScores.ReadOnly = true;
            dgvScores.RowHeadersVisible = false;
            dgvScores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvScores.Size = new System.Drawing.Size(760, 350);
            dgvScores.TabIndex = 1;

            // 
            // btnEditScore
            // 
            btnEditScore.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnEditScore.Location = new System.Drawing.Point(640, 430);
            btnEditScore.Name = "btnEditScore";
            btnEditScore.Size = new System.Drawing.Size(140, 40);
            btnEditScore.TabIndex = 2;
            btnEditScore.Text = "Chỉnh sửa điểm";
            btnEditScore.UseVisualStyleBackColor = true;
            btnEditScore.Click += new System.EventHandler(BtnEditScore_Click);

            // 
            // ScoreDetailForm
            // 
            ClientSize = new System.Drawing.Size(800, 500);
            Controls.Add(lblTitle);
            Controls.Add(dgvScores);
            Controls.Add(btnEditScore);
            Name = "ScoreDetailForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Điểm chi tiết lớp";
            ((System.ComponentModel.ISupportInitialize)(dgvScores)).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}
