using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSetUpLibary
{
    public interface ICarSetUp
    {
        List<RaceCarRankDetails> SetCarRanks(List<RaceCarConfiguration> raceCarConfigurations, RaceTrackConfiguration _raceTrackConfiguration = null);
    }
}
