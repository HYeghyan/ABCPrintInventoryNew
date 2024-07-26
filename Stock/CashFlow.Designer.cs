namespace ABCPrintInventory.Stock
{
    partial class CashFlow
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
            this.dgvCashFlow = new Zuby.ADGV.AdvancedDataGridView();
            this.TabDebts = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvWallRest = new Zuby.ADGV.AdvancedDataGridView();
            this.DebtsPay = new System.Windows.Forms.DataGridViewButtonColumn();
            this.WalTr = new System.Windows.Forms.Button();
            this.btnRef = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashFlow)).BeginInit();
            this.TabDebts.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWallRest)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCashFlow
            // 
            this.dgvCashFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            this.dgvCashFlow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashFlow.ColumnHeadersHeight = 30;
            this.dgvCashFlow.FilterAndSortEnabled = true;
            this.dgvCashFlow.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvCashFlow.Location = new System.Drawing.Point(0, 130);
            this.dgvCashFlow.Name = "dgvCashFlow";
            this.dgvCashFlow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvCashFlow.Size = new System.Drawing.Size(379, 579);
            this.dgvCashFlow.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvCashFlow.TabIndex = 5;
            // 
            // TabDebts
            // 
            this.TabDebts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabDebts.Controls.Add(this.tabPage1);
            this.TabDebts.Location = new System.Drawing.Point(404, 130);
            this.TabDebts.Name = "TabDebts";
            this.TabDebts.SelectedIndex = 0;
            this.TabDebts.Size = new System.Drawing.Size(824, 583);
            this.TabDebts.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.RosyBrown;
            this.tabPage1.Controls.Add(this.dgvWallRest);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Դրամարկղի մնացորդ";
            // 
            // dgvWallRest
            // 
            this.dgvWallRest.AllowUserToAddRows = false;
            this.dgvWallRest.AllowUserToDeleteRows = false;
            this.dgvWallRest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWallRest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWallRest.ColumnHeadersHeight = 24;
            this.dgvWallRest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DebtsPay});
            this.dgvWallRest.FilterAndSortEnabled = true;
            this.dgvWallRest.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvWallRest.Location = new System.Drawing.Point(0, 61);
            this.dgvWallRest.Name = "dgvWallRest";
            this.dgvWallRest.ReadOnly = true;
            this.dgvWallRest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvWallRest.RowHeadersVisible = false;
            this.dgvWallRest.Size = new System.Drawing.Size(816, 496);
            this.dgvWallRest.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvWallRest.TabIndex = 1;
            // 
            // DebtsPay
            // 
            this.DebtsPay.HeaderText = "";
            this.DebtsPay.MinimumWidth = 22;
            this.DebtsPay.Name = "DebtsPay";
            this.DebtsPay.ReadOnly = true;
            this.DebtsPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.DebtsPay.Text = "Վճարել";
            this.DebtsPay.UseColumnTextForButtonValue = true;
            this.DebtsPay.Width = 70;
            // 
            // WalTr
            // 
            this.WalTr.BackColor = System.Drawing.Color.LightSlateGray;
            this.WalTr.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.WalTr.Image = global::ABCPrintInventory.Properties.Resources.WalTr;
            this.WalTr.Location = new System.Drawing.Point(47, 31);
            this.WalTr.Name = "WalTr";
            this.WalTr.Size = new System.Drawing.Size(196, 64);
            this.WalTr.TabIndex = 71;
            this.WalTr.Text = "Փոխանցում դրամարկղերի միջև";
            this.WalTr.UseVisualStyleBackColor = false;
            this.WalTr.Click += new System.EventHandler(this.WalTr_Click);
            // 
            // btnRef
            // 
            this.btnRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRef.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRef.BackgroundImage = global::ABCPrintInventory.Properties.Resources.ref1;
            this.btnRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRef.ForeColor = System.Drawing.Color.Khaki;
            this.btnRef.Location = new System.Drawing.Point(1164, 41);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(49, 45);
            this.btnRef.TabIndex = 70;
            this.btnRef.UseVisualStyleBackColor = false;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(465, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 34);
            this.button1.TabIndex = 72;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CashFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1225, 710);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WalTr);
            this.Controls.Add(this.dgvCashFlow);
            this.Controls.Add(this.TabDebts);
            this.Controls.Add(this.btnRef);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashFlow";
            this.Text = "CashFlow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CashFlow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashFlow)).EndInit();
            this.TabDebts.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWallRest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvCashFlow;
        private System.Windows.Forms.TabControl TabDebts;
        private System.Windows.Forms.TabPage tabPage1;
        private Zuby.ADGV.AdvancedDataGridView dgvWallRest;
        private System.Windows.Forms.DataGridViewButtonColumn DebtsPay;
        private System.Windows.Forms.Button btnRef;
        private System.Windows.Forms.Button WalTr;
        private System.Windows.Forms.Button button1;
    }
}