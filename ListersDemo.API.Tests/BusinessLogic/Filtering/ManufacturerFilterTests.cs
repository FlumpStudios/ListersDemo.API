using ListersDemo.API.Common;
using ListersDemo.API.Common.Model;
using ListersDemo.API.Tests.MockData;
using ListersDemo.Services.BusinessLogic.Filtering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ListersDemo.API.Tests.BusinessLogic.Filtering
{
    [TestClass]
    public class ManufacturerFilterTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            mockRepository.VerifyAll();
        }

        private ManufacturerFilter CreateManufacturerFilter()
        {
            return new ManufacturerFilter();
        }

        [TestMethod]
        public void Filter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateManufacturerFilter();
            IEnumerable<Vehicle> vehicles = MockDataModels.MockVehicleDataList();
            Manufacturer manufacturer = MockDataModels.MockManufacturerModel(); ;

            // Act
            var result = unitUnderTest.Filter(
                vehicles,
                manufacturer);

            // Assert
            var expected = 2;
            var actual = result.Count();

            if (actual != expected) Assert.Fail(string.Format("Incorrect number of results returned. Was expecting {0} and returned {1}", expected, actual));

        }
    }
}
