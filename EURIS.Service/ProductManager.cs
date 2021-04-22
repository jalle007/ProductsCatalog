using System.Collections.Generic;
using System.Linq;
using EURIS.Entities;
using System.Data.Entity.Migrations;

namespace EURIS.Service
{
    public class ProductManager
    {
        readonly LocalDbEntities _context = new LocalDbEntities();

        public List<Product> GetProductsl()
        {
            var products = (from item in _context.Products select item).ToList();
            return products;
        }

        public Product GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public Product AddOrUpdate(Product product)
        {
            _context.Products.AddOrUpdate(product);
            var result = _context.SaveChanges();
            
            return (result == 0 ? null : product);
        }

        public int Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            _context.Products.Remove(product);
            int result = _context.SaveChanges();

            return result ;
        }


    }
}
