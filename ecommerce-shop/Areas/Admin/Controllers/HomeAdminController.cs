using ecommerce_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using System.Web.Security;

namespace ecommerce_shop.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user,string password)
        {
            //check db
            DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
            int demTaiKhoan = db.Staffs.Count(m => m.Usename.ToLower() == user.ToLower() && m.Password == password);
            //check code
            if(demTaiKhoan == 1)
            {
                Session["user"] = "user";
                
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng";
                return View();
            }
        }
        public ActionResult Logout()
        {
            //Xóa session
            Session.Remove("user");
            //Xóa session form Authent
            FormsAuthentication.SignOut();
            //Trả về login
            return RedirectToAction("Login");
        }
    }
}