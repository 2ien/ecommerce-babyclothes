using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class GuideController : Controller
    {
        // GET: /Guide/Read?doc=filename
        public ActionResult Read(string doc)
        {
            if (string.IsNullOrEmpty(doc))
            {
                return Content("Thiếu tên tài liệu.");
            }

            // Decode URL để kiểm tra ký tự thực sự
            string decodedDoc = HttpUtility.UrlDecode(doc);



            try
            {
                // Chỉ cho phép đọc file trong thư mục /Docs
                string path = Server.MapPath("~/Docs/" + decodedDoc);
                string content = System.IO.File.ReadAllText(path);
                return Content(content, "text/plain");
            }
            catch (Exception ex)
            {
                return Content("Lỗi khi đọc file: " + ex.Message);
            }
        }
    }
}
//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Web;
//using System.Web.Mvc;

//namespace ecommerce_shop.Controllers
//{
//    public class GuideController : Controller
//    {
//        // GET: /Guide/CmdTest?doc=filename
//        // Command Injection (demo) xài chết ráng chi.
//        public ActionResult CmdTest(string doc)
//        {
//            if (string.IsNullOrEmpty(doc))
//            {
//                return Content("Thiếu tên file.");
//            }

//            // Giả lập: decode URL
//            string decodedDoc = HttpUtility.UrlDecode(doc);

//            try
//            {
//                // Gọi hàm thực thi lệnh với param (có lỗ hổng)
//                string output = RunCmd(decodedDoc);
//                return Content($"Kết quả:\n{output}", "text/plain");
//            }
//            catch (Exception ex)
//            {
//                return Content("Lỗi khi thực thi lệnh: " + ex.Message);
//            }
//        }

//        // Hàm thực thi lệnh hệ thống (dễ bị Command Injection)
//        private string RunCmd(string param)
//        {
//            // Ví dụ: ghép trực tiếp param vào lệnh "type <param>"
//            // => Attacker có thể chèn & dir, ; ls -la, ...
//            Process proc = new Process();
//            proc.StartInfo.FileName = "cmd.exe";
//            proc.StartInfo.Arguments = "/c type " + param;

//            proc.StartInfo.UseShellExecute = false;
//            proc.StartInfo.RedirectStandardOutput = true;
//            proc.StartInfo.RedirectStandardError = true;

//            proc.Start();

//            string output = proc.StandardOutput.ReadToEnd();
//            string error = proc.StandardError.ReadToEnd();
//            proc.WaitForExit();

//            // Nối error nếu có
//            if (!string.IsNullOrEmpty(error))
//            {
//                output += "\nError:\n" + error;
//            }

//            return output;
//        }
//    }
//}
