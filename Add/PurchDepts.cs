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
    public partial class PurchDepts : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public PurchDepts()
        {
            InitializeComponent();
        }

        private void PurchDepts_Load(object sender, EventArgs e)
        {
            AddtoDebtsPurch();
            //AddtoDebtsByCode();
            FillGridCash();           
            PopulateUnitDebtbyOrderGridView();
        }        
        private void FillGridCash()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblPurchForDebts order by Ամսաթիվ asc", con);

            con.Close();

            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvPurchForDebts.DataSource = dt;
            dgvPurchForDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPurchForDebts.Columns["Ամսաթիվ"].Width = 80;
            dgvPurchForDebts.Columns["Ամսաթիվ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchForDebts.Columns["Կոդ"].Width = 80;
            dgvPurchForDebts.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvPurchForDebts.EnableHeadersVisualStyles = false;
            dgvPurchForDebts.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dgvPurchForDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPurchForDebts.ColumnHeadersHeight = 36;
        }

        private void AddtoDebtsPurch()
        {
            try
            {
                con.Open();

                // Clear the existing data from TblOrderForDepts
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblPurchForDebts", con);
                deleteCmd.ExecuteNonQuery();

                // Insert data with the new logic for the Պատվեր column
                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO TblPurchForDebts 
            (hh, Գործողություն, [վ/ե], Ամսաթիվ, Կոդ, Մատակարար, Արժեք, ԱԱՀ, Ընդհանուր, Ելք, Դրամարկղ, Մեկնաբանություն, Պատվեր) 
            SELECT 
                hh, 
                Գործողություն, 
                [վ/ե], 
                Ամսաթիվ, 
                Կոդ, 
                Մատակարար, 
                Արժեք,
                ԱԱՀ,
                Ընդհանուր, 
                Ելք, 
                Դրամարկղ, 
                Մեկնաբանություն, 
                CASE 
                    WHEN [վ/ե] = N'Կ' THEN Արժեք 
                    WHEN [վ/ե] = N'Փ' THEN Ընդհանուր 
                    ELSE NULL 
                END AS Պատվեր
            FROM TblDebtsControl 
            WHERE Գործողություն = N'Առք' OR Գործողություն = N'Ծախս'", con);

                cmd.ExecuteNonQuery();

                con.Close();

                // Reload the data into the DataGridView
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM TblPurchForDebts", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgvPurchForDebts.DataSource = dt1;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show(ex.Message);
            }
        }
        
        public void PopulateUnitDebtbyOrderGridView()
        {
            try
            {
                con.Open();

                // Fetch data from the database
                SqlCommand cmd = new SqlCommand("SELECT * FROM TblPurchForDebts ORDER BY Կոդ ASC", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Calculate and group data
                var groupedData = from row in dt.AsEnumerable()
                                  group row by row.Field<string>("Կոդ") into grp
                                  select new
                                  {
                                      Կոդ = grp.Key,
                                      Մատակարար = grp.First().Field<string>("Մատակարար"),
                                      Մեկնաբանություն = grp.First().Field<string>("Մեկնաբանություն"),
                                      Պատվեր = grp.Sum(r => r.IsNull("Պատվեր") ? 0 : Convert.ToDecimal(r["Պատվեր"])).ToString("#,0"),
                                      Վճար = grp.Sum(r => r.IsNull("Ելք") ? 0 : Convert.ToDecimal(r["Ելք"])).ToString("#,0"),
                                      Պարտք = grp.Sum(r =>
                                      {
                                          var input = r.IsNull("Պատվեր") ? 0 : Convert.ToDecimal(r["Պատվեր"]);
                                          var output = r.IsNull("Ելք") ? 0 : Convert.ToDecimal(r["Ելք"]);
                                          return input - output;
                                      }).ToString("#,0"),
                                  };

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("Կոդ");
                dt1.Columns.Add("Մատակարար");
                dt1.Columns.Add("Նշում");
                dt1.Columns.Add("Պատվեր");
                dt1.Columns.Add("Վճար");
                dt1.Columns.Add("Պարտք");

                foreach (var item in groupedData)
                {
                    dt1.Rows.Add(item.Կոդ, item.Մատակարար, item.Մեկնաբանություն, item.Պատվեր, item.Վճար, item.Պարտք);
                }

                // Filter rows where "Պարտք" is not equal to 0
                DataTable filteredRows = dt1.Clone();
                foreach (DataRow row in dt1.Rows)
                {
                    if (Convert.ToDecimal(row["Պարտք"]) != 0)
                    {
                        filteredRows.Rows.Add(row.ItemArray);
                    }
                }

                dgvDebtsByClient.DataSource = filteredRows;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dgvDebtsByClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                PayPurchDebts payPurchDebts = new PayPurchDebts();

                // Set values before showing the form or populating data
                DataGridViewRow selectedRow = dgvDebtsByClient.Rows[e.RowIndex];
                payPurchDebts.txtCodText = selectedRow.Cells[1].Value?.ToString();
                payPurchDebts.txtPDInvComText = selectedRow.Cells[3].Value?.ToString();

                // Populate data after setting the values
                payPurchDebts.PopulateDgvClientDebtsOrders();

                // Now show the form after the data is populated
                payPurchDebts.Show();
            }
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            PurchDepts_Load(sender, e);
        }

       
    }
}
