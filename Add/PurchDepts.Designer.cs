namespace ABCPrintInventory.Add
{
    partial class PurchDepts
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
            this.dgvPurchForDebts = new Zuby.ADGV.AdvancedDataGridView();
            this.TabDebts = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDebtsByClient = new Zuby.ADGV.AdvancedDataGridView();
            this.DebtsPay = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRef = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchForDebts)).BeginInit();
            this.TabDebts.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebtsByClient)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPurchForDebts
            // 
            this.dgvPurchForDebts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            this.dgvPurchForDebts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchForDebts.ColumnHeadersHeight = 30;
            this.dgvPurchForDebts.FilterAndSortEnabled = true;
            this.dgvPurchForDebts.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvPurchForDebts.Location = new System.Drawing.Point(1, 131);
            this.dgvPurchForDebts.Name = "dgvPurchForDebts";
            this.dgvPurchForDebts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPurchForDebts.Size = new System.Drawing.Size(379, 579);
            this.dgvPurchForDebts.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvPurchForDebts.TabIndex = 3;
            this.dgvPurchForDebts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchForDebts_CellDoubleClick);
            // 
            // TabDebts
            // 
            this.TabDebts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabDebts.Controls.Add(this.tabPage1);
            this.TabDebts.Location = new System.Drawing.Point(405, 131);
            this.TabDebts.Name = "TabDebts";
            this.TabDebts.SelectedIndex = 0;
            this.TabDebts.Size = new System.Drawing.Size(824, 583);
            this.TabDebts.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.RosyBrown;
            this.tabPage1.Controls.Add(this.dgvDebtsByClient);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Գնումների գծով և Այլ գործառնական վճարներ ";
            // 
            // dgvDebtsByClient
            // 
            this.dgvDebtsByClient.AllowUserToAddRows = false;
            this.dgvDebtsByClient.AllowUserToDeleteRows = false;
            this.dgvDebtsByClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDebtsByClient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDebtsByClient.ColumnHeadersHeight = 24;
            this.dgvDebtsByClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DebtsPay});
            this.dgvDebtsByClient.FilterAndSortEnabled = true;
            this.dgvDebtsByClient.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvDebtsByClient.Location = new System.Drawing.Point(0, 61);
            this.dgvDebtsByClient.Name = "dgvDebtsByClient";
            this.dgvDebtsByClient.ReadOnly = true;
            this.dgvDebtsByClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvDebtsByClient.RowHeadersVisible = false;
            this.dgvDebtsByClient.Size = new System.Drawing.Size(816, 496);
            this.dgvDebtsByClient.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvDebtsByClient.TabIndex = 1;
            this.dgvDebtsByClient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDebtsByClient_CellClick);
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
            // btnRef
            // 
            this.btnRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRef.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRef.BackgroundImage = global::ABCPrintInventory.Properties.Resources.ref1;
            this.btnRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRef.ForeColor = System.Drawing.Color.Khaki;
            this.btnRef.Location = new System.Drawing.Point(1130, 28);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(49, 45);
            this.btnRef.TabIndex = 70;
            this.btnRef.UseVisualStyleBackColor = false;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 49);
            this.button1.TabIndex = 71;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PurchDepts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 710);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRef);
            this.Controls.Add(this.dgvPurchForDebts);
            this.Controls.Add(this.TabDebts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PurchDepts";
            this.Text = "PurchDepts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PurchDepts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchForDebts)).EndInit();
            this.TabDebts.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebtsByClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvPurchForDebts;
        private System.Windows.Forms.TabControl TabDebts;
        private System.Windows.Forms.TabPage tabPage1;
        private Zuby.ADGV.AdvancedDataGridView dgvDebtsByClient;
        private System.Windows.Forms.DataGridViewButtonColumn DebtsPay;
        private System.Windows.Forms.Button btnRef;
        private System.Windows.Forms.Button button1;
    }
}