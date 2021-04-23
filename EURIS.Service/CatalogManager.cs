using System.Collections.Generic;
using System.Linq;
using EURIS.Entities;
using System.Data.Entity.Migrations;

namespace EURIS.Service
{
    public class CatalogManager
    {
        readonly LocalDbEntities db = new LocalDbEntities();

        public List<Catalog> GetCatalogs()
        {
            return  db.Catalogs.ToList();
        }

        public Catalog GetCatalog(int id)
        {
            var Catalog = db.Catalogs.FirstOrDefault(p => p.Id == id);
            return Catalog;
        }

        public Catalog AddOrUpdate(Catalog Catalog)
        {
            db.Catalogs.AddOrUpdate(Catalog);
            var result = db.SaveChanges();
            
            return (result == 0 ? null : Catalog);
        }

        public int Delete(int id)
        {
            var Catalog = db.Catalogs.FirstOrDefault(p => p.Id == id);

            db.Catalogs.Remove(Catalog);
            int result = db.SaveChanges();

            return result ;
        }


    }
}
