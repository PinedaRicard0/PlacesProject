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
    public class MunicipalityRepo : IMunicipalityRepo
    {
        private readonly PlacesContext _context;
        private readonly IRegionMunicipalitiesRepo _regionMunicipalitiesRepo;

        public MunicipalityRepo(PlacesContext context, IRegionMunicipalitiesRepo regionMunicipalitiesRepo)
        {
            _context = context;
            _regionMunicipalitiesRepo = regionMunicipalitiesRepo;

        }

        public async Task<bool> ExistMunicipalityByCode(int code)
        {
            bool res = await _context.Municipality.AnyAsync(m => m.Code == code);
            return res;
        }

        public async Task<List<Municipality>> GetMunicipalities()
        {
            List<Municipality> res = await _context.Municipality.ToListAsync();
            return res;
        }

        public async Task<bool> SaveMunicipality(Municipality municipality)
        {
            _context.Municipality.Add(municipality);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteMunicipalityById(Guid id)
        {
            await _regionMunicipalitiesRepo.DeleteRegMunByMunicipality(id);
            Municipality municipality  = new Municipality { Id = id };
            _context.Entry(municipality).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Municipality> GetMunicipalityByCode(int code)
        {
            return await _context.Municipality.Where(m => m.Code == code).FirstOrDefaultAsync();
        }

        public async Task<bool> EditMunicipality(Municipality municipality)
        {
            _context.Set<Municipality>().AddOrUpdate(municipality);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
