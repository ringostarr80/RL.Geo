using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.PocketFms
{
    [XmlType(AnonymousType = true)]
    public class PocketFmsMeasureSpecified<T> : PocketFmsMeasure<T>
    {
        [XmlIgnore]
        public bool ValueSpecified { get; set; }
    }
}