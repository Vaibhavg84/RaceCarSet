namespace RaceSetUpLibary
{
    public class RaceCarSetup : ICarSetUp
    {
        int seed = 0;
        double raceCompletionTime = 0;
        double fuelRequired = 0;
        double totalPitStopRequired = 0;
        double pistStopTime = 0;
        private double CalculateRaceCompletionTime(RaceCarConfiguration _raceCarConfiguration, RaceTrackConfiguration _raceTrackConfiguration)
        {

            if (_raceCarConfiguration != null)
            {
                if(_raceCarConfiguration.FuelCapacity <= 0 || _raceCarConfiguration.OneLapFuelConsumption <= 0)
                {
                    raceCompletionTime = -1;
                }
                else if (_raceTrackConfiguration == null) // if Track Configuration not input by user then taking constant values
                {
                    fuelRequired = Constants.NoOfLaps * _raceCarConfiguration.OneLapFuelConsumption;
                    totalPitStopRequired = Convert.ToDouble(Math.Ceiling(Convert.ToDecimal(fuelRequired / _raceCarConfiguration.FuelCapacity)));
                    pistStopTime = Constants.PitstopTime * totalPitStopRequired;
                    raceCompletionTime = (_raceCarConfiguration.OneLapCompletionTime * Constants.NoOfLaps) + pistStopTime;
                }
                else
                {
                    fuelRequired = _raceTrackConfiguration.NoOfLaps * _raceCarConfiguration.OneLapFuelConsumption;
                    totalPitStopRequired = Convert.ToDouble(Math.Ceiling(Convert.ToDecimal(fuelRequired / _raceCarConfiguration.FuelCapacity)));
                    pistStopTime = _raceTrackConfiguration.PitstopTime * totalPitStopRequired;
                    raceCompletionTime = (_raceCarConfiguration.OneLapCompletionTime * _raceTrackConfiguration.NoOfLaps) + pistStopTime;
                }
            }

            return raceCompletionTime;
        }
        public List<RaceCarRankDetails> SetCarRanks(List<RaceCarConfiguration> raceCarConfigurations, RaceTrackConfiguration _raceTrackConfiguration = null)
        {
            seed = 0;
            List<RaceCarRankDetails> SortedList = new List<RaceCarRankDetails>();
            if (raceCarConfigurations != null && raceCarConfigurations.Count > 0)
            {
                List<RaceCarRankDetails> lstCarDetails = new List<RaceCarRankDetails>();
                foreach (RaceCarConfiguration rcc in raceCarConfigurations)
                {
                    RaceCarRankDetails carDetails = new RaceCarRankDetails();
                    carDetails.RaceCarConfiguration = rcc;
                    try
                    {
                        carDetails.RaceCompletionTime = CalculateRaceCompletionTime(rcc, _raceTrackConfiguration);
                        if(carDetails.RaceCompletionTime == -1)
                        {
                            carDetails.ErrorMessage = "InValid Car Configuration";
                            carDetails.ErrorCode = 100;
                        }
                        lstCarDetails.Add(carDetails);
                    }
                    catch (Exception ex)
                    {
                        carDetails.ErrorMessage = ex.Message;
                        carDetails.ErrorCode = ex.HResult;
                        lstCarDetails.Add(carDetails);
                    }

                }
                SortedList = lstCarDetails.OrderBy(o => o.RaceCompletionTime).ToList();       //Soritng by Race Complition Time         
                SortedList.ForEach(x => x.Rank = nextNumber()); // Assigning Ranks
            }
            return SortedList;
        }
        public int nextNumber()
        {
            seed = seed + 1;
            return seed;
        }
    }
}

