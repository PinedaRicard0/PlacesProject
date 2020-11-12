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
    }
}
