using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EURIS.Entities;
using EURIS.Service;

namespace EurisTest.Web.Controllers
{
    public class ProductCatalogController : Controller
    {
        private LocalDbEntities db = new LocalDbEntities();
        private ProductCatalogManager _ProductCatalogManager = new ProductCatalogManager();

        // GET: ProductCatalogs
        public ActionResult Index()
        {
            var ProductCatalogs = _ProductCatalogManager.GetProductCatalogsl();

            return View(ProductCatalogs);
        }

        // GET: ProductCatalogs/Details/5
        public ActionResult Details(int id)
        {
            ProductCatalog ProductCatalog = _ProductCatalogManager.GetProductCatalog(id);

            if (ProductCatalog == null)
                return HttpNotFound();
            
            return View(ProductCatalog);
        }

        // GET: ProductCatalogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCatalogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,CatalogId")] ProductCatalog ProductCatalog)
        {
            if (ModelState.IsValid)
            {
                _ProductCatalogManager.AddOrUpdate(ProductCatalog);
                return RedirectToAction("Index");
            }

            return View(ProductCatalog);
        }

        // GET: ProductCatalogs/Edit/5
        public ActionResult Edit(int id)
        {
            ProductCatalog ProductCatalog = _ProductCatalogManager.GetProductCatalog(id);
             
            if (ProductCatalog == null)
                return HttpNotFound();
            
            return View(ProductCatalog);
        }

        // POST: ProductCatalogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,CatalogId")] ProductCatalog ProductCatalog)
        {
            if (ModelState.IsValid)
            {
                _ProductCatalogManager.AddOrUpdate(ProductCatalog);
                return RedirectToAction("Index");
            }
            return View(ProductCatalog);
        }

        // GET: ProductCatalogs/Delete/5
        public ActionResult Delete(int id)
        {
            ProductCatalog ProductCatalog = _ProductCatalogManager.GetProductCatalog(id);

            if (ProductCatalog == null)
                return HttpNotFound();

            return View(ProductCatalog);
        }

        // POST: ProductCatalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _ProductCatalogManager.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            
            base.Dispose(disposing);
        }
    
    }
}
