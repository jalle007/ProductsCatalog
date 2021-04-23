using System.Collections.Generic;
using System.Linq;
using EURIS.Entities;
using System.Data.Entity.Migrations;

namespace EURIS.Service
{
    public class ProductCatalogManager
    {
        readonly LocalDbEntities db = new LocalDbEntities();

        public List<ProductCatalog> GetProductCatalogsl()
        {
            return db.ProductCatalogs.ToList();
        }

        public ProductCatalog GetProductCatalog(int id)
        {
            var ProductCatalog = db.ProductCatalogs.FirstOrDefault(p => p.Id == id);
            return ProductCatalog;
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
