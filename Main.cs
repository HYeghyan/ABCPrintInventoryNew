using ABCPrintInventory.Add;
using ABCPrintInventory.Create;
using ABCPrintInventory.Stock;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using LicenseContext = OfficeOpenXml.LicenseContext;
namespace ABCPrintInventory
{
    public partial class Main : Form
    {
        private Point _imageLocation = new Point(15, 6);
        private Point _imgHitArea = new Point(15, 6);
        Image closeR;

        public Main()
        {        
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += tabControl1_DrawItem;
            closeR = ABCPrintInventory.Properties.Resources.CloseB;
            tabControl1.Padding = new Point(10, 3);
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Image img = new Bitmap(closeR);
                Rectangle r = e.Bounds;
                r = this.tabControl1.GetTabRect(e.Index);
                r.Offset(2, 2);
                Brush TitleBrush = new SolidBrush(Color.Black);
                Font f = this.Font;
                string title = this.tabControl1.TabPages[e.Index].Text;

                e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));

                if (tabControl1.SelectedIndex >= 0)
                {
                    e.Graphics.DrawImage(img, new PointF(r.X + (this.tabControl1.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
                }
            }
            catch
            {

            }
        }
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            Point p = e.Location;

            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                r.Offset(r.Width - _imgHitArea.X, _imgHitArea.Y);
                r.Width = closeR.Width;
                r.Height = closeR.Height;

                if (r.Contains(p))
                {
                    tc.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateService createService = new CreateService();
            createService.MdiParent = this;
            TabPage newTabPage = new TabPage("Ծառայություն");
            newTabPage.Controls.Add(createService);

            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            createService.Show();
        }

        private void standToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateStand createStand = new CreateStand();
            createStand.MdiParent = this;
            TabPage newTabPage = new TabPage("Ցուցավահանակ");
            newTabPage.Controls.Add(createStand);

            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            createStand.Show();
        }
        private void ExArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateExpArticle createExpArticle = new CreateExpArticle();
            createExpArticle.MdiParent = this;
            TabPage newTabPage = new TabPage("Ծախսային հոդված");
            newTabPage.Controls.Add(createExpArticle);

            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            createExpArticle.Show();
        }

        private void matBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMaterialBan createMaterialBan = new CreateMaterialBan();
            createMaterialBan.MdiParent = this;
            TabPage newTabPage = new TabPage("Տպ. նյութ");
            newTabPage.Controls.Add(createMaterialBan);

            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            createMaterialBan.Show();
        }

        private void printerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePrinter createPrinter = new CreatePrinter();
            createPrinter.MdiParent = this;
            TabPage newTabPage = new TabPage("Տպ. մեքենա");
            newTabPage.Controls.Add(createPrinter);

            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            createPrinter.Show();
        }

        private void inkToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateInk createInk = new CreateInk();
            createInk.MdiParent = this;
            TabPage newTabPage = new TabPage("Ներկ");
            newTabPage.Controls.Add(createInk);

            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            createInk.Show();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.MdiParent = this;
            TabPage newTabPage = new TabPage("Հաճախորդ");
            newTabPage.Controls.Add(addClient);

            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            addClient.Show();
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            orders.MdiParent = this;
            TabPage newTabPage = new TabPage("Պատվերներ");
            newTabPage.Controls.Add(orders);

            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            orders.Show();
            //Orders existingOrders = Application.OpenForms.OfType<Orders>().FirstOrDefault();

            //if (existingOrders != null)
            //{
            //    // Focus on the existing instance of Orders form
            //    existingOrders.Focus();
            //}
            //else
            //{
            //    // Create a new instance of Orders form and add it to a new tab
            //    Orders orders = new Orders();
            //    orders.MdiParent = this;
            //    TabPage newTabPage = new TabPage("Պատվերներ");
            //    newTabPage.Controls.Add(orders);

            //    tabControl1.TabPages.Add(newTabPage);
            //    tabControl1.SelectedTab = newTabPage;
            //    orders.Show();
            //}
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test newtest = new Test();
            newtest.MdiParent = this;
            TabPage newTabPage = new TabPage("Test");
            newTabPage.Controls.Add(newtest);
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            newtest.Show();
        }

        private void deptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depts depts = new Depts();
            depts.MdiParent = this;
            TabPage newTabPage = new TabPage("Պարտքեր");
            newTabPage.Controls.Add(depts);

            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            depts.Show();
        }

        private void bannerStToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockFlow stockFlow = new StockFlow();
            stockFlow.MdiParent = this;
            TabPage newTabPage = new TabPage("Պաստառի պահեստ");
            newTabPage.Controls.Add(stockFlow);

            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            stockFlow.Show();
        }
    }
    
}
