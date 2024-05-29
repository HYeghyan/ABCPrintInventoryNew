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
    public partial class CreatePrinter : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public CreatePrinter()
        {
            InitializeComponent();
        }
        private void CreatePrinter_Load(object sender, EventArgs e)
        {
            FillGrid();
            GetItemId();
            Designe();
        }
        private void Designe()
        {
            dgvPrint.EnableHeadersVisualStyles = false;
            dgvPrint.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;

            btnEdit.TabStop = false;
            btnDel.TabStop = false;
            dgvPrint.TabStop = false;
            btnexToEx.TabStop = false;
        }

        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblPrinter order by hh asc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvPrint.DataSource = dt;
            dgvPrint.Columns["hh"].Width = 60;
            dgvPrint.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrint.Columns["Անվանում"].Width = 200;
            dgvPrint.Columns["Անվանում"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrint.Columns["Հապ."].Width = 70;
            dgvPrint.Columns["Հապ."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrint.Columns["Լայնք"].Width = 80;
            dgvPrint.Columns["Լայնք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrint.Columns["Լայնք"].DefaultCellStyle.Format = "N2";
            dgvPrint.Columns["Տեխ. բնութագիր"].Width = 300;
            dgvPrint.Columns["Տեխ. բնութագիր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void GetItemId()
        {
            string prodCatId;
            string query = "select hh from TblPrinter order by hh Desc";
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
            txtPrintId.Text = prodCatId.ToString();
        }
        private void Cleartext()
        {
            txtPrintName.Text = "";
            txtPrintNameInS.Text = "";
            txtPrintSize.Text = "";
            txtPrintSize.Text = "";
            GetItemId();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
        }
        private void AddItemToGridview()
        {
            if (txtPrintName.Text == "" || txtPrintNameInS.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO TblPrinter (hh, Անվանում, [Հապ.], Լայնք, [Տեխ. բնութագիր]) VALUES (@ItemId, @ItemCod, @ItemName, @ItemSize, @ItemDesc)", con);
                    cmd.Parameters.AddWithValue("@ItemId", txtPrintId.Text);
                    cmd.Parameters.AddWithValue("@ItemCod", txtPrintName.Text);
                    cmd.Parameters.AddWithValue("@ItemName", txtPrintNameInS.Text);
                    cmd.Parameters.AddWithValue("@ItemSize", txtPrintSize.Text);
                    cmd.Parameters.AddWithValue("@ItemDesc", txtPrintDesc.Text);

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
        private void dgvPrint_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditgridviewItem(sender, e);
            btnAdd.Enabled = false;
        }
        int i;
        private void EditgridviewItem(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dgvPrint.Rows[i];
            txtPrintId.Text = row.Cells[0].Value.ToString();
            txtPrintName.Text = row.Cells[1].Value.ToString();
            txtPrintNameInS.Text = row.Cells[2].Value.ToString();
            txtPrintSize.Text = row.Cells[3].Value.ToString();
            txtPrintDesc.Text = row.Cells[4].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtPrintName.Text == "" || txtPrintNameInS.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE TblPrinter SET [Տեխ. բնութագիր] = @ItemDesc, Լայնք = @ItemSize, [Հապ.] = @ItemName, Անվանում = @ItemCod WHERE hh = @ItemId", con);
                    cmd.Parameters.AddWithValue("@ItemId", txtPrintId.Text);
                    cmd.Parameters.AddWithValue("@ItemCod", txtPrintName.Text);
                    cmd.Parameters.AddWithValue("@ItemName", txtPrintNameInS.Text);
                    cmd.Parameters.AddWithValue("@ItemSize", txtPrintSize.Text);
                    cmd.Parameters.AddWithValue("@ItemDesc", txtPrintDesc.Text);

                    cmd.ExecuteNonQuery();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Տպագրական մեքենան թարմացվե՛ց:");
                    }
                    else
                    {
                        MessageBox.Show("Խմբագրման համար ընտրե՛ք տպագրական մեքենա:");
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
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrintId.Text != "" || txtPrintName.Text != "")
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք ջնջել տպագրական մեքենան:", "Հեռացնել մեքենան", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();
                        cmd = new SqlCommand("DELETE FROM TblPrinter WHERE hh = '" + txtPrintId.Text + "'", con);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Տպագրական մեքենան հեռացվե՛ց");
                        }
                        else
                        {
                            MessageBox.Show("Խմբագրման համար տպագրական մեքենա չի ընտրվել:");
                        }

                        FillGrid();
                        GetItemId();
                        Cleartext();
                        btnAdd.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ընտրե՛ք տպագրական մեքենա ջնջելու համար:");
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
                ExportToExcel(dgvPrint, saveFileDialog.FileName);
            }
        }

        private void CreatePrinter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the Enter key from affecting the current row
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPrintDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Alt)
            {
                // Handle Alt+Enter differently (e.g., insert a newline)
                int selectionStart = txtPrintDesc.SelectionStart;
                txtPrintDesc.Text = txtPrintDesc.Text.Insert(selectionStart, Environment.NewLine);
                txtPrintDesc.SelectionStart = selectionStart + Environment.NewLine.Length;
                e.SuppressKeyPress = true; // Suppress the Enter key
            }
        }
    }
}
