using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess
{
    public interface IRegionRepo
    {
        Task<List<Region>> GetRegions();
        Task<Region> GetRegionById(Guid regionId);
        
        Task<bool> SaveRegion(Region region);
        Task<bool> ExistRegionByCode(int code);
        Task<Region> GetRegionByCode(int Code);
        Task<bool> EditRegion(Region region);
        Task DeleteRegionById(Guid id);
    }
}
