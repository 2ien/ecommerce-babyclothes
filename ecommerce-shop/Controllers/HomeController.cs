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
        // Trang ThoiTrang + tìm kiếm
        public ActionResult ThoiTrang(string search)
        {
            var products = db.SanPhams.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.TenSanPham.Contains(search));
            }

            return View(products.ToList());
        }

        // Trang chi tiết sản phẩm
        public ActionResult ChiTietSanPham(int id)
        {
            var product = db.SanPhams.FirstOrDefault(p => p.ID == id);
            if (product == null) return HttpNotFound("Không tìm thấy sản phẩm");
            return View(product);
        }
        public ActionResult HuongDan()
        {
            return View();
        }
   
    }
}
