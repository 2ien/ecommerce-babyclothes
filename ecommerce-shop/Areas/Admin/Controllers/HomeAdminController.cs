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
        public ActionResult Login(string username, string password)
        {
            //check db
            if (string.IsNullOrEmpty(username) == true | string.IsNullOrEmpty(password) == true)
            {
                TempData["Error"] = "Chưa nhập thông tin";
                return View();
            }
            DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
            var user = db.NhanViens.SingleOrDefault(m => m.Username.ToLower() == username.ToLower()); ;
            //check tài khoản,check mật khẩu 
            if (user == null || user.Password != password)
            {
                TempData["Error"] = "Tài khoản không tồn tại hoặc mật khẩu không đúng";
                return View();
            }    
            //Lưu session
            Session["user"] = user;
            return RedirectToAction("Index"); 

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