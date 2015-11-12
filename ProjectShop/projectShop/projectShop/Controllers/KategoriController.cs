using projectShop.Models;
using System;

using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace mvcShop.Controllers
{
    public class KategoriController : Controller
    {
        private projectShopEntities db = new projectShopEntities();
        // GET: Brand
        public ActionResult Kategori()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Produkt(int Id)
        {
            // henter categori ud fra id i urlen.

            projectShopEntities db = new projectShopEntities();

            List<Product> product = db.Products.Where(c => c.product_category == Id).ToList();

            return View(product);
        }
    }
}