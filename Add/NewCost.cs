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
    public partial class NewCost : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public NewCost()
        {
            InitializeComponent();
        }

        private void NewCost_Load(object sender, EventArgs e)
        {
            FillGrid();
            GetDebtItemId();
            GetDebtItemCode();
            PurchaiserComboboxComplate();
            ExpArticleComboboxComplate();
        }
        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblCosts order by Կոդ asc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvCost.DataSource = dt;
            dgvCost.Columns["hh"].Visible = false;
            dgvCost.Columns["Գործողություն"].Visible = false;
            dgvCost.Columns["Կոդ"].Width = 70;
            dgvCost.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        private void GetDebtItemId()
        {
            string codePrefix = "ՊԿ";
            string codeNumber;

            con.Open();

            // Use CAST or TRY_CAST to extract the numeric part after the prefix for correct sorting
            cmd = new SqlCommand(@"SELECT MAX(CAST(SUBSTRING(hh, LEN(@codePrefix) + 1, LEN(hh)) AS INT))
                                FROM TblDebtsControl WHERE hh LIKE @codePrefix + '%'", con);

            cmd.Parameters.AddWithValue("@codePrefix", codePrefix);
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result != DBNull.Value && result != null)
            {
                // Increment the numeric part
                int lastNumber = Convert.ToInt32(result);
                codeNumber = (lastNumber + 1).ToString();
            }
            else
            {
                // Start from 1 if no records are found
                codeNumber = "01";
            }

            // Combine the prefix and the incremented number
            string newCode = codePrefix + codeNumber;
            txtNCid.Text = newCode;
        }
        private void GetDebtItemCode()
        {
            string codePrefix = "ԾՀ";
            string codeNumber;

            con.Open();

            // Use CAST or TRY_CAST to extract the numeric part after the prefix for correct sorting
            cmd = new SqlCommand(@"SELECT MAX(CAST(SUBSTRING(hh, LEN(@codePrefix) + 1, LEN(hh)) AS INT))
                                FROM TblCosts WHERE Կոդ LIKE @codePrefix + '%'", con);

            cmd.Parameters.AddWithValue("@codePrefix", codePrefix);
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result != DBNull.Value && result != null)
            {
                // Increment the numeric part
                int lastNumber = Convert.ToInt32(result);
                codeNumber = (lastNumber + 1).ToString();
            }
            else
            {
                // Start from 1 if no records are found
                codeNumber = "01";
            }

            // Combine the prefix and the incremented number
            string newCode = codePrefix + codeNumber;
            txtNCcod.Text = newCode;
        }
        //-------Կոմբոները և պանելների փոփոխությունները-----
        private void PurchaiserComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Անվանում) FROM TblPurchaiser", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNCpur.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void ExpArticleComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Հոդված) FROM TblExpArticle", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNCart.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void ClearText()
        {
            txtNCcod.Text = "";
            cmbNCart.Text = "";
            cmbNCpur.Text = "";
            cmbNCpaySys.Text = "Կ";
            txtNCtotVal.Text = "";
            txtNPvalNds.Text = "";
            txtNPvalTotal.Text = "";
            txtNCcom.Text = "";
            txtNCid.Text = "";
        }

        //------------Ավելացնել, խմբագրել, հեռացնել

        private void btnAddban_Click(object sender, EventArgs e)
        {
            AddItemToCosts();
            AddItemToPurchDepts();
            ClearText();
            FillGrid();
        }
        public void AddItemToCosts()
        {
            if (cmbNCart.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը մուտքագրված չեն");
                return;
            }

            try
            {
                con.Open();

                DateTime date1 = dtpNO.Value.Date;

                // First insert command
                using (SqlCommand cmd1 = new SqlCommand("INSERT INTO TblCosts (hh, Կոդ, Ամսաթիվ, Գործողություն, [վ/ե], Գործընկեր, Հոդված, Արժեք, ԱԱՀ, Ընդհանուր, Մեկնաբանություն)" +
                        "VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9, @Column10, @Column11)", con))

                {
                    cmd1.Parameters.AddWithValue("@Column1", txtNCid.Text);
                    cmd1.Parameters.AddWithValue("@Column2", txtNCcod.Text);
                    cmd1.Parameters.AddWithValue("@Column3", date1);
                    cmd1.Parameters.AddWithValue("@Column4", txtAction.Text);
                    cmd1.Parameters.AddWithValue("@Column5", cmbNCpaySys.Text);
                    cmd1.Parameters.AddWithValue("@Column6", cmbNCpur.Text);
                    cmd1.Parameters.AddWithValue("@Column7", cmbNCart.Text);
                    cmd1.Parameters.AddWithValue("@Column8", txtNCtotVal.Text);
                    cmd1.Parameters.AddWithValue("@Column9", txtNPvalNds.Text);
                    cmd1.Parameters.AddWithValue("@Column10", txtNPvalTotal.Text);
                    cmd1.Parameters.AddWithValue("@Column11", txtNCcom.Text);

                    cmd1.ExecuteNonQuery();
                }

                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        public void AddItemToPurchDepts()
        {
            if (cmbNCart.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը մուտքագրված չեն");
                return;
            }

            try
            {
                con.Open();

                DateTime date1 = dtpNO.Value.Date;

                // First insert command
                using (SqlCommand cmd1 = new SqlCommand("INSERT INTO TblDebtsControl (hh, Գործողություն, [վ/ե], Ամսաթիվ, Կոդ, Մատակարար, Արժեք, ԱԱՀ, Ընդհանուր, Մեկնաբանություն)" +
                        "VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9, @Column10)", con))

                {
                    cmd1.Parameters.AddWithValue("@Column1", txtNCid.Text);
                    cmd1.Parameters.AddWithValue("@Column2", txtAction.Text);
                    cmd1.Parameters.AddWithValue("@Column3", cmbNCpaySys.Text);
                    cmd1.Parameters.AddWithValue("@Column4", date1);
                    cmd1.Parameters.AddWithValue("@Column5", txtNCcod.Text);
                    cmd1.Parameters.AddWithValue("@Column6", cmbNCpur.Text);
                    cmd1.Parameters.AddWithValue("@Column7", txtNCtotVal.Text);
                    cmd1.Parameters.AddWithValue("@Column8", txtNPvalNds.Text);
                    cmd1.Parameters.AddWithValue("@Column9", txtNPvalTotal.Text);
                    cmd1.Parameters.AddWithValue("@Column10", txtNCcom.Text);

                    cmd1.ExecuteNonQuery();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
