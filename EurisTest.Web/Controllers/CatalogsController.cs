using EURIS.Entities;
using EURIS.Service;
using System.Web.Mvc;

namespace EurisTest.Web.Controllers
{
    public class CatalogsController : Controller
    {
        private CatalogManager _CatalogManager = new CatalogManager();

        // GET: Catalogs
        public ActionResult Index()
        {
            var Catalogs = _CatalogManager.GetCatalogs();

            return View(Catalogs);
        }

        // GET: Catalogs/Details/5
        public ActionResult Details(int id)
        {
            Catalog Catalog = _CatalogManager.GetCatalog(id);

            if (Catalog == null)
                return HttpNotFound();
            
            return View(Catalog);
        }

        // GET: Catalogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Description,Product")] Catalog Catalog)
        {
            if (ModelState.IsValid)
            {
                _CatalogManager.AddOrUpdate(Catalog);
                return RedirectToAction("Index");
            }

            return View(Catalog);
        }

        // GET: Catalogs/Edit/5
        public ActionResult Edit(int id)
        {
            Catalog Catalog = _CatalogManager.GetCatalog(id);
             
            if (Catalog == null)
                return HttpNotFound();
            
            return View(Catalog);
        }

        // POST: Catalogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Description,Product")] Catalog Catalog)
        {
            if (ModelState.IsValid)
            {
                _CatalogManager.AddOrUpdate(Catalog);
                return RedirectToAction("Index");
            }
            return View(Catalog);
        }

        // GET: Catalogs/Delete/5
        public ActionResult Delete(int id)
        {
            Catalog Catalog = _CatalogManager.GetCatalog(id);

            if (Catalog == null)
                return HttpNotFound();

            return View(Catalog);
        }

        // POST: Catalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _CatalogManager.Delete(id);
            return RedirectToAction("Index");
        }

        
    
    }
}
