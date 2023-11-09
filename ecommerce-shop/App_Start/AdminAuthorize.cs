using ecommerce_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ecommerce_shop.App_Start
{
    public class AdminAuthorize:AuthorizeAttribute
    {
        public  int idChucNang {  get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            #region 1.check session: da dang nhap => cho thuc hien filter
            //Nguoc lai thi tro lai trang dang nhap
            NhanVien nvSession = (NhanVien)HttpContext.Current.Session["user"];
            if (nvSession != null)
            {
                #region 2.check quyen : Co quyen  => cho thuc hien filter
                // nguoc lai bao loi
                DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
                var count = db.PhanQuyens.Count(m => m.idNhanVien == nvSession.ID & m.idChucNang == idChucNang);
                if (count != 0)
                {
                    return;
                }
                else
                {
                    var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                        new
                        {
                            Controller = "Error",
                            action = "Error",
                            area = "Admin",
                            returnUrl = returnUrl.ToString()
                        }));
                }
                #endregion
                return;
            }
            else
            {
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        Controller = "HomeAdmin",
                        action = "Login",
                        area = "Admin",
                        returnUrl = returnUrl.ToString()
                    }));
            }
            #endregion         
        }
    }
}