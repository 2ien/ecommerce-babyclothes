using System.Text;
using System.Web.Mvc;

namespace ecommerce_shop.Controllers
{
    public class RobotsController : Controller
    {
        [HttpGet]
        public ContentResult Index()
        {
            var content = new StringBuilder();

            content.AppendLine("User-agent: *");
            content.AppendLine("Disallow: /Admin/HomeAdmin");
  

            //có backup ở đây lỗ hổng
            content.AppendLine("/backup/Dadmom");

            content.AppendLine("");
            content.AppendLine("Allow: /");
            content.AppendLine("Sitemap: http://www.shop.com/xxx.xml");

            return Content(content.ToString(), "text/plain", Encoding.UTF8);
        }
    }
}
