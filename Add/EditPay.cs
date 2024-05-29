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
    public partial class EditPay : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;

        public EditPay()
        {
            InitializeComponent();
        }
        public string txtEPidText
        {
            get { return txtEPid.Text; }
            set { txtEPid.Text = value; }
        }
        public string dtpEPText
        {
            get { return dtpEP.Text; }
            set { dtpEP.Text = value; }
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
        public string txtEPdeptText
        {
            get { return txtEPval.Text; }
            set { txtEPval.Text = value; }
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
                        cmd = new SqlCommand("DELETE FROM TblOrderForDepts WHERE hh = '" + txtEPid.Text + "'", con);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Վճարումը հեռացվե՛ց");
                        }
                        else
                        {
                            MessageBox.Show("Խմբագրման համար վճարման տող չի ընտրվել:");
                        }

                        //FillGrid();
                        //GetItemId();
                        //Cleartext();
                        //btnAdd.Enabled = true;
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
                    cmd = new SqlCommand("UPDATE TblOrderForDepts SET Ամսաթիվ = @Column1, [Պատվ. համ] = @Column2, Հաճախորդ = @Column3, [Վճարել է] = @Column5 WHERE hh = @ItemId", con);
                    cmd.Parameters.AddWithValue("@ItemId", txtEPid.Text);
                    DateTimePicker dtp = new DateTimePicker();
                    DateTime orderDate = dtp.Value;
                    cmd.Parameters.AddWithValue("@Column1", orderDate);
                    cmd.Parameters.AddWithValue("@Column2", txtEPnum.Text);
                    cmd.Parameters.AddWithValue("@Column3", cmbEPclient.Text);
                    cmd.Parameters.AddWithValue("@Column5", txtEPval.Text);

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
