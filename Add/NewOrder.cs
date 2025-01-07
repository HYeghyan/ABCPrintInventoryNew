using ABCPrintInventory.Create;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ABCPrintInventory.Add
{
    public partial class NewOrder : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public NewOrder()
        {
            InitializeComponent();
            GetPrintVal();
            GetDefVal();
            GetServVal();
            GetStandVal();
            GetLuvVal();
            GetCostVal();
            dtpNO.ValueChanged += dtpNO_ValueChanged;
        }
        public bool BtnNOAddEnabled
        {
            get { return btnNOAdd.Enabled; }
            set { btnNOAdd.Enabled = value; }
        }
        private void NewOrder_Load(object sender, EventArgs e)
        {
            DefCalculateAuto();
            FillComboBoxClient();
            FillComboBoxMash();
            FillComboBoxMat();
            FillComboBoxServ();
            FillComboBoxStand();
            UpdateTextBoxe1FromDataGridView();
            UpdateTextBoxe2FromDataGridView();
            UpdateTextBoxe3FromDataGridView();
            UpdateTextBoxe4FromDataGridView();
            GetRbtSelect();
            PopulateDgvNOorderFromDatabase();
            dtpNO_ValueChanged(sender, e);
            GetDebtItemId();
        }
        //Կոմբոբոքսերի լրացնելը
        private void FillComboBoxClient()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Անուն) FROM TblClient order by Անուն Asc", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNOclient.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void FillComboBoxMat()
        {
            cmbNOprMat.Items.Clear(); // Clear existing items
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Name FROM TblMaterialBan order by hh Asc"; // Select only the Name column
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmbNOprMat.Items.Add(dr["Name"]); // Add Name to the ComboBox
            }

            con.Close();
        }
        private void FillComboBoxMash()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT([Հապ.]) FROM TblPrinter", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNOprMash.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void FillComboBoxServ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Ծառայություն) FROM TblService", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNOserv.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void FillComboBoxStand()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Վահանակ) FROM TblStand", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNOstand.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void ClearText()
        {
            cmbNOprMat.Text = "";
            cmbNOprMat.Text = "";
            txtNOprW.Text = "";
            txtNOprL.Text = "";
            txtNOprQnt.Text = "";
            txtNOprSM.Text = "";
            txtNOprPrice.Text = "";
            txtNOprVal.Text = "";
            txtNOdefSM.Text = "";
            txtNOdefPrice.Text = "";
            txtNOdefVal.Text = "";
            txtNOluvQnt.Text = "";
            txtNOluvPrice.Text = "";
            txtNOluvVal.Text = "";
            cmbNOserv.Text = "";
            txtNOservQnt.Text = "";
            txtNOservPrice.Text = "";
            txtNOservVal.Text = "";
            cmbNOstand.Text = "";
            txtNOstandQnt.Text = "";
            txtNOstandPrice.Text = "";
            txtNOstandVal.Text = "";
            txtNOcost.Text = "";
            txtNOcostQnt.Text = "";
            txtNOcostPrice.Text = "";
            txtNOcostVal.Text = "";
            txtNOnote.Text = "";
            txtNOsale.Text = "";
        }
        //Ստանում ենք պատվերի կոդը
        private string connectionString = Properties.Settings.Default.AbcprintinvCon;
        private int orderNumber = 1;
        private void dtpNO_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpNO.Value;
            string orderId = GenerateOrderId(selectedDate);
            txtNOid.Text = orderId;
        }
        private string GenerateOrderId(DateTime date)
        {
            string formattedDate = date.ToString("ddMMyy");

            // Get the next order number for the selected date
            int nextOrderNumber = GetNextOrderNumber(date);

            // Format the order number with leading zeros if needed
            string formattedOrderNumber = nextOrderNumber.ToString().PadLeft(2, '0');

            // Combine the formatted date and order number to create the final order ID
            string orderId = formattedDate + "-" + formattedOrderNumber;

            return orderId;
        }
        private int GetNextOrderNumber(DateTime date)
        {
            // Connect to your database and query the last order ID for the selected date
            string query = "SELECT TOP 1 [Պատվ. համ] FROM TblOrders WHERE [Պատվ. համ] LIKE @pattern ORDER BY [Պատվ. համ] DESC";
            int lastOrderNumber = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@pattern", date.ToString("ddMMyy") + "%");

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string lastOrderId = reader["Պատվ. համ"].ToString();
                    string[] parts = lastOrderId.Split('-');
                    lastOrderNumber = int.Parse(parts[1]);
                }

                reader.Close();
            }

            // Increment the last order number by 1
            return lastOrderNumber + 1;
        }
        //Ստանում ենք տողի համարը
        private void UpdateTextBoxe1FromDataGridView()
        {
            int countProd = 1;

            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Check the value of the "Main product" column (assuming it's a string)
                    if (!string.IsNullOrEmpty(row.Cells["dgvOrderMat"].Value?.ToString()))
                    {
                        countProd++;
                    }

                }
            }

            textBox1.Text = countProd.ToString();

        }
        private void UpdateTextBoxe2FromDataGridView()
        {
            int countServ = 1; // Initialize count of services to 0

            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Check the value of the "dgvOrderAdt" column
                    if (!string.IsNullOrEmpty(row.Cells["dgvOrderAdt"].Value?.ToString()))
                    {
                        countServ++; // Increment count of services if cell is not empty
                    }
                }
            }

            textBox2.Text = countServ.ToString(); // Update textBox2 with the count of services
        }
        private void UpdateTextBoxe3FromDataGridView()
        {
            int countCost = 1; // Initialize count of services to 0

            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Check the value of the "dgvOrderAdt" column
                    if (!string.IsNullOrEmpty(row.Cells["dgvOrderCost"].Value?.ToString()))
                    {
                        countCost++; // Increment count of services if cell is not empty
                    }
                }
            }

            textBox3.Text = countCost.ToString(); // Update textBox2 with the count of services
        }
        private void UpdateTextBoxe4FromDataGridView()
        {
            int countCom = 1; // Initialize count of services to 0

            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Check the value of the "dgvOrderAdt" column
                    if (!string.IsNullOrEmpty(row.Cells["NOcomment"].Value?.ToString()) && !string.IsNullOrEmpty(row.Cells["NOsale"].Value?.ToString()))
                    {
                        countCom++; // Increment count of services if cell is not empty
                    }
                }
            }

            textBox4.Text = countCom.ToString(); // Update textBox2 with the count of services
        }
        //Enter և սլաքներով կոճակներով վանդակների փոփոխություն
        private void NewOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                SelectNextControl(this.ActiveControl, false, true, true, true);
            }
        }

        //-----------------------------------  Տպագրություն  ----------------------------------------

        //Հաշվում ենք տպագրության քմ-ը
        private void CountSqMPr()
        {
            if (!string.IsNullOrEmpty(txtNOprW.Text) && !string.IsNullOrEmpty(txtNOprL.Text) && !string.IsNullOrEmpty(txtNOprQnt.Text))
            {
                decimal prW = Convert.ToDecimal(txtNOprW.Text, CultureInfo.InvariantCulture);
                decimal prH = Convert.ToDecimal(txtNOprL.Text, CultureInfo.InvariantCulture);
                int prQnt = Convert.ToInt32(txtNOprQnt.Text);
                decimal prSM = prW * prH * prQnt;

                txtNOprSM.Text = prSM.ToString("0.00");
            }
        }
        //Հաշվում ենք տպագրության արժեքը
        private void CountValPr()
        {
            if (!string.IsNullOrEmpty(txtNOprSM.Text) && !string.IsNullOrEmpty(txtNOprPrice.Text))
            {
                string input = txtNOprPrice.Text.Replace(".", "").Replace(",", "");

                // Check if the input is numeric
                if (decimal.TryParse(input, out decimal prPrice))
                {
                    // Format the input with thousands separators and assign it back to the TextBox
                    txtNOprPrice.Text = prPrice.ToString("#,0");

                    // Move the cursor to the end of the text
                    txtNOprPrice.SelectionStart = txtNOprPrice.Text.Length;
                }
                prPrice = Convert.ToInt32(txtNOprPrice.Text.Replace(",", ""));
                decimal prSM = Convert.ToDecimal(txtNOprSM.Text);

                decimal prVal = prSM * prPrice;


                txtNOprVal.Text = prVal.ToString("#,0");
            }
        }
        //Տպագրության տողում յուր վանդակում որևէ թիվ փոխելուց ընդ քմ-ն և արժեքը փոխվում է /Հաջորդող 2 մեթոդները
        private void UpdatePrvalCalculations(object sender, EventArgs e)
        {
            CountSqMPr();
            CountValPr();
        }
        private void GetPrintVal()
        {
            txtNOprW.TextChanged += UpdatePrvalCalculations;
            txtNOprL.TextChanged += UpdatePrvalCalculations;
            txtNOprQnt.TextChanged += UpdatePrvalCalculations;
            txtNOprPrice.TextChanged += UpdatePrvalCalculations;
        }

        //Փոքր աղյուսակի ֆիլտր ըստ տպ. նյութի և տպ. մեքենայի
        private void cmbPrMach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string column1Value = cmbNOprMash.SelectedItem?.ToString();
            string column2Value = cmbNOprMat.SelectedItem?.ToString();
            FilterDataGridView(column1Value, column2Value);
            DefCalculateCheck();
            int lenght = 0;
            txtNOdefLenghtNeed.Text = lenght.ToString();
            CountTotalQM();
        }
        //Ֆիլտր անելուց բացի նաև լրացնում է նյութի լայնքը (a)
        private void cmbMat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string column1Value = cmbNOprMash.SelectedItem?.ToString();
            string column2Value = cmbNOprMat.SelectedItem?.ToString();
            FilterDataGridView(column1Value, column2Value);
            DefCalculateCheck();
            //CalculateOptim();
            cmd = new SqlCommand("Select * From TblMaterialBan where Name = '" + cmbNOprMat.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string width = (string)dr["Լայնք"].ToString();
                txtNOdefWightMat.Text = width;
            }
            con.Close();
            CountTotalQM();
        }
        private void FilterDataGridView(string column1Value, string column2Value)
        {

            foreach (DataGridViewRow row in dgvNOdefect.Rows)
            {
                if (row.IsNewRow)
                {
                    continue; // Skip the new row if it exists
                }

                string value1 = row.Cells[0].Value?.ToString(); // Assuming ComboBox1 corresponds to Column1
                string value2 = row.Cells[1].Value?.ToString(); // Assuming ComboBox2 corresponds to Column2

                // Check if the row matches the selected values
                bool match1 = string.IsNullOrEmpty(column1Value) || value1 == column1Value;
                bool match2 = string.IsNullOrEmpty(column2Value) || value2 == column2Value;

                // Hide or show the row based on the filter condition
                row.Visible = match1 && match2;

                CalculateOptim();
            }
        }
        //Ավելացնում ենք աղյուսակի մեջ
        private void prAdd_Click(object sender, EventArgs e)
        {
            AddPrinting();
            AddDefDgv();
            txtLenghtNeed_TextChanged(sender, e);
            CountTotalVal();
            CountTotalQM();
        }
        private int nextRowIndex = 0;
        private void AddPrinting()
        {
            if (cmbNOprMash.Text == "" || cmbNOprMat.Text == "" || txtNOprVal.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }
            else
            {
                for (int i = 0; i < dgvNOorder.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgvNOorder.Rows[i].Cells[2].Value?.ToString()))
                    {
                        dgvNOorder.Rows.Add(); // Add a new row to dgvOrder

                        // Get the index of the newly added row in dgvOrder
                        //int newRowIdex = dgvNOorder.Rows.Count - 1;
                        dgvNOorder.Rows[i].Cells[0].Value = dtpNO.Text;
                        dgvNOorder.Rows[i].Cells[1].Value = txtNOid.Text;
                        dgvNOorder.Rows[i].Cells[2].Value = textBox1.Text;
                        dgvNOorder.Rows[i].Cells[3].Value = cmbNOprMash.Text;
                        dgvNOorder.Rows[i].Cells[4].Value = cmbNOprMat.Text;
                        dgvNOorder.Rows[i].Cells[5].Value = txtNOprW.Text;
                        dgvNOorder.Rows[i].Cells[6].Value = txtNOprL.Text;
                        dgvNOorder.Rows[i].Cells[7].Value = txtNOprQnt.Text;
                        dgvNOorder.Rows[i].Cells[8].Value = txtNOprSM.Text;
                        dgvNOorder.Rows[i].Cells[9].Value = txtNOprPrice.Text;
                        dgvNOorder.Rows[i].Cells[10].Value = txtNOprVal.Text;

                        // Increment the row index for the next data entry
                        i++;
                        break;
                    }
                    else if (dgvNOorder.Rows[i].Cells[2].Value?.ToString() == textBox1.Text)
                    {
                        dgvNOorder.Rows[i].Cells[3].Value = cmbNOprMash.Text;
                        dgvNOorder.Rows[i].Cells[4].Value = cmbNOprMat.Text;
                        dgvNOorder.Rows[i].Cells[5].Value = txtNOprW.Text;
                        dgvNOorder.Rows[i].Cells[6].Value = txtNOprL.Text;
                        dgvNOorder.Rows[i].Cells[7].Value = txtNOprQnt.Text;
                        dgvNOorder.Rows[i].Cells[8].Value = txtNOprSM.Text;
                        dgvNOorder.Rows[i].Cells[9].Value = txtNOprPrice.Text;
                        dgvNOorder.Rows[i].Cells[10].Value = txtNOprVal.Text;
                        //nextRowIndex++;
                        // Exit the loop as we have found and completed the desired row
                        break;
                    }
                }

            }
            UpdateTextBoxe1FromDataGridView();
            txtNOprW.Text = "";
            txtNOprL.Text = "";
            txtNOprQnt.Text = "";
            txtNOprSM.Text = "";
            txtNOprPrice.Text = "";
            txtNOprVal.Text = "";
            txtNOservQnt.Text = "";
            CountTotaldgvrowVal();
        }
        private void btnNOprSave_Click(object sender, EventArgs e)
        {
            string targetValue = textBox1.Text; // Value to match in Cells[2]

            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                // Check if the value in Cells[2] matches the target value
                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == targetValue)
                {
                    row.Cells[3].Value = cmbNOprMash.Text;
                    row.Cells[4].Value = cmbNOprMat.Text;
                    row.Cells[5].Value = txtNOprW.Text;
                    row.Cells[6].Value = txtNOprL.Text;
                    row.Cells[7].Value = txtNOprQnt.Text;
                    row.Cells[8].Value = txtNOprSM.Text;
                    row.Cells[9].Value = txtNOprPrice.Text;
                    row.Cells[10].Value = txtNOprVal.Text;
                    row.Cells[11].Value = txtNOdefSM.Text;
                    row.Cells[12].Value = txtNOdefPrice.Text;
                    row.Cells[13].Value = txtNOdefVal.Text;
                    row.Cells[14].Value = txtNOluvQnt.Text;
                    row.Cells[15].Value = txtNOluvPrice.Text;
                    row.Cells[16].Value = txtNOluvVal.Text;
                    if (txtKoxm.Text == "Ծ")
                    {
                        row.Cells[17].Value = cmbNOserv.Text;
                        row.Cells[18].Value = txtNOservQnt.Text;
                        row.Cells[19].Value = txtNOservPrice.Text;
                        row.Cells[20].Value = txtNOservVal.Text;
                        row.Cells[28].Value = txtServKoxm.Text;
                    }
                    else if (txtKoxm.Text == "Վ")
                    {
                        row.Cells[17].Value = cmbNOstand.Text;
                        row.Cells[18].Value = txtNOstandQnt.Text;
                        row.Cells[19].Value = txtNOstandPrice.Text;
                        row.Cells[20].Value = txtNOstandVal.Text;
                        row.Cells[28].Value = txtStandKoxm.Text;
                    }

                    row.Cells[21].Value = txtNOcost.Text;
                    row.Cells[22].Value = txtNOcostQnt.Text;
                    row.Cells[23].Value = txtNOcostPrice.Text;
                    row.Cells[24].Value = txtNOcostVal.Text;
                    row.Cells[27].Value = txtNOnote.Text;
                    row.Cells[25].Value = txtNOsale.Text;

                }
            }
            AddDefDgv();
            CountTotaldgvrowVal();
            CountTotalVal();
            CountTotalQM();
            UpdateTextBoxe1FromDataGridView();
            ClearText();
        }
        //ավելացնում ենք Փոքր աղյուսակ
        private int nextDefectRowIndex = 0;
        private void AddDefDgv()
        {
            dgvNOdefect.Rows.Clear();
            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                int nextDefectRowIndex = dgvNOdefect.Rows.Add();

                dgvNOdefect.Rows[nextDefectRowIndex].Cells[0].Value = row.Cells[3].Value;
                dgvNOdefect.Rows[nextDefectRowIndex].Cells[1].Value = row.Cells[4].Value;
                dgvNOdefect.Rows[nextDefectRowIndex].Cells[2].Value = row.Cells[5].Value;
                dgvNOdefect.Rows[nextDefectRowIndex].Cells[3].Value = row.Cells[6].Value;
                dgvNOdefect.Rows[nextDefectRowIndex].Cells[4].Value = row.Cells[7].Value;
                dgvNOdefect.Rows[nextDefectRowIndex].Cells[5].Value = row.Cells[8].Value;
            }

        }
        private void btnNOprDel_Click(object sender, EventArgs e)
        {
            cmbNOprMat.Text = "";
            cmbNOprMat.Text = "";
            txtNOprW.Text = "";
            txtNOprL.Text = "";
            txtNOprQnt.Text = "";
            txtNOprSM.Text = "";
            txtNOprPrice.Text = "";
            txtNOprVal.Text = "";
            txtNOservQnt.Text = "";
            txtNOdefSM.Text = "";
            txtNOdefPrice.Text = "";
            txtNOdefVal.Text = "";
        }

        //-------------------------------------  Խոտան --------------------------------------------


        //Հաշվարկում ենք անհրաժեշտ նվազագույն բարձրությունը (b)
        private void CalculateOptim()
        {
            try
            {
                // Step 1: Retrieve material width from textBox1
                decimal materialWidth = 0; // Default value
                if (!string.IsNullOrEmpty(txtNOdefWightMat.Text))
                {
                    decimal.TryParse(txtNOdefWightMat.Text, out materialWidth);
                }

                // Step 2: Retrieve selected values from combo boxes
                string selectedPrMach = cmbNOprMash.Text;
                string selectedMat = cmbNOprMat.Text;

                // Step 3: Retrieve file sizes from dataGridView
                List<File> files = new List<File>();
                foreach (DataGridViewRow row in dgvNOdefect.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string prMachValue = row.Cells[0].Value?.ToString();
                        string matValue = row.Cells[1].Value?.ToString();

                        if (prMachValue == selectedPrMach && matValue == selectedMat)
                        {
                            decimal width = 0;
                            decimal length = 0;
                            int quantity = 0;

                            if (row.Cells[2].Value != null && row.Cells[3].Value != null && row.Cells[4].Value != null)
                            {
                                decimal.TryParse(row.Cells[2].Value.ToString(), out width);
                                decimal.TryParse(row.Cells[3].Value.ToString(), out length);
                                int.TryParse(row.Cells[4].Value.ToString(), out quantity);

                                files.Add(new File(width, length, quantity));
                            }
                        }
                    }
                }

                // Step 4: Calculate minimum length of the material needed
                decimal minLengthNeeded = 0;
                foreach (var file in files)
                {
                    decimal lengthNeeded = 0;
                    decimal widthNeeded = 0;

                    // Try to fit horizontally
                    if (file.Width <= materialWidth)
                    {
                        widthNeeded = file.Width;
                        lengthNeeded = file.Length;
                    }
                    else
                    {
                        // Try to fit vertically
                        widthNeeded = materialWidth;
                        lengthNeeded = Math.Ceiling(file.Length * file.Quantity / materialWidth);
                    }

                    minLengthNeeded = Math.Max(minLengthNeeded, lengthNeeded);
                }

                // Step 5: Display the result in textBox2
                txtNOdefLenghtNeed.Text = minLengthNeeded.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalculateOptimalLength(decimal materialWidth, List<File> files)
        {
            decimal totalLengthNeeded = decimal.MaxValue;

            // Generate all possible orientations for each file
            List<List<File>> allOrientations = GenerateOrientations(files);

            // Check each orientation to find the one with the minimum length needed
            foreach (var orientation in allOrientations)
            {
                decimal lengthNeeded = CalculateLengthNeeded(materialWidth, orientation);
                totalLengthNeeded = Math.Min(totalLengthNeeded, lengthNeeded);
            }

            return totalLengthNeeded;
        }

        private List<List<File>> GenerateOrientations(List<File> files)
        {
            decimal materialWidth = decimal.Parse(txtNOdefWightMat.Text); // Retrieve material width from the textbox
            List<List<File>> allOrientations = new List<List<File>>();
            GenerateOrientationsHelper(files, 0, new List<File>(), allOrientations, materialWidth);
            return allOrientations;
        }

        private void GenerateOrientationsHelper(List<File> files, int index, List<File> currentOrientation, List<List<File>> allOrientations, decimal materialWidth)
        {
            if (index == files.Count)
            {
                decimal totalWidth = CalculateTotalWidth(currentOrientation);
                if (totalWidth <= materialWidth)
                {
                    allOrientations.Add(new List<File>(currentOrientation));
                }
                return;
            }

            // Consider the file in its original orientation
            currentOrientation.Add(files[index]);
            GenerateOrientationsHelper(files, index + 1, currentOrientation, allOrientations, materialWidth);
            currentOrientation.RemoveAt(currentOrientation.Count - 1);

            // Consider the file rotated
            currentOrientation.Add(new File(files[index].Length, files[index].Width, files[index].Quantity));
            GenerateOrientationsHelper(files, index + 1, currentOrientation, allOrientations, materialWidth);
            currentOrientation.RemoveAt(currentOrientation.Count - 1);
        }

        private decimal CalculateTotalWidth(List<File> files)
        {
            decimal totalWidth = 0;
            foreach (var file in files)
            {
                totalWidth += file.Width * file.Quantity;
            }
            return totalWidth;
        }

        private decimal CalculateLengthNeeded(decimal materialWidth, List<File> files)
        {
            decimal totalLengthNeeded = 0;
            decimal remainingWidth = materialWidth;

            foreach (var file in files)
            {
                if (file.Width <= remainingWidth)
                {
                    remainingWidth -= file.Width;
                    totalLengthNeeded = Math.Max(totalLengthNeeded, file.Length);
                }
                else
                {
                    totalLengthNeeded += file.Length;
                    remainingWidth = materialWidth - file.Width;
                }
            }

            return totalLengthNeeded;
        }

        //Հաշվում ենք փոքր աղյուսակում երևացող տպագրության ընդհանուր քմ և ավելացնում txtDefTotalSM (c)
        private void DefCalculateCheck()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dgvNOdefect.Rows)
            {
                // Check if the row is visible and the cell value is not null and is a valid decimal
                if (row.Visible && row.Cells["dgvDefSM"].Value != null && decimal.TryParse(row.Cells["dgvDefSM"].Value.ToString(), out decimal value))
                {
                    sum += value;
                }
            }
            txtDefTotalSM.Text = sum.ToString();

        }
        //Հաշվում ենք խոտանի քմ՝ լայնք * բարձր - քմ (d)(a * b - c)
        private void DefCalculateAuto()
        {
            if (!string.IsNullOrEmpty(txtNOdefWightMat.Text) && !string.IsNullOrEmpty(txtNOdefLenghtNeed.Text) && !string.IsNullOrEmpty(txtNOdefLenghtNeed.Text))
            {
                decimal width = Convert.ToDecimal(txtNOdefWightMat.Text);
                decimal lenght = Convert.ToDecimal(txtNOdefLenghtNeed.Text);
                decimal sqm = Convert.ToDecimal(txtDefTotalSM.Text);
                decimal def = lenght * width - sqm;
                txtNOdefSM.Text = def.ToString();
            }
        }
        //Հաշվում ենք խոտանի արժեքը՝ d * գին
        private void CountValDef()
        {
            if (!string.IsNullOrEmpty(txtNOdefSM.Text) && !string.IsNullOrEmpty(txtNOdefPrice.Text))
            {
                int dfPrice = Convert.ToInt32(txtNOdefPrice.Text);
                decimal dfSM = Convert.ToDecimal(txtNOdefSM.Text);
                decimal dfVal = dfSM * dfPrice;

                //txtDefPrice.Text = dfPrice.ToString("#,0");
                txtNOdefVal.Text = dfVal.ToString("#,0");
            }
        }
        //Խոտանի հետ կապ ունեցող յուր վանդակում թվի փոփոխությունից քմ-ի և արժեքի փոխվելը /Հաջորդող 2 մեթոդները
        private void UpdateDefvalCalculations(object sender, EventArgs e)
        {
            CountValDef();
            CalculateOptim();
        }
        private void GetDefVal()
        {
            txtDefTotalSM.TextChanged += UpdateDefvalCalculations;
            txtNOdefWightMat.TextChanged += UpdateDefvalCalculations;
            txtNOdefLenghtNeed.TextChanged += UpdateDefvalCalculations;
            txtNOdefSM.TextChanged += UpdateDefvalCalculations;
            txtNOdefPrice.TextChanged += UpdateDefvalCalculations;
        }
        private void txtLenghtNeed_TextChanged(object sender, EventArgs e)
        {
            CountValDef();
            cbDef_CheckedChanged(sender, e);
        }
        //Խոտանի չեքբոքսի փոփոխությունները
        private void cbDef_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDef.Checked)
            {
                txtNOdefWightMat.Visible = true;
                txtNOdefLenghtNeed.Visible = true;
                dgvNOdefect.Visible = true;
                dgvNOdefect.Columns["տող"].Visible = false;
                txtDefTotalSM.Visible = true;
                txtNOdefSM.Enabled = false;
                DefCalculateCheck();
                DefCalculateAuto();
                CalculateOptim();
                CountValDef();
                GetDefVal();
            }
            else
            {
                txtNOdefWightMat.Visible = false;
                txtNOdefLenghtNeed.Visible = false;
                dgvNOdefect.Visible = false;
                txtDefTotalSM.Visible = false;
                txtNOdefSM.Enabled = true;
                CountValDef();
            }
        }
        //Խոտանի թվերը ավելացնենք հիմնական աղյուսակ՝ տողի համապատասխան
        private void defAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvNOorder.Rows.Count; i++)
            {
                if (dgvNOorder.Rows[i].Cells[3].Value?.ToString() == cmbNOprMash.Text && dgvNOorder.Rows[i].Cells[4].Value?.ToString() == cmbNOprMat.Text)
                {
                    // If the condition is met, complete Cells[9] to Cells[11] in that row
                    dgvNOorder.Rows[i].Cells[11].Value = txtNOdefSM.Text;
                    dgvNOorder.Rows[i].Cells[12].Value = txtNOdefPrice.Text;
                    dgvNOorder.Rows[i].Cells[13].Value = txtNOdefVal.Text;

                    // Exit the loop as we have found and completed the desired row
                    break;
                }
            }
            txtNOdefSM.Text = "";
            txtNOdefPrice.Text = "";
            txtNOdefVal.Text = "";
            CountTotaldgvrowVal();
            CountTotalVal();
        }
        private void btnNOdefDel_Click(object sender, EventArgs e)
        {
            txtNOdefSM.Text = "";
            txtNOdefPrice.Text = "";
            txtNOdefVal.Text = "";
        }

        //---------------------------------------  Կոճգամ  ------------------------------------------

        private void cbLuv_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLuv.Checked)
            {
                txtNOluvCm.Visible = true;
                label3.Visible = true;
                dgvNOdefect.Visible = true;
                txtNOluvQnt.Enabled = false;
                btnNOluvCount.Visible = true;
            }
            else
            {
                txtNOluvCm.Visible = false;
                label3.Visible = false;
                dgvNOdefect.Visible = false;
                txtNOluvQnt.Enabled = true;
                btnNOluvCount.Visible = false;
            }
        }
        //Հաշվում ենք օղակների քանակը ավտոմատ

        DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
        private void LuversDataCheckbox()
        {
            decimal total = 0;
            try
            {
                foreach (DataGridViewRow row in dgvNOdefect.Rows)
                {
                    bool checkBoxCell = Convert.ToBoolean(row.Cells[7].Value);
                    if (checkBoxCell)
                    {
                        decimal column3 = Convert.ToDecimal(row.Cells[2].Value);
                        decimal column4 = Convert.ToDecimal(row.Cells[3].Value);
                        decimal column5 = Convert.ToDecimal(row.Cells[4].Value);

                        decimal textBox1Value;
                        if (!decimal.TryParse(txtNOluvCm.Text, out textBox1Value))
                        {
                            MessageBox.Show("Մուտքագրե՛ք ճիշտ թիվ, քանի սանտի");
                            return;
                        }

                        decimal cm = textBox1Value / 100;
                        decimal result = (column3 + column4) * 2 * column5 / cm;

                        // Display the calculated result in another column (e.g., column index 6)
                        row.Cells[6].Value = (int)Math.Floor(result);

                        // Round down the decimal value to the nearest integer
                        int roundedResult = (int)Math.Floor(result);
                        total += roundedResult;
                    }
                    else
                    {
                        row.Cells[6].Value = 0;
                    }
                }
                txtNOluvQnt.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        //օղակները համագումարը գրվում է ցուցակում
        private void button1_Click(object sender, EventArgs e)
        {
            LuversDataCheckbox();
        }
        //Հաշվում ենք օղակների արժեքը
        private void CountLuvVal()
        {
            if (!string.IsNullOrEmpty(txtNOluvQnt.Text) && !string.IsNullOrEmpty(txtNOluvPrice.Text))
            {
                decimal luvQnt = Convert.ToDecimal(txtNOluvQnt.Text);
                decimal luvPrice = Convert.ToDecimal(txtNOluvPrice.Text);
                decimal luvVal = luvQnt * luvPrice;

                txtNOluvVal.Text = luvVal.ToString("#,0");
            }
        }
        //Օղակի հետ կապ ունեցող յուր վանդակում թվի փոփոխությունից քմ-ի և արժեքի փոխվելը /Հաջորդող 2 մեթոդները
        private void UpdateLuvValCalculation(object sender, EventArgs e)
        {
            CountLuvVal();
        }
        private void GetLuvVal()
        {
            txtNOluvQnt.TextChanged += UpdateLuvValCalculation;
            txtNOluvPrice.TextChanged += UpdateLuvValCalculation;
        }
        //Օղակի թվերն ավելացնում ենք աղյուսակ՝ նյութի համապատասխան
        private void luvAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvNOorder.Rows.Count; i++)
            {
                if (dgvNOorder.Rows[i].Cells[3].Value?.ToString() == cmbNOprMash.Text && dgvNOorder.Rows[i].Cells[4].Value?.ToString() == cmbNOprMat.Text)
                {
                    // If the condition is met, complete Cells[9] to Cells[11] in that row
                    dgvNOorder.Rows[i].Cells[14].Value = txtNOluvQnt.Text;
                    dgvNOorder.Rows[i].Cells[15].Value = txtNOluvPrice.Text;
                    dgvNOorder.Rows[i].Cells[16].Value = txtNOluvVal.Text;

                    // Exit the loop as we have found and completed the desired row
                    break;
                }
            }
            txtNOluvQnt.Text = "";
            txtNOluvPrice.Text = "";
            txtNOluvVal.Text = "";
            CountTotaldgvrowVal();
            CountTotalVal();
        }

        private void btnNOluvDel_Click(object sender, EventArgs e)
        {
            txtNOluvQnt.Text = "";
            txtNOluvPrice.Text = "";
            txtNOluvVal.Text = "";
            CountTotalVal();
        }

        //---------------------------------------  Ծառայություն  --------------------------------------

        //Հաշվում ենք ծառայության արժեքը
        private void CountServVal()
        {
            if (!string.IsNullOrEmpty(txtNOservQnt.Text) && !string.IsNullOrEmpty(txtNOservPrice.Text))
            {
                decimal servQnt = Convert.ToDecimal(txtNOservQnt.Text);
                decimal servPrice = Convert.ToDecimal(txtNOservPrice.Text);
                decimal servVal = servQnt * servPrice;

                txtNOservVal.Text = servVal.ToString("#,0");
            }
        }
        //Ծառ. հետ կապված յուր վանդակում թվի փոփոխությամբ փոխվում է արժեք
        private void UpdateServValCalculation(object sender, EventArgs e)
        {
            CountServVal();
        }
        private void GetServVal()
        {
            txtNOservQnt.TextChanged += UpdateServValCalculation;
            txtNOservPrice.TextChanged += UpdateServValCalculation;
        }
        //Ավելացնում ենք ծառայության տվյալները
        private void servAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvNOorder.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dgvNOorder.Rows[i].Cells[2].Value?.ToString()))
                {
                    dgvNOorder.Rows.Add();
                    dgvNOorder.Rows[i].Cells[0].Value = dtpNO.Text;
                    dgvNOorder.Rows[i].Cells[1].Value = txtNOid.Text;
                    dgvNOorder.Rows[i].Cells[2].Value = textBox2.Text;
                    dgvNOorder.Rows[i].Cells[17].Value = cmbNOserv.Text;
                    dgvNOorder.Rows[i].Cells[18].Value = txtNOservQnt.Text;
                    dgvNOorder.Rows[i].Cells[19].Value = txtNOservPrice.Text;
                    dgvNOorder.Rows[i].Cells[20].Value = txtNOservVal.Text;
                    dgvNOorder.Rows[i].Cells[28].Value = txtServKoxm.Text;
                    i++;

                    // Exit the loop as we have found and completed the desired row
                    break;
                }
                else if (dgvNOorder.Rows[i].Cells[2].Value?.ToString() == textBox2.Text)
                {
                    dgvNOorder.Rows[i].Cells[17].Value = cmbNOserv.Text;
                    dgvNOorder.Rows[i].Cells[18].Value = txtNOservQnt.Text;
                    dgvNOorder.Rows[i].Cells[19].Value = txtNOservPrice.Text;
                    dgvNOorder.Rows[i].Cells[20].Value = txtNOservVal.Text;
                    dgvNOorder.Rows[i].Cells[28].Value = txtServKoxm.Text;

                    // Exit the loop as we have found and completed the desired row
                    break;
                }
            }
            UpdateTextBoxe2FromDataGridView();
            cmbNOserv.Text = "";
            txtNOservQnt.Text = "";
            txtNOservPrice.Text = "";
            txtNOservVal.Text = "";
            CountTotaldgvrowVal();
            CountTotalVal();
        }
        private void btnNOservDel_Click(object sender, EventArgs e)
        {
            cmbNOserv.Text = "";
            txtNOservQnt.Text = "";
            txtNOservPrice.Text = "";
            txtNOservVal.Text = "";
            CountTotalVal();
        }

        //----------------------------------------  Վահանակ  ------------------------------------------

        //Հաշվում ենք վահանակի արժեքը
        private void CountStandVal()
        {
            if (!string.IsNullOrEmpty(txtNOstandQnt.Text) && !string.IsNullOrEmpty(txtNOstandPrice.Text))
            {
                decimal stdQnt = Convert.ToDecimal(txtNOstandQnt.Text);
                decimal stdPrice = Convert.ToDecimal(txtNOstandPrice.Text);
                decimal stdVal = stdQnt * stdPrice;

                txtNOstandVal.Text = stdVal.ToString("#,0");
            }
        }
        //Վահանակի հետ կապված յուր թվի փոփոխությամբ փոխվում է արժեք
        private void UpdateStandValCalculation(object sender, EventArgs e)
        {
            CountStandVal();
        }
        private void GetStandVal()
        {
            txtNOstandQnt.TextChanged += UpdateStandValCalculation;
            txtNOstandPrice.TextChanged += UpdateStandValCalculation;
        }
        //Ավելացնում ենք վահանակի տվյալները
        private void stndAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvNOorder.Rows.Count; i++)
            {
                if (dgvNOorder.Rows[i].Cells[2].Value?.ToString() == textBox2.Text)
                {
                    dgvNOorder.Rows[i].Cells[17].Value = cmbNOstand.Text;
                    dgvNOorder.Rows[i].Cells[18].Value = txtNOstandQnt.Text;
                    dgvNOorder.Rows[i].Cells[19].Value = txtNOstandPrice.Text;
                    dgvNOorder.Rows[i].Cells[20].Value = txtNOstandVal.Text;
                    dgvNOorder.Rows[i].Cells[28].Value = txtStandKoxm.Text;

                    // Exit the loop as we have found and completed the desired row
                    break;
                }
                else if (string.IsNullOrEmpty(dgvNOorder.Rows[i].Cells[2].Value?.ToString()))
                {
                    dgvNOorder.Rows.Add();
                    dgvNOorder.Rows[i].Cells[0].Value = dtpNO.Text;
                    dgvNOorder.Rows[i].Cells[1].Value = txtNOid.Text;
                    dgvNOorder.Rows[i].Cells[2].Value = textBox2.Text;
                    dgvNOorder.Rows[i].Cells[17].Value = cmbNOstand.Text;
                    dgvNOorder.Rows[i].Cells[18].Value = txtNOstandQnt.Text;
                    dgvNOorder.Rows[i].Cells[19].Value = txtNOstandPrice.Text;
                    dgvNOorder.Rows[i].Cells[20].Value = txtNOstandVal.Text;
                    dgvNOorder.Rows[i].Cells[28].Value = txtStandKoxm.Text;
                    i++;
                    // Exit the loop as we have found and completed the desired row
                    break;
                }
            }
            UpdateTextBoxe2FromDataGridView();
            cmbNOstand.Text = "";
            txtNOstandQnt.Text = "";
            txtNOstandPrice.Text = "";
            txtNOstandVal.Text = "";
            CountTotaldgvrowVal();
            CountTotalVal();
        }
        private void btnNOstndDel_Click(object sender, EventArgs e)
        {
            cmbNOstand.Text = "";
            txtNOstandQnt.Text = "";
            txtNOstandPrice.Text = "";
            txtNOstandVal.Text = "";
        }

        //---------------------------------------- Ծախսեր ----------------------------------------------
        private void CountCostVal()
        {
            if (!string.IsNullOrEmpty(txtNOcostQnt.Text) && !string.IsNullOrEmpty(txtNOcostPrice.Text))
            {
                decimal cstQnt = Convert.ToDecimal(txtNOcostQnt.Text);
                decimal cstPrice = Convert.ToDecimal(txtNOcostPrice.Text);
                decimal cstVal = cstQnt * cstPrice;

                txtNOcostVal.Text = cstVal.ToString("#,0");
            }
        }
        private void UpdateCostValCalculation(object sender, EventArgs e)
        {
            CountCostVal();
        }
        private void GetCostVal()
        {
            txtNOcostQnt.TextChanged += UpdateCostValCalculation;
            txtNOcostPrice.TextChanged += UpdateCostValCalculation;
        }
        private void btnNOcostAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvNOorder.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dgvNOorder.Rows[i].Cells[2].Value?.ToString()))
                {
                    dgvNOorder.Rows.Add();
                    dgvNOorder.Rows[i].Cells[0].Value = dtpNO.Text;
                    dgvNOorder.Rows[i].Cells[1].Value = txtNOid.Text;
                    dgvNOorder.Rows[i].Cells[2].Value = textBox3.Text;
                    dgvNOorder.Rows[i].Cells[21].Value = txtNOcost.Text;
                    dgvNOorder.Rows[i].Cells[22].Value = txtNOcostQnt.Text;
                    dgvNOorder.Rows[i].Cells[23].Value = txtNOcostPrice.Text;
                    dgvNOorder.Rows[i].Cells[24].Value = txtNOcostVal.Text;
                    i++;

                    // Exit the loop as we have found and completed the desired row
                    break;
                }
                else if (dgvNOorder.Rows[i].Cells[2].Value?.ToString() == textBox3.Text)
                {
                    dgvNOorder.Rows[i].Cells[21].Value = txtNOcost.Text;
                    dgvNOorder.Rows[i].Cells[22].Value = txtNOcostQnt.Text;
                    dgvNOorder.Rows[i].Cells[23].Value = txtNOcostPrice.Text;
                    dgvNOorder.Rows[i].Cells[24].Value = txtNOcostVal.Text;

                    // Exit the loop as we have found and completed the desired row
                    break;
                }
            }
            UpdateTextBoxe3FromDataGridView();
            txtNOcost.Text = "";
            txtNOcostQnt.Text = "";
            txtNOcostPrice.Text = "";
            txtNOcostVal.Text = "";
            CountTotaldgvrowVal();
            CountTotalVal();

        }
        private void btnNOcostDel_Click(object sender, EventArgs e)
        {
            txtNOcost.Text = "";
            txtNOcostQnt.Text = "";
            txtNOcostPrice.Text = "";
            txtNOcostVal.Text = "";
        }

        //---------------------------------------- Մեկնաբանություն --------------------------------------

        private void btnNOsaleAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvNOorder.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dgvNOorder.Rows[i].Cells[2].Value?.ToString()))
                {
                    dgvNOorder.Rows.Add();
                    dgvNOorder.Rows[i].Cells[0].Value = dtpNO.Text;
                    dgvNOorder.Rows[i].Cells[1].Value = txtNOid.Text;
                    dgvNOorder.Rows[i].Cells[2].Value = textBox4.Text;
                    dgvNOorder.Rows[i].Cells[27].Value = txtNOnote.Text;
                    dgvNOorder.Rows[i].Cells[25].Value = txtNOsale.Text;

                    i++;

                    // Exit the loop as we have found and completed the desired row
                    break;
                }
                else if (dgvNOorder.Rows[i].Cells[2].Value?.ToString() == textBox3.Text)
                {
                    dgvNOorder.Rows[i].Cells[27].Value = txtNOnote.Text;
                    dgvNOorder.Rows[i].Cells[25].Value = txtNOsale.Text;

                    // Exit the loop as we have found and completed the desired row
                    break;
                }
            }
            UpdateTextBoxe4FromDataGridView();
            txtNOnote.Text = "";
            txtNOsale.Text = "";
            CountTotaldgvrowVal();
            CountTotalVal();
        }

        private void btnNOsaleDel_Click(object sender, EventArgs e)
        {
            txtNOnote.Text = "";
            txtNOsale.Text = "";
        }
        //---------------------------------------- Աղյուսակի համագումար ---------------------------------

        private void CountTotaldgvrowVal()
        {
            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal value1 = 0;
                    decimal value2 = 0;
                    decimal value3 = 0;
                    decimal value4 = 0;
                    decimal value5 = 0;
                    decimal value6 = 0;
                    int value7;
                    int value8;

                    // Parse decimal values from cells 1, 2, and 3
                    decimal.TryParse(row.Cells[10].Value?.ToString(), out value1);
                    decimal.TryParse(row.Cells[13].Value?.ToString(), out value2);
                    decimal.TryParse(row.Cells[16].Value?.ToString(), out value3);
                    decimal.TryParse(row.Cells[20].Value?.ToString(), out value4);
                    decimal.TryParse(row.Cells[24].Value?.ToString(), out value5);
                    decimal.TryParse(row.Cells[25].Value?.ToString(), out value6);

                    // Calculate the sum of the decimal values
                    decimal sum = value1 + value2 + value3 + value4 + value5 + value6;

                    // Convert the sum to an integer
                    int result = Decimal.ToInt32(sum);

                    // Assign the integer value to cell 4
                    row.Cells[26].Value = result.ToString("#,0");

                }
            }
        }
        private void CountTotalVal()
        {
            decimal totalVal = 0;

            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Get the value from the cell
                    object cellValue = row.Cells[26].Value;

                    if (cellValue != null)
                    {
                        string formattedValue = cellValue.ToString().Replace(".", "");

                        if (decimal.TryParse(formattedValue, out decimal value))
                        {
                            totalVal += value;
                        }
                        else
                        {
                            // Handle parsing error or display a message
                            MessageBox.Show("Error: Invalid value in DataGridView.");
                        }
                    }
                }
            }

            if (rbNOpayCash.Checked)
            {
                txtNOval.Text = totalVal.ToString("#,0");
                txtNOval.ForeColor = Color.Black;
                txtNOvalNds.Text = "";
                txtNOvalTotal.Text = "";
                txtPayType.Text = "Կ";
            }
            else if (rbNOpayHdm.Checked)
            {
                // Calculate the total value with a 20% surcharge
                decimal valWithAah = totalVal * 1.20m;
                txtNOvalTotal.Text = valWithAah.ToString("#,0");
                txtNOvalTotal.ForeColor = Color.Black;
                txtNOval.Text = totalVal.ToString("#,0");
                txtNOval.ForeColor = Color.Gray;
                txtNOvalNds.Text = "";
                txtPayType.Text = "Հ";
            }
            else if (rbNOpayAtm.Checked)
            {
                decimal valWithAah = totalVal * 1.20m;
                txtNOvalTotal.Text = valWithAah.ToString("#,0");
                txtNOvalTotal.ForeColor = Color.Black;
                txtNOval.Text = totalVal.ToString("#,0");
                txtNOval.ForeColor = Color.Gray;
                txtNOvalNds.Text = "";
                txtPayType.Text = "Ք";
            }
            else if (rbNOpayAccount.Checked)
            {
                txtNOval.Text = totalVal.ToString("#,0");
                txtNOval.ForeColor = Color.Black;
                decimal valWithAah = totalVal * 1.20m;
                txtNOvalTotal.Text = valWithAah.ToString("#,0");
                txtNOvalTotal.ForeColor = Color.Black;
                decimal aaH = totalVal * 20 / 100;
                txtNOvalNds.Text = aaH.ToString("#,0");
                txtNOvalNds.ForeColor = Color.Black;
                txtPayType.Text = "Փ";
            }
        }
        private void CountTotalQM()
        {
            decimal totalQM = 0;

            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[4].Value?.ToString() == cmbNOprMat.Text && row.Cells[3].Value?.ToString() == cmbNOprMash.Text)
                    {
                        // Get the value from the cell
                        object cellValue = row.Cells[8].Value;

                        if (cellValue != null)
                        {
                            // Remove only comma separators and leave the decimal point for parsing
                            string formattedValue = cellValue.ToString().Replace(",", "");

                            if (decimal.TryParse(formattedValue, out decimal value))
                            {
                                totalQM += value;
                            }
                            else
                            {
                                // Handle parsing error or display a message
                                MessageBox.Show("Error: Invalid value in DataGridView.");
                            }
                        }
                    }
                }
            }

            // Update the TextBox without thousands separators and with two decimal places
            txtTotalQM.Text = totalQM.ToString("0.00");
        }

        //---------------------------------------- ՌադիոԲաթոնի փոփոխություն ----------------------------

        private void rbNOpayCash_CheckedChanged(object sender, EventArgs e)
        {
            CountTotalVal();
        }
        private void rbNOpayHdm_CheckedChanged(object sender, EventArgs e)
        {
            CountTotalVal();
        }
        private void rbNOpayAtm_CheckedChanged(object sender, EventArgs e)
        {
            CountTotalVal();
        }
        private void rbNOpayAccount_CheckedChanged(object sender, EventArgs e)
        {
            CountTotalVal();
        }
        //---------------------------------------Սևագրի փոփոխությունը-------------------------------------

        private void cbDraft_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDraft.Checked == true)
            {
                txtDraft.Text = "Ս";
            }
            else
            {
                txtDraft.Text = "Պ";
            }
        }

        private void CbdraftbyDubleClick()
        {
            if (txtDraft.Text == "Ս")
            {
                cbDraft.Checked = true;
            }
            else
            {
                cbDraft.Checked = false;
            }
        }

        //------Պարտքերի կառվարման աղյուսակի համար կոդ
        private void GetDebtItemId()
        {
            Test newTest = new Test();
            txtDebtId.Text = newTest.GetItemId();
        }

        //------------------------------------------- Ավելացնել -------------------------------------------


        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void insert()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler?.Invoke(this, args);
        }
        private void btnNOAdd_Click(object sender, EventArgs e)
        {
            GetDebtItemId();
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon))
            {
                SqlTransaction transaction = null;

                try
                {
                    con.Open(); // Open connection only once
                    transaction = con.BeginTransaction();

                    // Pass connection and transaction to each method
                    AddItemToDebtsControl(con, transaction);
                    AddItemToGridview(con, transaction);
                    AddItemToStock(con, transaction);

                    // Commit transaction only if all methods succeed
                    transaction.Commit();
                    //MessageBox.Show("Data added successfully!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Roll back the transaction if any operation fails
                    if (transaction != null)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            MessageBox.Show("Rollback failed: " + rollbackEx.Message);
                        }
                    }

                    // Display error message
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                // No need to explicitly close the connection here, as the "using" block will handle it
            }
            this.Close();
            insert();
        }
        public void AddItemToGridview(SqlConnection con, SqlTransaction transaction)
        {
            if (txtNOid.Text == "" || txtNOval.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
            }

            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                if (row.Cells[2].Value == null) continue;

                using (SqlCommand cmd = new SqlCommand("INSERT INTO TblOrders (Ամսաթիվ, [Պատվ. համ], Հաճախորդ, Միջնորդ, [Վճ. եղանակ], Արժեք, ԱԱՀ, Ընդհանուր, hh, [տ/մ], Նյութ, Լայնք, [Բարձ.], Քանակ, ՔՄ, Գին, [Տպ. արժեք], [Խոտան քմ], [Խոտան գին], [Խոտան արժեք], [Կոճգամ քան.], [Կոճգամ գին], [Կոճգամ արժեք], Լրացուցիչ, [Լր. քան.], [Լր. գին], [Լր. արժեք], Ծախս, [Ծախս քան.], [Ծախս գին], [Ծախս արժեք], Զեղչ, Մեկնաբանություն, Սևագիր, ՊԿկոդ) " +
                        "VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9, @Column10, @Column11, @Column12, @Column13, @Column14, @Column15, @Column16, @Column17, @Column18, @Column19, @Column20," +
                        " @Column21, @Column22, @Column23, @Column24, @Column25, @Column26, @Column27, @Column28, @Column29, @Column30, @Column31, @Column32, @Column33, @Column34, @Column35)", con, transaction))
                {
                    DateTime selectedDateo = dtpNO.Value;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@Column1", selectedDateo);
                    cmd.Parameters.AddWithValue("@Column2", txtNOid.Text);
                    cmd.Parameters.AddWithValue("@Column3", cmbNOclient.Text);
                    cmd.Parameters.AddWithValue("@Column4", txtNOagent.Text);
                    cmd.Parameters.AddWithValue("@Column5", txtPayType.Text);

                    if (txtPayType.Text == "Հ")
                    {
                        cmd.Parameters.AddWithValue("@Column6", txtNOvalTotal.Text);
                        cmd.Parameters.AddWithValue("@Column7", "");
                        cmd.Parameters.AddWithValue("@Column8", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Column6", txtNOval.Text);
                        cmd.Parameters.AddWithValue("@Column7", txtNOvalNds.Text);
                        cmd.Parameters.AddWithValue("@Column8", txtNOvalTotal.Text);
                    }
                    cmd.Parameters.AddWithValue("@Column9", row.Cells[2].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column10", row.Cells[3].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column11", row.Cells[4].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column12", row.Cells[5].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column13", row.Cells[6].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column14", row.Cells[7].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column15", row.Cells[8].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column16", row.Cells[9].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column17", row.Cells[10].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column18", row.Cells[11].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column19", row.Cells[12].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column20", row.Cells[13].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column21", row.Cells[14].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column22", row.Cells[15].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column23", row.Cells[16].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column24", row.Cells[17].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column25", row.Cells[18].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column26", row.Cells[19].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column27", row.Cells[20].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column28", row.Cells[21].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column29", row.Cells[22].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column30", row.Cells[23].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column31", row.Cells[24].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column32", row.Cells[25].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column33", row.Cells[27].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column34", txtDraft.Text);
                    cmd.Parameters.AddWithValue("@Column35", txtDebtId.Text);

                    cmd.ExecuteNonQuery();
                }

            }

        }
        public void AddItemToDebtsControl(SqlConnection con, SqlTransaction transaction)
        {
            if (string.IsNullOrEmpty(txtNOid.Text)) return;

            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO TblDebtsControl (hh, Գործողություն, [վ/ե], Ամսաթիվ, Կոդ, Հաճախորդ, Արժեք, ԱԱՀ, Ընդհանուր) " +
                "VALUES (@ColumnID, @Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8)", con, transaction))
            {
                cmd.Parameters.AddWithValue("@ColumnID", txtDebtId.Text);
                cmd.Parameters.AddWithValue("@Column1", txtAction.Text);
                cmd.Parameters.AddWithValue("@Column2", txtPayType.Text);
                cmd.Parameters.AddWithValue("@Column3", dtpNO.Value);
                cmd.Parameters.AddWithValue("@Column4", txtNOid.Text);
                cmd.Parameters.AddWithValue("@Column5", cmbNOclient.Text);
                cmd.Parameters.AddWithValue("@Column6", txtNOval.Text);
                cmd.Parameters.AddWithValue("@Column7", txtNOvalNds.Text);
                cmd.Parameters.AddWithValue("@Column8", txtNOvalTotal.Text);

                cmd.ExecuteNonQuery();
            }
        }
        public void AddItemToStock(SqlConnection con, SqlTransaction transaction)
        {
            foreach (DataGridViewRow row in dgvNOorder.Rows)
            {
                if (row.Cells[2].Value == null) continue;

                using (SqlCommand cmd = new SqlCommand("INSERT INTO TblStockFlow (Ամսաթիվ, Կոդ, [տ/մ], Նյութ, [ՔՄ տպ], [Խոտան քմ], [Կոճգամ ելք], Վահանակ, [Վ ելք])" +
                            "VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9)", con, transaction))
                {
                    DateTime selectedDateo = dtpNO.Value;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@Column1", selectedDateo);
                    cmd.Parameters.AddWithValue("@Column2", txtNOid.Text);
                    cmd.Parameters.AddWithValue("@Column3", row.Cells[3].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column4", row.Cells[4].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column5", row.Cells[8].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column6", row.Cells[11].Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Column7", row.Cells[14].Value ?? DBNull.Value);

                    if (row.Cells[28].Value?.ToString() == "Վ")
                    {
                        cmd.Parameters.AddWithValue("@Column8", row.Cells[17].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Column9", row.Cells[18].Value ?? DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Column8", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Column9", DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }

        }

        //------------------------------------------ Խմբագրել --------------------------------------------

        //Orders-ում դաբլ քլիքի ժամանակ թեքսթբոքսերը լրացնելու համար
        public string TxtNOidText
        {
            get { return txtNOid.Text; }
            set
            {
                txtNOid.Text = value;
                txtNOidForEdit.Text = value; // Also update txtNOidForEdit
            }
        }
        public string dtpNOText
        {
            get { return dtpNO.Text; }
            set { dtpNO.Text = value; }
        }
        public string cmbNOclientText
        {
            get { return cmbNOclient.Text; }
            set { cmbNOclient.Text = value; }
        }
        public string txtNOagentText
        {
            get { return txtNOagent.Text; }
            set { txtNOagent.Text = value; }
        }
        public string txtPayTypeText
        {
            get { return txtPayType.Text; }
            set { txtPayType.Text = value; }
        }
        public string txtDraftText
        {
            get { return txtDraft.Text; }
            set { txtDraft.Text = value; }
        }
        public string txtDebtidText
        {
            get { return txtDebtId.Text; }
            set { txtDebtId.Text = value; }
        }
        //radiobutton-ը ընտրել
        public void GetRbtSelect()
        {
            if (txtPayType.Text == "Կ")
            {
                rbNOpayCash.Checked = true;
            }
            else if (txtPayType.Text == "Հ")
            {
                rbNOpayHdm.Checked = true;
            }
            else if (txtPayType.Text == "Ք")
            {
                rbNOpayAtm.Checked = true;
            }
            else if (txtPayType.Text == "Փ")
            {
                rbNOpayAccount.Checked = true;
            }
        }
        //Աղյուսակը

        public void PopulateDgvNOorderFromDatabase()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(10), Ամսաթիվ, 103) AS ShortDate, [Պատվ. համ], hh, [տ/մ], Նյութ, Լայնք, [Բարձ.], Քանակ, ՔՄ, Գին, [Տպ. արժեք], [Խոտան քմ], [Խոտան գին], [Խոտան արժեք], [Կոճգամ քան.], [Կոճգամ գին], [Կոճգամ արժեք], Լրացուցիչ, [Լր. քան.], [Լր. գին], [Լր. արժեք], Ծախս, [Ծախս քան.], [Ծախս գին], [Ծախս արժեք], Զեղչ, Մեկնաբանություն FROM TblOrders WHERE [Պատվ. համ] = @Cell2Value", con);
                cmd.Parameters.AddWithValue("@Cell2Value", txtNOid.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    int rowIndex = dgvNOorder.Rows.Add();
                    int rowIndex2 = dgvNOdefect.Rows.Add();
                    DataGridViewRow dgvRow = dgvNOorder.Rows[rowIndex];
                    DataGridViewRow dgvRow2 = dgvNOdefect.Rows[rowIndex2];
                    dgvRow.Cells[0].Value = row["ShortDate"];
                    dgvRow.Cells[1].Value = row["Պատվ. համ"];
                    dgvRow.Cells[2].Value = row["hh"];
                    dgvRow.Cells[3].Value = row["տ/մ"];
                    dgvRow.Cells[4].Value = row["Նյութ"];
                    dgvRow.Cells[5].Value = row["Լայնք"];
                    dgvRow.Cells[6].Value = row["Բարձ."];
                    dgvRow.Cells[7].Value = row["Քանակ"];
                    dgvRow.Cells[8].Value = row["ՔՄ"];
                    dgvRow.Cells[9].Value = row["Գին"];
                    dgvRow.Cells[10].Value = row["Տպ. արժեք"];
                    dgvRow.Cells[11].Value = row["Խոտան քմ"];
                    dgvRow.Cells[12].Value = row["Խոտան գին"];
                    dgvRow.Cells[13].Value = row["Խոտան արժեք"];
                    dgvRow.Cells[14].Value = row["Կոճգամ քան."];
                    dgvRow.Cells[15].Value = row["Կոճգամ գին"];
                    dgvRow.Cells[16].Value = row["Կոճգամ արժեք"];
                    dgvRow.Cells[17].Value = row["Լրացուցիչ"];
                    dgvRow.Cells[18].Value = row["Լր. քան."];
                    dgvRow.Cells[19].Value = row["Լր. գին"];
                    dgvRow.Cells[20].Value = row["Լր. արժեք"];
                    dgvRow.Cells[21].Value = row["Ծախս"];
                    dgvRow.Cells[22].Value = row["Ծախս քան."];
                    dgvRow.Cells[23].Value = row["Ծախս գին"];
                    dgvRow.Cells[24].Value = row["Ծախս արժեք"];
                    dgvRow.Cells[25].Value = row["Զեղչ"];
                    dgvRow.Cells[27].Value = row["Մեկնաբանություն"];

                    dgvRow2.Cells[0].Value = row["տ/մ"];
                    dgvRow2.Cells[1].Value = row["Նյութ"];
                    dgvRow2.Cells[2].Value = row["Լայնք"];
                    dgvRow2.Cells[3].Value = row["Բարձ."];
                    dgvRow2.Cells[4].Value = row["Քանակ"];
                    dgvRow2.Cells[5].Value = row["ՔՄ"];
                }

                con.Close();
                CountTotaldgvrowVal();
                CountTotalVal();
                UpdateTextBoxe1FromDataGridView();
                UpdateTextBoxe2FromDataGridView();
                UpdateTextBoxe3FromDataGridView();
                UpdateTextBoxe4FromDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvNOorder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditgridviewItem(sender, e);
            //btnNOAdd.Enabled = false;
        }
        int i;
        private void EditgridviewItem(object sender, DataGridViewCellEventArgs e)
        {
            ClearText();
            i = e.RowIndex;
            DataGridViewRow row = dgvNOorder.Rows[i];

            textBox1.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
            textBox2.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
            textBox3.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
            textBox4.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
            cmbNOprMat.Text = row.Cells[4].Value?.ToString() ?? string.Empty;
            cmbNOprMash.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
            txtNOprW.Text = row.Cells[5].Value?.ToString() ?? string.Empty;
            txtNOprL.Text = row.Cells[6].Value?.ToString() ?? string.Empty;
            txtNOprQnt.Text = row.Cells[7].Value?.ToString() ?? string.Empty;
            txtNOprPrice.Text = row.Cells[9].Value?.ToString() ?? string.Empty;
            txtNOdefSM.Text = row.Cells[11].Value?.ToString() ?? string.Empty;
            txtNOdefPrice.Text = row.Cells[12].Value?.ToString() ?? string.Empty;
            txtNOluvQnt.Text = row.Cells[14].Value?.ToString() ?? string.Empty;
            txtNOluvPrice.Text = row.Cells[15].Value?.ToString() ?? string.Empty;
            FillComboBoxMat();

            SqlCommand cmdStand = new SqlCommand("SELECT * FROM TblStand WHERE Վահանակ = @Value", con);
            SqlCommand cmdService = new SqlCommand("SELECT * FROM TblService WHERE Ծառայություն = @Value", con);

            cmdStand.Parameters.AddWithValue("@Value", row.Cells[17].Value ?? DBNull.Value);
            cmdService.Parameters.AddWithValue("@Value", row.Cells[17].Value ?? DBNull.Value);

            con.Open();

            bool isStand = cmdStand.ExecuteScalar() != null;
            bool isService = cmdService.ExecuteScalar() != null;

            con.Close();

            if (isStand)
            {
                cmbNOstand.Text = row.Cells[17].Value?.ToString() ?? string.Empty;
                txtNOstandQnt.Text = row.Cells[18].Value?.ToString() ?? string.Empty;
                txtNOstandPrice.Text = row.Cells[19].Value?.ToString() ?? string.Empty;
            }
            else if (isService)
            {
                cmbNOserv.Text = row.Cells[17].Value?.ToString() ?? string.Empty;
                txtNOservQnt.Text = row.Cells[18].Value?.ToString() ?? string.Empty;
                txtNOservPrice.Text = row.Cells[19].Value?.ToString() ?? string.Empty;
            }

            txtNOcost.Text = row.Cells[21].Value?.ToString() ?? string.Empty;
            txtNOcostQnt.Text = row.Cells[22].Value?.ToString() ?? string.Empty;
            txtNOcostPrice.Text = row.Cells[23].Value?.ToString() ?? string.Empty;
            txtNOsale.Text = row.Cells[25].Value?.ToString() ?? string.Empty;
            txtNOnote.Text = row.Cells[27].Value?.ToString() ?? string.Empty;
            if (cmbNOserv.Text != "")
            {
                txtKoxm.Text = "Ծ";
            }
            else if (cmbNOstand.Text != "")
            {
                txtKoxm.Text = "Վ";
            }

        }
        //Խմբագրել պատվերը
        private void btnNOEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNOid.Text) || string.IsNullOrEmpty(txtNOval.Text))
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
                return; // Exit if required fields are not filled
            }

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon))
            {
                SqlTransaction transaction = null;

                try
                {
                    con.Open();
                    transaction = con.BeginTransaction();

                    // Delete from TblOrders
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM TblOrders WHERE [Պատվ. համ] = @OrderId", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", txtNOidForEdit.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete from TblDebtsControl
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM TblDebtsControl WHERE hh = @DebtId", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@DebtId", txtDebtId.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete from TblStockFlow
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM TblStockFlow WHERE Կոդ = @StockId", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@StockId", txtNOidForEdit.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert new data into all tables
                    AddItemToGridview(con, transaction);
                    AddItemToDebtsControl(con, transaction);
                    AddItemToStock(con, transaction);

                    // Commit transaction
                    transaction.Commit();
                    MessageBox.Show("Տվյալները հաջողությամբ թարմացվեցին։");
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Roll back transaction in case of an error
                    if (transaction != null)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            MessageBox.Show("Rollback failed: " + rollbackEx.Message);
                        }
                    }

                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        //Հեռացնել պատվերը
        private void btnNODel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNOid.Text) || string.IsNullOrEmpty(cmbNOclient.Text))
            {
                MessageBox.Show("Ընտրե՛ք ցուցավահանակ ջնջելու համար:");
                return;
            }

            if (MessageBox.Show("Ցանկանո՞ւմ եք հեռացնել պատվերը:", "Հեռացնել պատվերը", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return; // Exit if user cancels
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    con.Open();
                    transaction = con.BeginTransaction();

                    // Delete from TblOrders
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM TblOrders WHERE [Պատվ. համ] = @OrderId", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", txtNOid.Text);
                        int rowsAffectedOrders = cmd.ExecuteNonQuery();
                    }

                    // Delete from TblDebtsControl
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM TblDebtsControl WHERE hh = @DebtId", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@DebtId", txtDebtId.Text);
                        int rowsAffectedDepts = cmd.ExecuteNonQuery();
                    }

                    // Delete from TblStockFlow
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM TblStockFlow WHERE Կոդ = @StockId", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@StockId", txtNOid.Text);
                        int rowsAffectedStock = cmd.ExecuteNonQuery();
                    }

                    // Commit transaction
                    transaction.Commit();

                    MessageBox.Show("Պատվերը հեռացվե՛ց");
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Rollback transaction on error
                    if (transaction != null)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            MessageBox.Show("Rollback failed: " + rollbackEx.Message);
                        }
                    }

                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        //Խոտան
        public class File
        {
            public decimal Width { get; set; }
            public decimal Length { get; set; }
            public int Quantity { get; set; }

            public File(decimal width, decimal length, int quantity)
            {
                Width = width;
                Length = length;
                Quantity = quantity;
            }
            public decimal Area()
            {
                return Width * Length;
            }
        }
    }
}
