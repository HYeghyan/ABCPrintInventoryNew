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
    public partial class CreateMaterialBan : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public CreateMaterialBan()
        {
            InitializeComponent();
        }

        private void CreateMaterialBan_Load(object sender, EventArgs e)
        {
            FillGrid();
            GetItemId();
            Designe();
        }

        private void Designe()
        {
            dgvMatB.EnableHeadersVisualStyles = false;
            dgvMatB.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;

            btnEdit.TabStop = false;
            btnDel.TabStop = false;
            dgvMatB.TabStop = false;
            btnExToEx.TabStop = false;
        }
        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblMaterialBan order by hh asc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvMatB.DataSource = dt;
            dgvMatB.Columns["hh"].Width = 60;
            dgvMatB.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatB.Columns["Անվանում"].Width = 400;
            dgvMatB.Columns["Name"].Width = 400;
            dgvMatB.Columns["Լայնք"].Width = 80;
            dgvMatB.Columns["Լայնք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatB.Columns["Լայնք"].DefaultCellStyle.Format = "N2";
            dgvMatB.Columns["Լայնք"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.InvariantCulture;
            dgvMatB.Columns["Նկարագիր"].Width = 300;

        }
        private void GetItemId()
        {
            string prodCatId;
            string query = "select hh from TblMaterialBan order by hh Desc";
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
            txtMatBId.Text = prodCatId.ToString();
        }


        private void Cleartext()
        {
            txtMatBName.Text = "";
            txtMatBNameE.Text = "";
            txtMatBSize.Text = "";
            txtMatBDesc.Text = "";
            GetItemId();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
        }
        private void AddItemToGridview()
        {
            if (txtMatBName.Text == "" || txtMatBNameE.Text == "" || txtMatBSize.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO TblMaterialBan (hh, Անվանում, Name, Լայնք, Նկարագիր) VALUES (@ItemId, @ItemCod, @ItemName, @ItemSize, @ItemDesc)", con);
                    cmd.Parameters.AddWithValue("@ItemId", txtMatBId.Text);
                    cmd.Parameters.AddWithValue("@ItemCod", txtMatBName.Text);
                    cmd.Parameters.AddWithValue("@ItemName", txtMatBNameE.Text);
                    cmd.Parameters.AddWithValue("@ItemSize", txtMatBSize.Text);
                    cmd.Parameters.AddWithValue("@ItemDesc", txtMatBDesc.Text);

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

        private void dgvMatB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditgridviewItem(sender, e);
            btnAdd.Enabled = false;
        }
        int i;
        private void EditgridviewItem(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dgvMatB.Rows[i];
            txtMatBId.Text = row.Cells[0].Value.ToString();
            txtMatBName.Text = row.Cells[1].Value.ToString();
            txtMatBNameE.Text = row.Cells[2].Value.ToString();
            txtMatBSize.Text = row.Cells[3].Value.ToString();
            txtMatBDesc.Text = row.Cells[4].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE TblMaterialBan SET Նկարագիր = @ItemDesc, Լայնք = @ItemSize, Name = @ItemName, Անվանում = @ItemCod WHERE hh = @ItemId", con);
                cmd.Parameters.AddWithValue("@ItemId", txtMatBId.Text);
                cmd.Parameters.AddWithValue("@ItemCod", txtMatBName.Text);
                cmd.Parameters.AddWithValue("@ItemName", txtMatBNameE.Text);
                cmd.Parameters.AddWithValue("@ItemSize", txtMatBSize.Text);
                cmd.Parameters.AddWithValue("@ItemDesc", txtMatBDesc.Text);

                cmd.ExecuteNonQuery();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Տպ. նյութը թարմացվե՛ց:");
                }
                else
                {
                    MessageBox.Show("Խմբագրման համար ընտրե՛ք նյութ:");
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
                if (txtMatBName.Text != "" || txtMatBNameE.Text != "")
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք ջնջել տպագրական նյութը:", "Հեռացնել նյութը", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();
                        cmd = new SqlCommand("DELETE FROM TblMaterialBan WHERE hh = '" + txtMatBId.Text + "'", con);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Տպագրական նյութը հեռացվե՛ց");
                        }
                        else
                        {
                            MessageBox.Show("Խմբագրման համար նյութ չի ընտրվել:");
                        }

                        FillGrid();
                        GetItemId();
                        Cleartext();
                        btnAdd.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ընտրե՛ք նյութ ջնջելու համար:");
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
                ExportToExcel(dgvMatB, saveFileDialog.FileName);
            }
        }

        private void CreateMaterialBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
