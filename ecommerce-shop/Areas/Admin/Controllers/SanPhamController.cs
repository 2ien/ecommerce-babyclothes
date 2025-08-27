using ecommerce_shop.Models;
using System.Linq;
using System.Web.Mvc;

namespace ecommerce_shop.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();

        public ActionResult DanhSach(string search = "")
        {
            var list = db.SanPhams.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                list = list.Where(sp => sp.TenSanPham.Contains(search));
            return View(list.ToList());
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View(sp);
        }

        public ActionResult CapNhat(int id)
        {
            var sp = db.SanPhams.Find(id);
            return View(sp);
        }

        [HttpPost]
        public ActionResult CapNhat(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View(sp);
        }

        public ActionResult Xoa(int id)
        {
            var sp = db.SanPhams.Find(id);
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
    }
}
//using ecommerce_shop.Models;
//using System.Linq;
//using System.Web.Mvc;

//namespace ecommerce_shop.Areas.Admin.Controllers
//{
//    public class SanPhamController : Controller
//    {
//        DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();

//        public ActionResult DanhSach(string search = "")
//        {
//            var list = db.SanPhams.AsQueryable();
//            if (!string.IsNullOrEmpty(search))
//                list = list.Where(sp => sp.TenSanPham.Contains(search));
//            return View(list.ToList());
//        }

//        public ActionResult ThemMoi()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult ThemMoi(SanPham sp)
//        {
//            if (ModelState.IsValid)
//            {
//                db.SanPhams.Add(sp);
//                db.SaveChanges();
//                return RedirectToAction("DanhSach");
//            }
//            return View(sp);
//        }

//        public ActionResult CapNhat(int id)
//        {
//            var sp = db.SanPhams.Find(id);
//            return View(sp);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult CapNhat(SanPham sp)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("DanhSach");
//            }
//            return View(sp);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Xoa(int id)
//        {
//            var sp = db.SanPhams.Find(id);
//            if (sp != null)
//            {
//                db.SanPhams.Remove(sp);
//                db.SaveChanges();
//            }
//            return RedirectToAction("DanhSach");
//        }
//    }
//}
