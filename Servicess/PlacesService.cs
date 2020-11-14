using IDataAccess;
using IServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PlacesService : IPlacesService
    {
        private readonly IRegionRepo _regionRepo;
        private readonly IMunicipalityRepo _municipalityRepo;

        public PlacesService(IRegionRepo regionRepo, IMunicipalityRepo municipalityRepo)
        {
            _regionRepo = regionRepo;
            _municipalityRepo = municipalityRepo;
        }

        public async Task<List<Region>> GetAllRegions()
        {
            var res = await _regionRepo.GetRegions();
            return res;
        }

        public async Task<bool> SaveRegion(Region region)
        {
            bool exist = await _regionRepo.ExistRegionByCode(region.Code);
            if (!exist)
            {
                return await _regionRepo.SaveRegion(region);
            }
            return false;
        }

        public async Task<bool> EditRegion(Region region)
        {
            Region storeRegion = await _regionRepo.GetRegionByCode(region.Code);
            if (storeRegion == null || storeRegion.Id == region.Id) {
                return await _regionRepo.EditRegion(region);
            }
            return false;
        }

        public async Task DeleteRegion(string regionId)
        {
            Guid id = Guid.Parse(regionId);
            await _regionRepo.DeleteRegionById(id);
        }

        public async Task<List<Municipality>> GetAllMunicipalities()
        {
            var res = await _municipalityRepo.GetMunicipalities();
            return res;
        }
    }
}
