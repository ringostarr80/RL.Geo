﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geo.Measure;

namespace Geo.Geometries
{
    public class LineString : LineString<Point>
    {
        public LineString()
        {
        }

        public LineString(IEnumerable<Point> items) : base(items)
        {
        }
    }

    public class LineString<T> : IGeometry, IWktShape, IWktPart where T : class, IPoint
    {
        public LineString()
        {
            Points = new List<T>();
        }

        public LineString(IEnumerable<T> items)
        {
            Points = new List<T>(items);
        }

        public List<T> Points { get; protected set; }

        public T StartPoint
        {
            get
            {
                return IsEmpty ? default(T) : Points[0];
            }
        }

        public T EndPoint
        {
            get
            {
                return IsEmpty ? default(T) : Points[Points.Count - 1];
            }
        }

        public Distance CalculateLength()
        {
            var distance = new Distance(0);

            if (!IsEmpty)
            {

                for (var i = 1; i < Points.Count; i++)
                {
                    var line = Points[i - 1].CalculateShortestLine(Points[i]);
                    if(line !=null)
                        distance += line.Distance;
                }
            }

            return distance;
        }

        public bool IsEmpty
        {
            get { return Points.Count == 0; }
        }

        public bool IsClosed
        {
            get { return !IsEmpty && StartPoint == EndPoint; }
        }

        public Bounds GetBounds()
        {
            return IsEmpty ? null :
                new Bounds(Points.Min(x => x.Latitude), Points.Min(x => x.Longitude), Points.Max(x => x.Latitude), Points.Max(x => x.Longitude));
        }

        public string ToWktPartString()
        {
            var buf = new StringBuilder();
            if (IsEmpty)
                buf.Append("EMPTY");
            else
            {
                buf.Append("(");
                for (var i = 0; i < Points.Count; i++)
                {
                    if (i > 0)
                        buf.Append(", ");
                    buf.Append(Points[i].ToWktPartString());
                }
                buf.Append(")");
            }
            return buf.ToString();
        }

        public string ToWktString()
        {
            var buf = new StringBuilder();
            buf.Append("LINESTRING ");
            buf.Append(ToWktPartString());
            return buf.ToString();
        }

        public T this[int index]
        {
            get { return Points[index]; }
        }

        public void Add(T point)
        {
            Points.Add(point);
        }
    }
}
