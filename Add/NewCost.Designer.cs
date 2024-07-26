namespace ABCPrintInventory.Add
{
    partial class NewCost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCost));
            this.dgvCost = new Zuby.ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNCcom = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.txtNCid = new System.Windows.Forms.TextBox();
            this.txtNCtotVal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbNCpaySys = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbNCart = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNO = new System.Windows.Forms.DateTimePicker();
            this.cmbNCpur = new System.Windows.Forms.ComboBox();
            this.txtNCcod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditban = new System.Windows.Forms.Button();
            this.btnAddban = new System.Windows.Forms.Button();
            this.btnDelban = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNPvalTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNPvalNds = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCost)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCost
            // 
            this.dgvCost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            this.dgvCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCost.ColumnHeadersHeight = 24;
            this.dgvCost.FilterAndSortEnabled = true;
            this.dgvCost.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvCost.Location = new System.Drawing.Point(0, 158);
            this.dgvCost.Name = "dgvCost";
            this.dgvCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvCost.Size = new System.Drawing.Size(1227, 581);
            this.dgvCost.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvCost.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtNPvalTotal);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtNPvalNds);
            this.panel1.Controls.Add(this.txtNCcom);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtAction);
            this.panel1.Controls.Add(this.txtNCid);
            this.panel1.Controls.Add(this.txtNCtotVal);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbNCpaySys);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnEditban);
            this.panel1.Controls.Add(this.cmbNCart);
            this.panel1.Controls.Add(this.btnAddban);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnDelban);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpNO);
            this.panel1.Controls.Add(this.cmbNCpur);
            this.panel1.Controls.Add(this.txtNCcod);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1227, 141);
            this.panel1.TabIndex = 54;
            // 
            // txtNCcom
            // 
            this.txtNCcom.Location = new System.Drawing.Point(251, 93);
            this.txtNCcom.Multiline = true;
            this.txtNCcom.Name = "txtNCcom";
            this.txtNCcom.Size = new System.Drawing.Size(477, 30);
            this.txtNCcom.TabIndex = 114;
            this.txtNCcom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(146, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 158;
            this.label12.Text = "Ամսաթիվ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(862, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 157;
            this.label11.Text = "ԱՐԺԵՔ";
            // 
            // txtAction
            // 
            this.txtAction.BackColor = System.Drawing.SystemColors.Window;
            this.txtAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAction.Location = new System.Drawing.Point(894, 60);
            this.txtAction.Multiline = true;
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(123, 28);
            this.txtAction.TabIndex = 156;
            this.txtAction.Text = "Ծախս";
            this.txtAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAction.Visible = false;
            // 
            // txtNCid
            // 
            this.txtNCid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNCid.Enabled = false;
            this.txtNCid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNCid.Location = new System.Drawing.Point(914, 93);
            this.txtNCid.Multiline = true;
            this.txtNCid.Name = "txtNCid";
            this.txtNCid.Size = new System.Drawing.Size(69, 25);
            this.txtNCid.TabIndex = 155;
            this.txtNCid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNCid.Visible = false;
            // 
            // txtNCtotVal
            // 
            this.txtNCtotVal.BackColor = System.Drawing.Color.White;
            this.txtNCtotVal.Location = new System.Drawing.Point(836, 33);
            this.txtNCtotVal.Multiline = true;
            this.txtNCtotVal.Name = "txtNCtotVal";
            this.txtNCtotVal.Size = new System.Drawing.Size(104, 21);
            this.txtNCtotVal.TabIndex = 150;
            this.txtNCtotVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(760, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 120;
            this.label9.Text = "Վճ․ եղ";
            // 
            // cmbNCpaySys
            // 
            this.cmbNCpaySys.FormattingEnabled = true;
            this.cmbNCpaySys.Items.AddRange(new object[] {
            "Կ",
            "Փ"});
            this.cmbNCpaySys.Location = new System.Drawing.Point(752, 33);
            this.cmbNCpaySys.Name = "cmbNCpaySys";
            this.cmbNCpaySys.Size = new System.Drawing.Size(60, 21);
            this.cmbNCpaySys.TabIndex = 119;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(303, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 13);
            this.label10.TabIndex = 112;
            this.label10.Text = "Ծախսային հոդված";
            // 
            // cmbNCart
            // 
            this.cmbNCart.FormattingEnabled = true;
            this.cmbNCart.Location = new System.Drawing.Point(251, 33);
            this.cmbNCart.Name = "cmbNCart";
            this.cmbNCart.Size = new System.Drawing.Size(227, 21);
            this.cmbNCart.TabIndex = 108;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(425, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Մեկնաբանություն";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(581, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Գործընկեր";
            // 
            // dtpNO
            // 
            this.dtpNO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNO.Location = new System.Drawing.Point(123, 33);
            this.dtpNO.Name = "dtpNO";
            this.dtpNO.Size = new System.Drawing.Size(104, 20);
            this.dtpNO.TabIndex = 101;
            // 
            // cmbNCpur
            // 
            this.cmbNCpur.FormattingEnabled = true;
            this.cmbNCpur.Location = new System.Drawing.Point(507, 33);
            this.cmbNCpur.Name = "cmbNCpur";
            this.cmbNCpur.Size = new System.Drawing.Size(221, 21);
            this.cmbNCpur.TabIndex = 55;
            // 
            // txtNCcod
            // 
            this.txtNCcod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNCcod.Enabled = false;
            this.txtNCcod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNCcod.Location = new System.Drawing.Point(36, 33);
            this.txtNCcod.Multiline = true;
            this.txtNCcod.Name = "txtNCcod";
            this.txtNCcod.Size = new System.Drawing.Size(63, 21);
            this.txtNCcod.TabIndex = 0;
            this.txtNCcod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(52, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Կոդ";
            // 
            // btnEditban
            // 
            this.btnEditban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditban.BackColor = System.Drawing.Color.Teal;
            this.btnEditban.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditban.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditban.FlatAppearance.BorderSize = 0;
            this.btnEditban.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEditban.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditban.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditban.Image = ((System.Drawing.Image)(resources.GetObject("btnEditban.Image")));
            this.btnEditban.Location = new System.Drawing.Point(1131, 83);
            this.btnEditban.Name = "btnEditban";
            this.btnEditban.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEditban.Size = new System.Drawing.Size(42, 40);
            this.btnEditban.TabIndex = 6;
            this.btnEditban.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditban.UseVisualStyleBackColor = false;
            // 
            // btnAddban
            // 
            this.btnAddban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddban.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddban.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddban.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddban.FlatAppearance.BorderSize = 0;
            this.btnAddban.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddban.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddban.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddban.Image = ((System.Drawing.Image)(resources.GetObject("btnAddban.Image")));
            this.btnAddban.Location = new System.Drawing.Point(1086, 83);
            this.btnAddban.Name = "btnAddban";
            this.btnAddban.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddban.Size = new System.Drawing.Size(42, 40);
            this.btnAddban.TabIndex = 5;
            this.btnAddban.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddban.UseVisualStyleBackColor = false;
            this.btnAddban.Click += new System.EventHandler(this.btnAddban_Click);
            // 
            // btnDelban
            // 
            this.btnDelban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelban.BackColor = System.Drawing.Color.Maroon;
            this.btnDelban.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelban.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelban.FlatAppearance.BorderSize = 0;
            this.btnDelban.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDelban.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelban.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelban.Image = ((System.Drawing.Image)(resources.GetObject("btnDelban.Image")));
            this.btnDelban.Location = new System.Drawing.Point(1175, 83);
            this.btnDelban.Name = "btnDelban";
            this.btnDelban.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelban.Size = new System.Drawing.Size(42, 40);
            this.btnDelban.TabIndex = 7;
            this.btnDelban.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelban.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(1054, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 166;
            this.label14.Text = "ԸՆԴՀԱՆՈՒՐ";
            this.label14.Visible = false;
            // 
            // txtNPvalTotal
            // 
            this.txtNPvalTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNPvalTotal.Location = new System.Drawing.Point(1050, 32);
            this.txtNPvalTotal.Multiline = true;
            this.txtNPvalTotal.Name = "txtNPvalTotal";
            this.txtNPvalTotal.Size = new System.Drawing.Size(93, 21);
            this.txtNPvalTotal.TabIndex = 165;
            this.txtNPvalTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNPvalTotal.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(975, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 164;
            this.label13.Text = "ԱԱՀ";
            this.label13.Visible = false;
            // 
            // txtNPvalNds
            // 
            this.txtNPvalNds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNPvalNds.Location = new System.Drawing.Point(960, 32);
            this.txtNPvalNds.Multiline = true;
            this.txtNPvalNds.Name = "txtNPvalNds";
            this.txtNPvalNds.Size = new System.Drawing.Size(75, 21);
            this.txtNPvalNds.TabIndex = 163;
            this.txtNPvalNds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNPvalNds.Visible = false;
            // 
            // NewCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 737);
            this.Controls.Add(this.dgvCost);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewCost";
            this.Text = "NewCost";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NewCost_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCost)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView dgvCost;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNCcom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.TextBox txtNCid;
        private System.Windows.Forms.TextBox txtNCtotVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbNCpaySys;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnEditban;
        private System.Windows.Forms.ComboBox cmbNCart;
        private System.Windows.Forms.Button btnAddban;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelban;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNO;
        private System.Windows.Forms.ComboBox cmbNCpur;
        private System.Windows.Forms.TextBox txtNCcod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNPvalTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNPvalNds;
    }
}