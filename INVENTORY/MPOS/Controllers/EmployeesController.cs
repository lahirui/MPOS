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
    public class EmployeesController : Controller
    {
        private MPOSConStr db = new MPOSConStr();
        private Common com = new Common();

        // GET: Employees
        public ActionResult Index()
        {
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            var employees = db.Employees.Include(e => e.Factory).Where(e => e.FactoryId == factoryId && e.IsActive==true).OrderBy(e => e.EPF);
            return View(employees.ToList());
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.FactoryId = new SelectList(db.Factories, "ID", "Code");
            return View();
        }

        public ActionResult EmployeeDeposit(long? id, decimal deposit)
        {
            try
            {
                DataSet dsbalance = new DataSet();
                dsbalance = com.ReturnDataSet("SELECT ISNULL(SUM(Amount),0) AS Amount FROM EmployeePayments WHERE EmployeeID=" + id + "");
                decimal balance = Convert.ToDecimal(dsbalance.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());
                DataSet dsMax = new DataSet();
                dsMax = com.ReturnDataSet("SELECT ParamValue FROM Configurations WHERE(ParamName = 'MaxPayment')");
                decimal maxVal = Convert.ToDecimal(dsMax.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());
                decimal totalBalance = deposit + balance;
                if (totalBalance <= maxVal)
                {
                    EmployeePayment employeePayment = new EmployeePayment();
                    Employee employee = new Employee();
                    //Add deposit to Employee Payment Table
                    employeePayment.EmployeeID = id;
                    employeePayment.Amount = deposit;
                    employeePayment.EffectiveDate = DateTime.Now;
                    db.EmployeePayments.Add(employeePayment);
                    db.SaveChanges();

                    //Update Employee Credit Balance
                    var EmployeeSum = db.EmployeePayments.Where(e => e.EmployeeID == id).Sum(e=>e.Amount);
                    var DepositEmployee = db.Employees.Where(e => e.ID == id).FirstOrDefault();
                    DepositEmployee.CreditBalance = EmployeeSum;
                    db.Entry(DepositEmployee).State = EntityState.Modified;
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    var message = "SAVED SUCCESSFULLY";
                    return Json(new { message = message }, JsonRequestBehavior.AllowGet);
                    //TempData["success"] = "SAVED SUCCESSFULLY";
                    //return RedirectToAction("Index");
                }
                else
                {
                    var message = "PAYMENT EXCEEDS THE ALLOWED MAX PAYMENT";
                    return Json(new { message = message }, JsonRequestBehavior.AllowGet);
                    //TempData["error"]= "PAYMENT EXCEEDS THE ALLOWED MAX PAYMENT";
                    //return RedirectToAction("Index");
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
                com.RollbackTrans();
                var message = ex.Message.ToString();
                //return Json(new { message = message }, JsonRequestBehavior.AllowGet);

            }

            return RedirectToAction("Index");
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HRID,EPF,FullName,CallingName,FactoryId,CreditBalance,IsActive,IsDeleted")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FactoryId = new SelectList(db.Factories, "ID", "Code", employee.FactoryId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.FactoryId = new SelectList(db.Factories, "ID", "Code", employee.FactoryId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HRID,EPF,FullName,CallingName,FactoryId,CreditBalance,IsActive,IsDeleted")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FactoryId = new SelectList(db.Factories, "ID", "Code", employee.FactoryId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}