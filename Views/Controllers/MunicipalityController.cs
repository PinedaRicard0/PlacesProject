using AutoMapper;
using IServices;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Views.MapperFilter;
using Views.ViewModels;

namespace Views.Controllers
{
    [AllowAnonymous]
    public class MunicipalityController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPlacesService _placesService;

        public MunicipalityController(IPlacesService placesService)
        {
            _placesService = placesService;
            mapper = AutoMapperConfig.Mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var municipalities = await _placesService.GetAllMunicipalities();
            var res = mapper.Map<List<Municipality>, List<MunicipalityViewModel>>(municipalities);
            IndexMunicipalityViewModel indexViewModel = new IndexMunicipalityViewModel();
            indexViewModel.ListMunicipalities = res;
            indexViewModel.Municipality = new MunicipalityViewModel();
            indexViewModel.IsError = false;
            indexViewModel.IsEditing = false;
            return View(indexViewModel);

        }

        [HttpPost]
        public async Task<ActionResult> CreateMunicipality(MunicipalityViewModel municipality) {
            if (ModelState.IsValid)
            {
                var res = mapper.Map<MunicipalityViewModel, Municipality>(municipality);
                var isSaved = await _placesService.SaveMunicipality(res);
                if (isSaved)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("municipality.Code", "El código ya está registrado");
            }
            var municipalities = await _placesService.GetAllMunicipalities();
            var reg = mapper.Map<List<Municipality>, List<MunicipalityViewModel>>(municipalities);
            IndexMunicipalityViewModel indexViewModel = new IndexMunicipalityViewModel();
            indexViewModel.ListMunicipalities = reg;
            indexViewModel.Municipality = municipality;
            indexViewModel.IsError = true;
            indexViewModel.IsEditing = false;
            return View("Index", indexViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> EditMunicipality(string id)
        {
            var municipalities = await _placesService.GetAllMunicipalities();
            var res = mapper.Map<List<Municipality>, List<MunicipalityViewModel>>(municipalities);
            IndexMunicipalityViewModel indexViewModel = new IndexMunicipalityViewModel();
            indexViewModel.ListMunicipalities = res;
            var municipality = res.Where(m => m.Id.ToString().Equals(id)).FirstOrDefault();
            indexViewModel.Municipality = municipality;
            indexViewModel.IsEditing = true;
            indexViewModel.IsError = false;
            return View("Index", indexViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditMunicipality(MunicipalityViewModel municipality)
        {
            if (ModelState.IsValid)
            {
                var res = mapper.Map<MunicipalityViewModel, Municipality>(municipality);
                var isEdited = await _placesService.EditMunicipality(res);
                if (isEdited)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("municipality.Code", "El código ya está registrado");
            }
            var municipalities = await _placesService.GetAllMunicipalities();
            var mun = mapper.Map<List<Municipality>, List<MunicipalityViewModel>>(municipalities);
            IndexMunicipalityViewModel indexViewModel = new IndexMunicipalityViewModel();
            indexViewModel.ListMunicipalities = mun;
            indexViewModel.Municipality = municipality;
            indexViewModel.IsError = true;
            indexViewModel.IsEditing = true;
            return View("Index", indexViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> DeleteMunicipality(string municipalityId)
        {
            if (municipalityId != null || !municipalityId.Equals(""))
            {
                await _placesService.DeleteMunicipality(municipalityId);
            }
            return RedirectToAction("Index");
        }


    }
}