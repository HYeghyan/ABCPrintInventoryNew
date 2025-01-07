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
    public partial class OrdersFilter : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        DataSet ds;
        public OrdersFilter()
        {
            InitializeComponent();
        }
       
        private void OrdersFilter_Load(object sender, EventArgs e)
        {            
            FillAndFormatGrid();
        }
        
        public void FillAndFormatGrid()
        {
            // 1. Load the data
            con.Open();
            da = new SqlDataAdapter("select * from TblOrders order by Ամսաթիվ desc, [Պատվ. համ] desc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // 2. Apply Grouping and Summing for columns 9-11
            DataTable groupedTable = GroupAndSum(dt);

            // 3. Set the processed table as the DataSource for dgvSevagir
            dgvOrdersMain.DataSource = groupedTable;


            // 4. Enable visual styles for headers and configure layout
            dgvOrdersMain.EnableHeadersVisualStyles = false;
            dgvOrdersMain.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvOrdersMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvOrdersMain.ColumnHeadersHeight = 40;

            dgvOrdersMain.Columns["hh"].Visible = false;
            dgvOrdersMain.Columns["Լայնք"].Visible = false;
            dgvOrdersMain.Columns["Բարձ."].Visible = false;
            dgvOrdersMain.Columns["Խոտան գին"].Visible = false;
            dgvOrdersMain.Columns["Կոճգամ գին"].Visible = false;
            dgvOrdersMain.Columns["Լր. քան."].Visible = false;
            dgvOrdersMain.Columns["Լր. գին"].Visible = false;
            dgvOrdersMain.Columns["Ծախս քան."].Visible = false;
            dgvOrdersMain.Columns["Ծախս գին"].Visible = false;
            dgvOrdersMain.Columns["Սևագիր"].Visible = false;
            dgvOrdersMain.Columns["ՊԿկոդ"].Visible = false;

            //dgvOrdersMain.CellFormatting += dgvOrdersMain_CellFormatting;

            dgvOrdersMain.Columns["Ամսաթիվ"].Width = 90;
            dgvOrdersMain.Columns["Ամսաթիվ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Ամսաթիվ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["Պատվ. համ"].Width = 100;
            dgvOrdersMain.Columns["Պատվ. համ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Հաճախորդ"].Width = 250;
            dgvOrdersMain.Columns["Միջնորդ"].Width = 150;
            dgvOrdersMain.Columns["Վճ. եղանակ"].Width = 50;
            dgvOrdersMain.Columns["Վճ. եղանակ"].HeaderText = "Վճ. եղ.";
            dgvOrdersMain.Columns["Վճ. եղանակ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["Վճ. եղանակ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Վճ. եղանակ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Արժեք"].DefaultCellStyle.Font = new Font(dgvOrdersMain.Font.FontFamily, 8, FontStyle.Bold);
            dgvOrdersMain.Columns["Արժեք"].DefaultCellStyle.ForeColor = Color.Maroon;
            dgvOrdersMain.Columns["Արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["ԱԱՀ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["ԱԱՀ"].DefaultCellStyle.Font = new Font(dgvOrdersMain.Font.FontFamily, 8, FontStyle.Bold);
            dgvOrdersMain.Columns["ԱԱՀ"].DefaultCellStyle.ForeColor = Color.Maroon;
            dgvOrdersMain.Columns["ԱԱՀ"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["ԱԱՀ"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Ընդհանուր"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["Ընդհանուր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Ընդհանուր"].DefaultCellStyle.Font = new Font(dgvOrdersMain.Font.FontFamily, 8, FontStyle.Bold);
            dgvOrdersMain.Columns["Ընդհանուր"].DefaultCellStyle.ForeColor = Color.Maroon;
            dgvOrdersMain.Columns["Ընդհանուր"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Ընդհանուր"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["տ/մ"].Width = 50;
            dgvOrdersMain.Columns["տ/մ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["տ/մ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Նյութ"].Width = 250;
            dgvOrdersMain.Columns["Նյութ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Նյութ"].DefaultCellStyle.Font = new Font(dgvOrdersMain.Font.FontFamily, 7);
            dgvOrdersMain.Columns["Քանակ"].Width = 40;
            dgvOrdersMain.Columns["Քանակ"].HeaderText = "ք";
            dgvOrdersMain.Columns["Քանակ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["Քանակ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Քանակ"].Visible = false;
            dgvOrdersMain.Columns["ՔՄ"].Width = 50;
            dgvOrdersMain.Columns["ՔՄ"].HeaderText = "քմ";
            dgvOrdersMain.Columns["ՔՄ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["ՔՄ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["ՔՄ"].DefaultCellStyle.BackColor = SystemColors.Control;
            dgvOrdersMain.Columns["Գին"].Width = 60;
            dgvOrdersMain.Columns["Գին"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Տպ. արժեք"].Width = 80;
            dgvOrdersMain.Columns["Տպ. արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Տպ. արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Տպ. արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Խոտան քմ"].Width = 50;
            dgvOrdersMain.Columns["Խոտան քմ"].HeaderText = "Խոտ. քմ";
            dgvOrdersMain.Columns["Խոտան քմ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["Խոտան քմ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Խոտան արժեք"].Width = 70;
            dgvOrdersMain.Columns["Խոտան արժեք"].HeaderText = "Խոտ. արժեք";
            dgvOrdersMain.Columns["Խոտան արժեք"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["Խոտան արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Խոտան արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Խոտան արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Կոճգամ քան."].Width = 50;
            dgvOrdersMain.Columns["Կոճգամ քան."].HeaderText = "Կոճ քան";
            dgvOrdersMain.Columns["Կոճգամ քան."].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["Կոճգամ քան."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Կոճգամ արժեք"].Width = 70;
            dgvOrdersMain.Columns["Կոճգամ արժեք"].HeaderText = "Կոճ արժեք";
            dgvOrdersMain.Columns["Կոճգամ արժեք"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["Կոճգամ արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Կոճգամ արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Կոճգամ արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Լրացուցիչ"].Width = 150;
            dgvOrdersMain.Columns["Լրացուցիչ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Լր. արժեք"].Width = 70;
            dgvOrdersMain.Columns["Լր. արժեք"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["Լր. արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Լր. արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Լր. արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Ծախս"].Width = 150;
            dgvOrdersMain.Columns["Ծախս"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Ծախս արժեք"].Width = 70;
            dgvOrdersMain.Columns["Ծախս արժեք"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdersMain.Columns["Ծախս արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Ծախս արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Ծախս արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Զեղչ"].Width = 100;
            dgvOrdersMain.Columns["Զեղչ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersMain.Columns["Զեղչ"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Զեղչ"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrdersMain.Columns["Մեկնաբանություն"].Width = 200;
        }

        private DataTable GroupAndSum(DataTable originalTable)
        {
            DataTable groupedTable = originalTable.Clone();

            // Group by specific columns and calculate the sums
            var groupedData = originalTable.AsEnumerable()
                .GroupBy(row => new
                {
                    Col1 = row["Պատվ. համ"].ToString(),
                    Col2 = row["Հաճախորդ"].ToString(),
                    Col3 = row["Միջնորդ"].ToString(),
                    Col4 = row["Վճ․ եղանակ"].ToString(),
                    Col5 = row["Արժեք"].ToString(),
                    Col6 = row["ԱԱՀ"].ToString(),
                    Col7 = row["Ընդհանուր"].ToString(),
                    Col9 = row["տ/մ"].ToString(),
                    Col10 = row["Նյութ"].ToString()
                })
                .Select(g => new
                {
                    Column0 = g.First()["Ամսաթիվ"],
                    Column1 = g.Key.Col1,
                    Column2 = g.Key.Col2,
                    Column3 = g.Key.Col3,
                    Column4 = g.Key.Col4,
                    Column5 = g.Key.Col5,
                    Column6 = g.Key.Col6,
                    Column7 = g.Key.Col7,
                    Column8 = g.First()["hh"], // Adjust if necessary
                    Column9 = g.Key.Col9,
                    Column10 = g.Key.Col10,

                    SumColumn13 = g.Sum(r =>
                    {
                        var value = r["Քանակ"];
                        return value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()) ? 0 : Convert.ToDecimal(value);
                    }),
                    SumColumn14 = g.Sum(r =>
                    {
                        var value = r["ՔՄ"];
                        return value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()) ? 0 : Convert.ToDecimal(value);
                    }),

                    Column15 = g.First()["Գին"],
                    Column16 = g.First()["Տպ. արժեք"],
                    Column17 = g.First()["Խոտան քմ"],
                    Column18 = g.First()["Խոտան արժեք"],
                    Column19 = g.First()["Կոճգամ քան."],
                    Column20 = g.First()["Կոճգամ արժեք"],
                    Column21 = g.First()["Լրացուցիչ"],
                    Column22 = g.First()["Լր. արժեք"],
                    Column23 = g.First()["Ծախս"],
                    Column24 = g.First()["Ծախս արժեք"],
                    Column25 = g.First()["Զեղչ"],
                    Column26 = g.First()["Մեկնաբանություն"],
                    Column27 = g.First()["Սևագիր"]
                });

            // Populate groupedTable with grouped data
            foreach (var group in groupedData)
            {
                DataRow newRow = groupedTable.NewRow();
                newRow["Ամսաթիվ"] = group.Column0;
                newRow["Պատվ. համ"] = group.Column1;
                newRow["Հաճախորդ"] = group.Column2;
                newRow["Միջնորդ"] = group.Column3;
                newRow["Վճ․ եղանակ"] = group.Column4;
                newRow["Արժեք"] = group.Column5;
                newRow["ԱԱՀ"] = group.Column6;
                newRow["Ընդհանուր"] = group.Column7;
                newRow["hh"] = group.Column8;
                newRow["տ/մ"] = group.Column9;
                newRow["Նյութ"] = group.Column10;
                newRow["Քանակ"] = group.SumColumn13;
                newRow["ՔՄ"] = group.SumColumn14;
                newRow["Գին"] = group.Column15;
                newRow["Տպ. արժեք"] = group.Column16;
                newRow["Խոտան քմ"] = group.Column17;
                newRow["Խոտան արժեք"] = group.Column18;
                newRow["Կոճգամ քան."] = group.Column19;
                newRow["Կոճգամ արժեք"] = group.Column20;
                newRow["Լրացուցիչ"] = group.Column21;
                newRow["Լր. արժեք"] = group.Column22;
                newRow["Ծախս"] = group.Column23;
                newRow["Ծախս արժեք"] = group.Column24;
                newRow["Զեղչ"] = group.Column25;
                newRow["Մեկնաբանություն"] = group.Column26;
                newRow["Սևագիր"] = group.Column27;

                groupedTable.Rows.Add(newRow); // Ensure rows are added
            }

            return groupedTable;
        }

        bool isTheSameSev(int column, int row)
        {
            if (row == 0)
                return false; // No previous row to compare with

            // Compare cells in the same column and check if they are equal
            DataGridViewCell cell1 = dgvOrdersMain[column, row];
            DataGridViewCell cell2 = dgvOrdersMain[column, row - 1];

            if (cell1.Value == null || cell2.Value == null)
                return false; // Handle null values

            // Check if the current column index is within the desired range
            // Also ensure that the second column (index 1) is the same in both rows for merging
            return cell1.Value.ToString() == cell2.Value.ToString() &&
                   column >= 1 && column <= 7 &&
                   dgvOrdersMain[1, row].Value.ToString() == dgvOrdersMain[1, row - 1].Value.ToString();
        }

        private void dgvOrdersMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 1 && e.ColumnIndex <= 7)
            {
                if (isTheSameSev(e.ColumnIndex, e.RowIndex))
                {
                    // Hide the value of the current cell to simulate merging
                    e.Value = ""; // Clear the cell value to simulate merging
                    e.FormattingApplied = true;
                }
            }
            foreach (DataGridViewRow row in dgvOrdersMain.Rows)
            {
                if (!row.IsNewRow) // Skip the new row if present
                {
                    // Check if the cell value in the "ԴՀ" column is "yes"
                    if (row.Cells["Սևագիր"].Value?.ToString() == "Ս")
                    {
                        // Set the cell value to "yes"
                        row.Cells["Սևագիր"].Value = "Ս";

                        // Set the row's background color to yellow
                        row.DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
    }
}
