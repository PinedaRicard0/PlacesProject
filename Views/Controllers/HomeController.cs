using IServices;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public readonly IPlacesService _placesService;

        public HomeController(IPlacesService placesService)
        {
            _placesService = placesService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Regions()
        {
            return View();
        }

        public ActionResult Municipalities()
        {
            return View();
        }
    }
}