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
    public class InvoiceController : Controller
    {
        private STdatabaseEntities db = new STdatabaseEntities();

        //
        // GET: /Invoice/

        public ActionResult Index()
        {
            var invoice_table = db.Invoice_table.Include(i => i.Purchase_Table);
            return View(invoice_table.ToList());
        }

        //
        // GET: /Invoice/Details/5

        public ActionResult Details(string id = null)
        {
            Invoice_table invoice_table = db.Invoice_table.Find(id);
            if (invoice_table == null)
            {
                return HttpNotFound();
            }
            return View(invoice_table);
        }

        //
        // GET: /Invoice/Create

        public ActionResult Create()
        {
            ViewBag.Purchase_Order_Number = new SelectList(db.Purchase_Table, "Order_Number", "Order_Number");
            return View();
        }

        //
        // POST: /Invoice/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoice_table invoice_table)
        {
            if (ModelState.IsValid)
            {
                db.Invoice_table.Add(invoice_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Purchase_Order_Number = new SelectList(db.Purchase_Table, "Order_Number", "Order_Number", invoice_table.Purchase_Order_Number);
            return View(invoice_table);
        }

        //
        // GET: /Invoice/Edit/5

        public ActionResult Edit(string id = null)
        {
            Invoice_table invoice_table = db.Invoice_table.Find(id);
            if (invoice_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Purchase_Order_Number = new SelectList(db.Purchase_Table, "Order_Number", "Order_Number", invoice_table.Purchase_Order_Number);
            return View(invoice_table);
        }

        //
        // POST: /Invoice/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Invoice_table invoice_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Purchase_Order_Number = new SelectList(db.Purchase_Table, "Order_Number", "Order_Number", invoice_table.Purchase_Order_Number);
            return View(invoice_table);
        }

        //
        // GET: /Invoice/Delete/5

        public ActionResult Delete(string id = null)
        {
            Invoice_table invoice_table = db.Invoice_table.Find(id);
            if (invoice_table == null)
            {
                return HttpNotFound();
            }
            return View(invoice_table);
        }

        //
        // POST: /Invoice/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Invoice_table invoice_table = db.Invoice_table.Find(id);
            db.Invoice_table.Remove(invoice_table);
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