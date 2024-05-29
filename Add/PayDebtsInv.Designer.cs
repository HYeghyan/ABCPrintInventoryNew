﻿namespace ABCPrintInventory.Add
{
    partial class PayDebtsInv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayDebtsInv));
            this.dgvClientDebtsOrdersInv = new Zuby.ADGV.AdvancedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtHelp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNOSelectValuesInv = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpNO = new System.Windows.Forms.DateTimePicker();
            this.cmbNOclientInv = new System.Windows.Forms.ComboBox();
            this.txtNOBalanceInv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNODebtsInv = new System.Windows.Forms.TextBox();
            this.btnNOAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientDebtsOrdersInv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientDebtsOrdersInv
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientDebtsOrdersInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientDebtsOrdersInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientDebtsOrdersInv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvClientDebtsOrdersInv.FilterAndSortEnabled = true;
            this.dgvClientDebtsOrdersInv.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvClientDebtsOrdersInv.Location = new System.Drawing.Point(3, 183);
            this.dgvClientDebtsOrdersInv.Name = "dgvClientDebtsOrdersInv";
            this.dgvClientDebtsOrdersInv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvClientDebtsOrdersInv.RowHeadersVisible = false;
            this.dgvClientDebtsOrdersInv.Size = new System.Drawing.Size(839, 452);
            this.dgvClientDebtsOrdersInv.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvClientDebtsOrdersInv.TabIndex = 0;
            this.dgvClientDebtsOrdersInv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientDebtsOrders_CellContentClick);
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
            this.Column3.Width = 135;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Պատվ. արժեք";
            this.Column4.MinimumWidth = 22;
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column4.Width = 120;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.txtHelp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNOSelectValuesInv);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.dtpNO);
            this.panel1.Controls.Add(this.cmbNOclientInv);
            this.panel1.Controls.Add(this.txtNOBalanceInv);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNODebtsInv);
            this.panel1.Controls.Add(this.btnNOAdd);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 171);
            this.panel1.TabIndex = 54;
            // 
            // txtHelp
            // 
            this.txtHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtHelp.Location = new System.Drawing.Point(607, 12);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Size = new System.Drawing.Size(90, 25);
            this.txtHelp.TabIndex = 108;
            this.txtHelp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHelp.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(246, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Մնացորդ";
            // 
            // txtNOSelectValuesInv
            // 
            this.txtNOSelectValuesInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNOSelectValuesInv.Location = new System.Drawing.Point(393, 105);
            this.txtNOSelectValuesInv.Multiline = true;
            this.txtNOSelectValuesInv.Name = "txtNOSelectValuesInv";
            this.txtNOSelectValuesInv.Size = new System.Drawing.Size(90, 25);
            this.txtNOSelectValuesInv.TabIndex = 106;
            this.txtNOSelectValuesInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNOSelectValuesInv.TextChanged += new System.EventHandler(this.txtNOSelectValues_TextChanged);
            this.txtNOSelectValuesInv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNOSelectValues_KeyDown);
            this.txtNOSelectValuesInv.Leave += new System.EventHandler(this.txtNOSelectValues_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(246, 75);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 105;
            this.label19.Text = "Պարտք";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(234, 44);
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
            this.label17.Location = new System.Drawing.Point(246, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 103;
            this.label17.Text = "Ամսաթիվ";
            // 
            // dtpNO
            // 
            this.dtpNO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNO.Location = new System.Drawing.Point(393, 12);
            this.dtpNO.Name = "dtpNO";
            this.dtpNO.Size = new System.Drawing.Size(90, 20);
            this.dtpNO.TabIndex = 100;
            // 
            // cmbNOclientInv
            // 
            this.cmbNOclientInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbNOclientInv.FormattingEnabled = true;
            this.cmbNOclientInv.Location = new System.Drawing.Point(324, 39);
            this.cmbNOclientInv.Name = "cmbNOclientInv";
            this.cmbNOclientInv.Size = new System.Drawing.Size(225, 24);
            this.cmbNOclientInv.TabIndex = 95;
            // 
            // txtNOBalanceInv
            // 
            this.txtNOBalanceInv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNOBalanceInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNOBalanceInv.Location = new System.Drawing.Point(393, 136);
            this.txtNOBalanceInv.Multiline = true;
            this.txtNOBalanceInv.Name = "txtNOBalanceInv";
            this.txtNOBalanceInv.Size = new System.Drawing.Size(90, 25);
            this.txtNOBalanceInv.TabIndex = 53;
            this.txtNOBalanceInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(255, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Գումար";
            // 
            // txtNODebtsInv
            // 
            this.txtNODebtsInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNODebtsInv.ForeColor = System.Drawing.Color.Firebrick;
            this.txtNODebtsInv.Location = new System.Drawing.Point(393, 72);
            this.txtNODebtsInv.Multiline = true;
            this.txtNODebtsInv.Name = "txtNODebtsInv";
            this.txtNODebtsInv.Size = new System.Drawing.Size(90, 25);
            this.txtNODebtsInv.TabIndex = 4;
            this.txtNODebtsInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNOAdd
            // 
            this.btnNOAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNOAdd.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnNOAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNOAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNOAdd.FlatAppearance.BorderSize = 0;
            this.btnNOAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNOAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNOAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNOAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnNOAdd.Image")));
            this.btnNOAdd.Location = new System.Drawing.Point(708, 121);
            this.btnNOAdd.Name = "btnNOAdd";
            this.btnNOAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNOAdd.Size = new System.Drawing.Size(125, 40);
            this.btnNOAdd.TabIndex = 5;
            this.btnNOAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNOAdd.UseVisualStyleBackColor = false;
            this.btnNOAdd.Click += new System.EventHandler(this.btnNOAdd_Click);
            // 
            // PayDebtsInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvClientDebtsOrdersInv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PayDebtsInv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PayDebtsByClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientDebtsOrdersInv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvClientDebtsOrdersInv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpNO;
        private System.Windows.Forms.ComboBox cmbNOclientInv;
        private System.Windows.Forms.TextBox txtNOBalanceInv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNODebtsInv;
        private System.Windows.Forms.Button btnNOAdd;
        private System.Windows.Forms.TextBox txtNOSelectValuesInv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHelp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}