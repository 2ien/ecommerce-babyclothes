using System.IO;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class BackupController : Controller
    {
        // GET: /backup/Dadmom.jpg
        public ActionResult Dadmom()
        {
            var path = Server.MapPath("~/App_Data/Dadmom.jpg");

            if (!System.IO.File.Exists(path))
                return HttpNotFound("Không tìm thấy hình ảnh");

            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "application/octet-stream", "Dadmom.jpg");  // ép tải về
        }

    }
}
