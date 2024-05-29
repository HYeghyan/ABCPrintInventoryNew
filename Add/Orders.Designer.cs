namespace ABCPrintInventory.Add
{
    partial class Orders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabOrders = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvOrders = new Zuby.ADGV.AdvancedDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvOrderPrCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderPrCol16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabOrders.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabOrders
            // 
            this.tabOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOrders.Controls.Add(this.tabPage1);
            this.tabOrders.Controls.Add(this.tabPage2);
            this.tabOrders.Location = new System.Drawing.Point(0, 78);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.SelectedIndex = 0;
            this.tabOrders.Size = new System.Drawing.Size(1136, 584);
            this.tabOrders.TabIndex = 67;
            this.tabOrders.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabOrders_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SlateGray;
            this.tabPage1.Controls.Add(this.dgvOrders);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1128, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Պատվերներ";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvOrders.FilterAndSortEnabled = true;
            this.dgvOrders.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvOrders.Location = new System.Drawing.Point(0, 83);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvOrders.Size = new System.Drawing.Size(1128, 475);
            this.dgvOrders.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvOrders.TabIndex = 34;
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);
            this.dgvOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrders_CellFormatting);
            this.dgvOrders.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvOrders_CellPainting);
            this.dgvOrders.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvOrders_RowsAdded);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSlateGray;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1128, 558);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Սևագիր";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvOrderPrCol1,
            this.dgvOrderPrCol2,
            this.dgvOrderPrCol3,
            this.dgvOrderPrCol4,
            this.dgvOrderPrCol5,
            this.dgvOrderPrCol6,
            this.dgvOrderPrCol7,
            this.dgvOrderPrCol8,
            this.dgvOrderPrCol9,
            this.dgvOrderPrCol10,
            this.dgvOrderPrCol11,
            this.dgvOrderPrCol12,
            this.dgvOrderPrCol13,
            this.dgvOrderPrCol14,
            this.dgvOrderPrCol15,
            this.dgvOrderPrCol16});
            this.dataGridView1.Location = new System.Drawing.Point(0, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1128, 484);
            this.dataGridView1.TabIndex = 32;
            // 
            // dgvOrderPrCol1
            // 
            this.dgvOrderPrCol1.HeaderText = "hh";
            this.dgvOrderPrCol1.Name = "dgvOrderPrCol1";
            this.dgvOrderPrCol1.Width = 5;
            // 
            // dgvOrderPrCol2
            // 
            this.dgvOrderPrCol2.HeaderText = "ՏՄ";
            this.dgvOrderPrCol2.Name = "dgvOrderPrCol2";
            this.dgvOrderPrCol2.Width = 20;
            // 
            // dgvOrderPrCol3
            // 
            this.dgvOrderPrCol3.HeaderText = "Նյութ";
            this.dgvOrderPrCol3.Name = "dgvOrderPrCol3";
            this.dgvOrderPrCol3.Width = 200;
            // 
            // dgvOrderPrCol4
            // 
            this.dgvOrderPrCol4.HeaderText = "Լայնք";
            this.dgvOrderPrCol4.Name = "dgvOrderPrCol4";
            this.dgvOrderPrCol4.Width = 40;
            // 
            // dgvOrderPrCol5
            // 
            this.dgvOrderPrCol5.HeaderText = "Բարձ.";
            this.dgvOrderPrCol5.Name = "dgvOrderPrCol5";
            this.dgvOrderPrCol5.Width = 40;
            // 
            // dgvOrderPrCol6
            // 
            this.dgvOrderPrCol6.HeaderText = "Քան.";
            this.dgvOrderPrCol6.Name = "dgvOrderPrCol6";
            this.dgvOrderPrCol6.Width = 50;
            // 
            // dgvOrderPrCol7
            // 
            this.dgvOrderPrCol7.HeaderText = "ՔՄ";
            this.dgvOrderPrCol7.Name = "dgvOrderPrCol7";
            this.dgvOrderPrCol7.Width = 40;
            // 
            // dgvOrderPrCol8
            // 
            this.dgvOrderPrCol8.HeaderText = "Գին";
            this.dgvOrderPrCol8.Name = "dgvOrderPrCol8";
            this.dgvOrderPrCol8.Width = 50;
            // 
            // dgvOrderPrCol9
            // 
            this.dgvOrderPrCol9.HeaderText = "Արժեք";
            this.dgvOrderPrCol9.Name = "dgvOrderPrCol9";
            this.dgvOrderPrCol9.Width = 80;
            // 
            // dgvOrderPrCol10
            // 
            this.dgvOrderPrCol10.HeaderText = "Խոտ. ՔՄ";
            this.dgvOrderPrCol10.Name = "dgvOrderPrCol10";
            this.dgvOrderPrCol10.Width = 40;
            // 
            // dgvOrderPrCol11
            // 
            this.dgvOrderPrCol11.HeaderText = "Խոտ. Գին";
            this.dgvOrderPrCol11.Name = "dgvOrderPrCol11";
            this.dgvOrderPrCol11.Width = 50;
            // 
            // dgvOrderPrCol12
            // 
            this.dgvOrderPrCol12.HeaderText = "Խոտ. Արժեք";
            this.dgvOrderPrCol12.Name = "dgvOrderPrCol12";
            this.dgvOrderPrCol12.Width = 80;
            // 
            // dgvOrderPrCol13
            // 
            this.dgvOrderPrCol13.HeaderText = "Կոճ. քան";
            this.dgvOrderPrCol13.Name = "dgvOrderPrCol13";
            this.dgvOrderPrCol13.Width = 40;
            // 
            // dgvOrderPrCol14
            // 
            this.dgvOrderPrCol14.HeaderText = "Կոճ. Գին";
            this.dgvOrderPrCol14.Name = "dgvOrderPrCol14";
            this.dgvOrderPrCol14.Width = 50;
            // 
            // dgvOrderPrCol15
            // 
            this.dgvOrderPrCol15.HeaderText = "Կոճ. արժեք";
            this.dgvOrderPrCol15.Name = "dgvOrderPrCol15";
            this.dgvOrderPrCol15.Width = 80;
            // 
            // dgvOrderPrCol16
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvOrderPrCol16.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvOrderPrCol16.HeaderText = "Ընդհանուր";
            this.dgvOrderPrCol16.Name = "dgvOrderPrCol16";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Khaki;
            this.button1.Location = new System.Drawing.Point(22, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 60);
            this.button1.TabIndex = 34;
            this.button1.Text = "ՆՈՐ\r\nՊԱՏՎԵՐ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(416, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 31);
            this.label1.TabIndex = 33;
            this.label1.Text = "Չձևակերպված պատվերներ";
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1136, 663);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Orders";
            this.Text = "Orders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Orders_Load);
            this.tabOrders.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOrders;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderPrCol16;
        private System.Windows.Forms.Button button1;
        private Zuby.ADGV.AdvancedDataGridView dgvOrders;
        private System.Windows.Forms.Label label1;
    }
}