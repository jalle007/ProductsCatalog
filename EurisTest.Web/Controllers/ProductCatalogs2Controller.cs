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
        private ProductManager _productManager = new ProductManager();
        private CatalogManager _catalogManager = new CatalogManager();
        private ProductCatalogManager _productCatalogManager = new ProductCatalogManager();

        // GET: ProductCatalogs2
        public ActionResult Index(int? id)
        {
            // GEt products in Catalogs 
            List<ProductCatalog> productCatalog = _productCatalogManager.GetByCatalogId(id); 


            var allCatalogs = _catalogManager.GetCatalogs();
            // Combobox data
            var temp = allCatalogs.Select(c => new {Id=c.Id, Text = c.Code + " | " + c.Description }).ToList();
            ViewBag.Catalogs = new SelectList(temp, "Id", "Text", id);

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

         
    }
}
