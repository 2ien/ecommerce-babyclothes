using ecommerce_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class HomeController : Controller
    {
        DBQLEcommerceShopEntities objDBQLEcommerceShopEntities = new DBQLEcommerceShopEntities();
        public ActionResult Index()
        {
            var lstCategory = objDBQLEcommerceShopEntities.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult HuongDan()
        {
            return View();
        }
      
    }
}