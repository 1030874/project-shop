using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectShop.Controllers
{
    public class ReklameController : Controller
    {

      [Authorize(Roles = "Admin")]
        // GET: Reklame
        public ActionResult Index()
        {
            return View();
        }
    }
}