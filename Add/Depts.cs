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
            
            FillGridCash();
            AddtoDebtsByClient();
            AddtoAllCustomers();
            PopulateUnitDebtbyClientGridView();
            FillGridCashII();
            AddtoDebtsByOrders();
            PopulateUnitDebtbyOrderGridView();
            DesignDatagridviews();
          
            FillGridTransAction();
            AddtoDebtsTAinvNonCr();
            DesignDatagridviewsTA();
            AddtoDebtsTApayinv();
            PopulateUnitDebtTAbyclient();
            AddtoDebtsTApayinvAll();
            PopulateUnitDebtTAbyOrder();
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
            dgvDebtsbyOrderNums.Columns["Պատվ. համ"].Width = 120;
            dgvDebtsbyOrderNums.Columns["Պատվ. համ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderNums.Columns["Հաճախորդ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDebtsbyOrderNums.Columns["Պատվեր"].Width = 100;
            dgvDebtsbyOrderNums.Columns["Պատվեր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderNums.Columns["Վճար"].Width = 100;
            dgvDebtsbyOrderNums.Columns["Վճար"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderNums.Columns["Պարտք"].Width = 100;
            dgvDebtsbyOrderNums.Columns["Պարտք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderNums.Columns["Պարտք"].DefaultCellStyle.ForeColor = Color.Red;

            dgvDebtsbyOrderAll.EnableHeadersVisualStyles = false;
            dgvDebtsbyOrderAll.ColumnHeadersDefaultCellStyle.BackColor = Color.SaddleBrown;
            dgvDebtsbyOrderAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDebtsbyOrderAll.ColumnHeadersHeight = 24;
            dgvDebtsbyOrderAll.Columns["DebtsPayOrdII"].Width = 70;
            dgvDebtsbyOrderAll.Columns["Պատվ. համ"].Width = 120;
            dgvDebtsbyOrderAll.Columns["Պատվ. համ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderAll.Columns["Հաճախորդ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDebtsbyOrderAll.Columns["Պատվեր"].Width = 100;
            dgvDebtsbyOrderAll.Columns["Պատվեր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderAll.Columns["Վճար"].Width = 100;
            dgvDebtsbyOrderAll.Columns["Վճար"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderAll.Columns["Պարտք"].Width = 100;
            dgvDebtsbyOrderAll.Columns["Պարտք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDebtsbyOrderAll.Columns["Պարտք"].DefaultCellStyle.ForeColor = Color.Red;
        }
        //Պարտքերը ըստ հաճախորդների
        private void FillGridCash()
        {
            //con.Open();
            da = new SqlDataAdapter("select * from TblOrderForDepts order by Ամսաթիվ asc", con);
            SqlDataAdapter da1 = new SqlDataAdapter("select * from TblDebtsOnline order by Հաճախորդ asc", con);
            SqlDataAdapter da2 = new SqlDataAdapter("select * from TblDebtsOnline order by Հաճախորդ asc", con);
            //con.Close();

            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvCashFlow.DataSource = dt;
            dgvCashFlow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCashFlow.Columns["hh"].Width = 40;
            dgvCashFlow.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCashFlow.Columns["hh"].Visible = false;
            dgvCashFlow.Columns["Ամսաթիվ"].Width = 80;
            dgvCashFlow.Columns["Ամսաթիվ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCashFlow.Columns["Պատվ. համ"].Width = 80;
            dgvCashFlow.Columns["Պատվ. համ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCashFlow.Columns["Պատվ. արժեք"].Width = 90;
            dgvCashFlow.Columns["Պատվ. արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCashFlow.Columns["Վճարել է"].Width = 90;
            dgvCashFlow.Columns["Վճարել է"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCashFlow.Columns["Մնացորդ"].Visible = false;

            dgvCashFlow.EnableHeadersVisualStyles = false;
            dgvCashFlow.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dgvCashFlow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCashFlow.ColumnHeadersHeight = 30;
            

            //SqlCommandBuilder cb1 = new SqlCommandBuilder(da1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvDebtsByClient.DataSource = dt1;

            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvDebtsbyClientAll.DataSource = dt2;
        }

        private void AddtoDebtsByClient()
        {
            try
            {
                con.Open();
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblDebtsOnline", con);
                deleteCmd.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("Insert into TblDebtsOnline(Հաճախորդ, Պատվեր, Վճար) select Հաճախորդ, [Պատվ. արժեք], [Վճարել է] from TblOrderForDepts", con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter da1 = new SqlDataAdapter("select * from TblDebtsOnline", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgvDebtsByClient.DataSource = dt1;

            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
        
        public void PopulateUnitDebtbyClientGridView()
        {
            con.Open();

            // Calculate total input for each product
            var groupedData = from row in dt.AsEnumerable()
                              group row by row.Field<string>("Հաճախորդ") into grp
                              select new
                              {
                                  Հաճախորդ = grp.Key,
                                  Պատվեր = grp.Sum(r => string.IsNullOrEmpty(r["Պատվ. արժեք"].ToString()) ? 0 : Convert.ToDecimal(r["Պատվ. արժեք"])).ToString("#,0"),
                                  Վճար = grp.Sum(r => string.IsNullOrEmpty(r["Վճարել է"].ToString()) ? 0 : Convert.ToDecimal(r["Վճարել է"])).ToString("#,0"),
                                  Պարտք = grp.Sum(r =>
                                  {
                                      var input = string.IsNullOrEmpty(r["Պատվ. արժեք"].ToString()) ? 0 : Convert.ToDecimal(r["Պատվ. արժեք"]);
                                      var output = string.IsNullOrEmpty(r["Վճարել է"].ToString()) ? 0 : Convert.ToDecimal(r["Վճարել է"]);
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

            con.Close();

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
        //Բոլոր հաճախորդները
        private void AddtoAllCustomers()
        {
            try
            {
                con.Open();
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblDebtsOnline", con);
                deleteCmd.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("Insert into TblDebtsOnline(Հաճախորդ, Պատվեր, Վճար) select Հաճախորդ, [Պատվ. արժեք], [Վճարել է] from TblOrderForDepts", con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter da2 = new SqlDataAdapter("select * from TblDebtsOnline", con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dgvDebtsbyClientAll.DataSource = dt2;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
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
        //Պարտքերն ըստ պատվերների
        private void FillGridCashII()
        {
            //con.Open();
            SqlDataAdapter dao1 = new SqlDataAdapter("select * from TblDebtsbyOrdOnline order by [Պատվ. համ] asc", con);
            SqlDataAdapter dao2 = new SqlDataAdapter("select * from TblDebtsbyOrdOnline order by [Պատվ. համ] asc", con);
            //con.Close();

            //SqlCommandBuilder cb1 = new SqlCommandBuilder(da1);
            DataTable dt1 = new DataTable();
            dao1.Fill(dt1);
            dgvDebtsbyOrderNums.DataSource = dt1;

            DataTable dt2 = new DataTable();
            dao2.Fill(dt2);
            dgvDebtsbyOrderAll.DataSource = dt2;
        }
        private void AddtoDebtsByOrders()
        {
            try
            {
                con.Open();
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblDebtsbyOrdOnline", con);
                deleteCmd.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("Insert into TblDebtsbyOrdOnline([Պատվ. համ], Ամսաթիվ, Հաճախորդ, Արժեք, Վճար) select [Պատվ. համ], Ամսաթիվ, Հաճախորդ, [Պատվ. արժեք], [Վճարել է] from TblOrderForDepts", con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter da1 = new SqlDataAdapter("select * from TblDebtsbyOrdOnline", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgvDebtsbyOrderNums.DataSource = dt1;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
        public void PopulateUnitDebtbyOrderGridView()
        {
            con.Open();

            // Calculate total input for each product
            var groupedData = from row in dt.AsEnumerable()
                              group row by row.Field<string>("Պատվ. համ") into grp
                              select new
                              {
                                  ՊատվՀամար = grp.Key,
                                  Հաճախորդ = grp.FirstOrDefault()["Հաճախորդ"].ToString(),
                                  Պատվեր = grp.Sum(r => string.IsNullOrEmpty(r["Պատվ. արժեք"].ToString()) ? 0 : Convert.ToDecimal(r["Պատվ. արժեք"])).ToString("#,0"),
                                  Վճար = grp.Sum(r => string.IsNullOrEmpty(r["Վճարել է"].ToString()) ? 0 : Convert.ToDecimal(r["Վճարել է"])).ToString("#,0"),
                                  Պարտք = grp.Sum(r =>
                                  {
                                      var input = string.IsNullOrEmpty(r["Պատվ. արժեք"].ToString()) ? 0 : Convert.ToDecimal(r["Պատվ. արժեք"]);
                                      var output = string.IsNullOrEmpty(r["Վճարել է"].ToString()) ? 0 : Convert.ToDecimal(r["Վճարել է"]);
                                      return input - output;
                                  }).ToString("#,0"),
                              };

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Պատվ. համ");
            dt1.Columns.Add("Հաճախորդ");
            dt1.Columns.Add("Պատվեր");
            dt1.Columns.Add("Վճար");
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
                    if (cell.ColumnIndex == 5 && string.IsNullOrWhiteSpace(cell.Value?.ToString()))
                    {
                        MessageBox.Show("Տվյալ տողը խմբագրման ենթակա չէ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    
                }
                EditPay editPay = new EditPay();
                editPay.Show();

                // Set the text property of txtEPidText in the EditPay form
                editPay.txtEPidText = selectedRow.Cells[0].Value?.ToString();
                editPay.dtpEPText = selectedRow.Cells[1].Value?.ToString();
                editPay.txtEPnumText = selectedRow.Cells[2].Value?.ToString();
                editPay.cmbEPclientText = selectedRow.Cells[3].Value?.ToString();
                editPay.txtEPvalText = selectedRow.Cells[5].Value?.ToString();

            }
        }


        //--------------------------------------------ՓՈԽԱՆՑՈՒՄ------------------------------------

        private void DesignDatagridviewsTA()
        {
            dgvInvoiceNONcreat.Columns["ԴՀ"].Visible = false;
            dgvInvoiceNONcreat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            dgvInvoiceNONcreat.Columns["Ամսաթիվ"].Width = 60;
            dgvInvoiceNONcreat.Columns["Ամսաթիվ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoiceNONcreat.Columns["Պատվ. համար"].Width = 80;
            dgvInvoiceNONcreat.Columns["Պատվ. համար"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            SqlDataAdapter da1 = new SqlDataAdapter("select * from TblDebtsTAinvCreate order by Ամսաթիվ asc", con);
            SqlDataAdapter da2 = new SqlDataAdapter("select * from TblDebtsTApayInv order by Հաճախորդ asc", con);

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
            dgvTransAction.Columns["Պատվ. համ"].Width = 80;
            dgvTransAction.Columns["Պատվ. համ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransAction.Columns["Արժեք"].Width = 80;
            dgvTransAction.Columns["Արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransAction.Columns["ԱԱՀ"].Width = 70;
            dgvTransAction.Columns["ԱԱՀ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransAction.Columns["Ընդհանուր"].Width = 90;
            dgvTransAction.Columns["Ընդհանուր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransAction.Columns["Վճարել է"].Width = 90;
            dgvTransAction.Columns["Վճարել է"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransAction.Columns["Մնացորդ"].Visible = false;

            dgvTransAction.EnableHeadersVisualStyles = false;
            dgvTransAction.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dgvTransAction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvTransAction.ColumnHeadersHeight = 30;

            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvInvoiceNONcreat.DataSource = dt1;

            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgvDebtsInvByOrders.DataSource = dt2;

        }
        //--------Դուրս գրել հաշիվ

        private void AddtoDebtsTAinvNonCr()
        {
            try
            {
                con.Open();
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblDebtsTAinvCreate", con);
                deleteCmd.ExecuteNonQuery();

                // Insert rows into TblDebtsTAinvCreate where ԴՀ is empty
                SqlCommand cmdt = new SqlCommand("INSERT INTO TblDebtsTAinvCreate(Ամսաթիվ, [Պատվ. համար], Հաճախորդ, Արժեք, ԱԱՀ, Ընդհանուր) " +
                                  "SELECT Ամսաթիվ, [Պատվ. համ], Հաճախորդ, Արժեք, ԱԱՀ, Ընդհանուր FROM TblOrderForDeptsTA " +
                                  "WHERE (ԴՀ IS NULL OR ԴՀ = '') AND (Ընդհանուր IS NOT NULL AND Ընդհանուր <> '')", con);
                cmdt.ExecuteNonQuery();
                con.Close();


                SqlDataAdapter da1t = new SqlDataAdapter("select * from TblDebtsTAinvCreate", con);
                DataTable dt1t = new DataTable();
                da1t.Fill(dt1t);
                dgvInvoiceNONcreat.DataSource = dt1t;

            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
        private void dgvInvoiceNONcreat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            InvoiceCreator invoiceCreator = new InvoiceCreator();
            invoiceCreator.Show();
            DataGridViewRow selectedRow = dgvInvoiceNONcreat.Rows[e.RowIndex];
            invoiceCreator.cmbICclientText = selectedRow.Cells[4].Value?.ToString();

            string condition = $"SomeColumn = '{invoiceCreator.cmbICclientText}'"; // Example condition
            invoiceCreator.PopulateDgvInvoiceNonCreate();
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

        //---------Վճարել հաշիվ

        
        private void AddtoDebtsTApayinv()
        {
            try
            {
                con.Open();
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblDebtsTApayInv", con);
                deleteCmd.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("Insert into TblDebtsTApayInv([Պատվ. համ], Հաճախորդ, Պատվեր, Վճար) select [Պատվ. համ], Հաճախորդ, Ընդհանուր, [Վճարել է] from TblOrderForDeptsTA", con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter da1 = new SqlDataAdapter("select * from TblDebtsTApayInv", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgvDebtsInvByClients.DataSource = dt1;
                dgvDebtsInvByOrders.DataSource = dt1;

            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
        public void PopulateUnitDebtTAbyclient()
        {
            con.Open();

            // Calculate total input for each product
            var groupedData = from row in dt.AsEnumerable()
                              group row by row.Field<string>("Հաճախորդ") into grp
                              select new
                              {
                                  Հաճախորդ = grp.Key,
                                  Պատվեր = grp.Sum(r => string.IsNullOrEmpty(r["Ընդհանուր"].ToString()) ? 0 : Convert.ToDecimal(r["Ընդհանուր"])).ToString("#,0"),
                                  Վճար = grp.Sum(r => string.IsNullOrEmpty(r["Վճարել է"].ToString()) ? 0 : Convert.ToDecimal(r["Վճարել է"])).ToString("#,0"),
                                  Պարտք = grp.Sum(r =>
                                  {
                                      var input = string.IsNullOrEmpty(r["Ընդհանուր"].ToString()) ? 0 : Convert.ToDecimal(r["Ընդհանուր"]);
                                      var output = string.IsNullOrEmpty(r["Վճարել է"].ToString()) ? 0 : Convert.ToDecimal(r["Վճարել է"]);
                                      return (input - output);
                                  }).ToString("#,0"),
                              };

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Հաճախորդ");
            dt2.Columns.Add("Պատվեր");
            dt2.Columns.Add("Վճար");
            dt2.Columns.Add("Պարտք");

            foreach (var item in groupedData)
            {
                dt2.Rows.Add(item.Հաճախորդ, item.Պատվեր, item.Վճար, item.Պարտք);
            }

            con.Close();

            dgvDebtsInvByClients.DataSource = dt2;

            // Create a new DataTable to store filtered rows
            DataTable filteredRows = dt2.Clone(); // Clone the structure of dt1

            // Iterate through dt1 and add rows where "Պարտք" column is not equal to 0 to filteredRows
            foreach (DataRow row in dt2.Rows)
            {
                if (Convert.ToDecimal(row["Պարտք"]) != 0)
                {
                    filteredRows.Rows.Add(row.ItemArray); // Add a copy of the row to filteredRows
                }
            }

            dgvDebtsInvByClients.DataSource = filteredRows;
        }
        private void AddtoDebtsTApayinvAll()
        {
            //try
            //{
            //    con.Open();
            //    SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblDebtsTApayInv", con);
            //    deleteCmd.ExecuteNonQuery();

            //    SqlCommand cmd = new SqlCommand("Insert into TblDebtsTApayInv([Պատվ. համ], Հաճախորդ, Պատվեր, Վճար) select [Պատվ. համ], Հաճախորդ, Ընդհանուր, [Վճարել է] from TblOrderForDeptsTA", con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();

            //    SqlDataAdapter da3 = new SqlDataAdapter("select * from TblDebtsTApayInv", con);
            //    DataTable dt3 = new DataTable();
            //    da3.Fill(dt3);
            //    dgvDebtsInvByOrders.DataSource = dt3;

            //}
            //catch (Exception ex)
            //{
            //    // Handle exceptions
            //}
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

        public void PopulateUnitDebtTAbyOrder()
        {
            con.Open();

            // Calculate total input for each product
            var groupedData = from row in dt.AsEnumerable()
                              group row by row.Field<string>("Պատվ. համ") into grp
                              select new
                              {
                                  ՊատվերիՀամար = grp.Key,
                                  Հաճախորդ = grp.FirstOrDefault().Field<string>("Հաճախորդ"),
                                  Պատվեր = grp.Sum(r => string.IsNullOrEmpty(r["Ընդհանուր"].ToString()) ? 0 : Convert.ToDecimal(r["Ընդհանուր"])).ToString("#,0"),
                                  Վճար = grp.Sum(r => string.IsNullOrEmpty(r["Վճարել է"].ToString()) ? 0 : Convert.ToDecimal(r["Վճարել է"])).ToString("#,0"),
                                  Պարտք = grp.Sum(r =>
                                  {
                                      var input = string.IsNullOrEmpty(r["Ընդհանուր"].ToString()) ? 0 : Convert.ToDecimal(r["Ընդհանուր"]);
                                      var output = string.IsNullOrEmpty(r["Վճարել է"].ToString()) ? 0 : Convert.ToDecimal(r["Վճարել է"]);
                                      return (input - output);
                                  }).ToString("#,0"),
                              };

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Պատվ. համ");
            dt2.Columns.Add("Հաճախորդ");
            dt2.Columns.Add("Պատվեր");
            dt2.Columns.Add("Վճար");
            dt2.Columns.Add("Պարտք");

            foreach (var item in groupedData)
            {
                dt2.Rows.Add(item.ՊատվերիՀամար, item.Հաճախորդ, item.Պատվեր, item.Վճար, item.Պարտք);
            }

            con.Close();

            dgvDebtsInvByOrders.DataSource = dt2;

            
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
    }
}
    

