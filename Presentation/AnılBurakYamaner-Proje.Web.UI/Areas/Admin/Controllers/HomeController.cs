using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Controllers
{
    //Authorize attribute'unu kullanarak bu sayfaya sadece CoreIdentity yapımızdan geçmiş kullanıcıların ulaşabileceğini belirtiyoruz.
    //Bir area oluşturduğunuzda bu area içerisine eklediğiniz controller dosyaları Net Framework'de ki
    //gibi buraya ait olmuyor, Her bir controller'ın üzerine hangi area'ya ait olduğunu Area Attribute'u ile belirtmek zorundayız.
    [Area("Admin"), Authorize(AuthenticationSchemes = "AdminScheme")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "IsAdmin")?.Value != "True")
                return Redirect("/Home/Index");
            return View();
        }
    }
}
