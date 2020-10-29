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
    public class ItemTypesController : Controller
    {
        private MPOSConStr db = new MPOSConStr();
        private Common com = new Common();

        // GET: ItemTypes
        public ActionResult Index()
        {
            int factoryId = Convert.ToInt32(Session["factoryId"].ToString());
            var itemTypes = db.ItemTypes.Include(i => i.Factory).Where(i => i.FactoryID == factoryId && i.IsDeleted == false).OrderBy(i => i.ItemType1);
            return View(itemTypes.ToList());
        }

        // GET: ItemTypes/Details/5
        public ActionResult ItemCategories(int? factoryId)
        {
            var categories = db.ItemTypes.Where(i => i.FactoryID == factoryId && i.IsDeleted == false);
            return PartialView("_Categories", categories.ToList());
        }

        // GET: ItemTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ItemType1,IsDeleted,DeletedDate,FactoryID")] ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                itemType.FactoryID = Convert.ToInt32(Session["factoryId"].ToString());
                itemType.IsDeleted = false;
                itemType.ItemType1 = itemType.ItemType1.ToUpper();
                db.ItemTypes.Add(itemType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FactoryID = new SelectList(db.Factories, "ID", "Code", itemType.FactoryID);
            return View(itemType);
        }

        // GET: ItemTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType itemType = db.ItemTypes.Find(id);
            if (itemType == null)
            {
                return HttpNotFound();
            }
            ViewBag.FactoryID = new SelectList(db.Factories, "ID", "Code", itemType.FactoryID);
            return View(itemType);
        }

        // POST: ItemTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ItemType1,IsDeleted,DeletedDate,FactoryID")] ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemType).State = EntityState.Modified;
                itemType.ItemType1 = itemType.ItemType1.ToUpper();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FactoryID = new SelectList(db.Factories, "ID", "Code", itemType.FactoryID);
            return View(itemType);
        }

        // GET: ItemTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType itemType = db.ItemTypes.Find(id);
            if (itemType == null)
            {
                return HttpNotFound();
            }
            return View(itemType);
        }

        // POST: ItemTypes/Delete/5
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
                DelCat = com.ExecuteProcedure("SP_DeleteItemType", CommandType.StoredProcedure, Parameter);
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