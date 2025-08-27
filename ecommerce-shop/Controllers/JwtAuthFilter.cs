using System.Web;
using System.Web.Mvc;

public class JwtAuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var jwt = HttpContext.Current.Request.Cookies["jwt"]?.Value;
        if (!string.IsNullOrEmpty(jwt))
        {
            var principal = JwtManager.GetPrincipal(jwt);
            if (principal != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        base.OnActionExecuting(filterContext);
    }
}
