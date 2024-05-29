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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ABCPrintInventory.Add
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        private void CalculateOptim()
        {
            //try
            //{
            //    // Step 1: Retrieve material width from textBox1
            //    decimal materialWidth = decimal.Parse(textBox1.Text);

            //    // Step 2: Retrieve file sizes from dataGridView
            //    List<File> files = new List<File>();
            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        decimal width = 0;
            //        decimal length = 0;
            //        int quantity = 0;

            //        if (row.Cells[2].Value != null)
            //        {
            //            decimal.TryParse(row.Cells[2].Value.ToString(), out width);
            //        }
            //        if (row.Cells[3].Value != null)
            //        {
            //            decimal.TryParse(row.Cells[3].Value.ToString(), out length);
            //        }
            //        if (row.Cells[4].Value != null)
            //        {
            //            int.TryParse(row.Cells[4].Value.ToString(), out quantity);
            //        }

            //        files.Add(new File(width, length, quantity));
            //    }

            //    // Step 3: Generate all possible orientations of files
            //    List<File> allFiles = new List<File>();
            //    foreach (var file in files)
            //    {
            //        allFiles.Add(file);
            //        allFiles.Add(new File(file.Length, file.Width, file.Quantity)); // Rotate file
            //    }

            //    // Step 4: Optimize placement of files
            //    decimal totalWidth = 0;
            //    decimal totalLength = 0;
            //    foreach (var file in allFiles)
            //    {
            //        totalWidth += file.Width * file.Quantity;
            //        totalLength = Math.Max(totalLength, file.Length);
            //    }

            //    // Step 5: Calculate minimum length of the material needed
            //    decimal minLengthNeeded = 0;
            //    decimal currentWidth = 0;
            //    decimal currentLength = 0;
            //    foreach (var file in allFiles.OrderByDescending(f => f.Length))
            //    {
            //        if (currentWidth + (file.Width * file.Quantity) <= materialWidth)
            //        {
            //            currentWidth += file.Width * file.Quantity;
            //        }
            //        else
            //        {
            //            minLengthNeeded += currentLength;
            //            currentWidth = file.Width * file.Quantity;
            //            currentLength = file.Length;
            //        }
            //    }
            //    minLengthNeeded += currentLength;

            //    // Step 6: Display the result in textBox2
            //    textBox2.Text = minLengthNeeded.ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    CalculateOptim();
            //}
        }
    }
    //public class File
    //{
    //    public decimal Width { get; set; }
    //    public decimal Length { get; set; }
    //    public int Quantity { get; set; }

    //    public File(decimal width, decimal length, int quantity)
    //    {
    //        Width = width;
    //        Length = length;
    //        Quantity = quantity;
    //    }
    //}
}
