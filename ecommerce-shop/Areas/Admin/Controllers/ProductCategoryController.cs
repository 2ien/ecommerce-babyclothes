using ecommerce_shop.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Add(Kieu model)
        { 
            db.Kieux.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(db.Kieux.Where(s => s.ID == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(db.Kieux.Where(s => s.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Kieu model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Category");
        }
        public ActionResult Delete(int id)
        {
            return View(db.Kieux.Where(s => s.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Kieu model)
        {
            model = db.Kieux.Where(s => s.ID  == id).FirstOrDefault();
            db.Kieux.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Category");
        }
    }
}