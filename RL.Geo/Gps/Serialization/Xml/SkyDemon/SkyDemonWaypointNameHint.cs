using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.SkyDemon
{
    [XmlType(AnonymousType=true)]
    public class SkyDemonWaypointNameHint {
        [XmlAttribute]
        public string Location { get; set; }

        [XmlAttribute]
        public string Name { get; set; }
    }
}