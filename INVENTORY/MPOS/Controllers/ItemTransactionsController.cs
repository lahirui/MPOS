using MPOS.App_Context;
using MPOS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MPOS.Controllers
{
    public class ItemTransactionsController : Controller
    {
        private MPOSConStr db = new MPOSConStr();
        private static List<ModelReplenishments> AddedReplenishments = new List<ModelReplenishments>();

        // GET: ItemTransactions
        public ActionResult Index()
        {
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            var itemTransactions = db.ItemTransactions.Include(i => i.Item).Include(i => i.TransactionType);
            return View(itemTransactions.ToList());
        }

        public ActionResult Replenishments()
        {
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            ViewBag.ItemID = new SelectList(db.Items.Where(i => i.FactoryId == factoryId && i.IsDeleted == false).OrderBy(i => i.ItemName), "ID", "ItemName");
            ViewBag.SelectedItems = "";
            List<ModelReplenishments> Repel = new List<ModelReplenishments>();
            //Repel.Clear();
            //AddedReplenishments.Clear();
            Repel.RemoveAll(f => f.FactoryId == factoryId);
            AddedReplenishments.RemoveAll(f => f.FactoryId == factoryId);
            return View(Repel.ToList());
        }

        public ActionResult _SelectedToSell(int? id, decimal? itemQty)
        {
            var factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            var Items = db.Items.Where(i => i.ID == id).ToList();
            
            foreach (var item in Items)
            {
                //if (factoryId == item.FactoryId)
                //{
                    AddedReplenishments.Add(new ModelReplenishments() { ItemId = item.ID, ItemName = item.ItemName, TransactionTypeId = 1, Quantity = itemQty, EffectiveDate = DateTime.Now, FactoryId = factoryId });
                //}
                
            }
            //Session["selectedItems"] = AddedReplenishments.Where(f => f.FactoryId == factoryId).ToList();
            //ViewBag.SelectedItems = Session["selectedItems"];
            //ViewBag.SelectedItems = AddedReplenishments.Where(f=>f.FactoryId==factoryId).ToList();
            //ViewBag.SelectedItems = (List<ModelReplenishments>)Session["selectedItems"];
            ViewBag.SelectedItems= AddedReplenishments.Where(f => f.FactoryId == factoryId).ToList();
            return PartialView("_SelectedToSell", ViewBag.SelectedItems);
        }

        public ActionResult RemoveSeletedItem(int id)
        {
            var indexNo = AddedReplenishments.FindIndex(l => l.ItemId == id);
            AddedReplenishments.RemoveAt(indexNo);
            return Json(JsonRequestBehavior.AllowGet, ViewBag.ItemID);
        }
        public ActionResult RemoveAll()
        {
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            //AddedReplenishments.Clear();
            AddedReplenishments.RemoveAll(f => f.FactoryId == factoryId);
            return Json(JsonRequestBehavior.AllowGet, ViewBag.ItemID);
        }
        public ActionResult IssueReplenishments()
        {
            ItemTransaction itemTransaction = new ItemTransaction();
            Item item = new Item();
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            foreach (var itemsForSale in AddedReplenishments.Where(f=>f.FactoryId==factoryId))
            {
                var CompareItemFactory = db.Items.Where(i => i.ID == itemsForSale.ItemId).FirstOrDefault();
                if (CompareItemFactory.FactoryId == itemsForSale.FactoryId)
                {
                    itemTransaction.ItemID = itemsForSale.ItemId;
                    itemTransaction.Quantity = itemsForSale.Quantity;
                    itemTransaction.TransactionTypeId = 1;
                    itemTransaction.EffectiveDate = DateTime.Now;
                    db.ItemTransactions.Add(itemTransaction);
                    db.SaveChanges();


                    var changedRec = db.Items.Where(i => i.ID == itemsForSale.ItemId).FirstOrDefault();
                    changedRec.DaySellingQty = changedRec.DaySellingQty + itemsForSale.Quantity;
                    db.Entry(changedRec).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
            }
            AddedReplenishments.RemoveAll(f=>f.FactoryId==factoryId);
            return RedirectToAction("Replenishments");
        }

        // GET: ItemTransactions/Create
        public ActionResult Create()
        {
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            ViewBag.ItemID = new SelectList(db.Items.Where(i => i.FactoryId == factoryId && i.IsDeleted == false).OrderBy(i => i.ItemName), "ID", "ItemName");
            return View();
        }

        // POST: ItemTransactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ItemID,Quantity,TransactionTypeId,EffectiveDate")] ItemTransaction itemTransaction)
        {
            if (ModelState.IsValid)
            {
                db.ItemTransactions.Add(itemTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemName", itemTransaction.ItemID);
            //ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "ID", "TransactionType1", itemTransaction.TransactionTypeId);
            return View(itemTransaction);
        }

        // GET: ItemTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTransaction itemTransaction = db.ItemTransactions.Find(id);
            if (itemTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemName", itemTransaction.ItemID);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "ID", "TransactionType1", itemTransaction.TransactionTypeId);
            return View(itemTransaction);
        }

        // POST: ItemTransactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ItemID,Quantity,TransactionTypeId,EffectiveDate")] ItemTransaction itemTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemName", itemTransaction.ItemID);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "ID", "TransactionType1", itemTransaction.TransactionTypeId);
            return View(itemTransaction);
        }

        // GET: ItemTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTransaction itemTransaction = db.ItemTransactions.Find(id);
            if (itemTransaction == null)
            {
                return HttpNotFound();
            }
            return View(itemTransaction);
        }

        // POST: ItemTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemTransaction itemTransaction = db.ItemTransactions.Find(id);
            db.ItemTransactions.Remove(itemTransaction);
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