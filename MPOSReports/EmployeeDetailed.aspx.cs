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
    public partial class EmployeeDetailed : System.Web.UI.Page
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

                DataSet ds = new DataSet();
                ds = com.ReturnDataSet("SELECT ID, EPF FROM Employees WHERE(IsActive = 1) AND(IsDeleted = 0) ORDER BY EPF");
                ddlEmployee.DataSource = ds.Tables[0];
                ddlEmployee.DataValueField = "ID";
                ddlEmployee.DataTextField = "EPF";
                ddlEmployee.DataBind();
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

            string EmployeeEPF = ddlEmployee.SelectedItem.Text;
            int EmployeeId = Convert.ToInt32(ddlEmployee.SelectedValue);
            string FromDate = calFromDate.SelectedDate.ToString("dd-MMM-yyyy");
            string ToDate = calToDate.SelectedDate.ToString("dd-MMM-yyyy");
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/PurchaseDetailsDS.rdlc");
            PurchaseDetailsDS Services = dbQuery.getPurchaseDetails(EmployeeId, FromDate, ToDate);
            ReportDataSource DTSource = new ReportDataSource("PurchaseDetailsDS", Services.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(DTSource);

            ReportParameter epf = new ReportParameter("EPF", EmployeeEPF);
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { epf });
            ReportParameter fromDate = new ReportParameter("FromDate", FromDate);
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { fromDate });
            ReportParameter toDate = new ReportParameter("ToDate", ToDate);
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { toDate });
        }
    }
}