using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectShop.Models;
using System.Net;

namespace projectShop.Controllers
{
    
    public class HomeController : Controller
    {
        private projectShopEntities db = new projectShopEntities();
        
        public ActionResult Index()
        {
           
            //Henter alle produkter
            return View(db.Products.ToList().Take(8));
        }


        //Henter et produkt ud fra et ID

        public ActionResult ViewProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}
