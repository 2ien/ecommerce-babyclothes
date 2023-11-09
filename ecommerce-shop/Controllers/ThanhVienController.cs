using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class ThanhVienController : Controller
    {
        // GET: ThanhVien
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AuthenLogin()
        {
            return View();
        }
    }
}