using System.Collections.Generic;
using RL.Geo.Abstractions;
using RL.Geo.Abstractions.Interfaces;

namespace RL.Geo.Linq
{
    public class Spatial3DComparer<T> : IEqualityComparer<T> where T : ISpatialEquatable
    {
        public bool Equals(T x, T y)
        {
            return SpatialObject.Equals3D(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode(GeoContext.Current.EqualityOptions.To3D());
        }
    }
}