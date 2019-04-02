﻿using RL.Geo.Abstractions;
using RL.Geo.Abstractions.Interfaces;
using RL.Geo.IO.GeoJson;

namespace RL.Geo.Geometries
{
	public class Point : Geometry, IPosition
    {
        public static readonly Point Empty = new Point();

        public Point() : this(null)
        {
        }

        public Point(double latitude, double longitude)
        {
            Coordinate = new Coordinate(latitude, longitude);
        }

        public Point(double latitude, double longitude, double elevation)
        {
            Coordinate = new CoordinateZ(latitude, longitude, elevation);
        }

        public Point(double latitude, double longitude, double elevation, double measure)
        {
            Coordinate = new CoordinateZM(latitude, longitude, elevation, measure);
        }

        public Point(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public Coordinate Coordinate { get; set; }

        Coordinate IPosition.GetCoordinate()
        {
            return Coordinate;
        }

        public override bool IsEmpty
        {
            get { return Coordinate == null; }
        }

        public override bool Is3D
        {
            get { return Coordinate != null && Coordinate.Is3D; }
        }

        public override bool IsMeasured
        {
            get { return Coordinate != null && Coordinate.IsMeasured; }
        }

        public override Envelope GetBounds()
        {
            return Coordinate.GetBounds();
        }

        #region Equality methods

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj, SpatialEqualityOptions options)
        {
            var other = obj as Point;
            return !ReferenceEquals(null, other) && Equals(Coordinate, other.Coordinate, options);
        }

        public override int GetHashCode(SpatialEqualityOptions options)
        {
            return (Coordinate != null ? Coordinate.GetHashCode(options) : 0);
        }

        public static bool operator ==(Point left, Point right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;
            return !ReferenceEquals(left, null) && !ReferenceEquals(right, null) && left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        #endregion
    }
}
