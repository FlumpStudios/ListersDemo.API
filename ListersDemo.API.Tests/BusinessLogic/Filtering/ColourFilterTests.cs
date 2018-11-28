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
    public class ColourFilterTests
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

        private ColourFilter CreateColourFilter()
        {
            return new ColourFilter();
        }
        /// <summary>
        /// Shallow test for filters. Would add further coverage on full project.
        /// </summary>
        [TestMethod]
        public void Filter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateColourFilter();
            IEnumerable<Vehicle> vehicles = MockDataModels.MockVehicleDataList();
            Colour colour = MockDataModels.MockColourModel();
          

            // Act
            var result = unitUnderTest.Filter(
                vehicles,
                colour);

            var expected = 2;
            var actual = result.Count();

            if (actual != expected) Assert.Fail(string.Format("Incorrect number of results returned. Was expecting {0} and returned {1}",expected, actual));
            
        }
    }
}
