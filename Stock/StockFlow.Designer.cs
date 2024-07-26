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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBannerStock = new Zuby.ADGV.AdvancedDataGridView();
            this.txtLyuvName = new System.Windows.Forms.TextBox();
            this.txtLyuvIn = new System.Windows.Forms.TextBox();
            this.txtLyuvOut = new System.Windows.Forms.TextBox();
            this.txtLyuvRest = new System.Windows.Forms.TextBox();
            this.txtLyuvTotVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLyuvAvpr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRestVal = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvStandStock = new Zuby.ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBannerStock)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandStock)).BeginInit();
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
            this.dgvBannerStock.Location = new System.Drawing.Point(-3, 101);
            this.dgvBannerStock.Name = "dgvBannerStock";
            this.dgvBannerStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvBannerStock.Size = new System.Drawing.Size(1218, 502);
            this.dgvBannerStock.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvBannerStock.TabIndex = 1;
            // 
            // txtLyuvName
            // 
            this.txtLyuvName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLyuvName.Location = new System.Drawing.Point(26, 56);
            this.txtLyuvName.Name = "txtLyuvName";
            this.txtLyuvName.Size = new System.Drawing.Size(288, 22);
            this.txtLyuvName.TabIndex = 2;
            this.txtLyuvName.Text = "Կոճգամ";
            this.txtLyuvName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLyuvIn
            // 
            this.txtLyuvIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLyuvIn.Location = new System.Drawing.Point(346, 56);
            this.txtLyuvIn.Name = "txtLyuvIn";
            this.txtLyuvIn.Size = new System.Drawing.Size(120, 22);
            this.txtLyuvIn.TabIndex = 3;
            this.txtLyuvIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLyuvOut
            // 
            this.txtLyuvOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLyuvOut.Location = new System.Drawing.Point(484, 56);
            this.txtLyuvOut.Name = "txtLyuvOut";
            this.txtLyuvOut.Size = new System.Drawing.Size(126, 22);
            this.txtLyuvOut.TabIndex = 4;
            this.txtLyuvOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLyuvRest
            // 
            this.txtLyuvRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLyuvRest.Location = new System.Drawing.Point(628, 56);
            this.txtLyuvRest.Name = "txtLyuvRest";
            this.txtLyuvRest.Size = new System.Drawing.Size(126, 22);
            this.txtLyuvRest.TabIndex = 5;
            this.txtLyuvRest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLyuvTotVal
            // 
            this.txtLyuvTotVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLyuvTotVal.Location = new System.Drawing.Point(770, 56);
            this.txtLyuvTotVal.Name = "txtLyuvTotVal";
            this.txtLyuvTotVal.Size = new System.Drawing.Size(126, 22);
            this.txtLyuvTotVal.TabIndex = 6;
            this.txtLyuvTotVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(380, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Մուտք";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(528, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ելք";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(668, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Մնացորդ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(776, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Գնման ընդ․ արժեք";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(942, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Միավ․ գին";
            // 
            // txtLyuvAvpr
            // 
            this.txtLyuvAvpr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLyuvAvpr.Location = new System.Drawing.Point(918, 56);
            this.txtLyuvAvpr.Name = "txtLyuvAvpr";
            this.txtLyuvAvpr.Size = new System.Drawing.Size(126, 22);
            this.txtLyuvAvpr.TabIndex = 11;
            this.txtLyuvAvpr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(1078, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Մնացորդի արժեք";
            // 
            // txtRestVal
            // 
            this.txtRestVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRestVal.Location = new System.Drawing.Point(1064, 56);
            this.txtRestVal.Name = "txtRestVal";
            this.txtRestVal.Size = new System.Drawing.Size(126, 22);
            this.txtRestVal.TabIndex = 13;
            this.txtRestVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-1, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1219, 625);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvBannerStock);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtLyuvIn);
            this.tabPage1.Controls.Add(this.txtRestVal);
            this.tabPage1.Controls.Add(this.txtLyuvName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtLyuvOut);
            this.tabPage1.Controls.Add(this.txtLyuvAvpr);
            this.tabPage1.Controls.Add(this.txtLyuvRest);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtLyuvTotVal);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1211, 599);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Պաստառ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvStandStock);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1211, 599);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Վահանակ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1211, 599);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ներկ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvStandStock
            // 
            this.dgvStandStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStandStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStandStock.ColumnHeadersHeight = 24;
            this.dgvStandStock.FilterAndSortEnabled = true;
            this.dgvStandStock.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvStandStock.Location = new System.Drawing.Point(0, 30);
            this.dgvStandStock.Name = "dgvStandStock";
            this.dgvStandStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvStandStock.Size = new System.Drawing.Size(1208, 573);
            this.dgvStandStock.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvStandStock.TabIndex = 2;
            // 
            // StockFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 708);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StockFlow";
            this.Text = "StockFlow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockFlow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBannerStock)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvBannerStock;
        private System.Windows.Forms.TextBox txtLyuvName;
        private System.Windows.Forms.TextBox txtLyuvIn;
        private System.Windows.Forms.TextBox txtLyuvOut;
        private System.Windows.Forms.TextBox txtLyuvRest;
        private System.Windows.Forms.TextBox txtLyuvTotVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLyuvAvpr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRestVal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Zuby.ADGV.AdvancedDataGridView dgvStandStock;
    }
}