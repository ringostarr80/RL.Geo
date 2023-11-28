using NUnit.Framework;
using RL.Geo.IO.Wkt;
using RL.Geo.Geometries;

namespace RL.Geo.Tests.IO.Wkt
{
    [TestFixture]
    public class WktWriterTests
    {
        [Test]
        public void Point()
        {
            var writer = new WktWriter();

            var xy = writer.Write(new Point(65.9, 0));
            Assert.That(xy, Is.EqualTo("POINT (0 65.9)"));

            var xyz = writer.Write(new Point(65.9, 0, 5));
            Assert.That(xyz, Is.EqualTo("POINT Z (0 65.9 5)"));

            var xym = writer.Write(new Point(new CoordinateM(65.9, 0, 5)));
            Assert.That(xym, Is.EqualTo("POINT M (0 65.9 5)"));

            var xyzm = writer.Write(new Point(65.9, 0, 4, 5));
            Assert.That(xyzm, Is.EqualTo("POINT ZM (0 65.9 4 5)"));

            var empty = writer.Write(global::RL.Geo.Geometries.Point.Empty);
            Assert.That(empty, Is.EqualTo("POINT EMPTY"));
        }

        [Test]
        public void LineString()
        {
            var writer = new WktWriter();

            var xy = writer.Write(new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5)));
            Assert.That(xy, Is.EqualTo("LINESTRING (0 65.9, -34.5 9)"));

            var empty = writer.Write(global::RL.Geo.Geometries.LineString.Empty);
            Assert.That(empty, Is.EqualTo("LINESTRING EMPTY"));
        }

        [Test]
        public void LinearRing()
        {
            var writer = new WktWriter();

            var lineString = writer.Write(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(50, 0), new Coordinate(65.9, 0)));
            Assert.That(lineString, Is.EqualTo("LINESTRING (0 65.9, -34.5 9, 0 50, 0 65.9)"));
            
            var writer2 = new WktWriter(new WktWriterSettings { LinearRing = true });

            var linearRing = writer2.Write(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(50, 0), new Coordinate(65.9, 0)));
            Assert.That(linearRing, Is.EqualTo("LINEARRING (0 65.9, -34.5 9, 0 50, 0 65.9)"));

            var empty = writer2.Write(global::RL.Geo.Geometries.LinearRing.Empty);
            Assert.That(empty, Is.EqualTo("LINEARRING EMPTY"));
        }

        [Test]
        public void Polygon()
        {
            var writer = new WktWriter();

            var xy = writer.Write(new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))));
            Assert.That(xy, Is.EqualTo("POLYGON ((0 65.9, -34.5 9, -20 40, 0 65.9))"));

            var empty = writer.Write(global::RL.Geo.Geometries.Polygon.Empty);
            Assert.That(empty, Is.EqualTo("POLYGON EMPTY"));
        }

        [Test]
        public void Triangle()
        {
            var writer = new WktWriter();

            var polygon = writer.Write(new Triangle(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))));
            Assert.That(polygon, Is.EqualTo("POLYGON ((0 65.9, -34.5 9, -20 40, 0 65.9))"));

            var writer2 = new WktWriter(new WktWriterSettings { Triangle = true });

            var triangle = writer2.Write(new Triangle(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))));
            Assert.That(triangle, Is.EqualTo("TRIANGLE ((0 65.9, -34.5 9, -20 40, 0 65.9))"));

            var empty = writer2.Write(global::RL.Geo.Geometries.Triangle.Empty);
            Assert.That(empty, Is.EqualTo("TRIANGLE EMPTY"));
        }

        [Test]
        public void GeometryCollection()
        {
            var writer = new WktWriter();

            var brackets = writer.Write(new GeometryCollection(new Point(65.9, 0), new Point(9, -34.5), new Point(40, -20), new Point(65.9, 0)));
            Assert.That(brackets, Is.EqualTo("GEOMETRYCOLLECTION (POINT (0 65.9), POINT (-34.5 9), POINT (-20 40), POINT (0 65.9))"));

            var empty = writer.Write(new GeometryCollection());
            Assert.That(empty, Is.EqualTo("GEOMETRYCOLLECTION EMPTY"));
        }

        [Test]
        public void MultiPoint()
        {
            var writer = new WktWriter();

            var brackets = writer.Write(new MultiPoint(new Point(65.9, 0), new Point(9, -34.5), new Point(40, -20), new Point(65.9, 0)));
            Assert.That(brackets, Is.EqualTo("MULTIPOINT ((0 65.9), (-34.5 9), (-20 40), (0 65.9))"));

            var empty = writer.Write(new MultiPoint());
            Assert.That(empty, Is.EqualTo("MULTIPOINT EMPTY"));
        }

        [Test]
        public void MultiLineString()
        {
            var writer = new WktWriter();

            var one = writer.Write(new MultiLineString(new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))));
            Assert.That(one, Is.EqualTo("MULTILINESTRING ((0 65.9, -34.5 9, -20 40, 0 65.9))"));

            var two = writer.Write(new MultiLineString(new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)), new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))));
            Assert.That(two, Is.EqualTo("MULTILINESTRING ((0 65.9, -34.5 9, -20 40, 0 65.9), (0 65.9, -34.5 9, -20 40, 0 65.9))"));

            var empty = writer.Write(new MultiLineString());
            Assert.That(empty, Is.EqualTo("MULTILINESTRING EMPTY"));
        }

        [Test]
        public void MultiPolygon()
        {
            var writer = new WktWriter();

            var one = writer.Write(new MultiPolygon(new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)))));
            Assert.That(one, Is.EqualTo("MULTIPOLYGON (((0 65.9, -34.5 9, -20 40, 0 65.9)))"));

            var two = writer.Write(new MultiPolygon(new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))), new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)))));
            Assert.That(two, Is.EqualTo("MULTIPOLYGON (((0 65.9, -34.5 9, -20 40, 0 65.9)), ((0 65.9, -34.5 9, -20 40, 0 65.9)))"));

            var empty = writer.Write(new MultiPolygon());
            Assert.That(empty, Is.EqualTo("MULTIPOLYGON EMPTY"));
        }
    }
}
