using EURIS.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EURIS.Service
{
    public class ProductCatalogManager
    {
        readonly LocalDbEntities db = new LocalDbEntities();

        public List<ProductCatalog> GetProductCatalogs()
        {
            return db.ProductCatalogs.ToList();
        }

        public ProductCatalog GetProductCatalog(int id)
        {
            var ProductCatalog = db.ProductCatalogs.FirstOrDefault(p => p.Id == id);
            return ProductCatalog;
        }

        public List<ProductCatalog> GetByCatalogId(int? id)
        {
            List<ProductCatalog> productCatalog;
            if (id != null)
                productCatalog = db.ProductCatalogs.Where(c => c.CatalogId == id).Include(p => p.Product).ToList();
            else
            {
                var min = db.ProductCatalogs.Min(c => c.CatalogId);
                productCatalog = db.ProductCatalogs.Where(c => c.CatalogId == min).Include(p => p.Product).ToList();
            }

            return productCatalog;
        }


        public ProductCatalog AddOrUpdate(ProductCatalog ProductCatalog)
        {
            db.ProductCatalogs.AddOrUpdate(ProductCatalog);
            var result = db.SaveChanges();
            
            return (result == 0 ? null : ProductCatalog);
        }

        public int Delete(int id)
        {
            var ProductCatalog = db.ProductCatalogs.FirstOrDefault(p => p.Id == id);

            db.ProductCatalogs.Remove(ProductCatalog);
            int result = db.SaveChanges();

            return result ;
        }

        public int DeleteProduct(int catalogId, int productId)
        {
            var ProductCatalog = db.ProductCatalogs.FirstOrDefault(p => p.CatalogId == catalogId && p.ProductId == productId);

            db.ProductCatalogs.Remove(ProductCatalog);
            int result = db.SaveChanges();

            return result;
        }

        public int DeleteCatalog(int catalogId)
        {
            var ProductCatalog = db.ProductCatalogs.Where(p => p.CatalogId == catalogId );
            int result = 0;

            foreach (var item in ProductCatalog)
            {
                db.ProductCatalogs.Remove(item);
                result = db.SaveChanges();

            }

            return result;
        }


    }
}
