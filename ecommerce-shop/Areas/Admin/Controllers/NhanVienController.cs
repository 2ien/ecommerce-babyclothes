using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerce_shop.Models;
using ecommerce_shop.App_Start;
namespace ecommerce_shop.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult DanhSach()
        {        
            return View();
        }
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult ThemMoi()
        {         
            return View();
        }
        [AdminAuthorize(idChucNang = 3)]
        public ActionResult CapNhat()
        {         
            return View();
        }
        [AdminAuthorize(idChucNang = 4)]
        public ActionResult Xoa()
        {           
            return View();
        }
    }
}