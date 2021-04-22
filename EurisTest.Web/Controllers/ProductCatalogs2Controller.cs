using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EURIS.Entities;

namespace EurisTest.Web.Controllers
{
    public class ProductCatalogs2Controller : Controller
    {
        private LocalDbEntities db = new LocalDbEntities();

        // GET: ProductCatalogs2
        public ActionResult Index()
        {
            var productCatalogs = db.ProductCatalogs.Include(p => p.Catalog).Include(p => p.Product);
            return View(productCatalogs.ToList());
        }

        // GET: ProductCatalogs2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCatalog productCatalog = db.ProductCatalogs.Find(id);
            if (productCatalog == null)
            {
                return HttpNotFound();
            }
            return View(productCatalog);
        }

        // GET: ProductCatalogs2/Create
        public ActionResult Create()
        {
            ViewBag.CatalogId = new SelectList(db.Catalogs, "Id", "Code");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Code");
            return View();
        }

        // POST: ProductCatalogs2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,CatalogId")] ProductCatalog productCatalog)
        {
            if (ModelState.IsValid)
            {
                db.ProductCatalogs.Add(productCatalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatalogId = new SelectList(db.Catalogs, "Id", "Code", productCatalog.CatalogId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Code", productCatalog.ProductId);
            return View(productCatalog);
        }

        // GET: ProductCatalogs2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCatalog productCatalog = db.ProductCatalogs.Find(id);
            if (productCatalog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatalogId = new SelectList(db.Catalogs, "Id", "Code", productCatalog.CatalogId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Code", productCatalog.ProductId);
            return View(productCatalog);
        }

        // POST: ProductCatalogs2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,CatalogId")] ProductCatalog productCatalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productCatalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatalogId = new SelectList(db.Catalogs, "Id", "Code", productCatalog.CatalogId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Code", productCatalog.ProductId);
            return View(productCatalog);
        }

        // GET: ProductCatalogs2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCatalog productCatalog = db.ProductCatalogs.Find(id);
            if (productCatalog == null)
            {
                return HttpNotFound();
            }
            return View(productCatalog);
        }

        // POST: ProductCatalogs2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCatalog productCatalog = db.ProductCatalogs.Find(id);
            db.ProductCatalogs.Remove(productCatalog);
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
