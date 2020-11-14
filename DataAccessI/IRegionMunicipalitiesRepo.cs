using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess
{
   public interface IRegionMunicipalitiesRepo
    {
        Task<bool> DeleteRegMunByMunicipality(Guid idMunicipality);
        Task<bool> DeleteRegMunByRegion(Guid idRegion);
        Task<int> GetNumberOfMunicipalitiesByRegion(Guid idRegion);
        
    }
}
