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
    public partial class PayDebtsCash : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public PayDebtsCash()
        {
            InitializeComponent();
        }
        public string cmbNOclientText
        {
            get { return cmbNOclient.Text; }
            set { cmbNOclient.Text = value; }
        }
        private void PayDebtsByClient_Load(object sender, EventArgs e)
        {                   
            DesignDataGridView();
            ProdComboboxComplate();
            GetRestVal();

        }
        private void DesignDataGridView()
        {
            dgvClientDebtsOrders.EnableHeadersVisualStyles = false;
            dgvClientDebtsOrders.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dgvClientDebtsOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkSlateGray;
            //dgvClientDebtsOrders.Columns[7].Visible = false;
            dgvClientDebtsOrders.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dgvClientDebtsOrders.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dgvClientDebtsOrders.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dgvClientDebtsOrders.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dgvClientDebtsOrders.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvClientDebtsOrders.Sort(dgvClientDebtsOrders.Columns[3], System.ComponentModel.ListSortDirection.Ascending);

        }
        //Դրամարկղի կոմբոն
        private void ProdComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Դրամարկղ) FROM TblWallet", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbWallet.Items.Add(dr.GetValue(0).ToString());
            }
            cmbWallet.SelectedIndex = 4;
            dr.Close();
            con.Close();
        }
        public void PopulateDgvClientDebtsOrders()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [վ/ե], CONVERT(varchar(10), Ամսաթիվ, 105) AS ShortDate, Կոդ, Հաճախորդ, Պատվեր, Մուտք  FROM TblOrderForDepts WHERE Հաճախորդ = @Cell2Value", con);
                cmd.Parameters.AddWithValue("@Cell2Value", cmbNOclient.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    cmbPaySys.Text = table.Rows[0]["վ/ե"].ToString();
                }

                var groupedData = from row in table.AsEnumerable()
                                  group row by row.Field<string>("Կոդ") into grp
                                  select new
                                  {
                                      OrderNumber = grp.Key,
                                      Orders = grp.ToList(),
                                      TotalOrderAmount = grp.Sum(r =>
                                      {
                                          var orderAmount = string.IsNullOrEmpty(r["Պատվեր"].ToString()) ? 0 : Convert.ToDecimal(r["Պատվեր"]);
                                          return orderAmount;
                                      }),
                                      TotalPaymentAmount = grp.Sum(r =>
                                      {
                                          var paymentAmount = string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"]);
                                          return paymentAmount;
                                      }),
                                  };

                dgvClientDebtsOrders.Rows.Clear();
                
                foreach (var group in groupedData)
                {
                    decimal remainingBalance = group.TotalOrderAmount - group.TotalPaymentAmount;
                    if (remainingBalance != 0) // Show only orders with non-zero remaining balance
                    {
                        int rowIndex = dgvClientDebtsOrders.Rows.Add();
                        DataGridViewRow dgvRow = dgvClientDebtsOrders.Rows[rowIndex];

                        dgvRow.Cells[0].Value = false;
                        dgvRow.Cells[2].Value = group.Orders.FirstOrDefault()["Հաճախորդ"];
                        dgvRow.Cells[3].Value = group.Orders.FirstOrDefault()["ShortDate"];
                        dgvRow.Cells[4].Value = group.Orders.FirstOrDefault()["Կոդ"];
                        dgvRow.Cells[5].Value = group.TotalOrderAmount.ToString("#,0");
                        dgvRow.Cells[6].Value = group.TotalPaymentAmount.ToString("#,0");
                        dgvRow.Cells[7].Value = remainingBalance.ToString("#,0");
                        dgvRow.Cells[8].Value = 0;
                        dgvRow.Cells[3].Value = DateTime.ParseExact(group.Orders.FirstOrDefault()["ShortDate"].ToString(), "dd-MM-yyyy", null);

                    }

                    dgvClientDebtsOrders.Sort(dgvClientDebtsOrders.Columns[3], System.ComponentModel.ListSortDirection.Ascending);
                }
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CalculateSumDebts();
        }
        public void PopulateDgvAllClients()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(10), Ամսաթիվ, 105) AS ShortDate, [Պատվ. համ], Հաճախորդ, Արժեք, Վճար FROM TblDebtsbyOrdOnline WHERE Հաճախորդ = @Cell2Value", con);
                cmd.Parameters.AddWithValue("@Cell2Value", cmbNOclient.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                var groupedData = from row in table.AsEnumerable()
                                  group row by row.Field<string>("Պատվ. համ") into grp
                                  select new
                                  {
                                      OrderNumber = grp.Key,
                                      Orders = grp.ToList(),
                                      TotalOrderAmount = grp.Sum(r =>
                                      {
                                          var orderAmount = string.IsNullOrEmpty(r["Արժեք"].ToString()) ? 0 : Convert.ToDecimal(r["Արժեք"]);
                                          return orderAmount;
                                      }),
                                      TotalPaymentAmount = grp.Sum(r =>
                                      {
                                          var paymentAmount = string.IsNullOrEmpty(r["Վճար"].ToString()) ? 0 : Convert.ToDecimal(r["Վճար"]);
                                          return paymentAmount;
                                      }),
                                  };

                foreach (var group in groupedData)
                {
                    decimal remainingBalance = group.TotalOrderAmount - group.TotalPaymentAmount;
                    int rowIndex = dgvClientDebtsOrders.Rows.Add();
                    DataGridViewRow dgvRow = dgvClientDebtsOrders.Rows[rowIndex];

                    dgvRow.Cells[0].Value = false;
                    dgvRow.Cells[1].Value = group.Orders.FirstOrDefault()["Հաճախորդ"];
                    dgvRow.Cells[2].Value = group.Orders.FirstOrDefault()["ShortDate"];
                    dgvRow.Cells[3].Value = group.Orders.FirstOrDefault()["Պատվ. համ"];
                    dgvRow.Cells[4].Value = group.TotalOrderAmount;
                    dgvRow.Cells[5].Value = group.TotalPaymentAmount;
                    dgvRow.Cells[6].Value = remainingBalance;
                    dgvRow.Cells[7].Value = 0;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        //Կոդը
        private void GetItemId()
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

                string newCode = codePrefix + codeNumber;
                int startingNumber = int.Parse(codeNumber);

                foreach (DataGridViewRow row in dgvClientDebtsOrders.Rows)
                {
                    if (row.Cells[6].Value != null && decimal.TryParse(row.Cells[6].Value.ToString(), out decimal cellValue) && cellValue > 0)
                    {
                        // Generate and assign the new code for the current row
                        string rowCode = codePrefix + startingNumber.ToString("D2");
                        row.Cells[1].Value = rowCode;
                        startingNumber++; // Increment for the next row
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Աղյուսակի չեքբոքսը և աղյուսկում վճարման փոփոխությունները
        private void dgvClientDebtsOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvClientDebtsOrders.Rows[e.RowIndex].Cells[0].Value = !(bool)dgvClientDebtsOrders.Rows[e.RowIndex].Cells[0].Value;

            if ((bool)dgvClientDebtsOrders.Rows[e.RowIndex].Cells[0].Value)
            {
                // Update Cells[7] with Cells[6] value
                dgvClientDebtsOrders.Rows[e.RowIndex].Cells[8].Value = dgvClientDebtsOrders.Rows[e.RowIndex].Cells[7].Value;

                // Convert Cells[5] and Cells[7] to doubles before adding
                double cell5Value = Convert.ToDouble(dgvClientDebtsOrders.Rows[e.RowIndex].Cells[5].Value);
                double cell6Value = Convert.ToDouble(dgvClientDebtsOrders.Rows[e.RowIndex].Cells[6].Value);
                double cell8Value = Convert.ToDouble(dgvClientDebtsOrders.Rows[e.RowIndex].Cells[8].Value);
                dgvClientDebtsOrders.Rows[e.RowIndex].Cells[6].Value = (cell6Value + cell8Value).ToString();
                dgvClientDebtsOrders.Rows[e.RowIndex].Cells[7].Value = (cell5Value - cell8Value).ToString();

                // Calculate txtNOSelectValues
                txtNOSelectValues.Text = dgvClientDebtsOrders.Rows.Cast<DataGridViewRow>()
                    .Where(a => Convert.ToBoolean(a.Cells[0].Value).Equals(true))
                    .Sum(t => Convert.ToDouble(t.Cells[8].Value))
                    .ToString("#,0");

                // Calculate txtNOBalance without replacing decimal separator
                txtNOBalance.Text = (Convert.ToDouble(txtNODebts.Text) - Convert.ToDouble(txtNOSelectValues.Text)).ToString();
                GetItemId();
            }
            else
            {
                // Revert to initial view by resetting Cells[5] and Cells[7] values
                dgvClientDebtsOrders.Rows[e.RowIndex].Cells[6].Value = "0"; // Reset Cells[5] to initial value
                dgvClientDebtsOrders.Rows[e.RowIndex].Cells[8].Value = "0"; // Reset Cells[7] to initial value

                // Recalculate txtNOSelectValues and txtNOBalance for the remaining checked rows
                txtNOSelectValues.Text = dgvClientDebtsOrders.Rows.Cast<DataGridViewRow>()
                    .Where(a => Convert.ToBoolean(a.Cells[0].Value).Equals(true))
                    .Sum(t => Convert.ToDouble(t.Cells[8].Value))
                    .ToString("#,0");

                txtNOBalance.Text = (Convert.ToDouble(txtNODebts.Text) - Convert.ToDouble(txtNOSelectValues.Text)).ToString();
            }
        }

        //Հաշվել պարտքի աղյուսակի տոտալը
        private void CalculateSumDebts()
        {
            decimal totalVal = 0;

            foreach (DataGridViewRow row in dgvClientDebtsOrders.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Get the value from the cell
                    object cellValue = row.Cells[7].Value;

                    if (cellValue != null)
                    {
                        string formattedValue = cellValue.ToString().Replace(".", "");

                        if (decimal.TryParse(formattedValue, out decimal value))
                        {
                            totalVal += value;
                        }
                        else
                        {
                            // Handle parsing error or display a message
                            MessageBox.Show("Error: Invalid value in DataGridView.");
                        }
                    }
                }

                txtNODebts.Text = totalVal.ToString("#,0");
            }
        }
        private void CaountDeptRest()
        {
            if (!string.IsNullOrEmpty(txtNODebts.Text) && !string.IsNullOrEmpty(txtNOSelectValues.Text))
            {
                if (decimal.TryParse(txtNODebts.Text, out decimal debt) && decimal.TryParse(txtNOSelectValues.Text, out decimal pay))
                {
                    decimal rest = debt - pay;
                    txtNOBalance.Text = rest.ToString("N0");
                }
            }
        }
        private void RestResolutionTextChanged(object sender, EventArgs e)
        {
            txtNOSelectValues.TextChanged -= RestResolutionTextChanged;

            // Format the input as a number with commas
            if (decimal.TryParse(txtNOSelectValues.Text, out decimal pay))
            {
                txtNOSelectValues.Text = pay.ToString("N0");
                txtNOSelectValues.SelectionStart = txtNOSelectValues.Text.Length; // Set cursor to the end
            }

            // Re-add the TextChanged event handler
            txtNOSelectValues.TextChanged += RestResolutionTextChanged;

            // Call the CaounPurchDeptRest method to calculate the rest
            CaountDeptRest();
        }
        private void GetRestVal()
        {
            txtNOSelectValues.TextChanged += RestResolutionTextChanged;
        }

        private void txtNOSelectValues_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtNODebts.Text.Replace(",", ""), out double debts) &&
            double.TryParse(txtNOSelectValues.Text.Replace(",", ""), out double selectValues))
            {
                double balance = debts - selectValues;
                txtNOBalance.Text = balance.ToString("#,0");
            }
            else
            {
                txtNOBalance.Text = "0";
            }
        }
        private void txtNOSelectValues_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
                e.Handled = true;
                UpdateDataGridView();
                GetItemId();
            }
            else if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(txtNOSelectValues.Text))
            {
                UpdateDataGridView();
            }

        }
        private void UpdateDataGridView()
        {
            string inputText = txtNOSelectValues.Text.Replace(",", ""); // Remove commas for parsing
            if (!string.IsNullOrEmpty(inputText))
            {
                // Use double.TryParse instead of int.TryParse for decimal numbers
                double enteredAmount;
                if (!double.TryParse(inputText, out enteredAmount))
                {
                    MessageBox.Show("Please enter a valid number.");
                    return;
                }

                foreach (DataGridViewRow row in dgvClientDebtsOrders.Rows)
                {
                    if (row.Cells[7].Value == null || row.Cells[6].Value == null || row.Cells[5].Value == null)
                    {
                        MessageBox.Show("One of the required cells contains a null value in row " + (row.Index + 1));
                        return;
                    }

                    double orderAmount;
                    if (!double.TryParse(row.Cells[7].Value.ToString().Replace(",", ""), out orderAmount))
                    {
                        MessageBox.Show("Error parsing order amount in row " + (row.Index + 1));
                        return;
                    }

                    double distributedAmount = Math.Min(orderAmount, enteredAmount);
                    double currentPayment;
                    double orderDebt;

                    // Ensure cells 6 and 5 have valid values
                    if (!double.TryParse(row.Cells[6].Value.ToString().Replace(",", ""), out currentPayment) ||
                        !double.TryParse(row.Cells[5].Value.ToString().Replace(",", ""), out orderDebt))
                    {
                        MessageBox.Show("Error parsing current payment or order debt in row " + (row.Index + 1));
                        return;
                    }

                    // Update the distributed amount in cell[8]
                    row.Cells[8].Value = distributedAmount.ToString("#,0");

                    // Update the total current payment in cell[6]
                    double totalCurrentPayment = currentPayment + distributedAmount;
                    row.Cells[6].Value = totalCurrentPayment.ToString("#,0");

                    // Update the remaining order debt in cell[7]
                    double remainingDebt = orderDebt - totalCurrentPayment;

                    // Prevent negative debt values
                    if (remainingDebt < 0)
                    {
                        MessageBox.Show("Remaining debt cannot be negative in row " + (row.Index + 1));
                        return;
                    }

                    row.Cells[7].Value = remainingDebt.ToString("#,0");

                    // Decrease the entered amount by the distributed amount
                    enteredAmount -= distributedAmount;

                    if (enteredAmount <= 0)
                        break;
                }

                // If there's still some overpayment left
                if (enteredAmount > 0)
                {
                    MessageBox.Show("Overpayment amount: " + enteredAmount.ToString("#,0"));
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvClientDebtsOrders.Rows)
                {
                    // Reset cells if no amount was entered
                    row.Cells[8].Value = "0";
                    row.Cells[7].Value = "0";
                }
            }
        }
        
        //Ավելացնել պատվերների և վճարումների հիմնական աղյուսակ
        private void btnNOAdd_Click(object sender, EventArgs e)
        {
            //UpdateDataGridView();
            //GetItemId();
            AddItemToGridview();
            //AddItemToCashFlowGrid();
            this.Close();
        }
        private void AddItemToGridview()
        {
            if (cmbNOclient.Text == "" || txtNOSelectValues.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO TblDebtsControl (hh, Գործողություն, [վ/ե], Ամսաթիվ, Կոդ, Հաճախորդ, Մուտք, Դրամարկղ, Մեկնաբանություն) VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9)", con);
                    // Get DateTimePicker value outside the loop
                    DateTimePicker dtp = new DateTimePicker();
                    DateTime orderDate = dtpNO.Value;

                    // Loop through dgvNOorder rows
                    foreach (DataGridViewRow row in dgvClientDebtsOrders.Rows)
                    {
                        string cellValueStr = row.Cells[8].Value?.ToString(); // Get the cell value as a string
                        if (!string.IsNullOrEmpty(cellValueStr))
                        {
                            // Remove commas from the string and convert it to a numeric type (double or decimal)
                            if (double.TryParse(cellValueStr.Replace(",", ""), out double cellValueNumeric) && cellValueNumeric > 0)
                            {
                                cmd.Parameters.Clear(); // Clear parameters before re-adding them

                                cmd.Parameters.AddWithValue("@Column1", row.Cells[1].Value);
                                cmd.Parameters.AddWithValue("@Column2", txtPDInvAc.Text);
                                cmd.Parameters.AddWithValue("@Column3", cmbPaySys.Text);
                                cmd.Parameters.AddWithValue("@Column4", orderDate);
                                cmd.Parameters.AddWithValue("@Column5", row.Cells[4].Value ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@Column6", row.Cells[2].Value ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@Column7", cellValueNumeric);
                                cmd.Parameters.AddWithValue("@Column8", cmbWallet.Text);
                                cmd.Parameters.AddWithValue("@Column9", txtPDInvCom.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void AddItemToCashFlowGrid()
        {
            if (cmbNOclient.Text == "" || txtNOSelectValues.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO TblCashFlow (Ամսաթիվ, Կոդ, Դրամարկղ, Մուտք) VALUES (@Column1, @Column2, @Column3, @Column4)", con);
                    // Get DateTimePicker value outside the loop
                    DateTimePicker dtp = new DateTimePicker();
                    DateTime orderDate = dtp.Value;

                    // Loop through dgvNOorder rows
                    foreach (DataGridViewRow row in dgvClientDebtsOrders.Rows)
                    {
                        if (row.Cells[7].Value != null)
                        {
                            cmd.Parameters.Clear();

                            cmd.Parameters.AddWithValue("@Column1", orderDate);
                            cmd.Parameters.AddWithValue("@Column2", row.Cells[3].Value ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Column3", cmbWallet.Text);
                            cmd.Parameters.AddWithValue("@Column4", row.Cells[7].Value ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }
                        // Clear parameters and re-add them for each row

                    }

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtNOSelectValues_TextChanged(object sender, EventArgs e)
        {           
            //UpdateDataGridViewFromBalanceChange();
        }
       
    }
}
