using System.Collections.Generic;
using System.Linq;
using EURIS.Entities;
using System.Data.Entity.Migrations;

namespace EURIS.Service
{
    public class CatalogManager
    {
        readonly LocalDbEntities _context = new LocalDbEntities();

        public List<Catalog> GetCatalogsl()
        {
            var Catalogs = (from item in _context.Catalogs select item).ToList();
            return Catalogs;
        }

        public Catalog GetCatalog(int id)
        {
            var Catalog = _context.Catalogs.FirstOrDefault(p => p.Id == id);
            return Catalog;
        }

        public Catalog AddOrUpdate(Catalog Catalog)
        {
            _context.Catalogs.AddOrUpdate(Catalog);
            var result = _context.SaveChanges();
            
            return (result == 0 ? null : Catalog);
        }

        public int Delete(int id)
        {
            var Catalog = _context.Catalogs.FirstOrDefault(p => p.Id == id);

            _context.Catalogs.Remove(Catalog);
            int result = _context.SaveChanges();

            return result ;
        }


    }
}
