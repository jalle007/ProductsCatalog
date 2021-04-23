using EURIS.Entities;
using EURIS.Service;
using EurisTest.Web.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EurisTest.Web.Controllers
{
    public class ProductCatalogs2Controller : Controller
    {
        private LocalDbEntities db = new LocalDbEntities();
        private ProductManager _productManager = new ProductManager();
        private CatalogManager _catalogManager = new CatalogManager();
        private ProductCatalogManager _productCatalogManager = new ProductCatalogManager();

        // 1. Delete product from catalog here
        // 2. after delete product clean join table
        // 3. add buttons 
        // 4. Filter products in catalog - done

        // GET: ProductCatalogs2
        public ActionResult Index(int? id)
        {
            // GEt products in Catalogs 
            List<ProductCatalog> productCatalog;
            if (id != null)
                productCatalog = db.ProductCatalogs.Where(c => c.CatalogId == id).Include(p => p.Product).ToList();
            else
            {
                var min = db.ProductCatalogs.Min(c => c.CatalogId);
                productCatalog = db.ProductCatalogs.Where(c => c.CatalogId == min).Include(p => p.Product).ToList();
            }


            var allCatalogs = db.Catalogs.ToList();
            // Combobox data
            var temp = allCatalogs.Select(c => new {Id=c.Id, Text = c.Code + " | " + c.Description }).ToList();
            ViewBag.Catalogs = new SelectList(temp, "Id", "Text", id);


            var cat = JsonConvert.SerializeObject(temp); 

            //string jsArray = "{";
            //foreach (var cat in allCatalogs)
            //{

            //}
            ViewBag.Catalogs2 = cat;

            var productsInCatalog = productCatalog.Select(p => p.Product).ToList();
            ViewBag.productsInCatalog = productsInCatalog;

            // All products MINUS  products already in catalog
            var allProducts = _productManager.GetProducts();
            allProducts = allProducts.Except(productsInCatalog, new EqualityComparer()).ToList();

            ViewBag.Products = allProducts;


            ViewBag.productCatalogs = productCatalog.ToList();

            return View();
        }

        // POST: ProductCatalogs2/Add
        [HttpPost]
        public ActionResult Add(int catalogId, int[] selected)
        {
            foreach (int product_id in selected)
            {
                _productCatalogManager.AddOrUpdate(new ProductCatalog() {
                    CatalogId  = catalogId,
                    ProductId = product_id
                });
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


        // POST: ProductCatalogs2/Add
        [HttpPost]
        public ActionResult Remove(int catalogId, int[] selected)
        {
            foreach (int product_id in selected)
            {
                _productCatalogManager.DeleteProduct(catalogId, product_id);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
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

    }
}
