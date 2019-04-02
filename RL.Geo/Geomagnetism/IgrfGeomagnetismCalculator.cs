using RL.Geo.Geodesy;
using RL.Geo.Geomagnetism.Models;

namespace RL.Geo.Geomagnetism
{
    public class IgrfGeomagnetismCalculator : GeomagnetismCalculator
    {
        public IgrfGeomagnetismCalculator() : base(IgrfModelFactory.GetModels())
        {
        }

        public IgrfGeomagnetismCalculator(Spheroid spheroid) : base(spheroid, IgrfModelFactory.GetModels())
        {
        }
    }
}