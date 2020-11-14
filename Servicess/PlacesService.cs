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
        private readonly IRegionMunicipalitiesRepo _regionMunicipalitiesRepo;

        public PlacesService(IRegionRepo regionRepo, IMunicipalityRepo municipalityRepo, IRegionMunicipalitiesRepo regionMunicipalitiesRepo)
        {
            _regionRepo = regionRepo;
            _municipalityRepo = municipalityRepo;
            _regionMunicipalitiesRepo = regionMunicipalitiesRepo;
        }

        public async Task<List<Region>> GetAllRegions()
        {
            var res = await _regionRepo.GetRegions();
            return res;
        }

        public async Task<int> GetNumberOfMunicipalitiesByRegion(Guid regionId) {
            return await _regionMunicipalitiesRepo.GetNumberOfMunicipalitiesByRegion(regionId);
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

        public async Task<bool> SaveMunicipality(Municipality municipality)
        {
            bool exist = await _municipalityRepo.ExistMunicipalityByCode(municipality.Code);
            if (!exist)
            {
                return await _municipalityRepo.SaveMunicipality(municipality);
            }
            return false;
        }

        public async Task DeleteMunicipality(string municipalityId)
        {
            Guid id = Guid.Parse(municipalityId);
            await _municipalityRepo.DeleteMunicipalityById(id);
        }

        public async Task<bool> EditMunicipality(Municipality municipality)
        {
            Municipality storeMunipaciliy = await _municipalityRepo.GetMunicipalityByCode(municipality.Code);
            if (storeMunipaciliy == null || storeMunipaciliy.Id == municipality.Id)
            {
                if (await _municipalityRepo.EditMunicipality(municipality) && municipality.Status == "Inactivo") {
                   await _regionMunicipalitiesRepo.DeleteRegMunByMunicipality(municipality.Id);
                }
                return true;
            }
            return false;
        }
    }
}
