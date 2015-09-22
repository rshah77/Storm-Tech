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
    public class SupplierController : Controller
    {
        private STdatabaseEntities1 db = new STdatabaseEntities1();

        //
        // GET: /Supplier/

        public ActionResult Index()
        {
            return View(db.Supplier_table.ToList());
        }

        //
        // GET: /Supplier/Details/5

        public ActionResult Details(int id = 0)
        {
            Supplier_table supplier_table = db.Supplier_table.Find(id);
            if (supplier_table == null)
            {
                return HttpNotFound();
            }
            return View(supplier_table);
        }

        //
        // GET: /Supplier/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Supplier/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier_table supplier_table)
        {
            if (ModelState.IsValid)
            {
                db.Supplier_table.Add(supplier_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier_table);
        }

        //
        // GET: /Supplier/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Supplier_table supplier_table = db.Supplier_table.Find(id);
            if (supplier_table == null)
            {
                return HttpNotFound();
            }
            return View(supplier_table);
        }

        //
        // POST: /Supplier/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier_table supplier_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier_table);
        }

        //
        // GET: /Supplier/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Supplier_table supplier_table = db.Supplier_table.Find(id);
            if (supplier_table == null)
            {
                return HttpNotFound();
            }
            return View(supplier_table);
        }

        //
        // POST: /Supplier/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier_table supplier_table = db.Supplier_table.Find(id);
            db.Supplier_table.Remove(supplier_table);
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