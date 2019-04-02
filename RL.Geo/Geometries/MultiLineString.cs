using System.Collections.Generic;
using System.Linq;
using RL.Geo.Abstractions.Interfaces;
using RL.Geo.Linq;
using RL.Geo.Measure;

namespace RL.Geo.Geometries
{
    public class MultiLineString : GeometryCollection, IMultiCurve
    {
        public new static readonly MultiLineString Empty = new MultiLineString();

        public MultiLineString()
        {
        }

        public MultiLineString(IEnumerable<LineString> lineStrings) 
            : base(lineStrings.Cast<IGeometry>())
        {
        }

        public MultiLineString(params LineString[] lineStrings)
            : base(lineStrings.Cast<IGeometry>())
        {
        }

        public Distance GetLength()
        {
            return Geometries.Cast<LineString>().Sum(x => x.GetLength());
        }
    }
}