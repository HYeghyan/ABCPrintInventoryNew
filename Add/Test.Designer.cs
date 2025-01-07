namespace ABCPrintInventory.Add
{
    partial class Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDebt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNO = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNOclient = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNOAdd = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtAc = new System.Windows.Forms.TextBox();
            this.cmbPaySys = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvDeptscontrol = new Zuby.ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptscontrol)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(225, 112);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(103, 20);
            this.txtCode.TabIndex = 1;
            // 
            // txtDebt
            // 
            this.txtDebt.Location = new System.Drawing.Point(672, 112);
            this.txtDebt.Name = "txtDebt";
            this.txtDebt.Size = new System.Drawing.Size(77, 20);
            this.txtDebt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Հաճախորդ";
            // 
            // dtpNO
            // 
            this.dtpNO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNO.Location = new System.Drawing.Point(44, 112);
            this.dtpNO.Name = "dtpNO";
            this.dtpNO.Size = new System.Drawing.Size(139, 20);
            this.dtpNO.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "Ամսաթիվ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 103;
            this.label4.Text = "Պատվ․ համ";
            // 
            // cmbNOclient
            // 
            this.cmbNOclient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbNOclient.FormattingEnabled = true;
            this.cmbNOclient.Location = new System.Drawing.Point(361, 110);
            this.cmbNOclient.Name = "cmbNOclient";
            this.cmbNOclient.Size = new System.Drawing.Size(278, 24);
            this.cmbNOclient.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(687, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "Պարտք";
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
            this.btnNOAdd.Location = new System.Drawing.Point(794, 112);
            this.btnNOAdd.Name = "btnNOAdd";
            this.btnNOAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNOAdd.Size = new System.Drawing.Size(133, 40);
            this.btnNOAdd.TabIndex = 106;
            this.btnNOAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNOAdd.UseVisualStyleBackColor = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(44, 47);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(139, 20);
            this.txtID.TabIndex = 107;
            // 
            // txtAc
            // 
            this.txtAc.Location = new System.Drawing.Point(225, 47);
            this.txtAc.Name = "txtAc";
            this.txtAc.Size = new System.Drawing.Size(139, 20);
            this.txtAc.TabIndex = 108;
            this.txtAc.Text = "Վաճառք";
            // 
            // cmbPaySys
            // 
            this.cmbPaySys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbPaySys.FormattingEnabled = true;
            this.cmbPaySys.Items.AddRange(new object[] {
            "Կ",
            "Հ",
            "Ք",
            "Փ"});
            this.cmbPaySys.Location = new System.Drawing.Point(408, 45);
            this.cmbPaySys.Name = "cmbPaySys";
            this.cmbPaySys.Size = new System.Drawing.Size(90, 24);
            this.cmbPaySys.TabIndex = 115;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(971, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 83);
            this.button1.TabIndex = 116;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvDeptscontrol
            // 
            this.dgvDeptscontrol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            this.dgvDeptscontrol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDeptscontrol.ColumnHeadersHeight = 24;
            this.dgvDeptscontrol.FilterAndSortEnabled = true;
            this.dgvDeptscontrol.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvDeptscontrol.Location = new System.Drawing.Point(0, 193);
            this.dgvDeptscontrol.Name = "dgvDeptscontrol";
            this.dgvDeptscontrol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvDeptscontrol.Size = new System.Drawing.Size(1200, 415);
            this.dgvDeptscontrol.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.dgvDeptscontrol.TabIndex = 117;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1199, 607);
            this.Controls.Add(this.dgvDeptscontrol);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbPaySys);
            this.Controls.Add(this.txtAc);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnNOAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbNOclient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpNO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDebt);
            this.Controls.Add(this.txtCode);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptscontrol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtDebt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNOclient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNOAdd;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtAc;
        private System.Windows.Forms.ComboBox cmbPaySys;
        private System.Windows.Forms.Button button1;
        private Zuby.ADGV.AdvancedDataGridView dgvDeptscontrol;
    }
}