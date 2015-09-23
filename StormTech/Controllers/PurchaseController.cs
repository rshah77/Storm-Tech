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
    public class PurchaseController : Controller
    {
        private STdatabaseEntities db = new STdatabaseEntities();

        //
        // GET: /Purchase/

        public ActionResult Index()
        {
            var purchase_table = db.Purchase_Table.Include(p => p.Item_table);
            return View(purchase_table.ToList());
        }

        //
        // GET: /Purchase/Details/5

        public ActionResult Details(int id = 0)
        {
            Purchase_Table purchase_table = db.Purchase_Table.Find(id);
            if (purchase_table == null)
            {
                return HttpNotFound();
            }
            return View(purchase_table);
        }

        //
        // GET: /Purchase/Create

        public ActionResult Create()
        {
            ViewBag.Item_ID = new SelectList(db.Item_table, "ID", "Description");
            return View();
        }

        //
        // POST: /Purchase/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Purchase_Table purchase_table)
        {
            if (ModelState.IsValid)
            {
                db.Purchase_Table.Add(purchase_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_ID = new SelectList(db.Item_table, "ID", "Description", purchase_table.Item_ID);
            return View(purchase_table);
        }

        //
        // GET: /Purchase/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Purchase_Table purchase_table = db.Purchase_Table.Find(id);
            if (purchase_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item_ID = new SelectList(db.Item_table, "ID", "Description", purchase_table.Item_ID);
            return View(purchase_table);
        }

        //
        // POST: /Purchase/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Purchase_Table purchase_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Item_ID = new SelectList(db.Item_table, "ID", "Description", purchase_table.Item_ID);
            return View(purchase_table);
        }

        //
        // GET: /Purchase/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Purchase_Table purchase_table = db.Purchase_Table.Find(id);
            if (purchase_table == null)
            {
                return HttpNotFound();
            }
            return View(purchase_table);
        }

        //
        // POST: /Purchase/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase_Table purchase_table = db.Purchase_Table.Find(id);
            db.Purchase_Table.Remove(purchase_table);
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