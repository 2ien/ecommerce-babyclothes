using ecommerce_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce_shop.Areas.Admin.Controllers
{
    public class NhaCungCapController : Controller
    {
        // GET: Admin/NhaCungCap
        public ActionResult DanhSach()
        {
            mapNhaCungCap map = new mapNhaCungCap();
            var data = map.DanhSach();
            return View();
        }
    }
}