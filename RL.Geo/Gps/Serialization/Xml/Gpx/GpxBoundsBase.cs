using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.Gpx
{
    public abstract class GpxBoundsBase
    {
        [XmlAttribute]
        public decimal minlat { get; set; }

        [XmlAttribute]
        public decimal minlon { get; set; }

        [XmlAttribute]
        public decimal maxlat { get; set; }

        [XmlAttribute]
        public decimal maxlon { get; set; }
    }
}