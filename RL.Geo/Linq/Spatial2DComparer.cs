﻿using System.Collections.Generic;
using RL.Geo.Abstractions;
using RL.Geo.Abstractions.Interfaces;

namespace RL.Geo.Linq
{
    public class Spatial2DComparer<T> : IEqualityComparer<T> where T : ISpatialEquatable
    {
        public bool Equals(T x, T y)
        {
            return SpatialObject.Equals2D(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode(GeoContext.Current.EqualityOptions.To2D());
        }
    }
}