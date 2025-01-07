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
using static System.Runtime.CompilerServices.RuntimeHelpers;

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
            ButtonsAvailabel();
        }
        private void GetItemId()
        {
            string codePrefix = "ՊԿ";
            string baseCodeNumber;

            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon))
                {
                    con.Open();
                    string query = @"SELECT MAX(TRY_CAST(SUBSTRING(hh, LEN(@codePrefix) + 1, LEN(hh)) AS INT))
                             FROM TblDebtsControl 
                             WHERE hh LIKE @codePrefix + '%'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@codePrefix", codePrefix);
                        object lastCodeNumber = cmd.ExecuteScalar();

                        if (lastCodeNumber != DBNull.Value && lastCodeNumber != null)
                        {
                            int lastNumber = Convert.ToInt32(lastCodeNumber);
                            baseCodeNumber = (lastNumber + 1).ToString("D2");
                        }
                        else
                        {
                            baseCodeNumber = "01"; // Start sequence if no records exist
                        }
                    }
                }

                // Generate IDs
                string newCode = codePrefix + baseCodeNumber; 
                string newCodeWithSuffix = newCode + "a";     

                // Assign to text boxes
                txtDebtIdexit.Text = newCode;
                txtDebtIdenter.Text = newCodeWithSuffix;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    cmd.Parameters.AddWithValue("@Column1", txtDebtIdexit.Text);
                    cmd.Parameters.AddWithValue("@Column2", txtAction.Text);
                    cmd.Parameters.AddWithValue("@Column3", orderDate);
                    cmd.Parameters.AddWithValue("@Column4", cmbWTout.Text);
                    cmd.Parameters.AddWithValue("@Column5", transferValue);
                    cmd.Parameters.AddWithValue("@Column6", cmbWTcom.Text);
                    cmd.ExecuteNonQuery();

                    // Second INSERT statement
                    cmd = new SqlCommand("INSERT INTO TblDebtsControl (hh, Գործողություն, Ամսաթիվ, Դրամարկղ, Մուտք, Մեկնաբանություն) VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6)", con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Column1", txtDebtIdenter.Text);
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

        //Խմբագրել
        public string dtpWText
        {
            get { return dtpWT.Text; }
            set { dtpWT.Text = value; }
        }
        public string cmbWToutText
        {
            get { return cmbWTout.Text; }
            set { cmbWTout.Text = value; }
        }
        public string cmbWTinText
        {
            get { return cmbWTin.Text; }
            set { cmbWTin.Text = value; }
        }
        public string txtTotValText
        {
            get { return txtTotVal.Text; }
            set { txtTotVal.Text = value; }
        }
        public string txtDebtIdexitText
        {
            get { return txtDebtIdexit.Text; }
            set { txtDebtIdexit.Text = value; }
        }
        public string txtDebtIdenterText
        {
            get { return txtDebtIdenter.Text; }
            set { txtDebtIdenter.Text = value; }
        }
        public string txtForEditText
        {
            get { return txtForEdit.Text; }
            set { txtForEdit.Text = value; }
        }
        public string cmbWTcomText
        {
            get { return cmbWTcom.Text; }
            set { cmbWTcom.Text = value; }
        }
        public void ButtonsAvailabel()
        {
            if (txtForEdit.Text == "Խ")
            {
                btnNOAdd.Enabled = false;
                btnNOEdit.Enabled = true;
                btnNODel.Enabled = true;
            }
            else if (txtForEdit.Text == "")
            {
                btnNOAdd.Enabled = true;
                btnNOEdit.Enabled = false;
                btnNODel.Enabled = false;
            }
        }
        private void btnNOEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDebtIdexit.Text == "" || txtDebtIdenter.Text == "" || cmbWTout.Text == "" || cmbWTin.Text == "")
                {
                    MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
                    return; // Exit the method if required fields are not filled
                }

                con.Open();

                cmd = new SqlCommand("DELETE FROM TblDebtsControl WHERE hh = @hhExit", con);
                cmd.Parameters.AddWithValue("@hhExit", txtDebtIdexit.Text);
                int rowsAffectedExit = cmd.ExecuteNonQuery();

                // Delete where hh matches txtDebtIdenter
                cmd = new SqlCommand("DELETE FROM TblDebtsControl WHERE hh = @hhEnter", con);
                cmd.Parameters.AddWithValue("@hhEnter", txtDebtIdenter.Text);
                int rowsAffectedEnter = cmd.ExecuteNonQuery();
                con.Close();

                AddItemToGridview();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Սխալ: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        //Ջնջել       
        private void btnNODel_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbWTout.Text != "" && cmbWTin.Text != "")
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք հեռացնել Վճարումը:", "Հեռացնել վճարումը", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();

                        // Delete where hh matches txtDebtIdexit
                        cmd = new SqlCommand("DELETE FROM TblDebtsControl WHERE hh = @hhExit", con);
                        cmd.Parameters.AddWithValue("@hhExit", txtDebtIdexit.Text);
                        int rowsAffectedExit = cmd.ExecuteNonQuery();

                        //Delete where hh matches txtDebtIdenter
                       cmd = new SqlCommand("DELETE FROM TblDebtsControl WHERE hh = @hhEnter", con);
                        cmd.Parameters.AddWithValue("@hhEnter", txtDebtIdenter.Text);
                        int rowsAffectedEnter = cmd.ExecuteNonQuery();

                        con.Close();

                        // Notify user
                        if (rowsAffectedExit > 0 && rowsAffectedEnter > 0)
                        {
                            MessageBox.Show("Վճարումը հեռացվե՛ց");
                        }
                        else
                        {
                            MessageBox.Show("Հեռացման համար տող չի ընտրվել:");
                        }
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ընտրե՛ք վճարում ջնջելու համար:");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        
    }
}
