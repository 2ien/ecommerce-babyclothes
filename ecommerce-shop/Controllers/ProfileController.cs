//using System;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using ecommerce_shop.Models;
//using System.Security.Claims;

//namespace ecommerce_shop.Controllers
//{
//    public class ProfileController : Controller
//    {
//        // GET: /Profile/ViewProfile/5
//        public ActionResult ViewProfile(int id)
//        {
//            // Không kiểm tra quyền sở hữu ID 
//            var cookie = Request.Cookies["jwtToken"];
//            if (cookie == null)
//            {
//                return RedirectToAction("Login", "Account");
//            }

//            var principal = JwtManager.GetPrincipal(cookie.Value);
//            if (principal == null || !principal.Identity.IsAuthenticated)
//            {
//                return RedirectToAction("Login", "Account");
//            }

//            using (var db = new DBQLEcommerceShopEntities())
//            {
//                var user = db.Users.FirstOrDefault(u => u.ID == id);
//                if (user == null)
//                {
//                    return HttpNotFound("Không tìm thấy người dùng.");
//                }

//                return View("Profile", user);
//            }
//        }
//    }
//}
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerce_shop.Models;
using System.Security.Claims;

namespace ecommerce_shop.Controllers
{
    public class ProfileController : Controller
    {
        // GET: /Profile/ViewProfile/5
        public ActionResult ViewProfile(int id)
        {
            // Kiểm tra cookie jwtToken
            var cookie = Request.Cookies["jwtToken"];
            if (cookie == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var principal = JwtManager.GetPrincipal(cookie.Value);
            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy ID người dùng từ claim (giả sử sử dụng ClaimTypes.NameIdentifier)
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int currentUserId))
            {
                return RedirectToAction("Login", "Account");
            }
            
            // Kiểm tra nếu ID của người dùng xác thực không khớp với ID được yêu cầu
            if (id != currentUserId)
            {
                return new HttpUnauthorizedResult("Bạn không có quyền truy cập thông tin của người dùng khác.");
            }

            using (var db = new DBQLEcommerceShopEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.ID == id);
                if (user == null)
                {
                    return HttpNotFound("Không tìm thấy người dùng.");
                }

                return View("Profile", user);
            }
        }
    }
}

