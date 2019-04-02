using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.Gpx.Gpx11
{
    [XmlType(Namespace="http://www.topografix.com/GPX/1/1")]
    public class GpxPerson {
        public string name { get; set; }

        public GpxEmail email { get; set; }

        public GpxLink link { get; set; }
    }
}