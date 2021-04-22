using EURIS.Service;
using System.Web.Mvc;

namespace EurisTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productManager = new ProductManager();

            //var product =  productManager.AddOrUpdate(new EURIS.Entities.Product() {
            //    Code = "asd1",
            //    Description = "1",
            //    Price = 1
            //});

            //var result = productManager.Delete(product.Id);

            return View();
        }
    }
}