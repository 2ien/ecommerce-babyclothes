using ecommerce_shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class AccountController : Controller
    {
        DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var check = db.Users.Where(s=>s.Username.Equals(user.Username)&&s.Password.Equals(user.Password)).FirstOrDefault();
            if(check == null)
            {
                user.LoginErrorMessage = "Tài khoản hoặc mật khẩu sai";
                return View("Login",user);
            }
            else
            {
                Session["ID"] = user.ID;
                Session["Username"] = user.Username;
                return RedirectToAction("Index", "Home");
            }
           
        }
    
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Username == user.Username);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Tài khoản đã tồn tại";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}