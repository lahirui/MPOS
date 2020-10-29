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
    public class ItemsController : Controller
    {
        private MPOSConStr db = new MPOSConStr();
        private Common com = new Common();

        // GET: Items
        public ActionResult Index()
        {
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            var items = db.Items.Include(i => i.Factory).Include(i => i.ItemType).Where(i => i.FactoryId == factoryId && i.IsDeleted == false).OrderBy(i => i.ItemName);
            return View(items.ToList());
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            ViewBag.MetricId = new SelectList(db.Metrics.Where(m => m.IsDeleted == false).OrderBy(m => m.MetricName), "ID", "MetricName");
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes.Where(i => i.IsDeleted == false && i.FactoryID==factoryId).OrderBy(i => i.ItemType1), "ID", "ItemType1");
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ItemTypeId,FactoryId,ItemName,UnitPrice,UnitCapacity,DaySellingQty,IsDeleted,DeletedDate,MetricId")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.FactoryId = Convert.ToInt32(Session["factoryId"].ToString());
                item.IsDeleted = false;
                item.ItemName = item.ItemName.ToUpper();
                item.DaySellingQty = 0;
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            ViewBag.MetricId = new SelectList(db.Metrics.Where(m => m.IsDeleted == false).OrderBy(m => m.MetricName), "ID", "MetricName", item.MetricId);
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes.Where(i => i.IsDeleted == false && i.FactoryID== factoryId).OrderBy(i => i.ItemType1), "ID", "ItemType1", item.ItemTypeId);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            ViewBag.MetricId = new SelectList(db.Metrics.Where(m => m.IsDeleted == false).OrderBy(m => m.MetricName), "ID", "MetricName", item.MetricId);
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes.Where(i => i.IsDeleted == false && i.FactoryID==factoryId).OrderBy(i => i.ItemType1), "ID", "ItemType1", item.ItemTypeId);
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ItemTypeId,FactoryId,ItemName,UnitPrice,UnitCapacity,DaySellingQty,IsDeleted,DeletedDate,MetricId")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                item.ItemName = item.ItemName.ToUpper();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            ViewBag.MetricId = new SelectList(db.Metrics.Where(m => m.IsDeleted == false).OrderBy(m => m.MetricName), "ID", "MetricName", item.MetricId);
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes.Where(i => i.IsDeleted == false && i.FactoryID==factoryId).OrderBy(i => i.ItemType1), "ID", "ItemType1", item.ItemTypeId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                int DelCat = 0;
                com.BeginTrans();
                SqlParameter[] Parameter = new SqlParameter[1];
                Parameter[0] = new SqlParameter("@ID", id);
                DelCat = com.ExecuteProcedure("SP_DeleteItems", CommandType.StoredProcedure, Parameter);
                com.CommitTrans();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
                com.RollbackTrans();
                return RedirectToAction("Delete");
            }
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