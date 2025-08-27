using ecommerce_shop.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class AccountController : Controller
    {
        private DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();
        // GET: /Account/ForgotPassword
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        public ActionResult ForgotPassword(string username, string email)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Email == email);

            if (user == null)
            {
                ViewBag.Error = "Không tìm thấy tài khoản với thông tin đã cung cấp.";
                return View();
            }

            // Tạo mật khẩu mới (giả lập)
            string newPassword = Guid.NewGuid().ToString().Substring(0, 8); // ví dụ: "a1b2c3d4"
            user.Password = newPassword;

            db.SaveChanges();

            // Hiển thị mật khẩu mới trên View (không nên dùng thật, chỉ giả lập test)
            ViewBag.NewPassword = newPassword;
            return View();
        }

        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = db.Users.FirstOrDefault(u =>
                    u.Username == model.Username &&
                    u.Password == model.Password); // plaintext password

                if (user == null)
                {
                    model.LoginErrorMessage = "Tài khoản hoặc mật khẩu sai";
                    return View(model);
                }

                // Tạo JWT chứa username và ID
                var token = JwtManager.GenerateToken(user.Username, user.ID);

                // Lưu JWT vào cookie
                HttpCookie jwtCookie = new HttpCookie("jwtToken", token)
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Add(jwtCookie);

                if (Request.IsAjaxRequest() || (Request.Headers["Accept"]?.Contains("application/json") ?? false))
                {
                    return Json(new { success = true, message = "Đăng nhập thành công", token = token });
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                model.LoginErrorMessage = "Lỗi hệ thống: " + ex.Message;
                return View(model);
            }
        }

        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var check = db.Users.FirstOrDefault(u => u.Username == model.Username);
            if (check != null)
            {
                model.RegisterErrorMessage = "Tài khoản đã tồn tại";
                return View(model);
            }

            var newUser = new User
            {
                Username = model.Username,
                Password = model.Password // lưu plaintext
            };

            db.Configuration.ValidateOnSaveEnabled = false;
            db.Users.Add(newUser);
            db.SaveChanges();

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["jwtToken"] != null)
            {
                var cookie = new HttpCookie("jwtToken")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ProtectedData()
        {
            try
            {
                string token = null;
                var authHeader = Request.Headers["Authorization"];

                if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
                {
                    token = authHeader.Substring("Bearer ".Length).Trim();
                }
                else
                {
                    var cookie = Request.Cookies["jwtToken"];
                    if (cookie != null)
                        token = cookie.Value;
                }

                if (string.IsNullOrEmpty(token))
                    return Json(new { success = false, message = "Thiếu token" }, JsonRequestBehavior.AllowGet);

                var principal = JwtManager.GetPrincipal(token);
                if (principal == null)
                    return Json(new { success = false, message = "Token không hợp lệ" }, JsonRequestBehavior.AllowGet);

                var username = principal.Identity.Name;

                return Json(new
                {
                    success = true,
                    message = $"Chào {username}, bạn đã xác thực thành công!",
                    protectedValue = "đi một ngày đàng, học 2 buổi"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Lỗi hệ thống: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
