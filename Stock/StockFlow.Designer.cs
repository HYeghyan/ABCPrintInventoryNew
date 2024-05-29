namespace ABCPrintInventory.Stock
{
    partial class StockFlow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBannerStock = new Zuby.ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBannerStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBannerStock
            // 
            this.dgvBannerStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBannerStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBannerStock.ColumnHeadersHeight = 24;
            this.dgvBannerStock.FilterAndSortEnabled = true;
            this.dgvBannerStock.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvBannerStock.Location = new System.Drawing.Point(-1, 74);
            this.dgvBannerStock.Name = "dgvBannerStock";
            this.dgvBannerStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvBannerStock.Size = new System.Drawing.Size(1219, 633);
            this.dgvBannerStock.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvBannerStock.TabIndex = 1;
            // 
            // StockFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 708);
            this.Controls.Add(this.dgvBannerStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StockFlow";
            this.Text = "StockFlow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockFlow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBannerStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvBannerStock;
    }
}