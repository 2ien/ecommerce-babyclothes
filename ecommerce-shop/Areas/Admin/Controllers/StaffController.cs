using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce_shop.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        // GET: Admin/Staff
        public ActionResult DanhSach()
        {
            return View();
        }
        public ActionResult ThemMoi()
        {
            return View();
        }
        public ActionResult CapNhat()
        {
            return View();
        }
        public ActionResult Xoa()
        {
            return View();
        }
    }
}