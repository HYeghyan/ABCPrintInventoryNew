using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ABCPrintInventory.Add
{
    public partial class NewPurchasing : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public NewPurchasing()
        {
            InitializeComponent();
        }

        private void NewPurchasing_Load(object sender, EventArgs e)
        {           
            GetItemId();
            GetDebtItemId();
            FillGrid();
            PurchaiserComboboxComplate();
            GetBanval();
            GetLuvval();
            GetStval();
            GetColval();
            GetOthval();
        }       
        private void GetItemId()
        {
            string codePrefix = "ՁԲ";
            string codeNumber;

            con.Open();

            cmd = new SqlCommand("SELECT MAX(Կոդ) FROM TblPurchasing WHERE Կոդ LIKE @codePrefix", con);
            cmd.Parameters.AddWithValue("@codePrefix", codePrefix + "%");
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result != DBNull.Value && result != null)
            {
                string lastCode = result.ToString();
                string lastNumberStr = lastCode.Substring(codePrefix.Length);

                // Parsing the numeric part, allowing any length
                if (int.TryParse(lastNumberStr, out int lastNumber))
                {
                    codeNumber = (lastNumber + 1).ToString();  // No specific format, so it can grow beyond two digits
                }
                else
                {
                    codeNumber = "1";  // If parsing fails, start from 1
                }
            }
            else
            {
                codeNumber = "1";  // Start from 1 if no previous code exists
            }

            string newCode = codePrefix + codeNumber;
            txtNPcod.Text = newCode;
        }
        private void FillGrid()
        {
            cmbNPCatBan.SelectedIndex = 4;
            con.Open();
            da = new SqlDataAdapter("select * from TblPurchasing order by Կոդ asc", con);
            con.Close();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgvPurchasing.DataSource = dt;
            dgvPurchasing.Columns["Կոդ"].Width = 70;
            dgvPurchasing.Columns["Կոդ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
        }

        //-------Կոմբոները և պանելների փոփոխությունները-----
        private void PurchaiserComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Անվանում) FROM TblPurchaiser", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbnewPurchPur.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void PanelChange()
        {
            if(cmbNPCatBan.Text == "Պաստառ")
            {
                panelBan.Visible = true;
                panelSt.Visible = false;
                panelLuv.Visible = false;
                panelCol.Visible = false;
                panelOth.Visible = false;
                txtNPbanUn.Text = "քմ";
                txtNPstUn.Text = "";
                txtNPluvUn.Text = "";
                txtNPcolUn.Text = "";
                txtNPothUn.Text = "";
                BanComboboxComplate();
            }
            else if(cmbNPCatBan.Text == "Վահանակ")
            {
                panelBan.Visible = false;
                panelSt.Visible = true;
                panelLuv.Visible = false;
                panelCol.Visible = false;
                panelOth.Visible = false;
                txtNPbanUn.Text = "";
                txtNPstUn.Text = "հատ";
                txtNPluvUn.Text = "";
                txtNPcolUn.Text = "";
                txtNPothUn.Text = "";
                StndComboboxComplate();
            }
            else if (cmbNPCatBan.Text == "Կոճգամ")
            {
                panelBan.Visible = false;
                panelSt.Visible = false;
                panelLuv.Visible = true;
                panelCol.Visible = false;
                panelOth.Visible = false;
                txtNPbanUn.Text = "";
                txtNPstUn.Text = "";
                txtNPluvUn.Text = "հատ";
                txtNPcolUn.Text = "";
                txtNPothUn.Text = "";
            }
            else if (cmbNPCatBan.Text == "Ներկ")
            {
                panelBan.Visible = false;
                panelSt.Visible = false;
                panelLuv.Visible = false;
                panelCol.Visible = true;
                panelOth.Visible = false;
                txtNPbanUn.Text = "";
                txtNPstUn.Text = "";
                txtNPluvUn.Text = "";
                txtNPcolUn.Text = "լ";
                txtNPothUn.Text = "";
                ColComboboxComplate();
            }
            else if (cmbNPCatBan.Text == "Այլ")
            {
                panelBan.Visible = true;
                panelSt.Visible = false;
                panelLuv.Visible = false;
                panelCol.Visible = false;
                panelOth.Visible = true;
                txtNPbanUn.Text = "";
                txtNPstUn.Text = "";
                txtNPluvUn.Text = "";
                txtNPcolUn.Text = "";
                txtNPothUn.Text = "";
            }
        }
        private void cmbNPCatBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelChange();
        }

        private void BanComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Name) FROM TblMaterialBan", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNPban.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void StndComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Վահանակ) FROM TblStand", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNPst.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        private void ColComboboxComplate()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.AbcprintinvCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(Ներկ) FROM TblInk", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbNPcol.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
        }
        //---Դիզայն---

        //------------արժեք
        //--պաստ
        private void BanValResolution()
        {

            if (!string.IsNullOrEmpty(txtNPbanQnt.Text) && !string.IsNullOrEmpty(txtNPbanPrice.Text))
            {
                decimal banQnt = Convert.ToDecimal(txtNPbanQnt.Text);
                decimal banPr = Convert.ToDecimal(txtNPbanPrice.Text);
                decimal banVal = banQnt * banPr;

                txtNPbanVal.Text = banVal.ToString("N0");
            }           
        }
        private void BanResolutionTextChanged(object sender, EventArgs e)
        {
            BanValResolution();
            TotValResolution();
        }
        private void GetBanval()
        {
            txtNPbanQnt.TextChanged += BanResolutionTextChanged;
            txtNPbanPrice.TextChanged += BanResolutionTextChanged;
        }
        //--կոճ
        private void LuvValResolution()
        {

            if (!string.IsNullOrEmpty(txtNPluvQnt.Text) && !string.IsNullOrEmpty(txtNPluvPrice.Text))
            {
                decimal luvQnt = Convert.ToDecimal(txtNPluvQnt.Text);
                decimal luvPr = Convert.ToDecimal(txtNPluvPrice.Text);
                decimal luvVal = luvQnt * luvPr;

                txtNPluvVal.Text = luvVal.ToString("N0");
            }
        }
        private void LuvResolutionTextChanged(object sender, EventArgs e)
        {
            LuvValResolution();
        }
        private void GetLuvval()
        {
            txtNPluvQnt.TextChanged += LuvResolutionTextChanged;
            txtNPluvPrice.TextChanged += LuvResolutionTextChanged;
        }
        //--վահ
        private void StValResolution()
        {

            if (!string.IsNullOrEmpty(txtNPstQnt.Text) && !string.IsNullOrEmpty(txtNPstPrice.Text))
            {
                decimal stQnt = Convert.ToDecimal(txtNPstQnt.Text);
                decimal stPr = Convert.ToDecimal(txtNPstPrice.Text);
                decimal stVal = stQnt * stPr;

                txtNPstVal.Text = stVal.ToString("N0");
            }
        }
        private void StResolutionTextChanged(object sender, EventArgs e)
        {
            StValResolution();
        }
        private void GetStval()
        {
            txtNPstQnt.TextChanged += StResolutionTextChanged;
            txtNPstPrice.TextChanged += StResolutionTextChanged;
        }
        //--ներկ
        private void ColValResolution()
        {

            if (!string.IsNullOrEmpty(txtNPcolQnt.Text) && !string.IsNullOrEmpty(txtNPcolPrice.Text))
            {
                decimal colQnt = Convert.ToDecimal(txtNPcolQnt.Text);
                decimal colPr = Convert.ToDecimal(txtNPcolPrice.Text);
                decimal colVal = colQnt * colPr;

                txtNPcolVal.Text = colVal.ToString("N0");
            }
        }
        private void ColResolutionTextChanged(object sender, EventArgs e)
        {
            ColValResolution();
        }
        private void GetColval()
        {
            txtNPcolQnt.TextChanged += ColResolutionTextChanged;
            txtNPcolPrice.TextChanged += ColResolutionTextChanged;
        }
        //--այլ
        private void OthValResolution()
        {

            if (!string.IsNullOrEmpty(txtNPothQnt.Text) && !string.IsNullOrEmpty(txtNPothPrice.Text))
            {
                decimal othQnt = Convert.ToDecimal(txtNPothQnt.Text);
                decimal othPr = Convert.ToDecimal(txtNPothPrice.Text);
                decimal othVal = othQnt * othPr;

                txtNPothVal.Text = othVal.ToString("N0");
            }
        }
        private void OthResolutionTextChanged(object sender, EventArgs e)
        {
            OthValResolution();
            TotValResolution();
        }
        private void GetOthval()
        {
            txtNPothQnt.TextChanged += OthResolutionTextChanged;
            txtNPothPrice.TextChanged += OthResolutionTextChanged;
        }
        //--Ընդ արժեք
        private void TotValResolution()
        {
            decimal banVal = 0, luvVal = 0, stVal = 0, colVal = 0, othVal = 0;

            decimal.TryParse(txtNPbanVal.Text, out banVal);
            decimal.TryParse(txtNPluvVal.Text, out luvVal);
            decimal.TryParse(txtNPstVal.Text, out stVal);
            decimal.TryParse(txtNPcolVal.Text, out colVal);
            decimal.TryParse(txtNPothVal.Text, out othVal);

            decimal totVal = banVal + luvVal + stVal + colVal + othVal;
            decimal ndsVal = (totVal * 20 / 100);
            decimal totwNDS = totVal + ndsVal;

            if (cmbnewPurchPaySys.Text == "Կ")
            {
                txtNPTotVal.Text = totVal.ToString("N0");
                txtNPvalNds.Text = "";
                txtNPvalTotal.Text = "";
            } 
            
            else if (cmbnewPurchPaySys.Text == "Փ")
            {
                txtNPTotVal.Text = totVal.ToString("N0");
                txtNPvalNds.Text = ndsVal.ToString("N0");
                txtNPvalTotal.Text = totwNDS.ToString("N0");
            }          
        }
        private void cmbnewPurchPaySys_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotValResolution();
        }
        //------Պարտքերի կառվարման աղյուսակի համար կոդ
        private void GetDebtItemId()
        {
            string codePrefix = "ՊԿ";
            string codeNumber;

            con.Open();

            // Use CAST or TRY_CAST to extract the numeric part after the prefix for correct sorting
            cmd = new SqlCommand(@"SELECT MAX(CAST(SUBSTRING(hh, LEN(@codePrefix) + 1, LEN(hh)) AS INT))
                                FROM TblDebtsControl WHERE hh LIKE @codePrefix + '%'", con);

            cmd.Parameters.AddWithValue("@codePrefix", codePrefix);
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result != DBNull.Value && result != null)
            {
                // Increment the numeric part
                int lastNumber = Convert.ToInt32(result);
                codeNumber = (lastNumber + 1).ToString();
            }
            else
            {
                // Start from 1 if no records are found
                codeNumber = "01";
            }

            // Combine the prefix and the incremented number
            string newCode = codePrefix + codeNumber;
            txtNPid.Text = newCode;
        }

        //------------վանդակների մաքրելը
        private void BanClearText()
        {
            cmbnewPurchPur.Text = "";
            cmbnewPurchPaySys.Text = "";
            cmbNPban.Text = "";
            txtNPbanQnt.Text = "";
            txtNPbanPrice.Text = "";
            txtNPbanVal.Text = "";
            cmbNPst.Text = "";
            txtNPstQnt.Text = "";
            txtNPstPrice.Text = "";
            txtNPstVal.Text = "";
            txtNPluvQnt.Text = "";
            txtNPluvPrice.Text = "";
            txtNPluvVal.Text = "";
            cmbNPcol.Text = "";
            txtNPcolQnt.Text = "";
            txtNPcolPrice.Text = "";
            txtNPcolVal.Text = "";
            txtNPoth.Text = "";
            txtNPothQnt.Text = "";
            txtNPothPrice.Text = "";
            txtNPothVal.Text = "";
            txtnewPurchCom.Text = "";
            txtNPothUn.Text = "";
        }
        //------------Ավելացնել, խմբագրել, հեռացնել
        private void btnAddban_Click(object sender, EventArgs e)
        {
            AddItemToPurchBan();
            AddItemToStockBan();
            FillGrid();
            BanClearText();
            GetItemId();
            GetDebtItemId();
        }
        public void AddItemToPurchBan()
        {
            if (txtNPcod.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը մուտքագրված չեն");
                return;
            }

            try
            {
                con.Open();

                DateTime date1 = dtpNO.Value.Date;

                // First insert command
                using (SqlCommand cmd1 = new SqlCommand("INSERT INTO TblPurchasing " +
                    "(Կոդ, Ամսաթիվ, Մատակարար, Կատեգորիա, Նյութ, [ՔՄ մուտք], [ՔՄ գին], [ՔՄ արժեք], [Կոճգամ մուտք], [Կոճգամ գին], [Կոճգամ արժեք], Վահանակ, [Վ մուտք], [Վ գին], [Վ արժեք], Ներկ, [Ներկ մուտք], [Ներկ գին], [Ներկ արժեք], Այլ, [Այլ մուտք], [Այլ գին], [Այլ արժեք], [Ընդ արժեք], Մեկնաբանություն) VALUES " +
                    "(@Column1, @Column2, @Column3, @Column5, @Column6, @Column7, @Column8, @Column9, @Column10, @Column11, @Column12, @Column13, @Column14, @Column15, @Column16, @Column17, @Column18, @Column19, @Column20, @Column21, @Column22, @Column23, @Column24, @Column25, @Column26)", con))
                {
                    cmd1.Parameters.AddWithValue("@Column1", txtNPcod.Text);
                    cmd1.Parameters.AddWithValue("@Column2", date1);
                    cmd1.Parameters.AddWithValue("@Column3", cmbnewPurchPur.Text);
                    cmd1.Parameters.AddWithValue("@Column5", cmbNPCatBan.Text);
                    cmd1.Parameters.AddWithValue("@Column6", cmbNPban.Text);
                    cmd1.Parameters.AddWithValue("@Column7", txtNPbanQnt.Text);
                    cmd1.Parameters.AddWithValue("@Column8", txtNPbanPrice.Text);
                    cmd1.Parameters.AddWithValue("@Column9", txtNPbanVal.Text);
                    cmd1.Parameters.AddWithValue("@Column10", txtNPluvQnt.Text);
                    cmd1.Parameters.AddWithValue("@Column11", txtNPluvPrice.Text);
                    cmd1.Parameters.AddWithValue("@Column12", txtNPluvVal.Text);
                    cmd1.Parameters.AddWithValue("@Column13", cmbNPst.Text);
                    cmd1.Parameters.AddWithValue("@Column14", txtNPstQnt.Text);
                    cmd1.Parameters.AddWithValue("@Column15", txtNPstPrice.Text);
                    cmd1.Parameters.AddWithValue("@Column16", txtNPstVal.Text);
                    cmd1.Parameters.AddWithValue("@Column17", cmbNPcol.Text);
                    cmd1.Parameters.AddWithValue("@Column18", txtNPcolQnt.Text);
                    cmd1.Parameters.AddWithValue("@Column19", txtNPcolPrice.Text);
                    cmd1.Parameters.AddWithValue("@Column20", txtNPcolVal.Text);
                    cmd1.Parameters.AddWithValue("@Column21", txtNPoth.Text);
                    cmd1.Parameters.AddWithValue("@Column22", txtNPothQnt.Text);
                    cmd1.Parameters.AddWithValue("@Column23", txtNPothPrice.Text);
                    cmd1.Parameters.AddWithValue("@Column24", txtNPothVal.Text);
                    cmd1.Parameters.AddWithValue("@Column25", txtNPTotVal.Text);
                    cmd1.Parameters.AddWithValue("@Column26", txtnewPurchCom.Text);

                    cmd1.ExecuteNonQuery();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        public void AddItemToStockBan()
        {
            if (txtNPcod.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը մուտքագրված չեն");
                return;
            }

            try
            {
                con.Open();

                DateTime date1 = dtpNO.Value.Date;

                // First insert command
                using (SqlCommand cmd1 = new SqlCommand("INSERT INTO TblStockFlow " +
                    "(Կոդ, Ամսաթիվ, Նյութ, [ՔՄ մուտք], [ՔՄ արժեք], [Կոճգամ մուտք], [Կոճգամ արժեք], Վահանակ, [Վ մուտք], [Վ արժեք], Ներկ, [Ներկ մուտք], [Ներկ արժեք], Այլ, [Այլ մուտք], [Այլ արժեք]) VALUES " +
                    "(@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9, @Column10, @Column11, @Column12, @Column13, @Column14, @Column15, @Column16)", con))
                {
                    cmd1.Parameters.AddWithValue("@Column1", txtNPcod.Text);
                    cmd1.Parameters.AddWithValue("@Column2", date1);
                    cmd1.Parameters.AddWithValue("@Column3", cmbNPban.Text);
                    cmd1.Parameters.AddWithValue("@Column4", txtNPbanQnt.Text);
                    cmd1.Parameters.AddWithValue("@Column5", txtNPbanVal.Text);
                    cmd1.Parameters.AddWithValue("@Column6", txtNPluvQnt.Text);
                    cmd1.Parameters.AddWithValue("@Column7", txtNPluvVal.Text);
                    cmd1.Parameters.AddWithValue("@Column8", cmbNPst.Text);
                    cmd1.Parameters.AddWithValue("@Column9", txtNPstQnt.Text);
                    cmd1.Parameters.AddWithValue("@Column10", txtNPstVal.Text);
                    cmd1.Parameters.AddWithValue("@Column11", cmbNPcol.Text);
                    cmd1.Parameters.AddWithValue("@Column12", txtNPcolQnt.Text);
                    cmd1.Parameters.AddWithValue("@Column13", txtNPcolVal.Text);
                    cmd1.Parameters.AddWithValue("@Column14", txtNPoth.Text);
                    cmd1.Parameters.AddWithValue("@Column15", txtNPothQnt.Text);
                    cmd1.Parameters.AddWithValue("@Column16", txtNPothVal.Text);

                    cmd1.ExecuteNonQuery();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        public void AddItemToPurchDepts()
        {
            if (cmbNPCatBan.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը մուտքագրված չեն");
                return;
            }

            try
            {
                con.Open();

                DateTime date1 = dtpNO.Value.Date;

                // First insert command
                using (SqlCommand cmd1 = new SqlCommand("INSERT INTO TblDebtsControl (hh, Գործողություն, [վ/ե], Ամսաթիվ, Կոդ, Մատակարար, Արժեք, ԱԱՀ, Ընդհանուր, Մեկնաբանություն)" +
                        "VALUES (@ColumnID, @Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9, @Column10)", con))

                {
                    cmd1.Parameters.AddWithValue("@Column1", txtNPid.Text);
                    cmd1.Parameters.AddWithValue("@Column2", txtAction.Text);
                    cmd1.Parameters.AddWithValue("@Column3", cmbnewPurchPaySys.Text);
                    cmd1.Parameters.AddWithValue("@Column4", date1);                   
                    cmd1.Parameters.AddWithValue("@Column5", txtNPcod.Text);
                    cmd1.Parameters.AddWithValue("@Column6", cmbnewPurchPur.Text);
                    cmd1.Parameters.AddWithValue("@Column7", txtNPTotVal.Text);
                    cmd1.Parameters.AddWithValue("@Column8", txtNPvalNds.Text);
                    cmd1.Parameters.AddWithValue("@Column9", txtNPvalTotal.Text);
                    cmd1.Parameters.AddWithValue("@Column10", txtNPothVal.Text);

                    cmd1.ExecuteNonQuery();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        private void dgvPurchasing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditgridviewItem(sender, e);
            btnAddban.Enabled = false;
        }
        int i;
        private void EditgridviewItem(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dgvPurchasing.Rows[i];
            txtNPcod.Text = row.Cells[0].Value.ToString();
            dtpNO.Text = row.Cells[1].Value.ToString();
            cmbnewPurchPur.Text = row.Cells[2].Value.ToString();
            cmbNPCatBan.Text = row.Cells[3].Value.ToString();
            txtnewPurchCom.Text = row.Cells[24].Value.ToString();
            PanelChange();
            cmbNPban.Text = row.Cells[4].Value.ToString();
            txtNPbanQnt.Text = row.Cells[5].Value.ToString();
            txtNPbanPrice.Text = row.Cells[6].Value.ToString();
            txtNPbanVal.Text = row.Cells[7].Value.ToString();
            txtNPluvQnt.Text = row.Cells[8].Value.ToString();
            txtNPluvPrice.Text = row.Cells[9].Value.ToString();
            txtNPluvVal.Text = row.Cells[10].Value.ToString();
            cmbNPst.Text = row.Cells[11].Value.ToString();
            txtNPstQnt.Text = row.Cells[12].Value.ToString();
            txtNPstPrice.Text = row.Cells[13].Value.ToString();
            txtNPstVal.Text = row.Cells[14].Value.ToString();
            cmbNPcol.Text = row.Cells[15].Value.ToString();
            txtNPcolQnt.Text = row.Cells[16].Value.ToString();
            txtNPcolPrice.Text = row.Cells[17].Value.ToString();
            txtNPcolVal.Text = row.Cells[18].Value.ToString();
            txtNPoth.Text = row.Cells[19].Value.ToString();
            txtNPothQnt.Text = row.Cells[20].Value.ToString();
            txtNPothPrice.Text = row.Cells[21].Value.ToString();
            txtNPothVal.Text = row.Cells[22].Value.ToString();
            TotValResolution();
        }
        private void btnEditban_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date1 = dtpNO.Value.Date;
                con.Open();
                cmd = new SqlCommand("UPDATE TblPurchasing SET Ամսաթիվ = @Column2, Մատակարար = @Column3, Կատեգորիա = @Column5, Նյութ = @Column6, [ՔՄ մուտք] = @Column7, [ՔՄ գին] = @Column8, [ՔՄ արժեք] = @Column9, [Կոճգամ մուտք] = @Column10, [Կոճգամ գին] = @Column11, [Կոճգամ արժեք] = @Column12, " +
                                     "Վահանակ = @Column13, [Վ մուտք] = @Column14, [Վ գին] = @Column15, [Վ արժեք] = @Column16, Ներկ = @Column17, [Ներկ մուտք] = @Column18, [Ներկ գին] = @Column19, [Ներկ արժեք] = @Column20, Այլ = @Column21, [Այլ մուտք] = @Column22, [Այլ գին] = @Column23, [Այլ արժեք] = @Column24, [Ընդ արժեք] = @Column25, Մեկնաբանություն = @Column26 WHERE Կոդ = @Column1", con);
                cmd.Parameters.AddWithValue("@Column1", txtNPcod.Text);
                cmd.Parameters.AddWithValue("@Column2", date1);
                cmd.Parameters.AddWithValue("@Column3", cmbnewPurchPur.Text);
                cmd.Parameters.AddWithValue("@Column5", cmbNPCatBan.Text);
                cmd.Parameters.AddWithValue("@Column6", cmbNPban.Text);
                cmd.Parameters.AddWithValue("@Column7", txtNPbanQnt.Text);
                cmd.Parameters.AddWithValue("@Column8", txtNPbanPrice.Text);
                cmd.Parameters.AddWithValue("@Column9", txtNPbanVal.Text);
                cmd.Parameters.AddWithValue("@Column10", txtNPluvQnt.Text);
                cmd.Parameters.AddWithValue("@Column11", txtNPluvPrice.Text);
                cmd.Parameters.AddWithValue("@Column12", txtNPluvVal.Text);
                cmd.Parameters.AddWithValue("@Column13", cmbNPst.Text);
                cmd.Parameters.AddWithValue("@Column14", txtNPstQnt.Text);
                cmd.Parameters.AddWithValue("@Column15", txtNPstPrice.Text);
                cmd.Parameters.AddWithValue("@Column16", txtNPstVal.Text);
                cmd.Parameters.AddWithValue("@Column17", cmbNPcol.Text);
                cmd.Parameters.AddWithValue("@Column18", txtNPcolQnt.Text);
                cmd.Parameters.AddWithValue("@Column19", txtNPcolPrice.Text);
                cmd.Parameters.AddWithValue("@Column20", txtNPcolVal.Text);
                cmd.Parameters.AddWithValue("@Column21", txtNPoth.Text);
                cmd.Parameters.AddWithValue("@Column22", txtNPothQnt.Text);
                cmd.Parameters.AddWithValue("@Column23", txtNPothPrice.Text);
                cmd.Parameters.AddWithValue("@Column24", txtNPothVal.Text);
                cmd.Parameters.AddWithValue("@Column25", txtNPTotVal.Text);
                cmd.Parameters.AddWithValue("@Column26", txtnewPurchCom.Text);
                
                cmd.ExecuteNonQuery();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Պատվերը թարմացվե՛ց:");
                }
                else
                {
                    MessageBox.Show("Խմբագրման համար ընտրե՛ք տող:");
                }
                EditStockFlow();
                EditPurchDepts();
                FillGrid();
                GetItemId();
                BanClearText();
                btnAddban.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (txtNPcod.Text == "")
            {
                MessageBox.Show("Բոլոր պարտադիր դաշտերը լրացված չեն:");
                return; // Exit the method if required fields are not filled
            }

            
        }
        private void EditStockFlow()
        {
            try
            {
                DateTime date1 = dtpNO.Value.Date;
                con.Open();
                SqlCommand cmd1 = new SqlCommand("UPDATE TblStockFlow SET Ամսաթիվ = @Column2, Նյութ = @Column3, [ՔՄ մուտք] = @Column4, [ՔՄ արժեք] = @Column5, [Կոճգամ մուտք] = @Column6, [Կոճգամ արժեք] = @Column7, " +
                                     "Վահանակ = @Column8, [Վ մուտք] = @Column9, [Վ արժեք] = @Column10, Ներկ = @Column11, [Ներկ մուտք] = @Column12, [Ներկ արժեք] = @Column13, Այլ = @Column14, [Այլ մուտք] = @Column15, [Այլ արժեք] = @Column16 WHERE Կոդ = @Column1", con);
                cmd1.Parameters.AddWithValue("@Column1", txtNPcod.Text);
                cmd1.Parameters.AddWithValue("@Column2", date1);
                cmd1.Parameters.AddWithValue("@Column3", cmbNPban.Text);
                cmd1.Parameters.AddWithValue("@Column4", txtNPbanQnt.Text);
                cmd1.Parameters.AddWithValue("@Column5", txtNPbanVal.Text);
                cmd1.Parameters.AddWithValue("@Column6", txtNPluvQnt.Text);
                cmd1.Parameters.AddWithValue("@Column7", txtNPluvVal.Text);
                cmd1.Parameters.AddWithValue("@Column8", cmbNPst.Text);
                cmd1.Parameters.AddWithValue("@Column9", txtNPstQnt.Text);
                cmd1.Parameters.AddWithValue("@Column10", txtNPstVal.Text);
                cmd1.Parameters.AddWithValue("@Column11", cmbNPcol.Text);
                cmd1.Parameters.AddWithValue("@Column12", txtNPcolQnt.Text);
                cmd1.Parameters.AddWithValue("@Column13", txtNPcolVal.Text);
                cmd1.Parameters.AddWithValue("@Column14", txtNPoth.Text);
                cmd1.Parameters.AddWithValue("@Column15", txtNPothQnt.Text);
                cmd1.Parameters.AddWithValue("@Column16", txtNPothVal.Text);

                cmd.ExecuteNonQuery();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void EditPurchDepts()
        {
            try
            {
                DateTime date1 = dtpNO.Value.Date;
                con.Open();
                SqlCommand cmd1 = new SqlCommand("UPDATE TblPurchForDebts SET Ամսաթիվ = @Column2, Մատակարար = @Column3, [ՔՄ արժեք] = @Column4, [Կոճգամ արժեք] = @Column5, [Վ արժեք] = @Column6, [Ներկ արժեք] = @Column7, [Այլ արժեք] = @Column8, [Ընդ արժեք] = @Column9 WHERE Կոդ = @Column1", con);
                cmd1.Parameters.AddWithValue("@Column1", txtNPcod.Text);
                cmd1.Parameters.AddWithValue("@Column2", date1);
                cmd1.Parameters.AddWithValue("@Column3", cmbnewPurchPur.Text);
                cmd1.Parameters.AddWithValue("@Column4", txtNPbanVal.Text);
                cmd1.Parameters.AddWithValue("@Column5", txtNPluvVal.Text);
                cmd1.Parameters.AddWithValue("@Column6", txtNPstVal.Text);
                cmd1.Parameters.AddWithValue("@Column7", txtNPcolVal.Text);
                cmd1.Parameters.AddWithValue("@Column8", txtNPothVal.Text);
                cmd1.Parameters.AddWithValue("@Column9", txtNPTotVal.Text);

                cmd.ExecuteNonQuery();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnDelban_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtNPcod.Text))
                {
                    if (MessageBox.Show("Ցանկանո՞ւմ եք հեռացնել պատվերը:", "Հեռացնել պատվերը", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        con.Open();

                        // Delete from TblStockFlow
                        SqlCommand cmd = new SqlCommand("DELETE FROM TblStockFlow WHERE Կոդ = @PurchId", con);
                        cmd.Parameters.AddWithValue("@PurchId", txtNPcod.Text);
                        int rowsAffectedOrders = cmd.ExecuteNonQuery();

                        // Delete from TblPurchasing
                        SqlCommand cmdForPurch = new SqlCommand("DELETE FROM TblPurchasing WHERE Կոդ = @PurchId", con);
                        cmdForPurch.Parameters.AddWithValue("@PurchId", txtNPcod.Text);
                        int rowsAffectedPurch = cmdForPurch.ExecuteNonQuery();

                        // Delete from TblDebts
                        SqlCommand cmdForDebts = new SqlCommand("DELETE FROM TblPurchForDebts WHERE Կոդ = @PurchId", con);
                        cmdForPurch.Parameters.AddWithValue("@PurchId", txtNPcod.Text);
                        int rowsAffectedDepts = cmdForDebts.ExecuteNonQuery();

                        con.Close();

                        if (rowsAffectedOrders > 0 && rowsAffectedPurch > 0 && rowsAffectedDepts > 0)
                        {
                            MessageBox.Show("Պատվերը հեռացվե՛ց");
                        }
                        else
                        {
                            MessageBox.Show("Հեռացման համար պատվեր չի ընտրվել:");
                        }

                        FillGrid();
                        GetItemId();
                        BanClearText();
                        btnAddban.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ընտրե՛ք տող ջնջելու համար:");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }

}
