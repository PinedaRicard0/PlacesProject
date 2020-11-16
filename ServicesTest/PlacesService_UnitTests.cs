using IDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest
{
    [TestClass]
    public class PlacesService_UnitTests
    {
        private Mock<IRegionRepo> _regionRepoMock;
        private Mock<IRegionMunicipalitiesRepo> _regionMunicipalityRepoMock;
        private Mock<IMunicipalityRepo> _municipalityRepoMock;

        private PlacesService GetService() {
            _regionRepoMock = new Mock<IRegionRepo>();
            _regionMunicipalityRepoMock = new Mock<IRegionMunicipalitiesRepo>();
            _municipalityRepoMock = new Mock<IMunicipalityRepo>();
            var res = new PlacesService(_regionRepoMock.Object, _municipalityRepoMock.Object, _regionMunicipalityRepoMock.Object);
            return res;
        }


        [TestMethod]
        public void RequestAllMunicipalities_CallMunicipalitiesRepo() {
            PlacesService service = GetService();
            var result = service.GetAllMunicipalities();
            _municipalityRepoMock.Verify(m => m.GetMunicipalities(), Times.Once);
        }

        [TestMethod]
        public void RequestAllMunicipalities_GetAllMunicipalities()
        {
            PlacesService service = GetService();
            var result = service.GetAllMunicipalities();
            Assert.IsInstanceOfType(result, typeof(Task<List<Municipality>>));
        }

    }
}
