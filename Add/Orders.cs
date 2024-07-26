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
using static ABCPrintInventory.Add.NewOrder;

namespace ABCPrintInventory.Add
{
    public partial class Orders : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        DataSet ds;

        public Orders()
        {
            InitializeComponent();
            dgvOrders.CellFormatting += dgvOrders_CellFormatting;
            tabOrders.ItemSize = new Size(950, 30);
            tabOrders.SizeMode = TabSizeMode.Fixed;
            tabOrders.DrawMode = TabDrawMode.OwnerDrawFixed; // Set DrawMode to OwnerDrawFixed
            tabOrders.DrawItem += tabOrders_DrawItem;
        }
        private DataTable Source()
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                string query = "SELECT * FROM TblOrders"; // Adjust query as per your database schema
                cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            NewOrder newOrder = new NewOrder();
            newOrder.Show();
        }
        private void F2_UpdateEventHandler1(object sender, NewOrder.UpdateEventArgs args)
        {
            dgvOrders.DataSource = Source();
        }
        public void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblOrders order by Ամսաթիվ desc, [Պատվ. համ] desc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvOrders.DataSource = dt;

            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvOrders.ColumnHeadersHeight = 40;

            dgvOrders.Columns["Ամսաթիվ"].Width = 90;
            dgvOrders.Columns["Ամսաթիվ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Ամսաթիվ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Պատվ. համ"].Width = 100;
            dgvOrders.Columns["Պատվ. համ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Հաճախորդ"].Width = 250;
            dgvOrders.Columns["Միջնորդ"].Width = 150;
            dgvOrders.Columns["Վճ. եղանակ"].Width = 50;
            dgvOrders.Columns["Վճ. եղանակ"].HeaderText = "Վճ. եղ.";
            dgvOrders.Columns["Վճ. եղանակ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Վճ. եղանակ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Վճ. եղանակ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Արժեք"].DefaultCellStyle.Font = new Font(dgvOrders.Font.FontFamily, 8, FontStyle.Bold);
            dgvOrders.Columns["Արժեք"].DefaultCellStyle.ForeColor = Color.Maroon;
            dgvOrders.Columns["Արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["ԱԱՀ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["ԱԱՀ"].DefaultCellStyle.Font = new Font(dgvOrders.Font.FontFamily, 8, FontStyle.Bold);
            dgvOrders.Columns["ԱԱՀ"].DefaultCellStyle.ForeColor = Color.Maroon;
            dgvOrders.Columns["ԱԱՀ"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["ԱԱՀ"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Ընդհանուր"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Ընդհանուր"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Ընդհանուր"].DefaultCellStyle.Font = new Font(dgvOrders.Font.FontFamily, 8, FontStyle.Bold);
            dgvOrders.Columns["Ընդհանուր"].DefaultCellStyle.ForeColor = Color.Maroon;
            dgvOrders.Columns["Ընդհանուր"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Ընդհանուր"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["hh"].Visible = false;
            dgvOrders.Columns["տ/մ"].Width = 50;
            dgvOrders.Columns["տ/մ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["տ/մ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Նյութ"].Width = 250;
            dgvOrders.Columns["Նյութ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Նյութ"].DefaultCellStyle.Font = new Font(dgvOrders.Font.FontFamily, 7);
            dgvOrders.Columns["Լայնք"].Width = 40;
            dgvOrders.Columns["Լայնք"].HeaderText = "լ";
            dgvOrders.Columns["Լայնք"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Լայնք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Բարձ."].Width = 40;
            dgvOrders.Columns["Բարձ."].HeaderText = "բ";
            dgvOrders.Columns["Բարձ."].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Բարձ."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Քանակ"].Width = 40;
            dgvOrders.Columns["Քանակ"].HeaderText = "ք";
            dgvOrders.Columns["Քանակ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Քանակ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["ՔՄ"].Width = 50;
            dgvOrders.Columns["ՔՄ"].HeaderText = "քմ";
            dgvOrders.Columns["ՔՄ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["ՔՄ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["ՔՄ"].DefaultCellStyle.BackColor = SystemColors.Control;
            dgvOrders.Columns["Գին"].Width = 60;
            dgvOrders.Columns["Գին"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Տպ. արժեք"].Width = 80;
            dgvOrders.Columns["Տպ. արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Տպ. արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Տպ. արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Խոտան քմ"].Width = 50;
            dgvOrders.Columns["Խոտան քմ"].HeaderText = "Խոտ. քմ";
            dgvOrders.Columns["Խոտան քմ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Խոտան քմ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Խոտան գին"].Width = 60;
            dgvOrders.Columns["Խոտան գին"].HeaderText = "Խոտ. գին";
            dgvOrders.Columns["Խոտան գին"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Խոտան գին"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Խոտան արժեք"].Width = 70;
            dgvOrders.Columns["Խոտան արժեք"].HeaderText = "Խոտ. արժեք";
            dgvOrders.Columns["Խոտան արժեք"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Խոտան արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Խոտան արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Խոտան արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Կոճգամ քան."].Width = 50;
            dgvOrders.Columns["Կոճգամ քան."].HeaderText = "Կոճ քան";
            dgvOrders.Columns["Կոճգամ քան."].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Կոճգամ քան."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Կոճգամ գին"].Width = 60;
            dgvOrders.Columns["Կոճգամ գին"].HeaderText = "Կոճ գին";
            dgvOrders.Columns["Կոճգամ գին"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Կոճգամ գին"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Կոճգամ արժեք"].Width = 70;
            dgvOrders.Columns["Կոճգամ արժեք"].HeaderText = "Կոճ արժեք";
            dgvOrders.Columns["Կոճգամ արժեք"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Կոճգամ արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Կոճգամ արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Կոճգամ արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Լրացուցիչ"].Width = 150;
            dgvOrders.Columns["Լրացուցիչ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Լր. քան."].Width = 50;
            dgvOrders.Columns["Լր. քան."].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Լր. քան."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Լր. գին"].Width = 60;
            dgvOrders.Columns["Լր. գին"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Լր. գին"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Լր. արժեք"].Width = 70;
            dgvOrders.Columns["Լր. արժեք"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Լր. արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Լր. արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Լր. արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Ծախս"].Width = 150;
            dgvOrders.Columns["Ծախս"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Ծախս քան."].Width = 50;
            dgvOrders.Columns["Ծախս քան."].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Ծախս քան."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Ծախս գին"].Width = 60;
            dgvOrders.Columns["Ծախս գին"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Ծախս գին"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Ծախս արժեք"].Width = 70;
            dgvOrders.Columns["Ծախս արժեք"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrders.Columns["Ծախս արժեք"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Ծախս արժեք"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Ծախս արժեք"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Զեղչ"].Width = 100;
            dgvOrders.Columns["Զեղչ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.Columns["Զեղչ"].HeaderCell.Style.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Զեղչ"].DefaultCellStyle.BackColor = SystemColors.ScrollBar;
            dgvOrders.Columns["Մեկնաբանություն"].Width = 200;
        }
        public void Orders_Load(object sender, EventArgs e)
        {
            dgvOrders.DataSource = Source();
            FillGrid();
            dgvOrders.AutoGenerateColumns = false;           
        }
        private void dgvOrders_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        bool isTheSame(int column, int row)
        {
            if (row == 0)
                return false; // No previous row to compare with

            DataGridViewCell cell1 = dgvOrders[column, row];
            DataGridViewCell cell2 = dgvOrders[column, row - 1];

            if (cell1.Value == null || cell2.Value == null)
                return false; // Handle null values

            return cell1.Value.ToString() == cell2.Value.ToString() && column >= 2 && column <= 8 && dgvOrders[1, row].Value.ToString() == dgvOrders[1, row - 1].Value.ToString();
        }
        private void dgvOrders_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 1 || e.ColumnIndex < 2)
                return;

            if (isTheSame(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvOrders.AdvancedCellBorderStyle.Top;
            }

            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
        }
        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isTheSame(e.ColumnIndex, e.RowIndex))
            {
                e.Value = ""; // Clear the value of the merged cells
                e.FormattingApplied = true;
            }

            foreach (DataGridViewRow row in dgvOrders.Rows)
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

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NewOrder newOrder = new NewOrder();
            newOrder.Show();
            DataGridViewRow selectedRow = dgvOrders.Rows[e.RowIndex];
            newOrder.dtpNOText = selectedRow.Cells[0].Value?.ToString();
            newOrder.TxtNOidText = selectedRow.Cells[1].Value?.ToString();
            newOrder.cmbNOclientText = selectedRow.Cells[2].Value?.ToString();
            newOrder.txtNOagentText = selectedRow.Cells[3].Value?.ToString();
            newOrder.txtPayTypeText = selectedRow.Cells[4].Value?.ToString();
            newOrder.txtDraftText = selectedRow.Cells[33].Value?.ToString();
            newOrder.txtDebtidText = selectedRow.Cells[34].Value?.ToString();
            newOrder.GetRbtSelect();

            string condition = $"SomeColumn = '{newOrder.TxtNOidText}'"; // Example condition
            newOrder.PopulateDgvNOorderFromDatabase();
            newOrder.BtnNOAddEnabled = false;
        }
        //Թաբի դիզայնը
        private void tabOrders_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush bgBrush;
            Brush textBrush;
            TabPage tabPage = tabOrders.TabPages[e.Index];
            Rectangle tabBounds = tabOrders.GetTabRect(e.Index);
            Font tabFont;

            if (e.State == DrawItemState.Selected)
            {
                bgBrush = new SolidBrush(Color.Snow); // Set your desired background color here
                textBrush = new SolidBrush(Color.SlateGray); // Set your desired text color here
                tabFont = new Font(tabOrders.Font.FontFamily, 12, FontStyle.Bold);
            }
            else
            {
                bgBrush = new SolidBrush(Color.SlateGray); // Set your desired background color here
                textBrush = new SolidBrush(Color.White); // Set your desired text color here
                tabFont = tabOrders.Font; // Use the default font for unselected tabs
            }

            g.FillRectangle(bgBrush, tabBounds);

            // Center the text vertically and horizontally in the tab header
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(tabPage.Text, tabFont, textBrush, tabBounds, stringFormat);

            // Dispose of brushes and fonts
            bgBrush.Dispose();
            textBrush.Dispose();
            if (e.State == DrawItemState.Selected)
            {
                tabFont.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders_Load(sender, e);
        }
    }
}
