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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ABCPrintInventory.Add
{
    public partial class Test : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            GetItemId();
            GetDebtId();
            BanComboboxComplate();
        }
        private void GetItemId()
        {
            string codePrefix = "ՊԿ";
            string codeNumber;

            con.Open();

            cmd = new SqlCommand("SELECT MAX(hh) FROM TblDebtsControl WHERE hh LIKE @codePrefix", con);
            cmd.Parameters.AddWithValue("@codePrefix", codePrefix + "%");
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result != DBNull.Value && result != null)
            {
                string lastCode = result.ToString();
                string lastNumberStr = lastCode.Substring(codePrefix.Length);
                int lastNumber = int.Parse(lastNumberStr);
                codeNumber = (lastNumber + 1).ToString("00");
            }
            else
            {
                codeNumber = "01";
            }

            string newCode = codePrefix + codeNumber;
            txtID.Text = newCode;
        }
        private int currentCodeNumber = 3;
        private void GetDebtId()
        {
            string codePrefix = "300924-";
            string codeNumber = currentCodeNumber.ToString("00"); // Convert current number to a 2-digit string

            string newCode = codePrefix + codeNumber;
            txtCode.Text = newCode;

            currentCodeNumber++;
        }
        private void BanComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Անուն) FROM TblClient", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNOclient.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void Cleartext()
        {
            cmbNOclient.Text = "";
            txtDebt.Text = "";
        }
        private void btnNOAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
            GetItemId();
            GetDebtId();
        }
        private void AddItemToGridview()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO TblDebtsControl (hh, Գործողություն, [վ/ե], Ամսաթիվ, Կոդ, Հաճախորդ, Արժեք) VALUES (@ColumnID, @ColumnAC, @ColumnP, @Column1, @Column2, @Column3, @Column4)", con);
                DateTime selectedDateo = dtpNO.Value;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ColumnID", txtID.Text);
                cmd.Parameters.AddWithValue("@ColumnAC", txtAc.Text);
                cmd.Parameters.AddWithValue("@ColumnP", cmbPaySys.Text);
                cmd.Parameters.AddWithValue("@Column1", selectedDateo);
                cmd.Parameters.AddWithValue("@Column2", txtCode.Text);
                cmd.Parameters.AddWithValue("@Column3", cmbNOclient.Text);
                cmd.Parameters.AddWithValue("@Column4", txtDebt.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Cleartext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

}
