using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess
{
    public interface IMunicipalityRepo
    {
        Task<List<Municipality>> GetMunicipalities();
        Task<bool> SaveMunicipality(Municipality municipality);
        Task<bool> ExistMunicipalityByCode(int code);
        Task DeleteMunicipalityById(Guid id);
        Task<Municipality> GetMunicipalityByCode(int code);
        Task<bool> EditMunicipality(Municipality municipality);
    }
}
