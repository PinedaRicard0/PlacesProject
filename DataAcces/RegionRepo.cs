using IDataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class RegionRepo : IRegionRepo
    {
        private readonly PlacesContext _context;

        public RegionRepo(PlacesContext context)
        {
            _context = context;
        }

        public async Task<bool> existRegionByCode(int code)
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
    }
}
