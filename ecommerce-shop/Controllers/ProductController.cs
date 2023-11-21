using ecommerce_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Detail()
        { 
            return View();
        }
    }
}