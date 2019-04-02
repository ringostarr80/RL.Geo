namespace RL.Geo.Measure
{
    public enum DistanceUnit
    {
        [Unit("m", 1)]
        M = 0,
        [Unit("nm", 1852)]
        Nm = 1,
        [Unit("km", 1000)]
        Km = 2,
        [Unit("mi", 1609.34)]
        Mile = 3,
        [Unit("ft", 0.3048)]
        Ft = 4
    }
}