using ecommerce_shop.App_Start;
using ecommerce_shop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(db.Kieux.ToList(),"ID","TenKieu");
            return View();
        }
    }
}