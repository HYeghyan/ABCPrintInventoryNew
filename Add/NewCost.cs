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
            GetItemCode();
            PurchaiserComboboxComplate();
            ExpArticleComboboxComplate();
        }
        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblCosts order by Ամսաթիվ desc", con);
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
            Test newTest = new Test();
            txtNCid.Text = newTest.GetItemId();
        }
        private void GetItemCode()
        {
            string codePrefix = "ԾՀ";
            string codeNumber;

            con.Open();

            // Use CAST or TRY_CAST to extract the numeric part after the prefix for correct sorting
            cmd = new SqlCommand(@"SELECT MAX(CAST(SUBSTRING(Կոդ, LEN(@codePrefix) + 1, LEN(hh)) AS INT))
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
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Անուն) FROM TblEmployer", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNCemp.Items.Add(dr.GetValue(0).ToString());
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
            cmbNCemp.Text = "";
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
            GetDebtItemId();
            AddItemToCosts();
            AddItemToPurchDepts();
            ClearText();
            FillGrid();
            GetItemCode();
            GetDebtItemId();
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
                using (SqlCommand cmd1 = new SqlCommand("INSERT INTO TblCosts (hh, Կոդ, Ամսաթիվ, Գործողություն, [վ/ե], Կատարող, Հոդված, Արժեք, ԱԱՀ, Ընդհանուր, Մեկնաբանություն)" +
                        "VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9, @Column10, @Column11)", con))

                {
                    cmd1.Parameters.AddWithValue("@Column1", txtNCid.Text);
                    cmd1.Parameters.AddWithValue("@Column2", txtNCcod.Text);
                    cmd1.Parameters.AddWithValue("@Column3", date1);
                    cmd1.Parameters.AddWithValue("@Column4", txtAction.Text);
                    cmd1.Parameters.AddWithValue("@Column5", cmbNCpaySys.Text);
                    cmd1.Parameters.AddWithValue("@Column6", cmbNCemp.Text);
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
                    cmd1.Parameters.AddWithValue("@Column6", cmbNCemp.Text);
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

        //Խմբագրել
        private void dgvCost_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditgridviewItem(sender, e);
            btnAddban.Enabled = false;
        }
        int i;
        private void EditgridviewItem(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dgvCost.Rows[i];
            txtNCid.Text = row.Cells[0].Value.ToString();
            txtNCcod.Text = row.Cells[1].Value.ToString();
            dtpNO.Text = row.Cells[2].Value.ToString();
            cmbNCpaySys.Text = row.Cells[4].Value.ToString();
            cmbNCemp.Text = row.Cells[5].Value.ToString();
            cmbNCart.Text = row.Cells[6].Value.ToString();
            txtNCtotVal.Text = row.Cells[7].Value.ToString();
            txtNPvalNds.Text = row.Cells[8].Value.ToString();
            txtNPvalTotal.Text = row.Cells[9].Value.ToString();
            txtNCcom.Text = row.Cells[10].Value.ToString();
           
        }

        private void btnEditban_Click(object sender, EventArgs e)
        {
            EditCostDepts();
            EditCosts();
            ClearText();
            FillGrid();
            GetItemCode();
            GetDebtItemId();
            btnAddban.Enabled = true;
        }
        private void EditCostDepts()
        {
            try
            {
                DateTime date1 = dtpNO.Value.Date;
                con.Open();
                SqlCommand cmd1 = new SqlCommand("UPDATE TblDebtsControl SET Գործողություն = @ColumnT, [վ/ե] = @Column2,  Ամսաթիվ = @Column3, Կոդ = @Column4, Մատակարար = @Column5, Արժեք = @Column6, ԱԱՀ = @Column7, Ընդհանուր = @Column8, Մեկնաբանություն = @Column9 WHERE hh = @Column1", con);
                cmd1.Parameters.AddWithValue("@Column1", txtNCid.Text);
                cmd1.Parameters.AddWithValue("@ColumnT", txtAction.Text);
                cmd1.Parameters.AddWithValue("@Column2", cmbNCpaySys.Text);
                cmd1.Parameters.AddWithValue("@Column3", date1);
                cmd1.Parameters.AddWithValue("@Column4", txtNCcod.Text);
                cmd1.Parameters.AddWithValue("@Column5", cmbNCemp.Text);
                cmd1.Parameters.AddWithValue("@Column6", txtNCtotVal.Text);
                cmd1.Parameters.AddWithValue("@Column7", txtNPvalNds.Text);
                cmd1.Parameters.AddWithValue("@Column8", txtNPvalTotal.Text);
                cmd1.Parameters.AddWithValue("@Column9", txtNCcom.Text);

                cmd1.ExecuteNonQuery();
                int rowsAffected = cmd1.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void EditCosts()
        {
            try
            {
                DateTime date1 = dtpNO.Value.Date;
                con.Open();
                SqlCommand cmd1 = new SqlCommand("UPDATE TblCosts SET Գործողություն = @ColumnT, [վ/ե] = @Column2,  Ամսաթիվ = @Column3, Կոդ = @Column4, Կատարող = @Column5, Հոդված = @ColumnA, Արժեք = @Column6, ԱԱՀ = @Column7, Ընդհանուր = @Column8, Մեկնաբանություն = @Column9 WHERE hh = @Column1", con);
                cmd1.Parameters.AddWithValue("@Column1", txtNCid.Text);
                cmd1.Parameters.AddWithValue("@ColumnT", txtAction.Text);
                cmd1.Parameters.AddWithValue("@Column2", cmbNCpaySys.Text);
                cmd1.Parameters.AddWithValue("@Column3", date1);
                cmd1.Parameters.AddWithValue("@Column4", txtNCcod.Text);
                cmd1.Parameters.AddWithValue("@Column5", cmbNCemp.Text);
                cmd1.Parameters.AddWithValue("@ColumnA", cmbNCart.Text);
                cmd1.Parameters.AddWithValue("@Column6", txtNCtotVal.Text);
                cmd1.Parameters.AddWithValue("@Column7", txtNPvalNds.Text);
                cmd1.Parameters.AddWithValue("@Column8", txtNPvalTotal.Text);
                cmd1.Parameters.AddWithValue("@Column9", txtNCcom.Text);

                cmd1.ExecuteNonQuery();
                int rowsAffected = cmd1.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelban_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtNCid.Text))
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք հեռացնել պատվերը:", "Հեռացնել պատվերը", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();

                        // Delete from TblPurchasing
                        SqlCommand cmdForPurch = new SqlCommand("DELETE FROM TblCosts WHERE hh = @PurchId", con);
                        cmdForPurch.Parameters.AddWithValue("@PurchId", txtNCid.Text);
                        int rowsAffectedPurch = cmdForPurch.ExecuteNonQuery();

                        // Delete from TblDebts
                        SqlCommand cmdForDebts = new SqlCommand("DELETE FROM TblDebtsControl WHERE hh = @PurchId", con);
                        cmdForDebts.Parameters.AddWithValue("@PurchId", txtNCid.Text);
                        int rowsAffectedDepts = cmdForDebts.ExecuteNonQuery();

                        con.Close();

                        if (rowsAffectedPurch > 0 && rowsAffectedDepts > 0)
                        {
                            MessageBox.Show("Պատվերը հեռացվե՛ց");
                        }
                        else
                        {
                            MessageBox.Show("Հեռացման համար պատվեր չի ընտրվել:");
                        }

                        ClearText();
                        FillGrid();
                        GetItemCode();
                        GetDebtItemId();
                        btnAddban.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ընտրե՛ք տող ջնջելու համար:");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
