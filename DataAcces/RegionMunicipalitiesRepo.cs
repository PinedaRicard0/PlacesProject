using IDataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcces
{
    public class RegionMunicipalitiesRepo : IRegionMunicipalitiesRepo
    {
        private readonly PlacesContext _context;

        public RegionMunicipalitiesRepo(PlacesContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteRegMunByMunicipality(Guid idMunicipality)
        {
            var toDeleteItems = await GetRegMunByMunicipality(idMunicipality);
            if (toDeleteItems != null && toDeleteItems.Count() > 0) {
                foreach(var item in toDeleteItems) {
                    _context.Entry(item).State = EntityState.Deleted;
                }
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteRegMunByRegion(Guid idRegion)
        {
            var toDeleteItems = await GetRegMunByRegion(idRegion);
            if (toDeleteItems != null && toDeleteItems.Count() > 0)
            {
                foreach (var item in toDeleteItems)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public Task<int> GetNumberOfMunicipalitiesByRegion(Guid idRegion)
        {
            return _context.RegionMunicipalities.CountAsync(rm => rm.RegionId == idRegion);
        }

        private async Task<List<RegionMunicipalities>> GetRegMunByMunicipality(Guid idMunicipality) {
            return await _context.RegionMunicipalities.Where(rm => rm.MunicipalityId == idMunicipality).ToListAsync();
        }

        private async Task<List<RegionMunicipalities>> GetRegMunByRegion(Guid idRegion)
        {
            return await _context.RegionMunicipalities.Where(rm => rm.RegionId == idRegion).ToListAsync();
        }
    }
}
