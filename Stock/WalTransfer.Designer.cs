namespace ABCPrintInventory.Stock
{
    partial class WalTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WalTransfer));
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotVal = new System.Windows.Forms.TextBox();
            this.cmbWTin = new System.Windows.Forms.ComboBox();
            this.cmbWTout = new System.Windows.Forms.ComboBox();
            this.dtpWT = new System.Windows.Forms.DateTimePicker();
            this.txtDebtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNOAdd = new System.Windows.Forms.Button();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.cmbWTcom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(70, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 166;
            this.label2.Text = "Կոդ";
            this.label2.Visible = false;
            // 
            // txtTotVal
            // 
            this.txtTotVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTotVal.Location = new System.Drawing.Point(272, 181);
            this.txtTotVal.Multiline = true;
            this.txtTotVal.Name = "txtTotVal";
            this.txtTotVal.Size = new System.Drawing.Size(93, 27);
            this.txtTotVal.TabIndex = 165;
            this.txtTotVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotVal.TextChanged += new System.EventHandler(this.txtTotVal_TextChanged);
            // 
            // cmbWTin
            // 
            this.cmbWTin.FormattingEnabled = true;
            this.cmbWTin.Location = new System.Drawing.Point(232, 142);
            this.cmbWTin.Name = "cmbWTin";
            this.cmbWTin.Size = new System.Drawing.Size(168, 21);
            this.cmbWTin.TabIndex = 164;
            // 
            // cmbWTout
            // 
            this.cmbWTout.FormattingEnabled = true;
            this.cmbWTout.Location = new System.Drawing.Point(232, 103);
            this.cmbWTout.Name = "cmbWTout";
            this.cmbWTout.Size = new System.Drawing.Size(168, 21);
            this.cmbWTout.TabIndex = 163;
            // 
            // dtpWT
            // 
            this.dtpWT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWT.Location = new System.Drawing.Point(272, 67);
            this.dtpWT.Name = "dtpWT";
            this.dtpWT.Size = new System.Drawing.Size(93, 20);
            this.dtpWT.TabIndex = 162;
            // 
            // txtDebtId
            // 
            this.txtDebtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDebtId.Enabled = false;
            this.txtDebtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDebtId.Location = new System.Drawing.Point(117, 12);
            this.txtDebtId.Multiline = true;
            this.txtDebtId.Name = "txtDebtId";
            this.txtDebtId.Size = new System.Drawing.Size(93, 21);
            this.txtDebtId.TabIndex = 160;
            this.txtDebtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebtId.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(148, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 161;
            this.label5.Text = "Ամսաթիվ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 167;
            this.label1.Text = "Ելքագրվող դրամարկղ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(51, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 168;
            this.label3.Text = "Մուտքագրվող դրամարկղ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(157, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 169;
            this.label4.Text = "Գումար";
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
            this.btnNOAdd.Location = new System.Drawing.Point(272, 354);
            this.btnNOAdd.Name = "btnNOAdd";
            this.btnNOAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNOAdd.Size = new System.Drawing.Size(93, 40);
            this.btnNOAdd.TabIndex = 170;
            this.btnNOAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNOAdd.UseVisualStyleBackColor = false;
            this.btnNOAdd.Click += new System.EventHandler(this.btnNOAdd_Click);
            // 
            // txtAction
            // 
            this.txtAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAction.Location = new System.Drawing.Point(232, 12);
            this.txtAction.Multiline = true;
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(168, 27);
            this.txtAction.TabIndex = 172;
            this.txtAction.Text = "Փոխանցում";
            this.txtAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAction.Visible = false;
            // 
            // cmbWTcom
            // 
            this.cmbWTcom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbWTcom.Location = new System.Drawing.Point(232, 224);
            this.cmbWTcom.Multiline = true;
            this.cmbWTcom.Name = "cmbWTcom";
            this.cmbWTcom.Size = new System.Drawing.Size(168, 111);
            this.cmbWTcom.TabIndex = 173;
            this.cmbWTcom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(94, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 174;
            this.label6.Text = "Մեկնաբանություն";
            // 
            // WalTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(513, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbWTcom);
            this.Controls.Add(this.txtAction);
            this.Controls.Add(this.btnNOAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotVal);
            this.Controls.Add(this.cmbWTin);
            this.Controls.Add(this.cmbWTout);
            this.Controls.Add(this.dtpWT);
            this.Controls.Add(this.txtDebtId);
            this.Controls.Add(this.label5);
            this.Name = "WalTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Միջդրամարկղային փոխանցումներ";
            this.Load += new System.EventHandler(this.WalTransfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotVal;
        private System.Windows.Forms.ComboBox cmbWTin;
        private System.Windows.Forms.ComboBox cmbWTout;
        private System.Windows.Forms.DateTimePicker dtpWT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNOAdd;
        private System.Windows.Forms.TextBox txtDebtId;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.TextBox cmbWTcom;
        private System.Windows.Forms.Label label6;
    }
}