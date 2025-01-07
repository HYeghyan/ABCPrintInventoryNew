using Microsoft.Office.Interop.Excel;
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
    public partial class EditPurchPay : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        public EditPurchPay()
        {
            InitializeComponent();
        }
        public string txtEPidText
        {
            get { return txtEPid.Text; }
            set { txtEPid.Text = value; }
        }
        public string cmbPaySysText
        {
            get { return cmbPaySys.Text; }
            set { cmbPaySys.Text = value; }
        }
        public string dtpEPText
        {
            get { return dtpEP.Value.ToString("yyyy-MM-dd"); }  // Customize the format as needed
            set
            {
                DateTime dateValue;
                if (DateTime.TryParse(value, out dateValue))
                {
                    dtpEP.Value = dateValue;  // Set the date value if parsing is successful
                }
                else
                {
                    // Handle invalid date string if needed
                    throw new ArgumentException("Invalid date format.");
                }
            }
        }
        public string txtEPnumText
        {
            get { return txtEPnum.Text; }
            set { txtEPnum.Text = value; }
        }
        public string cmbEPclientText
        {
            get { return cmbEPclient.Text; }
            set { cmbEPclient.Text = value; }
        }
        public string txtEPvalText
        {
            get { return txtEPval.Text; }
            set { txtEPval.Text = value; }
        }
        public string txtEPwallet
        {
            get { return cmbEPWallet.Text; }
            set { cmbEPWallet.Text = value; }
        }
        public string txtPDInvComText
        {
            get { return txtPDInvCom.Text; }
            set { txtPDInvCom.Text = value; }
        }

        private void btnNOEdit_Click(object sender, EventArgs e)
        {
            if (txtEPid.Text == "" || txtEPnum.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE TblDebtsControl SET Ամսաթիվ = @Column1, Կոդ = @Column2, Մատակարար = @Column3, Ելք = @Column5, Դրամարկղ = @Column6, Մեկնաբանություն = @Column7  WHERE hh = @ItemId", con);
                    cmd.Parameters.AddWithValue("@ItemId", txtEPid.Text);
                    DateTimePicker dtp = new DateTimePicker();
                    DateTime orderDate = dtpEP.Value;
                    cmd.Parameters.AddWithValue("@Column1", orderDate);
                    cmd.Parameters.AddWithValue("@Column2", txtEPnum.Text);
                    cmd.Parameters.AddWithValue("@Column3", cmbEPclient.Text);
                    cmd.Parameters.AddWithValue("@Column5", txtEPval.Text);
                    cmd.Parameters.AddWithValue("@Column6", cmbEPWallet.Text);
                    cmd.Parameters.AddWithValue("@Column7", txtPDInvCom.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Վճարումըը թարմացվե՛ց:");
                    }
                    else
                    {
                        MessageBox.Show("Խմբագրման համար ընտրե՛ք տող:");
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnNODel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEPid.Text != "")
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք հեռացնել Վճարումը:", "Հեռացնել վճարումը", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();
                        cmd = new SqlCommand("DELETE FROM TblDebtsControl WHERE hh = @hh", con);
                        cmd.Parameters.AddWithValue("@hh", txtEPid.Text.Replace(".", ""));
                        int rowsAffected = cmd.ExecuteNonQuery();

                        con.Close();

                        if (rowsAffected > 0)
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
        }
    }
}
