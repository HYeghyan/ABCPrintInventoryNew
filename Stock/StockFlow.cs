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
            FillGrid();
        }
        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblStockFlow order by hh asc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvBannerStock.DataSource = dt;
            dgvBannerStock.Columns["hh"].Width = 60;
            dgvBannerStock.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        
    }
}
