using System.Linq;
using System.Web.Mvc;
using ecommerce_shop.Models;

namespace ecommerce_shop.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();

        public ActionResult DanhSach(string search)
        {
            var nhanviens = db.NhanViens.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                nhanviens = nhanviens.Where(n => n.TenNhanVien.Contains(search) || n.Username.Contains(search));
            return View(nhanviens.ToList());
        }

        [HttpGet]
        public ActionResult ThemMoi() => View();

        [HttpPost]
        public ActionResult ThemMoi(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nv);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View(nv);
        }

        public ActionResult Xoa(int id)
        {
            var nv = db.NhanViens.Find(id);
            if (nv != null)
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSach");
        }
    }
}
