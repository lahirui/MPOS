using MPOS.App_Context;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MPOS.Controllers
{
    public class ReportsController : Controller
    {
        private MPOSConStr db = new MPOSConStr();
        // GET: Reports
        public ActionResult ReportsHome()
        {
            return View();
        }

        public ActionResult EmployeeDetailedReport()
        {
            return View();
        }

        public ActionResult EmployeeSummaryReport()
        {
            return View();
        }
        public ActionResult SoldItemsDetails()
        {
            return View();
        }

        public ActionResult ItemTransactionSummary()
        {
            return View();
        }
    }
}