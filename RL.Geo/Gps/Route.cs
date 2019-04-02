using System.Collections.Generic;
using RL.Geo.Abstractions.Interfaces;
using RL.Geo.Geometries;
using RL.Geo.Gps.Metadata;
using RL.Geo.Measure;

namespace RL.Geo.Gps
{
    public class Route : IRavenIndexable, IHasLength
    {
        public Route()
        {
            Metadata = new RouteMetadata();
            Coordinates = new List<Coordinate>();
        }

        public RouteMetadata Metadata { get; private set; }
        public List<Coordinate> Coordinates { get; set; }

        public LineString ToLineString()
        {
            return new LineString(Coordinates);
        }

        ISpatial4nShape IRavenIndexable.GetSpatial4nShape()
        {
            return ToLineString();
        }

        public Distance GetLength()
        {
            return ToLineString().GetLength();
        }
    }
}