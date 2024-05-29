namespace ABCPrintInventory.Create
{
    partial class AddClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbtLP = new System.Windows.Forms.RadioButton();
            this.rbtPP = new System.Windows.Forms.RadioButton();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.txtClientLegName = new System.Windows.Forms.TextBox();
            this.txtClientAVC = new System.Windows.Forms.TextBox();
            this.txtClientContP = new System.Windows.Forms.TextBox();
            this.txtClientTel = new System.Windows.Forms.MaskedTextBox();
            this.txtClientTel2 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtClientMail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClientNote = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtClientAcount = new System.Windows.Forms.MaskedTextBox();
            this.cmbClientBank = new System.Windows.Forms.ComboBox();
            this.txtClientCod = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtClientAddress = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExToEx = new System.Windows.Forms.Button();
            this.dgvClient = new Zuby.ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.SuspendLayout();
            // 
            // rbtLP
            // 
            this.rbtLP.AutoSize = true;
            this.rbtLP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtLP.Location = new System.Drawing.Point(21, 150);
            this.rbtLP.Name = "rbtLP";
            this.rbtLP.Size = new System.Drawing.Size(157, 19);
            this.rbtLP.TabIndex = 1;
            this.rbtLP.TabStop = true;
            this.rbtLP.Text = "Կազմակերպություն";
            this.rbtLP.UseVisualStyleBackColor = true;
            // 
            // rbtPP
            // 
            this.rbtPP.AutoSize = true;
            this.rbtPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtPP.Location = new System.Drawing.Point(21, 120);
            this.rbtPP.Name = "rbtPP";
            this.rbtPP.Size = new System.Drawing.Size(73, 19);
            this.rbtPP.TabIndex = 1;
            this.rbtPP.TabStop = true;
            this.rbtPP.Text = "Անհատ";
            this.rbtPP.UseVisualStyleBackColor = true;
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(281, 27);
            this.txtClientName.Multiline = true;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(200, 22);
            this.txtClientName.TabIndex = 2;
            // 
            // txtClientLegName
            // 
            this.txtClientLegName.Location = new System.Drawing.Point(648, 27);
            this.txtClientLegName.Multiline = true;
            this.txtClientLegName.Name = "txtClientLegName";
            this.txtClientLegName.Size = new System.Drawing.Size(200, 22);
            this.txtClientLegName.TabIndex = 6;
            // 
            // txtClientAVC
            // 
            this.txtClientAVC.Location = new System.Drawing.Point(648, 67);
            this.txtClientAVC.Multiline = true;
            this.txtClientAVC.Name = "txtClientAVC";
            this.txtClientAVC.Size = new System.Drawing.Size(200, 22);
            this.txtClientAVC.TabIndex = 7;
            this.txtClientAVC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientAVC_KeyPress);
            // 
            // txtClientContP
            // 
            this.txtClientContP.Location = new System.Drawing.Point(1016, 27);
            this.txtClientContP.Multiline = true;
            this.txtClientContP.Name = "txtClientContP";
            this.txtClientContP.Size = new System.Drawing.Size(200, 22);
            this.txtClientContP.TabIndex = 10;
            // 
            // txtClientTel
            // 
            this.txtClientTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtClientTel.Location = new System.Drawing.Point(281, 67);
            this.txtClientTel.Mask = "(+374) 00 000000";
            this.txtClientTel.Name = "txtClientTel";
            this.txtClientTel.Size = new System.Drawing.Size(200, 22);
            this.txtClientTel.TabIndex = 3;
            // 
            // txtClientTel2
            // 
            this.txtClientTel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtClientTel2.Location = new System.Drawing.Point(1016, 65);
            this.txtClientTel2.Name = "txtClientTel2";
            this.txtClientTel2.Size = new System.Drawing.Size(200, 22);
            this.txtClientTel2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(214, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "* Անուն";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(591, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "ՀՎՀՀ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(602, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Հ/Հ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(591, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Բանկ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(922, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 26);
            this.label6.TabIndex = 15;
            this.label6.Text = "Միջնորդ/\r\nԿոնտ. անձ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(222, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Հեռ. 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(950, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Հեռ. 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(205, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Էլ. փոստ";
            // 
            // txtClientMail
            // 
            this.txtClientMail.Location = new System.Drawing.Point(281, 107);
            this.txtClientMail.Multiline = true;
            this.txtClientMail.Name = "txtClientMail";
            this.txtClientMail.Size = new System.Drawing.Size(200, 22);
            this.txtClientMail.TabIndex = 4;
            this.txtClientMail.Validating += new System.ComponentModel.CancelEventHandler(this.txtClientMail_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(952, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Նշում";
            // 
            // txtClientNote
            // 
            this.txtClientNote.Location = new System.Drawing.Point(1016, 103);
            this.txtClientNote.Multiline = true;
            this.txtClientNote.Name = "txtClientNote";
            this.txtClientNote.Size = new System.Drawing.Size(200, 66);
            this.txtClientNote.TabIndex = 12;
            this.txtClientNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClientNote_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.txtClientAcount);
            this.panel1.Controls.Add(this.cmbClientBank);
            this.panel1.Controls.Add(this.txtClientCod);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtClientAddress);
            this.panel1.Controls.Add(this.txtClientId);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtClientNote);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtClientTel2);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtClientContP);
            this.panel1.Controls.Add(this.txtClientMail);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rbtLP);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbtPP);
            this.panel1.Controls.Add(this.txtClientName);
            this.panel1.Controls.Add(this.txtClientTel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtClientAVC);
            this.panel1.Controls.Add(this.txtClientLegName);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1450, 190);
            this.panel1.TabIndex = 52;
            // 
            // txtClientAcount
            // 
            this.txtClientAcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtClientAcount.Location = new System.Drawing.Point(648, 147);
            this.txtClientAcount.Name = "txtClientAcount";
            this.txtClientAcount.Size = new System.Drawing.Size(200, 22);
            this.txtClientAcount.TabIndex = 61;
            this.txtClientAcount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClientAcount_KeyPress);
            // 
            // cmbClientBank
            // 
            this.cmbClientBank.FormattingEnabled = true;
            this.cmbClientBank.Location = new System.Drawing.Point(648, 107);
            this.cmbClientBank.Name = "cmbClientBank";
            this.cmbClientBank.Size = new System.Drawing.Size(200, 21);
            this.cmbClientBank.TabIndex = 60;
            // 
            // txtClientCod
            // 
            this.txtClientCod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtClientCod.Enabled = false;
            this.txtClientCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtClientCod.Location = new System.Drawing.Point(62, 67);
            this.txtClientCod.Multiline = true;
            this.txtClientCod.Name = "txtClientCod";
            this.txtClientCod.Size = new System.Drawing.Size(60, 22);
            this.txtClientCod.TabIndex = 0;
            this.txtClientCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(12, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "* Կոդ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(563, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 26);
            this.label5.TabIndex = 57;
            this.label5.Text = "Իրավ.\r\nանվանում";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(220, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Հասցե";
            // 
            // txtClientAddress
            // 
            this.txtClientAddress.Location = new System.Drawing.Point(281, 147);
            this.txtClientAddress.Multiline = true;
            this.txtClientAddress.Name = "txtClientAddress";
            this.txtClientAddress.Size = new System.Drawing.Size(200, 22);
            this.txtClientAddress.TabIndex = 5;
            // 
            // txtClientId
            // 
            this.txtClientId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtClientId.Enabled = false;
            this.txtClientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtClientId.Location = new System.Drawing.Point(62, 27);
            this.txtClientId.Multiline = true;
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(60, 22);
            this.txtClientId.TabIndex = 0;
            this.txtClientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(22, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "* հհ";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.Maroon;
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(1379, 129);
            this.btnDel.Name = "btnDel";
            this.btnDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDel.Size = new System.Drawing.Size(42, 40);
            this.btnDel.TabIndex = 15;
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.Teal;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(1331, 129);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEdit.Size = new System.Drawing.Size(42, 40);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(1283, 129);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(42, 40);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExToEx
            // 
            this.btnExToEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExToEx.BackgroundImage = global::ABCPrintInventory.Properties.Resources.buttonimage;
            this.btnExToEx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExToEx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExToEx.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExToEx.Location = new System.Drawing.Point(1320, 657);
            this.btnExToEx.Name = "btnExToEx";
            this.btnExToEx.Size = new System.Drawing.Size(101, 34);
            this.btnExToEx.TabIndex = 17;
            this.btnExToEx.UseVisualStyleBackColor = true;
            this.btnExToEx.Click += new System.EventHandler(this.btnExToEx_Click);
            // 
            // dgvClient
            // 
            this.dgvClient.AllowUserToAddRows = false;
            this.dgvClient.AllowUserToDeleteRows = false;
            this.dgvClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClient.FilterAndSortEnabled = true;
            this.dgvClient.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvClient.Location = new System.Drawing.Point(0, 199);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.ReadOnly = true;
            this.dgvClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvClient.Size = new System.Drawing.Size(1450, 450);
            this.dgvClient.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvClient.TabIndex = 53;
            this.dgvClient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClient_CellDoubleClick);
            // 
            // AddClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1450, 700);
            this.Controls.Add(this.dgvClient);
            this.Controls.Add(this.btnExToEx);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AddClient";
            this.Text = "Ավելացնել հաճախորդ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CreateClient_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddClient_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtLP;
        private System.Windows.Forms.RadioButton rbtPP;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TextBox txtClientLegName;
        private System.Windows.Forms.TextBox txtClientAVC;
        private System.Windows.Forms.TextBox txtClientContP;
        private System.Windows.Forms.MaskedTextBox txtClientTel;
        private System.Windows.Forms.MaskedTextBox txtClientTel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtClientMail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClientNote;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExToEx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtClientAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtClientCod;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtClientAcount;
        private System.Windows.Forms.ComboBox cmbClientBank;
        private Zuby.ADGV.AdvancedDataGridView dgvClient;
    }
}