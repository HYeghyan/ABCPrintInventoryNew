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
    public partial class PayPurchDebts : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public PayPurchDebts()
        {
            InitializeComponent();
        }
        private void PayPurchDebts_Load(object sender, EventArgs e)
        {
            GetDebtItemId();            
            ProdComboboxComplate();
            GetRestVal();
            PopulateDgvClientDebtsOrders();
        }
        public string txtCodText
        {
            get { return txtPDCod.Text; }
            set { txtPDCod.Text = value; }
        }
        public string txtPDInvComText
        {
            get { return txtPDInvCom.Text; }
            set { txtPDInvCom.Text = value; }
        }
        public string txtDebtIdText
        {
            get { return txtDebtId.Text; }
            set { txtDebtId.Text = value; }
        }
        private void GetDebtItemId()
        {
            Test newTest = new Test();
            txtDebtId.Text = newTest.GetItemId();
        }

        //Դրամարկղի կոմբոն
        private void ProdComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Դրամարկղ) FROM TblWallet", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbPDwallet.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        public void PopulateDgvClientDebtsOrders()
        {
            try
            {
                con.Open();

                // Query to get the relevant record based on Կոդ
                SqlCommand cmd = new SqlCommand("SELECT Կոդ, [վ/ե], Մատակարար, Պատվեր, Ելք, Դրամարկղ, Մեկնաբանություն FROM TblPurchForDebts WHERE Կոդ = @Cell2Value", con);
                cmd.Parameters.AddWithValue("@Cell2Value", txtPDCod.Text);

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // Check if there is any data
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Set the value of cmbPaySys.Text to the value in the վ/ե column
                    cmbPaySys.Text = row["վ/ե"].ToString();

                    // You can set other values as well (e.g. Purchaiser, Debts)
                    cmbPDpurch.Text = row["Մատակարար"].ToString();
                    decimal totalOrderAmount = row["Պատվեր"] != DBNull.Value ? Convert.ToDecimal(row["Պատվեր"]) : 0;
                    decimal totalPaymentAmount = row["Ելք"] != DBNull.Value ? Convert.ToDecimal(row["Ելք"]) : 0;
                    decimal remainingBalance = totalOrderAmount - totalPaymentAmount;
                    txtPDdebts.Text = remainingBalance.ToString("N0");
                }
                else
                {
                    MessageBox.Show("No data found for the provided code.");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Վճարում և մնացորդ
        private void cbPDpayall_CheckedChanged(object sender, EventArgs e)
        {
            if(cbPDpayall.Checked == true)
            {
                txtPDpay.Text = txtPDdebts.Text.Replace(",", "").Replace(".", "");
            }
            else
            {
                txtPDpay.Text = "";
            }
        }
        private void CaounPurchDeptRest()
        {
            if (!string.IsNullOrEmpty(txtPDdebts.Text) && !string.IsNullOrEmpty(txtPDpay.Text))
            {
                if (decimal.TryParse(txtPDdebts.Text, out decimal debt) && decimal.TryParse(txtPDpay.Text, out decimal pay))
                {
                    decimal rest = debt - pay;
                    txtPDrest.Text = rest.ToString("N0");
                }
            }
        }
        private void RestResolutionTextChanged(object sender, EventArgs e)
        {
            txtPDpay.TextChanged -= RestResolutionTextChanged;

            // Format the input as a number with commas
            if (decimal.TryParse(txtPDpay.Text, out decimal pay))
            {
                txtPDpay.Text = pay.ToString("N0");
                txtPDpay.SelectionStart = txtPDpay.Text.Length; // Set cursor to the end
            }

            // Re-add the TextChanged event handler
            txtPDpay.TextChanged += RestResolutionTextChanged;

            // Call the CaounPurchDeptRest method to calculate the rest
            CaounPurchDeptRest();
        }
        private void GetRestVal()
        {
            txtPDpay.TextChanged += RestResolutionTextChanged;
        }

        private void btnNOAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
            this.Close();
        }
        private void AddItemToGridview()
        {
            if (cmbPDwallet.Text == "" || txtPDpay.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    DateTime orderDate = dtpPD.Value.Date;

                    cmd = new SqlCommand("INSERT INTO TblDebtsControl (hh, Գործողություն, [վ/ե], Ամսաթիվ, Կոդ, Մատակարար, Ելք, Դրամարկղ, Մեկնաբանություն) VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9)", con);
                    // Get DateTimePicker value outside the loop
                    //DateTimePicker dtp = new DateTimePicker();
                    
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Column1", txtDebtId.Text);
                    cmd.Parameters.AddWithValue("@Column2", txtPDInvAc.Text);
                    cmd.Parameters.AddWithValue("@Column3", cmbPaySys.Text);
                    cmd.Parameters.AddWithValue("@Column4", orderDate);
                    cmd.Parameters.AddWithValue("@Column5", txtPDCod.Text);
                    cmd.Parameters.AddWithValue("@Column6", cmbPDpurch.Text);
                    cmd.Parameters.AddWithValue("@Column7", txtPDpay.Text.Replace(",", "").Replace(".", ""));
                    cmd.Parameters.AddWithValue("@Column8", cmbPDwallet.Text);
                    cmd.Parameters.AddWithValue("@Column9", txtPDInvCom.Text);
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
