using System.Collections.Generic;
using System.Linq;
using EURIS.Entities;
using System.Data.Entity.Migrations;

namespace EURIS.Service
{
    public class ProductCatalogManager
    {
        readonly LocalDbEntities _context = new LocalDbEntities();

        public List<ProductCatalog> GetProductCatalogsl()
        {
            var ProductCatalogs = (from item in _context.ProductCatalogs select item).ToList();
            return ProductCatalogs;
        }

        public ProductCatalog GetProductCatalog(int id)
        {
            var ProductCatalog = _context.ProductCatalogs.FirstOrDefault(p => p.Id == id);
            return ProductCatalog;
        }

        public ProductCatalog AddOrUpdate(ProductCatalog ProductCatalog)
        {
            _context.ProductCatalogs.AddOrUpdate(ProductCatalog);
            var result = _context.SaveChanges();
            
            return (result == 0 ? null : ProductCatalog);
        }

        public int Delete(int id)
        {
            var ProductCatalog = _context.ProductCatalogs.FirstOrDefault(p => p.Id == id);

            _context.ProductCatalogs.Remove(ProductCatalog);
            int result = _context.SaveChanges();

            return result ;
        }


    }
}
