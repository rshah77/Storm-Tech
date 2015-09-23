using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StormTech.Models;

namespace StormTech.Controllers
{
    public class ItemController : Controller
    {
        private STdatabaseEntities db = new STdatabaseEntities();

        //
        // GET: /Item/

        public ActionResult Index()
        {
            var item_table = db.Item_table.Include(i => i.Supplier_table);
            return View(item_table.ToList());
        }

        //
        // GET: /Item/Details/5

        public ActionResult Details(int id = 0)
        {
            Item_table item_table = db.Item_table.Find(id);
            if (item_table == null)
            {
                return HttpNotFound();
            }
            return View(item_table);
        }

        //
        // GET: /Item/Create

        public ActionResult Create()
        {
            ViewBag.Supplier_ID = new SelectList(db.Supplier_table, "ID", "Name");
            return View();
        }

        //
        // POST: /Item/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item_table item_table)
        {
            if (ModelState.IsValid)
            {
                db.Item_table.Add(item_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Supplier_ID = new SelectList(db.Supplier_table, "ID", "Name", item_table.Supplier_ID);
            return View(item_table);
        }

        //
        // GET: /Item/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Item_table item_table = db.Item_table.Find(id);
            if (item_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Supplier_ID = new SelectList(db.Supplier_table, "ID", "Name", item_table.Supplier_ID);
            return View(item_table);
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item_table item_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Supplier_ID = new SelectList(db.Supplier_table, "ID", "Name", item_table.Supplier_ID);
            return View(item_table);
        }

        //
        // GET: /Item/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Item_table item_table = db.Item_table.Find(id);
            if (item_table == null)
            {
                return HttpNotFound();
            }
            return View(item_table);
        }

        //
        // POST: /Item/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item_table item_table = db.Item_table.Find(id);
            db.Item_table.Remove(item_table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}