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

        public PlacesService(IRegionRepo regionRepo)
        {
            _regionRepo = regionRepo;
        }

        public async Task<List<Region>> GetAllRegions()
        {
            var res = await _regionRepo.GetRegions();
            return res;
        }

        public async Task<bool> SaveRegion(Region region)
        {
            bool exist = await _regionRepo.existRegionByCode(region.Code);
            if (!exist)
            {
                return await _regionRepo.SaveRegion(region);
            }
            return false;
        }
    }
}
