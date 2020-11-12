using AutoMapper;
using IServices;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Views.MapperFilter;
using Views.ViewModels;

namespace Views.Controllers
{
    public class RegionController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPlacesService _placesService;

        public RegionController(IPlacesService placesService)
        {
            _placesService = placesService;
            mapper = AutoMapperConfig.Mapper;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var regions = await _placesService.GetAllRegions();
            var res = mapper.Map<List<Region>, List<RegionViewModel>>(regions);
            return View(res);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult NewRegion() {
            RegionViewModel region = new RegionViewModel();
            return PartialView("_CreateRegion", region);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateRegion(RegionViewModel region) {
            if (ModelState.IsValid) {
                var res = mapper.Map<RegionViewModel, Region>(region);
                var isSaved = await _placesService.SaveRegion(res);
                return RedirectToAction("Index");
            }
            return PartialView("_CreateRegion", region);
        }
    }
}