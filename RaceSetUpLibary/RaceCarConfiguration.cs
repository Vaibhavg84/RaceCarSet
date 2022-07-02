namespace RaceSetUpLibary
{
    public class RaceCarConfiguration : ICarDummyConfiguration
    {
        public double FuelCapacity
        { get; set; }
        public double OneLapCompletionTime
        { get; set; }
        public double OneLapFuelConsumption
        { get; set; }

        public RaceCarConfiguration DummyObjects()
        {
            RaceCarConfiguration obj = new RaceCarConfiguration();
            Random ran = new ();
            obj.FuelCapacity = ran.Next(150, 300);
            obj.OneLapFuelConsumption = ran.Next(3, 10);
            obj.OneLapCompletionTime = ran.Next(30, 90);
            return obj;
        }
    }
}
