using System.Xml.Serialization;

namespace RL.Geo.Gps.Serialization.Xml.PocketFms
{
    [XmlType(AnonymousType=true)]
    public class PocketFmsValue<T>
    {
        [XmlAttribute]
        public T Value { get; set; }
    }
}