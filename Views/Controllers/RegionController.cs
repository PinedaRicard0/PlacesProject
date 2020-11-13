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
            IndexRegionViewModel indexViewModel = new IndexRegionViewModel();
            indexViewModel.ListRegions = res;
            indexViewModel.Region = new RegionViewModel();
            indexViewModel.IsError = false;
            return View(indexViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateRegion(RegionViewModel region) {
            if (ModelState.IsValid) {
                var res = mapper.Map<RegionViewModel, Region>(region);
                var isSaved = await _placesService.SaveRegion(res);
                if (isSaved) { 
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("region.Code", "El código ya está registrado");
            }
            var regions = await _placesService.GetAllRegions();
            var reg = mapper.Map<List<Region>, List<RegionViewModel>>(regions);
            IndexRegionViewModel indexViewModel = new IndexRegionViewModel();
            indexViewModel.ListRegions = reg;
            indexViewModel.Region = region;
            indexViewModel.IsError = true;
            return View("Index", indexViewModel);
        }
    }
}