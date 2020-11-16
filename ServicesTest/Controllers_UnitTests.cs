
using IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Views.Controllers;

namespace ServicesTest
{
    [TestClass]
    public class Controllers_UnitTests
    {
        private Mock<IPlacesService> _placesServiceMock;

        private MunicipalityController GetMunicipalityController() {
            _placesServiceMock = new Mock<IPlacesService>();
            var municipalityCtrl = new MunicipalityController(_placesServiceMock.Object);
            return municipalityCtrl;
        }

        private RegionController GetRegionController()
        {
            _placesServiceMock = new Mock<IPlacesService>();
            var regionCtrl = new RegionController(_placesServiceMock.Object);
            return regionCtrl;
        }

        [TestMethod]
        public void RequestAllMunicipalities_CallPlacesServiceGetAllMunicipalities()
        {
            var municipalityCtrl = GetMunicipalityController();
            var result = municipalityCtrl.Index();
            _placesServiceMock.Verify(m => m.GetAllMunicipalities(), Times.Once);
        }

        [TestMethod]
        public void RequestAllRegions_CallPlacesServiceGetAllRegion()
        {
            var RegionCtrl = GetRegionController();
            var result = RegionCtrl.Index();
            _placesServiceMock.Verify(m => m.GetAllRegions(), Times.Once);
        }
    }
}
