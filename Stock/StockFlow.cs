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
    public partial class StockFlow : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public StockFlow()
        {
            InitializeComponent();
        }

        private void StockFlow_Load(object sender, EventArgs e)
        {
            FillGridBan();
            AddtoBanGridView();
            PopulateUnitPriceGridView();
            PopulateUnitPriceGridViewLyuv();
            AddtoStandGridView();
            PopulateUnitPriceGridViewStand();
        }
        private void FillGridBan()
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from TblStockFlow order by Ամսաթիվ asc", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStockFlow.DataSource = dt;
                
            }
        }

        //Պաստառ և կոճգամ
        private void AddtoBanGridView()
        {
            try
            {
                con.Open();
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblStockBan", con);
                deleteCmd.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("Insert into TblStockBan(Նյութ, [ՔՄ մուտք], [ՔՄ տպ], [Խոտան քմ], [ՔՄ արժեք]) " +
                    "select Նյութ, [ՔՄ մուտք], [ՔՄ տպ], [Խոտան քմ], [ՔՄ արժեք] from TblStockFlow WHERE Նյութ IS NOT NULL AND Նյութ <> ''", con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter da1 = new SqlDataAdapter("select * from TblStockBan", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgvBannerStock.DataSource = dt1;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
        public void PopulateUnitPriceGridView()
        {
            const string StockBanQuery =
        "SELECT sb.*, mb.hh FROM TblStockBan sb " +
        "JOIN TblMaterialBan mb ON sb.Նյութ = mb.Name " +
        "ORDER BY mb.hh ASC";

            const string ColumnItem = "Նյութ";
            const string ColumnIn = "ՔՄ մուտք";
            const string ColumnPrint = "ՔՄ տպ";
            const string ColumnWaste = "Խոտան քմ";
            const string ColumnValue = "ՔՄ արժեք";

            try
            {
                using (var connection = new SqlConnection(con.ConnectionString))
                {
                    connection.Open();

                    var dataAdapter = new SqlDataAdapter(StockBanQuery, connection);
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    var groupedData = from row in dataTable.AsEnumerable()
                                      group row by row.Field<string>(ColumnItem) into grp
                                      let inSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnIn].ToString()) ? 0 : Convert.ToDecimal(r[ColumnIn]))
                                      let printSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnPrint].ToString()) ? 0 : Convert.ToDecimal(r[ColumnPrint]))
                                      let wasteSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnWaste].ToString()) ? 0 : Convert.ToDecimal(r[ColumnWaste]))
                                      let edgeFactor = 1.15m
                                      let outputSum = printSum * edgeFactor + wasteSum
                                      let restSum = inSum - outputSum
                                      let valueSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnValue].ToString().Trim()) ? 0 : Convert.ToDecimal(r[ColumnValue].ToString().Trim()))
                                      let avgInSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnIn].ToString().Trim()) ? 0 : Convert.ToDecimal(r[ColumnIn].ToString().Trim()))
                                      let avgValue = avgInSum == 0 ? 0 : valueSum / avgInSum
                                      let restValue = restSum * avgValue
                                      select new
                                      {
                                          Item = grp.Key,
                                          InSum = inSum,
                                          PrintSum = printSum,
                                          WasteSum = wasteSum,
                                          OutputSum = outputSum.ToString("0.00"),
                                          RestSum = restSum.ToString("0.00"),
                                          ValueSum = valueSum.ToString("#,0"),
                                          AvgPrice = avgValue.ToString("0.00"),
                                          RestValue = restValue.ToString("0.00")
                                      };

                    var resultTable = new DataTable();
                    resultTable.Columns.Add(ColumnItem, typeof(string));
                    resultTable.Columns.Add(ColumnIn);
                    resultTable.Columns.Add(ColumnPrint);
                    resultTable.Columns.Add(ColumnWaste);
                    resultTable.Columns.Add("ՔՄ ելք");
                    resultTable.Columns.Add("ՔՄ մնացորդ");
                    resultTable.Columns.Add(ColumnValue);
                    resultTable.Columns.Add("ՔՄ միավորի գին");
                    resultTable.Columns.Add("ՔՄ մնացորդի արժեք");

                    foreach (var item in groupedData)
                    {
                        resultTable.Rows.Add(item.Item, item.InSum, item.PrintSum, item.WasteSum, item.OutputSum, item.RestSum, item.ValueSum, item.AvgPrice, item.RestValue);
                    }

                    dgvBannerStock.DataSource = resultTable;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                // e.g., log the exception message
                Console.WriteLine(ex.Message);
            }
        }
        public DataGridView GetStockGridView()
        {
            return dgvBannerStock;
        }

        public void PopulateUnitPriceGridViewLyuv()
        {
            const string StockFlowQuery = "SELECT * FROM TblStockFlow";
            const string ColumnIn = "Կոճգամ մուտք";
            const string ColumnOut = "Կոճգամ ելք";
            const string ColumnValue = "Կոճգամ արժեք";

            try
            {
                using (var connection = new SqlConnection(con.ConnectionString))
                {
                    connection.Open();

                    var dataAdapter = new SqlDataAdapter(StockFlowQuery, connection);
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    var groupedData = from row in dataTable.AsEnumerable()
                                      group row by 1 into grp
                                      let inSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnIn].ToString()) ? 0 : Convert.ToDecimal(r[ColumnIn]))
                                      let outSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnOut].ToString()) ? 0 : Convert.ToDecimal(r[ColumnOut]))
                                      let valueSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnValue].ToString().Trim()) ? 0 : Convert.ToDecimal(r[ColumnValue].ToString().Trim()))
                                      let avgIn = grp.Sum(r => string.IsNullOrEmpty(r[ColumnIn].ToString().Trim()) ? 0 : Convert.ToDecimal(r[ColumnIn].ToString().Trim()))
                                      let midValue = avgIn == 0 ? 0 : valueSum / avgIn
                                      select new
                                      {
                                          InSum = inSum,
                                          OutSum = outSum,
                                          RestSum = inSum - outSum,
                                          ValueSum = valueSum,
                                          AvgPrice = midValue.ToString("0.00"),
                                          RestValue = (inSum - outSum) * midValue
                                      };

                    var result = groupedData.FirstOrDefault();
                    if (result != null)
                    {
                        txtLyuvIn.Text = result.InSum.ToString();
                        txtLyuvOut.Text = result.OutSum.ToString();
                        txtLyuvRest.Text = result.RestSum.ToString();
                        txtLyuvTotVal.Text = result.ValueSum.ToString("#,0");
                        txtLyuvAvpr.Text = result.AvgPrice;
                        txtRestVal.Text = result.RestValue.ToString("#,0");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                // e.g., log the exception message
                Console.WriteLine(ex.Message);
            }
        }
        //Վահանակ
        private void AddtoStandGridView()
        {
            try
            {
                con.Open();
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblStockStand", con);
                deleteCmd.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("Insert into TblStockStand(Վահանակ, [Վ մուտք], [Վ ելք], [Վ արժեք]) " +
                    "select Վահանակ, [Վ մուտք], [Վ ելք], [Վ արժեք] from TblStockFlow WHERE Վահանակ IS NOT NULL AND Վահանակ <> ''", con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter da1 = new SqlDataAdapter("select * from TblStockStand", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgvStandStock.DataSource = dt1;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }
        public void PopulateUnitPriceGridViewStand()
        {
            const string StockStandQuery = "SELECT * FROM TblStockStand";
            const string ColumnItem = "Վահանակ";
            const string ColumnIn = "Վ մուտք";
            const string ColumnOut = "Վ ելք";
            const string ColumnValue = "Վ արժեք";

            try
            {
                using (var connection = new SqlConnection(con.ConnectionString))
                {
                    connection.Open();

                    var dataAdapter = new SqlDataAdapter(StockStandQuery, connection);
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    var groupedData = from row in dataTable.AsEnumerable()
                                      group row by row.Field<string>(ColumnItem) into grp
                                      let inSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnIn].ToString()) ? 0 : Convert.ToDecimal(r[ColumnIn]))
                                      let outSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnOut].ToString()) ? 0 : Convert.ToDecimal(r[ColumnOut]))
                                      let valueSum = grp.Sum(r => string.IsNullOrEmpty(r[ColumnValue].ToString().Trim()) ? 0 : Convert.ToDecimal(r[ColumnValue].ToString().Trim()))
                                      let avgIn = grp.Sum(r => string.IsNullOrEmpty(r[ColumnIn].ToString().Trim()) ? 0 : Convert.ToDecimal(r[ColumnIn].ToString().Trim()))
                                      let midValue = avgIn == 0 ? 0 : valueSum / avgIn
                                      select new
                                      {
                                          Item = grp.Key,
                                          InSum = inSum,
                                          OutSum = outSum,
                                          RestSum = (inSum - outSum).ToString("0.00"),
                                          ValueSum = valueSum.ToString("#,0"),
                                          AvgPrice = midValue.ToString("0.00"),
                                          RestValue = (inSum - outSum) * midValue
                                      };

                    var resultTable = new DataTable();
                    resultTable.Columns.Add(ColumnItem, typeof(string));
                    resultTable.Columns.Add(ColumnIn);
                    resultTable.Columns.Add(ColumnOut);
                    resultTable.Columns.Add("Վ մնացորդ");
                    resultTable.Columns.Add(ColumnValue);
                    resultTable.Columns.Add("Վ միավորի գին");
                    resultTable.Columns.Add("Վ մնացորդի արժեք");

                    foreach (var item in groupedData)
                    {
                        resultTable.Rows.Add(item.Item, item.InSum, item.OutSum, item.RestSum, item.ValueSum, item.AvgPrice, item.RestValue);
                    }

                    dgvStandStock.DataSource = resultTable;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                // e.g., log the exception message
                Console.WriteLine(ex.Message);
            }
        }
        public DataGridView GetStockGridViewStand()
        {
            return dgvStandStock;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand deleteCmd = new SqlCommand("DELETE FROM TblStockFlow where Կոդ = N'ՍՄ01'  ", con);
            deleteCmd.ExecuteNonQuery();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            StockFlow_Load(sender, e);
        }
    }
}
