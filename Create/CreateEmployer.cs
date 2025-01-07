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

namespace ABCPrintInventory.Create
{
    public partial class CreateEmployer : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public CreateEmployer()
        {
            InitializeComponent();
        }

        private void CreateEmployer_Load(object sender, EventArgs e)
        {
            FillGrid();
            GetItemId();
            Designe();
        }
        private void Designe()
        {
            dgvEmp.EnableHeadersVisualStyles = false;
            dgvEmp.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;

            btnEdit.TabStop = false;
            btnDel.TabStop = false;
            dgvEmp.TabStop = false;
            btnExToEx.TabStop = false;
        }
        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblEmployer order by hh asc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvEmp.DataSource = dt;
            dgvEmp.Columns["hh"].Width = 60;
            dgvEmp.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmp.Columns["Անուն"].Width = 250;
            dgvEmp.Columns["Անուն"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmp.Columns["Ազգանուն"].Width = 250;
            dgvEmp.Columns["Ազգանուն"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmp.Columns["Հեռախոս"].Width = 130;
            dgvEmp.Columns["Հեռախոս"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmp.Columns["Պաշտոն"].Width = 150;
            dgvEmp.Columns["Պաշտոն"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void GetItemId()
        {
            string prodCatId;
            string query = "select hh from TblEmployer order by hh Desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                prodCatId = id.ToString("00");
            }
            else if (Convert.IsDBNull(dr))
            {
                prodCatId = "01";
            }
            else
            {
                prodCatId = "01";
            }

            con.Close();
            txtEmpId.Text = prodCatId.ToString();
        }
        private void Cleartext()
        {
            txtEmpName.Text = "";
            txtEmpSur.Text = "";
            txtEmpTel.Text = "";
            txtEmpStat.Text = "";
            GetItemId();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
        }
        private void AddItemToGridview()
        {
            if (txtEmpName.Text == "" || txtEmpSur.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO TblEmployer (hh, Անուն, Ազգանուն, Հեռախոս, Պաշտոն) VALUES (@ItemId, @ItemCod, @ItemName, @ItemSize, @ItemDesc)", con);
                    cmd.Parameters.AddWithValue("@ItemId", txtEmpId.Text);
                    cmd.Parameters.AddWithValue("@ItemCod", txtEmpName.Text);
                    cmd.Parameters.AddWithValue("@ItemName", txtEmpSur.Text);
                    cmd.Parameters.AddWithValue("@ItemSize", txtEmpTel.Text);
                    cmd.Parameters.AddWithValue("@ItemDesc", txtEmpStat.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    FillGrid();
                    Cleartext();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void dgvEmp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditgridviewItem(sender, e);
            btnAdd.Enabled = false;
        }
        int i;
        private void EditgridviewItem(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dgvEmp.Rows[i];
            txtEmpId.Text = row.Cells[0].Value.ToString();
            txtEmpName.Text = row.Cells[1].Value.ToString();
            txtEmpSur.Text = row.Cells[2].Value.ToString();
            txtEmpTel.Text = row.Cells[3].Value.ToString();
            txtEmpStat.Text = row.Cells[4].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE TblEmployer SET Պաշտոն = @ItemDesc, Հեռախոս = @ItemSize, Ազգանուն = @ItemName, Անուն = @ItemCod WHERE hh = @ItemId", con);
                cmd.Parameters.AddWithValue("@ItemId", txtEmpId.Text);
                cmd.Parameters.AddWithValue("@ItemCod", txtEmpName.Text);
                cmd.Parameters.AddWithValue("@ItemName", txtEmpSur.Text);
                cmd.Parameters.AddWithValue("@ItemSize", txtEmpTel.Text);
                cmd.Parameters.AddWithValue("@ItemDesc", txtEmpStat.Text);

                cmd.ExecuteNonQuery();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Աշխատակցի տվյալները թարմացվեցին:");
                }
                else
                {
                    MessageBox.Show("Խմբագրման համար ընտրե՛ք աշխատակից:");
                }
                FillGrid();
                GetItemId();
                Cleartext();
                btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpId.Text != "" || txtEmpName.Text != "")
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք ջնջել աշխատակցին:", "Հեռացնել աշխատակցին", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();
                        cmd = new SqlCommand("DELETE FROM TblEmployer WHERE hh = '" + txtEmpId.Text + "'", con);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Աշխատակիցը հեռացվե՛ց");
                        }
                        else
                        {
                            MessageBox.Show("Հեռացման համար աշխատակից չի ընտրվել:");
                        }

                        FillGrid();
                        GetItemId();
                        Cleartext();
                        btnAdd.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ընտրե՛ք ցուցավահանակ ջնջելու համար:");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
