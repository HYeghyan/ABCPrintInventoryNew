using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ABCPrintInventory.Add
{
    public partial class Test : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            GetItemId();
            FillGrid();
        }
        public string GetItemId()
        {
            string codePrefix = "ՊԿ";
            string codeNumber;
            string newCode = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon))
                {
                    con.Open();

                    string query = @"
                SELECT MAX(CAST(SUBSTRING(hh, LEN(@codePrefix) + 1, 
                    PATINDEX('%[^0-9]%', SUBSTRING(hh, LEN(@codePrefix) + 1, LEN(hh) + 1) + 'a') - 1) AS INT))
                FROM TblDebtsControl
                WHERE hh LIKE @codePrefix + '%'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@codePrefix", codePrefix);
                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            int lastNumber = Convert.ToInt32(result);
                            codeNumber = (lastNumber + 1).ToString("D2");
                        }
                        else
                        {
                            codeNumber = "01";
                        }

                        newCode = codePrefix + codeNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newCode;
        }
        private void GetDebtItemIdOld()
        {
            string codePrefix = "ՊԿ";
            string codeNumber;

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon))
                {
                    con.Open();

                    // SQL query to extract the numeric part before any suffix
                    string query = @"
                SELECT MAX(CAST(SUBSTRING(hh, LEN(@codePrefix) + 1, 
                    PATINDEX('%[^0-9]%', SUBSTRING(hh, LEN(@codePrefix) + 1, LEN(hh) + 1) + 'a') - 1) AS INT))
                FROM TblDebtsControl
                WHERE hh LIKE @codePrefix + '%'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@codePrefix", codePrefix);
                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            // Increment the numeric part
                            int lastNumber = Convert.ToInt32(result);
                            codeNumber = (lastNumber + 1).ToString("D2"); // Ensure at least 2 digits
                        }
                        else
                        {
                            // Start from 01 if no records are found
                            codeNumber = "01";
                        }
                    }
                }

                // Combine the prefix and the incremented number
                string newCode = codePrefix + codeNumber;

                // Assign new ID to text box
                txtID.Text = newCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblDebtsControl order by hh asc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvDeptscontrol.DataSource = dt;
            dgvDeptscontrol.Columns["Կոդ"].Width = 70;
            dgvDeptscontrol.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure the DataTable is filled
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No data to search for duplicates.");
                return;
            }

            // Use LINQ to find duplicate values in the 'hh' column
            var duplicates = dt.AsEnumerable()
                .GroupBy(row => row["hh"].ToString()) // Group by 'hh' column
                .Where(group => group.Count() > 1)   // Filter groups with more than 1 occurrence
                .Select(group => group.Key)          // Select the duplicate 'hh' values
                .ToList();

            if (duplicates.Count == 0)
            {
                MessageBox.Show("No duplicate codes found in column 'hh'.");
                return;
            }

            // Create a new DataTable to hold the duplicate rows
            DataTable duplicateTable = dt.Clone(); // Clone the structure of the original table

            foreach (var duplicate in duplicates)
            {
                var duplicateRows = dt.AsEnumerable()
                    .Where(row => row["hh"].ToString() == duplicate);

                foreach (var row in duplicateRows)
                {
                    duplicateTable.ImportRow(row);
                }
            }

            // Display the duplicate rows in a new DataGridView or the same one (as needed)
            dgvDeptscontrol.DataSource = duplicateTable; // Or use another DataGridView
            MessageBox.Show($"{duplicates.Count} duplicate codes found in column 'hh'.");
            //try
            //{
            //    DateTime date1 = dtpNO.Value.Date;

            //    // Open the database connection
            //    con.Open();

            //    // Prepare the SQL UPDATE command
            //    cmd = new SqlCommand("UPDATE TblDebtsControl SET hh = @ItemId WHERE Կոդ = @ItemCod AND Ամսաթիվ = @ItemDat", con);
            //    cmd.Parameters.AddWithValue("@ItemId", txtID.Text);
            //    cmd.Parameters.AddWithValue("@ItemCod", txtCode.Text);
            //    cmd.Parameters.AddWithValue("@ItemDat", date1);

            //    // Execute the command
            //    int rowsAffected = cmd.ExecuteNonQuery();

            //    // Provide feedback to the user
            //    if (rowsAffected > 0)
            //    {
            //        MessageBox.Show("Տվյալները հաջողությամբ թարմացվեցին:");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Տվյալներ չեն գտնվել թարմացման համար:");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Սխալ: " + ex.Message);
            //}
            //finally
            //{
            //    // Ensure the connection is closed
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //}
        }
    }
    
}
