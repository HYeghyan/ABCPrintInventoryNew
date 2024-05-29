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

namespace ABCPrintInventory.Add
{
    public partial class InvoiceCreator : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public InvoiceCreator()
        {
            InitializeComponent();
          
        }
        public string cmbICclientText
        {
            get { return cmbICclient.Text; }
            set { cmbICclient.Text = value; }
        }

        //2 Չեքբոքսերի նշելը
        private void checkBoxDH_CheckedChanged(object sender, EventArgs e)
        {
            
        }     
        private void btnICAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
            this.Close();
        }
        private void AddItemToGridview()
        {
            if (cmbICclient.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();

                    foreach (DataGridViewRow row in dgvClientDebtsTA.Rows)
                    {
                        if (!row.IsNewRow) // Skip the new row if present
                        {
                            cmd = new SqlCommand("UPDATE TblOrderForDeptsTA SET ԴՀ = @DhValue WHERE [Պատվ. համ] = @KodValue", con);
                            cmd.Parameters.AddWithValue("@KodValue", row.Cells[3].Value?.ToString());
                            cmd.Parameters.AddWithValue("@DhValue", row.Cells[4].Value?.ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Տվյալները ավելացվեցին հաջողությամբ");

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //Աղյուսակի չեքբոքսը
        private void dgvClientDebtsOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // Get the cell
                DataGridViewCell cell = dgvClientDebtsTA.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Ensure the cell is not null and is of type DataGridViewCheckBoxCell
                if (cell != null && cell is DataGridViewCheckBoxCell chkCell)
                {
                    // Toggle the checkbox state
                    chkCell.Value = !(bool)chkCell.Value;

                    // Set the corresponding cell in dgvClientDebtsTA based on the checkbox state
                    if ((bool)chkCell.Value)
                    {
                        dgvClientDebtsTA.Rows[e.RowIndex].Cells[4].Value = "yes";
                        txtICval.Text = dgvClientDebtsTA.Rows.Cast<DataGridViewRow>()
                           .Where(a => Convert.ToBoolean(a.Cells[0].Value).Equals(true))
                           .Sum(t => Convert.ToDouble(t.Cells[7].Value))
                           .ToString("#,0");
                        CalculateNDS();
                    }
                    else
                    {
                        dgvClientDebtsTA.Rows[e.RowIndex].Cells[4].Value = null; // Or set it to empty string as needed
                        txtICval.Text = dgvClientDebtsTA.Rows.Cast<DataGridViewRow>()
                           .Where(a => Convert.ToBoolean(a.Cells[0].Value).Equals(true))
                           .Sum(t => Convert.ToDouble(t.Cells[7].Value))
                           .ToString("#,0");
                        CalculateNDS();
                    }
                }
            }
        }
        public void CalculateNDS()
        {
            double val;
            double nds;
            double tot;

            val = Convert.ToDouble(txtICval.Text);
            nds = val * 20 / 100;
            txtICaah.Text = nds.ToString("#,0");
            tot = val + nds;
            txtICtot.Text = tot.ToString("#,0");
        }
        public void PopulateDgvInvoiceNonCreate()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(10), Ամսաթիվ, 105) AS ShortDate, [Պատվ. համ], Հաճախորդ, Արժեք, [Վճարել է] FROM TblOrderForDeptsTA WHERE Հաճախորդ = @Cell2Value", con);
                cmd.Parameters.AddWithValue("@Cell2Value", cmbICclient.Text);
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
                                          var paymentAmount = string.IsNullOrEmpty(r["Վճարել է"].ToString()) ? 0 : Convert.ToDecimal(r["Վճարել է"]);
                                          return paymentAmount;
                                      }),
                                  };

                foreach (var group in groupedData)
                {
                    decimal remainingBalance = group.TotalOrderAmount - group.TotalPaymentAmount;
                    if (remainingBalance != 0) // Show only orders with non-zero remaining balance
                    {
                        int rowIndex = dgvClientDebtsTA.Rows.Add();
                        DataGridViewRow dgvRow = dgvClientDebtsTA.Rows[rowIndex];

                        dgvRow.Cells[0].Value = false;
                        dgvRow.Cells[2].Value = group.Orders.FirstOrDefault()["ShortDate"]; 
                        dgvRow.Cells[3].Value = group.Orders.FirstOrDefault()["Պատվ. համ"];
                        dgvRow.Cells[1].Value = group.Orders.FirstOrDefault()["Հաճախորդ"];
                        dgvRow.Cells[5].Value = group.TotalOrderAmount.ToString("#,0");
                        dgvRow.Cells[6].Value = group.TotalPaymentAmount.ToString("#,0");
                        dgvRow.Cells[7].Value = remainingBalance.ToString("#,0");
                        dgvRow.Cells[8].Value = 0;
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
}
