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
    public partial class CreateInk : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public CreateInk()
        {
            InitializeComponent();
        }
        private void CreateInk_Load_1(object sender, EventArgs e)
        {
            FillGrid();
            GetItemId();
            Designe();
        }

        private void Designe()
        {
            dgvInk.EnableHeadersVisualStyles = false;
            dgvInk.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;

            btnEdit.TabStop = false;
            btnDel.TabStop = false;
            dgvInk.TabStop = false;
            btnExToEx.TabStop = false;
        }

        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblInk order by hh asc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvInk.DataSource = dt;
            dgvInk.Columns["hh"].Width = 60;
            dgvInk.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInk.Columns["Ներկ"].Width = 250;
            dgvInk.Columns["Ներկ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInk.Columns["Չմ"].Width = 60;
            dgvInk.Columns["Չմ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInk.Columns["Նկարագիր"].Width = 300;
            dgvInk.Columns["Նկարագիր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void GetItemId()
        {
            string prodCatId;
            string query = "select hh from TblInk order by hh Desc";
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
            txtInkId.Text = prodCatId.ToString();
        }

        private void Cleartext()
        {
            txtInkName.Text = "";
            txtInkSize.Text = "";
            txtInkDesc.Text = "";
            GetItemId();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
        }
        private void AddItemToGridview()
        {
            if (txtInkSize.Text == "" || txtInkName.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO TblInk (hh, Ներկ, Չմ, Նկարագիր) VALUES (@ItemId, @ItemName, @ItemSize, @ItemDesc)", con);
                    cmd.Parameters.AddWithValue("@ItemId", txtInkId.Text);
                    cmd.Parameters.AddWithValue("@ItemName", txtInkName.Text);
                    cmd.Parameters.AddWithValue("@ItemSize", txtInkSize.Text);
                    cmd.Parameters.AddWithValue("@ItemDesc", txtInkDesc.Text);

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
        private void dgvInk_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditgridviewItem(sender, e);
            btnAdd.Enabled = false;
        }
        int i;
        private void EditgridviewItem(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dgvInk.Rows[i];
            txtInkId.Text = row.Cells[0].Value.ToString();
            txtInkName.Text = row.Cells[1].Value.ToString();
            txtInkSize.Text = row.Cells[2].Value.ToString();
            txtInkDesc.Text = row.Cells[3].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtInkSize.Text == "" || txtInkName.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE TblInk SET Նկարագիր = @ItemDesc, Չմ = @ItemSize, Ներկ = @ItemName WHERE hh = @ItemId", con);
                    cmd.Parameters.AddWithValue("@ItemId", txtInkId.Text);
                    cmd.Parameters.AddWithValue("@ItemName", txtInkName.Text);
                    cmd.Parameters.AddWithValue("@ItemSize", txtInkSize.Text);
                    cmd.Parameters.AddWithValue("@ItemDesc", txtInkDesc.Text);

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
                if (txtInkId.Text != "" || txtInkName.Text != "")
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք ջնջել ներկը:", "Հեռացնել ներկը", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();
                        cmd = new SqlCommand("DELETE FROM TblInk WHERE hh = '" + txtInkId.Text + "'", con);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ներկը հեռացվե՛ց");
                        }
                        else
                        {
                            MessageBox.Show("Խմբագրման համար կ չի ընտրվել:");
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

        private void btnExToEx_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dgvInk, saveFileDialog.FileName);
            }
        }

        private void CreateInk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtInkDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Alt)
            {
                int selectionStart = txtInkDesc.SelectionStart;
                txtInkDesc.Text = txtInkDesc.Text.Insert(selectionStart, Environment.NewLine);
                txtInkDesc.SelectionStart = selectionStart + Environment.NewLine.Length;
                e.SuppressKeyPress = true; 
            }
        }
    }
}
