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
    public partial class WalTransfer : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public WalTransfer()
        {
            InitializeComponent();
        }
        private void WalTransfer_Load(object sender, EventArgs e)
        {
            GetItemId();
            OutWalComboboxComplate();
            InWalComboboxComplate();
        }
        private void GetItemId()
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
            txtDebtId.Text = newCode;
        }
        private void OutWalComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Դրամարկղ) FROM TblWallet", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbWTout.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void InWalComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Դրամարկղ) FROM TblWallet", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbWTin.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }

        private void txtTotVal_TextChanged(object sender, EventArgs e)
        {
            
            if (decimal.TryParse(txtTotVal.Text, out decimal value))
            {
                txtTotVal.Text = value.ToString("N0");
                txtTotVal.SelectionStart = txtTotVal.Text.Length; // Set cursor to the end
            }
            else
            {
                // Handle invalid input
                txtTotVal.Text = string.Empty;
            }
        }
        private void btnNOAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
            this.Close();
        }
        private void AddItemToGridview()
        {
            if (cmbWTout.Text == "" || cmbWTin.Text == "" || txtTotVal.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    // Remove formatting (both commas and periods) before parsing
                    string unformattedValue = txtTotVal.Text.Replace(",", "").Replace(".", "");

                    // Convert the unformatted value from text to integer
                    int transferValue;
                    if (!int.TryParse(unformattedValue, out transferValue))
                    {
                        MessageBox.Show("Խնդրում ենք մուտքագրել վավեր թիվ Տեղափոխման Արժեք դաշտում:");
                        return;
                    }

                    con.Open();

                    // First INSERT statement
                    cmd = new SqlCommand("INSERT INTO TblDebtsControl (hh, Գործողություն, Ամսաթիվ, Դրամարկղ, Ելք, Մեկնաբանություն) VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6)", con);
                    DateTime orderDate = dtpWT.Value;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Column1", txtDebtId.Text);
                    cmd.Parameters.AddWithValue("@Column2", txtAction.Text);
                    cmd.Parameters.AddWithValue("@Column3", orderDate);
                    cmd.Parameters.AddWithValue("@Column4", cmbWTout.Text);
                    cmd.Parameters.AddWithValue("@Column5", transferValue);
                    cmd.Parameters.AddWithValue("@Column6", cmbWTcom.Text);
                    cmd.ExecuteNonQuery();

                    // Second INSERT statement
                    cmd = new SqlCommand("INSERT INTO TblDebtsControl (hh, Գործողություն, Ամսաթիվ, Դրամարկղ, Մուտք, Մեկնաբանություն) VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6)", con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Column1", txtDebtId.Text);
                    cmd.Parameters.AddWithValue("@Column2", txtAction.Text);
                    cmd.Parameters.AddWithValue("@Column3", orderDate);
                    cmd.Parameters.AddWithValue("@Column4", cmbWTin.Text);
                    cmd.Parameters.AddWithValue("@Column5", transferValue);
                    cmd.Parameters.AddWithValue("@Column6", cmbWTcom.Text);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
