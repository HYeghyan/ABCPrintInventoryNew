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
    public partial class AddPartner : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public AddPartner()
        {
            InitializeComponent();
        }

        private void AddPartner_Load(object sender, EventArgs e)
        {

        }
        private void Cleartext()
        {
            txtClientAddress.Text = "";
            txtClientTel.Text = "";
            txtClientMail.Text = "";
            txtClientName.Text = "";
            txtClientNote.Text = "";
            txtClientLegName.Text = "";
            txtClientAVC.Text = "";
            cmbClientBank.Text = "Ընտրե՛ք բանկը";
            txtClientAcount.Text = "";
            txtClientContP.Text = "";
            txtClientTel2.Text = "";
            GetItemId();
            rbtPP.Checked = false;
            txtClientCod.Text = "";
        }
        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblClient order by hh desc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvClient.DataSource = dt;
            dgvClient.Columns["hh"].Width = 60;
            dgvClient.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Կոդ"].Width = 70;
            dgvClient.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Անուն"].Width = 200;
            dgvClient.Columns["Հասցե"].Width = 200;
            dgvClient.Columns["Հեռ. 1"].Width = 140;
            dgvClient.Columns["Հեռ. 1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Էլ. փոստ"].Width = 160;
            dgvClient.Columns["Իրավ. անուն"].Width = 160;
            dgvClient.Columns["ՀՎՀՀ"].Width = 100;
            dgvClient.Columns["ՀՎՀՀ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Բանկ"].Width = 120;
            dgvClient.Columns["Հաշվեհամար"].Width = 140;
            dgvClient.Columns["Հաշվեհամար"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Միջնորդ / Կոնտ. անձ"].Width = 180;
            dgvClient.Columns["Միջնորդ / Կոնտ. անձ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Հեռ. 2"].Width = 140;
            dgvClient.Columns["Հեռ. 2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Նշում"].Width = 200;
        }
        private void GetItemId()
        {
            string prodCatId;
            string query = "select hh from TblClient order by hh Desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                prodCatId = id.ToString("0");
            }
            else if (Convert.IsDBNull(dr))
            {
                prodCatId = "1";
            }
            else
            {
                prodCatId = "1";
            }

            con.Close();
            txtClientId.Text = prodCatId.ToString();
        }
    }
}
