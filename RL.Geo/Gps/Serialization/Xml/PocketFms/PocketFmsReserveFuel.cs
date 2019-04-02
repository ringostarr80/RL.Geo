using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.PocketFms
{
    [XmlType(AnonymousType=true)]
    public class PocketFmsReserveFuel : PocketFmsMeasureSpecified<decimal>
    {

        [XmlAttribute]
        public string DurationUnit { get; set; }

        [XmlAttribute]
        public short Duration { get; set; }

        [XmlIgnore]
        public bool DurationSpecified { get; set; }
    }
}