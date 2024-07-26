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
            da = new SqlDataAdapter("select * from TblCashFlow order by Ամսաթիվ asc", con);

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

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Insert into TblCashFlow (hh, Գործողություն, Ամսաթիվ, Դրամարկղ, Մուտք, Ելք, Մեկնաբանություն) select hh, Գործողություն, Ամսաթիվ, Դրամարկղ, Մուտք, Ելք, Մեկնաբանություն from TblDebtsControl WHERE (Մուտք IS NOT NULL AND Մուտք != 0) OR (Ելք IS NOT NULL AND Ելք != 0)", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
