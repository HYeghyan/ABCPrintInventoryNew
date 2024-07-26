using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ABCPrintInventory.Create
{
    public partial class AddClient : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public AddClient()
        {
            InitializeComponent();

            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnExToEx, "Արտահանել Excel");
            toolTip1.SetToolTip(btnAdd, "Ավելացնել");
            toolTip1.SetToolTip(btnEdit, "Պահպանել");
            toolTip1.SetToolTip(btnDel, "Ջնջել");

            rbtPP.CheckedChanged += rbtPP_CheckedChanged;
            rbtLP.CheckedChanged += rbtLP_CheckedChanged;
        }

        private void CreateClient_Load(object sender, EventArgs e)
        {
            FillGrid();
            DesignForm();
            Cleartext();
        }

        private void DesignForm()
        {
            dgvClient.EnableHeadersVisualStyles = false;
            dgvClient.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
        }
        private void Cleartext()
        {
            txtClientAddress.Text = "";
            txtClientTel.Text = "";
            txtClientMail.Text = "";
            txtClientName.Text = "";
            txtClientNote.Text = "";
            txtClientLegName.Text = "";
            txtClientAVC.Text = "";
            cmbClientBank.Text = "Ընտրե՛ք բանկը";
            txtClientAcount.Text = "";
            txtClientContP.Text = "";
            txtClientTel2.Text = "";
            GetItemId();
            rbtPP.Checked = false;
            txtClientCod.Text = "";
        }
        private void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblClient order by hh desc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvClient.DataSource = dt;
            dgvClient.Columns["hh"].Width = 60;
            dgvClient.Columns["hh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Կոդ"].Width = 70;
            dgvClient.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Անուն"].Width = 200;
            dgvClient.Columns["Հասցե"].Width = 200;
            dgvClient.Columns["Հեռ. 1"].Width = 140;
            dgvClient.Columns["Հեռ. 1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Էլ. փոստ"].Width = 160;
            dgvClient.Columns["Իրավ. անուն"].Width = 160;
            dgvClient.Columns["ՀՎՀՀ"].Width = 100;
            dgvClient.Columns["ՀՎՀՀ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Բանկ"].Width = 120;
            dgvClient.Columns["Հաշվեհամար"].Width = 140;
            dgvClient.Columns["Հաշվեհամար"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Միջնորդ / Կոնտ. անձ"].Width = 180;
            dgvClient.Columns["Միջնորդ / Կոնտ. անձ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Հեռ. 2"].Width = 140;
            dgvClient.Columns["Հեռ. 2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClient.Columns["Նշում"].Width = 200;
        }
        private void GetItemId()
        {
            string prodCatId;
            string query = "select hh from TblClient order by hh Desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                prodCatId = id.ToString("0");
            }
            else if (Convert.IsDBNull(dr))
            {
                prodCatId = "1";
            }
            else
            {
                prodCatId = "1";
            }

            con.Close();
            txtClientId.Text = prodCatId.ToString();
        }   
        private void rbtPP_CheckedChanged(object sender, EventArgs e)
        {
            string codeText = "Ֆ";
            string codeNumber;

            con.Open();
            cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(Կոդ, 2, LEN(Կոդ)) AS INT)) FROM TblClient WHERE Կոդ LIKE @codeText", con);
            cmd.Parameters.AddWithValue("@codeText", codeText + "%");

            object result = cmd.ExecuteScalar();
            int counter = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1;

            codeNumber = counter.ToString("0000");
            con.Close();

            codeText = codeText.Replace(" ", "");
            string resultText = codeText + codeNumber;

            txtClientCod.Text = resultText;
            txtClientLegName.Enabled = false;
            txtClientLegName.Text = "";
            txtClientLegName.BackColor = Color.Silver;
            txtClientAVC.Enabled = false;
            txtClientAVC.Text = "";
            txtClientAVC.BackColor = Color.Silver;

        }

        private void rbtLP_CheckedChanged(object sender, EventArgs e)
        {
            string codeText = "Ի";
            string codeNumber;

            con.Open();
            cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(Կոդ, 2, LEN(Կոդ)) AS INT)) FROM TblClient WHERE Կոդ LIKE @codeText", con);
            cmd.Parameters.AddWithValue("@codeText", codeText + "%");

            // If there are no records yet, set the counter to 1
            object result = cmd.ExecuteScalar();
            int counter = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1;

            codeNumber = counter.ToString("0000");
            con.Close();

            codeText = codeText.Replace(" ", "");
            string resultText = codeText + codeNumber;

            txtClientCod.Text = resultText;

            txtClientLegName.Enabled = true;
            txtClientLegName.BackColor = Color.White;
            txtClientAVC.Enabled = true;
            txtClientAVC.BackColor = Color.White;
        }

        private void txtClientAcount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtClientAVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtClientMail_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtClientMail.Text))
            {
                if (txtClientMail.Text.Contains('@') && txtClientMail.Text.Contains('.'))
                {
                }
                else
                {
                    MessageBox.Show("Էլ.հասցեի սխալ ֆորմատ");
                    e.Cancel = true; // Cancel the focus change
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
        }
        public void AddItemToGridview()
        {

            if (txtClientCod.Text == "" || txtClientName.Text == "" )
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը մուտքագրված չեն");
            }
            else
            {
                try
                {
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    
                    cmd = new SqlCommand("INSERT INTO TblClient " +
                        "(hh, Կոդ, Անուն, [Հեռ. 1], [Էլ. փոստ], Հասցե, [Իրավ. անուն], ՀՎՀՀ, Բանկ, Հաշվեհամար, [Միջնորդ / Կոնտ. անձ], [Հեռ. 2], Նշում) VALUES " +
                        "(@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9, @Column10, @Column11, @Column12, @Column13)", con);
                    cmd.Parameters.AddWithValue("@Column1", txtClientId.Text);
                    cmd.Parameters.AddWithValue("@Column2", txtClientCod.Text);
                    cmd.Parameters.AddWithValue("@Column3", txtClientName.Text);
                    cmd.Parameters.AddWithValue("@Column4", txtClientTel.Text);
                    cmd.Parameters.AddWithValue("@Column5", txtClientMail.Text);
                    cmd.Parameters.AddWithValue("@Column6", txtClientAddress.Text);                   
                    cmd.Parameters.AddWithValue("@Column7", txtClientLegName.Text);
                    cmd.Parameters.AddWithValue("@Column8", txtClientAVC.Text);
                    if (cmbClientBank.Text != "Ընտրե՛ք բանկը")
                    {
                        cmd.Parameters.AddWithValue("@Column9", cmbClientBank.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Column9", "");
                    }
                    cmd.Parameters.AddWithValue("@Column10", txtClientAcount.Text);
                    cmd.Parameters.AddWithValue("@Column11", txtClientContP.Text);

                    cmd.Parameters.AddWithValue("@Column12", txtClientTel2.Text);
                    cmd.Parameters.AddWithValue("@Column13", txtClientNote.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    FillGrid();
                    Cleartext();
                    DesignForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Editgridview(sender, e);
        }
        int i;
        public void Editgridview(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dgvClient.Rows[i];
            txtClientId.Text = row.Cells[0].Value.ToString();
            txtClientCod.Text = row.Cells[1].Value.ToString();
            //if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Length > 0 && row.Cells[1].Value.ToString()[0] == 'Ֆ')
            //{
            //    rbtPP.Checked = true;
            //}
            //else
            //{
            //    rbtLP.Checked = false;
            //}
            txtClientName.Text = row.Cells[2].Value.ToString();
            txtClientTel.Text = row.Cells[3].Value.ToString();
            txtClientMail.Text = row.Cells[4].Value.ToString();

            txtClientLegName.Text = row.Cells[6].Value.ToString();
            txtClientAVC.Text = row.Cells[7].Value.ToString();
            cmbClientBank.Text = row.Cells[8].Value.ToString();
            txtClientAcount.Text = row.Cells[9].Value.ToString();
            txtClientContP.Text = row.Cells[10].Value.ToString();
            txtClientTel2.Text = row.Cells[11].Value.ToString();
            txtClientNote.Text = row.Cells[12].Value.ToString();
            btnAdd.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtClientCod.Text == "" || txtClientName.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը մուտքագրված չեն");
            }
            else
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd = new SqlCommand("UPDATE TblClient SET " +
                        " Կոդ = @Column2, Անուն = @Column3, [Հեռ. 1] = @Column4, [Էլ. փոստ] = @Column5, Հասցե = @Column6, [Իրավ. անուն] = @Column7, ՀՎՀՀ = @Column8, Բանկ = @Column9, Հաշվեհամար = @Column10, [Միջնորդ / Կոնտ. անձ] = @Column11, [Հեռ. 2] = @Column12, [Նշում] = @Column13 " +
                        " WHERE hh = @Column1 ", con);
                    cmd.Parameters.AddWithValue("@Column1", txtClientId.Text);
                    cmd.Parameters.AddWithValue("@Column2", txtClientCod.Text);
                    cmd.Parameters.AddWithValue("@Column3", txtClientName.Text);
                    cmd.Parameters.AddWithValue("@Column4", txtClientTel.Text);
                    cmd.Parameters.AddWithValue("@Column5", txtClientMail.Text);
                    cmd.Parameters.AddWithValue("@Column6", txtClientAddress.Text);                  
                    cmd.Parameters.AddWithValue("@Column7", txtClientLegName.Text);
                    cmd.Parameters.AddWithValue("@Column8", txtClientAVC.Text);
                    if (cmbClientBank.Text != "Ընտրե՛ք բանկը")
                    {
                        cmd.Parameters.AddWithValue("@Column9", cmbClientBank.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Column9", "");
                    }
                    cmd.Parameters.AddWithValue("@Column10", txtClientAcount.Text);
                    cmd.Parameters.AddWithValue("@Column11", txtClientContP.Text);
                    cmd.Parameters.AddWithValue("@Column12", txtClientTel2.Text);
                    cmd.Parameters.AddWithValue("@Column13", txtClientNote.Text);
                    cmd.ExecuteNonQuery();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Հաճախորդի տվյալները թարմացվե՛ց:");
                    }
                    else
                    {
                        MessageBox.Show("Խմբագրման համար ընտրե՛ք հաճախորդ:");
                    }
                    FillGrid();
                    Cleartext();
                    DesignForm();
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
                if (txtClientId.Text != "")
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք ջնջել հաճախորդի տվյալները:", "Հեռացնել հաճախորդին", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();
                        cmd = new SqlCommand("DELETE FROM TblClient WHERE hh = '" + txtClientId.Text + "'", con);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Հաճախորդի տվյալները հեռացվեցին");
                        }
                        else
                        {
                            MessageBox.Show("Հաճախորդ չի ընտրվել:");
                        }

                        FillGrid();
                        Cleartext();
                        DesignForm();
                        btnAdd.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ընտրե՛ք հաճախորդ ջնջելու համար:");
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
                ExportToExcel(dgvClient, saveFileDialog.FileName);
            }
        }

        private void AddClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtClientNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Alt)
            {
                // Handle Alt+Enter differently (e.g., insert a newline)
                int selectionStart = txtClientNote.SelectionStart;
                txtClientNote.Text = txtClientNote.Text.Insert(selectionStart, Environment.NewLine);
                txtClientNote.SelectionStart = selectionStart + Environment.NewLine.Length;
                e.SuppressKeyPress = true; // Suppress the Enter key
            }
        }
    }
}
