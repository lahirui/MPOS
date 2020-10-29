using Microsoft.Reporting.WebForms;
using MPOS.Reports.DataSets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MPOSReports.WebForms
{
    public partial class SoldItemsDetails : System.Web.UI.Page
    {
        ReportQueries dbQuery = new ReportQueries();
        Common com = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                calToDate.Visible = false;
                calToDate.SelectedDate = DateTime.Now;
                txtToDate.Value = calToDate.SelectedDate.ToString("dd/MMM/yyyy");

                calFromDate.Visible = false;
                calFromDate.SelectedDate = DateTime.Now;
                txtFromDate.Value = calToDate.SelectedDate.ToString("dd/MMM/yyyy");

                //DataSet ds = new DataSet();
                //ds = com.ReturnDataSet("SELECT ID, ItemName FROM Items WHERE(IsDeleted = 0) ORDER BY ItemName");
                //ddlFromItem.DataSource = ds.Tables[0];
                //ddlFromItem.DataValueField = "ID";
                //ddlFromItem.DataTextField = "ItemName";
                //ddlFromItem.DataBind();

                //DataSet ds2 = new DataSet();
                //ds2 = com.ReturnDataSet("SELECT ID, ItemName FROM Items WHERE(IsDeleted = 0) ORDER BY ItemName");
                //ddltoItem.DataSource = ds2.Tables[0];
                //ddltoItem.DataValueField = "ID";
                //ddltoItem.DataTextField = "ItemName";
                //ddltoItem.DataBind();

                DataSet ds3 = new DataSet();
                ds3 = com.ReturnDataSet("SELECT ID, Code FROM Factories WHERE(IsDeleted = 0) ORDER BY Code");
                ddlFactory.DataSource = ds3.Tables[0];
                ddlFactory.DataValueField = "ID";
                ddlFactory.DataTextField = "Code";
                ddlFactory.DataBind();
                ddlFactory.Items.Insert(0, "--SELECT FACTORY--");
            }
        }

        protected void lbFromDate_Click(object sender, EventArgs e)
        {
            if (calFromDate.Visible)
            {
                calFromDate.Visible = false;
            }
            else
            {
                calFromDate.Visible = true;
            }
        }

        protected void calFromDate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.CompareTo(DateTime.Today) > 0)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void calFromDate_SelectionChanged(object sender, EventArgs e)
        {
            txtFromDate.Value = calFromDate.SelectedDate.ToString("dd/MMM/yyyy");
            calFromDate.Visible = false;
        }

        protected void lbToDate_Click(object sender, EventArgs e)
        {
            if (calToDate.Visible)
            {
                calToDate.Visible = false;
            }
            else
            {
                calToDate.Visible = true;
            }
        }

        protected void calToDate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.CompareTo(DateTime.Today) > 0)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void calToDate_SelectionChanged(object sender, EventArgs e)
        {
            txtToDate.Value = calToDate.SelectedDate.ToString("dd/MMM/yyyy");
            calToDate.Visible = false;
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            int factoryId = Convert.ToInt32(ddlFactory.SelectedValue);
            string FactoryName = ddlFactory.SelectedItem.Text;
            string fromItem = ddlFromItem.SelectedItem.Text;
            string toItem = ddltoItem.SelectedItem.Text;
            string FromDate = calFromDate.SelectedDate.ToString("dd-MMM-yyyy");
            string ToDate = calToDate.SelectedDate.ToString("dd-MMM-yyyy");
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/SoldItemsDetailsDS.rdlc");
            SoldItemsDetailsDS Services = dbQuery.getSoldItemDetails( FromDate, ToDate, fromItem, toItem, factoryId);
            ReportDataSource DTSource = new ReportDataSource("SoldItemsDetailsDS", Services.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(DTSource);

            ReportParameter fac = new ReportParameter("Factory", FactoryName);
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { fac });
            ReportParameter fromDate = new ReportParameter("FromDate", FromDate);
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { fromDate });
            ReportParameter toDate = new ReportParameter("ToDate", ToDate);
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { toDate });
        }

        protected void ddltoItem_DataBound(object sender, EventArgs e)
        {
            //DataSet ds2 = new DataSet();
            //ds2 = com.ReturnDataSet("SELECT ID, ItemName FROM Items WHERE(IsDeleted = 0) AND (FactoryId=" + ddlFactory.SelectedValue + ") ORDER BY ItemName");
            //ddltoItem.DataSource = ds2.Tables[0];
            //ddltoItem.DataValueField = "ID";
            //ddltoItem.DataTextField = "ItemName";
            //ddltoItem.DataBind();

            ddltoItem.SelectedIndex = ddlFromItem.Items.Count - 1;

            
        }

        protected void ddlFromItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataSet ds2 = new DataSet();
            //ds2 = com.ReturnDataSet("SELECT ID, ItemName FROM Items WHERE(IsDeleted = 0) AND (FactoryId=" + ddlFactory.SelectedValue + ") ORDER BY ItemName");
            //ddltoItem.DataSource = ds2.Tables[0];
            //ddltoItem.DataValueField = "ID";
            //ddltoItem.DataTextField = "ItemName";
            //ddltoItem.DataBind();

            ddltoItem.SelectedIndex = ddlFromItem.SelectedIndex;
        }

        protected void ddlFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlFromItem.Items.Clear();
            ddltoItem.Items.Clear();
            if (ddlFactory.SelectedIndex == 0)
            {
                ddlFromItem.Items.Clear();
                ddltoItem.Items.Clear();
            }
            else
            {
                ddlFromItem.Items.Clear();
                ddltoItem.Items.Clear();

                DataSet ds = new DataSet();
                ds = com.ReturnDataSet("SELECT ID, ItemName FROM Items WHERE(IsDeleted = 0) AND (FactoryId=" + ddlFactory.SelectedValue + ") ORDER BY ItemName");
                ddlFromItem.DataSource = ds.Tables[0];
                ddlFromItem.DataValueField = "ID";
                ddlFromItem.DataTextField = "ItemName";
                ddlFromItem.DataBind();

                DataSet ds2 = new DataSet();
                ds2 = com.ReturnDataSet("SELECT ID, ItemName FROM Items WHERE(IsDeleted = 0) AND (FactoryId=" + ddlFactory.SelectedValue + ") ORDER BY ItemName");
                ddltoItem.DataSource = ds2.Tables[0];
                ddltoItem.DataValueField = "ID";
                ddltoItem.DataTextField = "ItemName";
                ddltoItem.DataBind();
            }
            
        }
    }
}