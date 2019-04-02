using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.Gpx.Gpx11
{
    [XmlType(Namespace="http://www.topografix.com/GPX/1/1")]
    public class GpxTrackSegment {
        [XmlElement("trkpt")]
        public GpxWaypoint[] trkpt { get; set; }

        //public extensionsType extensions { get; set; }
    }
}