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
        Task<bool> SaveRegion(Region region);
        Task<bool> existRegionByCode(int code);
    }
}
