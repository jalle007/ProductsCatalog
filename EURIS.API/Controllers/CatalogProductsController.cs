using EURIS.Entities;
using EURIS.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace EURIS.API.Controllers
{
    public class CatalogProductsController : ApiController
    {
        private ProductCatalogManager _productCatalogManager = new ProductCatalogManager();

        // GET api/CatalogProducts/1
        public IHttpActionResult Get(int id)
        {
            var result = _productCatalogManager.GetByCatalogId(id);
            var products = result.Select(p => p.Product).ToList();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(products, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            
        }

         
         
    }
}
