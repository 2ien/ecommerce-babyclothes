using ecommerce_shop.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace ecommerce_shop.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        private DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
        // GET: Admin/ProductCategory 
        public ActionResult Index()
        {
            var items = db.Kieux;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Kieu model)
        {
            if(ModelState.IsValid)
            {        
                db.Kieux.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}