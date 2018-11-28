using AutoMapper;
using ListersDemo.API.Common;
using ListersDemo.API.Common.Model;
using ListersDemo.API.Common.Settings;
using ListersDemo.API.DataContracts.Requests;
using ListersDemo.API.Tests.MockData;
using ListersDemo.API.Tests.TestHelpers;
using ListersDemo.DataAccess;
using ListersDemo.Services;
using ListersDemo.Services.BusinessLogic.Filtering;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListersDemo.API.Tests.Services
{
    [TestClass]
    public class VehicleServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IOptions<AppSettings>> mockOptions;
        private Mock<IMapper> mockMapper;
        private Mock<IVehicleRepository> mockVehicleRepository;
        private Mock<IManufacturerFilter> mockManufacturerFilter;
        private Mock<IColourFilter> mockColourFilter;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockOptions = mockRepository.Create<IOptions<AppSettings>>();
            mockMapper = mockRepository.Create<IMapper>();
            mockManufacturerFilter = mockRepository.Create<IManufacturerFilter>();
            mockColourFilter = mockRepository.Create<IColourFilter>();
            mockVehicleRepository = mockRepository.Create<IVehicleRepository>();
            mockVehicleRepository.Setup(x => x.DeleteVehicle(It.IsAny<string>()));
            mockVehicleRepository.Setup(x => x.AddVechicle(It.IsAny<Vehicle>()));
            mockVehicleRepository.Setup(x => x.GetAllVehicles()).Returns(MockDataModels.MockVehicleDataList);
            mockVehicleRepository.Setup(x => x.GetVehicleById("1")).Returns(Task.FromResult(MockDataModels.MockVehicleData()));
            mockVehicleRepository.Setup(x => x.UpdateVechicle(It.IsAny<Vehicle>()));
            mockVehicleRepository.Setup(x => x.SaveAsync());
            mockVehicleRepository.Setup(x => x.GetSearchedResults(It.IsAny<VehicleRequest>())).Returns(MockDataModels.MockVehicleDataList());
            mockVehicleRepository.Setup(x => x.VehicleExists(It.IsAny<string>())).Returns(true);
            mockManufacturerFilter.Setup(x => x.Filter(It.IsAny<IEnumerable<Vehicle>>(), It.IsAny<Manufacturer>())).Returns(MockDataModels.MockVehicleDataList());
            mockColourFilter.Setup(x => x.Filter(It.IsAny<IEnumerable<Vehicle>>(), It.IsAny<Colour>())).Returns(MockDataModels.MockVehicleDataList());
        }
     

        private VehicleService CreateService()
        {
            return new VehicleService(
                mockOptions.Object,
                mockMapper.Object,
                mockVehicleRepository.Object,
                mockManufacturerFilter.Object,
                mockColourFilter.Object);
        }

        [TestMethod]
        public async Task Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateService();
            Vehicle vehicle = MockDataModels.MockVehicleData();

            // Act
            var result = await unitUnderTest.Create(
                vehicle);

            // Assert
            if (!result) Assert.Fail();
        }

        [TestMethod]
        public void GetAllVehicles_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateService();
            
            // Act
            var Expected = MockDataModels.MockVehicleDataList();
            var Actual = unitUnderTest.Get(MockDataModels.MockVehicleRequest());

            var result = Helpers.CompareCollection(Expected, Actual);
        }

        [TestMethod]
        public async Task UpdateAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateService();
            Vehicle vehicle = MockDataModels.MockVehicleData();

            // Act
            var result = await unitUnderTest.UpdateAsync(
                vehicle);

            // Assert
            if (!result) Assert.Fail();
        }

        [TestMethod]
        public async Task DeleteAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateService();
            string id = "1";

            // Act
            var result = await unitUnderTest.DeleteAsync(
                id);

            // Assert
            if (!result) Assert.Fail();
        }

        [TestMethod]
        public async Task GetAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateService();
            string id = "1";

            // Act
            var expected = await unitUnderTest.GetAsync(
                id);

            var actual = MockDataModels.MockVehicleData();

            if (!Helpers.CompareObject(expected, actual))
            {
                Assert.Fail();
            }
        }

 
    }
    
}
