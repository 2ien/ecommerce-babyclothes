using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class DocumentController : Controller
    {
        // GET: /Document/Import
        // Trang form cho người dùng nhập URL tài liệu (PDF, DOC...)
        [HttpGet]
        public ActionResult Import()
        {
            return View();
        }

        // POST: /Document/Import
        // Nhận URL, tải file về server (SSRF nguy cơ)
        // Đọc nội dung (nếu text-based) hoặc lưu tạm
        [HttpPost]
        public async Task<ActionResult> Import(string docUrl)
        {
            if (string.IsNullOrWhiteSpace(docUrl))
            {
                ViewBag.Error = "Vui lòng nhập URL tài liệu.";
                return View();
            }

            try
            {
                // Tạo HttpClient để tải file từ URL bất kỳ
                using (var client = new HttpClient())
                {
                    // SSRF: Không giới hạn domain/IP/cổng => attacker lợi dụng
                    var docBytes = await client.GetByteArrayAsync(docUrl);

                    // (Tuỳ vào mục đích, ví dụ: Lưu file tạm để xử lý hoặc hiển thị nội dung)
                    string tempPath = Path.Combine(Server.MapPath("~/App_Data"), "tempFile.bin");
                    System.IO.File.WriteAllBytes(tempPath, docBytes);

                    // Ví dụ: hiển thị độ dài file để chứng minh đã tải
                    ViewBag.Message = $"Đã tải thành công {docBytes.Length} byte từ {docUrl}.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi khi tải tài liệu: " + ex.Message;
            }

            return View();
        }
    }
}
