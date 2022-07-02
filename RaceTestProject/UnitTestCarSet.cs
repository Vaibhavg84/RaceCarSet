using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceSetUpLibary;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace RaceTestProject
{
    
    [TestClass]
    public class UnitTestCarSet
    {       
        public ICarSetUp iRaceCar;
        public UnitTestCarSet()
        {            
            iRaceCar = new RaceCarSetup();
        }
        [TestMethod]
        [Description("Test if no input given to the method")]
        public void TestSetCarRanks_NoInput() 
        {
            var mock = new Mock<List<RaceCarConfiguration>>();            
            List<RaceCarConfiguration> raceCarConfigurations = new List<RaceCarConfiguration>();
            var response = iRaceCar.SetCarRanks(mock.Object);
            Assert.IsNotNull(response);
        }
        [TestMethod]
        [Description("Test if input configurations having all 0 values")]
        public void TestSetCarRanks_ZeroInput()
        {
            List<RaceCarConfiguration> raceCarConfigurations = new List<RaceCarConfiguration>();
            Mock<ICarDummyConfiguration> mockCarSetUp = new Mock<ICarDummyConfiguration>();
            mockCarSetUp.Setup(a => a.DummyObjects()).Returns(new RaceCarConfiguration() { FuelCapacity = 0, OneLapFuelConsumption = 0, OneLapCompletionTime = 0 });
            raceCarConfigurations.Add(mockCarSetUp.Object.DummyObjects());
            var response = iRaceCar.SetCarRanks(raceCarConfigurations);
            Assert.IsNotNull(response);
        }
        [TestMethod]
        [Description("Test to validate Race Compliation time calulations")]
        public void TestSetCarRanks_RaceComplitionTime()
        {
            Mock<ICarDummyConfiguration> mockCarSetUp = new Mock<ICarDummyConfiguration>();
            mockCarSetUp.Setup(a=>a.DummyObjects()).Returns(new RaceCarConfiguration() { FuelCapacity = 180, OneLapFuelConsumption = 4, OneLapCompletionTime = 30 });      

            List<RaceCarConfiguration> raceCarConfigurations = new List<RaceCarConfiguration>();
            raceCarConfigurations.Add(mockCarSetUp.Object.DummyObjects());
            ICarSetUp carSetUp = new RaceCarSetup();

            var response1 = carSetUp.SetCarRanks(raceCarConfigurations);  

            Assert.AreEqual(response1[0].RaceCompletionTime, 1506);
        }
        [TestMethod]
        [Description("Test to validate first rank")]
        public void TestSetCarRanks_RaceComplitionTimeRankFirst()
        {
            List<RaceCarConfiguration> raceCarConfigurations = new List<RaceCarConfiguration>();

            Mock<ICarDummyConfiguration> mockCarSetUp = new Mock<ICarDummyConfiguration>();
            mockCarSetUp.Setup(a => a.DummyObjects()).Returns(new RaceCarConfiguration() { FuelCapacity = 180, OneLapFuelConsumption = 4, OneLapCompletionTime = 30 });
            raceCarConfigurations.Add(mockCarSetUp.Object.DummyObjects());
            mockCarSetUp = new Mock<ICarDummyConfiguration>();
            mockCarSetUp.Setup(a => a.DummyObjects()).Returns(new RaceCarConfiguration() { FuelCapacity = 200, OneLapFuelConsumption = 4, OneLapCompletionTime = 30 });
            raceCarConfigurations.Add(mockCarSetUp.Object.DummyObjects());            
            var response = iRaceCar.SetCarRanks(raceCarConfigurations);            
            Assert.AreEqual(response[0].Rank, 1);
        }
        [TestMethod]
        [Description("Test to validate second rank")]
        public void TestSetCarRanks_RaceComplitionTimeRankSecond()
        {
            List<RaceCarConfiguration> raceCarConfigurations = new List<RaceCarConfiguration>();

            Mock<ICarDummyConfiguration> mockCarSetUp = new Mock<ICarDummyConfiguration>();
            mockCarSetUp.Setup(a => a.DummyObjects()).Returns(new RaceCarConfiguration() { FuelCapacity = 180, OneLapFuelConsumption = 4, OneLapCompletionTime = 30 });
            raceCarConfigurations.Add(mockCarSetUp.Object.DummyObjects());
            mockCarSetUp = new Mock<ICarDummyConfiguration>();
            mockCarSetUp.Setup(a => a.DummyObjects()).Returns(new RaceCarConfiguration() { FuelCapacity = 200, OneLapFuelConsumption = 4, OneLapCompletionTime = 30 });
            raceCarConfigurations.Add(mockCarSetUp.Object.DummyObjects());
            var response = iRaceCar.SetCarRanks(raceCarConfigurations);

            Assert.AreEqual(response[1].Rank, 2);
        }
        
    }
}