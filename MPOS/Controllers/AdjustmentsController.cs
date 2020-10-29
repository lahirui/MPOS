using MPOS.App_Context;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MPOS.Controllers
{
    public class AdjustmentsController : Controller
    {
        private MPOSConStr db = new MPOSConStr();
        private string ZeroAddedMonth;
        private string ZeroAddedFirstDate;
        private string success;
        private string error;

        // GET: Adjustments
        [HttpGet]
        public ActionResult AdjustRecords()
        {
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            ViewBag.EmployeeId = new SelectList(db.Employees.Where(m => m.IsDeleted == false && m.FactoryId == factoryId).OrderBy(m => m.EPF), "ID", "EPF");
            var Year = DateTime.Now.Year;
            var Month = DateTime.Now.Month;
            var FirstDay = 1;
            var LastDay = DateTime.DaysInMonth(Year, Month);

            if (Month < 10)
            {
                ZeroAddedMonth = Month.ToString("D2");
            }
            ZeroAddedFirstDate = FirstDay.ToString("D2");
            ViewBag.Min = Year + "-" + ZeroAddedMonth + "-" + ZeroAddedFirstDate;
            ViewBag.Max = Year + "-" + ZeroAddedMonth + "-" + LastDay;
            return View();
        }

        public ActionResult GetEmployeeItemsForTheDay(string date, int EmpId)
        {
            DateTime? EffDate = Convert.ToDateTime(date);
            var EmpName = db.Employees.Where(e => e.ID == EmpId).FirstOrDefault();
            //return Json(db.ItemPurchases.Where(i =>DbFunctions.TruncateTime(i.EffectiveDate)== DbFunctions.TruncateTime(EffDate) && i.EmployeeId == EmpId).Select(f => new
            //{
            //    ID = f.ItemId,
            //    Item = f.Item.ItemName
            //}).ToList().OrderBy(f=>f.Item), JsonRequestBehavior.AllowGet);
            return Json(db.ItemPurchases.Where(i => DbFunctions.TruncateTime(i.EffectiveDate) == DbFunctions.TruncateTime(EffDate) && i.EmployeeId == EmpId).Select(f => new
            {
                ID = f.ItemId,
                Item = f.Item.ItemName
            }).GroupBy(f => f.Item).Select(g => g.FirstOrDefault()).ToList().OrderBy(f => f.Item), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetItemQuantity(string date, int EmpId, int ItemId)
        {
            DateTime? EffDate = Convert.ToDateTime(date);
            var Qty = db.ItemPurchases.Where(i => DbFunctions.TruncateTime(i.EffectiveDate) == DbFunctions.TruncateTime(EffDate) && i.EmployeeId == EmpId && i.ItemId == ItemId).Sum(i => i.Quantity);
            //var ItemQty = Qty.Quantity;
            var ItemQty = Qty;
            return Json(new { ItemQty }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EmployeeRecAdjustment(string date, int EmpId, int ItemId, decimal OldQty, decimal NewQty, string Remarks)
        {
            EmployeeAdjustment employeeAdjustment = new EmployeeAdjustment();
            DateTime? EffDate = Convert.ToDateTime(date);
            var RecordInItemPurchase = db.ItemPurchases.Where(i => DbFunctions.TruncateTime(i.EffectiveDate) == DbFunctions.TruncateTime(EffDate) && i.EmployeeId == EmpId && i.ItemId == ItemId).FirstOrDefault();
            int CurrentDate = DateTime.Now.Day;
            DateTime UserInputDate = Convert.ToDateTime(date);
            int EffectiveDate = UserInputDate.Day;
            if (CurrentDate == EffectiveDate)
            {
                employeeAdjustment.EmployeeId = EmpId;
                employeeAdjustment.ItemId = ItemId;
                employeeAdjustment.CashierId = RecordInItemPurchase.CashierId;
                employeeAdjustment.EnteredUserId = Convert.ToInt32(Session["UserId"].ToString());
                employeeAdjustment.TransactionTypeId = 4;
                employeeAdjustment.FactoryId = RecordInItemPurchase.FactoryId;
                employeeAdjustment.UnitPrice = RecordInItemPurchase.UnitPrice;
                employeeAdjustment.Quantity = NewQty;
                employeeAdjustment.EffectiveDate = EffDate;
                employeeAdjustment.EnteredDate = DateTime.Now;
                employeeAdjustment.Remarks = Remarks;
                db.EmployeeAdjustments.Add(employeeAdjustment);
                db.SaveChanges();

                EmployeePayment employeePayment = new EmployeePayment(); //Add a plus value for EmployeeID & Effective Date
                employeePayment.EmployeeID = EmpId;
                employeePayment.EffectiveDate = EffDate;
                employeePayment.Amount = (RecordInItemPurchase.UnitPrice * (NewQty * -1));
                db.EmployeePayments.Add(employeePayment);
                db.SaveChanges();

                ItemPurchase itemPurchase = new ItemPurchase();//Add minues value for Unit Price & Quantity for EmpId & EffDate
                itemPurchase.EffectiveDate = EffDate;
                itemPurchase.EmployeeId = EmpId;
                itemPurchase.ItemId = ItemId;
                itemPurchase.UnitPrice = (RecordInItemPurchase.UnitPrice * -1);
                itemPurchase.Quantity = NewQty;
                itemPurchase.FactoryId = RecordInItemPurchase.FactoryId;
                itemPurchase.CashierId = RecordInItemPurchase.CashierId;
                db.ItemPurchases.Add(itemPurchase);
                db.SaveChanges();

                ItemTransaction itemTransaction1 = new ItemTransaction(); //If same date No plus value for transaction type 3, Add plus value for Trans Type 2
                itemTransaction1.ItemID = ItemId;
                itemTransaction1.Quantity = (NewQty * -1);
                itemTransaction1.TransactionTypeId = 2;
                itemTransaction1.EffectiveDate = EffDate;
                db.ItemTransactions.Add(itemTransaction1);
                db.SaveChanges();

                var EmployeeDetails = db.Employees.Where(e => e.ID == EmpId).FirstOrDefault();//Reduce Credit Balance
                EmployeeDetails.CreditBalance = (EmployeeDetails.CreditBalance + ((RecordInItemPurchase.UnitPrice * -1) * NewQty));
                db.Entry(EmployeeDetails).State = EntityState.Modified;
                db.SaveChanges();

                var daySesslingQty = db.Items.Where(i => i.ID == ItemId).FirstOrDefault();
                decimal ReduceQty = (OldQty + NewQty);//If same date reduce Item Day Selling qty
                daySesslingQty.DaySellingQty = daySesslingQty.DaySellingQty + ReduceQty;
                db.Entry(daySesslingQty).State = EntityState.Modified;
                db.SaveChanges();

                success = "Adjustment Entered Succfully.";
            }
            else if (CurrentDate > EffectiveDate)
            {
                employeeAdjustment.EmployeeId = EmpId;
                employeeAdjustment.ItemId = ItemId;
                employeeAdjustment.CashierId = RecordInItemPurchase.CashierId;
                employeeAdjustment.EnteredUserId = Convert.ToInt32(Session["UserId"].ToString());
                employeeAdjustment.TransactionTypeId = 5;
                employeeAdjustment.FactoryId = RecordInItemPurchase.FactoryId;
                employeeAdjustment.UnitPrice = RecordInItemPurchase.UnitPrice;
                employeeAdjustment.Quantity = NewQty;
                employeeAdjustment.EffectiveDate = EffDate;
                employeeAdjustment.EnteredDate = DateTime.Now;
                employeeAdjustment.Remarks = Remarks;
                db.EmployeeAdjustments.Add(employeeAdjustment);
                db.SaveChanges();
                //employeeAdjustment.EmployeeId = EmpId;
                //employeeAdjustment.ItemId = ItemId;
                //employeeAdjustment.CashierId = RecordInItemPurchase.CashierId;
                //employeeAdjustment.EnteredUserId = Convert.ToInt32(Session["UserId"].ToString());
                //employeeAdjustment.TransactionTypeId = 3;
                //employeeAdjustment.FactoryId = RecordInItemPurchase.FactoryId;
                //employeeAdjustment.UnitPrice = RecordInItemPurchase.UnitPrice;
                //employeeAdjustment.Quantity = NewQty;
                //employeeAdjustment.EffectiveDate = EffDate;
                //employeeAdjustment.EnteredDate = DateTime.Now;
                //employeeAdjustment.Remarks = Remarks;
                //db.EmployeeAdjustments.Add(employeeAdjustment);
                //db.SaveChanges();

                EmployeePayment employeePayment = new EmployeePayment();
                employeePayment.EmployeeID = EmpId;
                employeePayment.EffectiveDate = EffDate;
                employeePayment.Amount = (RecordInItemPurchase.UnitPrice * (NewQty * -1));
                db.EmployeePayments.Add(employeePayment);
                db.SaveChanges();

                ItemPurchase itemPurchase = new ItemPurchase();
                itemPurchase.EffectiveDate = EffDate;
                itemPurchase.EmployeeId = EmpId;
                itemPurchase.ItemId = ItemId;
                itemPurchase.UnitPrice = (RecordInItemPurchase.UnitPrice * -1);
                itemPurchase.Quantity = NewQty;
                itemPurchase.FactoryId = RecordInItemPurchase.FactoryId;
                itemPurchase.CashierId = RecordInItemPurchase.CashierId;
                db.ItemPurchases.Add(itemPurchase);
                db.SaveChanges();

                ItemTransaction itemTransaction1 = new ItemTransaction();//If any other day- add plus value to transTyoe 2 and minus value to trans Type 3
                itemTransaction1.ItemID = ItemId;
                itemTransaction1.Quantity = (NewQty * -1);
                itemTransaction1.TransactionTypeId = 2;
                itemTransaction1.EffectiveDate = EffDate;
                db.ItemTransactions.Add(itemTransaction1);
                db.SaveChanges();

                ItemTransaction itemTransaction2 = new ItemTransaction();
                itemTransaction2.ItemID = ItemId;
                itemTransaction2.Quantity = NewQty;
                itemTransaction2.TransactionTypeId = 3;
                itemTransaction2.EffectiveDate = EffDate;
                db.ItemTransactions.Add(itemTransaction2);
                db.SaveChanges();

                var EmployeeDetails = db.Employees.Where(e => e.ID == EmpId).FirstOrDefault();
                EmployeeDetails.CreditBalance = (EmployeeDetails.CreditBalance + ((RecordInItemPurchase.UnitPrice * -1) * NewQty));
                db.Entry(EmployeeDetails).State = EntityState.Modified;
                db.SaveChanges();

                success = "Adjustment Entered Succfully.";
            }
            else
            {
                error = "Error in Adjustment Entering. Please Start Again";
            }

            return Json(new { error, success }, JsonRequestBehavior.AllowGet);
        }
    }
}