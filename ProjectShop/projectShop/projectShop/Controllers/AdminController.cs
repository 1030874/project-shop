using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using projectShop.Models;


namespace mvcShop.Controllers
{
    public class AdminController : Controller
    {
        private projectShopEntities db = new projectShopEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account model, string returnUrl)
        {
             // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {

                using(projectShopEntities entities = new projectShopEntities())
                {
                    string acc_name = model.acc_name;
                    string acc_pass = model.acc_pass;



                    bool userValid = entities.Accounts.Any(account => account.acc_name == acc_name && account.acc_pass == acc_pass);

                    if (userValid)
                    {
                         FormsAuthentication.SetAuthCookie(acc_name, false);
                         if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Start", "Admin");
                        }

                    }
                       else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }


                }
 
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

      [Authorize(Roles = "Admin")]
        public ActionResult Start()
        {

            ViewBag.Message = "This can be viewed only by users in Admin role only";

            return View();
        }

        // POST: Kunde/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

    }
}