using System.Linq;
using System.Web.Mvc;
using ecommerce_shop.Models;

namespace ecommerce_shop.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();

        public ActionResult DanhSach(string search)
        {
            var users = db.Users.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                users = users.Where(u => u.Username.Contains(search) || u.Username.Contains(search));
            return View(users.ToList());
        }

        [HttpGet]
        public ActionResult ThemMoi() => View();

        [HttpPost]
        public ActionResult ThemMoi(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View(user);
        }

        public ActionResult Xoa(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSach");
        }
    }
}
