using ecommerce_shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class HomeController : Controller
    {
       DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThoiTrang()
        {
            return View(db.SanPhams.ToList());
        }
        public ActionResult HuongDan()
        {
            return View();
        }
   
    }
}
