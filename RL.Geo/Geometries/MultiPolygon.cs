using System.Collections.Generic;
using System.Linq;
using RL.Geo.Abstractions.Interfaces;
using RL.Geo.Linq;
using RL.Geo.Measure;

namespace RL.Geo.Geometries
{
    public class MultiPolygon : GeometryCollection, IMultiSurface
    {
        public new static readonly MultiPolygon Empty = new MultiPolygon();

        public MultiPolygon()
        {
        }

        public MultiPolygon(IEnumerable<Polygon> polygons)
            : base(polygons.Cast<IGeometry>())
        {
        }

        public MultiPolygon(params Polygon[] polygons)
            : base(polygons.Cast<IGeometry>())
        {
        }

        public Area GetArea()
        {
            return Geometries.Cast<Polygon>().Sum(x => x.GetArea());
        }
    }
}