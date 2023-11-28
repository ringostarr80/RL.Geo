using System.Collections.Generic;
using System.Linq;
using RL.Geo.IO.GeoJson;
using NUnit.Framework;
using RL.Geo.Geometries;

namespace RL.Geo.Tests.IO.GeoJson
{
    [TestFixture]
    public class GeoJsonTests
    {
        [Test]
        public void Point()
        {
            var reader = new GeoJsonReader();
            var geo = new Point(0, 0);
            Assert.That(geo.ToGeoJson(), Is.EqualTo(@"{""type"":""Point"",""coordinates"":[0,0]}"));
            Assert.That(reader.Read(geo.ToGeoJson()), Is.EqualTo(geo));
        }

        [Test]
        public void LineString()
        {
            var reader = new GeoJsonReader();
            var geo = new LineString(new Coordinate(0, 0), new Coordinate(1, 1));
            Assert.That(geo.ToGeoJson(), Is.EqualTo(@"{""type"":""LineString"",""coordinates"":[[0,0],[1,1]]}"));
            Assert.That(reader.Read(geo.ToGeoJson()), Is.EqualTo(geo));
        }

        [Test]
        public void Polygon()
        {
            var reader = new GeoJsonReader();
            var geo =
                new Polygon(new LinearRing(new Coordinate(0, 0), new Coordinate(1, 1), new Coordinate(2, 0),
                                           new Coordinate(0, 0)));
            Assert.That(geo.ToGeoJson(), Is.EqualTo(@"{""type"":""Polygon"",""coordinates"":[[[0,0],[1,1],[0,2],[0,0]]]}"));
            Assert.That(reader.Read(geo.ToGeoJson()), Is.EqualTo(geo));
        }

        [Test]
        public void MultiPoint()
        {
            var reader = new GeoJsonReader();
            var geo = new MultiPoint(new Point(0, 0));
            Assert.That(geo.ToGeoJson(), Is.EqualTo(@"{""type"":""MultiPoint"",""coordinates"":[[0,0]]}"));
            Assert.That(reader.Read(geo.ToGeoJson()), Is.EqualTo(geo));
        }

        [Test]
        public void MultiLineString()
        {
            var reader = new GeoJsonReader();
            var geo = new MultiLineString(new LineString(new Coordinate(0, 0), new Coordinate(1, 1)));
            Assert.That(geo.ToGeoJson(), Is.EqualTo(@"{""type"":""MultiLineString"",""coordinates"":[[[0,0],[1,1]]]}"));
            Assert.That(reader.Read(geo.ToGeoJson()), Is.EqualTo(geo));
        }

        [Test]
        public void MultiPolygon()
        {
            var reader = new GeoJsonReader();
            var geo =
                new MultiPolygon(
                    new Polygon(new LinearRing(new Coordinate(0, 0), new Coordinate(1, 1), new Coordinate(2, 0),
                                               new Coordinate(0, 0))));
            Assert.That(geo.ToGeoJson(), Is.EqualTo(@"{""type"":""MultiPolygon"",""coordinates"":[[[[0,0],[1,1],[0,2],[0,0]]]]}"));
            Assert.That(reader.Read(geo.ToGeoJson()), Is.EqualTo(geo));
        }

        [Test]
        public void GeometryCollection()
        {
            var reader = new GeoJsonReader();
            var geo = new GeometryCollection(new Point(0, 0), new Point(1, 0));
            Assert.That(geo.ToGeoJson(), Is.EqualTo(@"{""type"":""GeometryCollection"",""geometries"":[{""type"":""Point"",""coordinates"":[0,0]},{""type"":""Point"",""coordinates"":[0,1]}]}"));
            Assert.That(reader.Read(geo.ToGeoJson()), Is.EqualTo(geo));
        }

        [Test]
        public void Feature()
        {
            var reader = new GeoJsonReader();
            Assert.That(
                new Feature(new Point(0, 0)) { Id = "test-id" }.ToGeoJson(),
                Is.EqualTo(@"{""type"":""Feature"",""geometry"":{""type"":""Point"",""coordinates"":[0,0]},""properties"":null,""id"":""test-id""}")
            );

            Assert.That(
                new Feature(new Point(0, 0), new Dictionary<string, object>()) { Id = "test-id" }.ToGeoJson(),
                Is.EqualTo(@"{""type"":""Feature"",""geometry"":{""type"":""Point"",""coordinates"":[0,0]},""properties"":null,""id"":""test-id""}")
            );

            var feature = new Feature(new Point(0, 0), new Dictionary<string, object>()
                                                           {
                                                               {"name", "test"}
                                                           }) {Id = "test-id"};
            Assert.That(
                feature.ToGeoJson(),
                Is.EqualTo(@"{""type"":""Feature"",""geometry"":{""type"":""Point"",""coordinates"":[0,0]},""properties"":{""name"":""test""},""id"":""test-id""}")
            );

            var feature2 = (Feature) reader.Read(feature.ToGeoJson());
            Assert.That(feature2.Id, Is.EqualTo(feature.Id));
            Assert.That(feature2.Geometry, Is.EqualTo(feature.Geometry));
        }

        [Test]
        public void FeatureCollection()
        {
            var reader = new GeoJsonReader();
            var features = new FeatureCollection(new[] {new Feature(new Point(0, 0)) {Id = "test-id"}});
            Assert.That(
                features.ToGeoJson(),
                Is.EqualTo(@"{""type"":""FeatureCollection"",""features"":[{""type"":""Feature"",""geometry"":{""type"":""Point"",""coordinates"":[0,0]},""properties"":null,""id"":""test-id""}]}")
            );

            var features2 = (FeatureCollection)reader.Read(features.ToGeoJson());
            Assert.That(features2.Features.Single().Geometry, Is.EqualTo(features.Features.Single().Geometry));
        }
    }
}
