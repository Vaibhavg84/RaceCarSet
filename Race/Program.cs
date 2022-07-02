
// Car SetUp Library Usage Example

RaceSetUpLibary.ICarSetUp objCarSetUp = new RaceSetUpLibary.RaceCarSetup();
RaceSetUpLibary.RaceCarConfiguration objRaceCarconfiguration = new RaceSetUpLibary.RaceCarConfiguration();
List<RaceSetUpLibary.RaceCarConfiguration> lstRaceCars = new List<RaceSetUpLibary.RaceCarConfiguration>();
for (int i= 0; i < 10; i++)
{
    lstRaceCars.Add(objRaceCarconfiguration.DummyObjects());
}
var Response = objCarSetUp.SetCarRanks(lstRaceCars);
foreach(RaceSetUpLibary.RaceCarRankDetails carDetails in Response)
{
    Console.WriteLine("Car Rank: " + carDetails.Rank.ToString());
    Console.WriteLine("Car Race Completion Time: " + carDetails.RaceCompletionTime.ToString());
    Console.WriteLine("Car Details: -----");
    Console.WriteLine("Car Fuel Capacity: " + carDetails.RaceCarConfiguration.FuelCapacity.ToString());
    Console.WriteLine("Car Lap Completion Time: " + carDetails.RaceCarConfiguration.OneLapCompletionTime.ToString());
    Console.WriteLine("Car Lap Fuel Consumption: " + carDetails.RaceCarConfiguration.OneLapFuelConsumption.ToString());
    Console.WriteLine("-------------------------------------------------------------------------");
}





