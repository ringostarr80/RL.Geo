using System;
using System.IO;
using NUnit.Framework;
using RL.Geo.IO.Wkt;
using RL.Geo.Geometries;

namespace RL.Geo.Tests.IO.Wkt
{
    [TestFixture]
    public class WktReaderTests
    {
        [Test]
        public void Invalid_geometry_type()
        {
            Assert.Throws<System.Runtime.Serialization.SerializationException>(() => {
                var reader = new WktReader();
                reader.Read("SOMETHING EMPTY");
            });
        }

        [Test]
        public void Null_input_string_throws_argument_exception()
        {
            Assert.Throws<ArgumentNullException>(() => {
                var reader = new WktReader();
                reader.Read((string) null);
            });
        }

        [Test]
        public void Null_input_stream_throws_argument_exception()
        {
            Assert.Throws<ArgumentNullException>(() => {
                var reader = new WktReader();
                reader.Read((Stream)null);
            });
        }

        [Test]
        public void Null()
        {
            var reader = new WktReader();

            var nothing = reader.Read("");
            Assert.That(nothing, Is.Null);
        }

        [Test]
        public void ExponentialNumber()
        {
            var reader = new WktReader();

            var xyWithE = reader.Read("POINT (5.5980439826435563E-06 -71.4920233210601)");
            Assert.That(xyWithE, Is.EqualTo(new Point(-71.4920233210601, 5.5980439826435563E-06)));
        }

        [Test]
        public void Point()
        {
            var reader = new WktReader();

            var xy = reader.Read("POINT (0.0 65.9)");
            Assert.That(xy, Is.EqualTo(new Point(65.9, 0)));

            var xyz = reader.Read("POINT Z (0.0 65.9 5)");
            Assert.That(xyz, Is.EqualTo(new Point(65.9, 0, 5)));

            var xyz2 = reader.Read("POINT (0.0 65.9 5)");
            Assert.That(xyz2, Is.EqualTo(new Point(65.9, 0, 5)));

            var xym = reader.Read("POINT M (0.0 65.9 5)");
            Assert.That(xym, Is.EqualTo(new Point(new CoordinateM(65.9, 0, 5))));

            var xyzm = reader.Read("POINT ZM (0.0 65.9 4 5)");
            Assert.That(xyzm, Is.EqualTo(new Point(65.9, 0, 4, 5)));

            var xyzm2 = reader.Read("POINT (0.0 65.9 4 5)");
            Assert.That(xyzm2, Is.EqualTo(new Point(65.9, 0, 4, 5)));

            var empty = reader.Read("POINT ZM EMPTY");
            Assert.That(empty, Is.EqualTo(global::RL.Geo.Geometries.Point.Empty));
        }

        [Test]
        public void LineString()
        {
            var reader = new WktReader();

            var xy = reader.Read("LINESTRING (0.0 65.9, -34.5 9)");
            Assert.That(xy, Is.EqualTo(new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5))));

            var empty = reader.Read("LINESTRING ZM EMPTY");
            Assert.That(empty, Is.EqualTo(new LineString()));
        }

        [Test]
        public void LinearRing()
        {
            var reader = new WktReader();

            var xy = reader.Read("LINEARRING (0.0 65.9, -34.5 9, 5.0 65.9, 0.0 65.9)");
            Assert.That(xy, Is.EqualTo(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(65.9, 5), new Coordinate(65.9, 0))));

            var empty = reader.Read("LINEARRING ZM EMPTY");
            Assert.That(empty, Is.EqualTo(new LinearRing()));
        }

        [Test]
        public void Polygon()
        {
            var reader = new WktReader();

            var xy = reader.Read("POLYGON ((0.0 65.9, -34.5 9, -20 40, 0 65.9))");
            Assert.That(xy, Is.EqualTo(new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)))));

            var empty = reader.Read("POLYGON ZM EMPTY");
            Assert.That(empty, Is.EqualTo(global::RL.Geo.Geometries.Polygon.Empty));
        }

        [Test]
        public void Triangle()
        {
            var reader = new WktReader();

            var xy = reader.Read("TRIANGLE ((0.0 65.9, -34.5 9, -20 40, 0 65.9))");
            Assert.That(xy, Is.EqualTo(new Triangle(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)))));

            var empty = reader.Read("Triangle ZM EMPTY");
            Assert.That(empty, Is.EqualTo(global::RL.Geo.Geometries.Triangle.Empty));
        }

        [Test]
        public void GeometryCollection()
        {
            var reader = new WktReader();

            var points = reader.Read("GEOMETRYCOLLECTION (POINT (0.0 65.9), POINT (-34.5 9), POINT  (-20 40), POINT (0 65.9))");
            Assert.That(points, Is.EqualTo(new GeometryCollection(new Point(65.9, 0), new Point(9, -34.5), new Point(40, -20), new Point(65.9, 0))));

            var empty = reader.Read("GEOMETRYCOLLECTION ZM EMPTY");
            Assert.That(empty, Is.EqualTo(new GeometryCollection()));
        }

        [Test]
        public void MultiPoint()
        {
            var reader = new WktReader();

            var none = reader.Read("MULTIPOINT (0.0 65.9, -34.5 9, -20 40, 0 65.9)");
            Assert.That(none, Is.EqualTo(new MultiPoint(new Point(65.9, 0), new Point(9, -34.5), new Point(40, -20), new Point(65.9, 0))));
            
            var brackets = reader.Read("MULTIPOINT (EMPTY, (0.0 65.9), (-34.5 9), (-20 40), (0 65.9))");
            Assert.That(brackets, Is.EqualTo(new MultiPoint(new Point(), new Point(65.9, 0), new Point(9, -34.5), new Point(40, -20), new Point(65.9, 0))));

            var empty = reader.Read("MULTIPOINT ZM EMPTY");
            Assert.That(empty, Is.EqualTo(new MultiPoint()));
        }

        [Test]
        public void MultiLineString()
        {
            var reader = new WktReader();

            var one = reader.Read("MULTILINESTRING ((0.0 65.9, -34.5 9, -20 40, 0 65.9))");
            Assert.That(one, Is.EqualTo(new MultiLineString(new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)))));

            var two = reader.Read("MULTILINESTRING ((0.0 65.9, -34.5 9, -20 40, 0 65.9), (0.0 65.9, -34.5 9, -20 40, 0 65.9))");
            Assert.That(two, Is.EqualTo(new MultiLineString(new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)), new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)))));

            var empty = reader.Read("MULTILINESTRING ZM EMPTY");
            Assert.That(empty, Is.EqualTo(new MultiLineString()));
        }

        [Test]
        public void MultiPolygon()
        {
            var reader = new WktReader();

            var one = reader.Read("MULTIPOLYGON (((0.0 65.9, -34.5 9, -20 40, 0 65.9)))");
            Assert.That(one, Is.EqualTo(new MultiPolygon(new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))))));

            var two = reader.Read("MULTIPOLYGON (((0.0 65.9, -34.5 9, -20 40, 0 65.9)),((0.0 65.9, -34.5 9, -20 40, 0 65.9)))");
            Assert.That(two, Is.EqualTo(new MultiPolygon(new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))), new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))))));

            var empty = reader.Read("MULTIPOLYGON ZM EMPTY");
            Assert.That(empty, Is.EqualTo(new MultiPolygon()));
        }
    }
}
