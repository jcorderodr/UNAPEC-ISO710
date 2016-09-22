using System.Web.Mvc;

namespace UNAPECIso710.WebExcelCRUD.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplicacón Universitaria para uso de ficheros Excel mediante un proyecto en la plataforma ASP.NET MVC";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Universidad APEC";

            return View();
        }
    }
}