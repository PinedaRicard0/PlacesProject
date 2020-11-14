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
    [AllowAnonymous]
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
        public async Task<ActionResult> Index()
        {
            var regions = await _placesService.GetAllRegions();
            var res = mapper.Map<List<Region>, List<RegionViewModel>>(regions);
            IndexRegionViewModel indexViewModel = new IndexRegionViewModel();
            foreach (var item in res) {
                item.Municipalities = await _placesService.GetNumberOfMunicipalitiesByRegion(item.Id);
            }
            indexViewModel.ListRegions = res;
            indexViewModel.Region = new RegionViewModel();
            indexViewModel.IsError = false;
            indexViewModel.IsEditing = false;
            return View(indexViewModel);
        }

        [HttpPost]
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
            foreach (var item in reg)
            {
                item.Municipalities = await _placesService.GetNumberOfMunicipalitiesByRegion(item.Id);
            }
            indexViewModel.ListRegions = reg;
            indexViewModel.Region = region;
            indexViewModel.IsError = true;
            indexViewModel.IsEditing = false;
            return View("Index", indexViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> EditRegion(string id) {
            var regions = await _placesService.GetAllRegions();
            var res = mapper.Map<List<Region>, List<RegionViewModel>>(regions);
            foreach (var item in res)
            {
                item.Municipalities = await _placesService.GetNumberOfMunicipalitiesByRegion(item.Id);
            }
            IndexRegionViewModel indexViewModel = new IndexRegionViewModel();
            indexViewModel.ListRegions = res;
            var region = res.Where(r => r.Id.ToString().Equals(id)).FirstOrDefault();
            indexViewModel.Region = region;
            indexViewModel.IsEditing = true;
            indexViewModel.IsError = false;
            return View("Index", indexViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditRegion(RegionViewModel region)
        {
            if (ModelState.IsValid)
            {
                var res = mapper.Map<RegionViewModel, Region>(region);
                var isEdited = await _placesService.EditRegion(res);
                if (isEdited)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("region.Code", "El código ya está registrado");
            }
            var regions = await _placesService.GetAllRegions();
            var reg = mapper.Map<List<Region>, List<RegionViewModel>>(regions);
            foreach (var item in reg)
            {
                item.Municipalities = await _placesService.GetNumberOfMunicipalitiesByRegion(item.Id);
            }
            IndexRegionViewModel indexViewModel = new IndexRegionViewModel();
            indexViewModel.ListRegions = reg;
            indexViewModel.Region = region;
            indexViewModel.IsError = true;
            indexViewModel.IsEditing = true;
            return View("Index", indexViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> DeleteRegion(string regionId) {
            if (regionId != null || !regionId.Equals("")) {
                await _placesService.DeleteRegion(regionId);
            }
            return RedirectToAction("Index");
        }
    }
}