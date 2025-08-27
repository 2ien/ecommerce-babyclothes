//using ecommerce_shop.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Razor.Generator;
//using System.Web.Security;

//namespace ecommerce_shop.Areas.Admin.Controllers
//{
//    public class HomeAdminController : Controller
//    {
//        // GET: Admin/HomeAdmin
//        public ActionResult Index()
//        {
//            if (Session["user"] == null)
//            {
//                return RedirectToAction("Login");
//            }
//            return View();
//        }

//        public ActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Login(string username, string password)
//        {
//            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
//            {
//                TempData["Error"] = "Thiếu thông tin đăng nhập";
//                return View();
//            }

//            using (var conn = new System.Data.SqlClient.SqlConnection("Data Source=localhost;Initial Catalog=DBQLEcommerceShop;User ID=webuser;Password=Admin@123;TrustServerCertificate=True"))

//            {
//                conn.Open();

//                // " kiểm tra ID, nhưng inject username và password
//                string query = $@"
//                    DECLARE @UserId INT;
//                    SELECT @UserId = ID FROM NhanVien 
//                    WHERE Username = '{username}' AND Password = '{password}';

//                    SELECT CASE 
//                    WHEN @UserId IS NOT NULL THEN 1
//                    ELSE 0
//                    END";

//                var cmd = new System.Data.SqlClient.SqlCommand(query, conn);
//                int result = Convert.ToInt32(cmd.ExecuteScalar());

//                if (result == 1)
//                {
//                    // Truy vấn lại để lấy object
//                    string userQuery = $@"
//                        SELECT TOP 1 * FROM NhanVien 
//                        WHERE Username = '{username}' AND Password = '{password}'";
//                    var cmd2 = new System.Data.SqlClient.SqlCommand(userQuery, conn);
//                    var reader = cmd2.ExecuteReader();
//                    reader.Read();

//                    var user = new NhanVien
//                    {
//                        ID = (int)reader["ID"],
//                        Username = reader["Username"].ToString(),
//                        Password = reader["Password"].ToString()
//                    };

//                    Session["user"] = user;
//                    return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
//                }
//                else
//                {
//                    TempData["Error"] = "Đăng nhập thất bại";
//                    return View();
//                }
//            }
//        }

//        public ActionResult Logout()
//        {
//            //Xóa session
//            Session.Remove("user");
//            //Xóa session form Authent
//            FormsAuthentication.SignOut();
//            //Trả về login
//            return RedirectToAction("Login");
//        }
//    }
//}
using ecommerce_shop.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ecommerce_shop.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // Sử dụng Entity Framework context (model database) của MVC
        private DBQLEcommerceShopEntities db = new DBQLEcommerceShopEntities();

        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        // GET: Admin/HomeAdmin/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Admin/HomeAdmin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                TempData["Error"] = "Thiếu thông tin đăng nhập";
                return View();
            }

            // Sử dụng Entity Framework để truy xuất dữ liệu
            // Lưu ý: Trong sản xuất, mật khẩu nên được lưu dưới dạng hash
            var user = db.NhanViens.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Đăng nhập thành công: lưu đối tượng user vào Session
                Session["user"] = user;
                return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
            }
            else
            {
                // Đăng nhập thất bại
                TempData["Error"] = "Đăng nhập thất bại";
                return View();
            }
        }

        // GET: Admin/HomeAdmin/Logout
        public ActionResult Logout()
        {
            // Xóa session và đăng xuất khỏi hệ thống
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
