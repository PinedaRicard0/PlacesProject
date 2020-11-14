using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IPlacesService
    {
        Task<List<Region>> GetAllRegions();
        Task<bool> SaveRegion(Region region);
        Task<bool> EditRegion(Region region);
        Task DeleteRegion(string regionId);

        Task<List<Municipality>> GetAllMunicipalities();
        Task<bool> SaveMunicipality(Municipality municipality);
        Task DeleteMunicipality(string municipalityId);
        Task<bool> EditMunicipality(Municipality municipality);
    }
}
