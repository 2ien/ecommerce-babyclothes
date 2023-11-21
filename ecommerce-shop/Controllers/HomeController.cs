using ecommerce_shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using PagedList;
using System.Threading.Tasks;

namespace ecommerce_shop.Controllers
{
    public class HomeController : Controller
    {
       DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThoiTrang(int? page)
        {
            var pageSize = 10;
            if(page == null)
            {
                page = 1;
            }
            var pageThoiTrang = page.HasValue?Convert.ToInt32(page) : 1;
            var items = db.SanPhams.OrderByDescending(x => x.ID).ToPagedList(pageThoiTrang,pageSize);
            return View(items);
        }
        public ActionResult ChiTietSanPham(int id )
        {
            return View(db.SanPhams.Where(m => m.ID == id).FirstOrDefault());
        }
        public ActionResult HuongDan()//đổi lại thành Giới thiệu
        {
            return View();
        }
   
    }
}
