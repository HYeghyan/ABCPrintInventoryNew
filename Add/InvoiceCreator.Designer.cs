namespace ABCPrintInventory.Add
{
    partial class InvoiceCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceCreator));
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpICdate = new System.Windows.Forms.DateTimePicker();
            this.cmbICclient = new System.Windows.Forms.ComboBox();
            this.btnICAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvClientDebtsTA = new Zuby.ADGV.AdvancedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ԴՀ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtICval = new System.Windows.Forms.TextBox();
            this.txtICaah = new System.Windows.Forms.TextBox();
            this.txtICtot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientDebtsTA)).BeginInit();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(186, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 104;
            this.label18.Text = "Հաճախորդ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(198, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 103;
            this.label17.Text = "Ամսաթիվ";
            // 
            // dtpICdate
            // 
            this.dtpICdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpICdate.Location = new System.Drawing.Point(275, 12);
            this.dtpICdate.Name = "dtpICdate";
            this.dtpICdate.Size = new System.Drawing.Size(90, 20);
            this.dtpICdate.TabIndex = 100;
            // 
            // cmbICclient
            // 
            this.cmbICclient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbICclient.FormattingEnabled = true;
            this.cmbICclient.Location = new System.Drawing.Point(275, 53);
            this.cmbICclient.Name = "cmbICclient";
            this.cmbICclient.Size = new System.Drawing.Size(294, 24);
            this.cmbICclient.TabIndex = 95;
            // 
            // btnICAdd
            // 
            this.btnICAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnICAdd.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnICAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnICAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnICAdd.FlatAppearance.BorderSize = 0;
            this.btnICAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnICAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnICAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnICAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnICAdd.Image")));
            this.btnICAdd.Location = new System.Drawing.Point(712, 85);
            this.btnICAdd.Name = "btnICAdd";
            this.btnICAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnICAdd.Size = new System.Drawing.Size(125, 40);
            this.btnICAdd.TabIndex = 5;
            this.btnICAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnICAdd.UseVisualStyleBackColor = false;
            this.btnICAdd.Click += new System.EventHandler(this.btnICAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtICtot);
            this.panel1.Controls.Add(this.txtICaah);
            this.panel1.Controls.Add(this.txtICval);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.dtpICdate);
            this.panel1.Controls.Add(this.cmbICclient);
            this.panel1.Controls.Add(this.btnICAdd);
            this.panel1.Location = new System.Drawing.Point(-5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 147);
            this.panel1.TabIndex = 56;
            // 
            // dgvClientDebtsTA
            // 
            this.dgvClientDebtsTA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientDebtsTA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.ԴՀ,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvClientDebtsTA.FilterAndSortEnabled = true;
            this.dgvClientDebtsTA.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvClientDebtsTA.Location = new System.Drawing.Point(4, 156);
            this.dgvClientDebtsTA.Name = "dgvClientDebtsTA";
            this.dgvClientDebtsTA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvClientDebtsTA.RowHeadersVisible = false;
            this.dgvClientDebtsTA.Size = new System.Drawing.Size(839, 331);
            this.dgvClientDebtsTA.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvClientDebtsTA.TabIndex = 55;
            this.dgvClientDebtsTA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientDebtsOrders_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Հաճախորդ";
            this.Column2.MinimumWidth = 22;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column2.Width = 245;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Ամսաթիվ";
            this.Column5.MinimumWidth = 22;
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Պատվ. համար";
            this.Column3.MinimumWidth = 22;
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column3.Width = 150;
            // 
            // ԴՀ
            // 
            this.ԴՀ.HeaderText = "ԴՀ";
            this.ԴՀ.MinimumWidth = 22;
            this.ԴՀ.Name = "ԴՀ";
            this.ԴՀ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ԴՀ.Width = 30;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Պատվ. արժեք";
            this.Column4.MinimumWidth = 22;
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Վճարել";
            this.Column6.MinimumWidth = 22;
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Մնացորդ";
            this.Column7.MinimumWidth = 22;
            this.Column7.Name = "Column7";
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Բաշխել";
            this.Column8.MinimumWidth = 22;
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // txtICval
            // 
            this.txtICval.BackColor = System.Drawing.Color.White;
            this.txtICval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtICval.Location = new System.Drawing.Point(275, 95);
            this.txtICval.Multiline = true;
            this.txtICval.Name = "txtICval";
            this.txtICval.Size = new System.Drawing.Size(90, 25);
            this.txtICval.TabIndex = 105;
            this.txtICval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtICaah
            // 
            this.txtICaah.BackColor = System.Drawing.Color.White;
            this.txtICaah.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtICaah.Location = new System.Drawing.Point(387, 95);
            this.txtICaah.Multiline = true;
            this.txtICaah.Name = "txtICaah";
            this.txtICaah.Size = new System.Drawing.Size(69, 25);
            this.txtICaah.TabIndex = 106;
            this.txtICaah.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtICtot
            // 
            this.txtICtot.BackColor = System.Drawing.Color.White;
            this.txtICtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtICtot.Location = new System.Drawing.Point(478, 95);
            this.txtICtot.Multiline = true;
            this.txtICtot.Name = "txtICtot";
            this.txtICtot.Size = new System.Drawing.Size(90, 25);
            this.txtICtot.TabIndex = 107;
            this.txtICtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(142, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "Ընդհանուր արժեք";
            // 
            // InvoiceCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 486);
            this.Controls.Add(this.dgvClientDebtsTA);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InvoiceCreator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientDebtsTA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpICdate;
        private System.Windows.Forms.ComboBox cmbICclient;
        private System.Windows.Forms.Button btnICAdd;
        private System.Windows.Forms.Panel panel1;
        private Zuby.ADGV.AdvancedDataGridView dgvClientDebtsTA;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ԴՀ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.TextBox txtICaah;
        private System.Windows.Forms.TextBox txtICval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtICtot;
    }
}