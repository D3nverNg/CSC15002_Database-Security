using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QLSVNhomApp.Data;
using QLSVNhomApp.Utils;

namespace QLSVNhomApp.Forms
{
    public partial class ScoreDetailForm : Form
    {
        private string connectionString;
        private string classId;
        private string employeeId;
        private string errorMessage;

        public ScoreDetailForm(string connStr, string empId, string classId)
        {
            this.connectionString = connStr;
            this.employeeId = empId;
            this.classId = classId;
            InitializeComponent();
            lblTitle.Text = "Điểm chi tiết lớp " + classId;
            SetupDataGridViewColumns();
            LoadScores();
        }

        private void LoadScores()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GET_SCORES_BY_CLASS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MALOP", classId);
                    cmd.Parameters.AddWithValue("@PUBKEY", employeeId);
                    SqlParameter errorParam = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 200)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(errorParam);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    string errorMessage = errorParam.Value.ToString();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            dt.Columns.Add("DIEM", typeof(decimal));

            // Giải mã điểm ở phía C#
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    byte[] encryptedBytes = row["DIEM_ENCRYPTED"] as byte[];
                    if (encryptedBytes != null)
                    {
                        string privateKey = EncryptionHelper.LoadPrivateKeyFromFile(employeeId);
                        string decryptedText = EncryptionHelper.DecryptDataRSA(encryptedBytes, privateKey);

                        if (decimal.TryParse(decryptedText, out decimal diem))
                        {
                            row["DIEM"] = diem;
                        }
                        else
                        {
                            row["DIEM"] = DBNull.Value; // hoặc gán 0
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý riêng nếu cần, nhưng không gán lỗi string vào cột DIEM_ENCRYPTED
                    row["DIEM"] = DBNull.Value;
                }
            }
            dt.Columns.Remove("DIEM_ENCRYPTED");
            dgvScores.DataSource = dt;
        }

        private void SetupDataGridViewColumns()
        {
            dgvScores.Columns.Clear();
            dgvScores.BackgroundColor = Color.White;
            dgvScores.GridColor = Color.LightGray;
            dgvScores.BorderStyle = BorderStyle.Fixed3D;
            dgvScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvScores.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvScores.DefaultCellStyle.BackColor = Color.White;
            dgvScores.DefaultCellStyle.ForeColor = Color.Black;
            dgvScores.RowHeadersVisible = false;
            dgvScores.AllowUserToAddRows = false;
            dgvScores.AllowUserToDeleteRows = false;
            dgvScores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colMaSV = new DataGridViewTextBoxColumn() { Name = "colMaSV", HeaderText = "Mã SV", DataPropertyName = "MASV", Width = 100, ReadOnly = true };
            var colHoTen = new DataGridViewTextBoxColumn() { Name = "colHoTen", HeaderText = "Họ Tên", DataPropertyName = "HOTEN", Width = 200, ReadOnly = true };
            var colMaHP = new DataGridViewTextBoxColumn() { Name = "colMaHP", HeaderText = "Mã HP", DataPropertyName = "MAHP", Width = 100, ReadOnly = true };
            var colTenHP = new DataGridViewTextBoxColumn() { Name = "colTenHP", HeaderText = "Tên Học Phần", DataPropertyName = "TENHP", Width = 250, ReadOnly = true };
            var colDiem = new DataGridViewTextBoxColumn() { Name = "colDiem", HeaderText = "Điểm", DataPropertyName = "DIEM", Width = 100, ReadOnly = true };

            dgvScores.Columns.AddRange(new DataGridViewColumn[] { colMaSV, colHoTen, colMaHP, colTenHP, colDiem });
        }

        private void BtnEditScore_Click(object sender, EventArgs e)
        {
            InputScoreForm frm = new InputScoreForm(connectionString, employeeId, classId);
            frm.ShowDialog();
            LoadScores(); // Refresh dữ liệu sau khi chỉnh sửa
        }
    }
}
