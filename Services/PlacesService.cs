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
        //private readonly DataAccess _dataAccess;

        public PlacesService()
        {

        }

        public Task<List<Region>> GetAllRegions()
        {
            throw new NotImplementedException();
        }

        public Municipality GetMunicipality(int municipalityCode)
        {
            return null;

        }
    }
}
