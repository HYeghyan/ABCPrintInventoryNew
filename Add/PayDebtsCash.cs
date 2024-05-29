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
        }
        private void DesignDataGridView()
        {
            dgvClientDebtsOrders.EnableHeadersVisualStyles = false;
            dgvClientDebtsOrders.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dgvClientDebtsOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkSlateGray;
            dgvClientDebtsOrders.Columns[7].Visible = false;
            dgvClientDebtsOrders.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dgvClientDebtsOrders.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dgvClientDebtsOrders.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dgvClientDebtsOrders.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dgvClientDebtsOrders.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
        }
        public void PopulateDgvClientDebtsOrders()
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
                    if (remainingBalance != 0) // Show only orders with non-zero remaining balance
                    {
                        int rowIndex = dgvClientDebtsOrders.Rows.Add();
                        DataGridViewRow dgvRow = dgvClientDebtsOrders.Rows[rowIndex];

                        dgvRow.Cells[0].Value = false;
                        dgvRow.Cells[1].Value = group.Orders.FirstOrDefault()["Հաճախորդ"];
                        dgvRow.Cells[2].Value = group.Orders.FirstOrDefault()["ShortDate"];
                        dgvRow.Cells[3].Value = group.Orders.FirstOrDefault()["Պատվ. համ"];
                        dgvRow.Cells[4].Value = group.TotalOrderAmount.ToString("#,0");
                        dgvRow.Cells[5].Value = group.TotalPaymentAmount.ToString("#,0");
                        dgvRow.Cells[6].Value = remainingBalance.ToString("#,0");
                        dgvRow.Cells[7].Value = 0;
                    }
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
        //Աղյուսակի չեքբոքսը ընտրելու համար
        private void dgvClientDebtsOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvClientDebtsOrders.Rows[e.RowIndex].Cells[0].Value = !(bool)dgvClientDebtsOrders.Rows[e.RowIndex].Cells[0].Value;

            if ((bool)dgvClientDebtsOrders.Rows[e.RowIndex].Cells[0].Value)
            {
                // Update Cells[7] with Cells[6] value
                dgvClientDebtsOrders.Rows[e.RowIndex].Cells[7].Value = dgvClientDebtsOrders.Rows[e.RowIndex].Cells[6].Value;

                // Convert Cells[5] and Cells[7] to doubles before adding
                double cell5Value = Convert.ToDouble(dgvClientDebtsOrders.Rows[e.RowIndex].Cells[5].Value);
                double cell7Value = Convert.ToDouble(dgvClientDebtsOrders.Rows[e.RowIndex].Cells[7].Value);
                dgvClientDebtsOrders.Rows[e.RowIndex].Cells[5].Value = (cell5Value + cell7Value).ToString();

                // Calculate txtNOSelectValues
                txtNOSelectValues.Text = dgvClientDebtsOrders.Rows.Cast<DataGridViewRow>()
                    .Where(a => Convert.ToBoolean(a.Cells[0].Value).Equals(true))
                    .Sum(t => Convert.ToDouble(t.Cells[7].Value))
                    .ToString("#,0");

                // Calculate txtNOBalance without replacing decimal separator
                txtNOBalance.Text = (Convert.ToDouble(txtNODebts.Text) - Convert.ToDouble(txtNOSelectValues.Text)).ToString();
            }
            else
            {
                // Revert to initial view by resetting Cells[5] and Cells[7] values
                dgvClientDebtsOrders.Rows[e.RowIndex].Cells[5].Value = "0"; // Reset Cells[5] to initial value
                dgvClientDebtsOrders.Rows[e.RowIndex].Cells[7].Value = "0"; // Reset Cells[7] to initial value

                // Recalculate txtNOSelectValues and txtNOBalance for the remaining checked rows
                txtNOSelectValues.Text = dgvClientDebtsOrders.Rows.Cast<DataGridViewRow>()
                    .Where(a => Convert.ToBoolean(a.Cells[0].Value).Equals(true))
                    .Sum(t => Convert.ToDouble(t.Cells[7].Value))
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
                    object cellValue = row.Cells[6].Value;

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
                    double orderAmount;
                    if (!double.TryParse(row.Cells[6].Value.ToString().Replace(",", ""), out orderAmount))
                    {
                        MessageBox.Show("Error parsing order amount in row " + (row.Index + 1));
                        return;
                    }
                    double distributedAmount = Math.Min(orderAmount, enteredAmount);
                    double currentPayment = double.Parse(row.Cells[5].Value.ToString().Replace(",", ""));
                    double orderDebt = double.Parse(row.Cells[4].Value.ToString().Replace(",", ""));
                    row.Cells[7].Value = distributedAmount.ToString("#,0");

                    double totalCurrentPayment = currentPayment + distributedAmount; // Add distributed amount to currentPayment
                    row.Cells[5].Value = totalCurrentPayment.ToString("#,0");
                    row.Cells[6].Value = (orderDebt - totalCurrentPayment).ToString("#,0");

                    enteredAmount -= distributedAmount;

                    if (enteredAmount <= 0)
                        break;
                }

                if (enteredAmount > 0)
                {
                    MessageBox.Show("Overpayment amount: " + enteredAmount.ToString("#,0"));
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvClientDebtsOrders.Rows)
                {
                    row.Cells[7].Value = "0";
                    row.Cells[6].Value = "0";
                }
            }
        }
        //Ավելացնել պատվերների և վճարումների հիմնական աղյուսակ
        private void btnNOAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
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
                    cmd = new SqlCommand("INSERT INTO TblOrderForDepts (Ամսաթիվ, [Պատվ. համ], Հաճախորդ, [Վճարել է]) VALUES (@Column1, @Column2, @Column3, @Column5)", con);
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
                            cmd.Parameters.AddWithValue("@Column3", row.Cells[1].Value ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Column5", row.Cells[7].Value ?? DBNull.Value);
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
