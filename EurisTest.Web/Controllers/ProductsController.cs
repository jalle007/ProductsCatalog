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
    public class ProductsController : Controller
    {
        private ProductManager _productManager = new ProductManager();

        // GET: Products
        public ActionResult Index()
        {
            var products = _productManager.GetProductsl();

            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            Product product = _productManager.GetProduct(id);

            if (product == null)
                return HttpNotFound();
            
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productManager.AddOrUpdate(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = _productManager.GetProduct(id);
             
            if (product == null)
                return HttpNotFound();
            
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productManager.AddOrUpdate(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = _productManager.GetProduct(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productManager.Delete(id);
            return RedirectToAction("Index");
        }

      
    
    }
}
