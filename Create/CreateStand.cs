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
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.IO;

namespace ABCPrintInventory.Create
{
    public partial class CreateStand : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;


        public CreateStand()
        {
            InitializeComponent();
        }

        private void CreateStand_Load(object sender, EventArgs e)
        {
            FillGrid();
            GetItemId();
            Designe();
        }
        private void Designe()
        {
            dgvStand.EnableHeadersVisualStyles = false;
            dgvStand.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;

            btnEdit.TabStop = false;
            btnDel.TabStop = false;
            dgvStand.TabStop = false;
            btnExToEx.TabStop = false;
        }
        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblStand order by hh asc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvStand.DataSource = dt;
            dgvStand.Columns["hh"].Width = 60;
            dgvStand.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStand.Columns["Կոդ"].Width = 120;
            dgvStand.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStand.Columns["Վահանակ"].Width = 250;
            dgvStand.Columns["Վահանակ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStand.Columns["Չափս"].Width = 130;
            dgvStand.Columns["Չափս"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStand.Columns["Նկարագիր"].Width = 300;
            dgvStand.Columns["Նկարագիր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void GetItemId()
        {
            string prodCatId;
            string query = "select hh from TblStand order by hh Desc";
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
            txtStandId.Text = prodCatId.ToString();
        }
        private void Cleartext()
        {
            txtStandCod.Text = "";
            txtStandName.Text = "";
            txtStandSize.Text = "";
            txtStandDesc.Text = "";
            GetItemId();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
        }
        private void AddItemToGridview()
        {
            if (txtStandCod.Text == "" || txtStandName.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO TblStand (hh, Կոդ, Վահանակ, Չափս, Նկարագիր) VALUES (@ItemId, @ItemCod, @ItemName, @ItemSize, @ItemDesc)", con);
                    cmd.Parameters.AddWithValue("@ItemId", txtStandId.Text);
                    cmd.Parameters.AddWithValue("@ItemCod", txtStandCod.Text);
                    cmd.Parameters.AddWithValue("@ItemName", txtStandName.Text);
                    cmd.Parameters.AddWithValue("@ItemSize", txtStandSize.Text);
                    cmd.Parameters.AddWithValue("@ItemDesc", txtStandDesc.Text);

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
        private void dgvStand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditgridviewItem(sender, e);
            btnAdd.Enabled = false;
        }
        int i;
        private void EditgridviewItem(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dgvStand.Rows[i];
            txtStandId.Text = row.Cells[0].Value.ToString();
            txtStandCod.Text = row.Cells[1].Value.ToString();
            txtStandName.Text = row.Cells[2].Value.ToString();
            txtStandSize.Text = row.Cells[3].Value.ToString();
            txtStandDesc.Text = row.Cells[4].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE TblStand SET Նկարագիր = @ItemDesc, Չափս = @ItemSize, Վահանակ = @ItemName, Կոդ = @ItemCod WHERE hh = @ItemId", con);
                cmd.Parameters.AddWithValue("@ItemId", txtStandId.Text);
                cmd.Parameters.AddWithValue("@ItemCod", txtStandCod.Text);
                cmd.Parameters.AddWithValue("@ItemName", txtStandName.Text);
                cmd.Parameters.AddWithValue("@ItemSize", txtStandSize.Text);
                cmd.Parameters.AddWithValue("@ItemDesc", txtStandDesc.Text);

                cmd.ExecuteNonQuery();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Ցուցավահանակը թարմացվե՛ց:");
                }
                else
                {
                    MessageBox.Show("Խմբագրման համար ընտրե՛ք ցուցավահանակ:");
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
                if (txtStandId.Text != "" || txtStandCod.Text != "")
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք ջնջել ցուցավահանակը:", "Հեռացնել վահանակը", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();
                        cmd = new SqlCommand("DELETE FROM TblStand WHERE hh = '" + txtStandId.Text + "'", con);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ցուցավահանակը հեռացվե՛ց");
                        }
                        else
                        {
                            MessageBox.Show("Հեռացման համար ցուցավահանակ չի ընտրվել:");
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
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    // Export headers with styling
                    for (int i = 1; i <= dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i].Value = dataGridView.Columns[i - 1].HeaderText;
                        worksheet.Cells[1, i].Style.Font.Bold = true;
                        worksheet.Cells[1, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[1, i].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    // Export data
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Add filter to the header row
                    worksheet.Cells[worksheet.Dimension.Address].AutoFilter = true;

                    // Adjust column sizes
                    for (int i = 1; i <= dataGridView.Columns.Count; i++)
                    {
                        worksheet.Column(i).AutoFit();
                    }

                    // Save the Excel file
                    package.SaveAs(new FileInfo(filePath));
                }
                MessageBox.Show("Տվյալները հաջողությամբ արտահանվեցին:", "Արտահանել Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel տվյալների արտահանման սխալ:" + ex.Message, "Արտահանել Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void exToEx_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dgvStand, saveFileDialog.FileName);
            }
        }

        private void CreateStand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
