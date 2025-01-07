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

namespace ABCPrintInventory.Stock
{
    public partial class CashFlow : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public CashFlow()
        {
            InitializeComponent();
        }

        private void CashFlow_Load(object sender, EventArgs e)
        {
            AddtoCashFlow();
            FillGridWall();
            PopulateUnitDebtbyOrderGridView();
        }
        private void AddtoCashFlow()
        {
            try
            {
                con.Open();
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblCashFlow", con);
                deleteCmd.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("Insert into TblCashFlow (hh, Գործողություն, Ամսաթիվ, Դրամարկղ, Մուտք, Ելք, Մեկնաբանություն) select hh, Գործողություն, Ամսաթիվ, Դրամարկղ, Մուտք, Ելք, Մեկնաբանություն from TblDebtsControl WHERE (Մուտք IS NOT NULL AND Մուտք != 0) OR (Ելք IS NOT NULL AND Ելք != 0)", con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter da1 = new SqlDataAdapter("select * from TblCashFlow", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgvCashFlow.DataSource = dt1;

            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
        private void FillGridWall()
        {
            //con.Open();
            da = new SqlDataAdapter("select * from TblCashFlow order by Ամսաթիվ desc, hh desc", con);

            con.Close();

            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvCashFlow.DataSource = dt;
            dgvCashFlow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCashFlow.Columns["Ամսաթիվ"].Width = 80;
            dgvCashFlow.Columns["Ամսաթիվ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvCashFlow.EnableHeadersVisualStyles = false;
            dgvCashFlow.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dgvCashFlow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCashFlow.ColumnHeadersHeight = 36;
        }
        public void PopulateUnitDebtbyOrderGridView()
        {
            try
            {
                con.Open();

                // Fetch data from the database
                SqlCommand cmd = new SqlCommand("SELECT Դրամարկղ, Մուտք, Ելք, Մնացորդ FROM TblCashFlow", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Calculate and group data
                var groupedData = from row in dt.AsEnumerable()
                                  group row by row.Field<string>("Դրամարկղ") into grp
                                  select new
                                  {
                                      Դրամարկղ = grp.Key,
                                      Մուտք = grp.Sum(r => string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"])).ToString("#,0"),
                                      Ելք = grp.Sum(r => string.IsNullOrEmpty(r["Ելք"].ToString()) ? 0 : Convert.ToDecimal(r["Ելք"])).ToString("#,0"),
                                      Մնացորդ = grp.Sum(r =>
                                      {
                                          var input = string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"]);
                                          var output = string.IsNullOrEmpty(r["Ելք"].ToString()) ? 0 : Convert.ToDecimal(r["Ելք"]);
                                          return input - output;
                                      }).ToString("#,0"),
                                  };

                // Create a new DataTable to hold the grouped data
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("Դրամարկղ");
                dt1.Columns.Add("Մուտք");
                dt1.Columns.Add("Ելք");
                dt1.Columns.Add("Մնացորդ");

                // Populate dt1 with the grouped data
                foreach (var item in groupedData)
                {
                    dt1.Rows.Add(item.Դրամարկղ, item.Մուտք, item.Ելք, item.Մնացորդ);
                }
  
                con.Close();

                dgvWallRest.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WalTr_Click(object sender, EventArgs e)
        {
            WalTransfer walTransfer = new WalTransfer();
            walTransfer.Show();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            CashFlow_Load(sender, e);
        }

       //Խմբագրելու համար
        private void dgvCashFlow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow clickedRow = dgvCashFlow.Rows[e.RowIndex];

            // Check if the first column contains "Փոխանցում"
            if (clickedRow.Cells[1].Value?.ToString() == "Փոխանցում")
            {
                EditWalTransfer(sender, e); // Call your method
            }
        }
        private void EditWalTransfer(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCashFlow.Rows.Count) return; // Ensure valid row index

            WalTransfer walTransfer = new WalTransfer();
            walTransfer.Show();
           
            DataGridViewRow selectedrow = dgvCashFlow.Rows[e.RowIndex];
            DataGridViewRow selectedNextrow = null;
            DataGridViewRow selectedPrevrow = null;

            // Safely get the next row if it exists
            if (e.RowIndex + 1 < dgvCashFlow.Rows.Count)
            {
                selectedNextrow = dgvCashFlow.Rows[e.RowIndex + 1];
            }

            // Safely get the previous row if it exists
            if (e.RowIndex - 1 >= 0)
            {
                selectedPrevrow = dgvCashFlow.Rows[e.RowIndex - 1];
            }

            // Populate WalTransfer fields
            walTransfer.dtpWText = selectedrow.Cells[2].Value?.ToString();
            walTransfer.cmbWTcomText = selectedrow.Cells[7].Value?.ToString();
            walTransfer.txtForEditText = "Խ";

            if (string.IsNullOrEmpty(selectedrow.Cells[4].Value?.ToString()))
            {
                walTransfer.txtTotValText = selectedrow.Cells[5].Value?.ToString();
                walTransfer.txtDebtIdexitText = selectedrow.Cells[0].Value?.ToString();
                walTransfer.txtDebtIdenterText = selectedNextrow?.Cells[0].Value?.ToString(); // Use null-check
                walTransfer.cmbWToutText = selectedrow.Cells[3].Value?.ToString();
                walTransfer.cmbWTinText = selectedNextrow?.Cells[3].Value?.ToString(); // Use null-check
            }
            else
            {
                walTransfer.txtTotValText = selectedrow.Cells[4].Value?.ToString();
                walTransfer.txtDebtIdenterText = selectedrow.Cells[0].Value?.ToString();
                walTransfer.txtDebtIdexitText = selectedPrevrow?.Cells[0].Value?.ToString(); // Use null-check
                walTransfer.cmbWTinText = selectedrow.Cells[3].Value?.ToString();
                walTransfer.cmbWToutText = selectedPrevrow?.Cells[3].Value?.ToString(); // Use null-check
            }
            walTransfer.ButtonsAvailabel();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Insert into TblCashFlow (hh, Գործողություն, Ամսաթիվ, Դրամարկղ, Մուտք, Ելք, Մեկնաբանություն) select hh, Գործողություն, Ամսաթիվ, Դրամարկղ, Մուտք, Ելք, Մեկնաբանություն from TblDebtsControl WHERE (Մուտք IS NOT NULL AND Մուտք != 0) OR (Ելք IS NOT NULL AND Ելք != 0)", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
