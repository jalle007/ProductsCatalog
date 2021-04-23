using System.Collections.Generic;
using System.Linq;
using EURIS.Entities;
using System.Data.Entity.Migrations;

namespace EURIS.Service
{
    public class ProductManager
    {
        readonly LocalDbEntities db = new LocalDbEntities();

        public List<Product> GetProducts()
        {
           return db.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public Product AddOrUpdate(Product product)
        {
            db.Products.AddOrUpdate(product);
            var result = db.SaveChanges();
            
            return (result == 0 ? null : product);
        }

        public int Delete(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);

            db.Products.Remove(product);
            int result = db.SaveChanges();

            return result ;
        }


    }
}
