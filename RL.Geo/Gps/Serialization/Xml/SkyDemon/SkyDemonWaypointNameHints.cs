using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.SkyDemon
{
    [XmlType(AnonymousType=true)]
    public class SkyDemonWaypointNameHints {
        [XmlElement("Hint", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public SkyDemonWaypointNameHint[] Hint { get; set; }
    }
}