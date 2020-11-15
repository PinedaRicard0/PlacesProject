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
            var region = await _placesService.GetRegion(id);
            if (region != null) {
                var regionMunicipalities = await _placesService.GetMunicipalitiesByRegion(region.Id);
                var regionViewModel = mapper.Map<Region, RegionViewModel>(region);
                var listMunicipalities = mapper.Map<List<Municipality>, List<MunicipalityViewModel>>(regionMunicipalities);
                EditRegionViewModel viewModel = new EditRegionViewModel()
                {
                    Region = regionViewModel,
                    Municipalities = listMunicipalities,
                    OriginalName = regionViewModel.Name
                    
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> EditRegion(SaveEditRegionViewModel region)
        {
            bool isEdited = false;
            if (ModelState.IsValid)
            {
                var res = mapper.Map<SaveEditRegionViewModel, Region>(region);
                isEdited = await _placesService.EditRegion(res);
                if (!isEdited)
                {
                    ModelState.AddModelError("region.Code", "El código ya está registrado");
                }
            }
            var regionMunicipalities = await _placesService.GetMunicipalitiesByRegion(region.Id);
            var listMunicipalities = mapper.Map<List<Municipality>, List<MunicipalityViewModel>>(regionMunicipalities);

            RegionViewModel viewRegion = new RegionViewModel()
            {
                Code = region.Code,
                Id = region.Id,
                Name = region.Name
            };

            EditRegionViewModel viewModel = new EditRegionViewModel()
            {
                Region = viewRegion,
                Municipalities = listMunicipalities,
                OriginalName = (isEdited) ? region.Name : region.OriginalName

            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> AddMunicipalities(string regionId, string regionName) {
            var municipalities = await _placesService.GetPossibleMununicipalitiesToAdd(regionId);
            var options = mapper.Map<List<Municipality>, List<MunicipalitySelectionViewModel>>(municipalities);
            AddMunicipalitiesViewModel viewModel = new AddMunicipalitiesViewModel() {
                Region = regionName,
                RegionId = regionId,
                Municipalities = options
            };
            return PartialView("_AddMunicipalities", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddMunicipalities(AddMunicipalitiesViewModel viewModel)
        {
            var regionId = viewModel.RegionId;
            var toAddMunicipalities = viewModel.Municipalities.Where(m => m.IsSelected).ToList();
            var toAdd = mapper.Map<List<MunicipalitySelectionViewModel>, List<Municipality>>(toAddMunicipalities);
            await _placesService.AssociatedMuniciapalities(regionId, toAdd);
            return RedirectToAction("EditRegion", new { id = viewModel.RegionId});
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