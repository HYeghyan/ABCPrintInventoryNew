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
    public partial class Depts : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public Depts()
        {
            InitializeComponent();
            TabDebts.ItemSize = new Size(200, 30); // Set the desired width and height for all tab headers
            TabDebts.SizeMode = TabSizeMode.Fixed;
            TabDebts.DrawMode = TabDrawMode.OwnerDrawFixed; // Set DrawMode to OwnerDrawFixed
            TabDebts.DrawItem += TabDebts_DrawItem;
            dgvTransAction.CellFormatting += dgvTransAction_CellFormatting;
        }

        private void Depts_Load(object sender, EventArgs e)
        {
            AddtoDebtsCash();
            FillGridCash();
            PopulateUnitDebtbyClientGridView();
            PopulateUnitDebtbyOrderGridView();
            DesignDatagridviews();

            AddtoDebtsTA();
            FillGridTransAction();
            PopulateUnitDebtTAbyclient();
            PopulateUnitDebtTAbyOrder();
            SelectDebtsTAinvNonCr();
            DesignDatagridviewsTA();
        }
        private void btnRef_Click(object sender, EventArgs e)
        {
            Depts_Load(sender, e);
        }
        //TabControl-ի գույները
        private void TabDebts_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush bgBrush;
            Brush textBrush;
            TabPage tabPage = TabDebts.TabPages[e.Index];
            Rectangle tabBounds = TabDebts.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                bgBrush = new SolidBrush(Color.RosyBrown); // Set your desired background color here
                textBrush = new SolidBrush(Color.White); // Set your desired text color here
            }
            else
            {
                bgBrush = new SolidBrush(Color.MistyRose); // Set your desired background color here
                textBrush = new SolidBrush(Color.DimGray); // Set your desired text color here
            }

            g.FillRectangle(bgBrush, tabBounds);

            // Center the text vertically and horizontally in the tab header
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            // Make the text bold
            using (Font boldFont = new Font(TabDebts.Font, FontStyle.Bold))
            {
                g.DrawString(tabPage.Text, boldFont, textBrush, tabBounds, stringFormat);
            }

            bgBrush.Dispose();
            textBrush.Dispose();
        }


        
        //----------------------------------------ԿԱՆԽԻԿ----------------------------------------------------

        private void DesignDatagridviews()
        {
            dgvDebtsByClient.EnableHeadersVisualStyles = false;
            dgvDebtsByClient.ColumnHeadersDefaultCellStyle.BackColor = Color.Brown;
            dgvDebtsByClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDebtsByClient.ColumnHeadersHeight = 24;
            dgvDebtsByClient.Columns["DebtsPay"].Width = 80;
            dgvDebtsByClient.Columns["Հաճախորդ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDebtsByClient.Columns["Պատվեր"].Width = 100;
            dgvDebtsByClient.Columns["Պատվեր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsByClient.Columns["Վճար"].Width = 100;
            dgvDebtsByClient.Columns["Վճար"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsByClient.Columns["Պարտք"].Width = 100;
            dgvDebtsByClient.Columns["Պարտք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsByClient.Columns["Պարտք"].DefaultCellStyle.ForeColor = Color.Red;

            dgvDebtsbyClientAll.EnableHeadersVisualStyles = false;
            dgvDebtsbyClientAll.ColumnHeadersDefaultCellStyle.BackColor = Color.Brown;
            dgvDebtsbyClientAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDebtsbyClientAll.ColumnHeadersHeight = 24;
            dgvDebtsbyClientAll.Columns["DebtsPayII"].Width = 80;
            dgvDebtsbyClientAll.Columns["Հաճախորդ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDebtsbyClientAll.Columns["Պատվեր"].Width = 100;
            dgvDebtsbyClientAll.Columns["Պատվեր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyClientAll.Columns["Վճար"].Width = 100;
            dgvDebtsbyClientAll.Columns["Վճար"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyClientAll.Columns["Պարտք"].Width = 100;
            dgvDebtsbyClientAll.Columns["Պարտք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyClientAll.Columns["Պարտք"].DefaultCellStyle.ForeColor = Color.Red;

            dgvDebtsbyOrderNums.EnableHeadersVisualStyles = false;
            dgvDebtsbyOrderNums.ColumnHeadersDefaultCellStyle.BackColor = Color.SaddleBrown;
            dgvDebtsbyOrderNums.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDebtsbyOrderNums.ColumnHeadersHeight = 24;
            dgvDebtsbyOrderNums.Columns["DebtsPayOrd"].Width = 70;
            dgvDebtsbyOrderNums.Columns["Կոդ"].Width = 120;
            dgvDebtsbyOrderNums.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderNums.Columns["Հաճախորդ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDebtsbyOrderNums.Columns["Արժեք"].Width = 100;
            dgvDebtsbyOrderNums.Columns["Արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderNums.Columns["Մուտք"].Width = 100;
            dgvDebtsbyOrderNums.Columns["Մուտք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderNums.Columns["Պարտք"].Width = 100;
            dgvDebtsbyOrderNums.Columns["Պարտք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderNums.Columns["Պարտք"].DefaultCellStyle.ForeColor = Color.Red;

            dgvDebtsbyOrderAll.EnableHeadersVisualStyles = false;
            dgvDebtsbyOrderAll.ColumnHeadersDefaultCellStyle.BackColor = Color.SaddleBrown;
            dgvDebtsbyOrderAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDebtsbyOrderAll.ColumnHeadersHeight = 24;
            dgvDebtsbyOrderAll.Columns["DebtsPayOrdII"].Width = 70;
            dgvDebtsbyOrderAll.Columns["Կոդ"].Width = 120;
            dgvDebtsbyOrderAll.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderAll.Columns["Հաճախորդ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDebtsbyOrderAll.Columns["Արժեք"].Width = 100;
            dgvDebtsbyOrderAll.Columns["Արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderAll.Columns["Մուտք"].Width = 100;
            dgvDebtsbyOrderAll.Columns["Մուտք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderAll.Columns["Պարտք"].Width = 100;
            dgvDebtsbyOrderAll.Columns["Պարտք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderAll.Columns["Պարտք"].DefaultCellStyle.ForeColor = Color.Red;
        }
        //---Պարտքերի կառավարման աղյուսակից առանձնացնում ենք կանխիկ գործարքները

        //-----Հիմնական աղյուսակ
        private void AddtoDebtsCash()
        {
            try
            {
                con.Open();

                // Clear the existing data from TblOrderForDepts
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblOrderForDepts", con);
                deleteCmd.ExecuteNonQuery();

                // Insert data with the new logic for the Պատվեր column
                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO TblOrderForDepts 
            (hh, Գործողություն, [վ/ե], Ամսաթիվ, Կոդ, Հաճախորդ, Արժեք, Ընդհանուր, Մուտք, Դրամարկղ, Մեկնաբանություն, Պատվեր) 
            SELECT 
                hh, 
                Գործողություն, 
                [վ/ե], 
                Ամսաթիվ, 
                Կոդ, 
                Հաճախորդ, 
                Արժեք, 
                Ընդհանուր, 
                Մուտք, 
                Դրամարկղ, 
                Մեկնաբանություն, 
                CASE 
                    WHEN [վ/ե] = N'Կ' THEN Արժեք 
                    WHEN [վ/ե] = N'Ք' THEN Ընդհանուր 
                    ELSE NULL 
                END AS Պատվեր
            FROM TblDebtsControl 
            WHERE Գործողություն = N'Վաճառք' AND [վ/ե] != N'Փ'", con);

                cmd.ExecuteNonQuery();

                con.Close();

                // Reload the data into the DataGridView
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM TblOrderForDepts", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgvCashFlow.DataSource = dt1;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show(ex.Message);
            }
        }
        private void FillGridCash()
        {
            da = new SqlDataAdapter("select * from TblOrderForDepts order by Ամսաթիվ desc, hh desc", con);

            
            dt = new DataTable();
            da.Fill(dt);
            dgvCashFlow.DataSource = dt;
            dgvCashFlow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCashFlow.Columns["hh"].Width = 40;
            dgvCashFlow.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCashFlow.Columns["hh"].Visible = false;
            dgvCashFlow.Columns["Գործողություն"].Visible = false;
            dgvCashFlow.Columns["վ/ե"].Visible = false;
            dgvCashFlow.Columns["Արժեք"].Visible = false;
            dgvCashFlow.Columns["Ընդհանուր"].Visible = false;
            dgvCashFlow.Columns["Ամսաթիվ"].Width = 80;
            dgvCashFlow.Columns["Ամսաթիվ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCashFlow.Columns["Կոդ"].Width = 80;
            dgvCashFlow.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCashFlow.Columns["Արժեք"].Width = 70;
            //dgvCashFlow.Columns["Արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCashFlow.Columns["Մուտք"].Width = 70;
            dgvCashFlow.Columns["Մուտք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCashFlow.Columns["Դրամարկղ"].Width = 130;

            dgvCashFlow.EnableHeadersVisualStyles = false;
            dgvCashFlow.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dgvCashFlow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCashFlow.ColumnHeadersHeight = 36;

        }
        
        //-----Պարտքերը ըստ հաճախորդների
        public void PopulateUnitDebtbyClientGridView()
        {
            try
            {
                con.Open();

                // Fetch data from TblOrderForDepts
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TblOrderForDepts order by Հաճախորդ asc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Calculate total input for each product
                var groupedData = from row in dt.AsEnumerable()
                                  group row by row.Field<string>("Հաճախորդ") into grp
                                  select new
                                  {
                                      Հաճախորդ = grp.Key,
                                      Պատվեր = grp.Sum(r => string.IsNullOrEmpty(r["Պատվեր"].ToString()) ? 0 : Convert.ToDecimal(r["Պատվեր"])).ToString("#,0"),
                                      Վճար = grp.Sum(r => string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"])).ToString("#,0"),
                                      Պարտք = grp.Sum(r =>
                                      {
                                          var input = string.IsNullOrEmpty(r["Պատվեր"].ToString()) ? 0 : Convert.ToDecimal(r["Պատվեր"]);
                                          var output = string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"]);
                                          return (input - output);
                                      }).ToString("#,0"),
                                  };

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("Հաճախորդ");
                dt1.Columns.Add("Պատվեր");
                dt1.Columns.Add("Վճար");
                dt1.Columns.Add("Պարտք");

                foreach (var item in groupedData)
                {
                    dt1.Rows.Add(item.Հաճախորդ, item.Պատվեր, item.Վճար, item.Պարտք);
                }

                dgvDebtsbyClientAll.DataSource = dt1;

                // Create a new DataTable to store filtered rows
                DataTable filteredRows = dt1.Clone(); // Clone the structure of dt1

                // Iterate through dt1 and add rows where "Պարտք" column is not equal to 0 to filteredRows
                foreach (DataRow row in dt1.Rows)
                {
                    if (Convert.ToDecimal(row["Պարտք"]) != 0)
                    {
                        filteredRows.Rows.Add(row.ItemArray); // Add a copy of the row to filteredRows
                    }
                }

                dgvDebtsByClient.DataSource = filteredRows;

            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
            finally
            {
                con.Close();
            }
        }

        //-----Պարտքերն ըստ պատվերների
        public void PopulateUnitDebtbyOrderGridView()
        {
            con.Open();

            // Calculate total input for each product
            var groupedData = from row in dt.AsEnumerable()
                              group row by row.Field<string>("Կոդ") into grp
                              select new
                              {
                                  ՊատվՀամար = grp.Key,
                                  Հաճախորդ = grp.FirstOrDefault()["Հաճախորդ"].ToString(),
                                  Պատվեր = grp.Sum(r => string.IsNullOrEmpty(r["Արժեք"].ToString()) ? 0 : Convert.ToDecimal(r["Արժեք"])).ToString("#,0"),
                                  Վճար = grp.Sum(r => string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"])).ToString("#,0"),
                                  Պարտք = grp.Sum(r =>
                                  {
                                      var input = string.IsNullOrEmpty(r["Արժեք"].ToString()) ? 0 : Convert.ToDecimal(r["Արժեք"]);
                                      var output = string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"]);
                                      return input - output;
                                  }).ToString("#,0"),
                              };

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Կոդ");
            dt1.Columns.Add("Հաճախորդ");
            dt1.Columns.Add("Արժեք");
            dt1.Columns.Add("Մուտք");
            dt1.Columns.Add("Պարտք");

            foreach (var item in groupedData)
            {
                dt1.Rows.Add(item.ՊատվՀամար, item.Հաճախորդ, item.Պատվեր, item.Վճար, item.Պարտք);
            }

            con.Close();

            dgvDebtsbyOrderAll.DataSource = dt1;

            // Create a new DataTable to store filtered rows
            DataTable filteredRows = dt1.Clone(); // Clone the structure of dt1

            // Iterate through dt1 and add rows where "Պարտք" column is not equal to 0 to filteredRows
            foreach (DataRow row in dt1.Rows)
            {
                if (Convert.ToDecimal(row["Պարտք"]) != 0)
                {
                    filteredRows.Rows.Add(row.ItemArray); // Add a copy of the row to filteredRows
                }
            }

            dgvDebtsbyOrderNums.DataSource = filteredRows;
        }       

        public DataGridView GetStockGridView()
        {
            return dgvDebtsByClient;
        }

        //Աղյուսակի կոճակների սեղմելը
              //1.Պարտքերն ըստ հաճախորդների
        private void dgvDebtsCash_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                PayDebtsCash payDebtsByClient = new PayDebtsCash();
                payDebtsByClient.Show();
                DataGridViewRow selectedRow = dgvDebtsByClient.Rows[e.RowIndex];
                payDebtsByClient.cmbNOclientText = selectedRow.Cells[1].Value?.ToString();

                string condition = $"SomeColumn = '{payDebtsByClient.cmbNOclientText}'"; // Example condition
                payDebtsByClient.PopulateDgvClientDebtsOrders();
            }
        }
              //2. Պարտքերն ըստ պատվերների
        private void dgvDebtsbyOrderNums_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDebtsbyOrderNums.Rows.Count)
            {
                try
                {
                    NewOrder newOrder = new NewOrder();
                    DataGridViewRow selectedRow = dgvDebtsbyOrderNums.Rows[e.RowIndex];

                    newOrder.TxtNOidText = selectedRow.Cells[1].Value?.ToString();
                    newOrder.cmbNOclientText = selectedRow.Cells[2].Value?.ToString();
                    newOrder.GetRbtSelect();
                    newOrder.PopulateDgvNOorderFromDatabase();

                    // Disable the Add button using the property
                    newOrder.BtnNOAddEnabled = false;

                    newOrder.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid row.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
              //3. Բոլոր Հաճախորդները
        private void dgvDebtsbyClientAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                PayDebtsCash payDebtsByClient = new PayDebtsCash();
                payDebtsByClient.Show();
                DataGridViewRow selectedRow = dgvDebtsByClient.Rows[e.RowIndex];
                payDebtsByClient.cmbNOclientText = selectedRow.Cells[1].Value?.ToString();

                string condition = $"SomeColumn = '{payDebtsByClient.cmbNOclientText}'"; // Example condition
                payDebtsByClient.PopulateDgvAllClients();
            }
        }
              //4. Բոլոր պատվերները
        private void dgvDebtsbyOrderAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDebtsbyOrderNums.Rows.Count)
            {
                try
                {
                    NewOrder newOrder = new NewOrder();
                    DataGridViewRow selectedRow = dgvDebtsbyOrderNums.Rows[e.RowIndex];

                    newOrder.TxtNOidText = selectedRow.Cells[1].Value?.ToString();
                    newOrder.cmbNOclientText = selectedRow.Cells[2].Value?.ToString();
                    newOrder.GetRbtSelect();
                    newOrder.PopulateDgvNOorderFromDatabase();

                    // Disable the Add button using the property
                    newOrder.BtnNOAddEnabled = false;

                    newOrder.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid row.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
        //Ձախ աղյուսակում վճարները խմբագրելու համար
        private void dgvCashFlow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditgridviewItem(sender, e);
        }
        private void EditgridviewItem(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid cell is double-clicked
            {
                DataGridViewRow selectedRow = dgvCashFlow.Rows[e.RowIndex];
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.ColumnIndex == 9 && string.IsNullOrWhiteSpace(cell.Value?.ToString()))
                    {
                        MessageBox.Show("Տվյալ տողը խմբագրման ենթակա չէ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    
                }
                EditPay editPay = new EditPay();
                editPay.Show();

                // Set the text property of txtEPidText in the EditPay form
                editPay.txtEPidText = selectedRow.Cells[0].Value?.ToString();
                editPay.cmbPaySysText = selectedRow.Cells[2].Value?.ToString();
                editPay.dtpEPText = selectedRow.Cells[3].Value?.ToString();
                editPay.txtEPnumText = selectedRow.Cells[4].Value?.ToString();
                editPay.cmbEPclientText = selectedRow.Cells[5].Value?.ToString();
                editPay.txtEPvalText = selectedRow.Cells[9].Value?.ToString();
                editPay.txtEPwallet = selectedRow.Cells[10].Value?.ToString();
                editPay.txtPDInvComText = selectedRow.Cells[11].Value?.ToString();
            }
        }


        //--------------------------------------------ՓՈԽԱՆՑՈՒՄ------------------------------------

        private void DesignDatagridviewsTA()
        {
            dgvInvoiceNONcreat.Columns["ԴՀ"].Visible = false;
            dgvInvoiceNONcreat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoiceNONcreat.Columns["Ամսաթիվ"].Width = 60;
            dgvInvoiceNONcreat.Columns["Ամսաթիվ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoiceNONcreat.Columns["Կոդ"].Width = 80;
            dgvInvoiceNONcreat.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoiceNONcreat.Columns["Արժեք"].Width = 50;
            dgvInvoiceNONcreat.Columns["Արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoiceNONcreat.Columns["ԱԱՀ"].Width = 40;
            dgvInvoiceNONcreat.Columns["ԱԱՀ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoiceNONcreat.Columns["Ընդհանուր"].Width = 80;
            dgvInvoiceNONcreat.Columns["Ընդհանուր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoiceNONcreat.Columns[0].Width = 70;
        }
        
        //-----Հիմնական աղյուսակ
        private void FillGridTransAction()
        {

            da = new SqlDataAdapter("select * from TblOrderForDeptsTA order by Ամսաթիվ asc", con);      

            dt = new DataTable();
            da.Fill(dt);
            dgvTransAction.DataSource = dt;
            dgvTransAction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransAction.Columns["hh"].Visible = false;
            dgvTransAction.Columns["ԴՀ"].Width = 30;
            dgvTransAction.Columns["ԴՀ"].Visible = false;
            dgvTransAction.Columns["ՄՀ"].Width = 30;
            dgvTransAction.Columns["ՄՀ"].Visible = false;
            dgvTransAction.Columns["Ամսաթիվ"].Width = 80;
            dgvTransAction.Columns["Ամսաթիվ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransAction.Columns["Կոդ"].Width = 80;
            dgvTransAction.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransAction.Columns["Արժեք"].Width = 80;
            dgvTransAction.Columns["Արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransAction.Columns["ԱԱՀ"].Width = 70;
            dgvTransAction.Columns["ԱԱՀ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransAction.Columns["Ընդհանուր"].Width = 90;
            dgvTransAction.Columns["Ընդհանուր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransAction.Columns["Մուտք"].Width = 90;
            dgvTransAction.Columns["Մուտք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTransAction.EnableHeadersVisualStyles = false;
            dgvTransAction.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dgvTransAction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvTransAction.ColumnHeadersHeight = 30;
           
        }
        private void AddtoDebtsTA()
        {
            try
            {
                con.Open();
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblOrderForDeptsTA", con);
                deleteCmd.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("Insert into TblOrderForDeptsTA(hh, Գործողություն, [վ/ե], ԴՀ, ՄՀ, Ամսաթիվ, Կոդ, Հաճախորդ, Արժեք, ԱԱՀ, Ընդհանուր, Մուտք, Դրամարկղ, Մեկնաբանություն) select hh, Գործողություն, [վ/ե], ԴՀ, ՄՀ, Ամսաթիվ, Կոդ, Հաճախորդ, Արժեք, ԱԱՀ, Ընդհանուր, Մուտք, Դրամարկղ, Մեկնաբանություն from TblDebtsControl WHERE Գործողություն = N'Վաճառք' AND [վ/ե] = N'Փ'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter da1 = new SqlDataAdapter("select * from TblOrderForDeptsTA", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgvTransAction.DataSource = dt1;

            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        //------Պարտքերն ըստ հաճախորդների
        public void PopulateUnitDebtTAbyclient()
        {
            //con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TblOrderForDeptsTA", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            // Calculate total input for each product
            var groupedData = from row in dt.AsEnumerable()
                              group row by row.Field<string>("Հաճախորդ") into grp
                              select new
                              {
                                  Հաճախորդ = grp.Key,
                                  Պատվեր = grp.Sum(r => string.IsNullOrEmpty(r["Ընդհանուր"].ToString()) ? 0 : Convert.ToDecimal(r["Ընդհանուր"])).ToString("#,0"),
                                  Վճար = grp.Sum(r => string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"])).ToString("#,0"),
                                  Պարտք = grp.Sum(r =>
                                  {
                                      var input = string.IsNullOrEmpty(r["Ընդհանուր"].ToString()) ? 0 : Convert.ToDecimal(r["Ընդհանուր"]);
                                      var output = string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"]);
                                      return (input - output);
                                  }).ToString("#,0"),
                              };
            DataTable dt3 = new DataTable();
            dt3.Columns.Add("Հաճախորդ");
            dt3.Columns.Add("Ընդհանուր");
            dt3.Columns.Add("Մուտք");
            dt3.Columns.Add("Պարտք");

            foreach (var item in groupedData)
            {
                dt3.Rows.Add(item.Հաճախորդ, item.Պատվեր, item.Վճար, item.Պարտք);
            }

            con.Close();

            dgvDebtsInvByClients.DataSource = dt3;

            // Create a new DataTable to store filtered rows
            DataTable filteredRows = dt3.Clone(); // Clone the structure of dt1

            // Iterate through dt1 and add rows where "Պարտք" column is not equal to 0 to filteredRows
            foreach (DataRow row in dt3.Rows)
            {
                if (Convert.ToDecimal(row["Պարտք"]) != 0)
                {
                    filteredRows.Rows.Add(row.ItemArray); // Add a copy of the row to filteredRows
                }
            }

            dgvDebtsInvByClients.DataSource = filteredRows;
        }

        //------Պարտքերն ըստ պատվերների
        public void PopulateUnitDebtTAbyOrder()
        {
            con.Open();

            // Calculate total input for each product
            var groupedData = from row in dt.AsEnumerable()
                              group row by row.Field<string>("Կոդ") into grp
                              select new
                              {
                                  ՊատվՀամար = grp.Key,
                                  Հաճախորդ = grp.FirstOrDefault()["Հաճախորդ"].ToString(),
                                  Պատվեր = grp.Sum(r => string.IsNullOrEmpty(r["Արժեք"].ToString()) ? 0 : Convert.ToDecimal(r["Արժեք"])).ToString("#,0"),
                                  Վճար = grp.Sum(r => string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"])).ToString("#,0"),
                                  Պարտք = grp.Sum(r =>
                                  {
                                      var input = string.IsNullOrEmpty(r["Արժեք"].ToString()) ? 0 : Convert.ToDecimal(r["Արժեք"]);
                                      var output = string.IsNullOrEmpty(r["Մուտք"].ToString()) ? 0 : Convert.ToDecimal(r["Մուտք"]);
                                      return input - output;
                                  }).ToString("#,0"),
                              };

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Կոդ");
            dt1.Columns.Add("Հաճախորդ");
            dt1.Columns.Add("Արժեք");
            dt1.Columns.Add("Մուտք");
            dt1.Columns.Add("Պարտք");

            foreach (var item in groupedData)
            {
                dt1.Rows.Add(item.ՊատվՀամար, item.Հաճախորդ, item.Պատվեր, item.Վճար, item.Պարտք);
            }

            con.Close();

            dgvDebtsInvByOrders.DataSource = dt1;

            
        }
        //------Դուրս գրել հաշիվ
        private void SelectDebtsTAinvNonCr()
        {
            try
            {               
                SqlDataAdapter da1t = new SqlDataAdapter("select hh, ԴՀ, Ամսաթիվ, Կոդ, Հաճախորդ, Արժեք, ԱԱՀ, Ընդհանուր, Մեկնաբանություն from TblOrderForDeptsTA WHERE (ԴՀ IS NULL OR ԴՀ = '') AND (Ընդհանուր IS NOT NULL AND Ընդհանուր <> '') AND ([վ/ե] = N'Փ')", con);
                DataTable dt1t = new DataTable();
                da1t.Fill(dt1t);
                dgvInvoiceNONcreat.DataSource = dt1t;

            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
        private void dgvTransAction_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTransAction.Rows)
            {
                if (!row.IsNewRow) // Skip the new row if present
                {
                    // Check if the cell value in the "ԴՀ" column is "yes"
                    if (row.Cells["ԴՀ"].Value?.ToString() == "yes")
                    {
                        // Set the cell value to "yes"
                        row.Cells["ԴՀ"].Value = "yes";

                        // Set the row's background color to yellow
                        row.DefaultCellStyle.BackColor = Color.Khaki;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
            }
        }

        //Աղյուսակի կոճակների սեղմելը
        private void dgvInvoiceNONcreat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            InvoiceCreator invoiceCreator = new InvoiceCreator();
            invoiceCreator.Show();
            DataGridViewRow selectedRow = dgvInvoiceNONcreat.Rows[e.RowIndex];
            invoiceCreator.cmbICclientText = selectedRow.Cells[5].Value?.ToString();

            string condition = $"SomeColumn = '{invoiceCreator.cmbICclientText}'"; // Example condition
            invoiceCreator.PopulateDgvInvoiceNonCreate();
        }
             
        private void dgvDebtsInvByClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                PayDebtsInv payDebtsInv = new PayDebtsInv();
                payDebtsInv.Show();
                DataGridViewRow selectedRow = dgvDebtsInvByClients.Rows[e.RowIndex];
                payDebtsInv.cmbNOclientText = selectedRow.Cells[1].Value?.ToString();

                string condition = $"SomeColumn = '{payDebtsInv.cmbNOclientText}'"; // Example condition
                payDebtsInv.PopulateDgvClientDebtsOrders();
            }
        }
        
        private void dgvDebtsInvByOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                PayDebtsInv payDebtsInv = new PayDebtsInv();
                payDebtsInv.Show();
                DataGridViewRow selectedRow = dgvDebtsInvByOrders.Rows[e.RowIndex];
                payDebtsInv.cmbNOclientText = selectedRow.Cells[2].Value?.ToString();

                string condition = $"SomeColumn = '{payDebtsInv.cmbNOclientText}'"; // Example condition
                payDebtsInv.PopulateDgvClientDebtsOrders();
            }
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
            dgvCashFlow.DataSource = duplicateTable; // Or use another DataGridView
            MessageBox.Show($"{duplicates.Count} duplicate codes found in column 'hh'.");
        }
    }
}
    

