using IDataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class RegionRepo : IRegionRepo
    {
        private readonly PlacesContext _context;
        private readonly IRegionMunicipalitiesRepo _regionMunicipalitiesRepo;

        public RegionRepo(PlacesContext context, IRegionMunicipalitiesRepo regionMunicipalitiesRepo)
        {
            _context = context;
            _regionMunicipalitiesRepo = regionMunicipalitiesRepo;
        }

        public async Task<bool> ExistRegionByCode(int code)
        {
            bool res = await _context.Region.AnyAsync(r => r.Code == code);
            return res;
        }

        public async Task<List<Region>> GetRegions()
        {
            List<Region> res =  await _context.Region.ToListAsync();
            return res;
        }

        public async Task<bool> SaveRegion(Region region)
        {
            _context.Region.Add(region);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Region> GetRegionByCode(int code)
        {
            return await _context.Region.Where(r => r.Code == code).FirstOrDefaultAsync();
        }

        public async Task<bool> EditRegion(Region region)
        {
            _context.Set<Region>().AddOrUpdate(region);
            //_context.Entry(region).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteRegionById(Guid id)
        {
            await _regionMunicipalitiesRepo.DeleteRegMunByRegion(id);
            Region region = new Region { Id = id};
            _context.Entry(region).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
