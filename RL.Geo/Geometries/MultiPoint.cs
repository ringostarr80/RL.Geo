using System.Collections.Generic;
using System.Linq;
using RL.Geo.Abstractions.Interfaces;

namespace RL.Geo.Geometries
{
    public class MultiPoint : GeometryCollection
    {
        public new static readonly MultiPoint Empty = new MultiPoint();

        public MultiPoint()
        {
        }

        public MultiPoint(IEnumerable<Point> points)
            : base(points.Cast<IGeometry>())
        {
        }

        public MultiPoint(params Point[] points)
            : base(points.Cast<IGeometry>())
        {
        }
    }
}