using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Configuration;
//using System.Data.Entity.Core.EntityClient;
using MPOS.Reports.DataSets;

namespace MPOSReports
{
    
    public class ReportQueries
    {
        Common ComDB = new Common();
        public string ConStrForReports = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public void Access()
        {
            SqlConnection Con = ComDB.conSQL;
        }

        public PurchaseSummaryDS getPurchaseSummaryDetails(int FactoryID, string FromDate, string ToDate)
        {
            //if ((ConStrForReports.ToLower().StartsWith("metadata=")))
            //{
            //    EntityConnectionStringBuilder RefineConStr = new EntityConnectionStringBuilder(ConStrForReports);
            //    ConStrForReports = RefineConStr.ProviderConnectionString;

            //}
            string constra = ConStrForReports;

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT dbo.Employees.Department, dbo.Employees.EPF, dbo.Employees.FullName, SUM(dbo.EmployeePayments.Amount) * - 1 AS Amount " +
                                "FROM     dbo.Employees INNER JOIN " +
                                                  "dbo.EmployeePayments ON dbo.Employees.ID = dbo.EmployeePayments.EmployeeID " +
                                "WHERE (CAST(dbo.EmployeePayments.EffectiveDate AS DATE) >= '" + FromDate + "') AND(CAST(dbo.EmployeePayments.EffectiveDate AS DATE) <= '" + ToDate + "') AND(dbo.Employees.FactoryId = " + FactoryID + ") " +
                                "GROUP BY dbo.Employees.Department, dbo.Employees.EPF, dbo.Employees.FullName " +
                                "ORDER BY dbo.Employees.Department, dbo.Employees.EPF");
            using (SqlConnection SqlCon = new SqlConnection(constra))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter())
                {
                    cmd.Connection = SqlCon;
                    ad.SelectCommand = cmd;
                    using (PurchaseSummaryDS ServiceCost = new PurchaseSummaryDS())
                    {
                        ad.Fill(ServiceCost, "PurchaseSummaryDS");
                        return ServiceCost;
                    }
                }
            }
        }

        public ItemTransactionSummaryDS getItemTransactionSummaryDetails(int FactoryID, string FromDate, string ToDate)
        {
            //if ((ConStrForReports.ToLower().StartsWith("metadata=")))
            //{
            //    EntityConnectionStringBuilder RefineConStr = new EntityConnectionStringBuilder(ConStrForReports);
            //    ConStrForReports = RefineConStr.ProviderConnectionString;

            //}
            string constra = ConStrForReports;

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT dbo.Items.ItemName AS Item,dbo.ItemTransactions.TransactionTypeId AS TransactionType,SUM(dbo.ItemTransactions.Quantity) AS Quantity " +
                                    "FROM     dbo.Items INNER JOIN " +
                                                      "dbo.ItemTransactions ON dbo.Items.ID = dbo.ItemTransactions.ItemID " +
                                    "WHERE(CAST(dbo.ItemTransactions.EffectiveDate AS DATE) >= '" + FromDate + "')AND(CAST(dbo.ItemTransactions.EffectiveDate AS DATE) <= '" + ToDate + "') AND(dbo.Items.FactoryId = " + FactoryID + ") " +
                                    "GROUP BY  dbo.Items.ItemName, dbo.ItemTransactions.TransactionTypeId " +
                                    "ORDER BY  dbo.Items.ItemName, dbo.ItemTransactions.TransactionTypeId");

            using (SqlConnection SqlCon = new SqlConnection(constra))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter())
                {
                    cmd.Connection = SqlCon;
                    ad.SelectCommand = cmd;
                    using (ItemTransactionSummaryDS ServiceCost = new ItemTransactionSummaryDS())
                    {
                        ad.Fill(ServiceCost, "ItemTransactionSummaryDS");
                        return ServiceCost;
                    }
                }
            }
        }

        public PurchaseDetailsDS getPurchaseDetails(int EmployeeId, string FromDate, string ToDate)
        {
            //if ((ConStrForReports.ToLower().StartsWith("metadata=")))
            //{
            //    EntityConnectionStringBuilder RefineConStr = new EntityConnectionStringBuilder(ConStrForReports);
            //    ConStrForReports = RefineConStr.ProviderConnectionString;

            //}
            string constra = ConStrForReports;

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT (CAST(DATEADD(MINUTE,DATEDIFF(MINUTE,0,dbo.ItemPurchase.EffectiveDate),0)AS smalldatetime)) AS Date, dbo.Factories.Code AS Factory, dbo.Items.ItemName AS Item, dbo.ItemPurchase.UnitPrice, dbo.ItemPurchase.Quantity, " +
                                                  "(CASE WHEN dbo.ItemPurchase.UnitPrice>0 THEN dbo.ItemPurchase.UnitPrice * dbo.ItemPurchase.Quantity WHEN dbo.ItemPurchase.UnitPrice<0 THEN ((dbo.ItemPurchase.UnitPrice*-1) * dbo.ItemPurchase.Quantity) ELSE 0 END) AS ItemTotal " +
                                "FROM     dbo.ItemPurchase INNER JOIN " +
                                                  "dbo.Items ON dbo.ItemPurchase.ItemId = dbo.Items.ID INNER JOIN " +
                                                  "dbo.Factories ON dbo.ItemPurchase.FactoryId = dbo.Factories.ID " +
                                "WHERE(CAST(dbo.ItemPurchase.EffectiveDate AS DATE) >= '" + FromDate + "') AND(CAST(dbo.ItemPurchase.EffectiveDate AS DATE) <= '" + ToDate + "') AND(dbo.ItemPurchase.EmployeeId = " + EmployeeId + ") " +
                                "ORDER BY Date, Factory, Item");

            using (SqlConnection SqlCon = new SqlConnection(constra))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter())
                {
                    cmd.Connection = SqlCon;
                    ad.SelectCommand = cmd;
                    using (PurchaseDetailsDS ServiceCost = new PurchaseDetailsDS())
                    {
                        ad.Fill(ServiceCost, "PurchaseDetailsDS");
                        return ServiceCost;
                    }
                }
            }
        }

        public SoldItemsDetailsDS getSoldItemDetails(string FromDate, string ToDate, string FromItem, string ToItem, int FactoryId)
        {
            //if ((ConStrForReports.ToLower().StartsWith("metadata=")))
            //{
            //    EntityConnectionStringBuilder RefineConStr = new EntityConnectionStringBuilder(ConStrForReports);
            //    ConStrForReports = RefineConStr.ProviderConnectionString;

            //}
            string constra = ConStrForReports;

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT Items.ItemName, CONVERT(DECIMAL(10, 2), dbo.ItemPurchase.UnitPrice) AS UnitPrice, SUM(dbo.ItemPurchase.Quantity) AS Quantity " +
                                "FROM    dbo.ItemPurchase INNER JOIN " +
                                        "dbo.Items ON dbo.ItemPurchase.ItemId = dbo.Items.ID " +
                                "WHERE(CAST(dbo.ItemPurchase.EffectiveDate AS DATE) >= '" + FromDate + "') AND(CAST(dbo.ItemPurchase.EffectiveDate AS DATE) <= '" + ToDate + "') AND(dbo.Items.ItemName BETWEEN '0' AND 'zzzzzzzzz') " +
                                "AND(dbo.ItemPurchase.FactoryId = " + FactoryId + ") " +
                                "GROUP BY dbo.Items.ItemName, dbo.ItemPurchase.UnitPrice " +
                                "HAVING SUM(dbo.ItemPurchase.Quantity) <> 0 " +
                                "ORDER BY dbo.Items.ItemName, dbo.ItemPurchase.UnitPrice");

            using (SqlConnection SqlCon = new SqlConnection(constra))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter())
                {
                    cmd.Connection = SqlCon;
                    ad.SelectCommand = cmd;
                    using (SoldItemsDetailsDS ServiceCost = new SoldItemsDetailsDS())
                    {
                        ad.Fill(ServiceCost, "SoldItemsDetailsDS");
                        return ServiceCost;
                    }
                }
            }
        }
    }
}