using NUnit.Framework;

namespace RL.Geo.Tests
{
    [TestFixture]
    public class CoordinateTests
    {
        [TestCase("     42.294498        -89.637901         ", 42.294498, -89.637901)]
        [TestCase("12 34.56'N 123 45.55'E", 12.576, 123.75916666666667)]
        [TestCase("12.345°N 123.456°E", 12.345, 123.456)]
        [TestCase("12.345N 123.456E", 12.345, 123.456)]
        [TestCase("12°N 34°W", 12, -34)]
        [TestCase("42.294498, -89.637901", 42.294498, -89.637901)]
        [TestCase("(42.294498, -89.637901)", 42.294498, -89.637901)]
        [TestCase("[42.294498, -89.637901]", 42.294498, -89.637901)]
        [TestCase(" ( 42.294498, -89.637901 ) ", 42.294498, -89.637901)]
        [TestCase("42° 17′ 40″ N, 89° 38′ 16″ W", 42.294444444444444d, -89.637777777777785d)]
        public void Parse(string coordinate, double latitude, double longitude)
        {
            var result = Coordinate.Parse(coordinate);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Latitude, Is.EqualTo(latitude));
            Assert.That(result.Longitude, Is.EqualTo(longitude));
        }

        [Test]
        public void Equality_Elevation()
        {
            Assert.That(new CoordinateZ(0, 0, 0).Equals(new CoordinateZ(0, 0, 0), new SpatialEqualityOptions{ UseElevation = true }), Is.True);
            Assert.That(new CoordinateZ(0, 0, 0).Equals(new CoordinateZ(0, 0, 10), new SpatialEqualityOptions{ UseElevation = true }), Is.False);
            Assert.That(new CoordinateZ(0, 0, 0).Equals(new CoordinateZ(0, 0, 10), new SpatialEqualityOptions{ UseElevation = false }), Is.True);
        }

        [Test]
        public void Equality_M()
        {
            Assert.That(new CoordinateZM(0, 0, 0, 0).Equals(new CoordinateZM(0, 0, 0, 0), new SpatialEqualityOptions { UseM = true }), Is.True);
            Assert.That(new CoordinateZM(0, 0, 0, 0).Equals(new CoordinateZM(0, 0, 0, 10), new SpatialEqualityOptions { UseM = true }), Is.False);
            Assert.That(new CoordinateZM(0, 0, 0, 0).Equals(new CoordinateZM(0, 0, 0, 10), new SpatialEqualityOptions { UseM = false }), Is.True);
        }

        [Test]
        public void Equality_PoleCoordinates()
        {
            Assert.That(new CoordinateZM(90, 0, 0, 0).Equals(new CoordinateZM(90, 180, 0, 0), new SpatialEqualityOptions { PoleCoordiantesAreEqual = true }), Is.True);
            Assert.That(new CoordinateZM(90, 0, 0, 0).Equals(new CoordinateZM(90, 180, 0, 0), new SpatialEqualityOptions { PoleCoordiantesAreEqual = false }), Is.False);
        }

        [Test]
        public void Equality_AntiMeridianCoordinates()
        {
            Assert.That(new Coordinate(4, 180).Equals(new Coordinate(4, -180), new SpatialEqualityOptions{ AntiMeridianCoordinatesAreEqual = true }), Is.True);
            Assert.That(new Coordinate(4, 180).Equals(new Coordinate(4, -180), new SpatialEqualityOptions{ AntiMeridianCoordinatesAreEqual = false }), Is.False);
        }
    }
}
