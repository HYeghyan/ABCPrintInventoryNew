using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCPrintInventory.Create
{
    public partial class CreateExpArticle : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public CreateExpArticle()
        {
            InitializeComponent();
        }

        private void CreateExpArticle_Load(object sender, EventArgs e)
        {
            FillGrid();
            GetItemId();
            Designe();
        }
        private void Designe()
        {
            dgvExpArt.EnableHeadersVisualStyles = false;
            dgvExpArt.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;

            btnEdit.TabStop = false;
            btnDel.TabStop = false;
            dgvExpArt.TabStop = false;
            btnExToEx.TabStop = false;
        }
        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblExpArticle order by hh asc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvExpArt.DataSource = dt;
            dgvExpArt.Columns["hh"].Width = 60;
            dgvExpArt.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExpArt.Columns["Հոդված"].Width = 250;
            dgvExpArt.Columns["Նկարագիր"].Width = 300;
        }
        private void GetItemId()
        {
            string prodCatId;
            string query = "select hh from TblExpArticle order by hh Desc";
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
            txtExartId.Text = prodCatId.ToString();
        }
        private void Cleartext()
        {
            txtExartName.Text = "";
            txtExartDesc.Text = "";
            GetItemId();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
        }
        private void AddItemToGridview()
        {
            if (txtExartId.Text == "" || txtExartName.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO TblExpArticle (hh, Հոդված, Նկարագիր) VALUES (@ItemId, @ItemName, @ItemDesc)", con);
                    cmd.Parameters.AddWithValue("@ItemId", txtExartId.Text);
                    cmd.Parameters.AddWithValue("@ItemName", txtExartName.Text);
                    cmd.Parameters.AddWithValue("@ItemDesc", txtExartDesc.Text);

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
        private void dgvExpArt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditgridviewItem(sender, e);
            btnAdd.Enabled = false;
        }
        int i;
        private void EditgridviewItem(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dgvExpArt.Rows[i];
            txtExartId.Text = row.Cells[0].Value.ToString();
            txtExartName.Text = row.Cells[1].Value.ToString();
            txtExartDesc.Text = row.Cells[2].Value.ToString();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE TblExpArticle SET Նկարագիր = @ItemDesc, Հոդված = @ItemName WHERE hh = @ItemId", con);
                cmd.Parameters.AddWithValue("@ItemId", txtExartId.Text);
                cmd.Parameters.AddWithValue("@ItemName", txtExartName.Text);
                cmd.Parameters.AddWithValue("@ItemDesc", txtExartDesc.Text);

                cmd.ExecuteNonQuery();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Հոդվածը թարմացվե՛ց:");
                }
                else
                {
                    MessageBox.Show("Խմբագրման համար ընտրե՛ք հոդված:");
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
                if (txtExartId.Text != "" || txtExartName.Text != "")
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք ջնջել հոդվածը:", "Հեռացնել հոդվածը", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();
                        cmd = new SqlCommand("DELETE FROM TblExpArticle WHERE hh = '" + txtExartId.Text + "'", con);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Հոդվածը հեռացվե՛ց");
                        }
                        else
                        {
                            MessageBox.Show("Խմբագրման համար հոդված չի ընտրվել:");
                        }

                        FillGrid();
                        GetItemId();
                        Cleartext();
                        btnAdd.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ընտրե՛ք հոդված ջնջելու համար:");
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

        private void btnExToEx_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dgvExpArt, saveFileDialog.FileName);
            }
        }

        private void CreateExpArticle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
