using POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.PRL
{
    public partial class PurchaseScreen : Form
    {
        Common com = new Common();
        private System.Windows.Forms.Timer timer1;
        public PurchaseScreen()
        {
            InitializeComponent();
        }

        private void timerScreen_Tick(object sender, EventArgs e)
        {
            LoadPurchasedDetails();
            //this.gvScreen.AutoResizeColumns();
            //this.gvScreen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void PurchaseScreen_Load(object sender, EventArgs e)
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timerScreen_Tick);
            timer1.Interval = 3000; // in miliseconds
            timer1.Start();
            //    Timer timer = new Timer();
            //    timer.Interval = (2 * 1000); // 10 secs
            //    timer.Tick += new EventHandler(timerScreen_Tick);
            //    timer.Start();

            //    gvScreen.ColumnHeadersDefaultCellStyle.Font = new Font(gvScreen.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            //    this.gvScreen.AutoResizeColumns();
            //    this.gvScreen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //Thread thread = new Thread(() => { LoadPurchasedDetails(); });
            //thread.Start();
        }
        private void LoadPurchasedDetails()
        {
            DataSet dsScreen = new DataSet();
            dsScreen = com.ReturnDataSet("SELECT * FROM(SELECT TOP(15)(dbo.Employees.EPF + ' - ' + dbo.Employees.CallingName) AS Customer, dbo.Items.ItemName AS Item, dbo.ItemPurchase.UnitPrice, dbo.ItemPurchase.Quantity, " +
                        "CONVERT(DECIMAL(10,2),dbo.ItemPurchase.UnitPrice* dbo.ItemPurchase.Quantity) AS  Total, ROW_NUMBER() OVER(PARTITION BY dbo.Employees.EPF ORDER BY dbo.ItemPurchase.ID, dbo.Employees.EPF DESC)RN " +
                         "FROM     dbo.ItemPurchase INNER JOIN " +
                                          "dbo.Employees ON dbo.ItemPurchase.EmployeeId = dbo.Employees.ID INNER JOIN " +
                                          "dbo.Items ON dbo.ItemPurchase.ItemId = dbo.Items.ID " +
                        "WHERE (dbo.ItemPurchase.CashierId = " + Variables._CashierId + ") AND (CAST(dbo.ItemPurchase.EffectiveDate AS DATE)=(CAST(GETDATE() AS DATE))) " +
                        "ORDER BY dbo.ItemPurchase.ID DESC) t1 WHERE RN <= 30");
            gvScreen.DataSource = dsScreen.Tables[0];

            this.gvScreen.Columns["RN"].Visible = false;
            this.gvScreen.AutoResizeColumns();
            this.gvScreen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
