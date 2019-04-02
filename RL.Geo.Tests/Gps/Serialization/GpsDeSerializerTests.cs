﻿using System.IO;
using System.Linq;
using NUnit.Framework;
using RL.Geo.Gps;

namespace RL.Geo.Tests.Gps.Serialization
{
    [TestFixture]
    public class GpsDeSerializerTests : SerializerTestFixtureBase
    {
        [Test]
        public void ImageFileTest()
        {
            var file = GetReferenceFileDirectory().GetFiles().First(x => x.Name == "image.png");
            using (var stream = new FileStream(file.FullName, FileMode.Open))
            {
                var data = GpsData.Parse(stream);

                Assert.That(data, Is.EqualTo(null));
            }
        }
    }
}
