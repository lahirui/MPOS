using MPOS.App_Context;
using MPOS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace MPOS.Controllers
{
    public class ItemPurchasesController : Controller
    {
        private MPOSConStr db = new MPOSConStr();
        private Common com = new Common();
        private string constr = ConfigurationManager.ConnectionStrings["MPOSConStr"].ConnectionString;
        private static List<ItemsReadyToPurchase> purchaseItems = new List<ItemsReadyToPurchase>();

        public ActionResult MPOSSignIn()
        {
            var userId = Convert.ToInt32(Session["UserId"].ToString());
            purchaseItems.RemoveAll(x => x.UserId == userId);
            return RedirectToAction("SignIn", "Users", new { MPOSSignIn = 1 });
        }

        public ActionResult MPOS()
        {
            var userId = Convert.ToInt32(Session["UserId"].ToString());
            purchaseItems.RemoveAll(x => x.UserId == userId);
            Session["ItemId"] = 0;
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            ViewBag.Categories = db.ItemTypes.Where(i => i.FactoryID == factoryId && i.IsDeleted == false).ToList().OrderBy(i => i.ItemType1);
            return View();
        }

        [HttpGet]
        public JsonResult EmployeeDetails(string EmployeeEPF)
        {
            //string epf = string.Empty;
            //epf = epf + EmployeeEPF;

            //var SearchedEmployeeRecord = db.Employees.Where(e => e.EPF == epf && e.IsActive == true && e.IsDeleted == false).FirstOrDefault();

            if (EmployeeEPF.Length >= 8)
            {
                var SearchedEmployeeRecord = db.Employees.Where(e => e.EPF == EmployeeEPF && e.IsActive == true && e.IsDeleted == false).FirstOrDefault();

                if (SearchedEmployeeRecord != null)
                {
                    Session["EmployeeId"] = SearchedEmployeeRecord.ID;
                    Session["EmployeeExistingBalance"] = SearchedEmployeeRecord.CreditBalance;

                    int? ClassId = SearchedEmployeeRecord.ClassId;
                    var EmployeeClass = db.Classes.Where(c => c.ID == ClassId).FirstOrDefault();
                    Session["EmployeeMinValue"] = EmployeeClass.MinVal;
                    Session["EmployeeMaxValue"] = EmployeeClass.MaxVal;

                    string ParamValue = "0";
                    string commonThreshold = "CommonThreshold";
                    var confTbl = db.Configurations.Where(c => c.ParamName == commonThreshold).FirstOrDefault();
                    if (confTbl.ParamValue == "True")
                    {
                        string minPayment = "MinPayment";
                        var min = db.Configurations.Where(c => c.ParamName == minPayment).FirstOrDefault();
                        ParamValue = min.ParamValue;
                    }
                    else
                    {
                        ParamValue = Session["EmployeeMinValue"].ToString();
                    }
                    return Json(new { SearchedEmployeeRecord.FullName, SearchedEmployeeRecord.CreditBalance, SearchedEmployeeRecord.EPF, SearchedEmployeeRecord.ID, ParamValue }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { FullName = "NO EMPLOYEE", Balance = "000.00", EPF = "NO EMPLOYEE" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult _Items(int? id)
        {
            ViewBag.ItemsInCategories = db.Items.Where(i => i.ItemTypeId == id && i.DaySellingQty > 0 && i.IsDeleted == false).ToList().OrderBy(i => i.ItemName);
            return PartialView("_Items");
        }

        public ActionResult getItemId(int? id)
        {
            Session["ItemId"] = id;
            var itemId = id;
            return Json(new { itemId }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _getItemQtytoPurchase(decimal? itemQty, int? itemId, string employeeEpf)
        {
            //var ItemId = Convert.ToInt32(Session["ItemId"]);
            var currentEmpId = db.Employees.Where(e => e.EPF == employeeEpf).FirstOrDefault();

            var ItemId = itemId;
            var Items = db.Items.Where(i => i.ID == ItemId).ToList();
            var SelectedItem = Items.FirstOrDefault();
            var empId = Convert.ToInt32(Session["EmployeeId"].ToString());
            int userId = Convert.ToInt32(Session["UserId"].ToString());
            var containsItem = purchaseItems.Where(p => p.ItemId == ItemId && p.EmployeeID == empId);

            bool duplicateItems = Convert.ToBoolean(0);
            if (purchaseItems.Contains(containsItem.FirstOrDefault()))
            {
                duplicateItems = Convert.ToBoolean(1);
            }
            decimal? SelectedItemPrice = (SelectedItem.UnitPrice * itemQty);
            decimal? TotalofAlreadySelectedItems = purchaseItems.Sum(p => p.ItemTotal);
            decimal? EmployeeBalance = Convert.ToDecimal(Session["EmployeeExistingBalance"].ToString());
            decimal? PossibleBalanceAfterPurchase = (EmployeeBalance - (TotalofAlreadySelectedItems + SelectedItemPrice));

            string ParamValue = "0";
            string commonThreshold = "CommonThreshold";
            var confTbl = db.Configurations.Where(c => c.ParamName == commonThreshold).FirstOrDefault();
            if (confTbl.ParamValue == "True")
            {
                string minPaymentPara = "MinPayment";
                var minPay = db.Configurations.Where(c => c.ParamName == minPaymentPara).FirstOrDefault();
                ParamValue = minPay.ParamValue;
            }
            else
            {
                ParamValue = Session["EmployeeMinValue"].ToString();
            }

            if (PossibleBalanceAfterPurchase >= Convert.ToDecimal(ParamValue))
            {
                if (duplicateItems == Convert.ToBoolean(0))
                {
                    if (SelectedItem.DaySellingQty >= itemQty)
                    {
                        if (currentEmpId.ID == empId)
                        {
                            foreach (var item in Items)
                            {
                                purchaseItems.Add(new ItemsReadyToPurchase() { ItemId = item.ID, UserId = userId, ItemName = item.ItemName, ItemQty = itemQty, UnitPrice = item.UnitPrice, ItemTotal = itemQty * item.UnitPrice, EmployeeID = Convert.ToInt32(Session["EmployeeId"].ToString()) });
                            }
                            ViewBag.OrderPrice = purchaseItems.Sum(p => p.ItemTotal);
                            ViewBag.SelectedItems = purchaseItems.Where(e => e.EmployeeID == empId);
                            decimal existingBalance = Convert.ToDecimal(Session["EmployeeExistingBalance"].ToString());
                            Session["ItemId"] = "";
                            Session["OrderPrice"] = purchaseItems.Where(p => p.EmployeeID == empId).Sum(p => p.ItemTotal);
                            decimal OrderPrice = Convert.ToDecimal(Session["OrderPrice"].ToString());
                            Session["EmployeeBalance"] = existingBalance - OrderPrice;
                            string minPayment = "MinPayment";
                            var min = db.Configurations.Where(c => c.ParamName == minPayment).FirstOrDefault();
                            return PartialView("_getItemQtytoPurchase", ViewBag.SelectedItems);
                        }
                        else
                        {
                            TempData["NoBalance"] = "EMPLOYEE SELECTION FAILED";
                            ViewBag.SelectedItems = purchaseItems;
                            return PartialView("_getItemQtytoPurchase", ViewBag.SelectedItems);
                        }
                    }
                    else
                    {
                        TempData["NoItems"] = "NOT ENOUGH " + SelectedItem.ItemName + " FOR SALE";
                        Session["OrderPrice"] = purchaseItems.Where(p => p.EmployeeID == empId).Sum(p => p.ItemTotal);
                        decimal existingBalance = Convert.ToDecimal(Session["EmployeeExistingBalance"].ToString());
                        decimal OrderPrice = Convert.ToDecimal(Session["OrderPrice"].ToString());
                        Session["EmployeeBalance"] = existingBalance - OrderPrice;
                        ViewBag.SelectedItems = purchaseItems;
                        return PartialView("_getItemQtytoPurchase", ViewBag.SelectedItems);
                    }
                }
                else
                {
                    TempData["AlreadySelected"] = SelectedItem.ItemName + " ALREADY SELECTED";
                    ViewBag.SelectedItems = purchaseItems;
                    return PartialView("_getItemQtytoPurchase", ViewBag.SelectedItems);
                }
            }
            else
            {
                TempData["NoBalance"] = "BALANCE NOT ENOUGH TO PURCHASE THE ITEM";
                ViewBag.SelectedItems = purchaseItems;
                return PartialView("_getItemQtytoPurchase", ViewBag.SelectedItems);
            }
        }

        public ActionResult RemoveSeletedItem(int id)
        {
            var empId = Convert.ToInt32(Session["EmployeeId"].ToString());
            //var indexNo = purchaseItems.FindIndex(l => l.ItemId == id && l.EmployeeID==empId);
            var indexNo = purchaseItems.Where(l => l.ItemId == id && l.EmployeeID == empId).FirstOrDefault();
            purchaseItems.Remove(indexNo);

            decimal? newPrice = purchaseItems.Where(p => p.EmployeeID == empId).Sum(p => p.ItemTotal);
            decimal? existingBalance = Convert.ToDecimal(Session["EmployeeExistingBalance"].ToString());
            decimal? newBalance = existingBalance - newPrice;
            return Json(new { newPrice, newBalance }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SavePurchasedItems()
        {
            ItemPurchase itemPurchase = new ItemPurchase();
            ItemTransaction itemTransaction = new ItemTransaction();
            EmployeePayment employeePayment = new EmployeePayment();

            int employeeId = Convert.ToInt32(Session["EmployeeId"].ToString());
            var employeeBalance = db.Employees.Where(e => e.ID == employeeId).FirstOrDefault();
            decimal? OrderAmount = purchaseItems.Sum(i => (i.UnitPrice * i.ItemQty));
            decimal? EmployeeBalanceAfterPurchase = (employeeBalance.CreditBalance - OrderAmount);

            string ParamValue = "0";
            string commonThreshold = "CommonThreshold";
            var confTbl = db.Configurations.Where(c => c.ParamName == commonThreshold).FirstOrDefault();
            if (confTbl.ParamValue == "True")
            {
                string minPayment = "MinPayment";
                var min = db.Configurations.Where(c => c.ParamName == minPayment).FirstOrDefault();
                ParamValue = min.ParamValue;
            }
            else
            {
                ParamValue = Session["EmployeeMinValue"].ToString();
            }

            if (EmployeeBalanceAfterPurchase > Convert.ToDecimal(ParamValue))
            {
                foreach (var ItemsSelectedToPurchase in purchaseItems)
                {
                    var itemBalance = db.Items.Where(i => i.ID == ItemsSelectedToPurchase.ItemId).FirstOrDefault();
                    var selectedItemQty = purchaseItems.Where(i => i.ItemId == ItemsSelectedToPurchase.ItemId).Sum(i => i.ItemQty);

                    if (itemBalance.DaySellingQty >= selectedItemQty)
                    {
                        // Add record to Item Purchase Table
                        itemPurchase.EffectiveDate = DateTime.Now;
                        itemPurchase.EmployeeId = employeeId;
                        itemPurchase.ItemId = ItemsSelectedToPurchase.ItemId;
                        itemPurchase.UnitPrice = ItemsSelectedToPurchase.UnitPrice;
                        itemPurchase.Quantity = ItemsSelectedToPurchase.ItemQty;
                        itemPurchase.FactoryId = Convert.ToInt32(Session["factoryId"].ToString());
                        itemPurchase.CashierId = Convert.ToInt32(Session["UserId"].ToString());
                        db.ItemPurchases.Add(itemPurchase);
                        db.SaveChanges();

                        // Add records to Item Transaction Table
                        itemTransaction.ItemID = ItemsSelectedToPurchase.ItemId;
                        itemTransaction.Quantity = ((ItemsSelectedToPurchase.ItemQty) * -1);
                        itemTransaction.TransactionTypeId = 2;
                        itemTransaction.EffectiveDate = DateTime.Now;
                        db.ItemTransactions.Add(itemTransaction);
                        db.SaveChanges();

                        //Add Records to Employee Payment Table
                        employeePayment.EmployeeID = employeeId;
                        employeePayment.EffectiveDate = DateTime.Now;
                        employeePayment.Amount = ((ItemsSelectedToPurchase.UnitPrice * ItemsSelectedToPurchase.ItemQty) * -1);
                        db.EmployeePayments.Add(employeePayment);
                        db.SaveChanges();

                        //Update Day Selling Quantity in Items Table
                        var changedRec = db.Items.Where(i => i.ID == ItemsSelectedToPurchase.ItemId).FirstOrDefault();
                        changedRec.DaySellingQty = changedRec.DaySellingQty - ItemsSelectedToPurchase.ItemQty;
                        db.Entry(changedRec).State = EntityState.Modified;
                        db.SaveChanges();

                        //Reduce Balance from Employee Table
                        var reduceEmployeeBalance = db.Employees.Where(e => e.ID == employeeId).FirstOrDefault();
                        reduceEmployeeBalance.CreditBalance = reduceEmployeeBalance.CreditBalance - ((ItemsSelectedToPurchase.UnitPrice * ItemsSelectedToPurchase.ItemQty));
                        db.Entry(reduceEmployeeBalance).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        var userId = Convert.ToInt32(Session["UserId"].ToString());
                        var items = purchaseItems.Where(e => e.EmployeeID == userId).ToList();
                        items.Clear();
                        TempData["NoItems"] = "NOT ENOUGH " + ItemsSelectedToPurchase.ItemName + " FOR SALE";
                        Session["OrderPrice"] = purchaseItems.Where(p => p.EmployeeID == userId).Sum(p => p.ItemTotal);
                        decimal existingBalance = Convert.ToDecimal(Session["EmployeeExistingBalance"].ToString());
                        decimal OrderPrice = Convert.ToDecimal(Session["OrderPrice"].ToString());
                        Session["EmployeeBalance"] = existingBalance - OrderPrice;
                        ViewBag.SelectedItems = purchaseItems;
                        return PartialView("_getItemQtytoPurchase", ViewBag.SelectedItems);
                    }
                }
                purchaseItems.Clear();
                return RedirectToAction("MPOS");
            }
            else
            {
                purchaseItems.Clear();
                TempData["NoBalance"] = "BALANCE NOT ENOUGH TO PURCHASE THE ITEM";
                ViewBag.SelectedItems = purchaseItems;
                return PartialView("_getItemQtytoPurchase", ViewBag.SelectedItems);
            }
        }

        public ActionResult RefreshPOS()
        {
            var userId = Convert.ToInt32(Session["UserId"].ToString());
            purchaseItems.RemoveAll(x => x.UserId == userId);
            return RedirectToAction("MPOS");
        }

        public ActionResult DistributorScreen()
        {
            int userId = Convert.ToInt32(Session["UserId"].ToString());
            if (constr.ToLower().StartsWith("metadata="))
            {
                EntityConnectionStringBuilder RefineConStr = new EntityConnectionStringBuilder(constr);
                constr = RefineConStr.ProviderConnectionString;
            }
            String sql = "SELECT * FROM (SELECT TOP (10) (dbo.Employees.EPF +' - '+dbo.Employees.CallingName) AS Customer, dbo.Items.ItemName AS Item, dbo.ItemPurchase.UnitPrice, dbo.ItemPurchase.Quantity, " +
                        "dbo.ItemPurchase.UnitPrice* dbo.ItemPurchase.Quantity AS  Total, ROW_NUMBER() OVER(PARTITION BY dbo.Employees.EPF ORDER BY dbo.ItemPurchase.ID, dbo.Employees.EPF DESC)RN " +
                         "FROM     dbo.ItemPurchase INNER JOIN " +
                                          "dbo.Employees ON dbo.ItemPurchase.EmployeeId = dbo.Employees.ID INNER JOIN " +
                                          "dbo.Items ON dbo.ItemPurchase.ItemId = dbo.Items.ID " +
                        "WHERE (dbo.ItemPurchase.CashierId = " + userId + ") " +
                        "ORDER BY dbo.ItemPurchase.ID DESC) t1 WHERE RN <= 20";

            var model = new List<CustomerDashboard>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var dashboard = new CustomerDashboard();
                    dashboard.Customer = dr["Customer"].ToString();
                    dashboard.Item = dr["Item"].ToString();
                    dashboard.UnitPrice = dr["UnitPrice"].ToString();
                    dashboard.Quantity = dr["Quantity"].ToString();
                    dashboard.Total = dr["Total"].ToString();

                    model.Add(dashboard);
                }
            }
            return View(model);
        }

        public ActionResult Image(int? id)
        {
            try
            {
                var fctiD = db.Employees.Where(e => e.ID == id).Select(i => i.FactoryId).FirstOrDefault();
                if (fctiD == 1)
                {
                    string imageEmp = db.Employees.Where(e => e.ID == id).Select(i => i.EPF).FirstOrDefault();
                    var path = $@"E:\HRMS\Katunayake\{imageEmp}.JPG";
                    var bytes = System.IO.File.ReadAllBytes(path);
                    return File(bytes, "image/jpg");
                }
                else if (fctiD == 2)
                {
                    int imageEmp = Convert.ToInt32(db.Employees.Where(e => e.ID == id).Select(i => i.EPFNumber).FirstOrDefault());
                    var path = $@"E:\HRMS\Wathupitiwala\{imageEmp}.JPG";
                    var bytes = System.IO.File.ReadAllBytes(path);
                    return File(bytes, "image/jpg");
                }
                else if (fctiD == 3)
                {
                    int imageEmp = Convert.ToInt32(db.Employees.Where(e => e.ID == id).Select(i => i.EPFNumber).FirstOrDefault());
                    var path = $@"E:\HRMS\Malwatta\{imageEmp}.JPG";
                    var bytes = System.IO.File.ReadAllBytes(path);
                    return File(bytes, "image/jpg");
                }
                else if (fctiD == 4)
                {
                    int imageEmp = Convert.ToInt32(db.Employees.Where(e => e.ID == id).Select(i => i.EPFNumber).FirstOrDefault());
                    var path = $@"E:\HRMS\Kantale\{imageEmp}.JPG";
                    var bytes = System.IO.File.ReadAllBytes(path);
                    return File(bytes, "image/jpg");
                }
                else if (fctiD == 5)
                {
                    int imageEmp = Convert.ToInt32(db.Employees.Where(e => e.ID == id).Select(i => i.EPFNumber).FirstOrDefault());
                    var path = $@"E:\HRMS\Galagedara\{imageEmp}.JPG";
                    var bytes = System.IO.File.ReadAllBytes(path);
                    return File(bytes, "image/jpg");
                }
                else if (fctiD == 6)
                {
                    int imageEmp = Convert.ToInt32(db.Employees.Where(e => e.ID == id && e.IsActive == true && e.IsDeleted == false).Select(i => i.EPFNumber).FirstOrDefault());
                    var path = $@"E:\HRMS\Dambulla\{imageEmp}.JPG";
                    var bytes = System.IO.File.ReadAllBytes(path);
                    return File(bytes, "image/jpg");
                }
                else
                {
                    string path = "~/Assest/images/user/avatar-5.jpg";
                    var bytes = System.IO.File.ReadAllBytes(path);
                    return File(bytes, "image/jpg");
                }
            }
            catch (System.Exception)
            {
                string path = "~/Assest/images/user/avatar-5.jpg";
                return File(path, "image/jpg");
            }
        }
    }
}