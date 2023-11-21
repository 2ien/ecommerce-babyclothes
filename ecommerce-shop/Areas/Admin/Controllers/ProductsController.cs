using ecommerce_shop.App_Start;
using ecommerce_shop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ecommerce_shop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
        // GET: Admin/Product
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult SanPham(int? page)
        {
            IEnumerable<SanPham> items = db.SanPhams.OrderByDescending(x => x.ID);
            var pageSize = 10;
            if(page == null)
            {
                page = 1;
            }
            var pageSanPham = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageSanPham, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);        
         }
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Add()
        {

            SanPham pro = new SanPham();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Add(SanPham model, HttpPostedFileBase ImageUpload)
        {
            try
            {
                if (model.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    string extension = Path.GetExtension(model.ImageUpload.FileName);
                    fileName = fileName + extension;
                    model.HinhAnh = "~/Content/imgs/product/" + fileName;
                    model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/imgs/product/"), fileName));

                }
                db.SanPhams.Add(model);
                db.SaveChanges();
                return RedirectToAction("SanPham");
            }
            catch
            {
                return View();
            }

        }
        [AdminAuthorize(idChucNang = 3)]
        public ActionResult Edit(int id)
        {
            return View(db.SanPhams.Where(m => m.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, SanPham model)
        {
            try
            {
                if (model.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    string extension = Path.GetExtension(model.ImageUpload.FileName);

                    fileName = fileName + extension;
                    model.HinhAnh = "~/Content/imgs/product/" + fileName;
                    model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/imgs/product/"), fileName));

                }
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SanPham");
            }
            catch { return View(); }
        }
        [AdminAuthorize(idChucNang = 4)]
        public ActionResult Delete(int id)
        {
            return View(db.SanPhams.Where(m => m.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, SanPham model)
        {
            model = db.SanPhams.Where(m => m.ID == id).FirstOrDefault();
            db.SanPhams.Remove(model);
            db.SaveChanges();
            return RedirectToAction("SanPham");
        }
    }
}
