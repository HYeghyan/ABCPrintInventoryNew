namespace ABCPrintInventory.Add
{
    partial class PayDebtsCash
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayDebtsCash));
            this.dgvClientDebtsOrders = new Zuby.ADGV.AdvancedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPDInvCom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPaySys = new System.Windows.Forms.ComboBox();
            this.txtPDInvAc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWallet = new System.Windows.Forms.ComboBox();
            this.txtHelp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNOSelectValues = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpNO = new System.Windows.Forms.DateTimePicker();
            this.cmbNOclient = new System.Windows.Forms.ComboBox();
            this.txtNOBalance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNODebts = new System.Windows.Forms.TextBox();
            this.btnNOAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientDebtsOrders)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientDebtsOrders
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientDebtsOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientDebtsOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientDebtsOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.hh,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvClientDebtsOrders.FilterAndSortEnabled = true;
            this.dgvClientDebtsOrders.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvClientDebtsOrders.Location = new System.Drawing.Point(3, 321);
            this.dgvClientDebtsOrders.Name = "dgvClientDebtsOrders";
            this.dgvClientDebtsOrders.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvClientDebtsOrders.RowHeadersVisible = false;
            this.dgvClientDebtsOrders.Size = new System.Drawing.Size(839, 314);
            this.dgvClientDebtsOrders.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvClientDebtsOrders.TabIndex = 0;
            this.dgvClientDebtsOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientDebtsOrders_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column1.Width = 40;
            // 
            // hh
            // 
            this.hh.HeaderText = "hh";
            this.hh.MinimumWidth = 22;
            this.hh.Name = "hh";
            this.hh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPDInvCom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbPaySys);
            this.panel1.Controls.Add(this.txtPDInvAc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbWallet);
            this.panel1.Controls.Add(this.txtHelp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNOSelectValues);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.dtpNO);
            this.panel1.Controls.Add(this.cmbNOclient);
            this.panel1.Controls.Add(this.txtNOBalance);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNODebts);
            this.panel1.Controls.Add(this.btnNOAdd);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 302);
            this.panel1.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(192, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 117;
            this.label4.Text = "Մեկնաբանություն";
            // 
            // txtPDInvCom
            // 
            this.txtPDInvCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPDInvCom.Location = new System.Drawing.Point(326, 228);
            this.txtPDInvCom.Multiline = true;
            this.txtPDInvCom.Name = "txtPDInvCom";
            this.txtPDInvCom.Size = new System.Drawing.Size(225, 52);
            this.txtPDInvCom.TabIndex = 116;
            this.txtPDInvCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(259, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "Վճ․ եղ,";
            // 
            // cmbPaySys
            // 
            this.cmbPaySys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbPaySys.FormattingEnabled = true;
            this.cmbPaySys.Location = new System.Drawing.Point(393, 41);
            this.cmbPaySys.Name = "cmbPaySys";
            this.cmbPaySys.Size = new System.Drawing.Size(90, 24);
            this.cmbPaySys.TabIndex = 114;
            // 
            // txtPDInvAc
            // 
            this.txtPDInvAc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPDInvAc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPDInvAc.Location = new System.Drawing.Point(12, 12);
            this.txtPDInvAc.Multiline = true;
            this.txtPDInvAc.Name = "txtPDInvAc";
            this.txtPDInvAc.Size = new System.Drawing.Size(90, 25);
            this.txtPDInvAc.TabIndex = 111;
            this.txtPDInvAc.Text = "Վաճառք";
            this.txtPDInvAc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPDInvAc.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(237, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 110;
            this.label2.Text = "Դրամարկղ";
            // 
            // cmbWallet
            // 
            this.cmbWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbWallet.FormattingEnabled = true;
            this.cmbWallet.Location = new System.Drawing.Point(326, 71);
            this.cmbWallet.Name = "cmbWallet";
            this.cmbWallet.Size = new System.Drawing.Size(225, 24);
            this.cmbWallet.TabIndex = 109;
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
            this.label1.Location = new System.Drawing.Point(246, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Մնացորդ";
            // 
            // txtNOSelectValues
            // 
            this.txtNOSelectValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNOSelectValues.Location = new System.Drawing.Point(393, 164);
            this.txtNOSelectValues.Multiline = true;
            this.txtNOSelectValues.Name = "txtNOSelectValues";
            this.txtNOSelectValues.Size = new System.Drawing.Size(90, 25);
            this.txtNOSelectValues.TabIndex = 106;
            this.txtNOSelectValues.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNOSelectValues.TextChanged += new System.EventHandler(this.txtNOSelectValues_TextChanged);
            this.txtNOSelectValues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNOSelectValues_KeyDown);
            this.txtNOSelectValues.Leave += new System.EventHandler(this.txtNOSelectValues_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(257, 137);
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
            this.label18.Location = new System.Drawing.Point(234, 107);
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
            this.label17.Location = new System.Drawing.Point(246, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 103;
            this.label17.Text = "Ամսաթիվ";
            // 
            // dtpNO
            // 
            this.dtpNO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNO.Location = new System.Drawing.Point(393, 15);
            this.dtpNO.Name = "dtpNO";
            this.dtpNO.Size = new System.Drawing.Size(90, 20);
            this.dtpNO.TabIndex = 100;
            // 
            // cmbNOclient
            // 
            this.cmbNOclient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbNOclient.FormattingEnabled = true;
            this.cmbNOclient.Location = new System.Drawing.Point(326, 101);
            this.cmbNOclient.Name = "cmbNOclient";
            this.cmbNOclient.Size = new System.Drawing.Size(225, 24);
            this.cmbNOclient.TabIndex = 95;
            // 
            // txtNOBalance
            // 
            this.txtNOBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNOBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNOBalance.Location = new System.Drawing.Point(393, 197);
            this.txtNOBalance.Multiline = true;
            this.txtNOBalance.Name = "txtNOBalance";
            this.txtNOBalance.Size = new System.Drawing.Size(90, 25);
            this.txtNOBalance.TabIndex = 53;
            this.txtNOBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(255, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Գումար";
            // 
            // txtNODebts
            // 
            this.txtNODebts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNODebts.ForeColor = System.Drawing.Color.Firebrick;
            this.txtNODebts.Location = new System.Drawing.Point(393, 131);
            this.txtNODebts.Multiline = true;
            this.txtNODebts.Name = "txtNODebts";
            this.txtNODebts.Size = new System.Drawing.Size(90, 25);
            this.txtNODebts.TabIndex = 4;
            this.txtNODebts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btnNOAdd.Location = new System.Drawing.Point(707, 240);
            this.btnNOAdd.Name = "btnNOAdd";
            this.btnNOAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNOAdd.Size = new System.Drawing.Size(125, 40);
            this.btnNOAdd.TabIndex = 5;
            this.btnNOAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNOAdd.UseVisualStyleBackColor = false;
            this.btnNOAdd.Click += new System.EventHandler(this.btnNOAdd_Click);
            // 
            // PayDebtsCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvClientDebtsOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PayDebtsCash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Կանխիկ";
            this.Load += new System.EventHandler(this.PayDebtsByClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientDebtsOrders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvClientDebtsOrders;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpNO;
        private System.Windows.Forms.ComboBox cmbNOclient;
        private System.Windows.Forms.TextBox txtNOBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNODebts;
        private System.Windows.Forms.Button btnNOAdd;
        private System.Windows.Forms.TextBox txtNOSelectValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHelp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWallet;
        private System.Windows.Forms.TextBox txtPDInvAc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPaySys;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPDInvCom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}