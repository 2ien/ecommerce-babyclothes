using ecommerce_shop.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ecommerce_shop.App_Start
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        public int idChucNang { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // 1. Kiểm tra đã đăng nhập chưa
            NhanVien nvSession = (NhanVien)HttpContext.Current.Session["user"];
            if (nvSession != null)
            {
                DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();

                //  Nếu là ID chức năng 5 thì cho qua luôn (Admin full quyền)
                var isAdmin = db.PhanQuyens.Any(m => m.idNhanVien == nvSession.ID && m.idChucNang == 5);
                if (isAdmin)
                {
                    return;
                }

                // 2. Kiểm tra quyền thông thường
                var hasPermission = db.PhanQuyens.Any(m => m.idNhanVien == nvSession.ID && m.idChucNang == idChucNang);
                if (hasPermission)
                {
                    return;
                }

                // Không có quyền -> redirect Error
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "Controller", "Error" },
                    { "action", "Error" },
                    { "area", "Admin" },
                    { "returnUrl", returnUrl }
                });
            }
            else
            {
                // Chưa đăng nhập
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "Controller", "HomeAdmin" },
                    { "action", "Login" },
                    { "area", "Admin" },
                    { "returnUrl", returnUrl }
                });
            }
        }
    }
}
