using ecommerce_shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class AccountController : Controller
    {
        DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
        // GET: Account
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult AuthenLogin(User _user)
        {
            try
            {
                var check_User = db.Users.Where(s => s.Username == _user.Username).FirstOrDefault();

                var check_Pass = db.Users.Where(s => s.Password == _user.Password).FirstOrDefault();
                if (check_User == null || check_Pass == null)
                {
                    if (check_User == null)
                        ViewBag.ErrorID = "ID not match";

                    if (check_Pass == null)
                        ViewBag.ErrorPass = "Pass not match";
                    return View("Login");
                }
                else
                {
                    Session["Username"] = _user.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return View("Login");
            }
        }
    }
}